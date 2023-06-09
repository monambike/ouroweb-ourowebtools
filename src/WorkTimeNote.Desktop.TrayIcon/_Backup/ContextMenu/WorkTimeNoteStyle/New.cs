//using System;
//using System.Collections.Generic;
//using System.Windows.Forms;

//namespace WorkTimeNote.TrayIcon
//{
//    internal partial class TrayIcon
//    {
//        internal static partial class Style
//        {
//            internal static class New
//            {
//                internal static List<MenuItem> GetMenuItemsNotPoitingHour()
//                {
//                    var menuItems = new List<MenuItem>
//                    {
//                        //new MenuItem("Modelo 2 (Inicia o apontamento já a função e depois só salva)"),
//                        new MenuItem("Apontar", new MenuItem[]
//                        {
//                            new MenuItem("28833", new MenuItem[]
//                            {
//                                new MenuItem("Implementação",
//                                    delegate (object sender, EventArgs e) { throw new NotImplementedException(); } ),
//                                new MenuItem("Reunião",
//                                    delegate (object sender, EventArgs e) { throw new NotImplementedException(); } ),
//                                new MenuItem("Correção de RI",
//                                    delegate (object sender, EventArgs e) { throw new NotImplementedException(); } )
//                            }),
//                            new MenuItem("65432", new MenuItem[]
//                            {
//                                new MenuItem("Implementação",
//                                    delegate (object sender, EventArgs e) { throw new NotImplementedException(); } ),
//                                new MenuItem("Reunião",
//                                    delegate (object sender, EventArgs e) { throw new NotImplementedException(); } )
//                            })
//                        })
//                    };

//                    return menuItems;
//                }

//                internal static List<MenuItem> GetMenuItemsAlreadyPoitingHour()
//                {
//                    var menuItems = new List<MenuItem>
//                    {
//                        new MenuItem("Salvar",
//                            delegate (object sender, EventArgs e) { throw new NotImplementedException(); } ),
//                        new MenuItem("Cancelar",
//                            delegate (object sender, EventArgs e) { throw new NotImplementedException(); } ),
//                        new MenuItem("-"),
//                        new MenuItem("Sair",
//                            delegate (object sender, EventArgs e) { throw new NotImplementedException(); } )

//                    };

//                    return menuItems;
//                }
//            }
//        }
//    }
//}
