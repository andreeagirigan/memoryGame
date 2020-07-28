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
using System.Windows.Threading;

namespace MemoryGame
{

    public partial class Beginner : Window
    {

        int playTime = 60;
        DispatcherTimer Timer;
        DispatcherTimer turnImageTime;
        DispatcherTimer gameTime;
        Image turnCardImage1;
        Image turnCardImage2;
        int showCardsTime = 3;

        Thickness[] buttonsMargins = new Thickness[16];
        public Beginner()
        {
            InitializeComponent();

            Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Tick += Timer_Tick;
            Timer.Start();

            turnImageTime = new DispatcherTimer();
            turnImageTime.Interval = new TimeSpan(0, 0, 0, 0, 500);
            turnImageTime.Tick += turnImageTime_Tick;

            gameTime = new DispatcherTimer();
            gameTime.Interval = new TimeSpan(0, 0, 1);
            gameTime.Tick += gameTime_Tick;


            int i = 0;
            foreach (Button btn in FindVisualChildren<Button>(imageTableGrid))
            {
                buttonsMargins[i] = btn.Margin;

                i++;
            }
            Random random = new Random();
            Thickness[] randomButtonsMargins = buttonsMargins.OrderBy(x => random.Next()).ToArray();

            int index = 0;
            foreach (Button btn in FindVisualChildren<Button>(imageTableGrid))
            {
                btn.Margin = randomButtonsMargins[index];
                index++;
            }
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        private void gameTime_Tick(object sender, EventArgs e)
        {
            if (playTime > 0)
            {
                playTime--;
                gameCountDownBeforeStart.Text = playTime.ToString();

                if (imagineaButonului1.IsEnabled == false && imagineaButonului2.IsEnabled == false && imagineaButonului3.IsEnabled == false && imagineaButonului4.IsEnabled == false
                       && imagineaButonului5.IsEnabled == false && imagineaButonului6.IsEnabled == false && imagineaButonului7.IsEnabled == false && imagineaButonului8.IsEnabled == false
                       && imagineaButonului9.IsEnabled == false && imagineaButonului10.IsEnabled == false && imagineaButonului11.IsEnabled == false && imagineaButonului12.IsEnabled == false
                       && imagineaButonului13.IsEnabled == false && imagineaButonului14.IsEnabled == false && imagineaButonului15.IsEnabled == false && imagineaButonului16.IsEnabled == false)
                {
                    gameTime.Stop();

                    System.IO.Stream gameWinStream = Properties.Resources.gameWin;
                    System.Media.SoundPlayer gameWinPlayer = new System.Media.SoundPlayer(gameWinStream);
                    gameWinPlayer.Play();
                    GameWin main = new GameWin();
                    App.Current.MainWindow = main;
                    main.Show();

                }
                else if (playTime == 0)
                {
                    imagineaButonului1.IsEnabled = false;
                    imagineaButonului2.IsEnabled = false;
                    imagineaButonului3.IsEnabled = false;
                    imagineaButonului4.IsEnabled = false;
                    imagineaButonului5.IsEnabled = false;
                    imagineaButonului6.IsEnabled = false;
                    imagineaButonului7.IsEnabled = false;
                    imagineaButonului8.IsEnabled = false;
                    imagineaButonului9.IsEnabled = false;
                    imagineaButonului10.IsEnabled = false;
                    imagineaButonului11.IsEnabled = false;
                    imagineaButonului12.IsEnabled = false;
                    imagineaButonului13.IsEnabled = false;
                    imagineaButonului14.IsEnabled = false;
                    imagineaButonului15.IsEnabled = false;
                    imagineaButonului16.IsEnabled = false;
                    gameCountDownBeforeStart.Text = "";
                    gameCountDownPlay.TextAlignment = TextAlignment.Center;
                    gameCountDownPlay.Foreground = new SolidColorBrush(Colors.Red);


                    GameOver main = new GameOver();
                    App.Current.MainWindow = main;
                    main.Show();

                    System.IO.Stream gameOverStream = Properties.Resources.gameOver;
                    System.Media.SoundPlayer gameOverPlayer = new System.Media.SoundPlayer(gameOverStream);
                    gameOverPlayer.Play();

                }
            }
           // throw new NotImplementedException();
        }

        private void turnImageTime_Tick(object sender, EventArgs e)
        {
            turnImageTime.Stop();
            turnCardImage1.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/color.png") as ImageSource;
            turnCardImage2.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/color.png") as ImageSource;

            turnCardImage1 = null;
            turnCardImage2 = null;
            //throw new NotImplementedException();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (showCardsTime > 0)
            {
                showCardsTime--;
                timer.Text = showCardsTime.ToString();
                if (showCardsTime == 0)
                {
                    timer.Text = " ";

                }


            }
            else
            {
                Timer.Stop();

                gameTime.Start();
                image1.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/color.png") as ImageSource;
                image2.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/color.png") as ImageSource;
                image3.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/color.png") as ImageSource;
                image4.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/color.png") as ImageSource;
                image5.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/color.png") as ImageSource;
                image6.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/color.png") as ImageSource;
                image7.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/color.png") as ImageSource;
                image8.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/color.png") as ImageSource;
                image9.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/color.png") as ImageSource;
                image10.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/color.png") as ImageSource;
                image11.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/color.png") as ImageSource;
                image12.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/color.png") as ImageSource;
                image13.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/color.png") as ImageSource;
                image14.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/color.png") as ImageSource;
                image15.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/color.png") as ImageSource;
                image16.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/color.png") as ImageSource;


            }
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);


            this.DragMove();
        }




