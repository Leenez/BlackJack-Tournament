using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackTounamentClasses
{
    public class CPlayerList
    {   
        /// <summary>
        /// Inex used to track the next player in turn and list for tournament players.
        /// </summary>
        public int ListIndex { get; set; } = 0;
        private List<CPlayer> TournamentPlayers { get; set; } = new List<CPlayer>();
        
        /// <summary>
        /// Add new player to the list.
        /// </summary>
        /// <param name="Name">Name of the player.</param>
        /// <param name="Chips">Amount of chips for the player.</param>
        public void AddPlayer(string Name, int Chips)
        {
            TournamentPlayers.Add(new CPlayer(Name, Chips));
        }

        /// <summary>
        /// Get the next player in turn. If there are no more players, then null value is returned.
        /// </summary>
        /// <returns>CPlayer object or null if list has no more players.</returns>
        public CPlayer GetNextPlayer()
        {
            try
            {
                return TournamentPlayers[ListIndex];
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                ListIndex += 1;
            }
        }
    }
}
