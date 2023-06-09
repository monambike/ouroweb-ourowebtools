using System.Data.Linq.Mapping;

namespace Common.Server
{
    public static partial class Table
    {
        [Table(Name = "Requisito")]
        public class Usuario
        {
            [Column(IsPrimaryKey = true, Name = "IdUsuario")]
            public int Id { get; set; }

            [Column(Name = "PrimeiroNome")]
            public string Nome { get; set; }

            [Column(Name = "Senha")]
            public string Senha { get; set; }

            [Column(Name = "Email")]
            public string Email { get; set; }
        }
    }
}
