using System.Data.Linq.Mapping;

namespace Common.Server
{
    public static partial class Table
    {
        [Table(Name = "UsuariosSolicitantes")]
        public class Solicitante
        {
            [Column(IsPrimaryKey = true, Name = "IdUsuario")]
            public int Id { get; set; }

            [Column(Name = "PrimeiroNome")]
            public string Nome { get; set; }
        }
    }
}
