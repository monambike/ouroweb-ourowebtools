using System.Data.Linq.Mapping;

namespace Common.Server
{
    public static partial class Table
    {
        [Table(Name = "Versao")]
        public class Versao
        {
            [Column(Name = "pk_int_Versao")]
            public int Id { get; set; }

            [Column(Name = "str_Versao")]
            public string Numero { get; set; }

            [Column(Name = "fk_int_Aplicativo")]
            public int FkAplicativoId { get; set; }
        }
    }
}
