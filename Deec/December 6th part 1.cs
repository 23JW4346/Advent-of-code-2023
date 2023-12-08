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
        static int[] intgetter(List<string> strings)
        {
            int[] newints = new int[strings.Count];
            for(int i  = 0; i < strings.Count; i++)
            {
                newints[i] = int.Parse(strings[i]);
            }
            return newints;
        }
        static int distancecalculator(int buttondown, int maxtime)
        {
            int buttonup = maxtime - buttondown;
            int distmade = buttondown * buttonup;
            return distmade;
        }
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input 6.txt");
            List<string> times = new List<string>(lines[0].Split(':')[1].Trim().Split(' '));
            List<string> distances = new List<string>( lines[1].Split(':')[1].Trim().Split(' '));
            while (times.Contains("")) times.Remove("");
            while (distances.Contains("")) distances.Remove("");
            int[] timesints = intgetter(times);
            int[] dist = intgetter(distances);
            int[] results = new int[timesints.Length];
            for(int i = 0; i <  timesints.Length; i++)
            {
                results[i] = 1;
                List<int> totaldistmade = new List<int>();
                for (int j = 1; j <= timesints[i]; j++)
                {
                    int distmade = distancecalculator(j, timesints[i]);
                    if (distmade > dist[i] && distmade != 0 && results[i] !=0)
                    {
                        if (results[i] * distmade != 0) totaldistmade.Add(distmade);
                    }
                }
                results[i] *= totaldistmade.Count;
            }
            int ans = results[0] * results[1] * results[2] * results[3];
            Console.WriteLine($"Answer: '{results[0]} * {results[1]} * {results[2]} * {results[3]}' = {ans}");
            Console.ReadKey();
        }
    }
}
