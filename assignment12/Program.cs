using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

class Program
{
    static void Main()
    {

        // Sample Product List
        List<Product> products = new List<Product>()
        {
            new Product{ProductName="Laptop",Category="Tech",UnitPrice=1200,UnitsInStock=0},
            new Product{ProductName="Mouse",Category="Tech",UnitPrice=20,UnitsInStock=50},
            new Product{ProductName="Keyboard",Category="Tech",UnitPrice=80,UnitsInStock=10},
            new Product{ProductName="Book",Category="Education",UnitPrice=5,UnitsInStock=0},
            new Product{ProductName="Pen",Category="Education",UnitPrice=2,UnitsInStock=200}
        };


        Console.WriteLine("==== Restriction Operators ====");

        var outOfStock = products.Where(p => p.UnitsInStock == 0);
        foreach (var p in outOfStock)
            Console.WriteLine(p.ProductName);

        var expensiveStock = products.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3);
        foreach (var p in expensiveStock)
            Console.WriteLine(p.ProductName);

        string[] digits = {"zero","one","two","three","four","five","six","seven","eight","nine"};

        var shortDigits = digits.Where((d, i) => d.Length < i);
        foreach (var d in shortDigits)
            Console.WriteLine(d);



        Console.WriteLine("\n==== Element Operators ====");

        var firstOut = products.FirstOrDefault(p => p.UnitsInStock == 0);
        Console.WriteLine(firstOut.ProductName);

        var firstExpensive = products.FirstOrDefault(p => p.UnitPrice > 1000);
        Console.WriteLine(firstExpensive?.ProductName);

        int[] nums = {5,4,1,3,9,8,6,7,2,0};
        var secondGreater5 = nums.Where(n => n > 5).Skip(1).First();
        Console.WriteLine(secondGreater5);



        Console.WriteLine("\n==== Aggregate Operators ====");

        int[] arr = {5,4,1,3,9,8,6,7,2,0};

        var oddCount = arr.Count(n => n % 2 == 1);
        Console.WriteLine(oddCount);

        var categoryCount = products.GroupBy(p => p.Category)
                                    .Select(g => new {Category=g.Key, Count=g.Count()});

        foreach (var c in categoryCount)
            Console.WriteLine(c.Category + " " + c.Count);

        var sum = arr.Sum();
        Console.WriteLine(sum);


        // dictionary words
        var words = File.ReadAllLines("dictionary_english.txt");

        var totalChars = words.Sum(w => w.Length);
        Console.WriteLine(totalChars);

        var shortest = words.Min(w => w.Length);
        Console.WriteLine(shortest);

        var longest = words.Max(w => w.Length);
        Console.WriteLine(longest);

        var average = words.Average(w => w.Length);
        Console.WriteLine(average);



        Console.WriteLine("\n==== Ordering Operators ====");

        var sortName = products.OrderBy(p => p.ProductName);
        foreach (var p in sortName)
            Console.WriteLine(p.ProductName);

        string[] wordsArr = {"aPPLE","AbAcUs","bRaNcH","BlUeBeRrY","ClOvEr","cHeRry"};

        var caseSort = wordsArr.OrderBy(w => w,StringComparer.OrdinalIgnoreCase);
        foreach (var w in caseSort)
            Console.WriteLine(w);

        var stockDesc = products.OrderByDescending(p => p.UnitsInStock);

        var digitSort = digits.OrderBy(d => d.Length).ThenBy(d => d);

        var wordSort = wordsArr.OrderBy(w => w.Length)
                               .ThenBy(w => w,StringComparer.OrdinalIgnoreCase);

        var catPrice = products.OrderBy(p => p.Category)
                               .ThenByDescending(p => p.UnitPrice);

        var wordSortDesc = wordsArr.OrderBy(w => w.Length)
                                   .ThenByDescending(w => w,StringComparer.OrdinalIgnoreCase);

        var secondLetter = digits.Where(d => d.Length > 1 && d[1] == 'i')
                                 .Reverse();



        Console.WriteLine("\n==== Transformation Operators ====");

        var names = products.Select(p => p.ProductName);
        foreach (var n in names)
            Console.WriteLine(n);

        string[] fruits = {"aPPLE","BlUeBeRrY","cHeRry"};

        var upperLower = fruits.Select(w => new
        {
            Upper = w.ToUpper(),
            Lower = w.ToLower()
        });

        foreach (var f in upperLower)
            Console.WriteLine(f.Upper + " " + f.Lower);

        var productInfo = products.Select(p => new
        {
            p.ProductName,
            Price = p.UnitPrice
        });

        int[] posArr = {5,4,1,3,9,8,6,7,2,0};

        var positionMatch = posArr.Select((num,index) => new
        {
            Number = num,
            InPlace = num == index
        });

        int[] numbersA = {0,2,4,5,6,8,9};
        int[] numbersB = {1,3,5,7,8};

        var pairs = from a in numbersA
                    from b in numbersB
                    where a < b
                    select new {a,b};


        Console.WriteLine("\n==== XML Queries ====");

        var xml = XDocument.Load("Customers.xml");

        var ordersLess500 =
            xml.Descendants("order")
            .Where(o => (decimal)o.Element("total") < 500);

        var ordersAfter1998 =
            xml.Descendants("order")
            .Where(o => DateTime.Parse(o.Element("orderdate").Value).Year >= 1998);

    }
}


class Product
{
    public string ProductName {get;set;}
    public string Category {get;set;}
    public decimal UnitPrice {get;set;}
    public int UnitsInStock {get;set;}
}