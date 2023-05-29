using Common.Server;
using System.Linq;

namespace Common.Models
{
    public static partial class Template
    {
        public partial class CheckinRetornoDeIncidente : Base
        {
            public InnerTemplate GetRetornoDeIncidenteTemplate(int pendenciaId)
            {
                using (var dataContext = Connection.GetSelectedConnectionString())
                {
                    var pendencias = dataContext.GetTable<Table.Pendencia>();

                    var projetoDeTestes = dataContext.GetTable<Table.ProjetoDeTeste>();
                    var casoDeTestes = dataContext.GetTable<Table.CasoDeTeste>();
                    var casoDeTesteErros = dataContext.GetTable<Table.CasoDeTesteErros>();

                    var retornoDeIncidentes = dataContext.GetTable<Table.RetornoDeIncidente>();

                    var query =
                        from pendencia in pendencias

                        join projetoTeste in projetoDeTestes on pendencia
                            .FkProjetoTesteId equals projetoTeste.Id
                        join casoDeTeste in casoDeTestes on pendencia
                            .Id equals casoDeTeste.FkPendenciaId
                        join casoDeTesteErro in casoDeTesteErros on casoDeTeste
                            .Id equals casoDeTesteErro.FkCasoDeTesteId

                        where pendencia.Id == pendenciaId
                        select new InnerTemplate
                        {
                            Pendencia = new InnerTemplate.InnerPendencia { Id = pendencia.Id, Assunto = pendencia.Assunto },
                            ProjetoTeste = new InnerTemplate.InnerProjetoTeste { Assunto = projetoTeste.Assunto },

                            RetornoDeIncidentes = retornoDeIncidentes
                                .Where(row => row.Id == casoDeTesteErro.Id)
                                .Select(
                                    row => new InnerTemplate.InnerRetornoDeIncidente
                                    {
                                        Id = row.Id,
                                        Assunto = row.Assunto
                                    }
                                )
                                .ToList()
                        };

                    var result = query.FirstOrDefault();
                    return result;
                }
            }
        }
    }
}
