using System.Collections.Generic;
using System.Windows.Controls;

namespace OuroWebTools.Desktop.Views.Settings
{
    public partial class CurrentWorkingOn : UserControl
    {
        public List<string> Pendencias { get; set; }

        public List<string> Versions { get; set; }

        public CurrentWorkingOn()
        {
            InitializeComponent();

            Pendencias = Common.Server.ServerRequisitions.FollowWeb.GetAllPendencias();
            txtTaskNumber.SuggestionItemSource = Pendencias;

            Versions = Common.Server.ServerRequisitions.FollowWeb.GetApplicationsVersionsAsListStringOrderedByDescending(Common.Server.ServerRequisitions.FollowWeb.ApplicationEnum.OuroNet);
            cmbVersion.ItemsSource = Versions;
        }
    }
}
