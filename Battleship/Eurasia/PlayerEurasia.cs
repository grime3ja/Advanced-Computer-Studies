using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torpedo;

namespace Eurasia
{
    public class PlayerEurasia
    {
        private List<string> shotsAlreadyTaken = new List<string>();
        /* The NextMove() method is called every time the main program needs a torpedo shot from this player.
         * Locations in this game always start with a letter A - J, and are followed by a number 1 - 10.
         * This is where most of your "artificial intelligence" will come into play.  As an example, I have
         * coded the Eurasia player to have one of the worst possible targetting algorithms.  All it does is
         * pick a random valid square and shoot at it.  It doesn'te ven check to see if they have already
         * shot at this square. */
        public TorpedoShot NextMove()
        {
            TorpedoShot shot = new TorpedoShot();
            string stringShot = "";

            while (stringShot == "")
            {
                Random random = new Random();
                int row = random.Next(10);
                int column = random.Next(10) + 1;
                shot = new TorpedoShot(((char)('A' + row)).ToString(), column.ToString());
                stringShot = shot.Row + shot.Column;
                if (shotsAlreadyTaken.Contains(stringShot))
                    stringShot = "";
                else
                    shotsAlreadyTaken.Add(stringShot);
            }

            return shot;
        }

        /* The ResultOfShot() method must contain all the code you need to adjust your internal data
         * in response to the result of your latest shot. */
        public void ResultOfShot(TorpedoResult result)
        {

        }

        /* The Reset() method must contain all the code you need to prepare for a new game, including
         * resetting your internal data for a "rematch". */
        public void Reset()
        {

        }

        /* Ship locations are only valid if the ship is positioned horizontally or vertically.
         * This means that either all the letters in the position are constant (horizontal) or
         * all the numbers in the position are constant (vertical).  Furthermore, the sequential
         * information must be in order, from lowest to highest.  Finally, the string array
         * representing the position must be exactly the predefined size of the ship whose position
         * it is representing.  For instance:
         * 
         *      Submarine:  {"E5", "F5", "G5"}          // valid
         *      Submarine:  {"E5", "F5", "G6"}          // invalid
         *      Cruiser:    {"E5", "F5", "G5"}          // invalid
         *      Battleship: {"E5", "F5", "G5"}          // invalid
         *      Battleship: {"J6", "J7", "J8", "J9"}    // valid
         *      Battleship: {"J9", "J8", "J7", "J6"}    // invalid
         *      Destroyer:  {"K1", "L1"}                // valid
         *      Destroyer:  {"L1", "K1"}                // invalid
         */

        /* Return the location of your Aircraft Carrier */
        public string[] GetAircraftCarrier()
        {
            string[] ship = new string[5] { "F3", "F4", "F5", "F6", "F7" };
            return ship;
        }

        /* Return the location of your Battleship */
        public string[] GetBattleship()
        {
            string[] ship = new string[4] { "I7", "I8", "I9", "I10" };

            return ship;
        }

        /* Return the location of your Cruiser */
        public string[] GetCruiser()
        {
            string[] ship = new string[3] { "B5", "B6", "B7" };

            return ship;
        }

        /* Return the location of your Submarine */
        public string[] GetSubmarine()
        {
            string[] ship = new string[3] { "H6", "H7", "H8" };

            return ship;
        }

        /* Return the location of your Destroyer */
        public string[] GetDestroyer()
        {
            string[] ship = new string[2] { "D2", "D3" };

            return ship;
        }
    }
}