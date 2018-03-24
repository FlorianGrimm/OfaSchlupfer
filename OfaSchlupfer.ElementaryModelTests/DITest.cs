namespace OfaSchlupfer.ElementaryModelTests {
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using OfaSchlupfer.Model;
    using System;
    using Xunit;

    public class DITest {
        [Fact]
        public void RepositoryTypeFactory_GetRepositoryTypes_Test() {

            IServiceCollection services = new ServiceCollection();
            services.AddLogging((builder) => { builder.AddDebug(); });
            services.AddSharePointOnlineCredentials();
            services.AddODataRepository();
            services.AddSqlRepository();
            var serviceProvider = services.BuildServiceProvider();

            var sut = new RepositoryTypeFactory(serviceProvider);
            var act = sut.GetRepositoryTypes();
            Assert.Equal(2, act.Count);
        }
    }
}
