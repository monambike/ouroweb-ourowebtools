namespace Common.Models
{
    public abstract class ObjectsWeb
    {
        public abstract string Name { get; set; }

        public abstract string Description { get; set; }
        
        public abstract void MakeScript();
    }

    public class Object
    {
        public class Permission
        {
            public string Name { get; set; }

            public string Description { get; set; }
        }


        public class Configuration
        {
            public string Name { get; set; }

            public string Description { get; set; }

            public enum Type { VARCHAR, INTEGER, BOOLEAN, DATETIME, LONG, IMAGE, CURRENCY }
        }
    }
}
