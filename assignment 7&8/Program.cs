using System;

namespace OOPAssignment
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== First Project ===");

            Point3D P = new Point3D(10, 10, 10);
            Console.WriteLine(P);

            Console.WriteLine("\nEnter P1 coordinates:");

            Point3D P1 = ReadPoint();
            Console.WriteLine("Enter P2 coordinates:");
            Point3D P2 = ReadPoint();

            Console.WriteLine(P1);
            Console.WriteLine(P2);

            if (P1 == P2)
                Console.WriteLine("Points are equal");
            else
                Console.WriteLine("Points are NOT equal");

            Point3D[] points =
            {
                new Point3D(5,3,1),
                new Point3D(2,9,4),
                new Point3D(5,1,2)
            };

            Array.Sort(points);

            Console.WriteLine("\nSorted Points:");
            foreach (var p in points)
                Console.WriteLine(p);

            Point3D clone = (Point3D)P.Clone();
            Console.WriteLine("\nCloned Point: " + clone);


            Console.WriteLine("\n=== Second Project ===");

            Console.WriteLine(Maths.Add(5, 3));
            Console.WriteLine(Maths.Subtract(10, 4));
            Console.WriteLine(Maths.Multiply(6, 2));
            Console.WriteLine(Maths.Divide(20, 5));


            Console.WriteLine("\n=== Third Project ===");

            Duration d1 = new Duration(1, 20, 30);
            Duration d2 = new Duration(1, 20, 30);

            Console.WriteLine(d1);
            Console.WriteLine("Equal? " + d1.Equals(d2));
            Console.WriteLine("HashCode: " + d1.GetHashCode());
        }


        static Point3D ReadPoint()
        {
            int x, y, z;

            Console.Write("X: ");
            while (!int.TryParse(Console.ReadLine(), out x))
                Console.Write("Invalid input, enter X again: ");

            Console.Write("Y: ");
            while (!int.TryParse(Console.ReadLine(), out y))
                Console.Write("Invalid input, enter Y again: ");

            Console.Write("Z: ");
            while (!int.TryParse(Console.ReadLine(), out z))
                Console.Write("Invalid input, enter Z again: ");

            return new Point3D(x, y, z);
        }
    }

    // ======================
    // FIRST PROJECT
    // ======================

    class Point3D : IComparable, ICloneable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Point3D() : this(0, 0, 0) { }

        public Point3D(int x) : this(x, 0, 0) { }

        public Point3D(int x, int y) : this(x, y, 0) { }

        public Point3D(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString()
        {
            return $"Point Coordinates: ({X}, {Y}, {Z})";
        }

        public override bool Equals(object obj)
        {
            if (obj is Point3D p)
                return X == p.X && Y == p.Y && Z == p.Z;

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z);
        }

        public static bool operator ==(Point3D p1, Point3D p2)
        {
            return p1.Equals(p2);
        }

        public static bool operator !=(Point3D p1, Point3D p2)
        {
            return !p1.Equals(p2);
        }

        public int CompareTo(object obj)
        {
            Point3D p = (Point3D)obj;

            if (X == p.X)
                return Y.CompareTo(p.Y);

            return X.CompareTo(p.X);
        }

        public object Clone()
        {
            return new Point3D(X, Y, Z);
        }
    }


// ======================
// SECOND PROJECT
// ======================

static class Maths
{
    public static int Add(int a, int b) => a + b;
    public static int Subtract(int a, int b) => a - b;
    public static int Multiply(int a, int b) => a * b;
    public static double Divide(int a, int b) => b != 0 ? (double)a / b : 0;
}

// ======================
// THIRD PROJECT
// ======================

   class Duration
{
    public int Hours { get; set; }
    public int Minutes { get; set; }
    public int Seconds { get; set; }

    // Constructor 1 (Hours, Minutes, Seconds)
    public Duration(int h, int m, int s)
    {
        Hours = h;
        Minutes = m;
        Seconds = s;
    }

    // Constructor 2 (Total Seconds)
    public Duration(int totalSeconds)
    {
        Hours = totalSeconds / 3600;
        totalSeconds %= 3600;

        Minutes = totalSeconds / 60;
        Seconds = totalSeconds % 60;
    }

    public override string ToString()
    {
        if (Hours > 0)
            return $"Hours: {Hours}, Minutes: {Minutes}, Seconds: {Seconds}";
        else
            return $"Minutes: {Minutes}, Seconds: {Seconds}";
    }

    public override bool Equals(object obj)
    {
        if (obj is Duration d)
            return Hours == d.Hours && Minutes == d.Minutes && Seconds == d.Seconds;

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Hours, Minutes, Seconds);
    }
}}