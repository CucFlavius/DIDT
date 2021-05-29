using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DIDT
{
    public class File
    {
        public static Dictionary<string, string> extensionMap = new Dictionary<string, string>()
            {
                { "ParticleSystem", "diPs" },
                { "Model", "diMdl" },
                { "Material", "diMat" },
                { "Texture2D", "diTex" },
                { "Mesh", "diMsh" },
                { "CollisionShape", "diCol" },
                { "LodModel", "diLod" },
                { "SkinSkeleton", "diSkl" },
                { "NavigateMap", "diNav" },
                { "NavigateMapFragment", "diNavf" },
                { "Terrain", "terrain" },
                { "Animation", "diAni" },
                { "PVSCube", "diPvs" },
                { "Impostor", "diImp" },
                { "Puppet", "diPup" },
                { "Prefab", "diPre" },
            };

        ushort unk1;
        ushort unk2;
        byte[] fileHash;
        byte[] fileNameBytes;
        string fileName;
        ushort folderIndex;
        ushort typeIndex;
        List<byte[]> relatedHashes;

        public File(BinaryReader br)
        {
            unk1 = br.ReadUInt16();
            unk2 = br.ReadUInt16();
            br.BaseStream.Position++;
            fileHash = br.ReadBytes(16);
            ushort fileNameSize = br.ReadUInt16();
            fileNameBytes = br.ReadBytes(fileNameSize);              // have to read this way because if using ReadChars it's not guaranteed to read just 1 byte per char
            folderIndex = br.ReadUInt16();
            typeIndex = br.ReadUInt16();
            ushort relatedHashCount = br.ReadUInt16();
            relatedHashes = new List<byte[]>();
            for (int i = 0; i < relatedHashCount; i++)
            {
                relatedHashes.Add(br.ReadBytes(16));
            }
        }

        public int GetFileTypeIndex()
        {
            return typeIndex;
        }

        public string GetFileName(bool createExtension = false)
        {
            if (fileName == null)
            {
                char[] fileNameChars = Encoding.UTF8.GetChars(fileNameBytes);
                fileName = new string(fileNameChars);
            }

            return fileName;
        }

        public int GetFolderIndex()
        {
            return folderIndex;
        }

        public byte[] GetHash() { return fileHash; }

        public string GetHashName()
        {
            string hex = BitConverter.ToString(fileHash);
            string[] s = hex.Split('-');

            string name = s[0] + s[1] + s[2] + s[3] + "-" + s[4] + s[5] + "-" + s[6] + s[7] + "-" + s[8] + s[9] + "-" +
                s[10] + s[11] + s[12] + s[13] + s[14] + s[15];

            return name;
        }

        public string GetHashPath()
        {
            return GenerateHashPath(fileHash);
        }

        string GenerateHashPath(byte[] hash)
        {
            string hex = BitConverter.ToString(hash);
            string[] s = hex.Split('-');

            string path = s[0] + @"\" + s[0] + s[1] + s[2] + s[3] + "-" + s[4] + s[5] + "-" + s[6] + s[7] + "-" + s[8] + s[9] + "-" +
                s[10] + s[11] + s[12] + s[13] + s[14] + s[15];

            return path;
        }

        public List<byte[]> GetRelatedHashes() { return relatedHashes; }

        public List<string> GetRelatedHashPaths()
        {
            if (relatedHashes == null) return null;

            List<string> hashes = new List<string>();
            for (int i = 0; i < relatedHashes.Count; i++)
            {
                hashes.Add(GenerateHashPath(relatedHashes[i]));
            }
            return hashes;
        }
    }
}
