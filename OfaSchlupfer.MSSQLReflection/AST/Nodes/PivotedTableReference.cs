#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class PivotedTableReference : TableReferenceWithAlias {
        public PivotedTableReference() : base() { }
        public PivotedTableReference(ScriptDom.PivotedTableReference src) : base(src) {
            this.TableReference = Copier.Copy<TableReference>(src.TableReference);
            Copier.CopyList(this.InColumns, src.InColumns);
            this.PivotColumn = Copier.Copy<ColumnReferenceExpression>(src.PivotColumn);
            Copier.CopyList(this.ValueColumns, src.ValueColumns);
            this.AggregateFunctionIdentifier = Copier.Copy<MultiPartIdentifier>(src.AggregateFunctionIdentifier);
        }
        public TableReference TableReference;
        public List<Identifier> InColumns { get; } = new List<Identifier>();
        public ColumnReferenceExpression PivotColumn;
        public List<ColumnReferenceExpression> ValueColumns { get; } = new List<ColumnReferenceExpression>();
        public MultiPartIdentifier AggregateFunctionIdentifier;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.TableReference?.Accept(visitor);
            this.InColumns.Accept(visitor);
            this.PivotColumn?.Accept(visitor);
            this.ValueColumns.Accept(visitor);
            this.AggregateFunctionIdentifier?.Accept(visitor);
        }
    }
}
