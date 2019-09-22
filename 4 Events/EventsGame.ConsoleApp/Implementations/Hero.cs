﻿using EventsGame.Core.Abstractions;

namespace EventsGame.ConsoleApp.Implementations
{
    class Hero : IHero
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
        private IBoard Board { get; set; }

        public void SetupHeroInitialPosition(int x, int y, IBoard board)
        {
            PosX = x;
            PosY = y;
            Board = board;
        }

        public void StartListenInput(IUserInteraction input)
        {
            input.InputReceived += OnInputReceived;
        }

        private void OnInputReceived(object sender, IGameEventArgs eventArgs)
        {
            switch (eventArgs.ReceivedCommand.Key)
            {
                case System.ConsoleKey.LeftArrow:
                    if (PosX != 1) PosX--;
                    break;

                case System.ConsoleKey.RightArrow:
                    if (PosX != Board.SizeX - 2) PosX++;
                    break;

                case System.ConsoleKey.UpArrow:
                    if (PosY != 1) PosY--;
                    break;

                case System.ConsoleKey.DownArrow:
                    if (PosY != Board.SizeY - 2) PosY++;
                    break;

                default:
                    break;
            }
        }
    }
}
