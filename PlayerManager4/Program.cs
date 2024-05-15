using System;

namespace PlayerManager4
{
    public class Player : IComparable<Player>
    {
        private static void Main(string[] args)
        {
            playerList = new List<Player>() {
                new Player("Best player ever", 100),
                new Player("An even better player", 500)
            };
            IView view = new UglyView();
            // Create a new instance of the player listing Controller
            Controller controller = new Controller();
            // Start the Controller instance
            controller.Start();
        }
    }
}