using System.Data.Linq.Mapping;

namespace Common.Server
{
    public static partial class Table
    {
        [Table(Name = "ProdutoAplicativo")]
        public class ProdutoAplicativo
        {
            [Column(IsPrimaryKey = true, Name = "pk_int_ProdutoAplicativo")]
            public int Id { get; set; }

            [Column(IsPrimaryKey = true, Name = "str_Nome")]
            public string Nome { get; set; }

            [Column(Name = "fk_int_Aplicativo")]
            public int FkAplicativoId { get; set; }

            [Column(Name = "fk_int_Produto")]
            public int FkProdutoId { get; set; }
        }
    }
}
