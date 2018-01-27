#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class IdentifierOrValueExpression : SqlNode {
        public IdentifierOrValueExpression() : base() { }
        public IdentifierOrValueExpression(ScriptDom.IdentifierOrValueExpression src) : base(src) {
            this.Identifier = Copier.Copy<Identifier>(src.Identifier);
            this.ValueExpression = Copier.Copy<ValueExpression>(src.ValueExpression);
        }
        public string Value {
            get {
                if (this.Identifier != null) {
                    return this.Identifier.Value;
                }
                if (this.ValueExpression != null) {
                    Literal literal = this.ValueExpression as Literal;
                    if (literal != null) {
                        return literal.Value;
                    }
                    VariableReference variableReference = this.ValueExpression as VariableReference;
                    if (variableReference != null) {
                        return variableReference.Name;
                    }
                    GlobalVariableExpression globalVariableExpression = this.ValueExpression as GlobalVariableExpression;
                    if (globalVariableExpression != null) {
                        return globalVariableExpression.Name;
                    }
                    return null;
                }
                return null;
            }
        }
        public Identifier Identifier;
        public ValueExpression ValueExpression;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Identifier?.Accept(visitor);
            this.ValueExpression?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
