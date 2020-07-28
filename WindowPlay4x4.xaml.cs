using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace MemoryGame
{
    /// <summary>
    /// Interaction logic for WindowPlay.xaml
    /// </summary>
    public partial class WindowPlay4x4 : Window
    {
        String imagePath;
        int showCardsTime = 5;
    
        int playTime = 45;
        DispatcherTimer Timer;
        DispatcherTimer flipTime;
        DispatcherTimer gameTime;
        Image FlipCardImage1;
        Image FlipCardImage2;
        

        Thickness[] buttonsMargins = new Thickness[16];



        public WindowPlay4x4()
        {
            //WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            //InitializeComponent();

            //playerName.Text = Login.StringUserForNextForm;
            //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-KT9S260\SQLEXPRESS;Initial Catalog=Pairs;Integrated Security=True");

            //SqlCommand com = new SqlCommand("select * from jucator where utilizator='" + playerName.Text + "'", con);
            //con.Open();
            //SqlDataReader read = com.ExecuteReader();
            //while (read.Read())
            //{
            //    imagePath = read.GetString(2);

            //}
            //read.Close();
            Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Tick += Timer_Tick;
            Timer.Start();

            flipTime = new DispatcherTimer();
            flipTime.Interval = new TimeSpan(0, 0, 0, 0, 500);
            flipTime.Tick += flipTime_Tick;

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

        public void flipTime_Tick(object sender, EventArgs e)
        {

            flipTime.Stop();
            FlipCardImage1.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/color.png") as ImageSource;
            FlipCardImage2.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/color.png") as ImageSource;

            FlipCardImage1 = null;
            FlipCardImage2 = null;

        }

        public void gameTime_Tick(object sender, EventArgs e)
        {
            if (playTime > 0)
            {
                playTime--;
                gameCountDownBeforeStart.Text = playTime.ToString();

                if (btnImage1.IsEnabled == false && btnImage2.IsEnabled == false && btnImage3.IsEnabled == false && btnImage4.IsEnabled == false
                       && btnImage5.IsEnabled == false && btnImage6.IsEnabled == false && btnImage7.IsEnabled == false && btnImage8.IsEnabled == false
                       && btnImage9.IsEnabled == false && btnImage10.IsEnabled == false && btnImage11.IsEnabled == false && btnImage12.IsEnabled == false
                       && btnImage13.IsEnabled == false && btnImage14.IsEnabled == false && btnImage15.IsEnabled == false && btnImage16.IsEnabled == false)
                {
                    gameTime.Stop();
                }
                else if (playTime == 0)
                {
                    btnImage1.IsEnabled = false;
                    btnImage2.IsEnabled = false;
                    btnImage3.IsEnabled = false;
                    btnImage4.IsEnabled = false;
                    btnImage5.IsEnabled = false;
                    btnImage6.IsEnabled = false;
                    btnImage7.IsEnabled = false;
                    btnImage8.IsEnabled = false;
                    btnImage9.IsEnabled = false;
                    btnImage10.IsEnabled = false;
                    btnImage11.IsEnabled = false;
                    btnImage12.IsEnabled = false;
                    btnImage13.IsEnabled = false;
                    btnImage14.IsEnabled = false;
                    btnImage15.IsEnabled = false;
                    btnImage16.IsEnabled = false;
                    gameCountDownBeforeStart.Text = "";
                    gameCountDownPlay.TextAlignment = TextAlignment.Center;
                    gameCountDownPlay.Foreground = new SolidColorBrush(Colors.Red);
                    gameCountDownPlay.Text = "Joc terminat";
                }



            }

        }

        public void Timer_Tick(object sender, EventArgs e)
        {
            if (showCardsTime > 0)
            {

                showCardsTime--;
                if (!string.IsNullOrEmpty(showCardsTime.ToString()))
                {
                  //  countdown.Text = showCardsTime.ToString();
                    return;
                }

                if (showCardsTime == 0)
                {
                    countdown.Text = " ";

                }
            }
            else
            {
                Timer.Stop();

                gameTime.Start();
                image1.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/girafa.jpg") as ImageSource;
                image2.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/leu.jpg") as ImageSource;
                image3.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/crocodil.jpg") as ImageSource;
                image4.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/zebra.jpg") as ImageSource;
                image5.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/tigru.jpg") as ImageSource;
                image6.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/maimuta.jpg") as ImageSource;
                image7.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/hopopotam.jpg") as ImageSource;
                image8.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/elefant.jpg") as ImageSource;
                image9.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/crocodil.jpg") as ImageSource;
                image10.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/elefant.jpg") as ImageSource;
                image11.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/girafa.jpg") as ImageSource;
                image12.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/hipopotam.jpg") as ImageSource;
                image13.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/leu.jpg") as ImageSource;
                image14.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/maimuta.jpg") as ImageSource;
                image15.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/tigru.jpg") as ImageSource;
                image16.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/zebra.jpg") as ImageSource;


            }
        }


        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }


        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);


            this.DragMove();
        }

        private void Button_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount >= 2)
            {
                e.Handled = true;
            }
        }

        #region Flip la click
        private void btnImage1_Click(object sender, RoutedEventArgs e)
        {
            image1.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/girafa.jpg") as ImageSource;
            if (FlipCardImage1 == null)
            {

                FlipCardImage1 = image1;
            }
            else if (FlipCardImage1 != null && FlipCardImage2 == null)
            {

                FlipCardImage2 = image1;

            }
            if (FlipCardImage1 != null && FlipCardImage2 != null)
            {
                if (FlipCardImage1.Uid == FlipCardImage2.Uid)
                {

                    System.IO.Stream str = Properties.Resources.succes;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);

                    snd.Play();
                    btnImage1.IsEnabled = false;
                    btnImage9.IsEnabled = false;
                    FlipCardImage1 = null;
                    FlipCardImage2 = null;

                }
                else
                {

                    flipTime.Start();
                }


            }
        }

        private void btnImage2_Click(object sender, RoutedEventArgs e)
        {
            image2.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/leu.jpg") as ImageSource;

            if (FlipCardImage1 == null)
            {
                FlipCardImage1 = image2;
            }
            else if (FlipCardImage1 != null && FlipCardImage2 == null)
            {

                FlipCardImage2 = image2;

            }
            if (FlipCardImage1 != null && FlipCardImage2 != null)
            {
                if (FlipCardImage1.Uid == FlipCardImage2.Uid)
                {
                    System.IO.Stream str = Properties.Resources.succes;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                    btnImage2.IsEnabled = false;
                    btnImage10.IsEnabled = false;
                    FlipCardImage1 = null;
                    FlipCardImage2 = null;



                }
                else
                {


                    flipTime.Start();
                }


            }
        }

        private void btnImage3_Click(object sender, RoutedEventArgs e)
        {
            image3.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/crocodil.jpg") as ImageSource;

            if (FlipCardImage1 == null)
            {
                FlipCardImage1 = image3;
            }
            else if (FlipCardImage1 != null && FlipCardImage2 == null)
            {

                FlipCardImage2 = image3;

            }
            if (FlipCardImage1 != null && FlipCardImage2 != null)
            {
                if (FlipCardImage1.Uid == FlipCardImage2.Uid)
                {
                    System.IO.Stream str = Properties.Resources.succes;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                    btnImage3.IsEnabled = false;
                    btnImage11.IsEnabled = false;
                    FlipCardImage1 = null;
                    FlipCardImage2 = null;



                }
                else
                {

                    flipTime.Start();
                }


            }
        }

        private void btnImage4_Click(object sender, RoutedEventArgs e)
        {
            image4.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/zebra.jpg") as ImageSource;

            if (FlipCardImage1 == null)
            {
                FlipCardImage1 = image4;
            }
            else if (FlipCardImage1 != null && FlipCardImage2 == null)
            {

                FlipCardImage2 = image4;

            }
            if (FlipCardImage1 != null && FlipCardImage2 != null)
            {
                if (FlipCardImage1.Uid == FlipCardImage2.Uid)
                {
                    System.IO.Stream str = Properties.Resources.succes;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                    btnImage4.IsEnabled = false;
                    btnImage12.IsEnabled = false;
                    FlipCardImage1 = null;
                    FlipCardImage2 = null;



                }
                else
                {
                    flipTime.Start();
                }


            }
        }

        private void btnImage5_Click(object sender, RoutedEventArgs e)
        {
            image5.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/tigru.jpg") as ImageSource;

            if (FlipCardImage1 == null)
            {
                FlipCardImage1 = image5;
            }
            else if (FlipCardImage1 != null && FlipCardImage2 == null)
            {

                FlipCardImage2 = image5;

            }
            if (FlipCardImage1 != null && FlipCardImage2 != null)
            {
                if (FlipCardImage1.Uid == FlipCardImage2.Uid)
                {
                    System.IO.Stream str = Properties.Resources.succes;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                    btnImage5.IsEnabled = false;
                    btnImage13.IsEnabled = false;
                    FlipCardImage1 = null;
                    FlipCardImage2 = null;



                }
                else
                {
                    flipTime.Start();
                }


            }
        }

        private void btnImage6_Click(object sender, RoutedEventArgs e)
        {
            image6.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/maimuta.jpg") as ImageSource;

            if (FlipCardImage1 == null)
            {
                FlipCardImage1 = image6;
            }
            else if (FlipCardImage1 != null && FlipCardImage2 == null)
            {

                FlipCardImage2 = image6;

            }
            if (FlipCardImage1 != null && FlipCardImage2 != null)
            {
                if (FlipCardImage1.Uid == FlipCardImage2.Uid)
                {
                    System.IO.Stream str = Properties.Resources.succes;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                    btnImage6.IsEnabled = false;
                    btnImage14.IsEnabled = false;
                    FlipCardImage1 = null;
                    FlipCardImage2 = null;



                }
                else
                {
                    flipTime.Start();
                }


            }
        }

        private void btnImage7_Click(object sender, RoutedEventArgs e)
        {
            image7.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/hipopotam.jpg") as ImageSource;

            if (FlipCardImage1 == null)
            {
                FlipCardImage1 = image7;
            }
            else if (FlipCardImage1 != null && FlipCardImage2 == null)
            {

                FlipCardImage2 = image7;

            }
            if (FlipCardImage1 != null && FlipCardImage2 != null)
            {
                if (FlipCardImage1.Uid == FlipCardImage2.Uid)
                {
                    System.IO.Stream str = Properties.Resources.succes;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                    btnImage7.IsEnabled = false;
                    btnImage15.IsEnabled = false;
                    FlipCardImage1 = null;
                    FlipCardImage2 = null;



                }
                else
                {

                    flipTime.Start();
                }


            }
        }

        private void btnImage8_Click(object sender, RoutedEventArgs e)
        {
            image8.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/elefant.jpg") as ImageSource;

            if (FlipCardImage1 == null)
            {
                FlipCardImage1 = image8;
            }
            else if (FlipCardImage1 != null && FlipCardImage2 == null)
            {

                FlipCardImage2 = image8;

            }
            if (FlipCardImage1 != null && FlipCardImage2 != null)
            {
                if (FlipCardImage1.Uid == FlipCardImage2.Uid)
                {
                    System.IO.Stream str = Properties.Resources.succes;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                    btnImage8.IsEnabled = false;
                    btnImage16.IsEnabled = false;
                    FlipCardImage1 = null;
                    FlipCardImage2 = null;



                }
                else
                {
                    flipTime.Start();
                }


            }
        }

        private void btnImage9_Click(object sender, RoutedEventArgs e)
        {
            image9.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/crocodil.jpg") as ImageSource;

            if (FlipCardImage1 == null)
            {
                FlipCardImage1 = image9;
            }
            else if (FlipCardImage1 != null && FlipCardImage2 == null)
            {

                FlipCardImage2 = image9;

            }
            if (FlipCardImage1 != null && FlipCardImage2 != null)
            {
                if (FlipCardImage1.Uid == FlipCardImage2.Uid)
                {
                    System.IO.Stream str = Properties.Resources.succes;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                    btnImage1.IsEnabled = false;
                    btnImage9.IsEnabled = false;
                    FlipCardImage1 = null;
                    FlipCardImage2 = null;



                }
                else
                {
                    flipTime.Start();
                }


            }
        }

        private void btnImage10_Click(object sender, RoutedEventArgs e)
        {
            image10.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/elefant.jpg") as ImageSource;

            if (FlipCardImage1 == null)
            {
                FlipCardImage1 = image10;
            }
            else if (FlipCardImage1 != null && FlipCardImage2 == null)
            {

                FlipCardImage2 = image10;

            }
            if (FlipCardImage1 != null && FlipCardImage2 != null)
            {
                if (FlipCardImage1.Uid == FlipCardImage2.Uid)
                {
                    System.IO.Stream str = Properties.Resources.succes;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                    btnImage2.IsEnabled = false;
                    btnImage10.IsEnabled = false;
                    FlipCardImage1 = null;
                    FlipCardImage2 = null;



                }
                else
                {
                    flipTime.Start();
                }


            }
        }

        private void btnImage11_Click(object sender, RoutedEventArgs e)
        {
            image11.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/girafa.jpg") as ImageSource;

            if (FlipCardImage1 == null)
            {
                FlipCardImage1 = image11;
            }
            else if (FlipCardImage1 != null && FlipCardImage2 == null)
            {

                FlipCardImage2 = image11;

            }
            if (FlipCardImage1 != null && FlipCardImage2 != null)
            {
                if (FlipCardImage1.Uid == FlipCardImage2.Uid)
                {
                    System.IO.Stream str = Properties.Resources.succes;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                    btnImage3.IsEnabled = false;
                    btnImage11.IsEnabled = false;
                    FlipCardImage1 = null;
                    FlipCardImage2 = null;


                }

                else
                {
                    flipTime.Start();
                }


            }
        }

        private void btnImage12_Click(object sender, RoutedEventArgs e)
        {
            image12.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame//Images/hipopotam.jpg") as ImageSource;

            if (FlipCardImage1 == null)
            {
                FlipCardImage1 = image12;
            }
            else if (FlipCardImage1 != null && FlipCardImage2 == null)
            {

                FlipCardImage2 = image12;

            }
            if (FlipCardImage1 != null && FlipCardImage2 != null)
            {
                if (FlipCardImage1.Uid == FlipCardImage2.Uid)
                {
                    System.IO.Stream str = Properties.Resources.succes;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                    btnImage4.IsEnabled = false;
                    btnImage12.IsEnabled = false;
                    FlipCardImage1 = null;
                    FlipCardImage2 = null;



                }
                else
                {
                    flipTime.Start();
                }


            }
        }

        private void btnImage13_Click(object sender, RoutedEventArgs e)
        {
            image13.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/leu.jpg") as ImageSource;
            if (FlipCardImage1 == null)
            {
                FlipCardImage1 = image13;
            }
            else if (FlipCardImage1 != null && FlipCardImage2 == null)
            {

                FlipCardImage2 = image13;

            }
            if (FlipCardImage1 != null && FlipCardImage2 != null)
            {
                if (FlipCardImage1.Uid == FlipCardImage2.Uid)
                {
                    System.IO.Stream str = Properties.Resources.succes;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                    btnImage5.IsEnabled = false;
                    btnImage13.IsEnabled = false;
                    FlipCardImage1 = null;
                    FlipCardImage2 = null;



                }
                else
                {

                    flipTime.Start();
                }


            }
        }

        private void btnImage14_Click(object sender, RoutedEventArgs e)
        {
            image14.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/maimuta.jpg") as ImageSource;
            if (FlipCardImage1 == null)
            {
                FlipCardImage1 = image14;
            }
            else if (FlipCardImage1 != null && FlipCardImage2 == null)
            {

                FlipCardImage2 = image14;

            }
            if (FlipCardImage1 != null && FlipCardImage2 != null)
            {
                if (FlipCardImage1.Uid == FlipCardImage2.Uid)
                {
                    System.IO.Stream str = Properties.Resources.succes;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                    btnImage6.IsEnabled = false;
                    btnImage14.IsEnabled = false;

                    FlipCardImage1 = null;
                    FlipCardImage2 = null;



                }
                else
                {

                    flipTime.Start();
                }


            }
        }

        private void btnImage15_Click(object sender, RoutedEventArgs e)
        {
            image15.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/tigru.jpg") as ImageSource;
            if (FlipCardImage1 == null)
            {
                FlipCardImage1 = image15;
            }
            else if (FlipCardImage1 != null && FlipCardImage2 == null)
            {

                FlipCardImage2 = image15;

            }
            if (FlipCardImage1 != null && FlipCardImage2 != null)
            {
                if (FlipCardImage1.Uid == FlipCardImage2.Uid)
                {
                    System.IO.Stream str = Properties.Resources.succes;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                    btnImage7.IsEnabled = false;
                    btnImage15.IsEnabled = false;
                    FlipCardImage1 = null;
                    FlipCardImage2 = null;

                }
                else
                {

                    flipTime.Start();
                }


            }
        }

        private void btnImage16_Click(object sender, RoutedEventArgs e)
        {
            image16.Source = (new ImageSourceConverter()).ConvertFromString("C:/Users/andreea/source/repos/MemoryGame/MemoryGame//Images/zebra.jpg") as ImageSource;
            if (FlipCardImage1 == null)
            {
                FlipCardImage1 = image16;
            }
            else if (FlipCardImage1 != null && FlipCardImage2 == null)
            {

                FlipCardImage2 = image16;

            }
            if (FlipCardImage1 != null && FlipCardImage2 != null)
            {
                if (FlipCardImage1.Uid == FlipCardImage2.Uid)
                {
                    System.IO.Stream str = Properties.Resources.succes;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                    btnImage8.IsEnabled = false;
                    btnImage16.IsEnabled = false;
                    FlipCardImage1 = null;
                    FlipCardImage2 = null;



                }
                else
                {

                    flipTime.Start();
                }


            }
        }

        #endregion


    }
}

