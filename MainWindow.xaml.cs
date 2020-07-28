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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MemoryGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()

        {
            //var image = new Image { Source = "C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/memory.jpg" };
            InitializeComponent();

        }

        private void ButtonExisting_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.Show();
            this.Hide();
        }

        private void ButtonNew_Click(object sender, RoutedEventArgs e)
        {
            RegisterUser window2 = new RegisterUser();
            window2.Show();
            this.Hide();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonPlay_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Va rog sa va autentificati");
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
