using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.InteropServices;

namespace December_1st
{
    internal class Program
    {
        static int switchnum(string word, int i)
        {
            switch (word[i])
            {
                case '0':
                    return 0;
                case '1':
                    return 1;
                case '2':
                    return 2;
                case '3':
                    return 3;
                case '4':
                    return 4;
                case '5':
                    return 5;
                case '6':
                    return 6;
                case '7':
                    return 7;
                case '8':
                    return 8;
                case '9':
                    return 9;
                default:
                    return 10;

            }
        }
        static void Main(string[] args)
        {
            int total = 0;
            string[] lines = File.ReadAllLines("Day 1.txt");
            List<string> linelist = new List<string> { };
            foreach (string line in lines) linelist.Add(line);
            for (int i = 0; i < linelist.Count; i++)
            {
                Console.WriteLine(linelist[i]);
                linelist[i] = linelist[i].Replace("zero", "zero0zero").Replace("one", "one1one").Replace("two", "two2two").Replace("three", "three3three")
                .Replace("four", "four4four").Replace("five", "five5five").Replace("six", "six6six").Replace("seven", "seven7seven")
                .Replace("eight", "eight8eight").Replace("nine", "nine9nine");
                string number = "";
                Console.WriteLine(linelist[i]);
                for (int j = 0; j < linelist[i].Length; j++)
                {
                    if (switchnum(linelist[i], j) < 10 && switchnum(linelist[i], j) > -1)
                    {
                        number += linelist[i][j];
                        j = 10000;
                    }
                    Console.WriteLine(number);
                }
                for (int k = linelist[i].Length - 1; k >= 0; k--)
                {
                    if (switchnum(linelist[i], k) < 10 && switchnum(linelist[i], k) > -1)
                    {
                        number += linelist[i][k];
                        k = -10;
                    }
                }
                Console.WriteLine("the two numbers in the string are" + number);
                total += int.Parse(number);
                Console.WriteLine("total = " + total);

            }
            Console.ReadKey();
        }
    }
}
