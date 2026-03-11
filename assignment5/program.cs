using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n===== Assignment 5 Menu =====");
            Console.WriteLine("1 - Print WeekDays Enum");
            Console.WriteLine("2 - Struct Person Array");
            Console.WriteLine("3 - Season Months");
            Console.WriteLine("4 - Permissions Enum");
            Console.WriteLine("5 - Primary Color Check");
            Console.WriteLine("6 - Distance Between Two Points");
            Console.WriteLine("7 - Oldest Person");
            Console.WriteLine("0 - Exit");

            Console.Write("Choose option: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: PrintWeekDays(); break;
                case 2: PersonArray(); break;
                case 3: SeasonMonths(); break;
                case 4: PermissionsExample(); break;
                case 5: CheckPrimaryColor(); break;
                case 6: DistanceBetweenPoints(); break;
                case 7: OldestPerson(); break;
                case 0: return;
                default: Console.WriteLine("Invalid choice"); break;
            }
        }
    }

    // 1️⃣ WeekDays Enum
    enum WeekDays
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    static void PrintWeekDays()
    {
        foreach (WeekDays day in Enum.GetValues(typeof(WeekDays)))
        {
            Console.WriteLine(day);
        }
    }

    // 2️⃣ Person Struct Array
    struct Person
    {
        public string Name;
        public int Age;
    }

    static void PersonArray()
    {
        Person[] people = new Person[3];

        for (int i = 0; i < 3; i++)
        {
            Console.Write("Enter name: ");
            people[i].Name = Console.ReadLine();

            Console.Write("Enter age: ");
            people[i].Age = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("\nPersons Data:");

        foreach (Person p in people)
        {
            Console.WriteLine($"Name: {p.Name}, Age: {p.Age}");
        }
    }

    // 3️⃣ Season Enum
    enum Season
    {
        Spring,
        Summer,
        Autumn,
        Winter
    }

    static void SeasonMonths()
    {
        Console.Write("Enter season: ");
        string input = Console.ReadLine();

        Season season = Enum.Parse<Season>(input, true);

        switch (season)
        {
            case Season.Spring:
                Console.WriteLine("March to May");
                break;

            case Season.Summer:
                Console.WriteLine("June to August");
                break;

            case Season.Autumn:
                Console.WriteLine("September to November");
                break;

            case Season.Winter:
                Console.WriteLine("December to February");
                break;
        }
    }

    // 4️⃣ Permissions Enum
    [Flags]
    enum Permissions
    {
        Read = 1,
        Write = 2,
        Delete = 4,
        Execute = 8
    }

    static void PermissionsExample()
    {
        Permissions userPermission = Permissions.Read;

        userPermission |= Permissions.Write; // Add permission

        Console.WriteLine("Current Permissions: " + userPermission);

        userPermission &= ~Permissions.Read; // Remove permission

        Console.WriteLine("After removing Read: " + userPermission);

        bool hasDelete = userPermission.HasFlag(Permissions.Delete);

        Console.WriteLine("Has Delete Permission: " + hasDelete);
    }

    // 5️⃣ Colors Enum
    enum Colors
    {
        Red,
        Green,
        Blue
    }

    static void CheckPrimaryColor()
    {
        Console.Write("Enter color: ");
        string input = Console.ReadLine();

        if (Enum.TryParse(input, true, out Colors color))
        {
            Console.WriteLine($"{color} is a primary color.");
        }
        else
        {
            Console.WriteLine("Not a primary color.");
        }
    }

    // 6️⃣ Point Struct
    struct Point
    {
        public double X;
        public double Y;
    }

    static void DistanceBetweenPoints()
    {
        Point p1 = new Point();
        Point p2 = new Point();

        Console.WriteLine("Enter first point:");
        Console.Write("X: ");
        p1.X = double.Parse(Console.ReadLine());
        Console.Write("Y: ");
        p1.Y = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter second point:");
        Console.Write("X: ");
        p2.X = double.Parse(Console.ReadLine());
        Console.Write("Y: ");
        p2.Y = double.Parse(Console.ReadLine());

        double distance = Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));

        Console.WriteLine("Distance = " + distance);
    }

    // 7️⃣ Oldest Person
    static void OldestPerson()
    {
        Person[] people = new Person[3];

        for (int i = 0; i < 3; i++)
        {
            Console.Write("Enter name: ");
            people[i].Name = Console.ReadLine();

            Console.Write("Enter age: ");
            people[i].Age = int.Parse(Console.ReadLine());
        }

        Person oldest = people[0];

        foreach (Person p in people)
        {
            if (p.Age > oldest.Age)
            {
                oldest = p;
            }
        }

        Console.WriteLine($"Oldest Person: {oldest.Name} ({oldest.Age})");
    }
}