namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class SetCommandStatement : TSqlStatement {
        public List<SetCommand> Commands { get; } = new List<SetCommand>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Commands.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
