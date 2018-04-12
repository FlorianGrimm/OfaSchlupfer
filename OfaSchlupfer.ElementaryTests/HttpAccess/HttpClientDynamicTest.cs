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
        [Fact]
        public async Task HttpClientDynamic_1_Test() {
            var testCfg = TestCfg.Get();
            var baseurl = testCfg.ProjectServer.Url;
            var suffix = "_api/ProjectData/$metadata";
            var url = baseurl + suffix;
            var cred = new SharePointOnlineServiceClientCredentials(testCfg.ProjectServer.User, testCfg.ProjectServer.Password, null);
            var client = new HttpClientDynamic(new Uri(baseurl), cred, null);
            var request = client.CreateHttpRequestMessage(HttpMethod.Get, suffix, null, null, null);
            await client.SendAsync<string>("metadata", request, async delegate (AzureOperationResponse<string> r) {
                r.Body = await r.Response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }, CancellationToken.None);
        }
    }
}
