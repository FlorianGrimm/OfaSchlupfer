namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class TableValuedFunctionReturnType : FunctionReturnType {
        public TableValuedFunctionReturnType() : base() { }
        public TableValuedFunctionReturnType(ScriptDom.TableValuedFunctionReturnType src) : base(src) {
            this.DeclareTableVariableBody = Copier.Copy<DeclareTableVariableBody>(src.DeclareTableVariableBody);
        }

        public DeclareTableVariableBody DeclareTableVariableBody { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.DeclareTableVariableBody?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
