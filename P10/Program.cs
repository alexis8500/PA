using System;
using static System.Console;
using System.Xml.Serialization;
using static System.Environment;
using static System.IO.Path;
using System.Collections;


namespace P10
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<Person> people = new ()
            {
                new (3000M){
                FirstName = "Pau Pau",
                LastName = "El Variables Culeras",
                DateOfBirth = new (1974, 3, 14)
                },
                new (4000M){
                    FirstName = "Mario",
                LastName = "El Puto",
                DateOfBirth = new (2000, 4, 20),
                Children = new(){
                    new(0M){
                        FirstName = "Dylan",
                        LastName = "Meses",
                        DateOfBirth = new (2022,04,28)
                    }
                }
                },
                new (5000M){
                    FirstName = "Alexis",
                LastName = "El Guapo",
                DateOfBirth = new (2002, 4, 2)
                },
                new (1000M){
                    FirstName = "Sara",
                LastName = "La compañera",
                DateOfBirth = new (2002, 5, 12)
                },

            };

            WorkingWithSerialization(people);
            JsonSerialization(people);
        }
    
        private static void WorkingWithSerialization(List<Person> people)
        {
            // Create an object that helps with the serialize
            XmlSerializer xs = new (people.GetType());
            //Path..
            string path = Combine(CurrentDirectory, "people.xml");
            //auto generated use of an object ... aka ... another way of lambda
            using (FileStream stream = File.Create(path))// <- this shit is efficient
            {
                xs.Serialize(stream, people);
            }
            WriteLine("Written {0:N0} bytes of XML to {1}", arg0: new FileInfo(path).Length, arg1: path);
            WriteLine();
            WriteLine(File.ReadAllText(path));

            using (FileStream xmlLoad = File.Open(path, FileMode.Open))
            {
                //beacuse we SERIALIZE a list of person, we need the same ... to De serialize
                List<Person>? loadedPeople = xs.Deserialize(xmlLoad) as List<Person>;
                if (loadedPeople is not null)
                {
                    foreach(var p in loadedPeople)
                    {
                        WriteLine($"{p.FirstName} {p.LastName} has {p.Children?.Count ?? 0} children");
                    }
                }
            }
            
        }
    
        private static void JsonSerialization(List<Person> people)
        {
            string jsonPath = Combine(CurrentDirectory, "people.json");
            using (StreamWriter jsonStream = File.CreateText(jsonPath))
            {
                Newtonsoft.Json.JsonSerializer jss = new();
                jss.Serialize(jsonStream, people);
            }
            WriteLine("Written {0:N0} bytes of XML to {1}", arg0: new FileInfo(jsonPath).Length, arg1: jsonPath);
            WriteLine();
            WriteLine(File.ReadAllText(jsonPath));
        }
    }
}