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
using System.Data.SqlClient;
using System.Data;

namespace WorldSkill_v6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=311-20-20;Initial Catalog=world-users;Integrated Security=True");
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable tableDirect = new DataTable();
        DataTable tableZakaz = new DataTable();
        DataTable tableKlad = new DataTable();
        DataTable tableMenedger = new DataTable();
        

        public MainWindow()
        {
            InitializeComponent();
        }

        private void enter_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand command;
            string directString = $"select [Логин], [Пароль] from [Пользователь] where [Логин] = '{login.Text}' and [Пароль] = '{password.Password}' and [Роль] = '{roly.Text}'";
            string zakazString = $"select [Логин], [Пароль] from [Пользователь] where [Логин] = '{login.Text}' and [Пароль] = '{password.Password}' and [Роль] = '{roly.Text}'";
            string kladString = $"select [Логин], [Пароль] from [Пользователь] where [Логин] = '{login.Text}' and [Пароль] = '{password.Password}' and [Роль] = '{roly.Text}'";
            string menedgerString = $"select [Логин], [Пароль] from [Пользователь] where [Логин] = '{login.Text}' and [Пароль] = '{password.Password}' and [Роль] = '{roly.Text}'";
            command = new SqlCommand(directString, sqlConnection);
            adapter.SelectCommand = command;
            adapter.Fill(tableDirect);
            command = new SqlCommand(zakazString, sqlConnection);
            adapter.SelectCommand = command;
            adapter.Fill(tableZakaz);
          //  command = new SqlCommand(kladString, sqlConnection);
         //   adapter.SelectCommand = command;
         //  adapter.Fill(tableKlad);
            command = new SqlCommand(menedgerString, sqlConnection);
           adapter.SelectCommand = command;
            adapter.Fill(tableMenedger);

            if (password.Password == "" & login.Text == "" )
            {
                MessageBox.Show("Ошибка : не введен логин или пароль");
            }

            else if (tableDirect.Rows.Count == 1 & roly.Text == "директор")
            {
                WindowDirect windowDirect = new WindowDirect();
                windowDirect.Show();
                this.Hide();
            }

            else if (tableDirect.Rows.Count == 1 & roly.Text == "заказчик")
            {
                WindowZakaz windowZakaz = new WindowZakaz();
                windowZakaz.Show();
                this.Hide();
            }

            else if (tableKlad.Rows.Count == 1)
            {
                WindowKlad windowKlad = new WindowKlad();
                windowKlad.Show();
                this.Hide();
            }

            else if (tableMenedger.Rows.Count == 1 & roly.Text == "менеджер")
            {
                WindowMenedger windowMenedger = new WindowMenedger();
                windowMenedger.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неправильно введен логин или пароль");
            }
            
        }
    }
}
