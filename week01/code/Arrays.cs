using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce a double array of size 'length' where the first element is 'number'
    /// and each subsequent element is a multiple of 'number'.
    /// </summary>
    /// <param name="number">The starting value and base number for multiples</param>
    /// <param name="length">The number of elements/multiples to generate</param>
    /// <returns>An array containing multiples of 'number'</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step 1: Initialize a new double array of size 'length' to store the generated multiples.
        double[] result = new double[length];

        // Step 2: Loop from index 0 up to length - 1.
        // Step 3: For each index 'i', calculate the multiple by multiplying 'number' by (i + 1).
        // Step 4: Assign the calculated multiple to result[i].
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        // Step 5: Return the populated array.
        return result;
    }

    /// <summary>
    /// Rotate the 'data' list to the right by the specified 'amount'.
    /// For example, if data is {1, 2, 3, 4, 5, 6, 7, 8, 9} and amount is 3,
    /// the end result should be {7, 8, 9, 1, 2, 3, 4, 5, 6}.
    /// </summary>
    /// <param name="data">The list of integers to rotate in-place</param>
    /// <param name="amount">The number of positions to rotate right (1 <= amount <= data.Count)</param>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Calculate the starting index of the split section that needs to move to the front.
        // The last 'amount' items start at index (data.Count - amount).
        int splitIndex = data.Count - amount;

        // Step 2: Slice the back portion of the list (from splitIndex to the end) using GetRange.
        List<int> backSlice = data.GetRange(splitIndex, amount);

        // Step 3: Remove that back portion from the original list using RemoveRange.
        data.RemoveRange(splitIndex, amount);

        // Step 4: Insert the sliced back portion at index 0 of the original list using InsertRange.
        data.InsertRange(0, backSlice);
    }
}