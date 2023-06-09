using System;

namespace Common.Utilities
{
    public static partial class Message
    {
        public static class Field
        {
            public static void CannotBeEmpty(string fieldName)
            {
                Custom.Warning($@"O campo ""{fieldName}"" não pode ficar vazio.");
            }

            public static void MustBeType(Type type, string fieldName)
            {
                var requiredType = TypeCodeToUserFriendlyString(type);
                Custom.Warning($@"O campo ""{fieldName}"" precisa ser do tipo {requiredType}.");
            }


            private static string TypeCodeToUserFriendlyString(Type type)
            {
                switch (type)
                {
                    case Type.String: return "texto";
                    case Type.Int: return "inteiro";
                    case Type.Numeric: return "numérico";
                    default: throw new NotImplementedException();
                }
            }


            public enum Type { String, Int, Numeric }
        }
    }
}
