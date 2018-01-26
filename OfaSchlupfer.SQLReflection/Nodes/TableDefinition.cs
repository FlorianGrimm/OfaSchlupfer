namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class TableDefinition : SqlNode {
        public TableDefinition() : base() { }
        public TableDefinition(ScriptDom.TableDefinition src) : base(src) {
            Copier.CopyList(this.ColumnDefinitions, src.ColumnDefinitions);
            Copier.CopyList(this.TableConstraints, src.TableConstraints);
        }

        public List<ColumnDefinition> ColumnDefinitions { get; } = new List<ColumnDefinition>();

        public List<ConstraintDefinition> TableConstraints { get; } = new List<ConstraintDefinition>();

        // public List<IndexDefinition> Indexes { get; } = new List<IndexDefinition>();
        // public SystemTimePeriodDefinition SystemTimePeriod { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.ColumnDefinitions.Accept(visitor);
            this.TableConstraints.Accept(visitor);
            // this.Indexes.Accept(visitor);
            // this.SystemTimePeriod?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
