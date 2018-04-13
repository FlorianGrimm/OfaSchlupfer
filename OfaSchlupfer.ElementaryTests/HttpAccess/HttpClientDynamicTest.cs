namespace OfaSchlupfer.HttpAccess {
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest.Azure;
    using OfaSchlupfer.HttpAccess;
    using OfaSchlupfer.SPO;
    using Xunit;

    public class HttpClientDynamicTest {
#if !LongRunning
        [Fact]
        public async Task HttpClientDynamic_1_Test() {
            await _HttpClientDynamic_1_Test();
        }
#endif

        private async Task _HttpClientDynamic_1_Test() {
            var testCfg = TestCfg.Get();
            var baseurl = testCfg.ProjectServer.Url;
            var suffix = "_api/ProjectData/$metadata";
            var url = baseurl + suffix;
            var cred = new SharePointOnlineServiceClientCredentials(testCfg.ProjectServer.User, testCfg.ProjectServer.Password, null);
            var client = new HttpClientDynamic(new Uri(baseurl), cred, null);
            var request = client.CreateHttpRequestMessage(HttpMethod.Get, suffix, null, null, null);
            var metadata = (await client.SendAsync<string>("metadata", request, async delegate (AzureOperationResponse<string> r) {
                r.Body = await r.Response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }, CancellationToken.None)).Body;
            Assert.StartsWith("<?xml version=\"1.0\" encoding=\"utf-8\"?><edmx:Edmx Version=\"1.0\"", metadata);
        }
    }
}
