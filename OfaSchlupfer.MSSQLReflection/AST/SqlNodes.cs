#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600,SA1649

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    public sealed class SqlScript : SqlNode {
        public SqlScript() : base() { }

        public SqlScript(ScriptDom.TSqlScript src) : base(src) {
            Copier.CopyList(this.Batches, src.Batches);
        }

        public List<SqlBatch> Batches { get; } = new List<SqlBatch>();

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Batches.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    public sealed class SqlBatch : SqlNode {
        public SqlBatch() : base() { }

        public SqlBatch(ScriptDom.TSqlBatch src) : base(src) {
            Copier.CopyList(this.Statements, src.Statements);
        }

        public List<SqlStatement> Statements { get; } = new List<SqlStatement>();

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Statements.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    public abstract class SqlStatement : SqlNode {
        protected SqlStatement() { }
        protected SqlStatement(ScriptDom.TSqlStatement src) : base(src) { }
    }

    [System.Serializable]
    public class StatementList : SqlNode {
        public StatementList() : base() { }
        public StatementList(ScriptDom.StatementList src) : base(src) {
            Copier.CopyList(this.Statements, src.Statements);
        }
        public List<SqlStatement> Statements { get; } = new List<SqlStatement>();

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Statements.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}