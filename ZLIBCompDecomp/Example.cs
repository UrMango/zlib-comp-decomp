using System;
using System.Text;
using NoamRaz.ZLIB;

class Example
{
	public static void Main()
	{
		// Compress string
		ZLIB.CompressString("Hello ZLIB World!", "MyFolder/MyCompressedFile.zlib");

		// Compress file
		ZLIB.CompressFile("MyFolder/FileToCompress.txt", "MyFolder/MyCompressedFile.zlib");

		// Compress buffer (byte array)
		byte[] buffer = ASCIIEncoding.ASCII.GetBytes("Hello ZLIB World!");
		ZLIB.CompressData(buffer, out byte[] result);
		Console.WriteLine("Compressed Data is: ", result);

		// Decompress compressed file
		ZLIB.Decompress("MyFolder/MyCompressedFile.zlib", "MyFolder/MyDecompressedFile.txt");

		// Decompress buffer (byte array)
		byte[] decompBuffer = ASCIIEncoding.ASCII.GetBytes("Hello ZLIB World!");
		ZLIB.DecompressData(decompBuffer, out byte[] decompResult);
		Console.WriteLine("Compressed Data is: ", ASCIIEncoding.ASCII.GetString(decompResult));

	}
}
