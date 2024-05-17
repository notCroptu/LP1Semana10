using System;

namespace GuessTheNumber
{
    public class Program
    {
        private static void Main()
        {
            Model newRandom = new Model();

            // Create a new instance of the player listing Controller
            Controller controller = new Controller(newRandom);

            IView view = new View(controller, newRandom);

            // Start the Controller instance
            controller.Start(view);
        }
    }
}