using System.Data.Linq.Mapping;

namespace Common.Server
{
    public static partial class Table
    {
        [Table(Name = "CasoTeste")]
        public class CasoDeTeste
        {
            [Column(IsPrimaryKey = true, Name = "pk_int_CasoTeste")]
            public int Id { get; set; }


            [Column(Name = "str_Descricao")]
            public string Assunto { get; set; }


            [Column(Name = "bit_corrigido")]
            public string Corrigido { get; set; }


            [Column(Name = "fk_int_TipoCorrecao")]
            public int FkTipoCorrecaoId { get; set; }


            [Column(Name = "int_UsuarioCorrecao")]
            public int FkUsuarioId { get; set; }

            [Column(Name = "int_pendencia")]
            public int FkPendenciaId { get; set; }
            [Column(Name = "fk_int_ProjetoTeste")]
            public int FkProjetoTesteId { get; set; }
        }
    }
}
