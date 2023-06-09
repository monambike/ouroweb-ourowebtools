//using System;
//using System.Collections.Generic;
//using System.Windows.Forms;

//namespace WorkTimeNote.TrayIcon
//{
//    internal partial class TrayIcon
//    {
//        public static class ContextMenu
//        {
//            internal static bool LegacyStyle { get; set; } = false;
            
//            internal static string StyleName => LegacyStyle ? "legado" : "novo";


//            public static void Update()
//            {
//                notifyIcon.ContextMenu = new System.Windows.Forms.ContextMenu();
//                var menuItems = new List<MenuItem>();

//                menuItems.AddRange(GetSelectedWorkTimeNoteStyleMenuItems(LegacyStyle));
//                menuItems.AddRange(GetConfigMenuItems());
//                menuItems.AddRange(GetDefaultMenuItemsList());

//                foreach (var menuItem in menuItems) notifyIcon.ContextMenu.MenuItems.Add(menuItem);
//            }

//            private static List<MenuItem> GetSelectedWorkTimeNoteStyleMenuItems(bool legacyStyle)
//            {
//                var selectedStyle = legacyStyle ? Style.Legacy.GetMenuItemsNotPoitingHour() : Style.New.GetMenuItemsNotPoitingHour();

//                return selectedStyle;
//            }

//            private static List<MenuItem> GetConfigMenuItems()
//            {
//                var menuItems = new List<MenuItem>
//                {
//                    new MenuItem("-"),
//                    new MenuItem("Pesquisar por Id"),
//                    new MenuItem("Recentes"),
//                    new MenuItem("-"),
//                    new MenuItem(
//                        "Ordenar por", new MenuItem[3]
//                        {
//                            new MenuItem("Id"),
//                            new MenuItem("Assunto"),
//                            new MenuItem("Prioridade")
//                        }
//                    ),
//                    new MenuItem("-"),
//                    new MenuItem(
//                        "Templates", new MenuItem[2]
//                        {
//                            new MenuItem("Checkin",
//                                delegate (object sender, EventArgs e) { Template.Checkin(); } ),
//                            new MenuItem("Retorno de Incidente (RI)",
//                                delegate (object sender, EventArgs e) { Template.RetornoDeIncidente(); } )
//                        }
//                    ),
//                    new MenuItem("Meu Dia",
//                        delegate (object sender, EventArgs e) { throw new NotImplementedException(); } ),
//                    new MenuItem($"Mudar para estilo de apontamento para {StyleName}",
//                        delegate (object sender, EventArgs e) { SwitchWorkTimeNoteStyle(); } )
//                };

//                return menuItems;
//            }

//            private static List<MenuItem> GetDefaultMenuItemsList()
//            {
//                var menuItems = new List<MenuItem>
//            {
//                new MenuItem("-"),
//                new MenuItem("Como Usar",
//                    delegate (object sender, EventArgs e) { throw new NotImplementedException(); } ),
//                new MenuItem("Sobre",
//                    delegate (object sender, EventArgs e) { throw new NotImplementedException(); } ),
//                new MenuItem("-"),
//                new MenuItem("Fechar", delegate (object sender, EventArgs e) { notifyIcon.Visible = false; } )
//            };

//                return menuItems;
//            }


//            private static void SwitchWorkTimeNoteStyle()
//            {
//                LegacyStyle = !LegacyStyle;

//                Update();

//                notifyIcon.ShowBalloonTip(
//                    500
//                    , "Estillo de Apontamento de Hora"
//                    , $"O estilo de apontamento de hora foi alterado para {StyleName}."
//                    , ToolTipIcon.Info
//                );
//            }
//        }
//    }
//}
