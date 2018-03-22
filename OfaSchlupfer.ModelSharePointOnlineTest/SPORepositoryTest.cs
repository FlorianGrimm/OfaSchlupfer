namespace OfaSchlupfer.ModelSharePointOnlineTest {
    using System;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OfaSchlupfer.ModelSharePointOnline;

    [TestClass]
    public class SPORepositoryTest {
        [TestMethod]
        public void SPORepository_ctor() {
            var testCfg = TestCfg.Get();
            Assert.IsFalse(string.IsNullOrEmpty(testCfg.ProjectServer?.Url));

            var sut = new SPORepository();
            sut.ConnectionString = testCfg.ProjectServer;
            Assert.IsTrue(sut.ConnectionString.Url.StartsWith("http"));
        }

        [TestMethod]
        public async Task SPORepository_ReadProjectListAsync() {
            var testCfg = TestCfg.Get();
            Assert.IsFalse(string.IsNullOrEmpty(testCfg.ProjectServer?.Url));

            var sut = new SPORepository();
            sut.ConnectionString = testCfg.ProjectServer;
            var list = await sut.ReadProjectListAsync(null);
            Assert.IsNotNull(list);
        }


        [TestMethod]
        public void SPORepository_ReadProjectList() {
            var testCfg = TestCfg.Get();
            Assert.IsFalse(string.IsNullOrEmpty(testCfg.ProjectServer?.Url));

            var sut = new SPORepository();
            sut.ConnectionString = testCfg.ProjectServer;
            var list = sut.ReadProjectList(null);
            Assert.IsNotNull(list);
        }
    }
}
