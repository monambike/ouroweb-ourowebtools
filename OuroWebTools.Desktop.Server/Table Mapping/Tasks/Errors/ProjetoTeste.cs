using System.Data.Linq.Mapping;

namespace Common.Server
{
    public static partial class Table
    {
        [Table(Name = "ProjetoTeste")]
        public class ProjetoDeTeste
        {
            [Column(IsPrimaryKey = true, Name = "pk_int_ProjetoTeste")]
            public int Id { get; set; }

            [Column(Name = "str_Descricao")]
            public string Assunto { get; set; }
        }
    }
}
