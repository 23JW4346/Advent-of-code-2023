using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Data;
namespace December_3rd_part_2
{
    class Program
    {
        static char[,] getmap(string[] lines)
        {
            char[,] map = new char[lines[0].Length, lines.Length];
            for(int x = 0; x < lines[0].Length; x++)
            {
                for (int y = 0;  y < lines.Length; y++)
                {
                    map[x, y] = lines[x][y];
                }
            }
            return map;
        }
        static string getrestofnum(char[,] map, int x, int y)
        {   
            string num = map[x,y] + "";
            int newx = x+1;
            while (newx <= map.GetLength(0) && newx >= 0)
            {
                while (Char.IsDigit(map[newx, y]))
                {
                    num += map[newx, y];
                    newx++;
                    if (x >= map.GetLength(0)) break;
                }
                newx = x - 1;
                while (Char.IsNumber(map[newx, y]))
                {
                    num = map[newx, y] + num;
                    newx--;
                    if (x <= 0) break;
                }
            }
            return num;
             
        }
        static void Main(string[] args)
        {
            string[] engineSchematic = File.ReadAllLines("input 3.txt");
            char[,] map = getmap(engineSchematic);
            bool validnum = false;
            string number = null;
            int sum = 0; 
            for(int y = 0; y < map.GetLength(1); y++)
            {
                for(int x = 0; x < map.GetLength(0); x++)
                {
                    char c = map[x, y];
                    if (c == '*')
                    {
                        number += getrestofnum(map, x, y);
                        for(int i = -1; i <= 1; i++)
                        {
                            for (int j = -1; j <= 1; j++)
                            {
                                int currentx = x + j;
                                int currenty = y + i;
                                if (currentx >= 0 && currentx <= map.GetLength(0)
                                    && currenty >= 0 && currenty <= map.GetLength(1)
                                    && (currentx != 0 || currenty != 0))
                                {
                                    if (Char.IsNumber(map[currentx, currenty]))
                                    {
                                        validnum = true;
                                        number = getrestofnum(map, currentx, currenty);
                                    }
                                }
                            }
                        }
                    }
                    if (validnum && !Char.IsNumber(c) || (x == map.GetLength(0) && y == map.GetLength(1)))
                    {
                        try
                        {
                            sum += Int32.Parse(number);
                        }
                        catch
                        {
                            Console.WriteLine($"unable to parse '{number}'");
                        }
                    }
                }
            }
            Console.ReadKey();
        }
    }
}

