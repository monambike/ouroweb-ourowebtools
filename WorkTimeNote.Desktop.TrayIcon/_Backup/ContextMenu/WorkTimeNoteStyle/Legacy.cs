//using System;
//using System.Collections.Generic;
//using System.Windows.Forms;

//namespace WorkTimeNote.TrayIcon
//{
//    internal partial class TrayIcon
//    {
//        internal static partial class Style
//        {
//            internal static class Legacy
//            {
//                internal static List<MenuItem> GetMenuItemsNotPoitingHour()
//                {
//                    var menuItems = new List<MenuItem>
//                    {
//                        //new MenuItem("Modelo 1 (Inicia o apontamento sem função, e salva com apontamento depois)"),
//                        new MenuItem(
//                            "Apontar", new MenuItem[2]
//                            {
//                                new MenuItem("28833",
//                                    delegate (object sender, EventArgs e) { throw new NotImplementedException(); } ),
//                                new MenuItem("28832",
//                                    delegate (object sender, EventArgs e) { throw new NotImplementedException(); } )
//                            }
//                        ),
//                        new MenuItem("Cancelar")
//                    };

//                    return menuItems;
//                }
//            }

//            internal static List<MenuItem> GetMenuItemsAlreadyPoitingHour()
//            {
//                var menuItems = new List<MenuItem>
//                {
//                    new MenuItem("Salvar", new MenuItem[]
//                    {
//                        new MenuItem("Implementação",
//                            delegate (object sender, EventArgs e) { throw new NotImplementedException(); } ),
//                        new MenuItem("Reunião",
//                            delegate (object sender, EventArgs e) { throw new NotImplementedException(); } ),
//                        new MenuItem("Correção de RI",
//                            delegate (object sender, EventArgs e) { throw new NotImplementedException(); } )
//                    }),
//                    new MenuItem("Cancelar",
//                        delegate (object sender, EventArgs e) { throw new NotImplementedException(); } ),
//                    new MenuItem("-"),
//                    new MenuItem("Sair",
//                        delegate (object sender, EventArgs e) { throw new NotImplementedException(); } )

//                };

//                return menuItems;
//            }
//        }
//    }
//}
