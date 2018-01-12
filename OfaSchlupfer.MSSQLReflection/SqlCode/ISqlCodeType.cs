namespace OfaSchlupfer.MSSQLReflection.SqlCode {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ISqlCodeType {
        ISqlCodeType GetResolved();
        void SetResolved(ISqlCodeType sqlCodeType);
    }

    public sealed class SqlCodeTypeLazy : ISqlCodeType {
        public readonly OfaSchlupfer.ScriptDom.TSqlFragment Fragment;
        public ISqlCodeType Resolved;

        public SqlCodeTypeLazy(OfaSchlupfer.ScriptDom.TSqlFragment fragment) {
            this.Fragment = fragment;
        }

        public ISqlCodeType GetResolved() {
            if (this.Resolved == null) { return null; }
            var resolvedLazy = this.Resolved as SqlCodeTypeLazy;
            if (resolvedLazy != null) {
                this.Resolved = resolvedLazy;
                return resolvedLazy.GetResolved();
            }
            return this.Resolved;
        }

        public void SetResolved(ISqlCodeType sqlCodeType) {
            if (sqlCodeType != null) {
                if (this.Resolved == null) {
                    this.Resolved = sqlCodeType;
                    return;
                } else {
                    if (System.Diagnostics.Debugger.IsAttached) {
                        System.Diagnostics.Debugger.Break();
                    }
                }
            }
        }
    }

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
