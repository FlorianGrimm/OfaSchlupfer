namespace OfaSchlupfer.ModelOData.Edm {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Xunit;

    public class CsdlEntityCollectionTypeModelTest {
        [Fact]
        public void CsdlEntityCollectionTypeModel_IsCollection() {
            Assert.Equal("a.b", CsdlEntityCollectionTypeModel.IsCollection("Collection(a.b)"));
            Assert.Null(CsdlEntityCollectionTypeModel.IsCollection("a.b"));
        }
    }
}
