using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;

class Program
{
    static void listPrint(List<int> nums)
    {
        Console.Write("[");
        foreach (int i in nums)
        {
            Console.Write(i + ", ");
        }
        Console.WriteLine("]");
    }
    static List<int> GetAdjacentNumbers(string[] lines, int row, int col)
    {
        List<int> numbers = new List<int>();
        int sum = 0;
        for (int i = row - 1; i <= row + 1; i++)
        {
            for (int j = col - 1; j <= col + 1; j++)
            {
                if (i >= 0 && i < lines.Length && j >= 0 && j < lines[i].Length &&
                    (i != 0 || j!= 0) && char.IsNumber(lines[i][j]))
                {
                    sum += lines[i][j];
                    int k = 1;
                    while (Char.IsNumber(lines[i][j]))
                    {
                        sum += lines[i][j + k];
                        k++;
                    }
                    k = 1;
                    while (Char.IsNumber(lines[i][j]))
                    {
                        sum = lines[i][j - k] + sum;
                        k++;
                    }
                    numbers.Add(int.Parse(sum.ToString()));
                }
            }
        }
        listPrint(numbers);
        return numbers;
    }
    static int CalculateGearRatios(string[] engine)
    {
        List<int> gearRatios = new List<int>();
        for (int row = 0; row < engine.Length; row++)
        {
            for (int col = 0; col < engine[row].Length; col++)
            {
                if (engine[row][col] == '*')
                {
                    List<int> adjacentNumbers = GetAdjacentNumbers(engine, row, col);
                    if (adjacentNumbers.Count == 2)
                    {
                        int gearRatio = 1;
                        for (int x = 0; x < adjacentNumbers.Count; x++)
                        {
                            gearRatio *= adjacentNumbers[x];
                        }
                        gearRatios.Add(gearRatio);
                        Console.WriteLine(gearRatio);
                    }
                    
                }
            }
        }
        return gearRatios.Sum();
    }
    static void Main(string[] args)
    {
        string[] engineSchematic = File.ReadAllLines("input 3.txt");
        int result = CalculateGearRatios(engineSchematic);
        Console.WriteLine(result);
        Console.ReadKey();
    } 
}

