namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class MethodSpecifier : SqlNode {
        public MethodSpecifier() : base() { }
        public MethodSpecifier(ScriptDom.MethodSpecifier src) : base(src) {
            this.AssemblyName = Copier.Copy<Identifier>(src.AssemblyName);
            this.ClassName = Copier.Copy<Identifier>(src.ClassName);
            this.MethodName = Copier.Copy<Identifier>(src.MethodName);
        }

        public Identifier AssemblyName { get; set; }

        public Identifier ClassName { get; set; }

        public Identifier MethodName { get; set; }


        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.AssemblyName?.Accept(visitor);
            this.ClassName?.Accept(visitor);
            this.MethodName?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
