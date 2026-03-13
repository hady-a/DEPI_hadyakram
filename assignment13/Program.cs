using System;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;
using System.IO;

class Program
{
    static void Main()
    {

        // Sample Products
        List<Product> products = new List<Product>()
        {
            new Product{ProductName="Laptop",Category="Tech",UnitPrice=1200,UnitsInStock=0},
            new Product{ProductName="Mouse",Category="Tech",UnitPrice=20,UnitsInStock=50},
            new Product{ProductName="Keyboard",Category="Tech",UnitPrice=80,UnitsInStock=10},
            new Product{ProductName="Notebook",Category="Stationery",UnitPrice=5,UnitsInStock=0},
            new Product{ProductName="Pen",Category="Stationery",UnitPrice=2,UnitsInStock=200}
        };

        int[] arr = {5,4,1,3,9,8,6,7,2,0};

        string[] dictionary = File.ReadAllLines("dictionary_english.txt");

        XDocument xml = XDocument.Load("Customers.xml");



        Console.WriteLine("==== Element Operators ====");

        var firstOutStock = products.FirstOrDefault(p => p.UnitsInStock == 0);
        Console.WriteLine(firstOutStock.ProductName);

        var firstPrice1000 = products.FirstOrDefault(p => p.UnitPrice > 1000);
        Console.WriteLine(firstPrice1000?.ProductName);

        var secondGreater5 = arr.Where(n => n > 5).Skip(1).First();
        Console.WriteLine(secondGreater5);



        Console.WriteLine("\n==== Aggregate Operators ====");

        var oddCount = arr.Count(n => n % 2 == 1);
        Console.WriteLine("Odd Count: " + oddCount);


        var customersOrders =
            xml.Descendants("customer")
            .Select(c => new
            {
                Name = c.Element("name").Value,
                Orders = c.Descendants("order").Count()
            });

        foreach (var c in customersOrders)
            Console.WriteLine(c.Name + " " + c.Orders);


        var categoryProducts =
            products.GroupBy(p => p.Category)
            .Select(g => new
            {
                Category = g.Key,
                Count = g.Count()
            });

        foreach (var c in categoryProducts)
            Console.WriteLine(c.Category + " " + c.Count);


        Console.WriteLine("Sum: " + arr.Sum());


        Console.WriteLine("Total Characters: " + dictionary.Sum(w => w.Length));

        Console.WriteLine("Shortest Word Length: " + dictionary.Min(w => w.Length));

        Console.WriteLine("Longest Word Length: " + dictionary.Max(w => w.Length));

        Console.WriteLine("Average Length: " + dictionary.Average(w => w.Length));


        var unitsPerCategory =
            products.GroupBy(p => p.Category)
            .Select(g => new
            {
                Category = g.Key,
                Units = g.Sum(p => p.UnitsInStock)
            });


        var cheapestPrice =
            products.GroupBy(p => p.Category)
            .Select(g => new
            {
                Category = g.Key,
                MinPrice = g.Min(p => p.UnitPrice)
            });


        var cheapestProduct =
            from p in products
            group p by p.Category into g
            let minPrice = g.Min(p => p.UnitPrice)
            from prod in g
            where prod.UnitPrice == minPrice
            select prod;


        var maxPrice =
            products.GroupBy(p => p.Category)
            .Select(g => new
            {
                Category = g.Key,
                MaxPrice = g.Max(p => p.UnitPrice)
            });


        var expensiveProduct =
            from p in products
            group p by p.Category into g
            let max = g.Max(p => p.UnitPrice)
            from prod in g
            where prod.UnitPrice == max
            select prod;


        var avgPrice =
            products.GroupBy(p => p.Category)
            .Select(g => new
            {
                Category = g.Key,
                Avg = g.Average(p => p.UnitPrice)
            });



        Console.WriteLine("\n==== Set Operators ====");

        var uniqueCategories = products.Select(p => p.Category).Distinct();

        var productLetters = products.Select(p => p.ProductName[0]);
        var customerLetters = xml.Descendants("customer")
                                 .Select(c => c.Element("name").Value[0]);

        var unionLetters = productLetters.Union(customerLetters);

        var intersectLetters = productLetters.Intersect(customerLetters);

        var exceptLetters = productLetters.Except(customerLetters);

        var lastThree =
            products.Select(p => p.ProductName.Substring(p.ProductName.Length - 3))
            .Concat(xml.Descendants("customer")
            .Select(c => c.Element("name").Value.Substring(c.Element("name").Value.Length - 3)));



        Console.WriteLine("\n==== Partitioning Operators ====");

        var washingtonOrders =
            xml.Descendants("customer")
            .Where(c => c.Element("city").Value == "Washington")
            .SelectMany(c => c.Descendants("order"))
            .Take(3);

        var skipOrders =
            xml.Descendants("customer")
            .Where(c => c.Element("city").Value == "Washington")
            .SelectMany(c => c.Descendants("order"))
            .Skip(2);


        var takeWhileNumbers =
            arr.TakeWhile((n, i) => n >= i);

        var skipDivisible3 =
            arr.SkipWhile(n => n % 3 != 0);

        var skipPosition =
            arr.SkipWhile((n, i) => n >= i);



        Console.WriteLine("\n==== Quantifiers ====");

        var containsEi =
            dictionary.Any(w => w.Contains("ei"));

        Console.WriteLine("Contains 'ei': " + containsEi);


        var categoryWithOutStock =
            products.GroupBy(p => p.Category)
            .Where(g => g.Any(p => p.UnitsInStock == 0));


        var allInStock =
            products.GroupBy(p => p.Category)
            .Where(g => g.All(p => p.UnitsInStock > 0));



        Console.WriteLine("\n==== Grouping Operators ====");

        List<int> numbers = new List<int>{0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15};

        var groupRemainder =
            numbers.GroupBy(n => n % 5);

        foreach (var g in groupRemainder)
        {
            Console.WriteLine("Remainder " + g.Key);
            foreach (var n in g)
                Console.Write(n + " ");
            Console.WriteLine();
        }


        var wordsByLetter =
            dictionary.GroupBy(w => w[0]);


        string[] arrWords = {"from","salt","earn","last","near","form"};

        var anagramGroups =
            arrWords.GroupBy(w => String.Concat(w.OrderBy(c => c)));

        foreach (var g in anagramGroups)
        {
            foreach (var w in g)
                Console.Write(w + " ");
            Console.WriteLine();
        }
    }
}


class Product
{
    public string ProductName {get;set;}
    public string Category {get;set;}
    public decimal UnitPrice {get;set;}
    public int UnitsInStock {get;set;}
}