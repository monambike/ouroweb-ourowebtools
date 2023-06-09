using Common.Utilities;
using System;
using System.Data.SqlClient;

namespace Common.Models.ScriptPackage
{
    public partial class ScriptPackage
    {
        public string Server { get; set; }

        public string Database { get; set; }


        private bool CanConnectToDatabase(string connectionString)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();

                    return true;
                }
                catch (Exception)
                {
                    Message.Custom.Error("Não foi possível se conectar ao banco de dados.");

                    return false;
                }
            }
        }

        private string GetDefaultCustomSoftwareConnectionString()
        {
            return
                 $"Server={Server};"
               + $"Database={Database};"
               + "User ID=ouro;"
               + "Password=nc7895al63;"
               + "Application Name=OuroWebTools";
        }
    }
}
