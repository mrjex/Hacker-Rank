using System;
using System.Collections.Generic;
using System.Linq;

namespace ProblemSolving2
{
    class Program
    {
        static void Main(String[] args)
        {
            int amountOfTestCasesLeft = Convert.ToInt32(Console.ReadLine());
            while (amountOfTestCasesLeft-- > 0)
            {
                bool printYes = false;
                int[] values = Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToInt32);
                string[] rows = new string[values[0]];

                for (int i = 0; i < values[0]; i++)
                {
                    rows[i] = Console.ReadLine();
                }

                int[] patternValues = Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToInt32);
                string[] patternRows = new string[patternValues[0]];

                for (int i = 0; i < patternValues[0]; i++)
                {
                    patternRows[i] = Console.ReadLine();
                }

                for (int i = 0; i <= values[0] - patternRows.Length; i++)
                {
                    if (rows[i].Contains(patternRows[0]))
                    {
                        List<string> columnBoundries = new List<string>();

                        for (int o = 0; o < rows[i].Length - patternValues[1] + 1; o++)
                        {
                            if (rows[i].Substring(o, patternValues[1]) == patternRows[0])
                                columnBoundries.Add(o + " " + (o + patternValues[1] - 1));
                        }

                        for (int c = 0; c < columnBoundries.Count; c++)
                        {
                            int s = Convert.ToInt32(columnBoundries[c].Split(' ').First());
                            int r = 1;

                            for (int o = i + 1; o < rows.Length; o++)
                            {
                                if (rows[o].Substring(s, patternValues[1]) != patternRows[r++]) 
                                { 
                                    break; 
                                }

                                if (r == patternRows.Length) { printYes = true; break; }
                            }

                            if (printYes) break;
                        }
                    }

                    if (printYes) break;
                }

                if (printYes)
                    Console.WriteLine("YES");
                else
                    Console.WriteLine("NO");
            }
        }
    }
}