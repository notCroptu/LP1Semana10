using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerManagerMVC
{
    public class UglyView : IView
    {
        private readonly Controller controller;
        private readonly List<Player> players;

        public UglyView(Controller controller, List<Player> players)
        {
            this.controller = controller;
            this.players = players;
        }
        public int ShowMenu()
        {
            Console.WriteLine("Menu");
            Console.WriteLine("----\n");
            Console.WriteLine("1. Insert player");
            Console.WriteLine("2. List all players");
            Console.WriteLine("3. List players with score greater than");
            Console.WriteLine("4. Sort players");
            Console.WriteLine("0. Quit\n");
            Console.Write("Your choice > ");

            return int.Parse(Console.ReadLine());
        }
        public void EndMessage()
        {
            Console.WriteLine("\nBye!\n");
        }
        public void InvalidOption()
        {
            Console.Error.WriteLine("\n>>> Unknown option! <<<\n");
        }
        public void AfterMenu()
        {
            // Wait for user to press a key...
            Console.Write("\nPress any key to continue...");
            Console.ReadLine();
            Console.WriteLine("\n");
        }
        public Player InsertPlayer()
        {
            // Variables
            string name;
            int score;

            // Ask for player info
            Console.WriteLine("\nInsert player");
            Console.WriteLine("-------------\n");
            Console.Write("Name: ");
            name = Console.ReadLine();
            Console.Write("Score: ");
            score = Convert.ToInt32(Console.ReadLine());

            // Create new player and add it to list
            return new Player(name, score);
        }
        public int AskForMinScore()
        {
            Console.Write("\nMinimum score player should have? ");
            return Convert.ToInt32(Console.ReadLine());
        }
        public PlayerOrder AskForPlayerOrder()
        {
            Console.WriteLine("Player order");
            Console.WriteLine("------------");
            Console.WriteLine(
                $"{(int)PlayerOrder.ByScore}. Order by score");
            Console.WriteLine(
                $"{(int)PlayerOrder.ByName}. Order by name");
            Console.WriteLine(
                $"{(int)PlayerOrder.ByNameReverse}. Order by name (reverse)");
            Console.WriteLine("");
            Console.Write("> ");

            return Enum.Parse<PlayerOrder>(Console.ReadLine());
        }
        public void ListPlayers(IEnumerable<Player> playersToList)
        {
            Console.WriteLine("\nList of players");
            Console.WriteLine("-------------\n");

            // Show each player in the enumerable object
            foreach (Player p in playersToList)
            {
                Console.WriteLine($" -> {p.Name} with a score of {p.Score}");
            }
            Console.WriteLine();
        }
    }
}