using System;
namespace KattisProblemSolving
{
    class Program
    {
        static int n;
        static int m;
        static bool[,] map;
        static bool[,] originalMap;

        static int finalPlusLengthA;
        static int finalPlusLengthB;

        static void Main(String[] args)
        {
            var tmp = Console.ReadLine().Split(' ');
            n = int.Parse(tmp[0]);
            m = int.Parse(tmp[1]);

            int G = 0;
            map = new bool[n, m];
            originalMap = new bool[n, m];
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();
                for (int j = 0; j < m; j++)
                {
                    map[i, j] = line[j] == 'G';
                    if (map[i, j]) G++;
                }
            }

            Array.ConstrainedCopy(map, 0, originalMap, 0, map.Length);
            int ans = 1;

            if (G < 2) Console.WriteLine(0);
            else
            {
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < m; j++)
                    {
                        if (!map[i, j]) continue;

                        int h = 1, v = 1;
                        while (j - h >= 0 && j + h < m && map[i, j - h] && map[i, j + h])
                            h++;

                        while (i - v >= 0 && i + v < n && map[i - v, j] && map[i + v, j])
                            v++;

                        int firstPlusLength = Math.Min(h, v) - 1;
                        for (int p = i - firstPlusLength; p <= i + firstPlusLength; p++)
                            map[p, j] = false;

                        for (int p = j - firstPlusLength; p <= j + firstPlusLength; p++)
                            map[i, p] = false;

                        int secondPlusLength = GetSecondPlusLength();
                        if (ans < (4 * firstPlusLength + 1) * ((4 * secondPlusLength) + 1))
                        {
                            ans = (4 * firstPlusLength + 1) * ((4 * secondPlusLength) + 1);
                            finalPlusLengthA = firstPlusLength; finalPlusLengthB = secondPlusLength;
                        }
                        Array.ConstrainedCopy(originalMap, 0, map, 0, originalMap.Length);
                    }

                if (Math.Abs(finalPlusLengthA - finalPlusLengthB) > 0)
                {
                    ans = 0;
                    int length = -1;
                    while (++length <= 15 / 2)
                    {
                        for (int i = 0; i < n - length; i++)
                            for (int j = 0; j < m - length; j++)
                            {
                                bool isValidPlus = true;
                                for (int c = i; c <= i + length; c++)
                                {
                                    if (i - (c - i) < 0 || !map[c, j] || !map[i - (c - i), j])
                                    {
                                        isValidPlus = false;
                                        break;
                                    }
                                    else
                                    {
                                        map[c, j] = false;
                                        map[i - (c - i), j] = false;
                                    }
                                }

                                if (isValidPlus)
                                {
                                    for (int c = j + 1; c <= j + length; c++)
                                    {
                                        if (j - (c - j) < 0 || !map[i, c] || !map[i, j - (c - j)])
                                        {
                                            isValidPlus = false;
                                            break;
                                        }
                                        else
                                        {
                                            map[i, c] = false;
                                            map[i, j - (c - j)] = false;
                                        }
                                    }

                                    if (isValidPlus)
                                    {
                                        int secondPlusLength = GetSecondPlusLength();
                                        ans = Math.Max(ans, ((length * 4) + 1) * ((secondPlusLength * 4) + 1));
                                    }
                                }
                                Array.ConstrainedCopy(originalMap, 0, map, 0, originalMap.Length);
                            }
                    }
                }
                Console.WriteLine(ans);
            }
        }

        static int GetSecondPlusLength()
        {
            int plusLength = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    if (!map[i, j]) continue;

                    int h = 1, v = 1;
                    while (j - h >= 0 && j + h < m && map[i, j - h] && map[i, j + h])
                        h++;

                    while (i - v >= 0 && i + v < n && map[i - v, j] && map[i + v, j])
                        v++;

                    if (Math.Min(h, v) - 1 > plusLength)
                        plusLength = Math.Min(h, v) - 1;
                }
            return plusLength;
        }
    }
}