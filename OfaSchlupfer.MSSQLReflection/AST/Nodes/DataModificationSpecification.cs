#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public abstract class DataModificationSpecification : SqlNode {
        public DataModificationSpecification() : base() { }
        public DataModificationSpecification(ScriptDom.DataModificationSpecification src) : base(src) {
            this.Target = Copier.Copy<TableReference>(src.Target);
            this.TopRowFilter = Copier.Copy<TopRowFilter>(src.TopRowFilter);
            this.OutputIntoClause = Copier.Copy<OutputIntoClause>(src.OutputIntoClause);
            this.OutputClause = Copier.Copy<OutputClause>(src.OutputClause);
        }
        public TableReference Target;
        public TopRowFilter TopRowFilter;
        public OutputIntoClause OutputIntoClause;
        public OutputClause OutputClause;
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Target?.Accept(visitor);
            this.TopRowFilter?.Accept(visitor);
            this.OutputIntoClause?.Accept(visitor);
            this.OutputClause?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public abstract class UpdateDeleteSpecificationBase : DataModificationSpecification {
        public UpdateDeleteSpecificationBase() : base() { }
        public UpdateDeleteSpecificationBase(ScriptDom.UpdateDeleteSpecificationBase src) : base(src) {
            this.FromClause = Copier.Copy<FromClause>(src.FromClause);
            this.WhereClause = Copier.Copy<WhereClause>(src.WhereClause);
        }
        public FromClause FromClause;
        public WhereClause WhereClause;
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.FromClause?.Accept(visitor);
            this.WhereClause?.Accept(visitor);
        }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class InsertSpecification : DataModificationSpecification {
        public InsertSpecification() : base() { }
        public InsertSpecification(ScriptDom.InsertSpecification src) : base(src) {
            this.InsertOption = src.InsertOption;
            this.InsertSource = Copier.Copy<InsertSource>(src.InsertSource);
            Copier.CopyList(this.Columns, src.Columns);
        }
        public Microsoft.SqlServer.TransactSql.ScriptDom.InsertOption InsertOption;
        public InsertSource InsertSource;
        public List<ColumnReferenceExpression> Columns { get; } = new List<ColumnReferenceExpression>();
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.InsertSource?.Accept(visitor);
            this.Columns.Accept(visitor);
        }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class UpdateSpecification : UpdateDeleteSpecificationBase {
        public UpdateSpecification() : base() { }
        public UpdateSpecification(ScriptDom.UpdateSpecification src) : base(src) {
            Copier.CopyList(this.SetClauses, src.SetClauses);
        }
        public List<SetClause> SetClauses { get; } = new List<SetClause>();
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.SetClauses.Accept(visitor);
        }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class DeleteSpecification : UpdateDeleteSpecificationBase {
        public DeleteSpecification() : base() { }
        public DeleteSpecification(ScriptDom.DeleteSpecification src) : base(src) { }
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class MergeSpecification : DataModificationSpecification {
        public MergeSpecification() : base() { }
        public MergeSpecification(ScriptDom.MergeSpecification src) : base(src) {
            this.TableAlias = Copier.Copy<Identifier>(src.TableAlias);
            this.TableReference = Copier.Copy<TableReference>(src.TableReference);
            this.SearchCondition = Copier.Copy<BooleanExpression>(src.SearchCondition);
            Copier.CopyList(this.ActionClauses, src.ActionClauses);
        }
        public Identifier TableAlias;
        public TableReference TableReference;
        public BooleanExpression SearchCondition;
        public List<MergeActionClause> ActionClauses { get; } = new List<MergeActionClause>();
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.TableAlias?.Accept(visitor);
            this.TableReference?.Accept(visitor);
            this.SearchCondition?.Accept(visitor);
            this.ActionClauses.Accept(visitor);
        }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class InsertStatement : DataModificationStatement {
        public InsertStatement() : base() { }
        public InsertStatement(ScriptDom.InsertStatement src) : base(src) {
            this.InsertSpecification = Copier.Copy<InsertSpecification>(src.InsertSpecification);
        }
        public InsertSpecification InsertSpecification;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.InsertSpecification?.Accept(visitor);
        }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class UpdateStatement : DataModificationStatement {
        public UpdateStatement() : base() { }
        public UpdateStatement(ScriptDom.UpdateStatement src) : base(src) {
            this.UpdateSpecification = Copier.Copy<UpdateSpecification>(src.UpdateSpecification);
        }
        public UpdateSpecification UpdateSpecification;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.UpdateSpecification?.Accept(visitor);
        }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class DeleteStatement : DataModificationStatement {
        public DeleteStatement() : base() { }
        public DeleteStatement(ScriptDom.DeleteStatement src) : base(src) {
            this.DeleteSpecification = Copier.Copy<DeleteSpecification>(src.DeleteSpecification);
        }
        public DeleteSpecification DeleteSpecification;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.DeleteSpecification?.Accept(visitor);
        }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class MergeStatement : DataModificationStatement {
        public MergeStatement() : base() { }
        public MergeStatement(ScriptDom.MergeStatement src) : base(src) {
            this.MergeSpecification = Copier.Copy<MergeSpecification>(src.MergeSpecification);
        }
        public MergeSpecification MergeSpecification;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.MergeSpecification?.Accept(visitor);
        }
    }
}
