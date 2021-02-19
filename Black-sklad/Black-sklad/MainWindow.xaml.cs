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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Black_sklad
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Auts_Click(object sender, RoutedEventArgs e)
        {
            string loginUser = autlogin.Text;
            string passUser = autpass.Password;

            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM reg WHERE login = @uL AND pass = @uP", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUser;
            db.openConnection();
            dataAdapter.SelectCommand = command;
            dataAdapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                MessageBox.Show($"Вход выполнен. Приятного пользования!");
                Window_Job window_Job = new Window_Job();
                window_Job.Show();
                Hide();
            }
            else
            {
            MessageBox.Show($"Вход не выполнен. Логин или пароль введён не верно!");
            }
            db.closeConnection();
        }

        private void Button_Window_Reg_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            Hide();
        }
    }
}
