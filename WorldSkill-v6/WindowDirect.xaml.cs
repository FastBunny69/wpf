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
    /// Логика взаимодействия для WindowDirect.xaml
    /// </summary>
    public partial class WindowDirect : Window
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=311-20-20;Initial Catalog=world-users;Integrated Security=True");
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public WindowDirect()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {         
        }
    }
}
