#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public abstract class ProcedureStatementBodyBase : SqlStatement {
        public ProcedureStatementBodyBase() : base() { }
        public ProcedureStatementBodyBase(ScriptDom.ProcedureStatementBodyBase src) : base(src) {
            Copier.CopyList(this.Parameters, src.Parameters);
            this.StatementList = Copier.Copy<StatementList>(src.StatementList);
            this.MethodSpecifier = Copier.Copy<MethodSpecifier>(src.MethodSpecifier);
        }
        public List<ProcedureParameter> Parameters { get; } = new List<ProcedureParameter>();
        public StatementList StatementList;
        public MethodSpecifier MethodSpecifier;
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Parameters.Accept(visitor);
            this.StatementList?.Accept(visitor);
            this.MethodSpecifier?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public abstract class ProcedureStatementBody : ProcedureStatementBodyBase {
        public ProcedureStatementBody() : base() { }
        public ProcedureStatementBody(ScriptDom.ProcedureStatementBody src) : base(src) {
            this.ProcedureReference = Copier.Copy<ProcedureReference>(src.ProcedureReference);
            this.IsForReplication = src.IsForReplication;
        }
        public ProcedureReference ProcedureReference;
        public bool IsForReplication;

        /*
        public List<ProcedureOption> Options { get; } = new List<ProcedureOption>();
         */
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.ProcedureReference?.Accept(visitor);
            // this.Options.Accept(visitor);
        }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class CreateOrAlterProcedureStatement : ProcedureStatementBody {
        public CreateOrAlterProcedureStatement() : base() { }
        public CreateOrAlterProcedureStatement(ScriptDom.CreateOrAlterProcedureStatement src) : base(src) { }
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.ProcedureReference?.Accept(visitor);
            this.Parameters.Accept(visitor);
            // this.Options.Accept(visitor);
            this.StatementList?.Accept(visitor);
            this.MethodSpecifier?.Accept(visitor);
        }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class CreateProcedureStatement : ProcedureStatementBody {
        public CreateProcedureStatement() : base() { }
        public CreateProcedureStatement(ScriptDom.CreateProcedureStatement src) : base(src) { }
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.ProcedureReference?.Accept(visitor);
            this.Parameters.Accept(visitor);
            // this.Options.Accept(visitor);
            this.StatementList?.Accept(visitor);
            this.MethodSpecifier?.Accept(visitor);
        }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class AlterProcedureStatement : ProcedureStatementBody {
        public AlterProcedureStatement() : base() { }
        public AlterProcedureStatement(ScriptDom.AlterProcedureStatement src) : base(src) { }
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.ProcedureReference?.Accept(visitor);
            this.Parameters.Accept(visitor);
            // this.Options.Accept(visitor);
            this.StatementList?.Accept(visitor);
            this.MethodSpecifier?.Accept(visitor);
        }
    }
}
