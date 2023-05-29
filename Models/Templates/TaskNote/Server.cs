using Common.Server;
using System.Linq;

namespace Common.Models
{
    public static partial class Template
    {
        public partial class TaskNote : Base
        {
            public InnerTemplate GetTaskNoteTemplate(int pendenciaId)
            {
                using (var dataContext = Connection.GetSelectedConnectionString())
                {
                    var pendencias = dataContext.GetTable<Table.Pendencia>();
                    var requisitos = dataContext.GetTable<Table.Requisito>();

                    var solicitantes = dataContext.GetTable<Table.Solicitante>();
                    var clientes = dataContext.GetTable<Table.Cliente>();
                    var contatos = dataContext.GetTable<Table.Contato>();

                    var casoDeTestes = dataContext.GetTable<Table.CasoDeTeste>();
                    var retornoDeIncidentes = dataContext.GetTable<Table.RetornoDeIncidente>();

                    var clienteProdutoAplicativos = dataContext.GetTable<Table.ClienteProdutoAplicativo>();
                    var produtoAplicativo = dataContext.GetTable<Table.ProdutoAplicativo>();
                    var aplicativos = dataContext.GetTable<Table.Aplicativo>();
                    var produtos = dataContext.GetTable<Table.Produto>();

                    var query =
                        from tablePendencia in pendencias
                        join tableRequisito in requisitos on tablePendencia
                            .Id equals tableRequisito.FkPendenciaId

                        join tableSolicitante in solicitantes on tablePendencia
                            .FkSolicitanteId equals tableSolicitante.Id into tableSolicitanteJoinTable
                        from tableSolicitanteLeftJoin in tableSolicitanteJoinTable.DefaultIfEmpty()
                        join tableCliente in clientes on tablePendencia
                            .FkClienteId equals tableCliente.Id
                        join tableContato in contatos on tablePendencia
                            .FkContatoId equals tableContato.Id

                        join tableCasoDeTeste in casoDeTestes on tablePendencia
                            .Id equals tableCasoDeTeste.FkPendenciaId
                        join tableRetornoDeIncidente in retornoDeIncidentes on tableCasoDeTeste
                            .Id equals tableRetornoDeIncidente.FkCasoTesteId

                        join tableClienteProdutoAplicativo in clienteProdutoAplicativos on tablePendencia
                            .FkClienteProdutoAplicativoId equals tableClienteProdutoAplicativo.Id
                        join tableProdutoAplicativo in produtoAplicativo on tableClienteProdutoAplicativo
                            .FkProdutoAplicativoId equals tableProdutoAplicativo.Id
                        join tableAplicativo in aplicativos on tableProdutoAplicativo
                            .FkAplicativoId equals tableAplicativo.Id
                        join tableProduto in produtos on tableProdutoAplicativo
                            .FkProdutoId equals tableProduto.Id

                        where tablePendencia.Id == pendenciaId
                        select new InnerTemplate
                        {
                            Id = tablePendencia.Id,
                            Assunto = tablePendencia.Assunto,
                            Descricao = tablePendencia.Descricao,
                            Solicitante = new InnerTemplate.InnerSolicitante { Nome = tableSolicitanteLeftJoin.Nome },
                            Cliente = new InnerTemplate.InnerCliente
                            {
                                Nome = tableCliente.Nome,
                                Contato = new InnerTemplate.InnerContato { Nome = tableContato.Nome }
                            },
                            ProdutoAplicativo = new InnerTemplate.InnerProdutoAplicativo
                            {
                                Aplicativo = new InnerTemplate.InnerAplicativo { Nome = tableAplicativo.Nome },
                                Produto = new InnerTemplate.InnerProduto { Nome = tableProduto.Nome }
                            },
                            Requisitos = requisitos
                                .Where(requisito => requisito.Id == tableRequisito.Id)
                                .Select(
                                    row => new InnerTemplate.InnerRequisito
                                    {
                                        Id = row.Id,
                                        Assunto = row.Assunto,
                                        Descricao = row.Descricao,
                                        DocumentacaoTecnica = row.DocumentacaoTecnica
                                    }
                                ).ToList(),
                            RetornoDeIncidentes = retornoDeIncidentes
                                .Where(retornoDeIncidente => retornoDeIncidente.Id == tableRetornoDeIncidente.Id)
                                .Select(
                                    row => new InnerTemplate.InnerRetornoDeIncidente
                                    {
                                        Id = row.Id,
                                        Assunto = row.Assunto,
                                        Descricao = row.Descricao,
                                        Correcao = row.Correcao
                                    }
                                ).ToList()
                        };

                    var result = query.FirstOrDefault();

                    return result;
                }
            }
        }
    }
}
