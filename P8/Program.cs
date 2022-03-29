using System;
using static System.Console;
namespace P8
{
    class Program
    {
        static bool EsPalindromo (string analiza)
        {       
            string primero = analiza.Substring(0, analiza.Length / 2);
            char[] arra = analiza.ToCharArray();

            Array.Reverse(arra);

            string temp = new string(arra);
            string segunda = temp.Substring(0, temp.Length / 2);

            return primero.Equals(segunda);
        }

        static string[] palindromos (string palabra)
        {
            string[] pal = { };
            List<string> palList = new List<string>();
            for (int palindromeIndex = 2; palindromeIndex <= palabra.Length; palindromeIndex++)
            {
                for (int t = 0; t <= palabra.Length - palindromeIndex; t++)
                {
                    string guardar = "";
                    for (var x = t; x < t + palindromeIndex; x++)
                    {
                        guardar += palabra[x];
                    }
                    if (EsPalindromo(guardar) && !palList.Contains(guardar))
                    {
                        palList.Add(guardar);
                    }
                }
            }
            pal = palList.ToArray();
            return pal;
        }

        static void Main(string[] args)
        {
            string? palabra;
            palabra = "alasalas";
            string[] linea = palindromos(palabra!);
            WriteLine($"\n\npalabras palindromas encontradas: ");
            WriteLine(String.Join(" ", linea));

        }
        
    }
}