using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace December_4th_part_2
{
    internal class Program
    {
        static int compare(List<string> winning, List<string> your)
        {
            int points = 0;
            for (int i = 0; i < your.Count; i++)
            {
                if (winning.Contains(your[i])) points++;
            }
            return points;
        }
        static int string_spliter(string line, int result)
        {

            string[] split = line.Split(':')[1].Trim().Split('|');
            List<string> winnum = new List<string>(split[0].Trim().Split(' '));
            while (winnum.Contains("")) winnum.Remove("");
            List<string> yournum = new List<string>(split[1].Trim().Split(' '));
            while (yournum.Contains("")) yournum.Remove("");
            result = compare(winnum, yournum);
            return result;
        }
        static void Main(string[] args)
        {
            int result = 0;
            string[] lines = File.ReadAllLines("input 4.txt");
            int[] totalcards = new int[lines.Length];
            for (int i = 0; i < totalcards.Length; i++) totalcards[i] = 1;
            for (int Linenumber = 0; Linenumber < lines.Length; Linenumber++)
            {
                int match = string_spliter(lines[Linenumber], result);
                for (int i = Linenumber + 1; i <= Linenumber + match; i++)
                {
                    totalcards[i] += totalcards[Linenumber];
                }
            }
            Console.WriteLine($"Final Result: {totalcards.Sum()}");
            Console.ReadKey();
        }
    }
}