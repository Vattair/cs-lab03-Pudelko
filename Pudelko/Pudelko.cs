using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace PudelkoLibrary
{
    public sealed class Pudelko : IFormattable, IEquatable<Pudelko>, IEnumerable
    {
        public double A { get; }
        public double B { get; }
        public double C { get; }
        public double Objetosc => Math.Round(A * B * C, 9);
        public double Pole => Math.Round((2 * (A * B)) + (2 * (B * C)) + (2 * (A * C)), 6);

        #region Constructors
        public Pudelko()
        {
            A = 0.1;
            B = 0.1;
            C = 0.1;
        }
        public Pudelko(double a, double b, double c, UnitOfMeasure unit = UnitOfMeasure.meter)
        {
            if (unit == UnitOfMeasure.meter)
            {
                if (a <= 0 || b <= 0 || c <= 0) throw new ArgumentOutOfRangeException();
                if (a > 10 || b > 10 || c > 10) throw new ArgumentOutOfRangeException();
                A = a;
                B = b;
                C = c;
            }
            else if (unit == UnitOfMeasure.centimeter)
            {
                if (a <= 0.1 || b <= 0.1 || c <= 0.1) throw new ArgumentOutOfRangeException();
                if (a > 1000 || b > 1000 || c > 1000) throw new ArgumentOutOfRangeException();
                A = a / 100;
                B = b / 100;
                C = c / 100;
            }
            else if (unit == UnitOfMeasure.milimeter)
            {
                if (a <= 1 || b <= 1 || c <= 1) throw new ArgumentOutOfRangeException();
                if (a > 10000 || b > 10000 || c > 10000) throw new ArgumentOutOfRangeException();
                A = a / 1000;
                B = b / 1000;
                C = c / 1000;
            }
        }
        public Pudelko(double a, double b, UnitOfMeasure unit = UnitOfMeasure.meter)
        {
            if (unit == UnitOfMeasure.meter)
            {
                if (a <= 0 || b <= 0) throw new ArgumentOutOfRangeException();
                if (a > 10 || b > 10) throw new ArgumentOutOfRangeException();
                A = a;
                B = b;
                C = 0.1;
            }
            else if (unit == UnitOfMeasure.centimeter)
            {
                if (a <= 0.01 || b <= 0.01) throw new ArgumentOutOfRangeException();
                if (a > 1000 || b > 1000) throw new ArgumentOutOfRangeException();
                A = a / 100;
                B = b / 100;
                C = 0.1;
            }
            else if (unit == UnitOfMeasure.milimeter)
            {
                if (a <= 1 || b <= 1) throw new ArgumentOutOfRangeException();
                if (a > 10000 || b > 10000) throw new ArgumentOutOfRangeException();
                A = a / 1000;
                B = b / 1000;
                C = 0.1;
            }
        }
        public Pudelko(double a, UnitOfMeasure unit = UnitOfMeasure.meter)
        {
            if (unit == UnitOfMeasure.meter)
            {
                if (a <= 0) throw new ArgumentOutOfRangeException();
                if (a > 10) throw new ArgumentOutOfRangeException();
                A = a;
                B = 0.1;
                C = 0.1;
            }
            else if (unit == UnitOfMeasure.centimeter)
            {
                if (a <= 0.01) throw new ArgumentOutOfRangeException();
                if (a > 1000) throw new ArgumentOutOfRangeException();
                A = a / 100;
                B = 0.1;
                C = 0.1;
            }
            else if (unit == UnitOfMeasure.milimeter)
            {
                if (a <= 1) throw new ArgumentOutOfRangeException();
                if (a > 10000) throw new ArgumentOutOfRangeException();
                A = a / 1000;
                B = 0.1;
                C = 0.1;
            }
        }
        #endregion
        #region IFormattable
        public string ToString(string format, IFormatProvider formatProvider = null)
        {
            if (formatProvider == null) formatProvider = CultureInfo.CurrentCulture;
            switch (format)
            {
                case null:
                    return $"{A:N3} m × {B:N3} m × {C:N3} m";
                    break;
                case "m":
                    return $"{A:N3} {format} × {B:N3} {format} × {C:N3} {format}";
                    break;
                case "cm":
                    return $"{A * 100:N1} {format} × {B * 100:N1} {format} × {C * 100:N1} {format}";
                    break;
                case "mm":
                    return $"{A * 1000} {format} × {B * 1000} {format} × {C * 1000} {format}";
                    break;
                default:
                    throw new FormatException();
                    break;
            }
        }

        public override string ToString()
        {
            return $"{A:N3} m × {B:N3} m × {C:N3} m";
        }
        #endregion
        #region IEquatable
        public bool Equals(Pudelko other)
        {
            if (this.Objetosc == other.Objetosc && this.Pole == other.Pole)
            {
                return true;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return A.GetHashCode() ^ B.GetHashCode() ^ C.GetHashCode();
        }

        public static bool operator ==(Pudelko pudelko1, Pudelko pudelko2)
        {
            if (((object)pudelko1) == null || ((object)pudelko2) == null)
                return Object.Equals(pudelko1, pudelko2);

            return pudelko1.Equals(pudelko2);
        }

        public static bool operator !=(Pudelko pudelko1, Pudelko pudelko2)
        {
            if (((object)pudelko1) == null || ((object)pudelko2) == null)
                return !Object.Equals(pudelko1, pudelko2);

            return !(pudelko1.Equals(pudelko2));
        }
        #endregion
        #region IEnumerable
        public IEnumerator GetEnumerator()
        {
            yield return A;
            yield return B;
            yield return C;
        }
        #endregion

        public static Pudelko operator +(Pudelko pudelko1, Pudelko pudelko2)
        {
            double[] p1 = new double[3] { pudelko1.A, pudelko1.B, pudelko1.C };
            Array.Sort(p1);
            double[] p2 = new double[3] { pudelko2.A, pudelko2.B, pudelko2.C };
            Array.Sort(p2);
            double b = p1[1] >= p2[1] ? p1[1] : p2[1];
            double c = p1[2] >= p2[2] ? p1[2] : p2[2];
            return new Pudelko(p1[0] + p2[0], b, c);
        }
        public static explicit operator double[](Pudelko p) => new double[3] { p.A, p.B, p.C };
        public static implicit operator Pudelko((int a, int b, int c) v) => new Pudelko(v.a, v.b, v.c, UnitOfMeasure.milimeter);

        public double this[int i]
        {
            get
            {
                double[] arr = new double[3]{ A, B, C};
                return arr[i];
            }
        }
        public static Pudelko Parse(string s)
        {
            string[] array = s.Split();
            if (array[1] == "m") {
                return new Pudelko(double.Parse(array[0]), double.Parse(array[3]), double.Parse(array[6]), UnitOfMeasure.meter);
            }else if (array[1] == "cm")
            {
                return new Pudelko(double.Parse(array[0]), double.Parse(array[3]), double.Parse(array[6]), UnitOfMeasure.centimeter);
            }
            else if (array[1] == "mm")
            {
                return new Pudelko(double.Parse(array[0]), double.Parse(array[3]), double.Parse(array[6]), UnitOfMeasure.milimeter);
            }
            throw new Exception();
        }
        
    }
}
