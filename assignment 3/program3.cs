using System;

class Program
{
    static void Main()
    {

        // ==============================
        // 1) Divisible by 3 and 4
        // ==============================
        Console.Write("Enter number: ");
        int num = int.Parse(Console.ReadLine());

        if (num % 3 == 0 && num % 4 == 0)
            Console.WriteLine("Yes");
        else
            Console.WriteLine("No");


        // ==============================
        // 2) Positive or Negative
        // ==============================
        Console.Write("Enter number: ");
        int n = int.Parse(Console.ReadLine());

        if (n < 0)
            Console.WriteLine("Negative");
        else
            Console.WriteLine("Positive");


        // ==============================
        // 3) Max and Min of 3 numbers
        // ==============================
        Console.WriteLine("Enter 3 numbers:");
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());

        int max = Math.Max(a, Math.Max(b, c));
        int min = Math.Min(a, Math.Min(b, c));

        Console.WriteLine("Max element = " + max);
        Console.WriteLine("Min element = " + min);


        // ==============================
        // 4) Even or Odd
        // ==============================
        Console.Write("Enter number: ");
        int even = int.Parse(Console.ReadLine());

        if (even % 2 == 0)
            Console.WriteLine("Even");
        else
            Console.WriteLine("Odd");


        // ==============================
        // 5) Vowel or Consonant
        // ==============================
        Console.Write("Enter character: ");
        char ch = char.ToLower(Console.ReadLine()[0]);

