namespace Common.Models
{
    public partial class OuroNet
    {
        public partial class Setup
        {
            public class Client
            {
                public class App : Base { }

                public class WinService
                {
                    public class Cce : Base { }

                    public class CceAutomaticAnswer : Base { }

                    public class Farma : Base { }

                    public class Whatsapp : Base { }

                    public class PagBco : Base { }
                }
            }
        }
    }
}
