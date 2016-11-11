using ExpressionMapping.Data;
using ExpressionMapping.External;
using ExpressionMapping.Mapping;
using Xunit;

namespace ExpressionMapping.Tests
{
    public class UserMapperTests
    {
        [Fact]
        public void ToUser_PopulatedExternalUser_UserPropertiesMapped()
        {
            var expectedUser = new ExternalUser
            {
                Forename = "Tarquin"
            };

            User result = UserMapper.ToUser(expectedUser);

            Assert.Equal(expectedUser.Forename, result.Forename);
            Assert.True(result.ForenameSpecified);
        }
    }
}
