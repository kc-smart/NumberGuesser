using System;
using System.Collections.Generic;

namespace NumberGuesser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Welcome... \nI am a number guessing Wizard. ");

            //keep track of guesses
            int guesses = 0;
            //create list of numbers
            var numbers = new List<int>();

            for (int i = 1; i < 1025; i++)
            {
                numbers.Add(i);
            }

            Console.WriteLine($"Please think of a number from {numbers[0]} to {numbers.Count}.\n");

            //Loop
            //Question
            //Answer
            //Remove opposite
            //increment guesses

            //Even or odd -> removes half (512)


            //Greater than 512 -> remove another half (256)


            //Divisible by 3 -> ~16% left (~41)



            //Final question (guess)
            Console.WriteLine($"Is your number {numbers[0]}?");

        }



    }
}
