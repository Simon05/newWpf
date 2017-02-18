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
using System.Data.SQLite;
using System.Text.RegularExpressions;
using System.Windows.Media.Animation;

namespace first_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
            {
        string dbconstring = @"Data Source=database.db;Version=3;";
        public MainWindow()
        {
            

            InitializeComponent();

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            SQLiteConnection sqlitecon = new SQLiteConnection(dbconstring);
            // open connection to database 
            try {
                sqlitecon.Open();
                string Query = "select * from employ where username='" + this.txt_username.Text + "' and password='" + this.txt_password.Password  + "'";
                SQLiteCommand creatcommand = new SQLiteCommand(Query, sqlitecon);


                creatcommand.ExecuteNonQuery();
                SQLiteDataReader dr = creatcommand.ExecuteReader();

                int count = 0;
                while (dr.Read())
                {
                    count++;
                }
                if (count == 1)
                {
                    MessageBox.Show("username and pass correct");
                    this.Hide();
                    sqlitecon.Close();
                    Window1 sec = new Window1();

                    sec.ShowDialog();
                    



                }
                if (count > 1)
                {
                    MessageBox.Show("DUPLICATE username and pass correct try again");
                }
                if (count < 1)
                {
                    MessageBox.Show("username and pass NOT correct!!");
                }
              

            } catch(Exception ex)

            {
                MessageBox.Show(ex.Message);
            }

             


        }

       
    }
}
