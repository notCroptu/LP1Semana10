using System;

namespace GuessTheNumber
{
    public interface IView
    {
        void WelcomePlayer();
        int AskForGuess();
        bool Congratulate();
        void TooLow();
        void TooHigh();
        void ThankPlayer();
    }
}