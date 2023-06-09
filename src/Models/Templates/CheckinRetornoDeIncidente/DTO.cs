using System.Collections.Generic;

namespace Common.Models
{
    public static partial class Template
    {
        public partial class CheckinRetornoDeIncidente : Base
        {
            public class InnerTemplate
            {
                public InnerProjetoTeste ProjetoTeste { get; set; }

                public InnerPendencia Pendencia { get; set; }

                public List<InnerRetornoDeIncidente> RetornoDeIncidentes { get; set; }

                public class InnerPendencia
                {
                    public int Id { get; set; }

                    public string Assunto { get; set; }
                }

                public class InnerRetornoDeIncidente
                {
                    public int Id { get; set; }

                    public string Assunto { get; set; }
                }

                public class InnerProjetoTeste
                {
                    public string Assunto { get; set; }
                }
            }
        }
    }
}
