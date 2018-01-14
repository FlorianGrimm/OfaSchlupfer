namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class SetCommandStatement : TSqlStatement {
        private List<SetCommand> _commands = new List<SetCommand>();

        public List<SetCommand> Commands {
            get {
                return this._commands;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            for (int i = 0, count = this.Commands.Count; i < count; i++) {
                this.Commands[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
