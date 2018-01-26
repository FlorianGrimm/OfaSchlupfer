namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class SetOffsetsStatement : SetOnOffStatement {
        public SetOffsetsStatement() : base() { }
        public SetOffsetsStatement(ScriptDom.SetOffsetsStatement src) : base(src) {
            this.Options = src.Options;
        }
        public Microsoft.SqlServer.TransactSql.ScriptDom.SetOffsets Options { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
