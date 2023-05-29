using System.Collections.Generic;

namespace Common.Models
{
    public static partial class Template
    {
        public partial class TaskNote : Base
        {
            public class InnerTemplate
            {
                public int Id { get; set; }

                public string Assunto { get; set; }

                public string Descricao { get; set; }

                public InnerSolicitante Solicitante { get; set; }

                public InnerCliente Cliente { get; set; }

                public InnerProdutoAplicativo ProdutoAplicativo { get; set; }

                public List<InnerRequisito> Requisitos { get; set; }

                public List<InnerRetornoDeIncidente> RetornoDeIncidentes { get; set; }

                public class InnerSolicitante
                {
                    public string Nome { get; set; }
                }

                public class InnerCliente
                {
                    public string Nome { get; set; }

                    public InnerContato Contato { get; set; }
                }

                public class InnerContato
                {
                    public string Nome { get; set; }
                }

                public class InnerProdutoAplicativo
                {
                    public string ProdutoAplicativoAsString => Produto.Nome + "/" + Aplicativo.Nome;

                    public InnerAplicativo Aplicativo { get; set; }

                    public InnerProduto Produto { get; set; }
                }

                public class InnerAplicativo
                {
                    public string Nome { get; set; }
                }

                public class InnerProduto
                {
                    public string Nome { get; set; }
                }

                public class InnerRequisito
                {
                    public int Id { get; set; }

                    public string Assunto { get; set; }

                    public string Descricao { get; set; }

                    public string DocumentacaoTecnica { get; set; }
                }

                public class InnerRetornoDeIncidente
                {
                    public int Id { get; set; }

                    public string Assunto { get; set; }

                    public string Descricao { get; set; }

                    public string Correcao { get; set; }
                }
            }
        }
    }
}
