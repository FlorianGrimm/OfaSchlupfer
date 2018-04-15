namespace OfaSchlupfer.Model {
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Xunit;
    public class ModelRootTest {
        [Fact]
        public void ModelRoot_1_Test() {
            var modelRoot = new ModelRoot();
            modelRoot.Name = "Hugo";
            var modelRepository = new ModelRepository();
            modelRepository.Name = "PWA";
            modelRoot.Repositories.Add(modelRepository);
            //modelRepository.ReferenceRepositoryModel
        }
    }
}
