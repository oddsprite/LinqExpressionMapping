using ExpressionMapping.Data;
using ExpressionMapping.External;

namespace ExpressionMapping.Mapping
{
    public static class UserMapper
    {
        public static User ToUser(ExternalUser externalUser)
        {
            var user = new User();
            ExpressionMapper.PopulatePropertyAndSpecifiedField(() => user.Forename, externalUser.Forename);
            return user;
        }
    }
}
