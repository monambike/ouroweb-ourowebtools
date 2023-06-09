using System.Data.Linq.Mapping;

namespace Common.Server
{
    public static partial class Table
    {
        [Table(Name = "Produto")]
        public class Produto
        {
            [Column(Name = "pk_int_id_Produto")]
            public int Id { get; set; }

            [Column(Name = "str_Produto")]
            public string Nome { get; set; }
        }
    }
}