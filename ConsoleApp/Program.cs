using System;
using System.Collections.Generic;
using PudelkoLibrary;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Pudelko> listaPudelek = new List<Pudelko>();
            listaPudelek.Add(new Pudelko());
            listaPudelek.Add(new Pudelko(1));
            listaPudelek.Add(new Pudelko(2, 5));
            listaPudelek.Add(new Pudelko(7, 8, 3));
            listaPudelek.Add(Pudelko.Parse("2,500 m × 4,700 m × 1,990 m"));
            listaPudelek.Add(new Pudelko(9, 5, 3, UnitOfMeasure.meter));
            listaPudelek.Add(new Pudelko(2, 7, 5, UnitOfMeasure.meter));
            listaPudelek.Add(new Pudelko(4, 9, 7, UnitOfMeasure.meter));
            listaPudelek.Add(new Pudelko(6, 2, 9, UnitOfMeasure.meter));
            listaPudelek.Add(new Pudelko(80, 4, 10, UnitOfMeasure.centimeter));
            listaPudelek.Add(new Pudelko(1, 6, 10, UnitOfMeasure.centimeter));
            listaPudelek.Add(new Pudelko(40, 8, 5, UnitOfMeasure.centimeter));
            listaPudelek.Add(new Pudelko(60, 10, 70, UnitOfMeasure.milimeter));
            listaPudelek.Add(new Pudelko(70, 30, 90, UnitOfMeasure.milimeter));
            listaPudelek.Add(new Pudelko(90, 50, 20, UnitOfMeasure.milimeter));
            Console.WriteLine("Lista nieposortowana");
            foreach (var item in listaPudelek)
            {
                Console.WriteLine(item);
            }
            static int ComparePudelka(Pudelko p1, Pudelko p2) {
                if (p1.Objetosc < p2.Objetosc)
                {
                    return -1;
                } 
                else if(p1.Objetosc < p2.Objetosc)
                {
                    return 1;
                } 
                else
                {
                    if(p1.Pole < p2.Pole)
                    {
                        return -1;
                    }
                    else if(p1.Pole > p2.Pole)
                    {
                        return 1;
                    }
                    else
                    {
                        if (p1.A + p1.B + p1.C < p2.A + p2.B + p2.C)
                        {
                            return -1;
                        }else if (p1.A + p1.B + p1.C > p2.A + p2.B + p2.C)
                        {
                            return 1;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
            }
            listaPudelek.Sort(ComparePudelka);
            Console.WriteLine("Lista posortowana");
            foreach (var item in listaPudelek)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Operator + {listaPudelek[0]} + {listaPudelek[1]} = {listaPudelek[0] + listaPudelek[1]}");
            Console.WriteLine($"Operator == {listaPudelek[0]} z {listaPudelek[1]} = {listaPudelek[0] == listaPudelek[1]}");
            Console.WriteLine($"Operator == {new Pudelko()} z {new Pudelko()} = {new Pudelko() == new Pudelko()}");
            Console.WriteLine($"Operator != {listaPudelek[0]} z {listaPudelek[1]} = {listaPudelek[0] != listaPudelek[1]}");
            Console.WriteLine($"Operator != {new Pudelko()} z {new Pudelko()} = {new Pudelko() != new Pudelko()}");
            Console.WriteLine("Indexer");
            foreach (var item in listaPudelek[0])
            {
                Console.WriteLine(item);
            }
        }
    }
}
