using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWar
{
    class PlayerShipMissilFactory : GameObjectFactory
    {
        public PlayerShipMissilFactory(GameSettings gameSettings) : base(gameSettings)
        { }

        public override GameObject GetGameObject(GameObjectPlace objectPlace)
        {
            GameObjectPlace missilePlace = new GameObjectPlace()
            {
                XCordinate = objectPlace.XCordinate,
                YCordinat = objectPlace.YCordinat - 1,
            };
            GameObject missile = new PlayerShipMissile()
            {
                Figure = GameSettings.PlayerMissile,
                GameObjectPlace = missilePlace,
                gameObjectTipe = GameObjectTipe.PlayerShipMissile
            };
            return missile;
        }
    }
}
