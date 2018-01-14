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
            int i = 0;
            for (int count = this.Literals.Count; i < count; i++) {
                this.Literals[i].Accept(visitor);
            }
            int j = 0;
            for (int count2 = this.Options.Count; j < count2; j++) {
                this.Options[j].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
