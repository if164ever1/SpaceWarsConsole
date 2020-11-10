using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWar
{
    class GameSettings
    {
        public int ConsoleWidth { get; set; } = 80;
        public int ConsoleHeight { get; set; } = 30;
        /*-----------------------------------------*/
        public int NumbersOfSwarmsRows { get; set; } = 2;
        public int NumbersOfSwarmColls { get; set; } = 50;
        /*------------------------------------------*/
        public int SwarmStartXCordinat { get; set; } = 10;
        public int SwarmStartYCordinat { get; set; } = 2;
        /*------------------------------------------*/
        public char AlienShip { get; set; } = '*';
        public int SwarmSpeed { get; set; } = 20;
        /*------------------------------------------*/


        public int PlayerShipStartXCordinat { get; set; } = 40;
        public int PlayerShipStartYCordinat { get; set; } = 15;
        public char PlayerShip { get; set; } = '^';
        /*--------------------------------------------*/

        public int GroundStartXCordinat { get; set; } = 1;
        public int GroundStartYCordinat { get; set; } = 20;
        public char Ground { get; set; } = '~';
        public int NumbersOfGroundRows { get; set; } = 3;
        public int NumbersOfGroundColls { get; set; } = 80;
        /*--------------------------------------------*/

        public char PlayerMissile { get; set; } = '\'';
        public int PlayerMisileSpeed { get; set; } = 10;

        public int GameSpeed { get; set; } = 70;
    }
}
