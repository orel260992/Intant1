using Black_sklad.vivemodels;
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
using MySql.Data.MySqlClient;
using System.Data;

namespace Black_sklad.pages
{
    /// <summary>
    /// Логика взаимодействия для catalog.xaml
    /// </summary>
    public partial class catalog : Page
    {
        public catalog()
        {
            InitializeComponent();
            categ.IsReadOnly = true;
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            // MySqlCommand command = new MySqlCommand("SELECT categories FROM price ", db.getConnection());
            MySqlCommand command = new MySqlCommand("SELECT `cat` AS `Категория`, `podcat` AS `Подкатегория` FROM categ", db.getConnection());            
            db.openConnection();
            dataAdapter.SelectCommand = command;
            dataAdapter.Fill(table);
            categ.ItemsSource = table.DefaultView;
            db.closeConnection();                      
        }

        private void Button_addcat_Click(object sender, RoutedEventArgs e)
        {
            Add_Categories add_Categories = new Add_Categories();
            add_Categories.Show();            
            /* string add = "Красавчег";
            DB db = new DB();           
            MySqlCommand command = new MySqlCommand("INSERT INTO price (categories) VALUES (@Tabak);", db.getConnection());
            db.openConnection();
            command.Parameters.Add("@Tabak", MySqlDbType.VarChar).Value = add;
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Категория добавлена!");
            }
            else
            {
                MessageBox.Show("ошибка!");
            }
            db.closeConnection();
            */
        }
        /*
CREATE TABLE CUSTOMERS(
ID   INT              NOT NULL,
NAME VARCHAR (20)     NOT NULL,
AGE  INT              NOT NULL,
ADDRESS  CHAR (25) ,
SALARY   DECIMAL (18, 2),       
PRIMARY KEY (ID)
);
*/

    }
}
