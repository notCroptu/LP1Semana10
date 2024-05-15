using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerManager4
{
    public class UglyView : IView
    {
        public int MainMenu()
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
        void InvalidOption()
        {
            Console.Error.WriteLine("\n>>> Unknown option! <<<\n");
        }
        void AfterMenu()
        {
            // Wait for user to press a key...
            Console.Write("\nPress any key to continue...");
            Console.ReadKey(true);
            Console.WriteLine("\n");
        }
        Player InsertPlayer()
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
        int AskForMinScore(int score)
        {
            Console.Write("\nMinimum score player should have? ");
            return Convert.ToInt32(Console.ReadLine());
        }
        PlayerOrder AskForPlayerOrder();
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
    }
}