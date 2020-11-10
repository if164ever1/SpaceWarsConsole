using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWar
{
    class SceneRender
    {
        int _screenWidth;
        int _screenHeight;

        char[,] _screenMatrix;

        public SceneRender(GameSettings gameSettings)
        {
            _screenWidth = gameSettings.ConsoleWidth;
            _screenHeight = gameSettings.ConsoleHeight;
            _screenMatrix = new char[gameSettings.ConsoleHeight, gameSettings.ConsoleWidth];

            //set parametrs for console
            Console.WindowHeight = gameSettings.ConsoleHeight;
            Console.WindowWidth = gameSettings.ConsoleWidth;

            Console.CursorVisible = false; // видимість курсора
            Console.SetCursorPosition(0, 0); //початкова позиція курсора
        }

        public void Render(Scene scene)
        {
            //Console.Clear();
            ClearScreen();

            Console.SetCursorPosition(0,0);

            //add items
            AddListForRendering(scene._swarm);
            AddListForRendering(scene._ground);
            AddListForRendering(scene._playerShipMissile);

            AddGameObjectForRendering(scene._playerShip);

            StringBuilder stringBuilder = new StringBuilder();
            for (int y = 0; y < _screenHeight; y++)
            {
                for (int x = 0; x < _screenWidth; x++)
                {
                    stringBuilder.Append(_screenMatrix[y,x]);
                }

                stringBuilder.Append(Environment.NewLine); // move to new string
            }
            Console.WriteLine(stringBuilder.ToString());
            Console.SetCursorPosition(0, 0);
        }

        public void AddGameObjectForRendering(GameObject gameObject) //method adding one object to console
        {
            //робим перевірку чи не виходим за границю матриці
            if (gameObject.GameObjectPlace.YCordinat < _screenMatrix.GetLength(0) &&
                gameObject.GameObjectPlace.XCordinate < _screenMatrix.GetLength(1))
            {
                _screenMatrix[gameObject.GameObjectPlace.YCordinat, gameObject.GameObjectPlace.XCordinate] = gameObject.Figure;
            }
            else 
            {
                //_screenMatrix[gameObject.GameObjectPlace.YCordinat, gameObject.GameObjectPlace.XCordinate] = ' ';
            }
        }

        public void AddListForRendering(List<GameObject> gameObjects) //method for adding 
        {
            foreach (GameObject gameObject in gameObjects)
            {
                AddGameObjectForRendering(gameObject);
            }
        }

        public void ClearScreen()
        {
            for (int y = 0; y < _screenHeight; y++)
            {
                for (int x = 0; x < _screenWidth; x++)
                {
                    _screenMatrix[y, x] = ' ';
                }
            }
            Console.SetCursorPosition(0, 0);

        }

        public void RenderGameOwer()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Game OWER");
            Console.WriteLine(stringBuilder.ToString());
        }
    }
}
