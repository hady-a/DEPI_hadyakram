using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n===== Assignment 4 Menu =====");
            Console.WriteLine("1 - Value Type Example");
            Console.WriteLine("2 - Reference Type Example");
            Console.WriteLine("3 - Sum & Subtract");
            Console.WriteLine("4 - Sum of Digits");
            Console.WriteLine("5 - Check Prime");
            Console.WriteLine("6 - Min Max Array");
            Console.WriteLine("7 - Factorial");
            Console.WriteLine("8 - Change Character");
            Console.WriteLine("0 - Exit");

            Console.Write("Choose option: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: ValueTypeExample(); break;
                case 2: ReferenceTypeExample(); break;
                case 3: SumSubtractExample(); break;
                case 4: SumDigitsExample(); break;
                case 5: PrimeExample(); break;
                case 6: MinMaxExample(); break;
                case 7: FactorialExample(); break;
                case 8: ChangeCharExample(); break;
                case 0: return;
                default: Console.WriteLine("Invalid option"); break;
            }
        }
    }

    // VALUE TYPE
    static void ValueTypeExample()
    {
        int a = 10;
        int b = 10;

        ChangeValue(a);
        ChangeValueRef(ref b);

        Console.WriteLine("By Value: " + a);
        Console.WriteLine("By Reference: " + b);
    }

    static void ChangeValue(int x)
    {
        x = 100;
    }

    static void ChangeValueRef(ref int x)
    {
        x = 100;
    }


    // REFERENCE TYPE
    static void ReferenceTypeExample()
    {
        int[] arr = { 1, 2, 3 };

        ModifyArray(arr);
        Console.WriteLine("Reference by value: " + arr[0]);

        ModifyArrayRef(ref arr);
        Console.WriteLine("Reference by reference: " + arr[0]);
    }

    static void ModifyArray(int[] arr)
    {
        arr[0] = 50;
    }

    static void ModifyArrayRef(ref int[] arr)
    {
        arr = new int[] { 99, 99, 99 };
    }


    // SUM & SUBTRACT
    static void SumSubtractExample()
    {
        Console.WriteLine("Enter 4 numbers:");

        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());
        int d = int.Parse(Console.ReadLine());

        int sum, sub;

        SumSub(a, b, c, d, out sum, out sub);

        Console.WriteLine("Sum = " + sum);
        Console.WriteLine("Subtract = " + sub);
    }

    static void SumSub(int a, int b, int c, int d, out int sum, out int sub)
    {
        sum = a + b + c + d;
        sub = a - b - c - d;
    }


    // SUM DIGITS
    static void SumDigitsExample()
    {
        Console.Write("Enter number: ");
        int num = int.Parse(Console.ReadLine());

        Console.WriteLine("Sum of digits = " + SumDigits(num));
    }

    static int SumDigits(int n)
    {
        int sum = 0;

        while (n > 0)
        {
            sum += n % 10;
            n /= 10;
        }

        return sum;
    }


    // PRIME
    static void PrimeExample()
    {
        Console.Write("Enter number: ");
        int num = int.Parse(Console.ReadLine());

        Console.WriteLine(IsPrime(num));
    }

    static bool IsPrime(int n)
    {
        if (n < 2) return false;

        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0)
                return false;
        }

        return true;
    }


    // MIN MAX ARRAY
    static void MinMaxExample()
    {
        int[] arr = { 4, 7, 1, 9, 3 };

        int min = 0;
        int max = 0;

        MinMaxArray(arr, ref min, ref max);

        Console.WriteLine("Min = " + min);
        Console.WriteLine("Max = " + max);
    }

    static void MinMaxArray(int[] arr, ref int min, ref int max)
    {
        min = arr[0];
        max = arr[0];

        foreach (int n in arr)
        {
            if (n < min) min = n;
            if (n > max) max = n;
        }
    }


    // FACTORIAL
    static void FactorialExample()
    {
        Console.Write("Enter number: ");
        int num = int.Parse(Console.ReadLine());

        Console.WriteLine("Factorial = " + Factorial(num));
    }

    static int Factorial(int n)
    {
        int result = 1;

        for (int i = 1; i <= n; i++)
            result *= i;

        return result;
    }


    // CHANGE CHARACTER
    static void ChangeCharExample()
    {
        Console.Write("Enter string: ");
        string text = Console.ReadLine();

        Console.Write("Enter position: ");
        int pos = int.Parse(Console.ReadLine());

        Console.Write("Enter new character: ");
        char c = Console.ReadLine()[0];

        Console.WriteLine(ChangeChar(text, pos, c));
    }

    static string ChangeChar(string str, int pos, char newChar)
    {
        char[] chars = str.ToCharArray();

        chars[pos] = newChar;

        return new string(chars);
    }
}