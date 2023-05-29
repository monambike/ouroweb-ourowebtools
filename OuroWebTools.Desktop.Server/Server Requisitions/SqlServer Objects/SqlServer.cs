using Common.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Data.Sql;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Server
{
    public static partial class ServerRequisitions
    {
        public static class Sql
        {
            private static readonly List<string> SqlServerSistemDatabasesList =
                new List<string> { "master", "tempdb", "model", "msdb" };


            /// <summary>
            /// Gets a list of servers with its name and databases.
            /// </summary>
            /// <returns></returns>
            public static List<Instance> GetDatabases(List<string> serverNames)
            {
                var servers = new List<Instance>();

                foreach (var serverName in serverNames)
                {
                    var databases = GetDatabases(serverName);
                    var server = new Instance { Name = serverName, Databases = databases };

                    servers.Add(server);
                }
            
                return servers;
            }

            /// <summary>
            /// Gets a list of databases at determined server instance.
            /// </summary>
            public static List<Database> GetDatabases(string serverName)
            {
                var connectionString = $@"Server={serverName};Database=master;Trusted_Connection=True;";
                var databases = new List<Database>();

                try
                {
                    using (var dataContext = new DataContext(connectionString))
                    {
                        var sysDatabases = dataContext.GetTable<Table.SysDatabases>();

                        var query =
                            from sysDatabase in sysDatabases
                            where !SqlServerSistemDatabasesList.Contains(sysDatabase.Name)
                            select new Database
                            {
                                Name = sysDatabase.Name,
                                Path = sysDatabase.Path
                            };

                        databases = query.ToList();
                    }
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Messages.Custom.Error($@"Não foi possível obter as bases da instância ""{serverName}"". ");
                    Log.AppendToLogCustomText(Log.LogType.ERROR, $@"Não foi possível obter as bases do servidor ""{serverName}"".");
                }

                return databases;
            }

            public static List<string> GetDatabasesAsListString(string serverName)
            {
                var connectionString = $@"Server={serverName};Database=master;Trusted_Connection=True;";
                var databases = new List<string>();

                try
                {
                    using (var dataContext = new DataContext(connectionString))
                    {
                        var sysDatabases = dataContext.GetTable<Table.SysDatabases>();

                        var query =
                            from sysDatabase in sysDatabases
                            where !SqlServerSistemDatabasesList.Contains(sysDatabase.Name)
                            select sysDatabase.Name;

                        databases = query.ToList();
                    }
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Messages.Custom.Error($@"Não foi possível obter as bases da instância ""{serverName}"". ");
                    Log.AppendToLogCustomText(Log.LogType.ERROR, $@"Não foi possível obter as bases do servidor ""{serverName}"".");
                }

                databases = databases.OrderBy(database => database).ToList();
                return databases;
            }

            public static List<string> GetAvaiableSqlServerInstancesAsListString()
            {

                var avaiableServers = new List<string>();

                var sqlDataSourceEnumeratorInstance = SqlDataSourceEnumerator.Instance;
                var dataTable = sqlDataSourceEnumeratorInstance.GetDataSources();

                foreach (DataRow row in dataTable.Rows)
                {
                    var server = row[0];
                    var instanceWithSeparator = row[1] != DBNull.Value ? @"\" + row[1] : "";

                    avaiableServers.Add($"{server}{instanceWithSeparator}");
                }

                return avaiableServers;
            }

            public static async Task<List<string>> GetAvaiableSqlServerInstancesAsListStringAsync()
            {
                var avaiableServers = new List<string>();

                await Task.Run(() => { avaiableServers = GetAvaiableSqlServerInstancesAsListString(); });
                avaiableServers = avaiableServers.OrderBy(avaiableServer => avaiableServer).ToList();

                return avaiableServers;
            }
        }
    }
}
