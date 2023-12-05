using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;

namespace December_5th_part_1
{
    internal class Program
    {
        static List<List<long>> rangeListFinder(string[] lines, long count, long start)
        {
            List<List<long>> newlist = new List<List<long>>();
            for (long i = start + 1; i < count + start; i++)
            {
                string[] part = lines[i].Trim().Split(' ');
                for (long k = 0; k < 2; k++)
                {
                    List<long> longs = new List<long>();
                    for (long j = 0; j < long.Parse(part[2]); j++)
                    {
                        longs.Add(long.Parse(part[k]) + j);
                    }
                    newlist.Add(longs);
                }
            }
            return newlist;
        }           
        static List<long> rangeFinder(string[] lines, long count, long start)
        {
            List<long> newlong = new List<long>();
            for(long i = start+1; i < count + start; i++)
            {
                string[] part = lines[i].Trim().Split(' ');
                newlong.Add(long.Parse(part[2]));
            }
            return newlong;
        }
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input 5.txt");
            string[] seeds = lines[0].Split(':')[1].Trim().Split(' ');
            long[] seednums = new long[seeds.Length];
            for(long i = 0; i < seeds.Length; i++)
            {
                seednums[i] = long.Parse(seeds[i]);
            }
            long startline = 2;
            long count = 0;
            List<List<List<long>>> lists = new List<List<List<long>>>();
            List<List<long>> ranges = new List<List<long>>();
            for (long i = 2; i < lines.Length; i++)
            {
                if (lines[i] == "\n")
                {
                    lists.Add(rangeListFinder(lines, count, startline));
                    ranges.Add(rangeFinder(lines, count, startline));
                    startline = count + 1;
                    count = 0;
                }
                else count++;
            }
            List<long> locationnums = new List<long>();
            locationnums.Add(0);
            for (int j = 0; j <= 42; j++)
            {
                for (long i = 0; i < seeds.Length; i++)
                {
                    long temp = seednums[i] - ranges[0][j];
                    if (lists[0][0].Contains(seednums[i]))
                    {
                        if (locationnums[0] == 0)
                        {
                            locationnums[0] = temp;
                        }
                        else if (temp < locationnums[0])
                        {
                            locationnums[0] = temp;
                        }
                    }
                } 
            }
            for(long i = 1; i < lists.Count; i++)
            {

            }
            locationnums.Sort();
            Console.WriteLine(locationnums[0]);
            Console.ReadKey();
        }
    }
}
