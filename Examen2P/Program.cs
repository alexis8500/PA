using System;
using static System.Console;
namespace Examen2P
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
            Write("Introduzca su string: ");
            string frase = ReadLine();

            bool val = Validar(frase);
            WriteLine(val);

            if (val == true)
            {
                WriteLine("El string es valido");
            }else{
                WriteLine("El string es invalido cheque bien sus corchetes");
            }

        }

        public static bool Validar(string str)
        {
            #region ValidacionVacio

            if (string.IsNullOrEmpty(str))
            {
                return false;
            }

            #endregion

            var hashmap = new Dictionary<char, int>();

            hashmap.Add('(', 0);
            hashmap.Add('{', 0);
            hashmap.Add('[', 0);

            #region NamedParameters
            foreach (var c in str)
            {
                switch (c)
                {
                    case '(':
                        hashmap['(']++;
                        break;
                    case '[':
                        hashmap['[']++;
                        break;
                    case '{':
                        hashmap['{']++;
                        break;
                    case ')':
                        hashmap['(']--;
                        break;
                    case ']':
                        hashmap['[']--;
                        break;
                    case '}':
                        hashmap['{']--;
                        break;
                }
            }
            #endregion

            return hashmap['('] == 0 && hashmap['{'] == 0 && hashmap['['] == 0;
        }
    }
}