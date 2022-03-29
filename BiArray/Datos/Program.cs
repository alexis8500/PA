using Array;
using System;
using static System.Console;
namespace Datos
{
    class Program
    {
        static void Main(string[] args)
        {                     //y =  0  1  2
            var array = new int[,] {{1, 2, 3},  //x = 0
                                    {4, 5, 6}}; //    1
            var arr2d = new Array2D<int>(array);

            //foreach (var item in arr2d)
            //{
            //    WriteLine(item);
            //}

            WriteLine(arr2d.ElementAt(1, 0));
        }
    }
}