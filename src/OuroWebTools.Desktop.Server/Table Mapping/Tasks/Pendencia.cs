using System.Data.Linq.Mapping;

namespace Common.Server
{
    public static partial class Table
    {
        [Table(Name = "Pendencias")]
        public class Pendencia
        {
            [Column(IsPrimaryKey = true, Name = "IdPendencia")]
            public int Id { get; set; }

            [Column(Name = "Assunto")]
            public string Assunto { get; set; }

            [Column(Name = "DetalhePendencia")]
            public string Descricao { get; set; }

            [Column(Name = "IdUsuarioDig")]
            public int FkContatoId { get; set; }

            [Column(Name = "fk_int_Cliente")]
            public int FkClienteId { get; set; }

            [Column(Name = "fk_int_Solicitante")]
            public int FkSolicitanteId { get; set; }

            /// <summary>
            /// O nome dessa coluna está errada no banco de dados, porém o mapeamento está correto.
            /// </summary>
            [Column(Name = "fk_int_ProdutoAplicativo")]
            public int FkClienteProdutoAplicativoId { get; set; }

            [Column(Name = "fk_int_Versao")]
            public int FkVersaoId { get; set; }

            [Column(Name = "fk_int_ProjetoTeste")]
            public int FkProjetoTesteId { get; set; }
        }
    }
}
