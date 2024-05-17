using System;

namespace GuessTheNumber
{
    public class Model
    {
        private Random random;
        private int targetNumber;
        public int Attempts { get; private set; }

        public Model()
        {
            // Generate a random number
            random = new Random();

            // Generate a number between 1 and 100
            targetNumber = random.Next(1, 101);

            Attempts = 0;
        }
        public void IncrementAttempts()
        {
            Attempts++;
        }
        public int Get()
        {
            return targetNumber;
        }
    }
}