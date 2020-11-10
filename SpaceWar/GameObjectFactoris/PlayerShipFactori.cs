using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWar
{
    class PlayerShipFactori : GameObjectFactory
    {

        public PlayerShipFactori(GameSettings gameSettings):base(gameSettings)
        { 
        }

        public override GameObject GetGameObject(GameObjectPlace objectPlace)
        {
            
            GameObject gameObject = new PlayerShip()
            { 
                Figure = GameSettings.PlayerShip, 
                GameObjectPlace = objectPlace, 
                gameObjectTipe = GameObjectTipe.PlayerShip
            };
            return gameObject;

        }

        public GameObject GetGameObject()
        {
            GameObjectPlace gameObjectPlace = new GameObjectPlace()
            {
                XCordinate = GameSettings.PlayerShipStartXCordinat,
                YCordinat = GameSettings.PlayerShipStartYCordinat
            };
            GameObject gameObject = GetGameObject(gameObjectPlace);
            return gameObject; 
        }
    }
}
