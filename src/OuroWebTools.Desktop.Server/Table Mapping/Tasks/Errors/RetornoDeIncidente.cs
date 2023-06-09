using System.Data.Linq.Mapping;

namespace Common.Server
{
    public static partial class Table
    {
        [Table(Name = "CasoTeste_Erros")]
        public class RetornoDeIncidente
        {
            [Column(IsPrimaryKey = true, Name = "pk_int_CasoTeste_Erros")]
            public int Id { get; set; }

            [Column(Name = "str_Nome")]
            public string Assunto { get; set; }

            [Column(IsPrimaryKey = true, Name = "str_DescricaoErro")]
            public string Descricao { get; set; }

            [Column(Name = "str_Base")]
            public string Base { get; set; }

            [Column(Name = "str_DescricaoCorrecao")]
            public string Correcao { get; set; }

            [Column(Name = "bit_Corrigido")]
            public string Corrigido { get; set; }

            [Column(Name = "fk_int_CasoTeste")]
            public int FkCasoTesteId { get; set; }

            [Column(Name = "fk_int_UsuarioCorrecao")]
            public int FkTipoCorrecaoId { get; set; }
        }
    }
}
