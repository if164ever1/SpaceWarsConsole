using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWar
{
    class GroundFactory:GameObjectFactory
    {
        public GroundFactory(GameSettings gameSettings) : base(gameSettings)
        {
        }

        /// <summary>
        /// Make a AlianShip
        /// </summary>
        /// <param name="objectPlace"></param>
        /// <returns></returns>
        public override GameObject GetGameObject(GameObjectPlace objectPlace)
        {
            GroundObject groundObject = new GroundObject()
            {
                Figure = GameSettings.Ground,
                GameObjectPlace = objectPlace,
                gameObjectTipe = GameObjectTipe.GroundObject
            };
            return groundObject;
        }

        public List<GameObject> GetGround()
        {
            List<GameObject> ground = new List<GameObject>();
            int startX = GameSettings.GroundStartXCordinat;
            int startY = GameSettings.GroundStartYCordinat;

            for (int y = 0; y < GameSettings.NumbersOfGroundRows; y++)
            {
                for (int x = 0; x < GameSettings.NumbersOfGroundColls; x++)
                {
                    GameObjectPlace objectPlace = new GameObjectPlace() { XCordinate = startX + x, YCordinat = startY + y };
                    GameObject groundObject = GetGameObject(objectPlace);
                    ground.Add(groundObject);
                }
            }

            return ground;
        }

    }
}

