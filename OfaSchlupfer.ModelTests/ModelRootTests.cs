using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfaSchlupfer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfaSchlupfer.Model {
    [TestClass()]
    public class ModelRootTests {
        [TestMethod()]
        public void ModelRoot_ModelRootTest() {
            string json = null;
            {
                var modelRoot = new ModelRoot();
                modelRoot.Name = "Test";
                modelRoot.Repositories.Add(new ModelRepository() { Name = "1" });
                modelRoot.Repositories.Add(new ModelRepository() { Name = "2" });
                modelRoot.RepositoryMappings.Add(new MappingRepository() { SourceName = "1", TargetName = "2" });

                json = Newtonsoft.Json.JsonConvert.SerializeObject(modelRoot);
            }
            {
                var modelRoot = Newtonsoft.Json.JsonConvert.DeserializeObject<ModelRoot>(json);
                Assert.IsNotNull(modelRoot);
                Assert.AreEqual(2, modelRoot.Repositories.Count);
                Assert.AreEqual(1, modelRoot.RepositoryMappings.Count);
                Assert.IsNotNull(modelRoot.FindRepository("1"));
                modelRoot.ResolveNames();
                Assert.IsNotNull(modelRoot.RepositoryMappings[0].Source);
                Assert.IsNotNull(modelRoot.RepositoryMappings[0].Target);


                modelRoot.FindRepository("1").Name = "one";
                modelRoot.UpdateNames();
            }
        }
    }
}