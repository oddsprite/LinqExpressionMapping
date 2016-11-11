using ExpressionMapping.Data;
using ExpressionMapping.External;

namespace ExpressionMapping.Mapping
{
    public static class UserMapper
    {
        public static User ToUser(ExternalUser externalUser)
        {
            return new User
            {
                Forename = externalUser.Forename,
                ForenameSpecified = externalUser.Forename != null
            };
        }
    }
}
