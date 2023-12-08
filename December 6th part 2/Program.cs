using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;

namespace Deec
{
    internal class Program
    {
        static long distancecalculator(long buttondown, long maxtime)
        {
            long buttonup = maxtime - buttondown;
            long distmade = buttondown * buttonup;
            return distmade;
        }
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input 6.txt");
            List<string> times = new List<string>(lines[0].Split(':')[1].Trim().Split(' '));
            List<string> distances = new List<string>(lines[1].Split(':')[1].Trim().Split(' '));
            while (times.Contains("")) times.Remove("");
            while (distances.Contains("")) distances.Remove("");
            long timesint = long.Parse(times[0] + times[1] + times[2] + times[3]);
            long dist = long.Parse(distances[0] + distances[1] + distances[2] + distances[3]);
            Console.WriteLine($"time: '{timesint}'  Distance: {dist}");
            int result = 1;
            List<long> totaldistmade = new List<long>();
            for (int i = 1; i <= timesint; i++)
            {
                long distmade = distancecalculator(i, timesint);
                if (distmade > dist && distmade != 0 && result != 0)
                {
                    totaldistmade.Add(distmade);
                    Console.WriteLine(distmade);
                }
            }
            result *= totaldistmade.Count;
            Console.WriteLine($"Answer: '{result}'");
            Console.ReadKey();
        }

    }
}