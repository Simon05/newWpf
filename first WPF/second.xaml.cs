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
using System.Data.SQLite;

namespace first_WPF
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {

            InitializeComponent();
        }
        string dbconstring = @"Data Source=database.db;Version=3;";

        private void button_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection sqlitecon = new SQLiteConnection(dbconstring);
            // open connection to database 
            try
            {
                sqlitecon.Open();
                string Query = "insert into employ (eid,name,surname,age) values ('" + this.textBox_eid.Text + "','" + this.textBox_name.Text+"','"+this.textBox_surname.Text+ "','" + this.textBox_age.Text + "')";
                SQLiteCommand creatcommand = new SQLiteCommand(Query, sqlitecon);
                
                creatcommand.ExecuteNonQuery();
                MessageBox.Show("SAVED");
                sqlitecon.Close();
            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.Message);
            }
        } 

}
}
