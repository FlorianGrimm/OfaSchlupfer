namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class PivotedTableReference : TableReferenceWithAlias {
        public PivotedTableReference() : base() { }
        public PivotedTableReference(ScriptDom.PivotedTableReference src) : base(src) {
            this.TableReference = Copier.Copy<TableReference>(src.TableReference);
            Copier.CopyList(this.InColumns, src.InColumns);
            this.PivotColumn = Copier.Copy<ColumnReferenceExpression>(src.PivotColumn);
            Copier.CopyList(this.ValueColumns, src.ValueColumns);
            this.AggregateFunctionIdentifier = Copier.Copy<MultiPartIdentifier>(src.AggregateFunctionIdentifier);
        }

        public TableReference TableReference { get; set; }

        public List<Identifier> InColumns { get; } = new List<Identifier>();

        public ColumnReferenceExpression PivotColumn { get; set; }

        public List<ColumnReferenceExpression> ValueColumns { get; } = new List<ColumnReferenceExpression>();

        public MultiPartIdentifier AggregateFunctionIdentifier { get; set; }

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
