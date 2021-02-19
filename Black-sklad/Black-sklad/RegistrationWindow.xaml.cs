using MySql.Data.MySqlClient;
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

namespace Black_sklad
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = textboxlogin.Text.Trim();
            string pass = passbox.Password.Trim();
            string pass2 = passbox2.Password.Trim();
            string key = passboxperskey.Password.Trim();
            string email = textboxemail.Text.Trim().ToLower();
            

            if (login.Length < 5)
                {
                    textboxlogin.ToolTip = "В поле логин должно быть не менее 5 символов";
                    textboxlogin.Background = Brushes.MediumPurple;
                }
                else
                {
                    textboxlogin.ToolTip = "";
                    textboxlogin.Background = Brushes.Transparent;
                }
                if (pass.Length < 8)
                {
                    passbox.ToolTip = "В поле пароль должно быть не менее 8 символов";
                    passbox.Background = Brushes.MediumPurple;
                }
                else
                {
                    passbox.ToolTip = "";
                    passbox.Background = Brushes.Transparent;
                }
                if (pass != pass2)
                {
                    passbox2.ToolTip = "Пароли не совпадают";
                    passbox2.Background = Brushes.MediumPurple;
                }
                else
                {
                    passbox2.ToolTip = "";
                    passbox2.Background = Brushes.Transparent;
                }
                if (key.Length < 16 || key != "qwertyui12345678")
                {
                    passboxperskey.ToolTip = "Не верный ключ. Вы можете приобрести ключ, email для связи orel260992@iclod.com";
                    passboxperskey.Background = Brushes.MediumPurple;
                }
                else
                {
                    passboxperskey.ToolTip = "";
                    passboxperskey.Background = Brushes.Transparent;
                }
                if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
                {
                    textboxemail.ToolTip = "Введите настоящий email";
                    textboxemail.Background = Brushes.MediumPurple;
                }
                else
                {
                    textboxemail.ToolTip = "";
                    textboxemail.Background = Brushes.Transparent;
                }
            
            if (login.Length >= 5 && pass.Length >= 8 && pass == pass2 && key.Length == 16 && key == "qwertyui12345678" && email.Length >= 5 && email.Contains("@") && email.Contains("."))
            {
                textboxlogin.ToolTip = "";
                textboxlogin.Background = Brushes.Transparent;
                passbox.ToolTip = "";
                passbox.Background = Brushes.Transparent;
                passbox2.ToolTip = "";
                passbox2.Background = Brushes.Transparent;
                passboxperskey.ToolTip = "";
                passboxperskey.Background = Brushes.Transparent;
                textboxemail.ToolTip = "";
                textboxemail.Background = Brushes.Transparent;
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("INSERT INTO `reg` (`login`, `pass`, `passkey`, `email`) VALUES (@login, @pass, @passkey, @email)", db.getConnection());
                command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;
                command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = pass;
                command.Parameters.Add("@passkey", MySqlDbType.VarChar).Value = key;
                command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
                db.openConnection();
                if(command.ExecuteNonQuery() == 1)
                    {
                    MessageBox.Show("Регистрация прошла успешно. Приятного пользования!");
                    Window_Job window_Job = new Window_Job();
                    window_Job.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Регистрация не завершина. повторите попытку позже!");
                }
                db.closeConnection();
                
            }
        }

        private void Button_Window_Add_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }
    }
}
