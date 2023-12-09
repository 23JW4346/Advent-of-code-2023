using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Web;

namespace December_7th_part_1
{
    internal class Program
    {
        struct hand
        {
            public string card;
            public int bid;
        }
        static int numsCard(string hand1, int count)
        {
            string temp = hand1;
            int numofcard = 0 ;
            while (temp.Contains(hand1[count]))
            {
                numofcard++;
                temp.Replace(hand1[count], ' ');
            }
            return numofcard;
        }
        static bool handBetter(string hand1, string hand2)
        {
            char[] cards = { '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A' };
            int numofcard1 = 0, numofcard2 = 0, count = 0 ;
            string temp1 = hand1, temp2 = hand2;
            while (numofcard1 <= 2)  numofcard1 = numsCard(temp1, count);
            while (numofcard2 <= 2)  numofcard2 = numsCard(temp2, count);
            if (numofcard1 > numofcard2) return true;
            else if (numofcard1 < numofcard2) return false;
            else
            {
                temp1.Trim(' ');
                temp2.Trim(' ');
                if (temp1.Length >= 2)
                {
                    int numoftemp1 = 0, numoftemp2 = 0;
                    for (int i = 0; i < hand1.Length; i++)
                    {
                        if (temp1[0] == temp1[i])
                        {
                            numoftemp1++;
                        }
                        if (temp1[0] == temp2[i])
                        {
                            numoftemp2++;
                        }
                    }
                    if (numoftemp1 > numoftemp2) return true;
                    else if (numoftemp1 < numoftemp2) return false;
                }
                int secondcount = 0;
                while (hand1[secondcount] == hand2[secondcount])
                {
                    count++;
                }
                if (Array.IndexOf(cards, hand1[count]) > Array.IndexOf(cards, hand2[count])) return true;
                else return false;
            }
        }
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("test.txt");
            hand[] hands = new hand[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                hands[i].card = (lines[i].Trim().Split(' ')[0]);
                hands[i].bid = int.Parse(lines[i].Trim().Split(' ')[1]);
                Console.WriteLine($"Hand: {hands[i].card} Bid: {hands[i].bid}");
            }
            List<long> ranks = new List<long>();
            List<string> handcompare = new List<string>();
            List<long> numofcard = new List<long>();
            for (int i = 0; i < lines.Length; i++)
            {
                List<string> newlist = new List<string>();
                Console.WriteLine(hands[i].card);
                if (handcompare.Count > 0)
                {
                    for (int j = 0; j < handcompare.Count; j++)
                    {
                        if (j < lines.Length)
                        {
                            if (handBetter(hands[i].card, handcompare[j]))
                            {
                                for (int count = 0; count < j - 1; count++)
                                {
                                    newlist.Add(handcompare[count]);
                                }
                                newlist.Add(hands[i].card);
                                for (int k = j; k < handcompare.Count; k++) newlist.Add(handcompare[k]);
                                handcompare = newlist;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    handcompare.Add(hands[i].card);
                }
                ranks.Add(i);
            }
            Console.WriteLine($"Sorted list: ");
            foreach (string han in handcompare)
            {
                Console.Write(han + ", ");
            }
            Console.ReadKey();
        }
    }
}
