using System;

namespace Common.Models
{
    public static partial class Template
    {
        public partial class CheckinPendencia : Base
        {
            private int PendenciaId { get; }

            private InnerTemplate Template { get; }

            public static new string TemplateName => "Checkin";

            public CheckinPendencia(int pendenciaId)
            {
                PendenciaId = pendenciaId;

                Template = GetCheckinTemplate(PendenciaId);
            }

            public override string GetTemplate()
            {
                var listaDeRequisitos = ListOfRequisitosAsString();

                return string.Format(
                      $"Pendência {Template.Id} - {Template.Assunto}"
                    + $"{listaDeRequisitos}" + "{0}"
                    + $"Versão {Template.Aplicativo.Nome} {Template.Versao.Numero}"
                    , Environment.NewLine
                );
            }

            private string ListOfRequisitosAsString()
            {
                var result = "";

                Template.Requisitos.ForEach(
                    requisito =>
                        result += $"{Environment.NewLine}" + $"Requisito {requisito.Id} - {requisito.Assunto}"
                );

                return result;
            }
        }
    }
}
