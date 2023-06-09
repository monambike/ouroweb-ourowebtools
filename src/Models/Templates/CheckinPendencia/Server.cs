using Common.Server;
using System.Linq;

namespace Common.Models
{
    public static partial class Template
    {
        public partial class CheckinPendencia : Base
        {
            public InnerTemplate GetCheckinTemplate(int pendenciaId)
            {
                using (var dataContext = Connection.GetSelectedConnectionString())
                {
                    var pendencias = dataContext.GetTable<Table.Pendencia>();
                    var requisitos = dataContext.GetTable<Table.Requisito>();

                    var clienteProdutoAplicativos = dataContext.GetTable<Table.ClienteProdutoAplicativo>();
                    var produtoAplicativos = dataContext.GetTable<Table.ProdutoAplicativo>();
                    var aplicativos = dataContext.GetTable<Table.Aplicativo>();
                    var versoes = dataContext.GetTable<Table.Versao>();
                    var subVersoes = dataContext.GetTable<Table.SubVersao>();

                    var query =
                        from pendencia in pendencias
                        join requisito in requisitos on pendencia
                            .Id equals requisito.FkPendenciaId

                        join clienteProdutoAplicativo in clienteProdutoAplicativos on pendencia
                            .FkClienteProdutoAplicativoId equals clienteProdutoAplicativo.Id
                        join produtoAplicativo in produtoAplicativos on clienteProdutoAplicativo
                            .FkProdutoAplicativoId equals produtoAplicativo.Id
                        join aplicativo in aplicativos on produtoAplicativo
                            .FkAplicativoId equals aplicativo.Id
                        join versao in versoes on pendencia
                            .FkVersaoId equals versao.Id
                        //join subVersao in subVersoes on versao
                        //    .Id equals subVersao.FkVersaoId
                        where pendencia.Id == pendenciaId
                        select new InnerTemplate
                        {
                            Id = pendencia.Id,
                            Assunto = pendencia.Assunto,
                            Aplicativo = new InnerTemplate.InnerAplicativo { Nome = aplicativo.Nome },
                            Versao = new InnerTemplate.InnerVersao { Numero = $"{versao.Numero.Trim()}" },
                            Requisitos = requisitos
                                .Where(row => row.Id == requisito.Id)
                                .Select(row => new InnerTemplate.InnerRequisito { Id = row.Id, Assunto = row.Assunto })
                                .ToList()
                        };

                    var result = query.FirstOrDefault();

                    return result;
                }
            }
        }
    }
}
