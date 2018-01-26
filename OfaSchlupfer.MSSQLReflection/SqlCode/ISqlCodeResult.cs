#pragma warning disable SA1402
#pragma warning disable SA1600

namespace OfaSchlupfer.MSSQLReflection.SqlCode {
    using System;

    public interface ISqlCodeResult {
        // ISqlCodeType GetSqlCodeType();

        // ISqlCodeResult GetResolvedCodeResult();

        // void SetResolvedCodeResult(ISqlCodeResult sqlCodeType);
    }

    public sealed class SqlCodeResultVoid : ISqlCodeResult, ISqlCodeType {
        private static SqlCodeResultVoid _Instance;

        public static SqlCodeResultVoid Instance => _Instance ?? (_Instance = new SqlCodeResultVoid());

        private SqlCodeResultVoid() { }

        /*
         public ISqlCodeType GetSqlCodeType() => this;
         */

        public ISqlCodeType GetResolvedCodeType() => this;

        public void SetResolvedCodeType(ISqlCodeType sqlCodeType) {
            if (ReferenceEquals(this, sqlCodeType)) { return; }
            throw new InvalidOperationException();
        }
    }

    public sealed class SqlCodeResultLazy : ISqlCodeResult {
        public SqlCodeResultLazy() { }

        // public ISqlCodeType GetSqlCodeType() {
        //     return null;
        // }
    }

    public sealed class SqlCodeResultConst : ISqlCodeResult {
        public OfaSchlupfer.MSSQLReflection.Model.ModelSqlScalarValue ScalarValue;

        public SqlCodeResultConst(OfaSchlupfer.MSSQLReflection.Model.ModelSqlScalarValue scalarValue) {
            this.ScalarValue = scalarValue;
        }

        /*
        public ISqlCodeType SqlCodeType;
        public string SqlValue;

        public SqlCodeResultConst(ISqlCodeType sqlCodeType, string sqlValue) {
            this.SqlCodeType = sqlCodeType;
            this.SqlValue = sqlValue;
        }

        public ISqlCodeType GetSqlCodeType() {
            return this.SqlCodeType;
        }
        */
    }
}
