namespace OfaSchlupfer.MSSQLReflection.SqlCode {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ISqlCodeResult {
        ISqlCodeType GetSqlCodeType();
        //ISqlCodeResult GetResolved();
        //void SetResolved(ISqlCodeResult sqlCodeResult);
    }

    public sealed class SqlCodeResultVoid : ISqlCodeResult, ISqlCodeType {
        private static SqlCodeResultVoid _Instance;
        public static SqlCodeResultVoid Instance => _Instance ?? (_Instance = new SqlCodeResultVoid());

        private SqlCodeResultVoid() {
        }

        public ISqlCodeType GetSqlCodeType() => this;

        public ISqlCodeType GetResolved() => this;

        public void SetResolved(ISqlCodeType sqlCodeType) {
            if (ReferenceEquals(this, sqlCodeType)) { return; }
            throw new InvalidOperationException();
        }
    }

    public sealed class SqlCodeResultLazy : ISqlCodeResult {
        public SqlCodeResultLazy() {
        }

        public ISqlCodeType GetSqlCodeType() {
            return null;
        }
    }

    public sealed class SqlCodeResultConst : ISqlCodeResult {
        public ISqlCodeType SqlCodeType;
        public string SqlValue;
        public SqlCodeResultConst(ISqlCodeType sqlCodeType, string sqlValue) {
            this.SqlCodeType = sqlCodeType;
            this.SqlValue = sqlValue;
        }

        public ISqlCodeType GetSqlCodeType() {
            return this.SqlCodeType;
        }
    }
}
