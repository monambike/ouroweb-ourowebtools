using System.Data.Linq.Mapping;

namespace Common.Server
{
    public static partial class Table
    {
        [Table(Name = "ClienteProdutoAplicativo")]
        public class ClienteProdutoAplicativo
        {
            [Column(Name = "pk_int_ClienteProdutoAplicativo")]
            public int Id { get; set; }

            [Column(Name = "fk_int_ProdutoAplicativo")]
            public int FkProdutoAplicativoId { get; set; }
        }
    }
}