using Delegates.Core.Abstractions;

namespace Delegates.ConsoleApp.Implementations
{
    public class Board : IBoard
    {
        public int BoardSizeX { get; set; }
        public int BoardSizeY { get; set; }

        public void SetBoardSize(int x, int y)
        {
            BoardSizeX = x;
            BoardSizeY = y;
        }
    }
}
