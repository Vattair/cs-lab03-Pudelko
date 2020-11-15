using System;
using System.Collections.Generic;
using System.Text;

namespace PudelkoLibrary
{
    public class PudelkoExtensions
    {
        public static Pudelko Kompresuj(Pudelko p)
        {
            double a = Math.Pow(p.Objetosc,(double)1/(double)3);
            Console.WriteLine(a);
            return new Pudelko(a, a, a, UnitOfMeasure.meter);
        }
    }
}
