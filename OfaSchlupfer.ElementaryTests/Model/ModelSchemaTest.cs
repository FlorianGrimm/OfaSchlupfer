#pragma warning disable xUnit2013 // Do not use equality check to check for collection size.

namespace OfaSchlupfer.Model {
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;

    using OfaSchlupfer.Freezable;

    using Xunit;

    public class ModelSchemaTest {
        [Fact]
        public void ModelSchema_ModelComplexType_Test() {
            var modelSchema = new ModelSchema();
            var name = new ModelEntityName("test", "gna").AsFrozen();
            var ctGna = new ModelComplexType() { Name = name };
            modelSchema.ComplexTypes.Add(ctGna);
            ctGna.Freeze();
            Assert.True(ReferenceEquals(ctGna.Owner, modelSchema));
            var lstGna = modelSchema.FindComplexType(new ModelEntityName("test", "gna"));
            Assert.Equal(1, lstGna.Count);
            Assert.True(ReferenceEquals(lstGna.Single(), ctGna));
        }

        [Fact]
        public void ModelSchema_Entities_Test() {
            var modelSchema = new ModelSchema();
            var name = new ModelEntityName("test", "gna").AsFrozen();
            var ctGna = new ModelComplexType() { Name = name };
            var etGna = new ModelEntity() { Name = name, EntityTypeNáme = name };
            modelSchema.ComplexTypes.Add(ctGna.AsFrozen());
            modelSchema.Entities.Add(etGna);
            Assert.True(ReferenceEquals(etGna.Owner, modelSchema));
            {
            var lstGna = modelSchema.FindEntity(new ModelEntityName("test", "gna"));
            Assert.Equal(1, lstGna.Count);
            Assert.True(ReferenceEquals(lstGna.Single(), etGna));
            }
            {
                modelSchema.Freeze();
                ctGna.ThrowIfNotFrozen();
            }
            {
                var lstGna = modelSchema.FindEntity(new ModelEntityName("test", "gna"));
                Assert.Equal(1, lstGna.Count);
                Assert.True(ReferenceEquals(lstGna.Single(), etGna));
            }
        }
    }
}
