using Common.Server;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace OuroWebTools.Desktop.ViewModels
{
    internal partial class ConnectionStringViewModel : NotifyPropertyChanged
    {
        //xmlns:properties="clr-namespace:TestSettings.Properties"
        //{x:Static properties:Settings.Default}
        //{Binding Source = { x:Static properties:Settings.Default }, Path = Names}

        private static Settings.ConfigFile ConfigFileSettings => Settings.ConfigFile.Default;

        private ObservableCollection<string> avaiableInstances;
        internal ObservableCollection<string> AvaiableInstances
        {
            get => avaiableInstances;
            set { avaiableInstances = value; OnPropertyChanged("AvaiableInstances"); }
        }

        private string selectedInstance;
        internal string SelectedInstance
        {
            get => selectedInstance;
            set { selectedInstance = value; savedInstances?.Add(value); OnPropertyChanged("SelectedInstance"); }
        }

        private string selectedDatabase;
        internal string SelectedDatabase
        {
            get => selectedDatabase;
            set { selectedDatabase = value; savedDatabases?.Add(value); OnPropertyChanged("SelectedDatabase"); }
        }

        private ObservableCollection<string> savedInstances;
        internal ObservableCollection<string> SavedInstances
        {
            get => savedInstances;
            set { savedInstances = value ?? new ObservableCollection<string>(); OnPropertyChanged("SavedInstances"); }
        }

        private ObservableCollection<string> savedDatabases;
        internal ObservableCollection<string> SavedDatabases
        {
            get => savedDatabases;
            set { savedDatabases = value ?? new ObservableCollection<string>(); OnPropertyChanged("SavedDatabases"); }
        }

        internal void LoadAllInstancesAndDatabases()
        {
            SavedInstances = new ObservableCollection<string>();
            //var teste = ConnectionStringsSettings.SelectedInstancesSetting;

            FillServerInstancesComboBoxAsync();
        }

        internal async void FillServerInstancesComboBoxAsync()
        {
            List<string> listOfServerInstances = new List<string>();
            await Task.Run(() => { listOfServerInstances = ServerRequisitions.Sql.GetAvaiableSqlServerInstancesAsListStringAsync().Result; });

            var selectedInstancesAsObservableCollection = new ObservableCollection<string>();
            
            if (ConfigFileSettings.ConnectionStringsInstance != null)
            {
                var selectedInstancesAsList = ConfigFileSettings.ConnectionStringsInstance.Instances.Cast<string>().ToList();

                selectedInstancesAsObservableCollection = new ObservableCollection<string>(selectedInstancesAsList);
            }

            SavedInstances = selectedInstancesAsObservableCollection;
            AvaiableInstances = new ObservableCollection<string>(listOfServerInstances); ;
        }

        internal static void AddInstance(string instanceName)
        {
            ConfigFileSettings.ConnectionStringsInstance.AddInstanceIfNotExists(instanceName);
            ConfigFileSettings.Save();
        }
        
        internal static void AddDatabase(string databaseName, string instanceName)
        {
            ConfigFileSettings.ConnectionStringsInstance.AddDatabaseIfNotExists(databaseName, instanceName);
            ConfigFileSettings.Save();
        }

        internal static void RemoveInstance(string instanceName)
        {
            ConfigFileSettings.ConnectionStringsInstance.RemoveInstance(instanceName);
            ConfigFileSettings.Save();
        }

        internal static void RemoveDatabaseFromList(string databaseName, string instanceName)
        {
            ConfigFileSettings.ConnectionStringsInstance.RemoveDatabaseAtInstance(databaseName, instanceName);
            ConfigFileSettings.Save();
        }
    }
}
