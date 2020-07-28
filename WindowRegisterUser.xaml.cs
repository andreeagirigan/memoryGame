using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaction logic for RegisterUser.xaml
    /// </summary>
    public partial class RegisterUser : Window
    {
        public RegisterUser()
        {
            InitializeComponent();
        }

       // String avatardatabase;
        //private void btnImg1_Click(object sender, RoutedEventArgs e)
        //{
        //    avatardatabase = "C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/leu.jpg";
        //}

        //private void btnImg2_Click(object sender, RoutedEventArgs e)
        //{
        //    avatardatabase = "C:/Users/andreea/source/repos/MemoryGame/MemoryGame/Images/tigru.jpg";
        //}
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection("Data Source=ANDREEA-PC\\SQLEXPRESS;Initial Catalog=LoginDB;Persist Security Info=True;User ID=sa;Password=blabla2");
            try
            {
                if (sqlCon.State == System.Data.ConnectionState.Closed)
                    sqlCon.Open();
                String query = "INSERT into tblUser (Username, Password) values('" + txtUsername.Text + "'," + " '" + txtPassword.Text + "')";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.ExecuteNonQuery();
                //sqlCmd.CommandType = System.Data.CommandType.Text;
                //sqlCmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                //sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                MessageBox.Show("Userul a fost inregistrat cu succes");
                Window1 window1 = new Window1();
                window1.Show();
                this.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Show();
            this.Close();
        }

        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {

        }



    }
}
