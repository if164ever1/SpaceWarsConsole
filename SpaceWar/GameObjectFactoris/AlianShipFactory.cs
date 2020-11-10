using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWar
{
    class AlianShipFactory : GameObjectFactory
    {
        public AlianShipFactory(GameSettings gameSettings):base(gameSettings)
        { 
        }

        /// <summary>
        /// Make a AlianShip
        /// </summary>
        /// <param name="objectPlace"></param>
        /// <returns></returns>
        public override GameObject GetGameObject(GameObjectPlace objectPlace)
        {
            GameObject alianship = new AlianShip()
            {
                Figure = GameSettings.AlienShip,
                GameObjectPlace = objectPlace,
                gameObjectTipe = GameObjectTipe.AlianShip
            };
            return alianship;
        }

        public List<GameObject> GetSwarm()
        {
            List<GameObject> swarm = new List<GameObject>();
            int startX = GameSettings.SwarmStartXCordinat;
            int startY = GameSettings.SwarmStartYCordinat;

            for (int y = 0; y < GameSettings.NumbersOfSwarmsRows; y++)
            {
                for (int x = 0; x < GameSettings.NumbersOfSwarmColls; x++)
                {
                    GameObjectPlace objectPlace = new GameObjectPlace() { XCordinate = startX + x, YCordinat = startY + y };
                    GameObject alienShip = GetGameObject(objectPlace);
                    swarm.Add(alienShip);
                }
            }

            return swarm;
        }

    }
}
