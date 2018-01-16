namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class AlterEventSessionStatement : EventSessionStatement {
        private AlterEventSessionStatementType _statementType;

        public AlterEventSessionStatementType StatementType {
            get {
                return this._statementType;
            }

            set {
                this._statementType = value;
            }
        }

        public List<EventSessionObjectName> DropEventDeclarations { get; } = new List<EventSessionObjectName>();

        public List<EventSessionObjectName> DropTargetDeclarations { get; } = new List<EventSessionObjectName>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.DropEventDeclarations.Accept(visitor);
            this.DropTargetDeclarations.Accept(visitor);
        }
    }
}
