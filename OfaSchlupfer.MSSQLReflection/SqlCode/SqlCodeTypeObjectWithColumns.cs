#pragma warning disable SA1402
#pragma warning disable SA1600

namespace OfaSchlupfer.MSSQLReflection.SqlCode {
    using System;

    public sealed class SqlCodeTypeObjectWithColumns : ISqlCodeType {
        public readonly Model.ModelSqlObjectWithColumns ObjectWithColumns;

        public SqlCodeTypeObjectWithColumns(Model.ModelSqlObjectWithColumns objectWithColumns) {
            this.ObjectWithColumns = objectWithColumns;
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
