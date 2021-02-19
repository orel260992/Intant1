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
    /// Логика взаимодействия для warehous.xaml
    /// </summary>
    public partial class warehous : Page
    {
        DB db = new DB();
        DataTable tableprice;
        MySqlDataAdapter dataAdapter = null;        
        

        /*
         * <WrapPanel>
                                    <TextBlock Text="{Binding categories}" FontWeight="Bold" />
                                    <TextBlock Text=" " FontWeight="Bold" />
                                    <TextBlock Text="{Binding podcategories}" FontWeight="Bold" />
                                    <TextBlock Text=" " FontWeight="Bold" />
                                    <TextBlock Text="{Binding name}" FontWeight="Bold" />
                                    <TextBlock Text=" " FontWeight="Bold" />
                                    <TextBlock Text="{Binding info}" FontWeight="Bold" />
                                    <TextBlock Text=" " FontWeight="Bold" />
                                    <TextBlock Text="{Binding ostatok}" FontWeight="Bold" />
                                    <TextBlock Text=" " FontWeight="Bold" />
                                    <TextBlock Text="{Binding price}" FontWeight="Bold" />
                                    <TextBlock Text=" " FontWeight="Bold" />
                                    <TextBlock Text="{Binding priceopt}" FontWeight="Bold" />
                                    <TextBlock Text=" " FontWeight="Bold" />
                                    <TextBlock Text="{Binding pricevhod}" FontWeight="Bold" />                                    
                                </WrapPanel>
        */

        public warehous()
        {
            InitializeComponent();

            pricelist.IsReadOnly = true;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            pricelist.IsReadOnly = true;
            Add_Product add_Product = new Add_Product();
            add_Product.Show();
        }
        private void Button_Update_Click(object sender, RoutedEventArgs e)
        {
                pricelist.IsReadOnly = true;
                tableprice.Clear();
                dataAdapter.Fill(tableprice);
                pricelist.ItemsSource = tableprice.DefaultView;  
            
        }

        private void pricelist_Loaded(object sender, RoutedEventArgs e)
        {
            pricelist.IsReadOnly = true;
            tableprice = new DataTable();
            dataAdapter = new MySqlDataAdapter();            
            MySqlCommand command = new MySqlCommand("SELECT `categories` AS `Категория`, `podcategories` AS `Подкатегория`, `name` AS `Название`, `info` AS `Описание`, `ostatok` AS `Количество`, `price`AS `Цена розницы`, `priceopt`AS `Оптовая цена`, `pricevhod` AS `Входной ценник` FROM price", db.getConnection());            
            dataAdapter.SelectCommand = command;
            dataAdapter.Fill(tableprice);
            /* tableprice.Columns["categories"].ColumnName = "Категория";
            tableprice.Columns["podcategories"].ColumnName = "Подкатегория";
            tableprice.Columns["name"].ColumnName = "Название";
            tableprice.Columns["info"].ColumnName = "Описание";
            tableprice.Columns["ostatok"].ColumnName = "Количество";
            tableprice.Columns["price"].ColumnName = "Цена розницы";
            tableprice.Columns["priceopt"].ColumnName = "Оптовая цена";
            tableprice.Columns["pricevhod"].ColumnName = "Входной ценник";*/
            pricelist.ItemsSource = tableprice.DefaultView;
        }

        private void Button_Read_Click(object sender, RoutedEventArgs e)
        {
            pricelist.IsReadOnly = false;
        }
    }
}
