using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Black_sklad
{
    /// <summary>
    /// Логика взаимодействия для Add_Categories.xaml
    /// </summary>
    public partial class Add_Categories : Window
    {
        public Add_Categories()
        {
            InitializeComponent();
            
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT DISTINCT `cat` FROM categ", db.getConnection());
                db.openConnection();
                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(table);
                textboxNamePodcat.ItemsSource = table.DefaultView;
                db.closeConnection();
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            string newcat = textboxName.Text.Trim();
            string podcat;

            DataRowView oDataRowView = textboxNamePodcat.SelectedItem as DataRowView;
            

            if (oDataRowView != null) 
            {
                podcat = oDataRowView.Row["cat"] as string;
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("INSERT INTO `categ` (`cat`, `podcat`) VALUES (@categories, @podcategories)", db.getConnection());
                command.Parameters.Add("@categories", MySqlDbType.VarChar).Value = podcat;
                command.Parameters.Add("@podcategories", MySqlDbType.VarChar).Value = newcat;
                db.openConnection();
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Категория добавлена!");
                }
                else
                {
                    MessageBox.Show("ошибка!");
                }
                db.closeConnection();
            }
            else
            {
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("INSERT INTO `categ` (`cat`) VALUES (@categories)", db.getConnection());
                command.Parameters.Add("@categories", MySqlDbType.VarChar).Value = newcat;                
                db.openConnection();
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Категория добавлена!");
                }
                else
                {
                    MessageBox.Show("ошибка!");
                }
                db.closeConnection();
            }

            
        }
    }
}
