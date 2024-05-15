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
        public Controller(List<Player> players)
        {
            playerList = players;
            // Initialize player comparers
            compareByName = new CompareByName(true);
            compareByNameReverse = new CompareByName(false);
        }

        /// <summary>
        /// Start the player listing Controller instance
        /// </summary>
        public void Start(IView newView)
        {
            view = newView;
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
                        view.ListPlayers(playerList);
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
            } while (option != 0);
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
            view.ListPlayers(playersWithScoreGreaterThan);
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
            PlayerOrder playerOrder = view.AskForPlayerOrder();

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
