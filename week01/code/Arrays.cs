public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // So the code will get a number and the lenght as inputs, so if the user provides de number 3 and an lenght of 3
        // the output should be an array with the values 3, 6, 9.
        // To do this I will:
        // 1. I need to create an array of doubles with the length provided by the user.
        // 2. I will create a for loop that will iterate from 0 to length provided by the user
        // So it would be for int i = 0; while i is less then the length; i++
        // 3. Inside the for loop, the code will calculate the multiple of the number by multiplying it by (i + 1)
        // So it would be number * (i + 1) - The Plus one is necessary because i will begging as 0 not 1.
        // 4. Then the result will be stored in the array at the index of i since it's following the order 0, 1, 2, etc.
        // 5. After the loop is done, the code will return the array

        var multiplesArray = new double[length];

        for (int i = 0; i < length; i++)
        {
            multiplesArray[i] = number * (i + 1);
        }

        return multiplesArray; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Basically the code needs to move to the right the elements of a list the amount of times specified by the user.
        // To do this I will:
        // 1. Create a for loop
        // The for loop will be as follows: for int i = 0; while i is less than amount; i++
        // 2. Inside the for loop, the code will need to increment the indexes of the list to the right.
        // The only exception will be the last element of the list, which will need to have the index of 0.
        // For that I can remove the last element of the list and then add it to the start of the list.
        // 3. To remove the last element I will need to store it in a varible called lastElement.
        // 4. Then I will remove the last element from the list using data.RemoveAt(data.Count - 1);
        // The .Count counts the amount of elements in a list, so if we do the count and subtract 1 we will get the index of the last element.
        // 5. I will add the lastElement to the start of the list using data.Insert(0, lastElement);
        // 6. After the for loop is done, the list will be rotated.

        for (int i = 0; i < amount; i++)
        {
            int lastElement = data[data.Count - 1];
            data.RemoveAt(data.Count - 1);
            data.Insert(0, lastElement);
            // In C# when an list have "space" for a new element, no matter where you inset the element, the other elements from the right will move and do the indexes automatically change.
        }
    }
}
