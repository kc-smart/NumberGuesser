using System;
using System.Collections.Generic;

namespace NumberGuesser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Welcome... \nI am a number guessing Wizard. ");

            //keep track of questions
            int questions = 0;
            //create list of numbers
            var numbers = new List<int>();
            //current guess
            int guess = 0;
            //player answer
            string answer = "";

            for (int i = 1; i < 1025; i++)
            {
                numbers.Add(i);
            }

            Console.WriteLine($"Please think of a number from {numbers[0]} to {numbers.Count}.\nI will guess your number by asking you a few questions.\n");


            do
            {
            //Select random number from list
            guess = randomGuess(numbers);

            //ask if higher, lower, or correct
            Console.WriteLine($"My guess is {guess}. Is your number higher, lower, or am I correct?");
            answer = Console.ReadLine();
            //ensure response is all lower before moving on
            answer.ToLower();

            if(answer == "higher"){
                removeLower(numbers, guess);
                //Status
                status(numbers, questions);
            }
            else if (answer == "lower"){
                removeHigher(numbers, guess);
                //Status
                status(numbers, questions);
            }
            else if(answer == "correct"){
                questions++;
                Console.WriteLine($"I correctly guessed your number in {questions} questions. Amazing!");
            }
            else{
                Console.WriteLine("Invalid response. Please enter higher, lower, or correct.");
            }
            } while (answer != "correct");
            

            Console.WriteLine("Thank you for playing.");
        

        }

        static int status(List<int> numbers, int questions){
            Console.WriteLine($"{numbers.Count} numbers remaining.");
            questions++;
            Console.WriteLine($"I have asked {questions} questions.");
            return questions;
        }

/* 
        public List<Int> removeEven(numbers){

            for(int i; i < numbers.length; i++){
                if(numbers[i] % 2 = 0){
                    number.RemoveAt(i);
                    i++;
                }
                else
                {
                    i++;
                }
            }

            return numbers;
        } 

        public List<Int> removeOdd(numbers){
            for(int i; i < numbers.length; i++){
                if(numbers[i] % 2 != 0){
                    number.RemoveAt(i);
                    i++;
                }
                else
                {
                     i++;
                }
            }

            return numbers;
        }
        */

        static int randomGuess(List<int> numbers){
            //draw random number from 1-1024 using guess var
            var rnd = new Random();
            int numIndex = rnd.Next(numbers.Count);
            //guess = numbers[numIndex];
            return numbers[numIndex];
        }

        static List<int> removeHigher(List<int> numbers, int guess){
            for(int i = guess; i < numbers.Count; i++){
                numbers.RemoveAt(i);
                    //i++;
            }

            return numbers;
        }

        static List<int> removeLower(List<int> numbers, int guess){
            for(int i = guess; i > -1; i--){
                numbers.RemoveAt(i);
                //i--;
            }

            return numbers;
        }

    }
}
