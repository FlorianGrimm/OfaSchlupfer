#pragma warning disable SA1402
#pragma warning disable SA1600

namespace OfaSchlupfer.MSSQLReflection.SqlCode {
    using System;

    public sealed class SqlCodeTypeSingle : ISqlCodeType {
        public readonly OfaSchlupfer.MSSQLReflection.Model.ModelSqlType Type;

        public SqlCodeTypeSingle(OfaSchlupfer.MSSQLReflection.Model.ModelSqlType type) {
            this.Type = type;
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
