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
using System.Data.SqlClient;
using System.Data;

namespace WorldSkill_v6
{
    /// <summary>
    /// Логика взаимодействия для WindowZakaz.xaml
    /// </summary>
    public partial class WindowZakaz : Window
    {

        SqlConnection sqlConnection = new SqlConnection(@"Data Source=311-20-20;Initial Catalog=world-users;Integrated Security=True");
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        public WindowZakaz()
        {
            InitializeComponent();
            string String = $"select * from [Ткани]";
            SqlCommand command = new SqlCommand(String, sqlConnection);
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataBaseMenedger.ItemsSource = table.DefaultView;
        }

        private void dataBaseMenedger_SelectionChanged(object sender, SelectionChangedEventArgs e)
            { 
            }

            private void SaveButton_Click(object sender, RoutedEventArgs e)
            {

            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataBaseMenedger.ItemsSource = ds.Tables[0].DefaultView;
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
            adapter.Update(ds);
            ds.Clear();
            adapter.Fill(ds);
            dataBaseMenedger.ItemsSource = ds.Tables[0].DefaultView;

        }
        }
    }


