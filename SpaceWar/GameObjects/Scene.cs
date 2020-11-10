using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWar
{
    class Scene
    {
        public List<GameObject> _swarm;
        public List<GameObject> _ground;
        public GameObject _playerShip;
        public List<GameObject> _playerShipMissile;
        public GameSettings _gameSettings;
        private static Scene _scene;

        private Scene(GameSettings gameSettings)
        {
            _gameSettings = gameSettings;
            _swarm = new AlianShipFactory(_gameSettings).GetSwarm();
            _ground = new GroundFactory(_gameSettings).GetGround();
            _playerShip = new PlayerShipFactori(_gameSettings).GetGameObject();
            _playerShipMissile = new List<GameObject>();
        }

        public static Scene getScene(GameSettings gameSettings)
        {
            if (_scene == null)
            {
                _scene = new Scene(gameSettings);
                //return _scene;
            }
            return _scene;
        }

        

    }
}
