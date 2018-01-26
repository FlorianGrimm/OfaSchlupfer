namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class ExecutableStringList : ExecutableEntity {
        public ExecutableStringList() : base() { }
        public ExecutableStringList(ScriptDom.ExecutableStringList src) : base(src) {
            Copier.CopyList(this.Strings, src.Strings);
        }
        public List<ValueExpression> Strings { get; } = new List<ValueExpression>();

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Strings.Accept(visitor);
        }
    }
}
