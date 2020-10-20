using System;
using System.Linq;
using System.Xml;

namespace TupleStringCompare
{
    class Program
    {
        static void Main(string[] args)
        {
            //Use Jagged array instead of Tuple array because remove initilization of empty member.
            string[][] synonyms = new string[2][];
            synonyms[0] = new string[] { "rate", "ratings", "rates" };
            synonyms[1] = new string[] { "approval", "popularity" };

            Tuple<string, string>[] queries = new Tuple<string, string>[]{
                new Tuple<string, string>("obama approval rate", "obama popularity ratings"),
                new Tuple<string, string>("obama popularity rates", "obama approval ratings"),
                new Tuple<string, string>("obama approval rating", "obama TV ratings"),
                new Tuple<string, string>("obama approval rate", "popularity ratings obama")};

            //initial results to be all true first.
            bool[] results = Enumerable.Repeat(true, 4).ToArray();

            int i = 0;
            foreach (Tuple<string, string> query in queries)
            {
                foreach(string[] synonym in synonyms)
                {
                    results[i] &= synonym.Any(query.Item1.Contains) && synonym.Any(query.Item2.Contains);
                }
                i++;
            }

            var output = results.Select(x => x);

            Console.WriteLine("[{0}]", string.Join(", ", output));
            Console.ReadKey();
        }
    }
}
