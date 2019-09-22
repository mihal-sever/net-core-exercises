using System;
using Delegates.Core.Abstractions;

namespace Delegates.ConsoleApp.Implementations
{
    public class ProcessUserInput : IProcessUserInput
    {
        public int SelectMenuItem()
        {
            int selectedItem;
            try
            {
                selectedItem = int.Parse(Console.ReadLine());
            }
            catch
            {
                selectedItem = -1;
            }
            return selectedItem;
        }

        public void QuitGame()
        {
            Environment.Exit(0);
        }
    }
}
