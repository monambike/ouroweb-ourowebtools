using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace OuroWebTools.Desktop.Views.Settings.ConfigFiles
{
    public partial class ConnectionString : UserControl
    {
        public List<string> Servers { get; set; }

        public List<string> Databases { get; set; }

        public ConnectionString()
        {
            InitializeComponent();

            _ = SetSqlServerInstancesToComboBoxItemsSourceAsync();
        }

        public async Task SetSqlServerInstancesToComboBoxItemsSourceAsync()
        {
            Servers = await Common.Server.ServerRequisitions.Sql.GetAvaiableSqlServerInstancesAsListStringAsync();
            clbConnectionStrings.ComboBoxItemsSource = Servers;

        }

        private void ConnectionStrings_ComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedInstance = e.AddedItems[0].ToString();

            Databases = Common.Server.ServerRequisitions.Sql.GetDatabasesAsListString(selectedInstance);
            clbDatabases.ComboBoxItemsSource = Databases;
        }
    }
}
