using System;
using System.Collections.Generic;

// Keep this class in the global namespace because the provided tests
// refer to Recursion without a namespace qualifier.
public static class Recursion
{
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
            return 0;

        return n * n + SumSquaresRecursive(n - 1);
    }

    public static void PermutationsChoose(List<string> results, string letters, int size, string currPerm = "")
    {
        if (currPerm.Length == size)
        {
            results.Add(currPerm);
            return;
        }

        for (int i = 0; i < letters.Length; i++)
        {
            char selected = letters[i];
            string remaining = letters.Substring(0, i) + letters.Substring(i + 1);
            PermutationsChoose(results, remaining, size, currPerm + selected);
        }
    }

    // Decimal is large enough for the expected result at 100 steps.
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        remember ??= new Dictionary<int, decimal>();

        if (s < 0)
            return 0m;
        if (s == 0)
            return 1m;

        if (remember.TryGetValue(s, out decimal cached))
            return cached;

        decimal ways = CountWaysToClimb(s - 1, remember)
                     + CountWaysToClimb(s - 2, remember)
                     + CountWaysToClimb(s - 3, remember);

        remember[s] = ways;
        return ways;
    }

    // Signature matches the supplied tests: pattern first, results second.
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int wildcardIndex = pattern.IndexOf('*');

        if (wildcardIndex == -1)
        {
            results.Add(pattern);
            return;
        }

        string prefix = pattern[..wildcardIndex];
        string suffix = pattern[(wildcardIndex + 1)..];

        WildcardBinary(prefix + "0" + suffix, results);
        WildcardBinary(prefix + "1" + suffix, results);
    }

    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<(int, int)>? currPath = null)
    {
        currPath ??= new List<(int, int)>();
        currPath.Add((x, y));

        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            currPath.RemoveAt(currPath.Count - 1);
            return;
        }

        (int dx, int dy)[] directions = { (1, 0), (-1, 0), (0, 1), (0, -1) };

        foreach (var (dx, dy) in directions)
        {
            int newX = x + dx;
            int newY = y + dy;

            if (maze.IsValidMove(currPath, newX, newY))
                SolveMaze(results, maze, newX, newY, currPath);
        }

        currPath.RemoveAt(currPath.Count - 1);
    }
}
