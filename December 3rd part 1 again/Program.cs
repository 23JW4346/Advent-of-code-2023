using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;

namespace December_3rd_part_1
{
    class Program
    {
        static int CalculateSum(string[] lines)
        {
            int sum = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (IsSymbol(lines[i][j]))
                    {
                        sum += GetAdjacentNumbers(lines, i, j);
                    }
                }
            }
            return sum;
        }
        static bool isDigit(char l)
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
        static bool IsSymbol(char c)
        {
            char[] symbols = { '*', '#', '+', '$' , '/', '%', '+', '@', '-', '&',  };
            return symbols.Contains(c);
        }

        static int GetAdjacentNumbers(string[] lines, int row, int col)
        {
            int result = 0;
            // x and y coordinates around the symbol point. 
            int[] dx = { 0, 0, -1, 1, -1, -1, 1, 1 };
            int[] dy = { -1, 1, 0, 0, -1, 1, -1, 1 };
            for (int i = 0; i < dx.Length; i++)
            {
                string sum = "";
                int newRow = row + dx[i];
                int newCol = col + dy[i];
                // check to see if its in bounds
                if (newRow >= 0 && newRow < lines.Length && newCol >= 0 && newCol < lines[newRow].Length)
                {
                    // checks if its a digit
                    if (isDigit(lines[newRow][newCol]))
                    {
                        int j = 1;
                        sum += lines[newRow][newCol];
                        while (isDigit(lines[newRow][newCol + j]))
                        {
                            sum += lines[newRow][newCol+j];
                            j++;
                        }
                        j = 1;
                        while (isDigit(lines[newRow][newCol - j]))
                        {
                            sum = lines[newRow][newCol-j] + sum;
                            j++;
                        }
                        result += int.Parse(sum);
                    }
                }
                Console.WriteLine($"Sum: {result}");
            }
            return result;
        }
        static void Main()
        {
            string[] lines = File.ReadAllLines("input 3.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = "." + lines[i] + ".";
            }
            int sum = CalculateSum(lines);
            Console.WriteLine($"Sum of numbers: {sum}");
            Console.ReadKey();
        }
    }     
}