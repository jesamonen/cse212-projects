public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.
    /// </summary>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step 1: Create an array of size 'length' to store results
        double[] result = new double[length];

        // Step 2: Loop through each index from 0 to length - 1
        for (int i = 0; i < length; i++)
        {
            // Step 3: Store multiples of number (i + 1 ensures we start at number itself)
            result[i] = number * (i + 1);
        }

        // Step 4: Return the completed array
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.
    /// This modifies the existing list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Find the split point (where rotation happens)
        int splitIndex = data.Count - amount;

        // Step 2: Get the last 'amount' elements (these go to the front)
        List<int> rightPart = data.GetRange(splitIndex, amount);

        // Step 3: Get the first part of the list
        List<int> leftPart = data.GetRange(0, splitIndex);

        // Step 4: Clear original list so we can rebuild it
        data.Clear();

        // Step 5: Add right part first (rotated section)
        data.AddRange(rightPart);

        // Step 6: Add left part after it
        data.AddRange(leftPart);
    }
}