# ZLIB Compressor & Decompressor
![License](https://img.shields.io/aur/license/apache-spark)
![Nuget](https://img.shields.io/badge/NuGet%20Package%20Required-zlib.net-orange)
[![Release](https://img.shields.io/github/v/release/UrMango/zlib-comp-decomp?color=%23)](https://github.com/UrMango/zlib-comp-decomp/releases)
[![Follow](https://img.shields.io/github/followers/UrMango?label=Follow%20Me&style=social)](https://github.com/UrMango)

**ZLIB Binary Compressor & Decompressor written in C-Sharp (C#)**

The best easy to use compressor & decompressor for zlib built in c-sharp is ready for you to use for you projects free and open source!

Options the library has to offer:

 - Compress file content, string, and buffers (Byte array).
 - Decompress any compressed file

Example for using the library:

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
			Console.WriteLine("Compressed Data is: ", ASCIIEncoding.ASCII.GetString(decompResult);
		
		}
	}

GOOD LUCK!