        private void imagineaButonului1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Button_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount >= 2)
            {
                e.Handled = true;
            }
        }
        private void imagineaButonului1_Click(object sender, RoutedEventArgs e)
        {
            image1.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/crocodil.jpg") as ImageSource;
            if (turnCardImage1 == null)
            {

                turnCardImage1 = image1;
            }
            else if (turnCardImage1 != null && turnCardImage2 == null)
            {

                turnCardImage2 = image1;

            }
            if (turnCardImage1 != null && turnCardImage2 != null)
            {
                if (turnCardImage1.Uid == turnCardImage2.Uid)
                {

                    System.IO.Stream str = Properties.Resources.succes;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);

                    snd.Play();
                    imagineaButonului1.IsEnabled = false;
                    imagineaButonului9.IsEnabled = false;
                    turnCardImage1 = null;
                    turnCardImage2 = null;
                }
                else
                {
                    turnImageTime.Start();
                }

            }
        }

        private void imagineaButonului2_Click(object sender, RoutedEventArgs e)
        {
            image2.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/elefant.jpg") as ImageSource;

            if (turnCardImage1 == null)
            {
                turnCardImage1 = image2;
            }
            else if (turnCardImage1 != null && turnCardImage2 == null)
            {

                turnCardImage2 = image2;

            }
            if (turnCardImage1 != null && turnCardImage2 != null)
            {
                if (turnCardImage1.Uid == turnCardImage2.Uid)
                {
                    System.IO.Stream str = Properties.Resources.succes;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                    imagineaButonului2.IsEnabled = false;
                    imagineaButonului10.IsEnabled = false;
                    turnCardImage1 = null;
                    turnCardImage2 = null;
                }
                else
                {
                    turnImageTime.Start();
                }


            }
        }
        private void imagineaButonului3_Click(object sender, RoutedEventArgs e)
        {
            image3.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/girafa.jpg") as ImageSource;

            if (turnCardImage1 == null)
            {
                turnCardImage1 = image3;
            }
            else if (turnCardImage1 != null && turnCardImage2 == null)
            {

                turnCardImage2 = image3;

            }
            if (turnCardImage1 != null && turnCardImage2 != null)
            {
                if (turnCardImage1.Uid == turnCardImage2.Uid)
                {
                    System.IO.Stream str = Properties.Resources.succes;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                    imagineaButonului3.IsEnabled = false;
                    imagineaButonului11.IsEnabled = false;
                    turnCardImage1 = null;
                    turnCardImage2 = null;
                }
                else
                {
                    turnImageTime.Start();
                }
            }
        }

        private void imagineaButonului4_Click(object sender, RoutedEventArgs e)
        {
            image4.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/hipopotam.jpg") as ImageSource;

            if (turnCardImage1 == null)
            {
                turnCardImage1 = image4;
            }
            else if (turnCardImage1 != null && turnCardImage2 == null)
            {

                turnCardImage2 = image4;

            }
            if (turnCardImage1 != null && turnCardImage2 != null)
            {
                if (turnCardImage1.Uid == turnCardImage2.Uid)
                {
                    System.IO.Stream str = Properties.Resources.succes;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                    imagineaButonului4.IsEnabled = false;
                    imagineaButonului12.IsEnabled = false;
                    turnCardImage1 = null;
                    turnCardImage2 = null;
                }
                else
                {
                    turnImageTime.Start();
                }
            }
        }

        private void imagineaButonului5_Click(object sender, RoutedEventArgs e)
        {
            image5.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/leu.jpg") as ImageSource;

            if (turnCardImage1 == null)
            {
                turnCardImage1 = image5;
            }
            else if (turnCardImage1 != null && turnCardImage2 == null)
            {

                turnCardImage2 = image5;

            }
            if (turnCardImage1 != null && turnCardImage2 != null)
            {
                if (turnCardImage1.Uid == turnCardImage2.Uid)
                {
                    System.IO.Stream str = Properties.Resources.succes;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                    imagineaButonului5.IsEnabled = false;
                    imagineaButonului13.IsEnabled = false;
                    turnCardImage1 = null;
                    turnCardImage2 = null;
                }
                else
                {
                    turnImageTime.Start();
                }
            }
        }

        private void imagineaButonului6_Click(object sender, RoutedEventArgs e)
        {
            image6.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/maimuta.jpg") as ImageSource;

            if (turnCardImage1 == null)
            {
                turnCardImage1 = image6;
            }
            else if (turnCardImage1 != null && turnCardImage2 == null)
            {

                turnCardImage2 = image6;

            }
            if (turnCardImage1 != null && turnCardImage2 != null)
            {
                if (turnCardImage1.Uid == turnCardImage2.Uid)
                {
                    System.IO.Stream str = Properties.Resources.succes;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                    imagineaButonului6.IsEnabled = false;
                    imagineaButonului14.IsEnabled = false;
                    turnCardImage1 = null;
                    turnCardImage2 = null;
                }
                else
                {
                    turnImageTime.Start();
                }
            }
        }

        private void imagineaButonului7_Click(object sender, RoutedEventArgs e)
        {
            image7.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/tigru.jpg") as ImageSource;

            if (turnCardImage1 == null)
            {
                turnCardImage1 = image7;
            }
            else if (turnCardImage1 != null && turnCardImage2 == null)
            {

                turnCardImage2 = image7;
            }
            if (turnCardImage1 != null && turnCardImage2 != null)
            {
                if (turnCardImage1.Uid == turnCardImage2.Uid)
                {
                    System.IO.Stream str = Properties.Resources.succes;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                    imagineaButonului7.IsEnabled = false;
                    imagineaButonului12.IsEnabled = false;
                    turnCardImage1 = null;
                    turnCardImage2 = null;
                }
                else
                {

                    turnImageTime.Start();
                }
            }
        }

        private void imagineaButonului8_Click(object sender, RoutedEventArgs e)
        {
            image8.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/zebra.jpg") as ImageSource;

            if (turnCardImage1 == null)
            {
                turnCardImage1 = image8;
            }
            else if (turnCardImage1 != null && turnCardImage2 == null)
            {

                turnCardImage2 = image8;

            }
            if (turnCardImage1 != null && turnCardImage2 != null)
            {
                if (turnCardImage1.Uid == turnCardImage2.Uid)
                {
                    System.IO.Stream str = Properties.Resources.succes;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                    imagineaButonului8.IsEnabled = false;
                    imagineaButonului16.IsEnabled = false;
                    turnCardImage1 = null;
                    turnCardImage2 = null;
                }
                else
                {
                    turnImageTime.Start();
                }
            }
        }

        private void imagineaButonului9_Click(object sender, RoutedEventArgs e)
        {
            image9.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/crocodil.jpg") as ImageSource;

            if (turnCardImage1 == null)
            {
                turnCardImage1 = image9;
            }
            else if (turnCardImage1 != null && turnCardImage2 == null)
            {

                turnCardImage2 = image9;

            }
            if (turnCardImage1 != null && turnCardImage2 != null)
            {
                if (turnCardImage1.Uid == turnCardImage2.Uid)
                {
                    System.IO.Stream str = Properties.Resources.succes;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                    imagineaButonului3.IsEnabled = false;
                    imagineaButonului9.IsEnabled = false;
                    turnCardImage1 = null;
                    turnCardImage2 = null;



                }
                else
                {
                    turnImageTime.Start();
                }
            }
        }

        private void imagineaButonului10_Click(object sender, RoutedEventArgs e)
        {
            image10.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/elefant.jpg") as ImageSource;

            if (turnCardImage1 == null)
            {
                turnCardImage1 = image10;
            }
            else if (turnCardImage1 != null && turnCardImage2 == null)
            {

                turnCardImage2 = image10;

            }
            if (turnCardImage1 != null && turnCardImage2 != null)
            {
                if (turnCardImage1.Uid == turnCardImage2.Uid)
                {
                    System.IO.Stream str = Properties.Resources.succes;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                    imagineaButonului2.IsEnabled = false;
                    imagineaButonului10.IsEnabled = false;
                    turnCardImage1 = null;
                    turnCardImage2 = null;

                }
                else
                {
                    turnImageTime.Start();
                }
            }
        }

        private void imagineaButonului11_Click(object sender, RoutedEventArgs e)
        {
            image11.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/girafa.jpg") as ImageSource;

            if (turnCardImage1 == null)
            {
                turnCardImage1 = image11;
            }
            else if (turnCardImage1 != null && turnCardImage2 == null)
            {

                turnCardImage2 = image11;

            }
            if (turnCardImage1 != null && turnCardImage2 != null)
            {
                if (turnCardImage1.Uid == turnCardImage2.Uid)
                {
                    System.IO.Stream str = Properties.Resources.succes;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                    imagineaButonului3.IsEnabled = false;
                    imagineaButonului11.IsEnabled = false;
                    turnCardImage1 = null;
                    turnCardImage2 = null;


                }

                else
                {
                    turnImageTime.Start();
                }
            }
        }

        private void imagineaButonului12_Click(object sender, RoutedEventArgs e)
        {
            image12.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame//Images/hipopotam.jpg") as ImageSource;

            if (turnCardImage1 == null)
            {
                turnCardImage1 = image12;
            }
            else if (turnCardImage1 != null && turnCardImage2 == null)
            {

                turnCardImage2 = image12;

            }
            if (turnCardImage1 != null && turnCardImage2 != null)
            {
                if (turnCardImage1.Uid == turnCardImage2.Uid)
                {
                    System.IO.Stream str = Properties.Resources.succes;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                    imagineaButonului4.IsEnabled = false;
                    imagineaButonului12.IsEnabled = false;
                    turnCardImage1 = null;
                    turnCardImage2 = null;
                }
                else
                {
                    turnImageTime.Start();
                }
            }
        }

        private void imagineaButonului13_Click(object sender, RoutedEventArgs e)
        {
            image13.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/leu.jpg") as ImageSource;
            if (turnCardImage1 == null)
            {
                turnCardImage1 = image13;
            }
            else if (turnCardImage1 != null && turnCardImage2 == null)
            {

                turnCardImage2 = image13;

            }
            if (turnCardImage1 != null && turnCardImage2 != null)
            {
                if (turnCardImage1.Uid == turnCardImage2.Uid)
                {
                    System.IO.Stream str = Properties.Resources.succes;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                    imagineaButonului5.IsEnabled = false;
                    imagineaButonului13.IsEnabled = false;
                    turnCardImage1 = null;
                    turnCardImage2 = null;
                }
                else
                {
                    turnImageTime.Start();
                }
            }
        }

        private void imagineaButonului14_Click(object sender, RoutedEventArgs e)
        {
            image14.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/maimuta.jpg") as ImageSource;
            if (turnCardImage1 == null)
            {
                turnCardImage1 = image14;
            }
            else if (turnCardImage1 != null && turnCardImage2 == null)
            {

                turnCardImage2 = image14;

            }
            if (turnCardImage1 != null && turnCardImage2 != null)
            {
                if (turnCardImage1.Uid == turnCardImage2.Uid)
                {
                    System.IO.Stream str = Properties.Resources.succes;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                    imagineaButonului6.IsEnabled = false;
                    imagineaButonului14.IsEnabled = false;

                    turnCardImage1 = null;
                    turnCardImage2 = null;
                }
                else
                {
                    turnImageTime.Start();
                }

            }
        }

        private void imagineaButonului15_Click(object sender, RoutedEventArgs e)
        {
            image15.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/tigru.jpg") as ImageSource;
            if (turnCardImage1 == null)
            {
                turnCardImage1 = image15;
            }
            else if (turnCardImage1 != null && turnCardImage2 == null)
            {

                turnCardImage2 = image15;

            }
            if (turnCardImage1 != null && turnCardImage2 != null)
            {
                if (turnCardImage1.Uid == turnCardImage2.Uid)
                {
                    System.IO.Stream str = Properties.Resources.succes;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                    imagineaButonului7.IsEnabled = false;
                    imagineaButonului15.IsEnabled = false;
                    turnCardImage1 = null;
                    turnCardImage2 = null;
                }
                else
                {
                    turnImageTime.Start();
                }


            }
        }

        private void imagineaButonului16_Click(object sender, RoutedEventArgs e)
        {
            image16.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame//Images/zebra.jpg") as ImageSource;
            if (turnCardImage1 == null)
            {
                turnCardImage1 = image16;
            }
            else if (turnCardImage1 != null && turnCardImage2 == null)
            {

                turnCardImage2 = image16;

            }
            if (turnCardImage1 != null && turnCardImage2 != null)
            {
                if (turnCardImage1.Uid == turnCardImage2.Uid)
                {
                    System.IO.Stream str = Properties.Resources.succes;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                    imagineaButonului8.IsEnabled = false;
                    imagineaButonului16.IsEnabled = false;
                    turnCardImage1 = null;
                    turnCardImage2 = null;
                }
                else
                {
                    turnImageTime.Start();
                }


            }
        }

    }
}
