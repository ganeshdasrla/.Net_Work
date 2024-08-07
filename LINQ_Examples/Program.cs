using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Examples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // WHERE CLAUSE
            //int[] numbers = { 1, 2, 3, 4, 5, 6 };

            //var evenNumbers = (from num in numbers
            //                   where num % 2 == 0
            //                   select num).ToArray();

            //foreach (int num in evenNumbers)
            //{
            //    Console.WriteLine(num);
            //}

            // ORDER BY 
            //string[] words = { "the", "quick", "fox", "jump" };

            //var sortedWords = from word in words
            //                  orderby word.Length, word.Substring(0,1)
            //                  select word;

            //foreach(var word in sortedWords)
            //{
            //    Console.WriteLine(word);
            //}

            // SET OPERATIONS AND INTERSECTIONS
            int[] list1 = { 1, 2, 3, 4 , 5, 6};
            int[] list2 = { 5, 6, 7, 8 };

            //var query = from num in list1.Union(list2)
            //            select num;

            //var query = from num in list1.Intersect(list2)
            //            select num;

            //DISTINCT
            //var query = from num in list1.Distinct()
            //            select num;

            //string[] words = { "the", "quick", "brown", "fox", "jumps" };

            //var query = from word in words
            //            //where word.Length == 3 && word.StartsWith("f")
            //            where word.Length == 3 && word.Substring(0,1) == "f"
            //            select word;


            // QUANTIFIER OPERATIONS (any, all, contains)
            var Markets = new[]
            {
                new {MarketName = "MarketA", Fruits = new string[]{"kiwi", "cherry", "banaa"}},
                new {MarketName = "MarketB", Fruits = new string[]{"melon", "mango", "olive"}},
                new {MarketName = "MarketC", Fruits = new string[]{"kiwi", "apple", "orange"}},
                new {MarketName = "MarketD", Fruits = new string[]{"grape", "cherry", "banaa"}}
            };

            //market contains all fruit length==5
            //var query = from market in Markets
            //            where market.Fruits.All(fruit => fruit.Length == 5)
            //            select market.MarketName;

            //market that conatins fruits starts with 'o'
            //var query = from market in Markets
            //            where market.Fruits.Any(f => f.StartsWith("o"))
            //            select market.MarketName;

            //market that contains fruit 'kiwi'
            //var query = from market in Markets
            //            where market.Fruits.Contains("kiwi")
            //            select market.MarketName;

            //Projection operations --- operation of transforming object to new form
            //var words = new string[] { "an", "apple", "a", "day" };

            //var query = from word in words
            //            select word.Substring(0,1);

            //sentences
            var sentences = new string[] { "an apple a day", "the quick brown fox" };
            var query = from sentence in sentences
                        from word in sentence.Split(' ')
                        select word;
                         
                        

            foreach(var item in query)
            {
                Console.WriteLine(item);
            }


            Console.ReadKey();
        }
    }
}
