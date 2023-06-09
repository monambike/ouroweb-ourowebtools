using System.Threading;
using System.Windows;

namespace Common.Utilities
{
    public static class Application
    {
        public static void Exit()
        {
            //if (Custom.Question("Tem certeza que deseja sair? Se você sair agora, perderá os apontamentos de horas pendentes.") == System.Windows.MessageBoxResult.Yes)

            System.Windows.Application.Current.Shutdown();
        }
    }
}
