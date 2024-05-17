using System;

namespace GuessTheNumber
{
    public class View
    {
        private readonly Controller controller;
        private readonly Model model;

        public UglyView(Controller controller, Model model)
        {
            this.controller = controller;
            this.model = model;
        }
        public void WelcomePlayer()
        {
            Console.WriteLine("Welcome to Guess the Number!");
            Console.WriteLine("I have chosen a number between 1 and 100.");
        }
        public int AskForGuess()
        {
            Console.Write("Take a guess: ");
            return Convert.ToInt32(Console.ReadLine());
        }
        public bool Congratulate()
        {
            Console.WriteLine(
                "Congratulations! You guessed the number correctly!");
            Console.WriteLine("Number of attempts: " + model.Get());
            return true;
        }
        public void TooLow()
        {
            Console.WriteLine("Too low! Try again.");
        }
        public void TooHigh()
        {
            Console.WriteLine("Too high! Try again.");
        }
        public void ThankPlayer()
        {
            Console.WriteLine("Thank you for playing Guess the Number!");
        }
    }
}