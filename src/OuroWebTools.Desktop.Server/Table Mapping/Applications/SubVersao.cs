using System.Data.Linq.Mapping;

namespace Common.Server
{
    public static partial class Table
    {
        [Table(Name = "SubVersao")]
        public class SubVersao
        {
            [Column(Name = "pk_int_SubVersao")]
            public int Id { get; set; }

            [Column(Name = "int_SubVersao")]
            public string Numero { get; set; }

            [Column(Name = "fk_int_Versao")]
            public int FkVersaoId { get; set; }
        }
    }
}

