namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class SetCommandStatement : SqlStatement {
        public SetCommandStatement() : base() { }
        public SetCommandStatement(ScriptDom.SetCommandStatement src) : base(src) {
            Copier.CopyList(this.Commands, src.Commands);
        }
        public List<SetCommand> Commands { get; } = new List<SetCommand>();

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Commands.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
