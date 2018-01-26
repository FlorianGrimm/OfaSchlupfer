namespace OfaSchlupfer.SQLReflection {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    public sealed class FromClause : SqlNode {
        public FromClause() : base() {
        }
        public FromClause(ScriptDom.FromClause src) : base(src) {
            Copier.CopyList(this.TableReferences, src.TableReferences);
        }

        public List<TableReference> TableReferences { get; } = new List<TableReference>();

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.TableReferences.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
