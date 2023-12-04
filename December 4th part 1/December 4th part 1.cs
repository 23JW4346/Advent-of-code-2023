using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices.ComTypes;

namespace December_4th_part_1
{
    internal class Program
    {
        static int compare(List<string> winning, List<string> your)
        {
            int points = 0; 
            for(int i = 0; i < your.Count; i++)
            {
                if (winning.Contains(your[i])) points++;
            }
            if (points == 0) return 0;
            else if (points > 0) return (int)Math.Pow(2, points - 1);
            else return 0;
        }
        static void string_spliter(string line, ref int result)
        {
            string[] split = line.Split(':')[1].Trim().Split('|');
            List<string> winnum = new List<string>(split[0].Trim().Split(' '));
            while (winnum.Contains("")) winnum.Remove("");
            List<string> yournum = new List<string>(split[1].Trim().Split(' '));
            while (yournum.Contains("")) yournum.Remove("");
            result += compare(winnum, yournum);
        }
        static void Main(string[] args)
        {
            int result=0;
            string[] lines = File.ReadAllLines("input 4.txt");
            foreach(string line in lines)
            {
                string_spliter(line, ref result);
            }
            Console.WriteLine($"Final Result: {result}");
            Console.ReadKey();
        }
    }
}
