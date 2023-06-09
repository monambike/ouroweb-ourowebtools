////using System.Windows.Forms;
////using TemplateModels = Common.Models;

////namespace WorkTimeNote.TrayIcon
////{
////    internal partial class TrayIcon
////    {
////        internal static class Template
////        {
////            private static readonly int pendenciaId = 31635;


////            internal static void Checkin()
////            {

////                var templateCheckin = new TemplateModels.Template.Checkin(pendenciaId);
////                templateCheckin.CopyToClipboard();

////                ShowBalloonTip(TemplateType.Checkin);
////            }

////            internal static void RetornoDeIncidente()
////            {
////                var templateRetornoDeIncidente = new TemplateModels.Template.RetornoDeIncidente(pendenciaId);
////                templateRetornoDeIncidente.CopyToClipboard();

////                ShowBalloonTip(TemplateType.RetornoDeIncidente);
////            }


////            private static void ShowBalloonTip(TemplateType template)
////            {
////                var templateName = GetTemplateNameAsString(template);

////                notifyIcon.ShowBalloonTip(500, "Template Copiado", 
////                    $"O template de {templateName} foi copiado para à área de transferência.", ToolTipIcon.Info);
////            }

////            private static string GetTemplateNameAsString(TemplateType template)
////            {
////                switch (template)
////                {
////                    case TemplateType.Checkin: return "Checkin";
////                    case TemplateType.RetornoDeIncidente: return "RI (Retorno de Incidente)";
////                    default: return null;
////                }
////            }


////            private enum TemplateType { Checkin, RetornoDeIncidente }
////        }
////    }
////}
