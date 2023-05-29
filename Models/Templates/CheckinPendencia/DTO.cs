using System.Collections.Generic;

namespace Common.Models
{
    public static partial class Template
    {
        public partial class CheckinPendencia : Base
        {
            public class InnerTemplate
            {
                public int Id { get; set; }

                public string Assunto { get; set; }

                public List<InnerRequisito> Requisitos { get; set; }

                public InnerAplicativo Aplicativo { get; set; }

                public InnerVersao Versao { get; set; }

                public class InnerRequisito
                {
                    public int Id { get; set; }

                    public string Assunto { get; set; }
                }

                public class InnerAplicativo { public string Nome { get; set; } }

                public class InnerVersao { public string Numero { get; set; } }
            }
        }
    }
}
