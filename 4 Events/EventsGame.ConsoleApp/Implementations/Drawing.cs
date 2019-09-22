using System;
using EventsGame.Core.Abstractions;

namespace EventsGame.ConsoleApp.Implementations
{
    class Drawing : IDrawing
    {
        private IBoard board;
        private IHero hero;

        public void SetupDrawing(IBoard board, IHero hero)
        {
            this.board = board;
            this.hero = hero;
        }

        public void StartListenInput(IUserInteraction input)
        {
            input.InputReceived += OnInputReceived;
        }

        private void OnInputReceived(object sender, IGameEventArgs eventArgs)
        {
            DrawAll();
        }

        public void DrawAll()
        {
            Console.Clear();

            DrawBoardWithRestrictions();
            DrawHero();
        }        

        private void DrawBoardWithRestrictions()
        {
            //corners
            WriteAt("+", 0, 0);
            WriteAt("+", 0, board.SizeY - 1);
            WriteAt("+", board.SizeX - 1, 0);
            WriteAt("+", board.SizeX - 1, board.SizeY - 1);
            //top line
            if (hero.PosY == 1)
                Console.ForegroundColor = ConsoleColor.Yellow;

            for (int x = 1; x < board.SizeX - 1; WriteAt("-", x++, 0));

            Console.ResetColor();
            //bottom line
            if (hero.PosY == board.SizeY - 2)
                Console.ForegroundColor = ConsoleColor.Yellow;

            for (int x = 1; x < board.SizeX - 1; WriteAt("-", x++, board.SizeY - 1));

            Console.ResetColor();
            //left line
            if (hero.PosX == 1)
                Console.ForegroundColor = ConsoleColor.Yellow;

            for (int y = 1; y < board.SizeY - 1; WriteAt("|", 0, y++));

            Console.ResetColor();
            //right line
            if (hero.PosX == board.SizeX - 2)
                Console.ForegroundColor = ConsoleColor.Yellow;

            for (int y = 1; y < board.SizeY - 1; WriteAt("|", board.SizeX - 1, y++));
            
            Console.ResetColor();

            Console.WriteLine();
        }

        private void DrawHero()
        {
            int currentRow = Console.CursorTop;
            WriteAt("+", hero.PosX, hero.PosY);
            Console.SetCursorPosition(0, currentRow);
        }
        
        private static void WriteAt(string s, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(s);
        }

    }
}
