using System;
using System.Collections.Generic;
using System.Linq;

namespace KattisProblemSolving
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            int[] tempArr = Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToInt32);

            HashSet<int> hashSetRanked = tempArr.ToHashSet();
            int[] ranked = new int[hashSetRanked.Count];

            List<int> listRanked = new List<int>();

            hashSetRanked.CopyTo(ranked);

            for (int i = 0; i < ranked.Length; i++)
            {
                listRanked.Add(ranked[i]);
            }

            Console.ReadLine();       
            int[] player = Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToInt32);

            Array.Reverse(ranked);
            listRanked.Reverse();

            int start = 0;
            bool hasFoundRanking;

            for (int i = 0; i < player.Length; i++)
            {
                hasFoundRanking = false;

                for (int j = start; j < listRanked.Count; j++)
                {
                    if (player[i] < listRanked[j])
                    {
                        Console.WriteLine(listRanked.Count - j + 1);

                        start = j;
                        hasFoundRanking = true;

                        break;
                    }
                }

                if (!hasFoundRanking)
                {
                    listRanked.Add(player[i]);                   
                    Console.WriteLine(1);
                }
            }
        }
    }
}