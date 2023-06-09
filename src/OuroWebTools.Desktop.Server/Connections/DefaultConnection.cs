using System.Data.Linq;

namespace Common.Server
{
    public static class Connection
    {
        private static Connections.ConnectionStrings ConnectionStrings => Connections.ConnectionStrings.Default;

        private static string SelectedConnectionString => ConnectionStrings.ProductionDatabase;

        public static DataContext GetSelectedConnectionString() => new DataContext(SelectedConnectionString);
    }
}
