using System;

namespace GuessTheNumber
{
    public class Model
    {
            Random random;
            int targetNumber;
            int Attempts { get; };

        public Model()
        {
            // Generate a random number
            random = new Random();

            // Generate a number between 1 and 100
            targetNumber = random.Next(1, 101);

            attempts = 0;
        }
        public IncrementAttempts()
        {
            Attempts++;
        }
        public int Get()
        {
            return targetNumber;
        }
    }
}