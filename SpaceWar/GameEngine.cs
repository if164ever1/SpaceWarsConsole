using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpaceWar
{
    class GameEngine
    {
        private static GameEngine _gameEngine;

        private bool _isNotOwer;

        private SceneRender _sceneRender;
        private GameSettings _gameSettings;
        private Scene _scene;
        private GameEngine()
        {
        }

        public static GameEngine GetGameEngine(GameSettings gameSettings)
        {
            if (_gameEngine == null)
            {
                _gameEngine = new GameEngine(gameSettings);
            } 
            return _gameEngine;
        }

        private GameEngine(GameSettings gameSettings)
        {
            _gameSettings = gameSettings;
            _isNotOwer = true;
            _scene = Scene.getScene(gameSettings);
            _sceneRender = new SceneRender(gameSettings);
        }

        public void Run()
        {
            int swarmMobeCounter = 0;
            int playerMissileCounter = 0;
            do
            {
                _sceneRender.Render(_scene);
                Thread.Sleep(_gameSettings.GameSpeed); // частота оновлення
                _sceneRender.ClearScreen();

                if (swarmMobeCounter == _gameSettings.SwarmSpeed)
                {
                    CalculateSwarmMove();
                    swarmMobeCounter = 0;
                }
                swarmMobeCounter++;

                if (playerMissileCounter == _gameSettings.PlayerMisileSpeed)
                {
                    CalculateMissileMove();
                    playerMissileCounter = 0;
                }
                playerMissileCounter++;

            } while (_isNotOwer);
            Console.ForegroundColor = ConsoleColor.Red;
            _sceneRender.RenderGameOwer();
        }

        public void CalculateMovePlayerShipLeft()
        {
            if (_scene._playerShip.GameObjectPlace.XCordinate > 1)
            {
                _scene._playerShip.GameObjectPlace.XCordinate--;
            }
        }
        public void CalculateMovePlayerShipRight()
        {
            if (_scene._playerShip.GameObjectPlace.XCordinate < _gameSettings.ConsoleWidth)
            {
                _scene._playerShip.GameObjectPlace.XCordinate++;
            }
        }

        public void CalculateSwarmMove()
        {
            for (int i = 0; i < _scene._swarm.Count; i++)   //_scene._swarm.Count - max value of this ships
            {
                GameObject alienShip = _scene._swarm[i];
                alienShip.GameObjectPlace.YCordinat++;
                if (alienShip.GameObjectPlace.YCordinat == _scene._playerShip.GameObjectPlace.YCordinat)
                {
                    _isNotOwer = false;
                }
                
            }
        }


        public void Shot()
        {
            PlayerShipMissilFactory playerShipMissilFactory = new PlayerShipMissilFactory(_gameSettings);
            GameObject missile = playerShipMissilFactory.GetGameObject(_scene._playerShip.GameObjectPlace);

            _scene._playerShipMissile.Add(missile);
            //Console.Beep(1000, 200);
        }

        public void CalculateMissileMove()
        {
            if (_scene._playerShipMissile.Count == 0) { return; }

            for (int x = 0; x < _scene._playerShipMissile.Count; x++)
            {
                GameObject missile = _scene._playerShipMissile[x];

                if (missile.GameObjectPlace.YCordinat == 1)
                {
                    _scene._playerShipMissile.RemoveAt(x);
                }

                missile.GameObjectPlace.YCordinat--;

                for (int i = 0; i < _scene._swarm.Count; i++)
                {
                    GameObject alianship = _scene._swarm[i];
                    if (missile.GameObjectPlace.Equals(alianship.GameObjectPlace))
                    {
                        _scene._swarm.RemoveAt(i);
                        _scene._playerShipMissile.RemoveAt(x);
                        break;
                    }
                }
            }
        }
    }
}
