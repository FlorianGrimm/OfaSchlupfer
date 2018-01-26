#pragma warning disable SA1402
#pragma warning disable SA1600

namespace OfaSchlupfer.MSSQLReflection.SqlCode {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OfaSchlupfer.MSSQLReflection.AST;

    /// <summary>
    /// Lazy
    /// </summary>
    public sealed class SqlCodeTypeLazy : ISqlCodeType {
        public readonly SqlNode Fragment;
        public ISqlCodeType Resolved;

        public SqlCodeTypeLazy(SqlNode fragment) {
            this.Fragment = fragment;
        }

        public ISqlCodeType GetResolvedCodeType() {
            if (this.Resolved == null) { return null; }
            var resolvedLazy = this.Resolved as SqlCodeTypeLazy;
            if (resolvedLazy != null) {
                this.Resolved = resolvedLazy;
                return resolvedLazy.GetResolvedCodeType();
            }
            return this.Resolved;
        }

        public void SetResolvedCodeType(ISqlCodeType sqlCodeType) {
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
