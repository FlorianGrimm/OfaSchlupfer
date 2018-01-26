namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
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

        public Identifier Identifier { get; set; }
        public ValueExpression ValueExpression { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Identifier?.Accept(visitor);
            this.ValueExpression?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
