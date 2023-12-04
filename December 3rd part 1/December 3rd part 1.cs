using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;

namespace December_3rd_part_1
{
    internal class Program
    {
        static int toInt(char c)
        {
            return (int)(c - '0');
        }

        static bool isSymbol(char c)
        {
            return !char.IsNumber(c) && !(c == '.');
        }

        static bool isValid(int x, int y, int numCols, int numRows)
        {
            return x >= 0 && x < numCols && y >= 0 && y < numRows;
        }

        static bool findPartNums(string[] lines, int i, int j, int place, int numCols, int numRows)
        {
            for (int y = i - 1; y <= i + 1; y++)
            {
                for (int x = j - 1; x <= j + place; x++)
                {
                    if (isValid(x, y, numCols, numRows) && isSymbol(lines[y][x]))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        static void Main(string[] args)
        {
            int total = 0;

            string[] lines = File.ReadAllLines("input 3.txt");
            int numberRows = lines.Length;
            int numberCols = lines[0].Length;

            for (int i = 0; i < numberRows; i++)
            {
                for (int j = 0; j < numberCols; j++)
                {
                    if (char.IsNumber(lines[i][j]))
                    {
                        int num = 0;
                        int place = 0;

                        while (j + place < numberCols && char.IsNumber(lines[i][j + place]))
                        {
                            num = num * 10 + toInt(lines[i][j + place]);
                            place++;
                        }

                        bool valid = findPartNums(lines, i, j, place, numberCols, numberRows);

                        if (valid)
                        {
                            total += num;
                        }

                        j += place;
                    }
                }
            }
            Console.WriteLine(total);
            Console.ReadKey();
        }
    }
}


