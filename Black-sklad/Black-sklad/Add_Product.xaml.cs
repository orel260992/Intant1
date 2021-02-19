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
using System.Text.RegularExpressions;

namespace Black_sklad
{
    /// <summary>
    /// Логика взаимодействия для Add_Product.xaml
    /// </summary>
    public partial class Add_Product : Window
    {
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        public Add_Product()
        {
            InitializeComponent();

            DB db = new DB();
            DataTable table = new DataTable();
            DataTable table1 = new DataTable();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            MySqlDataAdapter dataAdapter1 = new MySqlDataAdapter();            
            MySqlCommand command = new MySqlCommand("SELECT DISTINCT cat FROM categ", db.getConnection());
            MySqlCommand command1 = new MySqlCommand("SELECT DISTINCT podcat FROM categ", db.getConnection());
            db.openConnection();
            dataAdapter.SelectCommand = command;
            dataAdapter.Fill(table);
            textboxNamecat.ItemsSource = table.DefaultView;
            dataAdapter1.SelectCommand = command1;
            dataAdapter1.Fill(table1);
            textboxNamepodcat.ItemsSource = table1.DefaultView;
            db.closeConnection();
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {            
            string cat;
            string podcat;
            string name = textboxName.Text.Trim();
            string info = textboxinfo.Text.Trim();            
            
            int price = 0; 
            int priceopt = 0; 
            int pricevhod = 0;
            int col = 0;

            DataRowView oDataRowView = textboxNamecat.SelectedItem as DataRowView;
            DataRowView oDataRowView1 = textboxNamepodcat.SelectedItem as DataRowView;
            if (textboxintcol.Text != "")
            {
                textboxintcol.ToolTip = "";
                textboxintcol.BorderBrush = Brushes.Transparent;
                col = Convert.ToInt32(textboxintcol.Text.Trim());
            }
            else
            {
                textboxintcol.ToolTip = "поле не должно быть пустым";
                textboxintcol.BorderBrush = Brushes.DarkRed;
            }
            if (textboxintcenaopen.Text != "")
            {
                textboxintcenaopen.ToolTip = "";
                textboxintcenaopen.BorderBrush = Brushes.Transparent;
                pricevhod = Convert.ToInt32(textboxintcenaopen.Text.Trim());
            }
            else
            {
                textboxintcenaopen.ToolTip = "поле не должно быть пустым";
                textboxintcenaopen.BorderBrush = Brushes.DarkRed;
            }            
            if (textboxintcenaopt.Text != "")
            {
                textboxintcenaopt.ToolTip = "";
                textboxintcenaopt.BorderBrush = Brushes.Transparent;
                priceopt = Convert.ToInt32(textboxintcenaopt.Text.Trim());
            }
            else
            {
                textboxintcenaopt.ToolTip = "поле не должно быть пустым";
                textboxintcenaopt.BorderBrush = Brushes.DarkRed;
            }
            if (textboxintcena.Text != "")
            {
                textboxintcena.ToolTip = "";
                textboxintcena.BorderBrush = Brushes.Transparent;
                price = Convert.ToInt32(textboxintcena.Text.Trim());
            }
            else
            {
                textboxintcena.ToolTip = "поле не должно быть пустым";
                textboxintcena.BorderBrush = Brushes.DarkRed;
            }

            if (textboxName.Text != "")
            {
                textboxName.ToolTip = "";
                textboxName.BorderBrush = Brushes.Transparent;                
            }
            else
            {
                textboxName.ToolTip = "поле не должно быть пустым";
                textboxName.BorderBrush = Brushes.DarkRed;
            }

            if (oDataRowView != null)
            {
                textboxNamecat.ToolTip = "";
                textboxNamecat.BorderBrush = Brushes.Transparent;
                if (oDataRowView1 != null)
                {
                    textboxNamepodcat.ToolTip = "";
                    textboxNamepodcat.BorderBrush = Brushes.Transparent;
                    if (textboxintcol.Text != "" && textboxintcenaopen.Text != "" && textboxintcenaopt.Text != "" && textboxintcena.Text != "" && textboxName.Text != "")
                    {                        
                        cat = oDataRowView.Row["cat"] as string;
                        podcat = oDataRowView1.Row["podcat"] as string;
                        DB db = new DB();
                        MySqlCommand command = new MySqlCommand("INSERT INTO `price` (`categories`, `podcategories`, `name`, `info`, `ostatok`, `price`, `priceopt`, `pricevhod`) VALUES (@cat, @podcat, @name, @info, @col, @pr, @pro, @prv)", db.getConnection());
                        command.Parameters.Add("@cat", MySqlDbType.VarChar).Value = cat;
                        command.Parameters.Add("@podcat", MySqlDbType.VarChar).Value = podcat;
                        command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                        command.Parameters.Add("@info", MySqlDbType.VarChar).Value = info;
                        command.Parameters.Add("@col", MySqlDbType.VarChar).Value = col;
                        command.Parameters.Add("@pr", MySqlDbType.VarChar).Value = price;
                        command.Parameters.Add("@pro", MySqlDbType.VarChar).Value = priceopt;
                        command.Parameters.Add("@prv", MySqlDbType.VarChar).Value = pricevhod;
                        if (col >= 0 && price >= 0 && priceopt >= 0 && pricevhod >= 0)
                        {
                            db.openConnection();
                            if (command.ExecuteNonQuery() == 1)
                            {
                                MessageBox.Show("Товар добавлен!");
                            }
                            else
                            {
                                MessageBox.Show("Ошибка! Товар не добавлен");
                            }
                            db.closeConnection();
                        }
                        else
                        {
                            MessageBox.Show("поля название количество, и цены не должны быть пустые!" +
                                "Если товара нет в наличии либо вы не знаете цен, можете поставить 0.");
                        }
                    }
                }
                else
                {                   
                    textboxNamepodcat.ToolTip = "поле подкатегории не должно быть пустым";
                    textboxNamepodcat.BorderBrush = Brushes.DarkRed;
                }
            }
            else
            {
                textboxNamecat.ToolTip = "поле категории не должно быть пустым";
                textboxNamecat.BorderBrush = Brushes.DarkRed;
            }
        }
    }
}
