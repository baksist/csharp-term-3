using System;
using System.IO;
using System.IO.Compression;

namespace pr_02_03_02
{
    class Program
    {
        static void CompressFile(string inFilename, string outFilename)
        {
            FileStream sourceFile = File.OpenRead(inFilename);
            FileStream destFile = File.OpenWrite(outFilename);
            GZipStream compStream = new GZipStream(destFile, CompressionMode.Compress);
            int theByte = sourceFile.ReadByte();
            while (theByte != -1)
            {    
                compStream.WriteByte((byte)theByte);
                theByte = sourceFile.ReadByte();
            }

            compStream.Close();
            sourceFile.Close();
            destFile.Close();
        }

        static void UncompressFile(string inFilename, string outFilename)
        {
            FileStream sourceFile = File.OpenRead(inFilename);
            FileStream destFile = File.OpenWrite(outFilename);
            GZipStream compStream = new GZipStream(sourceFile, CompressionMode.Decompress);
            int theByte = compStream.ReadByte();
            while (theByte != -1)
            {    
                destFile.WriteByte((byte)theByte);
                theByte = compStream.ReadByte();
            }

            destFile.Close();
            compStream.Close();
            sourceFile.Close();
        }

        static void Main(string[] args)
        {
            string path_src = "/home/matt/test.txt";
            string path_cmp = "/home/matt/test.txt.gz";
            string path_uncmp = "/home/matt/uncmp.txt";
            CompressFile(path_src, path_cmp);
            UncompressFile(path_cmp, path_uncmp);
        }
    }
}