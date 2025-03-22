using System;

namespace KattisProblemSolving
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine().Trim(' ');
            string input = "";

            for (int o = 0; o < s.Length; o++)
            {
                if (s[o] != ' ')
                {
                    input += s[o];
                }
            }

            int rows = (int)Math.Floor(Math.Sqrt(input.Length));
            int columns = (int)Math.Ceiling(Math.Sqrt(input.Length));

            while (rows * columns < input.Length)
            {
                if (columns >= rows)
                {
                    rows++;
                }
                else
                {
                    columns++;
                }
            }

            char[,] grid = new char[rows, columns];

            int i = 0;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    if (i != input.Length)
                    {
                        grid[r, c] = input[i];
                        i++;
                    }
                    else
                    {
                        grid[r, c] = '#';
                    }
                }
            }

            i = 0;
            string message = "";

            for (int c = 0; c < columns; c++)
            {
                for (int r = 0; r < rows; r++)
                {
                    if (grid[r,c] != '#')
                    {
                        message += grid[r, c] + "";
                    }
                }

                if (c != columns - 1)
                {
                    message += " ";
                }
            }

            Console.WriteLine(message);
        }
    }
}