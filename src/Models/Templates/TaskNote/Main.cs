using System;
using System.Collections.Generic;

namespace Common.Models
{
    public static partial class Template
    {
        public partial class TaskNote : Base
        {
            private int PendenciaId { get; }

            private InnerTemplate Template { get; }

            public static new string TemplateName => "Nota de Pendência";

            public TaskNote(int pendenciaId)
            {
                PendenciaId = pendenciaId;

                Template = GetTaskNoteTemplate(PendenciaId);
            }

            public override string GetTemplate()
            {
                return string.Format(
                    GetTemplateCabecalhoAstring()
                    + "{0}" + "## INFORMAÇÕES IMPORTANTES"
                    + "{0}" + GetTemplateInformacoesPrincipaisDaPendenciaAsString()
                    + "{0}" + GetTemplateDetalhesDaPendenciaAsString()
                    + "{0}" + GetTemplateConteudosDesenvolvidosAsString()
                    + "{0}" + "## REQUISITOS"
                    + "{0}" + GetTemplateRequisitosAsString()
                    + "{0}" + "## RETORNOS DE INCIDENTE"
                    + "{0}" + GetTemplateRetornosDeIncidenteAsString()
                    , Environment.NewLine
                );
            }

            private string GetTemplateCabecalhoAstring()
            {
                return string.Format(
                    "# {1} - ({2}) {3}"
                    + "{0}" + "```"
                    + "{0}" + "{4}"
                    + "{0}" + "```"
                    , Environment.NewLine
                    , Template.Id.ToString()
                    , Template.Solicitante.Nome
                    , Template.Assunto
                    , Template.Descricao
                ).ToUpper();
            }

            private string GetTemplateInformacoesPrincipaisDaPendenciaAsString()
            {
                return string.Format(
                    "### Informações Principais da Pendência"
                    + "{0}"
                    + "{0}" + "| Tipo        | Descrição |"
                    + "{0}" + "| ----------- | --------- |"
                    + "{0}" + "| Pendência   | {1}       |"
                    + "{0}" + "| Solicitante | {2}       |"
                    + "{0}" + "| Assunto     | {3}       |"
                    , Environment.NewLine
                    , Template.Id
                    , Template.Solicitante.Nome
                    , Template.Assunto
                );
            }

            private string GetTemplateDetalhesDaPendenciaAsString()
            {
                return string.Format(
                    "### Detalhes da Pendência"
                    + "{0}"
                    + "{0}" + "| Tipo               | Descrição |"
                    + "{0}" + "| ------------------ | --------- |"
                    + "{0}" + "| Cliente            | {1}       |"
                    + "{0}" + "| Contato            | {2}       |"
                    + "{0}" + "| Produto/Aplicativo | {3}       |"
                    , Environment.NewLine
                    , Template.Cliente.Nome
                    , Template.Cliente.Contato.Nome
                    , Template.ProdutoAplicativo.ProdutoAplicativoAsString
                );
            }

            private string GetTemplateConteudosDesenvolvidosAsString()
            {
                return string.Format(
                    "### Conteúdos Desenvolvidos"
                    + "{0}"
                    + "{0}" + "|     Dia      |  Hora   |   Descrição   |"
                    + "{0}" + "| ------------ | ------- | ------------- |"
                    + "{0}" + "| [dd/MM/yyyy] | [hh:mm] | [description] |"
                    , Environment.NewLine
                );
            }

            private string GetTemplateRequisitosAsString()
            {
                var result = "";

                Template.Requisitos.ForEach(
                    requisito =>
                        result += string.Format(
                            "### {1} - {2}"
                            + "{0}"
                            + "{0}" + "#### Descrição"
                            + "{0}" + "{3}"
                            + "{0}" + "#### Documentação Técnica"
                            + "{0}" + "{4}"
                            + "{0}"
                            , Environment.NewLine
                            , requisito.Id
                            , requisito.Assunto
                            , requisito.Descricao
                            , requisito.DocumentacaoTecnica
                        )
                );

                return result;
            }

            private string GetTemplateRetornosDeIncidenteAsString()
            {
                var result = "";

                Template.RetornoDeIncidentes.ForEach(
                    retornosDeIncidente =>
                        result += string.Format(
                            "### {1} - {2}"
                            + "{0}"
                            + "{0}" + "#### Descrição"
                            + "{0}" + "{3}"
                            + "{0}" + "#### Correção"
                            + "{0}" + "{4}"
                            + "{0}"
                            , Environment.NewLine
                            , retornosDeIncidente.Id
                            , retornosDeIncidente.Assunto
                            , retornosDeIncidente.Descricao
                            , retornosDeIncidente.Correcao
                        )
                );

                return result;
            }
        }
    }
}