        if (ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u')
            Console.WriteLine("Vowel");
        else
            Console.WriteLine("Consonant");


        // ==============================
        // 6) Print numbers from 1 to n
        // ==============================
        Console.Write("Enter number: ");
        int num2 = int.Parse(Console.ReadLine());

        for (int i = 1; i <= num2; i++)
            Console.Write(i + " ");


        // ==============================
        // 7) Multiplication table
        // ==============================
        Console.Write("\nEnter number: ");
        int m = int.Parse(Console.ReadLine());

        for (int i = 1; i <= 12; i++)
            Console.Write(m * i + " ");


        // ==============================
        // 8) Even numbers from 1 to n
        // ==============================
        Console.Write("\nEnter number: ");
        int even2 = int.Parse(Console.ReadLine());

        for (int i = 2; i <= even2; i += 2)
            Console.Write(i + " ");


        // ==============================
        // 9) Power calculation
        // ==============================
        Console.Write("Enter base: ");
        int baseNum = int.Parse(Console.ReadLine());

        Console.Write("Enter power: ");
        int power = int.Parse(Console.ReadLine());

        int result = 1;

        for (int i = 0; i < power; i++)
            result *= baseNum;

        Console.WriteLine(result);


        // ==============================
        // 10) Marks calculation
        // ==============================
        Console.WriteLine("Enter marks of 5 subjects:");

        int total = 0;

        for (int i = 0; i < 5; i++)
            total += int.Parse(Console.ReadLine());

        double average = total / 5.0;

        Console.WriteLine("Total marks = " + total);
        Console.WriteLine("Average Marks = " + average);
        Console.WriteLine("Percentage = " + average);


        // ==============================
        // 11) Days in month
        // ==============================
        Console.Write("Enter month number: ");
        int month = int.Parse(Console.ReadLine());

        int days = 0;

        switch (month)
        {
            case 2: days = 28; break;
            case 4:
            case 6:
            case 9:
            case 11: days = 30; break;
            default: days = 31; break;
        }

        Console.WriteLine("Days in Month = " + days);


        // ==============================
        // 12) Simple calculator
        // ==============================
        Console.Write("Enter first number: ");
        double x = double.Parse(Console.ReadLine());

        Console.Write("Enter operator (+ - * /): ");
        char op = Console.ReadLine()[0];

        Console.Write("Enter second number: ");
        double y = double.Parse(Console.ReadLine());

        switch (op)
        {
            case '+': Console.WriteLine(x + y); break;
            case '-': Console.WriteLine(x - y); break;
            case '*': Console.WriteLine(x * y); break;
            case '/': Console.WriteLine(x / y); break;
        }


        // ==============================
        // 13) Reverse string
        // ==============================
        Console.Write("Enter string: ");
        string str = Console.ReadLine();

        char[] arr = str.ToCharArray();
        Array.Reverse(arr);

        Console.WriteLine(new string(arr));


        // ==============================
        // 14) Reverse integer
        // ==============================
        Console.Write("Enter number: ");
        int numRev = int.Parse(Console.ReadLine());

        int rev = 0;

        while (numRev > 0)
        {
            rev = rev * 10 + numRev % 10;
            numRev /= 10;
        }

        Console.WriteLine(rev);


        // ==============================
        // 15) Prime numbers in range
        // ==============================
        Console.Write("Start: ");
        int start = int.Parse(Console.ReadLine());

        Console.Write("End: ");
        int end = int.Parse(Console.ReadLine());

        for (int i = start; i <= end; i++)
        {
            bool prime = true;

            if (i < 2) prime = false;

            for (int j = 2; j <= Math.Sqrt(i); j++)
                if (i % j == 0) prime = false;

            if (prime) Console.Write(i + " ");
        }


        // ==============================
        // 16) Decimal to Binary
        // ==============================
        Console.Write("\nEnter number: ");
        int dec = int.Parse(Console.ReadLine());

        string binary = "";

        while (dec > 0)
        {
            binary = (dec % 2) + binary;
            dec /= 2;
        }

        Console.WriteLine(binary);


        // ==============================
        // 17) Points on straight line
        // ==============================
        Console.WriteLine("Enter x1 y1:");
        int x1 = int.Parse(Console.ReadLine());
        int y1 = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter x2 y2:");
        int x2 = int.Parse(Console.ReadLine());
        int y2 = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter x3 y3:");
        int x3 = int.Parse(Console.ReadLine());
        int y3 = int.Parse(Console.ReadLine());

        if ((y2 - y1) * (x3 - x1) == (y3 - y1) * (x2 - x1))
            Console.WriteLine("Points lie on a straight line");
        else
            Console.WriteLine("Points do NOT lie on a straight line");


        // ==============================
        // 18) Worker efficiency
        // ==============================
        Console.Write("Enter hours: ");
        double hours = double.Parse(Console.ReadLine());

        if (hours >= 2 && hours < 3)
            Console.WriteLine("Highly efficient");
        else if (hours >= 3 && hours < 4)
            Console.WriteLine("Increase speed");
        else if (hours >= 4 && hours <= 5)
            Console.WriteLine("Training required");
        else
            Console.WriteLine("Leave the company");


        // ==============================
        // 19) Identity matrix
        // ==============================
        Console.Write("Enter size: ");
        int size = int.Parse(Console.ReadLine());

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (i == j) Console.Write("1 ");
                else Console.Write("0 ");
            }
            Console.WriteLine();
        }


        // ==============================
        // 20) Sum of array
        // ==============================
        Console.Write("Enter array size: ");
        int s = int.Parse(Console.ReadLine());

        int[] arr1 = new int[s];
        int sum = 0;

        for (int i = 0; i < s; i++)
        {
            arr1[i] = int.Parse(Console.ReadLine());
            sum += arr1[i];
        }

        Console.WriteLine("Sum = " + sum);


        // ==============================
        // 21) Merge arrays
        // ==============================
        int[] arr2 = new int[s];
        int[] merged = new int[s * 2];

        Console.WriteLine("Enter first array:");
        for (int i = 0; i < s; i++)
            merged[i] = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter second array:");
        for (int i = 0; i < s; i++)
            merged[i + s] = int.Parse(Console.ReadLine());

        Array.Sort(merged);

        Console.WriteLine("Merged array:");
        foreach (int v in merged)
            Console.Write(v + " ");


        // ==============================
        // 22) Frequency of elements
        // ==============================
        for (int i = 0; i < s; i++)
        {
            int count = 1;

            for (int j = i + 1; j < s; j++)
            {
                if (arr1[i] == arr1[j])
                {
                    count++;
                    arr1[j] = int.MinValue;
                }
            }

            if (arr1[i] != int.MinValue)
                Console.WriteLine(arr1[i] + " occurs " + count);
        }


        // ==============================
        // 23) Max & Min in array
        // ==============================
        int maxVal = merged[0];
        int minVal = merged[0];

        foreach (int v in merged)
        {
            if (v > maxVal) maxVal = v;
            if (v < minVal) minVal = v;
        }

        Console.WriteLine("Max = " + maxVal);
        Console.WriteLine("Min = " + minVal);


        // ==============================
        // 24) Second largest
        // ==============================
        Array.Sort(merged);
        Console.WriteLine("Second largest = " + merged[merged.Length - 2]);


        // ==============================
        // 25) Longest distance
        // ==============================
        int maxDist = 0;

        for (int i = 0; i < merged.Length; i++)
        {
            for (int j = merged.Length - 1; j > i; j--)
            {
                if (merged[i] == merged[j])
                {
                    int dist = j - i - 1;
                    if (dist > maxDist)
                        maxDist = dist;
                }
            }
        }

        Console.WriteLine("Longest distance = " + maxDist);


        // ==============================
        // 26) Reverse words
        // ==============================
        Console.Write("Enter sentence: ");
        string sentence = Console.ReadLine();

        string[] words = sentence.Split(' ');
        Array.Reverse(words);

        Console.WriteLine(string.Join(" ", words));


        // ==============================
        // 27) Copy 2D array
        // ==============================
        int[,] m1 = new int[2, 2];
        int[,] m2 = new int[2, 2];

        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                m1[i, j] = int.Parse(Console.ReadLine());
                m2[i, j] = m1[i, j];
            }
        }


        // ==============================
        // 28) Reverse array
        // ==============================
        Array.Reverse(merged);

        Console.WriteLine("Reversed array:");
        foreach (int v in merged)
            Console.Write(v + " ");
    }
}