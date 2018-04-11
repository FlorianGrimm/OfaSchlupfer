namespace OfaSchlupfer.HttpAccess {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using OfaSchlupfer.HttpAccess;
    using OfaSchlupfer.SPO;
    using Xunit;

    public class HttpClientDynamicTest {
        [Fact]
        public void HttpClientDynamic_1_Test() {
            var testCfg = TestCfg.Get();
            var baseurl = testCfg.ProjectServer.Url;
            var url = baseurl + "/_api/ProjectData/[en-us]/$metadata";
            var cred = new SharePointOnlineServiceClientCredentials(testCfg.ProjectServer.User, testCfg.ProjectServer.Password, null);
            var client = new HttpClientDynamic(new Uri(baseurl), null, null);
            client.HttpClient
        }
    }
}
