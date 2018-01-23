#pragma warning disable SA1402
#pragma warning disable SA1600

namespace OfaSchlupfer.MSSQLReflection.SqlCode {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Lazy
    /// </summary>
    public sealed class SqlCodeTypeLazy : ISqlCodeType {
        public readonly OfaSchlupfer.AST.TSqlFragment Fragment;
        public ISqlCodeType Resolved;

        public SqlCodeTypeLazy(OfaSchlupfer.AST.TSqlFragment fragment) {
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
}
