using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WorkTimeNote.TrayIcon
{
    internal partial class TrayIcon
    {
        public static void RefreshMenuItems()
        {
            notifyIcon.ContextMenu = new ContextMenu();
            notifyIcon.Icon = Icon;

            var menuItems = new List<MenuItem>();

            if (UserPointingState == State.PointingTime) menuItems.AddRange(GetMenuItemsAlreadyPoitingHour());
            else menuItems.AddRange(GetMenuItemsNotPoitingHour());
            
            menuItems.AddRange(GetConfigMenuItems());
            menuItems.AddRange(GetDefaultMenuItemsList());

            foreach (var menuItem in menuItems) notifyIcon.ContextMenu.MenuItems.Add(menuItem);
        }

            
        internal static List<MenuItem> GetMenuItemsNotPoitingHour()
        {
            var menuItems = new List<MenuItem>();

            menuItems.AddRange(new List<MenuItem>
            {
                new MenuItem("28833",
                    delegate (object sender, EventArgs e) { Start(); } ),
                new MenuItem("68459",
                    delegate (object sender, EventArgs e) { Start(); } ),
                new MenuItem("28835",
                    delegate (object sender, EventArgs e) { Start(); } ),
                new MenuItem("28832",
                    delegate (object sender, EventArgs e) { Start(); } ),
            });

            menuItems.Add(new MenuItem("Ordenar por", new MenuItem[]
            {
                    new MenuItem("Id"),
                    new MenuItem("Assunto"),
                    new MenuItem("Prioridade")
            }));

            return menuItems;
        }
            
        internal static List<MenuItem> GetMenuItemsAlreadyPoitingHour()
        {
            var menuItems = new List<MenuItem>
            {
                new MenuItem("Salvar", new MenuItem[]
                {
                    new MenuItem("Implementação",
                        delegate (object sender, EventArgs e) { Save(); } ),
                    new MenuItem("Reunião",
                        delegate (object sender, EventArgs e) { Save(); } ),
                    new MenuItem("Correção de RI",
                        delegate (object sender, EventArgs e) { Save(); } )
                }),
                new MenuItem("Cancelar",
                    delegate (object sender, EventArgs e) { Cancel(); } )
            };

            return menuItems;
        }

        private static List<MenuItem> GetConfigMenuItems()
        {
            var menuItems = new List<MenuItem>
            {
                new MenuItem("-"),
                new MenuItem("Pesquisar por Id"),
                new MenuItem("Recentes"),
                new MenuItem("-"),
                new MenuItem(
                    "Templates", new MenuItem[2]
                    {
                        new MenuItem("Checkin",
                            delegate (object sender, EventArgs e) { Template.Checkin(); } ),
                        new MenuItem("Retorno de Incidente (RI)",
                            delegate (object sender, EventArgs e) { Template.RetornoDeIncidente(); } )
                    }
                ),
                new MenuItem("Meu Dia",
                    delegate (object sender, EventArgs e) { throw new NotImplementedException(); } ),
                //new MenuItem($@"Mudar para estilo de apontamento (atual: ""{StyleName}"").",
                //    delegate (object sender, EventArgs e) { SwitchWorkTimeNoteStyle(); } )
            };

            return menuItems;
        }

        private static List<MenuItem> GetDefaultMenuItemsList()
        {
            var menuItems = new List<MenuItem>
            {
                //new MenuItem("-"),
                //new MenuItem("Como Usar",
                //    delegate (object sender, EventArgs e) { throw new NotImplementedException(); } ),
                //new MenuItem("Sobre",
                //    delegate (object sender, EventArgs e) { throw new NotImplementedException(); } ),
                new MenuItem("-"),
                new MenuItem("Fechar", delegate (object sender, EventArgs e) { throw new NotImplementedException(); })
            };

            return menuItems;
        }
    }
}
