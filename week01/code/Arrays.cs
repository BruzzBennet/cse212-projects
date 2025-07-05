using System.Diagnostics;
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

        //first off, I have to get the values from the function
        double num = number;
        int len = length;
        int j = 1;
        var list = new double[len];
        //then, I have to make the for function to do the function as many times as the length
        for (int i = 0; i < len; i++)
        {
            //then, I have to think how to get the multiples of a number. This is easier said than done
            //Wait, maybe it isn't as hard as I thought
            //Basically, I just need to create a j value that's i but +1. 
            //Then, I need to multiply j with num and add it to a list
            //I should first create that list, and make its length be len
            list[i] = num * j;
            j++;
        }

        //And finally, I need to return that list
        return list; // replace this return statement with your own
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

        //We don't need to create new local variables to do this, but
        //first, we get how long the initial list is
        int count = data.Count;

        //then, we'll create a new list (new_list) that'll have those numbers 
        //to do it, we start by finding the index to start from (index_to_find)
        //which is found in the spot (amount) before from the list's end (count) 
        int  index_to_find  = count - amount;
        // then, we'll find the 'amount' of numbers that we have to get after said index 
        int amount_of_numbers = amount;
        //and we create the first part of the new list by starting from that index and getting the rest of the numbers
        var new_list = data.GetRange(index_to_find, amount_of_numbers);

        //Then, we get the OTHER rest of the numbers by searching the amount BEFORE the mentioned index
        //This is done by starting from the first index (0), and the numbers before the mentioned
        //index (index_to_find)
        new_list.AddRange(data.GetRange(0, index_to_find));

        //Then, we replace the initial list with the new list
        data.RemoveRange(0, count);
        data.AddRange(new_list.GetRange(0,count));
    }
}
