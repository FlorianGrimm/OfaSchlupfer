namespace OfaSchlupfer.ModelOData.SPO {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Xunit;
    public class SharePointOnlineCredentialsTest {
#if LongRunning
        [Fact()]
        [Trait("Category", "LongRunning")]
        public async Task SharePointOnlineCredentialsAuth() {
            await _SharePointOnlineCredentialsAuth();
        }
#endif
        private async Task _SharePointOnlineCredentialsAuth() {
            var testCfg = TestCfg.Get();
            Assert.False(string.IsNullOrEmpty(testCfg.ProjectServer?.Url));

            IServiceCollection services = new ServiceCollection();
            services.AddLogging((builder) => { builder.AddDebug(); });
            services.AddSharePointOnlineCredentials();
            services.AddTransient<ODataRepository, ODataRepositoryImplementation>();
            services.AddSingleton(typeof(OfaSchlupfer.HttpAccess.IHttpClientFactory), typeof(SharePointOnlineFactory));

            var serviceProvider = services.BuildServiceProvider();

            var sut = serviceProvider.GetService<ODataRepository>();
            sut.SetConnectionString(testCfg.ProjectServer, "/_api/ProjectData/[en-us]");
            var metadataContent = await sut.GetMetadataAsync();
            Assert.StartsWith("<?xml version=\"1.0\" encoding=\"utf-8\"?><edmx:Edmx", metadataContent);
        }
    }
}
