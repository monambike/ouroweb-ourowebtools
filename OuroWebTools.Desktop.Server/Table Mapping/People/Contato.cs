using System.Data.Linq.Mapping;

namespace Common.Server
{
    public static partial class Table
    {
        [Table(Name = "Contato")]
        public class Contato
        {
            [Column(IsPrimaryKey = true, Name = "pk_int_Contato")]
            public int Id { get; set; }

            [Column(IsPrimaryKey = true, Name = "str_Nome")]
            public string Nome { get; set; }
        }
    }
}
