using System;
using System.Collections.Generic;

namespace PlayerManager4
{
    /// <summary>
    /// The player listing Controller.
    /// </summary>
    public class Controller
    {
        /// The list of all players
        private readonly List<Player> playerList;

        // Comparer for comparing player by name (alphabetical order)
        private readonly IComparer<Player> compareByName;

        // Comparer for comparing player by name (reverse alphabetical order)
        private readonly IComparer<Player> compareByNameReverse;
        private IView view;

        /// <summary>
        /// Creates a new instance of the player listing Controller.
        /// </summary>
        public Controller(IView view)
        {
            // Initialize player comparers
            compareByName = new CompareByName(true);
            compareByNameReverse = new CompareByName(false);

            view.this = view;
        }

        /// <summary>
        /// Start the player listing Controller instance
        /// </summary>
        private void Start()
        {
            // We keep the user's option here
            int option;

            // Main Controller loop
            do
            {
                // Show menu and get user option
                option = view.ShowMenu();

                // Determine the option specified by the user and act on it
                switch (option)
                {
                    case 1:
                        // Insert player
                        InsertPlayer();
                        break;
                    case 2:
                        ListPlayers(playerList);
                        break;
                    case 3:
                        ListPlayersWithScoreGreaterThan();
                        break;
                    case 4:
                        SortPlayerList();
                        break;
                    case 0:
                        view.EndMessage();
                        break;
                    default:
                        view.InvalidOption();
                        break;
                }

                view.AfterMenu();

                // Loop keeps going until players choses to quit (option 4)
            } while (option != "0");
        }

        /// <summary>
        /// Inserts a new player in the player list.
        /// </summary>
        private void InsertPlayer()
        {
            // Create new player and add it to list
            Player newPlayer = view.InsertPlayer();
            playerList.Add(newPlayer);
        }

        /// <summary>
        /// Show all players in a list of players. This method can be static
        /// because it doesn't depend on anything associated with an instance
        /// of the Controller. Namely, the list of players is given as a parameter
        /// to this method.
        /// </summary>
        /// <param name="playersToList">
        /// An enumerable object of players to show.
        /// </param>
        private static void ListPlayers(IEnumerable<Player> playersToList)
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

        /// <summary>
        /// Show all players with a score higher than a user-specified value.
        /// </summary>
        private void ListPlayersWithScoreGreaterThan()
        {
            // Minimum score user should have in order to be shown
            int minScore;
            // Enumerable of players with score higher than the minimum score
            IEnumerable<Player> playersWithScoreGreaterThan;

            // Ask the user what is the minimum score
            minScore = view.AskForMinScore();

            // Get players with score higher than the user-specified value
            playersWithScoreGreaterThan =
                GetPlayersWithScoreGreaterThan(minScore);

            // List all players with score higher than the user-specified value
            ListPlayers(playersWithScoreGreaterThan);
        }

        /// <summary>
        /// Get players with a score higher than a given value.
        /// </summary>
        /// <param name="minScore">Minimum score players should have.</param>
        /// <returns>
        /// An enumerable of players with a score higher than the given value.
        /// </returns>
        private IEnumerable<Player> GetPlayersWithScoreGreaterThan(int minScore)
        {
            // Cycle all players in the original player list
            foreach (Player p in playerList)
            {
                // If the current player has a score higher than the
                // given value....
                if (p.Score > minScore)
                {
                    // ...return him as a member of the player enumerable
                    yield return p;
                }
            }
        }

        /// <summary>
        ///  Sort player list by the order specified by the user.
        /// </summary>
        private void SortPlayerList()
        {
            PlayerOrder playerOrder;

            playerOrder = view.AskForPlayerOrder();

            switch (playerOrder)
            {
                case PlayerOrder.ByScore:
                    playerList.Sort();
                    break;
                case PlayerOrder.ByName:
                    playerList.Sort(compareByName);
                    break;
                case PlayerOrder.ByNameReverse:
                    playerList.Sort(compareByNameReverse);
                    break;
                default:
                    view.InvalidOption();
                    break;
            }
        }
    }
}
