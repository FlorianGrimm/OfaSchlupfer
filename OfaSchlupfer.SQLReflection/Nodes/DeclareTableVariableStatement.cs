namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class DeclareTableVariableStatement : SqlStatement {
        public DeclareTableVariableStatement() : base() { }
        public DeclareTableVariableStatement(ScriptDom.DeclareTableVariableStatement src) : base(src) {
            this.Body = Copier.Copy<DeclareTableVariableBody>(src.Body);
        }
        public DeclareTableVariableBody Body { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Body?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
    
    [System.Serializable]
    public sealed class DeclareTableVariableBody : SqlNode {
        public DeclareTableVariableBody() : base() { }
        public DeclareTableVariableBody(ScriptDom.DeclareTableVariableBody src) : base(src) {
            this.VariableName = Copier.Copy<Identifier>(src.VariableName);
            this.AsDefined = src.AsDefined;
            this.Definition = Copier.Copy<TableDefinition>(src.Definition);
        }

        public Identifier VariableName { get; set; }

        public bool AsDefined { get; set; }

        public TableDefinition Definition { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.VariableName?.Accept(visitor);
            this.Definition?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
