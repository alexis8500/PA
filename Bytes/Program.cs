using System;
using static System.Console;
namespace Bytes
{
    class Program
    {
        static void Main (string[] args)
        {
            #region Bytes

                byte[] bytes = new byte[128];

                (new Random()).NextBytes(bytes);

                WriteLine("Bytes");
                for (var i = 0; i < bytes.Length; i++)
                {
                    Write($"{bytes[i]} ");
                }
                
                WriteLine("\n\nBytes a hexa");
                for (var i = 0; i < bytes.Length; i++)
                {
                    Write($"{bytes[i]:X} ");
                }

                WriteLine("\n\nBytes a string");

                string str = Convert.ToBase64String(bytes);
                
                WriteLine($"{str}");

            #endregion
        }
    }
}