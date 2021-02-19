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
using Black_sklad.vivemodels;

namespace Black_sklad
{
    /// <summary>
    /// Логика взаимодействия для Window_Job.xaml
    /// </summary>
    public partial class Window_Job : Window
    {
        public Window_Job()
        {
            InitializeComponent();
            DataContext = new viewmodels();
        }

        private void Button_User_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Hide();
        }
    }
}
