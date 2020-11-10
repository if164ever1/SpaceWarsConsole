using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpaceWar
{
    class Program
    {
        static GameEngine gameEngine;
        static GameSettings gameSettings;

        static UIController uIController;

        static void Main(string[] args)
        {
            Initialize();
            gameEngine.Run();
        }

        public static void Initialize()
        {
            gameSettings = new GameSettings();
            gameEngine = GameEngine.GetGameEngine(gameSettings);
            uIController = new UIController();
            uIController.OnAPressed += (obj, arg) => gameEngine.CalculateMovePlayerShipLeft();
            uIController.OnDPressed += (obj, arg) => gameEngine.CalculateMovePlayerShipRight();
            uIController.OnSpacePressed += (obj, arg) => gameEngine.Shot();

            Thread uIThread = new Thread(uIController.StartListening); // in other thread we loof fot push button A D
            uIThread.Start();



            Thread.CurrentThread.Priority = ThreadPriority.AboveNormal;

        }




    }
}
