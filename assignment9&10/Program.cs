using System;
using System.Collections;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("===== Optimized Bubble Sort =====");
        int[] arr = { 5, 3, 8, 4, 2 };

        BubbleSort(arr);

        Console.WriteLine(string.Join(", ", arr));


        Console.WriteLine("\n===== Range<T> =====");
        Range<int> r = new Range<int>(10, 20);

        Console.WriteLine("Is 15 in range? " + r.IsInRange(15));
        Console.WriteLine("Range Length: " + r.Length());


        Console.WriteLine("\n===== Reverse ArrayList =====");
        ArrayList list = new ArrayList() { 1, 2, 3, 4, 5 };
        ReverseArrayList(list);
        foreach (var item in list)
            Console.Write(item + " ");


        Console.WriteLine("\n\n===== Even Numbers =====");
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
        var evens = GetEvenNumbers(numbers);
        Console.WriteLine(string.Join(", ", evens));


        Console.WriteLine("\n===== FixedSizeList =====");
        FixedSizeList<int> fixedList = new FixedSizeList<int>(3);

        fixedList.Add(10);
        fixedList.Add(20);
        fixedList.Add(30);

        Console.WriteLine(fixedList.Get(1));


        Console.WriteLine("\n===== First Non-Repeated Character =====");
        string text = "leetcode";
        Console.WriteLine(FirstUniqueChar(text));
    }

    // 1️⃣ Optimized Bubble Sort
    static void BubbleSort(int[] arr)
    {
        bool swapped;

        for (int i = 0; i < arr.Length - 1; i++)
        {
            swapped = false;

            for (int j = 0; j < arr.Length - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;

                    swapped = true;
                }
            }

            if (!swapped)
                break;
        }
    }

    // 2️⃣ Reverse ArrayList without Reverse()
    static void ReverseArrayList(ArrayList list)
    {
        int start = 0;
        int end = list.Count - 1;

        while (start < end)
        {
            object temp = list[start];
            list[start] = list[end];
            list[end] = temp;

            start++;
            end--;
        }
    }

    // 3️⃣ Get Even Numbers
    static List<int> GetEvenNumbers(List<int> numbers)
    {
        List<int> result = new List<int>();

        foreach (var num in numbers)
        {
            if (num % 2 == 0)
                result.Add(num);
        }

        return result;
    }

    // 4️⃣ First Non-Repeated Character
    static int FirstUniqueChar(string s)
    {
        Dictionary<char, int> freq = new Dictionary<char, int>();

        foreach (char c in s)
        {
            if (freq.ContainsKey(c))
                freq[c]++;
            else
                freq[c] = 1;
        }

        for (int i = 0; i < s.Length; i++)
        {
            if (freq[s[i]] == 1)
                return i;
        }

        return -1;
    }
}


// ============================
// Range<T> Class
// ============================

class Range<T> where T : IComparable<T>
{
    public T Min { get; set; }
    public T Max { get; set; }

    public Range(T min, T max)
    {
        Min = min;
        Max = max;
    }

    public bool IsInRange(T value)
    {
        return value.CompareTo(Min) >= 0 && value.CompareTo(Max) <= 0;
    }

    public double Length()
    {
        return Convert.ToDouble(Max) - Convert.ToDouble(Min);
    }
}


// ============================
// FixedSizeList<T>
// ============================

class FixedSizeList<T>
{
    private T[] items;
    private int count = 0;

    public FixedSizeList(int capacity)
    {
        items = new T[capacity];
    }

    public void Add(T item)
    {
        if (count >= items.Length)
            throw new Exception("List is full.");

        items[count++] = item;
    }

    public T Get(int index)
    {
        if (index < 0 || index >= count)
            throw new Exception("Invalid index.");

        return items[index];
    }
}