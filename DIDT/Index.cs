using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIDT
{
    public struct Index
    {
        public char[] magic;
        public int blockCount;
        public Block[] blocks;

        public Index(BinaryReader br)
        {
            this.magic = br.ReadChars(4);       // HPPK
            this.blockCount = br.ReadInt32();

            this.blocks = new Block[this.blockCount];
            for (int i = 0; i < this.blockCount; i++)
            {
                this.blocks[i] = new Block(br);
            }
        }

        public struct Block
        {
            public int ID;
            public int offset;          // Idk to where
            public int fileCount;
            public int count;           // Idk of what but used to skip data
            public int[] fileSizes;
            public int[] unks;
            public int[] unks2;
            public Hash[] hashes;

            public Block(BinaryReader br)
            {
                this.ID = br.ReadInt32();
                this.offset = br.ReadInt32();
                this.fileCount = br.ReadInt32();
                this.count = br.ReadInt32();
                this.fileSizes = new int[this.fileCount];
                for (int i = 0; i < this.fileCount; i++)
                {
                    this.fileSizes[i] = br.ReadInt32();
                }
                this.unks = new int[this.count * 2];
                for (int i = 0; i < this.count * 2; i++)
                {
                    this.unks[i] = br.ReadInt32();
                }
                this.unks2 = new int[this.count];
                for (int i = 0; i < this.count; i++)
                {
                    this.unks2[i] = br.ReadInt32();
                }
                this.hashes = new Hash[this.fileCount];
                for (int i = 0; i < this.fileCount; i++)
                {
                    this.hashes[i] = new Hash(br);
                }
            }

            public struct Hash
            {
                public byte[] hashA;
                public byte[] hashB;

                public Hash(BinaryReader br)
                {
                    this.hashA = br.ReadBytes(16);
                    this.hashB = br.ReadBytes(16);
                }
            }
        }
    }
}
