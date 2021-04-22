using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIDT
{
    public static class DataTool
    {
        public static string updateDomainURL = @"https://g67ena.update.easebar.com/";
        public static string gphDomainURL = @"https://g67ena.gph.easebar.com/";
        static string medium = "medium";
        static string cacheDir = AppContext.BaseDirectory + @"\Cache\";

        public static string osTypeString;
        public static string gameVersionString;

        public static string patchListUrl;
        public static string patchListFileName;
        public static string downloadUUID;
        public static PatchList patchList;

        public static string indexURL;
        public static string indexFileName;
        public static Index index;

        public enum OSType { IOS = 0, Android = 1 };

        public enum GameVersion { PublicAlpha1, PublicAlpha2 };

        public static Dictionary<GameVersion, string> gameVersionLinkStrings = new Dictionary<GameVersion, string>()
        { 
            { GameVersion.PublicAlpha1, "PubAlpha1ROW" },
            { GameVersion.PublicAlpha2, "PubAlpha2ROW" },
        };

        /// <summary>
        /// Run on startup
        /// </summary>
        public static void Initialize(MainWindow window)
        {
            window.Initialize();
        }

        /// <summary>
        /// Begin a new session
        /// </summary>
        public static void BeginSession()
        {
            // https://mbdl.update.easebar.com/g67ena.mbdl -- gives base64 encoded text that contains domain names -- https://www.base64decode.org/

            DownloadPatchList();
        }

        static void DownloadPatchList()
        {
            if (!Directory.Exists(cacheDir))
                Directory.CreateDirectory(cacheDir);

            patchListUrl = Program.window.GetPatchListPath();
            osTypeString = Program.window.GetOSTypeString();
            gameVersionString = Program.window.GetGameVersionString();
            patchListFileName = Path.GetFileNameWithoutExtension(patchListUrl);

            try
            {
                using (WebClient wc = new WebClient())
                {
                    wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                    wc.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadPatchListCallback);
                    wc.DownloadFileAsync(
                        // Param1 = Link of file
                        new System.Uri(patchListUrl),
                        // Param2 = Path to save
                        cacheDir + patchListFileName
                    );
                }
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }

        static void DownloadPatchListCallback(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                Debug.Log("File download cancelled.");
            }

            if (e.Error != null)
            {
                Debug.Log(e.Error.ToString());
            }

            using (Stream str = File.OpenRead(cacheDir + patchListFileName))
            {
                using (StreamReader reader = new StreamReader(str))
                {
                    string jsonData = reader.ReadToEnd();
                    patchList = JsonConvert.DeserializeObject<PatchList>(jsonData);

                    downloadUUID = patchList.GetFullUUID();
                    Debug.Log("Found UUID : " + downloadUUID);

                    indexURL = @"https://g67ena.gph.easebar.com/" + downloadUUID + "/" + osTypeString.ToLower() + "_" + medium + "_" + "index";
                    DownloadIndex();
                }
            }
        }

        static void DownloadIndex()
        {
            indexFileName = Path.GetFileNameWithoutExtension(indexURL);
            try
            {
                using (WebClient wc = new WebClient())
                {
                    wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                    wc.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadIndexCallback);
                    wc.DownloadFileAsync(
                        // Param1 = Link of file
                        new System.Uri(indexURL),
                        // Param2 = Path to save
                        cacheDir + indexFileName
                    );
                }
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }

        static void DownloadIndexCallback(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                Debug.Log("File download cancelled.");
            }

            if (e.Error != null)
            {
                Debug.Log(e.Error.ToString());
            }

            using (Stream str = File.OpenRead(cacheDir + indexFileName))
            {
                using (BinaryReader br = new BinaryReader(str))
                {
                    index = new Index(br);
                }
            }

            DownloadRepository();
        }

        static void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Program.window.SetProgressBarPercent(e.ProgressPercentage);
        }

        static void DownloadRepository()
        {
            // Create Data Folder //
            string dataDir = AppContext.BaseDirectory + @"\Data_" + gameVersionString + "_" + osTypeString + @"\";
            if (!Directory.Exists(dataDir))
                Directory.CreateDirectory(dataDir);

            // Calculate total files so we can monitor progress //
            float totalFiles = 0;
            for (int b = 0; b < index.blockCount; b++)
            {
                Index.Block block = index.blocks[b];
                totalFiles += block.fileCount;
            }

            Thread thread = new Thread(() =>
            {
                WebClient client = new WebClient();

                float fileCounter = 0;
                for (int b = 0; b < index.blockCount; b++)
                {
                    Index.Block block = index.blocks[b];
                    int blockID = block.ID;

                    // Download each file and merge into a buffer file //
                    string bufferFilePath = cacheDir + @"Block" + blockID + ".buffer";
                    using (var oStr = File.Create(bufferFilePath))
                    {
                        for (int f = 0; f < block.fileCount; f++)
                        {
                            string fileURL = gphDomainURL + downloadUUID + "/" + osTypeString.ToLower() + "_" + medium + "_" + blockID + "." + f;
                            string fileName = Path.GetFileName(fileURL);

                            Debug.Log("Downloading | " + fileURL);
                            byte[] data = client.DownloadData(new Uri(fileURL));

                            Program.window.SetProgressBarPercent((int)((fileCounter / totalFiles) * 100));
                            fileCounter++;

                            using (MemoryStream inputStream = new MemoryStream(data))
                            {
                                inputStream.CopyTo(oStr);
                            }
                        }
                    }

                    Debug.Log("Extracting | " + bufferFilePath);

                    // Process buffer //
                    using (Stream oStr = File.OpenRead(bufferFilePath))
                    {
                        using (BinaryReader br = new BinaryReader(oStr))
                        {
                            while (oStr.Position < oStr.Length)
                            {
                                int strSize = br.ReadInt32();
                                string UUID = new string(br.ReadChars(strSize));
                                int fileSize = br.ReadInt32();
                                char[] hash = br.ReadChars(32);

                                // Read whole file //
                                byte[] data = br.ReadBytes(fileSize);
                                string dir = dataDir + Path.GetDirectoryName(UUID);
                                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
                                File.WriteAllBytes(dataDir + UUID, data);
                                Console.WriteLine(UUID);
                            }
                        }
                    }

                    if (File.Exists(bufferFilePath)) File.Delete(bufferFilePath);
                }

                Debug.Log("Complete");
                Program.window.SetProgressBarPercent(0);
            });

            thread.Start();
        }
    }
}
