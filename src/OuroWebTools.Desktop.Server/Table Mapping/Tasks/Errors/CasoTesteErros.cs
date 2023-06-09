using System.Data.Linq.Mapping;

namespace Common.Server
{
    public static partial class Table
    {
        [Table(Name = "CasoTeste_Erros")]
        public class CasoDeTesteErros
        {
            [Column(IsPrimaryKey = true, Name = "pk_int_CasoTeste_Erros")]
            public int Id { get; set; }

            [Column(IsPrimaryKey = true, Name = "str_Nome")]
            public string Assunto { get; set; }

            [Column(Name = "fk_int_CasoTeste")]
            public int FkCasoDeTesteId { get; set; }
        }
    }
}
