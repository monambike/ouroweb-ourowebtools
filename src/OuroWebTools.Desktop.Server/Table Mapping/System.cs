using System.Data.Linq.Mapping;

namespace Common.Server
{
    public static partial class Table
    {
        [Table(Name = "sysdatabases")]
        public class SysDatabases
        {
            [Column(Name = "dbid")]
            public int Id { get; set; }

            [Column(Name = "name")]
            public string Name { get; set; }

            [Column(Name = "filename")]
            public string Path { get; set; }
        }
    }
}
