namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class SetVariableStatement : SqlStatement {
        public SetVariableStatement() : base() { }
        public SetVariableStatement(ScriptDom.SetVariableStatement src) : base(src) {
            this.Variable = Copier.Copy<VariableReference>(src.Variable);
            this.SeparatorType = src.SeparatorType;
            this.Identifier = Copier.Copy<Identifier>(src.Identifier);
            this.FunctionCallExists = src.FunctionCallExists;
            Copier.CopyList(this.Parameters, src.Parameters);
            this.Expression = Copier.Copy<ScalarExpression>(src.Expression);
            this.CursorDefinition = Copier.Copy<CursorDefinition>(src.CursorDefinition);
            this.AssignmentKind = src.AssignmentKind;
        }

        public VariableReference Variable { get; set; }

        public Microsoft.SqlServer.TransactSql.ScriptDom.SeparatorType SeparatorType { get; set; }

        public Identifier Identifier { get; set; }

        public bool FunctionCallExists { get; set; }

        public List<ScalarExpression> Parameters { get; } = new List<ScalarExpression>();

        public ScalarExpression Expression { get; set; }

        public CursorDefinition CursorDefinition { get; set; }

        public Microsoft.SqlServer.TransactSql.ScriptDom.AssignmentKind AssignmentKind { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Variable?.Accept(visitor);
            this.Identifier?.Accept(visitor);
            this.Parameters.Accept(visitor);
            this.Expression?.Accept(visitor);
            this.CursorDefinition?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
