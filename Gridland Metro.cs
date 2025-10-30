using System;
using System.Collections.Generic;
using System.Linq;

class Solution
{
    public static long gridlandMetro(int n, int m, int k, List<List<int>> track)
    {
        
        Dictionary<int, List<Tuple<int, int>>> rows = new Dictionary<int, List<Tuple<int, int>>>();

        foreach (var t in track)
        {
            int r = t[0];
            int c1 = t[1];
            int c2 = t[2];

            if (!rows.ContainsKey(r))
                rows[r] = new List<Tuple<int, int>>();

            rows[r].Add(Tuple.Create(c1, c2));
        }

        long totalOccupied = 0;

        foreach (var kvp in rows)
        {
            var segments = kvp.Value;
            
            segments.Sort((a, b) => a.Item1.CompareTo(b.Item1));

            int start = -1, end = -1;
            foreach (var seg in segments)
            {
                if (seg.Item1 > end)
                {
                    
                    totalOccupied += (end - start > 0) ? (end - start + 1) : 0;
                    start = seg.Item1;
                    end = seg.Item2;
                }
                else
                {
                    
                    end = Math.Max(end, seg.Item2);
                }
            }
            totalOccupied += (end - start + 1);
        }

        long totalCells = (long)n * m;
        return totalCells - totalOccupied;
    }

    static void Main(string[] args)
    {
        string[] nmk = Console.ReadLine().Split(' ');
        int n = int.Parse(nmk[0]);
        int m = int.Parse(nmk[1]);
        int k = int.Parse(nmk[2]);

        List<List<int>> track = new List<List<int>>();
        for (int i = 0; i < k; i++)
        {
            track.Add(Console.ReadLine().Split(' ').Select(int.Parse).ToList());
        }

        long result = gridlandMetro(n, m, k, track);
        Console.WriteLine(result);
    }
}
