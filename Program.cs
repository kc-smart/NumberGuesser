using System;
using System.Collections.Generic;

namespace NumberGuesser
{
    class Program
    {
        static void Main(string[] args)
        {
            greeting();


            //keep track of questions
            int questions = 0;
            //create list of numbers
            var numbers = new List<int>();
            //current guess
            int guess = 0;
            //player answer
            string answer = "";
            //keep track of number of games
            int numberOfGames = 0;
            //keep track of average guesses
            //int averageGuesses = 0;

            createList(numbers);

            Console.WriteLine($"Please think of a number from {numbers[0]} to {numbers.Count}.\nI will guess your number by asking you a few questions.\n");

            //gamePlay();

            do
            {
                numberOfGames++;
                //Select random number from list
                guess = randomGuess(numbers);

                //ask if higher, lower, or correct
                Console.WriteLine($"My guess is {guess}. Is your number higher, lower, or am I correct?");

            top:
                answer = Console.ReadLine();

                //ensure response is all lower before moving on
                answer.ToLower();

                questions++;

                if (answer == "higher")
                {
                    removeLower(numbers, guess);
                    //Status
                    status(numbers, questions);
                }
                else if (answer == "lower")
                {
                    removeHigher(numbers, guess);
                    //Status
                    status(numbers, questions);
                }
                else if (answer == "correct")
                {
                    Console.WriteLine($"I correctly guessed your number in {questions} tries. Amazing!");
                }
                else
                {
                    Console.WriteLine("Invalid response. Please enter higher, lower, or correct.");
                    goto top;
                }
            } while (answer != "correct");


            endOfGame();


        }

        static void greeting()
        {
            Console.Write("Welcome... \nI am a number guessing Wizard. ");
        }

        static List<int> createList(List<int> numbers)
        {
            for (int i = 1; i < 1025; i++)
            {
                numbers.Add(i);
            }

            return numbers;
        }

        /*
        gamePlay(){
            do
            {
            numberOfGames++;
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
        }
         */

        static int randomGuess(List<int> numbers)
        {
            //draw random number from 1-1024 using guess var
            var rnd = new Random();
            int numIndex = rnd.Next(numbers.Count);
            return numbers[numIndex];
        }

        static List<int> removeHigher(List<int> numbers, int guess)
        {
            Console.WriteLine($"I will now remove all numbers at and above {guess}");

            int range = numbers.Count - guess;
            int min = guess - 1;

            numbers.RemoveRange(min, range);

            return numbers;
        }

        static List<int> removeLower(List<int> numbers, int guess)
        {
            Console.WriteLine($"I will now remove all numbers at and below {guess}");

            numbers.RemoveRange(0, guess);

            return numbers;
        }

        static void status(List<int> numbers, int questions)
        {
            Console.WriteLine(numbers.Count + " numbers remaining.");
            Console.WriteLine($"I have asked {questions} questions.");
        }

        static void endOfGame()
        {
            Console.WriteLine("Thank you for playing. Would you like to play again?\n");

        top:
            string playAgain = Console.ReadLine();

            //ensure response is all lower before moving on
            playAgain.ToLower();

            if (playAgain == "yes")
            {
                Console.WriteLine("We need to figure this out!");
            }
            else if (playAgain == "no")
            {
                Console.WriteLine("Come back soon!");
            }
            else
            {
                Console.WriteLine("Invalid response. Please enter yes or no.");
                goto top;
            }
        }

    }
}
