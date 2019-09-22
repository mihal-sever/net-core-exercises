using System;
using EventsGame.Core.Abstractions;

namespace EventsGame.Core
{
    public class GameLogic
    {
        public void Run(IRegistry registry)
        {
            Console.CursorVisible = false;

            registry.Board.SetupBoardSize(20, 10);
            registry.Hero.SetupHeroInitialPosition(10, 5, registry.Board);
            registry.Drawing.SetupDrawing(registry.Board, registry.Hero);

            registry.Drawing.DrawAll();

            registry.Hero.StartListenInput(registry.UserInteraction);
            registry.Drawing.StartListenInput(registry.UserInteraction);
            registry.UserInteraction.StartListening();
        }
    }
}
