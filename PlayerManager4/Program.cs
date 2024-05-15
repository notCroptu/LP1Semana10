using System;
using System.Collections.Generic;

namespace PlayerManager4
{
    public class Program
    {
        private static void Main(string[] args)
        {
            List<Player> playerList = new List<Player>() {
                new Player("Best player ever", 100),
                new Player("An even better player", 500)
            };

            // Create a new instance of the player listing Controller
            Controller controller = new Controller(playerList);

            IView view = new UglyView(controller, playerList);

            // Start the Controller instance
            controller.Start(view);
        }
    }
}