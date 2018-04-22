#pragma warning disable SA1402
#pragma warning disable SA1600

namespace OfaSchlupfer.MSSQLReflection.SqlCode {
    using System;

    /// <summary>
    /// add lazyness
    /// </summary>
    public sealed class SqlCodeType : ISqlCodeType {
        public readonly OfaSchlupfer.MSSQLReflection.Model.ModelSematicType ModelType;

        public SqlCodeType(OfaSchlupfer.MSSQLReflection.Model.ModelSematicType modelType) {
            this.ModelType = modelType;
        }

        public ISqlCodeType GetResolvedCodeType() {
            return this;
        }

        public void SetResolvedCodeType(ISqlCodeType sqlCodeType) {
            if (ReferenceEquals(sqlCodeType, this)) { return; }
            throw new InvalidOperationException();
        }
    }
}
