using System.Collections.Generic;
using System.Linq;

namespace Common.Server
{
    public static partial class ServerRequisitions
    {
        public static partial class FollowWeb
        {
            public static List<string> GetAllPendencias()
            {
                var result = new List<string>();

                using (var dataContext = Connection.GetSelectedConnectionString())
                {
                    var pendencias = dataContext.GetTable<Table.Pendencia>();

                    var query = from pendencia in pendencias select pendencia.Id.ToString();
                    result = query.ToList();
                }

                return result;
            }
        }
    }
}
