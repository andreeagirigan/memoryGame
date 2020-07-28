using System;
using System.Windows;

namespace MemoryGame
{
    internal class GameOver
    {
        public static implicit operator Window(GameOver v)
        {

            MessageBox.Show("Timpul a expirat");
            WindowPlay window = new WindowPlay();
            window.Show();
            return null;

        }

        internal void Show()
        {
            
        }
    }
}