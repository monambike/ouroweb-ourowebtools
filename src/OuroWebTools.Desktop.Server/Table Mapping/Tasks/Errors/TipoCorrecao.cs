using System.Data.Linq.Mapping;

namespace Common.Server
{
    public static partial class Table
    {
        [Table(Name = "CasoTeste_TipoCorrecao")]
        public class TipoCorrecao
        {
            [Column(IsPrimaryKey = true, Name = "pk_int_TipoCorrecao")]
            public int Id { get; set; }

            [Column(IsPrimaryKey = true, Name = "str_Descricao")]
            public string Nome { get; set; }
        }
    }
}
