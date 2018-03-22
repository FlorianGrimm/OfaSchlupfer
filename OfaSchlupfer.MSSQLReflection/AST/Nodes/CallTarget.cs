#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    /// <summary>
    /// usd in <see cref="FunctionCall.CallTarget"/>.
    /// </summary>
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public abstract class CallTarget : SqlNode {
        public CallTarget() : base() { }
        public CallTarget(ScriptDom.CallTarget src) : base(src) { }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class MultiPartIdentifierCallTarget : CallTarget {
        public MultiPartIdentifierCallTarget() : base() { }
        public MultiPartIdentifierCallTarget(ScriptDom.MultiPartIdentifierCallTarget src) : base(src) {
            this.MultiPartIdentifier = Copier.Copy<MultiPartIdentifier>(src.MultiPartIdentifier);
        }
        public MultiPartIdentifier MultiPartIdentifier;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.MultiPartIdentifier?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class ExpressionCallTarget : CallTarget {
        public ExpressionCallTarget() : base() { }
        public ExpressionCallTarget(ScriptDom.ExpressionCallTarget src) : base(src) {
            this.Expression = Copier.Copy<ScalarExpression>(src.Expression);
        }
        public ScalarExpression Expression;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Expression?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class UserDefinedTypeCallTarget : CallTarget {
        public UserDefinedTypeCallTarget() : base() { }
        public UserDefinedTypeCallTarget(ScriptDom.UserDefinedTypeCallTarget src) : base(src) {
            this.SchemaObjectName = Copier.Copy<SchemaObjectName>(src.SchemaObjectName);
        }
        public SchemaObjectName SchemaObjectName;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.SchemaObjectName?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
