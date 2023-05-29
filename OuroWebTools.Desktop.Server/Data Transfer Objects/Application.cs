using System.Collections.Generic;

namespace Common.Server
{
    public class Application
    {
        public string Name { get; set; }

        public List<Version> Versions { get; set; }

    }

    public class Version
    {
        public string Sob { get; set; }

        public List<SubVersion> SubVersions { get; set; }

        public class SubVersion
        {
            public string Sub { get; set; }
        }
    }

    public class SingleVersion
    {
        public string Sob { get; set; }

        public string Sub { get; set; }

        public string Whole => $"{Sob}.{Sub}";
    }
}