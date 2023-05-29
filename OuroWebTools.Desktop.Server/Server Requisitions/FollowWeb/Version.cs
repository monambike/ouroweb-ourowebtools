using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Server
{
    public static partial class ServerRequisitions
    {
        public static partial class FollowWeb
        {
            public static List<Application> GetOuroNetVersions() => GetApplicationsVersions(ApplicationEnum.OuroNet);

            private static List<Application> GetApplicationsVersions(ApplicationEnum applicationEnum)
            {
                var result = new List<Application>();

                using (var dataContext = Connection.GetSelectedConnectionString())
                {
                    int applicationEnumValue = (int)applicationEnum;

                    var aplicativos = dataContext.GetTable<Table.Aplicativo>();
                    var versoes = dataContext.GetTable<Table.Versao>();
                    var subVersoes = dataContext.GetTable<Table.SubVersao>();

                    var query =
                        from aplicativo in aplicativos
                        where aplicativo.Id == applicationEnumValue
                        select new Application
                        {
                            Name = aplicativo.Nome,
                            Versions = (List<Version>)
                                (from versao in versoes
                                 where versao.FkAplicativoId == applicationEnumValue
                                 orderby Convert.ToDouble(versao.Numero)
                                 select new Version
                                 {
                                     Sob = versao.Numero.Trim(),
                                     SubVersions = (List<Version.SubVersion>)(
                                         from subVersao in subVersoes
                                         where versao.Id == subVersao.FkVersaoId
                                         orderby subVersao.Numero
                                         select new Version.SubVersion
                                         {
                                             Sub = subVersao.Numero.ToString()
                                         }
                                     )
                                 })
                        };

                    result.AddRange(query.ToList());
                }
                
                return result;
            }

            private static List<Application> GetApplicationsVersions(IEnumerable<ApplicationEnum> applicationEnums)
            {
                var result = new List<Application>();

                foreach (var applicationEnum in applicationEnums)
                {
                    result.AddRange(GetApplicationsVersions(applicationEnum));
                }

                return result;
            }

            public static List<string> GetApplicationsVersionsAsListStringOrderedByDescending(ApplicationEnum applicationEnum)
            {
                var result = new List<string>();
                var applications = GetApplicationsVersions(applicationEnum);
                
                foreach (var application in applications)
                {
                    application.Versions = application.Versions
                        .OrderByDescending(version => version.Sob.Length)
                        .ThenByDescending(version => version.Sob)
                        .ToList();

                    foreach (var version in application.Versions)
                    {
                        version.SubVersions = version.SubVersions
                            .OrderByDescending(subVersion => subVersion.Sub)
                            .ToList();

                        foreach (var subVersion in version.SubVersions)
                        {
                            var fullVersion = $"{version.Sob}.{subVersion.Sub}";
                            result.Add(fullVersion);
                        }
                    }
                }

                return result;
            }

            public static List<string> GetOuroNetVersionsAsListStringOrderedByDescending() => GetApplicationsVersionsAsListStringOrderedByDescending(ApplicationEnum.OuroNet);

            public static SingleVersion GetLatestOuroNetVersion()
            {
                var versions = GetOuroNetVersions();
                var lastestVersionAsList = versions.LastOrDefault().Versions.LastOrDefault();

                var latestVersion = new SingleVersion
                {
                    Sob = lastestVersionAsList.Sob,
                    Sub = lastestVersionAsList.SubVersions.LastOrDefault().Sub
                };

                return latestVersion;
            }

            /// <summary>
            /// Valores que representam os aplicativos e suas respectivas primary keys da tabela "Aplicativo"
            /// </summary>
            public enum ApplicationEnum { OuroWeb = 1, OuroNet = 58 }
        }
    }
}
