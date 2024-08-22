using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HandsOn
{
    public class Program
    {

        static void RaiseStackOverflowException()
        {
            RaiseStackOverflowException();
        }
        static void Main(string[] args)
        {

            string mainString = "Hello, welcome to the world of C#!";
            string searchString = "world1111";

            bool isFound = SearchString(mainString, searchString);

            if (isFound)
            {
                Console.WriteLine("Substring found!");
            }
            else
            {
                Console.WriteLine("Substring not found.");
            }



            try
            {
                //1. stack overflow
                RaiseStackOverflowException();

                //1. Out of memroy
                List<byte[]> memoryHog = new List<byte[]>();
                while (true)
                {
                    // Attempt to allocate 1 GB of memory repeatedly
                    memoryHog.Add(new byte[1024 * 1024 * 1024]);
                }

                

            }
            catch (StackOverflowException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            catch (OutOfMemoryException ex) { 
                Console.WriteLine(ex.ToString());
                return;
            }


            //string interpolation
            var uname = "Ganesh";
            var age = 30;
            Console.WriteLine($"Hello, my name is {uname} and my age is {age}");


            //enumerable range
            foreach (var num in Enumerable.Range(1, 10))
            {
                Console.WriteLine(num);
            }

            //using declarations
            using var sreamReader = new StreamReader("file.txt"); //the object is automatically disposed
            string content = sreamReader.ReadToEnd();

            //is palindrome
            var str = "MOM";
            Console.WriteLine(str.IsPalindrome());


            //is - type checking or pattern matching
            object obj = 123;
            if (obj is int i)
                Console.WriteLine(i);

            //Value Tuple
            var person = (Id: 1, name: "Johne Doe");
            Console.WriteLine($"{person.Id}, {person.name}");

            var (id, name) = GetPerson();
            Console.WriteLine(id + " " + name);

            //as -- for type conversion 
            var result = LINQ.GetSecondHighestSalary() as string[]; //result like ["name1", "name2"]
            Console.WriteLine(string.Join(",", result));


            var scoreResult = LINQ.GetHighScores() as int[];
            Console.WriteLine(string.Join(",", scoreResult));

            //Null-Conditional Operator
            string[] arr = null;
            var legth = arr?.Length ?? 0; //legth is 0 without throwing an exception

            Console.ReadLine();

            var originalList = new List<string> { "Alice", "Bob", "Charlie" };
            var readOnlyCollection = originalList.AsReadOnly(); //Now this list is immutable
        }

        //tuple
        public static (int, string) GetPerson()
        {
            return (1, "John Doe");
        }

        private async Task<string> FetchDataAsync(string url)
        {
            using (var httpClinet = new HttpClient())
            {
                var response = await httpClinet.GetStringAsync("");
                return response;
            }
        }

        private static bool SearchString(string originalString, string findString)
        {
            int mainLen = originalString.Length;
            int subsLen = findString.Length;

            for (int i = 0; i < mainLen - subsLen; i++)
            {
                int j;
                for (j = 0; j < subsLen; j++)
                {
                    // Extract a substring from the main string
                    // string substring = originalString.Substring(i, searchLength);

                    if (originalString[i + j] != findString[j])
                    {
                        break;
                    }
                }
                if (j == subsLen)
                {
                    return true;
                }
            }
            return false;
        }
    }

    //Extension method
    public static class StringExtensions
    {
        public static bool IsPalindrome(this string str)
        {
            if (String.IsNullOrEmpty(str)) return false;

            str = str.ToLower();
            string reversed = new string(str.Reverse().ToArray());
            return str == reversed;
        }
    }

    public static class LINQ
    {
        public class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Salary { get; set; }
        }

        static List<Employee> employees = new List<Employee>()
        {
            new Employee { Id = 1, Name="John", Salary=10000},
            new Employee { Id = 2, Name="Jane", Salary=20000 },
            new Employee { Id = 3, Name="Bob", Salary=30000 },
            new Employee { Id = 4, Name="Alice", Salary=20000 }
        };

        public static object GetSecondHighestSalary()
        {
            var s2ndSalary = employees
                .Select(e => e.Salary)
                .Distinct()
                .OrderByDescending(e => e)
                .Skip(1)
                .FirstOrDefault();

            var emp = employees
                .Where(e => e.Salary == s2ndSalary)
                .Select(e => e.Name).ToArray();

            return emp;
        }

        public static object GetHighScores()
        {
            int[] scores = new int[] { 97, 92, 81, 60 };

            var highScores = from score in scores
                             where score > 80
                             select score;


            return highScores.ToArray();
        }

        

    }

}
