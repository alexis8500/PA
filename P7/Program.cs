using System;
using static System.Console;
using PeopleLibrary;

namespace P7
{
    class Program
    {
        static void Main(string[] args)
        {
            //instancia
            var esmeralda = new People();
            
            esmeralda.FirstName = "Esmeralda";
            esmeralda.DateOfBirth = new DateTime(1990, 04, 02);
            esmeralda.vaccine = VaccineApplied.AstraZeneca;
            //instancia explicita
            esmeralda.Children.Add( new People{
                FirstName = "El Brayian", 
                DateOfBirth = DateTime.Now
            });
            for (var childrenIndex = 0; childrenIndex < esmeralda.Children.Count; childrenIndex++)
            {
                WriteLine(esmeralda.Children[childrenIndex].FirstName);
            }
            //Tuplas 2 tipos: facil(dentro de collections), otro tipo(usable como tipo de dato)
            var fruit = esmeralda.GetFruit();
            WriteLine($"There are {fruit.Number} {fruit.Name}");

            System.Collections.Hashtable lookUpObject = new();
            lookUpObject.Add(key: 1, value: "Alexis");
            lookUpObject.Add(key: 2, value: "Alexis");
            lookUpObject.Add(key: 3, value: "Alexis");
            lookUpObject.Add(key: 4, value: "Alexis");
            lookUpObject.Add(key: 5, value: "Alexis");
            lookUpObject.Add(key: esmeralda, value: 2315);
            
            People [] people = {

                new People {FirstName = "Gabo"},
                new People {FirstName = "Alexis"},
                new People {FirstName = "Mario"},
                new People {FirstName = "Isaac"},
                new People {FirstName = "Esmeralda"},
                new People {FirstName = "Virus"},
            };
            foreach (var item in people)
            {
                WriteLine(item.FirstName);
            }
            Array.Sort(people);
            foreach (var item in people)
            {
                WriteLine(item.FirstName);
            }

        }
    }
}