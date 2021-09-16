using AAS.Data.DTOs;
using AAS.Data.Utilities;

namespace AAS.Test.Tests.Integration.Group
{
    public abstract class BaseGroupTest : BaseIntegrationTest
    {
        protected static GroupDto GetGroupDto()
        {
            return new GroupDto()
            {
                Name = RandomFactory.GetCompanyName(),
                IsActive = RandomFactory.GetBoolean()
            };
        }
    }
}
