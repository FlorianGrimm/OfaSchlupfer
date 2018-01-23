#pragma warning disable SA1402
#pragma warning disable SA1600

namespace OfaSchlupfer.MSSQLReflection.SqlCode {
    using System;

    public sealed class SqlCodeTypeSingle : ISqlCodeType {
        public readonly Model.ModelSqlType Type;

        public SqlCodeTypeSingle(Model.ModelSqlType type) {
            this.Type = type;
        }

        public ISqlCodeType GetResolved() {
            return this;
        }

        public void SetResolved(ISqlCodeType sqlCodeType) {
            if (ReferenceEquals(sqlCodeType, this)) { return; }
            throw new InvalidOperationException();
        }
    }
}
