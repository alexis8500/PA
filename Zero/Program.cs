using System;
using static System.Console;
namespace Zero
{
    class Program
    {
        public static int[] sumZero(int n)
        {
            int[] v = new int[n];
            for (var ZeroIndex = 0; ZeroIndex < n; ZeroIndex++)
            {
                v[ZeroIndex]= 2*ZeroIndex - n + 1;
            }
            return v;
        }
        static void Main(string[] args)
        {
            Write($"ingresa un numero: ");
            string? numero = ReadLine();
            int num = Int32.Parse(numero);
        
            int[] output = sumZero(num);
            for(int i=0;i<num;i++){
                Write(output[i]+" ");
            }
            WriteLine();
        }
    }
}