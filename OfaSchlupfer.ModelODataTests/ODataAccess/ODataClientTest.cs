namespace OfaSchlupfer.ModelOData.ODataAccess {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using OfaSchlupfer.Elementary;
    using OfaSchlupfer.HttpAccess;
    using OfaSchlupfer.ModelOData.Edm;
    using Xunit;

    public class ODataClientTest {
#if LongRunning
        [Fact]
        [Trait("Category", "hot")]
        public async Task ODataClient_1_Test() {
            await _ODataClient_1_Test();
        }
#endif

        private async Task _ODataClient_1_Test() {
            var testCfg = OfaSchlupfer.TestCfg.Get();
            var repCSProjectServer = testCfg.ProjectServer.CreateWithSuffix("");
            repCSProjectServer.AuthenticationMode = "SPOIDCRL";

            IServiceCollection services = new ServiceCollection();
            services.AddLogging((builder) => { builder.AddDebug(); });
            services.AddSharePointOnlineCredentials((builder) => { });
            services.AddHttpClient((builder) => { });
            var serviceProvider = services.BuildServiceProvider();

            var srcPath = System.IO.Path.Combine(testCfg.SolutionFolder, @"test\ProjectOnlinemetadata.xml");
            var cachedMetadataResolver = new CachedMetadataResolver();
            cachedMetadataResolver.SetDynamicResolution((location) => new System.IO.StreamReader(location));
            var edmReader = new EdmReader(serviceProvider);
            edmReader.MetadataResolver = cachedMetadataResolver;

            var edmxModel = edmReader.Read(srcPath, null);

            var clientFactory = serviceProvider.GetRequiredService<IHttpClientDispatcherFactory>();
            var oDataClient = new ODataClient(clientFactory, serviceProvider);
            oDataClient.EdmxModel = edmxModel;
            var oDataRequest = oDataClient.Query("Projects");
            // oDataClient.ConnectionString = repCSProjectServer;
            oDataClient.SetConnectionString(repCSProjectServer, "/_api/ProjectData/[en-us]");
            var t = oDataClient.ExecuteAsync(oDataRequest, CancellationToken.None, null);
            var oDataResponce = await t;
            Assert.NotNull(oDataResponce);
            Assert.Null(oDataResponce.ResponceContentStream);
            Assert.NotNull(oDataResponce.ResponceContentString);
            //var httpClient = clientFactory.CreateHttpClient(repCSProjectServer)
        }

        [Fact]
        [Trait("Category", "hot")]
        public void ODataClient_2_Translate_Test() {
            var testCfg = OfaSchlupfer.TestCfg.Get();
            var repCSProjectServer = testCfg.ProjectServer.CreateWithSuffix("");
            repCSProjectServer.AuthenticationMode = "SPOIDCRL";

            IServiceCollection services = new ServiceCollection();
            services.AddLogging((builder) => { builder.AddDebug(); });
            services.AddSharePointOnlineCredentials((builder) => { });
            services.AddHttpClient((builder) => { });
            var serviceProvider = services.BuildServiceProvider();

            var srcPath = System.IO.Path.Combine(testCfg.SolutionFolder, @"test\ProjectOnlinemetadata.xml");
            var cachedMetadataResolver = new CachedMetadataResolver();
            cachedMetadataResolver.SetDynamicResolution((location) => new System.IO.StreamReader(location));
            var edmReader = new EdmReader(serviceProvider);
            edmReader.MetadataResolver = cachedMetadataResolver;

            var edmxModel = edmReader.Read(srcPath, null);

            var clientFactory = serviceProvider.GetRequiredService<IHttpClientDispatcherFactory>();
            var oDataClient = new ODataClient(clientFactory, serviceProvider);
            oDataClient.EdmxModel = edmxModel;
            var oDataRequest = oDataClient.Query("Projects");
            // oDataClient.ConnectionString = repCSProjectServer;
            oDataClient.SetConnectionString(repCSProjectServer, "/_api/ProjectData/[en-us]");

            var srcPathData = System.IO.Path.Combine(testCfg.SolutionFolder, @"test\ProjectOnlineData-Projects.json");

            ODataResponce oDataResponce = new ODataResponce();
            oDataResponce.ResponceContentString = System.IO.File.ReadAllText(srcPathData);

            ODataDeserializtion d = new ODataDeserializtion(oDataResponce, oDataRequest, edmxModel);
            Assert.NotNull(oDataResponce);
            Assert.Null(oDataResponce.ResponceContentStream);
            Assert.NotNull(oDataResponce.ResponceContentString);

            //oDataRequest.Parse(oDataResponce);
            oDataResponce.Parse(oDataClient, oDataRequest);
            //var httpClient = clientFactory.CreateHttpClient(repCSProjectServer)
        }
    }
}
