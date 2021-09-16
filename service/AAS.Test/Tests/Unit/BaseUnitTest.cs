using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using AAS.Data;
using AAS.Data.Abstractions;
using AAS.Test.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AAS.Test.Tests.Unit
{
    [TestCategory("Unit")]
    public abstract class BaseUnitTest : BaseTest
    {
        protected ILoggerFactory LoggerFactory { get; set; }

        protected Mock<IMediator> MockMediator { get; set; } = new Mock<IMediator>();

        protected static IMapper Mapper => new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>()).CreateMapper();

        protected Mock<IAuthorizationService> MockAuthorizationService { get; set; } = new Mock<IAuthorizationService>();

        protected Mock<IEmailService> MockEmailService { get; set; } = new Mock<IEmailService>();

        protected BaseUnitTest()
        {
            // redirect all logging to console
            var services = new ServiceCollection();
            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConsole();
                loggingBuilder.SetMinimumLevel(LogLevel.Trace);
            });
            var serviceProvider = services.BuildServiceProvider();
            LoggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();


            // by default, action is authorized
            SetupAuthorization(true);
        }

        protected void SetupAuthorization(bool isAuthorized)
        {
            MockAuthorizationService
                .Setup(x => x.AuthorizeAsync(It.IsAny<ClaimsPrincipal>(), null, It.IsAny<IEnumerable<IAuthorizationRequirement>>()))
                .ReturnsAsync(isAuthorized ? AuthorizationResult.Success() : AuthorizationResult.Failed());
        }

        /// <summary>
		/// Execute a query against an in-memory database seeded with test data and then check assertions using the return value.
		/// </summary>
        /// <remarks>To test methods which we expect to throw an exception, don't specify <paramref name="assertions"/>.</remarks>
		/// <param name="func">Function to execute.</param>
		/// <param name="assertions">Assertions to execute after the function has executed.</param>
		protected async Task ExecuteWithDb<TResult>(
            Func<AasDbContext, Task<TResult>> func,
            Action<TResult, AasDbContext> assertions = null)
        {
            using (var db = new AasDbContext(CreateInMemoryContextOptions()))
            {
                // seed test data
                new TestDataSeeder(db, LoggerFactory.CreateLogger<TestDataSeeder>()).SeedTestData();

                // execute our test
                var result = await func(db);

                // check our test results
                assertions?.Invoke(result, db);
            }
        }

        private static DbContextOptions<AasDbContext> CreateInMemoryContextOptions()
        {
            var builder = new DbContextOptionsBuilder<AasDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()) // we use a new GUID so that each unit test gets its own fresh database
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));

            return builder.Options;
        }
    }
}
