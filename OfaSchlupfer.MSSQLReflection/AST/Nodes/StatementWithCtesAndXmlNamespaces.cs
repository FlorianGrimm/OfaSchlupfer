#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public abstract class StatementWithCtesAndXmlNamespaces : SqlStatement {
        protected StatementWithCtesAndXmlNamespaces() : base() { }

        protected StatementWithCtesAndXmlNamespaces(ScriptDom.StatementWithCtesAndXmlNamespaces src) : base() {
            this.WithCtesAndXmlNamespaces = Copier.Copy<WithCtesAndXmlNamespaces>(src.WithCtesAndXmlNamespaces);
        }
        public WithCtesAndXmlNamespaces WithCtesAndXmlNamespaces;

        /*
        public List<OptimizerHint> OptimizerHints { get; } = new List<OptimizerHint>();
         */
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.WithCtesAndXmlNamespaces?.Accept(visitor);
            // this.OptimizerHints.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public class SelectStatement : StatementWithCtesAndXmlNamespaces {
        public SelectStatement() : base() { }
        public SelectStatement(ScriptDom.SelectStatement src) : base(src) {
            this.QueryExpression = Copier.Copy<QueryExpression>(src.QueryExpression);
            this.Into = Copier.Copy<SchemaObjectName>(src.Into);
            this.On = Copier.Copy<Identifier>(src.On);
            Copier.CopyList(this.ComputeClauses, src.ComputeClauses);
        }
        public QueryExpression QueryExpression;
        public SchemaObjectName Into;
        public Identifier On;
        public List<ComputeClause> ComputeClauses { get; } = new List<ComputeClause>();
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.QueryExpression?.Accept(visitor);
            this.Into?.Accept(visitor);
            this.On?.Accept(visitor);
            this.ComputeClauses.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
