using System.IO;
using System.Text;
using zlib;

namespace NoamRaz.ZLIB
{
	class ZLIB
	{
        /// <summary>
        /// Compress string value and save result to a file
        /// </summary>
        /// <param name="compressContent">Text to compress</param>
        /// <param name="compressedFileName">File path to save result in</param>
        /// <returns>Compressed binary data as string</returns>
        public static string CompressString(string compressContent, string compressedFileName)
        {
            byte[] buffer = ASCIIEncoding.ASCII.GetBytes(compressContent);

            CompressData(buffer, out byte[] outData);
            File.WriteAllBytes(compressedFileName, outData);

            return ASCIIEncoding.ASCII.GetString(outData);
        }

        /// <summary>
        /// Compress file content and save result to a file
        /// </summary>
        /// <param name="originalFileName">File to compress</param>
        /// <param name="compressedFileName">File path to save result in</param>
        /// <returns>Compressed binary data as string</returns>
        public static string CompressFile(string originalFileName, string compressedFileName)
        {
            string content = File.ReadAllText(originalFileName);
            return CompressString(content, compressedFileName);
        }

        /// <summary>
        /// Decompress compressed file
        /// </summary>
        /// <param name="compressedFileName">File to decompress</param>
        /// <param name="decompressedFileName">File path to save result in</param>
        /// <returns>Decompressed string data</returns>
        public static string Decompress(string compressedFileName, string decompressedFileName)
        {
            byte[] resBuf = File.ReadAllBytes(compressedFileName);

            DecompressData(resBuf, out byte[] outDataDecomp);
            File.WriteAllText(decompressedFileName, ASCIIEncoding.ASCII.GetString(outDataDecomp));

            return ASCIIEncoding.ASCII.GetString(outDataDecomp);
        }

        /// <summary>
        /// Compress buffer and result to a variable
        /// </summary>
        /// <param name="inData">Buffer to compress</param>
        /// <param name="outData">Buffer to put the compressed data in</param>
        /// <returns></returns>
        public static void CompressData(byte[] inData, out byte[] outData)
        {
            using (MemoryStream outMemoryStream = new MemoryStream())
            using (ZOutputStream outZStream = new ZOutputStream(outMemoryStream, zlibConst.Z_DEFAULT_COMPRESSION))
            using (Stream inMemoryStream = new MemoryStream(inData))
            {
                CopyStream(inMemoryStream, outZStream);
                outZStream.finish();
                outData = outMemoryStream.ToArray();
            }
        }

        /// <summary>
        /// Deompress buffer and result to a variable
        /// </summary>
        /// <param name="inData">Buffer to decompress</param>
        /// <param name="outData">Buffer to put the decompressed data in</param>
        /// <returns></returns>
        public static void DecompressData(byte[] inData, out byte[] outData)
        {
            using (MemoryStream outMemoryStream = new MemoryStream())
            using (ZOutputStream outZStream = new ZOutputStream(outMemoryStream))
            using (Stream inMemoryStream = new MemoryStream(inData))
            {
                CopyStream(inMemoryStream, outZStream);
                outZStream.finish();
                outData = outMemoryStream.ToArray();
            }
        }

        private static void CopyStream(System.IO.Stream input, System.IO.Stream output)
        {
            byte[] buffer = new byte[2000];
            int len;
            while ((len = input.Read(buffer, 0, 2000)) > 0)
            {
                output.Write(buffer, 0, len);
            }
            output.Flush();
        }
    }
}
