namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class GeneralSetCommand : SetCommand {
        public GeneralSetCommand() : base() { }
        public GeneralSetCommand(ScriptDom.GeneralSetCommand src) : base(src) {
            this.CommandType = src.CommandType;
            this.Parameter = Copier.Copy<ScalarExpression>(src.Parameter);
        }
        public Microsoft.SqlServer.TransactSql.ScriptDom.GeneralSetCommandType CommandType { get; set; }

        public ScalarExpression Parameter { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Parameter?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
