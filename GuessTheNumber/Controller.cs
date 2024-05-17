using System;

namespace GuessTheNumber
{
    public class Controller
    {
        private Model model;
        private IView view;
        public Controller(Model model)
        {
            this.model = model;
        }
        public Start(IView newView)
        {
            view = newView;

            int guess;
            bool guessedCorrectly = false;

            view.WelcomePlayer();

            // Game loop
            while (!guessedCorrectly)
            {
                guess = view.AskForGuess();
                model.IncrementAttempts();

                if (guess == model.Get())
                {
                    guessedCorrectly = view.Congratulate();
                }
                else if (guess < model.Get())
                {
                    view.TooLow();
                }
                else
                {
                    view.TooHigh();
                }
            }

            view.ThankPlayer();
        }
    }
}