using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace DIDT
{
    public class ResourceRepository
    {
        string[] fileTypes;
        string[] folderPaths;
        Dictionary<string, List<int>> folderFileContents;
        List<File> files;
        Dictionary<byte[], File> hashMap;
        Dictionary<string, uint> hashIndexMap;
        string localDataPath;
        public bool running;
        bool endSession = false;
        Thread workerThread;
        IProgress<int> progress;

        public ResourceRepository(string repoPath, IProgress<int> progress)
        {
            this.localDataPath = Path.GetDirectoryName(repoPath);
            this.progress = progress;

            byte[] decompressedData;

            if (!System.IO.File.Exists(repoPath))
            {
                Debug.Log("Repo file doesn't exist : " + repoPath);
                return;
            }

            // Read Repo //
            using (Stream str = System.IO.File.OpenRead(repoPath))
            {
                using (BinaryReader br = new BinaryReader(str, Encoding.ASCII))
                {
                    string CCCC = new string(br.ReadChars(4));
                    string ZZZ4 = new string(br.ReadChars(4));
                    int uncompressedSize = br.ReadInt32();

                    // Decompress //
                    byte[] compressedData = br.ReadBytes((int)(str.Length - str.Position));
                    LZ4 decompressor = new LZ4();
                    decompressedData = new byte[uncompressedSize];
                    decompressor.DecompressKnownSize(compressedData, decompressedData, uncompressedSize);
                }
            }

            // Parse Repo //
            folderFileContents = new Dictionary<string, List<int>>();
            files = new List<File>();
            hashMap = new Dictionary<byte[], File>(ByteArrayComparer.Default);
            hashIndexMap = new Dictionary<string, uint>(StringComparer.OrdinalIgnoreCase);
            int fileIndex = 0;
            using (MemoryStream ms = new MemoryStream(decompressedData))
            {
                using (BinaryReader br = new BinaryReader(ms, Encoding.ASCII))
                {
                    uint version = br.ReadUInt32();     // probably version, always 1
                    br.ReadUInt16();                    // unknown
                    br.ReadUInt32();                    // empty

                    // Read File Types //
                    ushort sizeOfFileTypeStrings = br.ReadUInt16();
                    string fileTypeData = new string(br.ReadChars(sizeOfFileTypeStrings));
                    fileTypes = fileTypeData.Split(';');

                    // Read Folders //
                    ushort sizeOfFolderStrings = br.ReadUInt16();
                    string folderPathData = new string(br.ReadChars(sizeOfFolderStrings));
                    folderPathData = folderPathData.Replace('/', '\\');
                    folderPaths = folderPathData.Split(';');

                    // Read Files //
                    while (ms.Position < ms.Length)
                    {
                        File file = new File(br);
                        string folderPath = folderPaths[file.GetFolderIndex()];
                        if (folderFileContents.ContainsKey(folderPath))
                        {
                            folderFileContents[folderPath].Add(fileIndex);
                        }
                        else
                        {
                            folderFileContents.Add(folderPath, new List<int>());
                            folderFileContents[folderPath].Add(fileIndex);
                        }
                        var hash = file.GetHash();
                        if (!hashMap.ContainsKey(hash))
                        {
                            files.Add(file);
                            hashMap.Add(file.GetHash(), file);
                            hashIndexMap.Add(file.GetHashName(), (uint)files.Count - 1);
                        }
                        fileIndex++;
                    }
                }
            }
            Debug.Log("Read " + fileIndex + " files in Repository.");
        }

        public void SortFiles(string outputPath)
        {
            workerThread = new Thread(() =>
            {
                int total = files.Count;
                for (int i = 0; i < total; i++)
                {
                    if (endSession)
                    {
                        Debug.Log("Ended.");
                        endSession = false;
                        return;
                    }

                    // Data file //
                    string fileDataPath = localDataPath + "\\" + files[i].GetHashPath();
                    bool dataFileExists = System.IO.File.Exists(fileDataPath);

                    if (!dataFileExists)
                    {
                        // Likely a texture so we check for path.0 -> path.4
                        for (int j = 0; j < 5; j++)
                        {
                            dataFileExists = System.IO.File.Exists(fileDataPath + "." + j);
                            if (dataFileExists)
                            {
                                fileDataPath += "." + j;
                                break;
                            }
                        }
                    }

                    // Sorted file //
                    string fileNameWithExtension = files[i].GetFileName() + "." + fileTypes[files[i].GetFileTypeIndex()];
                    string folderPath = outputPath + "\\" + folderPaths[files[i].GetFolderIndex()] + "\\";

                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);

                    fileNameWithExtension = fileNameWithExtension.Replace("\\", "_");
                    fileNameWithExtension = ReplaceInvalidChars(fileNameWithExtension);

                    if (dataFileExists)
                    {
                        System.IO.File.Move(fileDataPath, folderPath + fileNameWithExtension);
                        Debug.Log(folderPath + fileNameWithExtension);
                    }
                    else
                    {
                        if (!System.IO.File.Exists(folderPath + fileNameWithExtension))
                            Debug.Log("Data file doesn't exist : " + fileDataPath);
                    }

                    this.progress.Report((int)(i / (float)total * 100));
                }

                // Clear empty folders
                ClearEmptyFolders(this.localDataPath);

                Debug.Log("Done");
            });

            workerThread.Start();
        }

        public void DecompressFiles()
        {
            workerThread = new Thread(() =>
            {
                IEnumerable<string> filesList = Directory.EnumerateFiles(localDataPath, "*.*", SearchOption.AllDirectories);
                int total = (from file in filesList select file).Count();
                int index = 0;
                foreach (string file in filesList)
                {
                    if (endSession)
                    {
                        Debug.Log("Ended.");
                        endSession = false;
                        return;
                    }

                    index++;

                    byte[] decompressedData;

                    using (Stream str = System.IO.File.OpenRead(file))
                    {
                        using (BinaryReader br = new BinaryReader(str, Encoding.ASCII))
                        {
                            decompressedData = null;

                            uint ZZZ4 = br.ReadUInt32();
                            if (ZZZ4 != 878336602) continue;

                            int uncompressedSize = br.ReadInt32();

                            // Decompress //
                            byte[] compressedData = br.ReadBytes((int)(str.Length - str.Position));
                            LZ4 decompressor = new LZ4();
                            decompressedData = new byte[uncompressedSize];
                            decompressor.DecompressKnownSize(compressedData, decompressedData, uncompressedSize);
                        }
                    }

                    if (decompressedData != null)
                    {
                        System.IO.File.Delete(file);
                        System.IO.File.WriteAllBytes(file, decompressedData);
                        Debug.Log("Decompressed : " + file);
                    }

                    this.progress.Report((int)(index / (float)total * 100));
                }
            });

            workerThread.Start();
        }

        public void StopWork()
        {
            endSession = true;
        }

        string ReplaceInvalidChars(string filename)
        {
            return string.Join("_", filename.Split(Path.GetInvalidFileNameChars()));
        }

        void ClearEmptyFolders(string startLocation)
        {
            Debug.Log("Clearing empty folders");

            foreach (var directory in Directory.GetDirectories(startLocation))
            {
                ClearEmptyFolders(directory);
                if (Directory.GetFiles(directory).Length == 0 &&
                    Directory.GetDirectories(directory).Length == 0)
                {
                    Directory.Delete(directory, false);
                }
            }
        }
    }
}
