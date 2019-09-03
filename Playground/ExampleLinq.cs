using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using System.IO;
using System.Diagnostics;

namespace Playground
{
    static class LinqX
    {
        public static void CallAllFunction()
        {
            //FromSelect();
            //FromWhereSelect();
            //FromWhereOrderBy();
            //FromWhereSelectCreateNewObject();
            AggregateFromListOfNumbers();
        }

        public static void FromSelect()
        {
             int[] scores = new int[] { 97, 92, 81, 60 };

             IEnumerable<int> scoreQueryExpression =
                from score in scores
                select score;

             IEnumerable<int> scoreQueryMethod = scores.Select(x => x);

            // Execute the query.
            foreach (int i in scoreQueryExpression)
            {
                Console.Write(i + " ");
            }
            foreach (int i in scoreQueryMethod)
            {
                Console.Write(i + " ");
            }
        }

        public static void FromWhereSelect()
        {
            int[] scores = new int[] { 97, 92, 81, 60 };

            IEnumerable<int> scoreQueryExpression =
                from score in scores
                where score > 80
                select score;

            IEnumerable<int> scoreQueryMethod = scores.Select(x => x);

            foreach (int i in scoreQueryExpression)
            {
                Console.Write(i + " ");
            }
            foreach (int i in scoreQueryMethod)
            {
                Console.Write(i + " ");
            }
        }

        public static void FromWhereOrderBy()
        {
            int[] numbers = { 5, 10, 8, 3, 6, 12 };

            IEnumerable<int> numQuery1 =
                from num in numbers
                where num % 2 == 0
                orderby num
                select num;

            IEnumerable<int> numQuery2 = numbers.Where(num => num % 2 == 0).OrderBy(n => n);

            foreach (int i in numQuery1)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine(System.Environment.NewLine);
            foreach (int i in numQuery2)
            {
                Console.Write(i + " ");
            }

        }

        static IEnumerable<string> Suits()
        {
            yield return "clubs";
            yield return "diamonds";
            yield return "hearts";
            yield return "spades";
        }

        static IEnumerable<string> Ranks()
        {
            yield return "two";
            yield return "three";
            yield return "four";
            yield return "five";
            yield return "six";
            yield return "seven";
            yield return "eight";
            yield return "nine";
            yield return "ten";
            yield return "jack";
            yield return "queen";
            yield return "king";
            yield return "ace";
        }

        public static void FromWhereSelectCreateNewObject()
        {
            var suits = Suits();

            Console.WriteLine(suits.First());

            var x = from suite in suits
                    where suite.StartsWith('s')
                    select suite;

            var startingDeck = (from s in Suits()
                                from r in Ranks()
                                select new { Suit = s, Rank = r });
            foreach (var item in startingDeck)
            {
                Console.WriteLine(item);
            }
        }

        public static void McqExample()
        {
            string[] strs = { "alpha", "beta", "gamma" };
            var chrs = from str in strs
                       let chrArray = str.ToCharArray()
                       from ch in chrArray
                       orderby ch
                       select ch;
            Console.WriteLine("The individual characters in sorted order:");
            foreach (char c in chrs.AsEnumerable())
                Console.Write(c + " ");
            Console.WriteLine();
            Console.ReadLine();
        }
       
        class Pet
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        static Pet[] GetCats()
        {
            Pet[] cats = { new Pet { Name="Barley", Age=8 },
                   new Pet { Name="Boots", Age=6 },
                   new Pet { Name="Chaplin", Age=6 },
                   new Pet { Name="Giri", Age=4 },
                   new Pet { Name="Rob", Age=1 },
                   new Pet { Name="Stark", Age=9 },
                   new Pet { Name="Arya", Age=7 },
                   new Pet { Name="Whiskers", Age=3 } };
            return cats;
        }

        static Pet[] GetDogs()
        {
            Pet[] dogs = { new Pet { Name="Bounder", Age=3 },
                   new Pet { Name="Snoopy", Age=14 },
                   new Pet { Name="Fido", Age=9 } };
            return dogs;
        }

        public static void ConcatTwoEnumerables()
        {
            Pet[] cats = GetCats();
            Pet[] dogs = GetDogs();

            IEnumerable<string> query =
                cats.Select(cat => cat.Name).Concat(dogs.Select(dog => dog.Name));

            foreach (string name in query)
            {
                Console.WriteLine(name);
            }
        }

        public static void GetDistinctElementsFormList()
        {
            List<int> ages = new List<int> { 21, 46, 46, 55, 17, 21, 55, 55 };

            IEnumerable<int> distinctAges = ages.Distinct();

            Console.WriteLine("Distinct ages:");

            foreach (int age in distinctAges)
            {
                Console.WriteLine(age);
            }

        }

        public static void TakeELementsFromList()
        {
            int[] grades = { 59, 82, 70, 56, 92, 98, 85 };

            IEnumerable<int> topThreeGrades =
                grades.OrderByDescending(grade => grade).Take(3);

            Console.WriteLine("The top three grades are:");
            foreach (int grade in topThreeGrades)
            {
                Console.WriteLine(grade);
            }
        }

        public static void AggregateFromListOfNumbers()
        {
            var numbers = new int[] { 2,2 };

            var result = numbers.Aggregate((a, b) => { Debug.WriteLine(a.ToString() + " * " + b.ToString()); return a * b; });



            Debug.WriteLine("Aggregated numbers by multiplication:");
            Debug.WriteLine(result);
        }


    }

    }
