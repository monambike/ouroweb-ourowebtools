using System.Collections.Generic;

namespace Common.Models.ScriptPackage
{
    public partial class ScriptPackage
    {
        public class Progress
        {
            public enum Status { Started, InProgress, Finished }

            public decimal Percentage = 0;
        }

        public ScriptPackage()
        {

        }

        public void MakeSetupAsync()
        {
            if (!CanConnectToDatabase(GetDefaultCustomSoftwareConnectionString())) return;
        }
    }
}
