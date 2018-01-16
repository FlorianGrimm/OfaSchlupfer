namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class DbccStatement : TSqlStatement {
        public string DllName { get; set; }

        public DbccCommand Command { get; set; }

        public bool ParenthesisRequired { get; set; }

        public List<DbccNamedLiteral> Literals { get; } = new List<DbccNamedLiteral>();

        public List<DbccOption> Options { get; } = new List<DbccOption>();

        public bool OptionsUseJoin { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Literals.Accept(visitor);
            this.Options.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
