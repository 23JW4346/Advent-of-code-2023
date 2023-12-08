using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;

namespace December_5th_part_1
{
    internal class Program
    {
        static List<long> GetSeedNums(string Line)
        {
            List<long> output = new List<long>();
            Regex re = new Regex(@"\d+");
            MatchCollection match = re.Matches(Line);
            foreach (Match num in match)
            {
                output.Add(long.Parse(num.ToString()));
            }
            return output;
        }
        static List<List<long>> rangeListFinder(List<string> lines)
        {

            List<List<long>> newlist = new List<List<long>>();
            Regex rg = new Regex("[0-9]+\\s");
            string input = null;
            foreach (string line in lines)
            {
                input += line;
                input += " ";
            }
            MatchCollection allmatches = rg.Matches(input);
            for (int i = 0; i < allmatches.Count; i += 3)
            {
                List<long> temp = new List<long> { long.Parse(allmatches[i].ToString()), 
                long.Parse(allmatches[i + 1].ToString()), long.Parse(allmatches[i + 2].ToString()) };
                newlist.Add(temp);
            }
            return newlist;
        }
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input 5.txt");
            List<string> map = new List<string>();
            List<List<List<long>>> lists = new List<List<List<long>>>();
            List<long> seednums = new List<long>();
            List<long> answers = new List<long>();              
            for (int linenumber = 0; linenumber < lines.Length; linenumber++)
            {
                if (!(lines[linenumber].StartsWith("seeds: ")))
                {
                    map.Add(lines[linenumber]);
                }
                else
                {
                    seednums = GetSeedNums(lines[linenumber]);
                }
                if ((lines[linenumber]) == "" && (linenumber != 1 || linenumber == lines.Length - 1))
                {
                    lists.Add(rangeListFinder(map));
                    map.Clear();
                }
            }
            foreach (long seed in seednums)
            {
                long Location = seed;
                foreach (List<List<long>> list in lists)
                {
                    foreach (List<long> points in list)
                    {
                        if (Location >= points[1] && Location < (points[1] + points[2]))
                        {
                            Location += points[0] - points[1];
                            Console.Write($"({points[0]}, {points[1]}, {points[2]}): {Location} \n");
                            break;
                        }
                    }
                }
                Console.WriteLine($"{seed}: {Location}");
                answers.Add(Location);
            }
            answers.Sort();
            foreach (long ans in answers) Console.Write(ans + ", ");
            Console.WriteLine($"Answer: {answers.Min()}");
            Console.ReadKey();
        }
    }
}
