using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace December_3rd_part_1
{
    internal class Program
    {
        static bool isNum(char l)
        {
            switch (l)
            {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    return true;
                default:
                    return false;
            }
        }
        static bool isSymbol(char l)
        {
            switch (l) 
            {
                case '*':
                case '£':
                case '$':
                case '%':
                case '^':
                case '&':
                case '@':
                case '#':
                case '+':
                case '=':
                case '/':
                case '-':
                    return true;
                default: 
                    return false;
            }
        }
        static void Main(string[] args)
        {
            List<string> lines = new List<string>(File.ReadAllLines("input 3.txt"));
            int result = 0;
            for (int i = 0; i < lines.Count; i++) lines[i] = "." + lines[i] + ".";
            for (int j = 0; j < lines.Count; j++)
            {
                Console.WriteLine(lines[j]);
                for(int i = 0; i < lines[j].Length;  i++) 
                {
                    string num = "";
                    if (isNum(lines[j][i]))
                    {
                        if (i - 1 < 0 || i + 1 > lines[j].Length)
                        {
                            num += lines[j][i];
                        }
                        else
                        {
                            int val = 1;
                            while (isNum(lines[j][i + val]))
                            {
                                num += lines[j][i + val];
                                val++;
                                if (i + val > lines[j].Length - 1) break;
                            }
                            i += val;
                            if (i - 1 < 0 || i + 1 > lines[j].Length)
                            {
                                if (isSymbol(lines[j][i - 1]) || isSymbol(lines[j][i + 1]))
                                {
                                    if (num != "") result += int.Parse(num);
                                }
                            }
                            for (int k = 0; k < (num.Length / 2 + 1); k++)
                            {
                                if (j - i > 0)
                                {
                                    if (isSymbol(lines[j - 1][i + k]))
                                    {
                                        if (num != "") result += int.Parse(num);
                                        break;
                                    }
                                }
                                else if (j + 1 > lines.Count - 1)
                                {
                                    if (isSymbol(lines[j + 1][i - k]))
                                    {
                                        if (num != "") result += int.Parse(num);
                                        break;
                                    }
                                }
                            }
                            for (int k = num.Length / 2; k > 0; k--)
                            {
                                if (j - i > 0)
                                {
                                    if (isSymbol(lines[j - 1][i - k]))
                                    {
                                        if (num != "") result += int.Parse(num);
                                        break;
                                    }
                                }
                                else if (j + 1 > lines.Count - 1)
                                {
                                    if (isSymbol(lines[j + 1][i + k]))
                                    {
                                        if (num != "") result += int.Parse(num);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                Console.WriteLine($"Result: {result}");
            }
            Console.ReadKey();
        }
    }
}
