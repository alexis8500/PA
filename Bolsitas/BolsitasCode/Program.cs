using System;
using static System.Console;
using BolsitasLib;
using System.Collections.Generic;
using System.Linq;

namespace BolsitasCode
{
    class program
    {
        static void Main()
        {
            float? PlayerNum, bolets;
            string NameIn;
            bool bool1 = true, bool2 = true;
            int RandomEntry, counter = 0;
            uint number;
            List<jugadores> Jug = new List<jugadores>();
            List<uint> JugadorRandom = new List<uint>();
            List<uint> BolsitasRandom = new List<uint>();
            List<List<int>> Bolsitas = new List<List<int>>();
            var rand = new Random();
            do
            {
                WriteLine("Cuantos jugadores habrá? Este numero debe ser par");
                PlayerNum = int.Parse(ReadLine());
            }
            while ((PlayerNum % 2) != 0);
            WriteLine("Cuantos items tendra cada jugador?");
            bolets = int.Parse(ReadLine());
            WriteLine("Introduzca los nombres de los jugadores");
            for (int i = 0; i < PlayerNum; i++)
            {
                NameIn = ReadLine();
                Jug.Add(new(NameIn));
            }
            WriteLine("va");
            Bolsitas = BolsitasInitialize((int)PlayerNum, (int)bolets);
            JugadorRandom = RandomNoRepeats((uint)PlayerNum, (int)PlayerNum);
            foreach (uint numberin in JugadorRandom)
            {
                bool1 = true;
                foreach (List<int> bag in Bolsitas.ToList())
                {
                    if (bag.Count == 0)
                    {
                        Bolsitas.Remove(bag);
                    }
                }
                counter = 0;
                if (JugadorRandom.IndexOf(numberin) == JugadorRandom.Count() - 2)
                {
                    bool1 = false;
                    counter = 0;
                    BolsitasRandom = RandomNoRepeats((uint)bolets, Bolsitas.Count());
                    do
                    {
                        foreach (List<int> bag in Bolsitas)
                        {
                            if (bag.Count == 2)
                            {
                                if (!BolsitasRandom.Contains((uint)Bolsitas.IndexOf(bag)))
                                {
                                    BolsitasRandom[counter] = (uint)Bolsitas.IndexOf(bag);
                                    counter++;
                                }
                            }
                            bool2 = false;
                        }
                        foreach (List<int> bag in Bolsitas)
                        {
                            if (bag.Count == 2)
                            {
                                if (!BolsitasRandom.Contains((uint)Bolsitas.IndexOf(bag)))
                                {
                                    bool2 = true;
                                }
                            }
                        }
                    } while (bool2 == true);
                }
                if (JugadorRandom.IndexOf(numberin) == JugadorRandom.Count() - 3)
                {
                    bool1 = false;
                    counter = 0;
                    BolsitasRandom = RandomNoRepeats((uint)bolets, Bolsitas.Count());
                    do
                    {
                        foreach (List<int> bag in Bolsitas)
                        {
                            if (bag.Count == 3)
                            {
                                if (!BolsitasRandom.Contains((uint)Bolsitas.IndexOf(bag)))
                                {
                                    BolsitasRandom[counter] = (uint)Bolsitas.IndexOf(bag);
                                    counter++;
                                }
                            }
                            bool2 = false;
                        }
                        foreach (List<int> bag in Bolsitas)
                        {
                            if (bag.Count == 3)
                            {
                                if (!BolsitasRandom.Contains((uint)Bolsitas.IndexOf(bag)))
                                {
                                    bool2 = true;
                                }
                            }
                        }
                    } while (bool2 == true);
                }
                if (bool1)
                {
                    BolsitasRandom = RandomNoRepeats((uint)bolets, Bolsitas.Count());
                }
                foreach (int BagNumber in BolsitasRandom)
                {
                    var Randy = new Random();
                    RandomEntry = Randy.Next(Bolsitas[BagNumber].Count);
                    Jug[(int)numberin].Boletos.Add(Bolsitas[BagNumber][RandomEntry]);
                    Bolsitas[BagNumber].RemoveAt(RandomEntry);
                }
            }
            foreach (uint numberin in JugadorRandom)
            {
                WriteLine($"Jugador: {Jug[(int)numberin].Fname}");
                Write("Entradas:    ");
                foreach (int entries in Jug[(int)numberin].Boletos)
                {
                    Write($"    {entries,10}");
                }
                WriteLine("");
                WriteLine("");
            }
        }
        static List<uint> RandomNoRepeats(uint upperbound, int numberbag)
        {
            var rand = new Random();
            List<uint> listNumbers = new List<uint>();
            uint number;
            for (int i = 0; i < upperbound; i++)
            {
                do
                {
                    number = (uint)rand.Next(0, numberbag);
                } while (listNumbers.Contains(number));
                listNumbers.Add(number);
            }
            return listNumbers;
        }
        static List<List<int>> BolsitasInitialize(int BagNum, int TickNum)
        {
            List<List<int>> Bolsitas = new List<List<int>>();
            int e = 1;
            for (int i = 0; i < BagNum; i++)
            {
                List<int> tickets = new List<int>();
                Bolsitas.Add(tickets);
                for (int c = 0; c < TickNum; c++)
                {
                    Bolsitas[i].Add(e);
                    e++;
                }
            }
            return Bolsitas;
        }

    }

}