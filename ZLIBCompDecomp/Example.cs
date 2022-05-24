using System;
using System.Text;
using NoamRaz.ZLIB;

class Example
{
	public static void Main()
	{
		Encoding encoding = UTF8Encoding.UTF8;

		// Compress string
		ZLIB.CompressString("Hello ZLIB World!", "MyFolder/MyCompressedFile.zlib", encoding);

		// Compress file
		ZLIB.CompressFile("MyFolder/FileToCompress.txt", "MyFolder/MyCompressedFile.zlib", encoding);

		// Compress buffer (byte array)
		byte[] buffer = UTF8Encoding.UTF8.GetBytes("Hello ZLIB World!");
		ZLIB.CompressData(buffer, out byte[] result);
		Console.WriteLine("Compressed Data is: ", result);

		// Decompress compressed file
		ZLIB.Decompress("MyFolder/MyCompressedFile.zlib", "MyFolder/MyDecompressedFile.txt", encoding);

		// Decompress buffer (byte array)
		byte[] decompBuffer = encoding.GetBytes("Hello ZLIB World!");
		ZLIB.DecompressData(decompBuffer, out byte[] decompResult);
		Console.WriteLine("Compressed Data is: ", encoding.GetString(decompResult));

	}
}
