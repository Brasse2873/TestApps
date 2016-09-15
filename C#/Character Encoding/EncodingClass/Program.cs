using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncodingClass
{
    class Program
    {
        static byte[] byteBuffer = new byte[] {0x20,0x31, 0x41, 0x7A, 0x8F, 0x8E, 0x99 };

        static void Main(string[] args)
        {
            PrintArray(byteBuffer);
            TestEncodingStaticMethods();

            TestAsciiEncoding();
        }

        static void TestEncodingStaticMethods()
        {
            Console.WriteLine("\nTestEncodingStaticMethods");
            Console.WriteLine("===========================");
            Console.WriteLine("Encoding.Default:" + Encoding.Default.EncodingName);

            Console.WriteLine("GetEncodings");
            Console.WriteLine("------------");
            EncodingInfo[] infos = Encoding.GetEncodings();
            for(int ix =0; ix<infos.Length;ix++)
            {
                var info = infos[ix];
                Console.WriteLine("Name:{0}, DisplayName:{1},CodePage:{2}", info.Name, info.DisplayName, info.CodePage);
            }

            Console.WriteLine("GetEncoding(utf-8)");
            Console.WriteLine("------------------");
            Encoding encoding = Encoding.GetEncoding("utf-8");
            Console.WriteLine("EncodingName:" + encoding.EncodingName);
            Console.WriteLine("GetType:" + encoding.GetType());
            Console.WriteLine("CodePage:" + encoding.CodePage);
        }

        static void TestAsciiEncoding()
        {
            Encoding asciiEncoding = Encoding.ASCII;

            Console.WriteLine("\nTestAsciiEncoding");
            Console.WriteLine("===========================");
            Console.WriteLine("EncodingName:" + asciiEncoding.EncodingName);
            Console.WriteLine("GetType:" +  asciiEncoding.GetType() );
            Console.WriteLine("CodePage:"+ asciiEncoding.CodePage);

            char[] charBuffer = asciiEncoding.GetString(byteBuffer).ToCharArray();
            Console.WriteLine("GetByteCount:" + asciiEncoding.GetByteCount(charBuffer));
            Console.WriteLine("GetString:" + asciiEncoding.GetString(byteBuffer));
            Console.Write("GetString (bytes):");
            PrintArray(charBuffer);

        }

        static void PrintArray(char[] buffer)
        {
            byte[] byteArray = new byte[buffer.Length*4];
            for(int ix=0,iy=0;ix<buffer.Length;ix++,iy+=2)
            { 
                byte [] bytes = BitConverter.GetBytes(buffer[ix]);
                byteArray[iy] = bytes[0];
                byteArray[iy+1] = bytes[1];
            }
            PrintArray(byteArray);
        }

        static void PrintArray(byte[] buffer)
        {
            for( int ix=0; ix<buffer.Length;ix++)
            { 
                Console.Write( "{0:X2}",buffer[ix]);
                Console.Write(" ");
            }
            Console.Write( System.Environment.NewLine);
        }
    }
}
