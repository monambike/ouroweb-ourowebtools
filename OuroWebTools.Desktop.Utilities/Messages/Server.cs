namespace Common.Utilities
{
    public static partial class Message
    {
        public static class Server
        {
            public static void NotFoundResults()
            {
                Custom.Warning(@"Não foram encontrados resultados para a consulta realizada.");
            }
        }
    }
}
