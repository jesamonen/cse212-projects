using System.Collections;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it.  Remember to both express the solution 
    /// in terms of recursive call on a smaller problem and 
    /// to identify a base case (terminating case).  If the value of
    /// n <= 0, just return 0.   A loop should not be used.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        // Base case: if n is less than or equal to 0, stop recursion.
        if (n <= 0)
        {
            return 0;
        }

        // Recursive case: n^2 + sum of squares up to (n - 1)
        return (n * n) + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length
    /// 'size' from a list of 'letters' into the results list.  This function
    /// should assume that each letter is unique (i.e. the 
    /// function does not need to find unique permutations).
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // Base case: if our accumulated word has reached the desired size, record it.
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        // Branching: loop through available letters to pick the next one
        for (int i = 0; i < letters.Length; i++)
        {
            char chosenChar = letters[i];
            
            // Remove the chosen character from remaining letters
            string remainingLetters = letters.Remove(i, 1);
            
            // Recurse with the updated word and remaining letters
            PermutationsChoose(results, remainingLetters, size, word + chosenChar);
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// To run this function for larger values of 's', you will need
    /// to update this function to use memoization.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        // Initialize dictionary on first call
        remember ??= new Dictionary<int, decimal>();

        // Base Cases
        if (s <= 0)
            return 0;
        if (s == 1)
            return 1;
        if (s == 2)
            return 2;
        if (s == 3)
            return 4;

        // Check memoization dictionary before computing
        if (remember.ContainsKey(s))
        {
            return remember[s];
        }

        // Solve using recursion with memoization pass-through
        decimal ways = CountWaysToClimb(s - 1, remember) + 
                       CountWaysToClimb(s - 2, remember) + 
                       CountWaysToClimb(s - 3, remember);

        // Store result in dictionary and return
        remember[s] = ways;
        return ways;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// Using recursion, insert all possible binary strings for a given pattern into the results list.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int index = pattern.IndexOf('*');

        // Base case: no wildcard found, pattern is a full binary string
        if (index == -1)
        {
            results.Add(pattern);
            return;
        }

        // Split pattern before and after '*'
        string prefix = pattern[..index];
        string suffix = pattern[(index + 1)..];

        // Branch 1: replace '*' with '0'
        WildcardBinary(prefix + "0" + suffix, results);

        // Branch 2: replace '*' with '1'
        WildcardBinary(prefix + "1" + suffix, results);
    }

    /// <summary>
    /// #############
    /// # Problem 5 #
    /// #############
    /// Use recursion to insert all paths that start at (0,0) and end at the
    /// 'end' square into the results list.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        // Initialize path list on first call
        currPath ??= new List<ValueTuple<int, int>>();

        // Check boundary limits and valid move using maze helper
        if (!maze.IsValidMove(currPath, x, y))
        {
            return;
        }

        // Add current coordinate to path
        currPath.Add((x, y));

        // Base case: check if we reached the end of the maze
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
        }
        else
        {
            // Recursive cases: try moving Right, Left, Down, Up
            SolveMaze(results, maze, x + 1, y, currPath); // Move Right
            SolveMaze(results, maze, x - 1, y, currPath); // Move Left
            SolveMaze(results, maze, x, y + 1, currPath); // Move Down
            SolveMaze(results, maze, x, y - 1, currPath); // Move Up
        }

        // Backtrack: remove current cell before returning to caller
        currPath.RemoveAt(currPath.Count - 1);
    }
}