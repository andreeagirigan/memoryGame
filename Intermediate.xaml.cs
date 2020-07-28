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

    public partial class Intermediate : Window
    {
        
        int showCardsTime = 3;

        int playTime = 120;
        DispatcherTimer Timer;
        DispatcherTimer turnImageTime;
        DispatcherTimer gameTime;
        Image turnCardImage1;
        Image turnCardImage2;

        Thickness[] buttonsMargins = new Thickness[36];
        public Intermediate()
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
                       && imagineaButonului13.IsEnabled == false && imagineaButonului14.IsEnabled == false && imagineaButonului15.IsEnabled == false && imagineaButonului16.IsEnabled == false
                       && imagineaButonului17.IsEnabled == false && imagineaButonului18.IsEnabled == false && imagineaButonului19.IsEnabled == false && imagineaButonului20.IsEnabled == false
                       && imagineaButonului21.IsEnabled == false && imagineaButonului22.IsEnabled == false && imagineaButonului23.IsEnabled == false && imagineaButonului24.IsEnabled == false
                       && imagineaButonului25.IsEnabled == false && imagineaButonului26.IsEnabled == false && imagineaButonului27.IsEnabled == false && imagineaButonului28.IsEnabled == false
                       && imagineaButonului29.IsEnabled == false && imagineaButonului30.IsEnabled == false && imagineaButonului31.IsEnabled == false && imagineaButonului32.IsEnabled == false
                       && imagineaButonului33.IsEnabled == false && imagineaButonului34.IsEnabled == false && imagineaButonului35.IsEnabled == false && imagineaButonului36.IsEnabled == false)
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
                    imagineaButonului17.IsEnabled = false;
                    imagineaButonului18.IsEnabled = false;
                    imagineaButonului19.IsEnabled = false;
                    imagineaButonului20.IsEnabled = false;
                    imagineaButonului21.IsEnabled = false;
                    imagineaButonului22.IsEnabled = false;
                    imagineaButonului23.IsEnabled = false;
                    imagineaButonului24.IsEnabled = false;
                    imagineaButonului25.IsEnabled = false;
                    imagineaButonului26.IsEnabled = false;
                    imagineaButonului27.IsEnabled = false;
                    imagineaButonului28.IsEnabled = false;
                    imagineaButonului29.IsEnabled = false;
                    imagineaButonului30.IsEnabled = false;
                    imagineaButonului31.IsEnabled = false;
                    imagineaButonului33.IsEnabled = false;
                    imagineaButonului34.IsEnabled = false;
                    imagineaButonului35.IsEnabled = false;
                    imagineaButonului36.IsEnabled = false;


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

        }

        private void turnImageTime_Tick(object sender, EventArgs e)
        {
            turnImageTime.Stop();
            turnCardImage1.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/color.png") as ImageSource;
            turnCardImage2.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/color.png") as ImageSource;

            turnCardImage1 = null;
            turnCardImage2 = null;

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (showCardsTime > 0)
            {
                showCardsTime--;
                countdown.Text = showCardsTime.ToString();
                if (showCardsTime == 0)
                {
                    countdown.Text = " ";

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
                image17.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/color.png") as ImageSource;
                image18.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/color.png") as ImageSource;
                image19.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/color.png") as ImageSource;
                image20.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/color.png") as ImageSource;
                image21.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/color.png") as ImageSource;
                image22.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/color.png") as ImageSource;
                image23.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/color.png") as ImageSource;
                image24.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/color.png") as ImageSource;
                image25.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/color.png") as ImageSource;
                image26.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/color.png") as ImageSource;
                image27.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/color.png") as ImageSource;
                image28.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/color.png") as ImageSource;
                image29.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/color.png") as ImageSource;
                image30.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/color.png") as ImageSource;
                image31.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/color.png") as ImageSource;
                image32.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/color.png") as ImageSource;
                image33.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/color.png") as ImageSource;
                image34.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/color.png") as ImageSource;
                image35.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/color.png") as ImageSource;
                image36.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/color.png") as ImageSource;

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
            image1.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/caine.jpg") as ImageSource;
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
            image2.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/elefant2.jpg") as ImageSource;

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
            image3.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/cocos.jpg") as ImageSource;

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
            image4.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/iepure.jpg") as ImageSource;

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
            image5.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/oaie.jpg") as ImageSource;

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
            image6.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/maimuta2.jpg") as ImageSource;

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
            image7.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/porc.jpg") as ImageSource;

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
            image8.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/vaca.jpg") as ImageSource;

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
            image9.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/caine.jpg") as ImageSource;

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
            image10.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/elefant2.jpg") as ImageSource;

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
            image11.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/cocos.jpg") as ImageSource;

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
            image12.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame//Images/iepure.jpg") as ImageSource;

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
            image13.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/oaie.jpg") as ImageSource;
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
            image14.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/maimuta2.jpg") as ImageSource;
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
            image15.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/porc.jpg") as ImageSource;
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
            image16.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame//Images/vaca.jpg") as ImageSource;
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
        private void imagineaButonului17_Click(object sender, RoutedEventArgs e)
        {
            image17.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame//Images/testoasa.jpg") as ImageSource;
            if (turnCardImage1 == null)
            {
                turnCardImage1 = image17;
            }
            else if (turnCardImage1 != null && turnCardImage2 == null)
            {

                turnCardImage2 = image17;

            }
            if (turnCardImage1 != null && turnCardImage2 != null)
            {
                if (turnCardImage1.Uid == turnCardImage2.Uid)
                {
                    System.IO.Stream str = Properties.Resources.succes;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                    imagineaButonului17.IsEnabled = false;
                    //imagineaButonului35.IsEnabled = false;
                    turnCardImage1 = null;
                    turnCardImage2 = null;
                }
                else
                {
                    turnImageTime.Start();
                }


            }
        }
        private void imagineaButonului18_Click(object sender, RoutedEventArgs e)
        {
            image18.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame//Images/raton.jpg") as ImageSource;
            if (turnCardImage1 == null)
            {
                turnCardImage1 = image18;
            }
            else if (turnCardImage1 != null && turnCardImage2 == null)
            {

                turnCardImage2 = image18;

            }
            if (turnCardImage1 != null && turnCardImage2 != null)
            {
                if (turnCardImage1.Uid == turnCardImage2.Uid)
                {
                    System.IO.Stream str = Properties.Resources.succes;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                    imagineaButonului18.IsEnabled = false;
                   // imagineaButonului33.IsEnabled = false;
                    turnCardImage1 = null;
                    turnCardImage2 = null;
                }
                else
                {
                    turnImageTime.Start();
                }


            }
        }
        private void imagineaButonului19_Click(object sender, RoutedEventArgs e)
        {
            image19.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame//Images/papagal.jpg") as ImageSource;
            if (turnCardImage1 == null)
            {
                turnCardImage1 = image19;
            }
            else if (turnCardImage1 != null && turnCardImage2 == null)
            {

                turnCardImage2 = image19;

            }
            if (turnCardImage1 != null && turnCardImage2 != null)
            {
                if (turnCardImage1.Uid == turnCardImage2.Uid)
                {
                    System.IO.Stream str = Properties.Resources.succes;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                    imagineaButonului19.IsEnabled = false;
                  //  imagineaButonului31.IsEnabled = false;
                    turnCardImage1 = null;
                    turnCardImage2 = null;
                }
                else
                {
                    turnImageTime.Start();
                }


            }
        }
        private void imagineaButonului20_Click(object sender, RoutedEventArgs e)
        {
            image20.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame//Images/arici.jpg") as ImageSource;
            if (turnCardImage1 == null)
            {
                turnCardImage1 = image20;
            }
            else if (turnCardImage1 != null && turnCardImage2 == null)
            {

                turnCardImage2 = image20;

            }
            if (turnCardImage1 != null && turnCardImage2 != null)
            {
                if (turnCardImage1.Uid == turnCardImage2.Uid)
                {
                    System.IO.Stream str = Properties.Resources.succes;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                    imagineaButonului20.IsEnabled = false;
                   // imagineaButonului29.IsEnabled = false;
                    turnCardImage1 = null;
                    turnCardImage2 = null;
                }
                else
                {
                    turnImageTime.Start();
                }


            }
        }
        private void imagineaButonului21_Click(object sender, RoutedEventArgs e)
        {
            image21.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame//Images/vulpe.jpg") as ImageSource;
            if (turnCardImage1 == null)
            {
                turnCardImage1 = image21;
            }
            else if (turnCardImage1 != null && turnCardImage2 == null)
            {

                turnCardImage2 = image21;

            }
            if (turnCardImage1 != null && turnCardImage2 != null)
            {
                if (turnCardImage1.Uid == turnCardImage2.Uid)
                {
                    System.IO.Stream str = Properties.Resources.succes;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                    imagineaButonului21.IsEnabled = false;
                   // imagineaButonului36.IsEnabled = false;
                    turnCardImage1 = null;
                    turnCardImage2 = null;
                }
                else
                {
                    turnImageTime.Start();
                }


            }
        }
        private void imagineaButonului22_Click(object sender, RoutedEventArgs e)
        {
            image22.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame//Images/soarece.jpg") as ImageSource;
            if (turnCardImage1 == null)
            {
                turnCardImage1 = image22;
            }
            else if (turnCardImage1 != null && turnCardImage2 == null)
            {

                turnCardImage2 = image22;

            }
            if (turnCardImage1 != null && turnCardImage2 != null)
            {
                if (turnCardImage1.Uid == turnCardImage2.Uid)
                {
                    System.IO.Stream str = Properties.Resources.succes;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                    imagineaButonului22.IsEnabled = false;
                    imagineaButonului34.IsEnabled = false;
                    turnCardImage1 = null;
                    turnCardImage2 = null;
                }
                else
                {
                    turnImageTime.Start();
                }


            }
        }
        private void imagineaButonului23_Click(object sender, RoutedEventArgs e)
        {
            image23.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame//Images/pinguin.jpg") as ImageSource;
            if (turnCardImage1 == null)
            {
                turnCardImage1 = image23;
            }
            else if (turnCardImage1 != null && turnCardImage2 == null)
            {

                turnCardImage2 = image23;

            }
            if (turnCardImage1 != null && turnCardImage2 != null)
            {
                if (turnCardImage1.Uid == turnCardImage2.Uid)
                {
                    System.IO.Stream str = Properties.Resources.succes;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                    imagineaButonului23.IsEnabled = false;
                    imagineaButonului32.IsEnabled = false;
                    turnCardImage1 = null;
                    turnCardImage2 = null;
                }
                else
                {
                    turnImageTime.Start();
                }


            }
        }
        private void imagineaButonului24_Click(object sender, RoutedEventArgs e)
        {
            image24.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame//Images/bufnita.jpg") as ImageSource;
            if (turnCardImage1 == null)
            {
                turnCardImage1 = image24;
            }
            else if (turnCardImage1 != null && turnCardImage2 == null)
            {

                turnCardImage2 = image24;

            }
            if (turnCardImage1 != null && turnCardImage2 != null)
            {
                if (turnCardImage1.Uid == turnCardImage2.Uid)
                {
                    System.IO.Stream str = Properties.Resources.succes;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                    imagineaButonului24.IsEnabled = false;
                    imagineaButonului30.IsEnabled = false;
                    turnCardImage1 = null;
                    turnCardImage2 = null;
                }
                else
                {
                    turnImageTime.Start();
                }


            }
        }
        private void imagineaButonului25_Click(object sender, RoutedEventArgs e)
        {
            image25.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame//Images/panda.jpg") as ImageSource;
            if (turnCardImage1 == null)
            {
                turnCardImage1 = image25;
            }
            else if (turnCardImage1 != null && turnCardImage2 == null)
            {

                turnCardImage2 = image25;

            }
            if (turnCardImage1 != null && turnCardImage2 != null)
            {
                if (turnCardImage1.Uid == turnCardImage2.Uid)
                {
                    System.IO.Stream str = Properties.Resources.succes;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                    imagineaButonului25.IsEnabled = false;
                    imagineaButonului27.IsEnabled = false;
                    turnCardImage1 = null;
                    turnCardImage2 = null;
                }
                else
                {
                    turnImageTime.Start();
                }


            }
        }
        private void imagineaButonului26_Click(object sender, RoutedEventArgs e)
        {
            image26.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame//Images/pisica.jpg") as ImageSource;
            if (turnCardImage1 == null)
            {
                turnCardImage1 = image26;
            }
            else if (turnCardImage1 != null && turnCardImage2 == null)
            {

                turnCardImage2 = image26;

            }
            if (turnCardImage1 != null && turnCardImage2 != null)
            {
                if (turnCardImage1.Uid == turnCardImage2.Uid)
                {
                    System.IO.Stream str = Properties.Resources.succes;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                    imagineaButonului26.IsEnabled = false;
                    imagineaButonului28.IsEnabled = false;
                    turnCardImage1 = null;
                    turnCardImage2 = null;
                }
                else
                {
                    turnImageTime.Start();
                }


            }
        }
        private void imagineaButonului27_Click(object sender, RoutedEventArgs e)
        {
            image27.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame//Images/panda.jpg") as ImageSource;
            if (turnCardImage1 == null)
            {
                turnCardImage1 = image27;
            }
            else if (turnCardImage1 != null && turnCardImage2 == null)
            {

                turnCardImage2 = image27;

            }
            if (turnCardImage1 != null && turnCardImage2 != null)
            {
                if (turnCardImage1.Uid == turnCardImage2.Uid)
                {
                    System.IO.Stream str = Properties.Resources.succes;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                    imagineaButonului27.IsEnabled = false;
                    imagineaButonului25.IsEnabled = false;
                    turnCardImage1 = null;
                    turnCardImage2 = null;
                }
                else
                {
                    turnImageTime.Start();
                }


            }
        }
        private void imagineaButonului28_Click(object sender, RoutedEventArgs e)
        {
            image28.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame//Images/pisica.jpg") as ImageSource;
            if (turnCardImage1 == null)
            {
                turnCardImage1 = image28;
            }
            else if (turnCardImage1 != null && turnCardImage2 == null)
            {

                turnCardImage2 = image28;

            }
            if (turnCardImage1 != null && turnCardImage2 != null)
            {
                if (turnCardImage1.Uid == turnCardImage2.Uid)
                {
                    System.IO.Stream str = Properties.Resources.succes;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                    imagineaButonului28.IsEnabled = false;
                    imagineaButonului35.IsEnabled = false;
                    turnCardImage1 = null;
                    turnCardImage2 = null;
                }
                else
                {
                    turnImageTime.Start();
                }


            }
        }
        private void imagineaButonului29_Click(object sender, RoutedEventArgs e)
        {
            image29.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame//Images/arici.jpg") as ImageSource;
            if (turnCardImage1 == null)
            {
                turnCardImage1 = image29;
            }
            else if (turnCardImage1 != null && turnCardImage2 == null)
            {

                turnCardImage2 = image29;

            }
            if (turnCardImage1 != null && turnCardImage2 != null)
            {
                if (turnCardImage1.Uid == turnCardImage2.Uid)
                {
                    System.IO.Stream str = Properties.Resources.succes;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                    imagineaButonului29.IsEnabled = false;
                    imagineaButonului30.IsEnabled = false;
                    turnCardImage1 = null;
                    turnCardImage2 = null;
                }
                else
                {
                    turnImageTime.Start();
                }


            }
        }
        private void imagineaButonului30_Click(object sender, RoutedEventArgs e)
        {
            image30.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame//Images/bufnita.jpg") as ImageSource;
            if (turnCardImage1 == null)
            {
                turnCardImage1 = image30;
            }
            else if (turnCardImage1 != null && turnCardImage2 == null)
            {

                turnCardImage2 = image30;

            }
            if (turnCardImage1 != null && turnCardImage2 != null)
            {
                if (turnCardImage1.Uid == turnCardImage2.Uid)
                {
                    System.IO.Stream str = Properties.Resources.succes;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                    imagineaButonului30.IsEnabled = false;
                    imagineaButonului24.IsEnabled = false;
                    turnCardImage1 = null;
                    turnCardImage2 = null;
                }
                else
                {
                    turnImageTime.Start();
                }


            }
        }
        private void imagineaButonului31_Click(object sender, RoutedEventArgs e)
        {
            image31.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame//Images/papagal.jpg") as ImageSource;
            if (turnCardImage1 == null)
            {
                turnCardImage1 = image31;
            }
            else if (turnCardImage1 != null && turnCardImage2 == null)
            {

                turnCardImage2 = image31;

            }
            if (turnCardImage1 != null && turnCardImage2 != null)
            {
                if (turnCardImage1.Uid == turnCardImage2.Uid)
                {
                    System.IO.Stream str = Properties.Resources.succes;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                    imagineaButonului31.IsEnabled = false;
                    imagineaButonului19.IsEnabled = false;
                    turnCardImage1 = null;
                    turnCardImage2 = null;
                }
                else
                {
                    turnImageTime.Start();
                }


            }
        }
        private void imagineaButonului32_Click(object sender, RoutedEventArgs e)
        {
            image32.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame//Images/pinguin.jpg") as ImageSource;
            if (turnCardImage1 == null)
            {
                turnCardImage1 = image32;
            }
            else if (turnCardImage1 != null && turnCardImage2 == null)
            {

                turnCardImage2 = image32;

            }
            if (turnCardImage1 != null && turnCardImage2 != null)
            {
                if (turnCardImage1.Uid == turnCardImage2.Uid)
                {
                    System.IO.Stream str = Properties.Resources.succes;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                    imagineaButonului32.IsEnabled = false;
                    imagineaButonului23.IsEnabled = false;
                    turnCardImage1 = null;
                    turnCardImage2 = null;
                }
                else
                {
                    turnImageTime.Start();
                }


            }
        }
        private void imagineaButonului33_Click(object sender, RoutedEventArgs e)
        {
            image33.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame//Images/raton.jpg") as ImageSource;
            if (turnCardImage1 == null)
            {
                turnCardImage1 = image33;
            }
            else if (turnCardImage1 != null && turnCardImage2 == null)
            {

                turnCardImage2 = image33;

            }
            if (turnCardImage1 != null && turnCardImage2 != null)
            {
                if (turnCardImage1.Uid == turnCardImage2.Uid)
                {
                    System.IO.Stream str = Properties.Resources.succes;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                    imagineaButonului33.IsEnabled = false;
                    imagineaButonului18.IsEnabled = false;
                    turnCardImage1 = null;
                    turnCardImage2 = null;
                }
                else
                {
                    turnImageTime.Start();
                }


            }
        }
        private void imagineaButonului34_Click(object sender, RoutedEventArgs e)
        {
            image34.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame//Images/soarece.jpg") as ImageSource;
            if (turnCardImage1 == null)
            {
                turnCardImage1 = image34;
            }
            else if (turnCardImage1 != null && turnCardImage2 == null)
            {

                turnCardImage2 = image34;

            }
            if (turnCardImage1 != null && turnCardImage2 != null)
            {
                if (turnCardImage1.Uid == turnCardImage2.Uid)
                {
                    System.IO.Stream str = Properties.Resources.succes;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                    imagineaButonului34.IsEnabled = false;
                    imagineaButonului22.IsEnabled = false;
                    turnCardImage1 = null;
                    turnCardImage2 = null;
                }
                else
                {
                    turnImageTime.Start();
                }


            }
        }
        private void imagineaButonului35_Click(object sender, RoutedEventArgs e)
        {
            image35.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame//Images/testoasa.jpg") as ImageSource;
            if (turnCardImage1 == null)
            {
                turnCardImage1 = image35;
            }
            else if (turnCardImage1 != null && turnCardImage2 == null)
            {

                turnCardImage2 = image35;

            }
            if (turnCardImage1 != null && turnCardImage2 != null)
            {
                if (turnCardImage1.Uid == turnCardImage2.Uid)
                {
                    System.IO.Stream str = Properties.Resources.succes;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                    imagineaButonului35.IsEnabled = false;
                    imagineaButonului17.IsEnabled = false;
                    turnCardImage1 = null;
                    turnCardImage2 = null;
                }
                else
                {
                    turnImageTime.Start();
                }


            }
        }
        private void imagineaButonului36_Click(object sender, RoutedEventArgs e)
        {
            image36.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame//Images/vulpe.jpg") as ImageSource;
            if (turnCardImage1 == null)
            {
                turnCardImage1 = image36;
            }
            else if (turnCardImage1 != null && turnCardImage2 == null)
            {

                turnCardImage2 = image36;

            }
            if (turnCardImage1 != null && turnCardImage2 != null)
            {
                if (turnCardImage1.Uid == turnCardImage2.Uid)
                {
                    System.IO.Stream str = Properties.Resources.succes;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                    imagineaButonului36.IsEnabled = false;
                    imagineaButonului21.IsEnabled = false;
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
