using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MemoryGame
{
    /// <summary>
    /// Interaction logic for WindowPlay.xaml
    /// </summary>
    public partial class WindowPlay : Window
    {
        public WindowPlay()
        {
            InitializeComponent();
        }

        private void Button_ClickIncepator(object sender, RoutedEventArgs e)
        {
            Beginner window1 = new Beginner();
            window1.Show();
            this.Hide();
        }

        private void Button_ClickMediu(object sender, RoutedEventArgs e)
        {
            Intermediate window2 = new Intermediate();
            window2.Show();
            this.Hide();
        }

        private void Button_ClickAvansat(object sender, RoutedEventArgs e)
        {

        }
        private void Button_ClickHelp(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Andreea Girigan, Grupa 10ID561");
        }
        private void Button_ClickBack(object sender, RoutedEventArgs e)
        {
            MainWindow window4 = new MainWindow();
            window4.Show();
            this.Hide();
        }

    }
}
