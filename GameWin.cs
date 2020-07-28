using System;
using System.Windows;

namespace MemoryGame
{
    internal class GameWin
    {
        public GameWin()
        {
        }

        public static implicit operator Window(GameWin v)
        {
            MessageBox.Show("Felicitari! Ai gasit toate perechile!");
            return null;
        }

        internal void Show()
        {
            
        }
    }
}