using System;

namespace Common.Models
{
    public static partial class Template
    {
        public partial class CheckinRetornoDeIncidente : Base
        {
            private int PendenciaId { get; }

            private InnerTemplate Template { get; }

            public static new string TemplateName => "RI (Retorno de Incidente)";

            public CheckinRetornoDeIncidente(int pendenciaId)
            {
                PendenciaId = pendenciaId;

                Template = GetRetornoDeIncidenteTemplate(PendenciaId);
            }

            public override string GetTemplate()
            {
                var listaDeRetornoDeIncidentes = GetTemplateListOfRetornoDeIncidentesAsString();

                var template = string.Format(
                      $"{Template.ProjetoTeste.Assunto}" + "{0}"
                    + $"Pendência {Template.Pendencia.Id} - {Template.Pendencia.Assunto}"
                    + $"{listaDeRetornoDeIncidentes}"
                    , Environment.NewLine
                );

                return template;
            }

            private string GetTemplateListOfRetornoDeIncidentesAsString()
            {
                var result = "";

                Template.RetornoDeIncidentes.ForEach(
                    RetornoDeIncidente =>
                        result += $"{Environment.NewLine}" + $"RI  {RetornoDeIncidente.Id} - {RetornoDeIncidente.Assunto}"
                );

                return result;
            }
        }
    }
}
