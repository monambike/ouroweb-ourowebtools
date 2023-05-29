using System.Data.Linq.Mapping;

namespace Common.Server
{
    public static partial class Table
    {
        [Table(Name = "Requisito")]
        public class Requisito
        {
            [Column(IsPrimaryKey = true, Name = "pk_int_Requisito")]
            public int Id { get; set; }

            [Column(Name = "str_Nome")]
            public string Assunto { get; set; }

            [Column(Name = "str_Descricao")]
            public string Descricao { get; set; }

            [Column(Name = "str_DescricaoTecnica")]
            public string DocumentacaoTecnica { get; set; }

            [Column(Name = "fk_int_Pendencia")]
            public int FkPendenciaId { get; set; }
        }
    }
}
