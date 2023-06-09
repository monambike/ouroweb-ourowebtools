using System.Collections.Generic;
using System.Linq;

namespace Common.Server
{
    public class InstanceList
    {
        public List<Instance> Instances { get; set; }

        public void AddInstanceIfNotExists(string instanceName)
        {
            var instance = new Instance { Name = instanceName };

            if (!Instances.Contains(instance)) Instances.Add(instance);
        }

        public void AddDatabaseIfNotExists(string databaseName, string instanceName)
        {
            var allDatabasesCollection = GetAllDatabases();

            if (allDatabasesCollection.Contains(databaseName)) AddInstanceIfNotExists(instanceName);
        }

        public void RemoveInstance(string instanceName) => Instances.RemoveAll(instance => instance.Name == instanceName);

        public void RemoveDatabaseAtInstance(string databaseName, string instanceName)
        {
            var userChosenInstance = Instances.Find(instance => instance.Name == instanceName);

            userChosenInstance.Databases.RemoveAll(database => database.Name == databaseName);
        }

        public IEnumerable<string> GetAllDatabases() => Instances.SelectMany(instance => instance.Databases.Select(database => database.Name));
    }

    public class Instance
    {
        public string Name { get; set; }

        public List<Database> Databases { get; set; }

        public void Remove(string databaseName) => Databases.RemoveAll(instance => instance.Name == databaseName);
    }

    public class Database
    {
        public string Name { get; set; }

        public string Path { get; set; }
    }
}