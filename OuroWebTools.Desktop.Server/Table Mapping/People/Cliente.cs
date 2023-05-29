using System.Data.Linq.Mapping;

namespace Common.Server
{
    public static partial class Table
    {
        [Table(Name = "Cliente")]
        public class Cliente
        {
            [Column(IsPrimaryKey = true, Name = "pk_int_Cliente")]
            public int Id { get; set; }

            [Column(IsPrimaryKey = true, Name = "str_NomeEmpresa")]
            public string Nome { get; set; }
        }
    }
}
