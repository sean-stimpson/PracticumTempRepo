using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace AAS.Test.Tests.Unit.Infrastructure
{
    [TestClass]
    [TestCategory("Infrastructure")]
    public class InfrastructureTests : BaseUnitTest
    {
        [TestMethod]
        public async Task Infrastructure_AutoMapper_ConfigurationIsValid()
        {
            Mapper.ConfigurationProvider.AssertConfigurationIsValid();

            await Task.CompletedTask;
        }
    }
}
