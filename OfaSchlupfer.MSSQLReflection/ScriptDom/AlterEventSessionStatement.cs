namespace OfaSchlupfer.ScriptDom {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class AlterEventSessionStatement : EventSessionStatement {
        private AlterEventSessionStatementType _statementType;

        private List<EventSessionObjectName> _dropEventDeclarations = new List<EventSessionObjectName>();

        private List<EventSessionObjectName> _dropTargetDeclarations = new List<EventSessionObjectName>();

        public AlterEventSessionStatementType StatementType {
            get {
                return this._statementType;
            }

            set {
                this._statementType = value;
            }
        }

        public List<EventSessionObjectName> DropEventDeclarations {
            get {
                return this._dropEventDeclarations;
            }
        }

        public List<EventSessionObjectName> DropTargetDeclarations {
            get {
                return this._dropTargetDeclarations;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            for (int i = 0, count = this.DropEventDeclarations.Count; i < count; i++) {
                this.DropEventDeclarations[i].Accept(visitor);
            }
            int j = 0;
            for (int count2 = this.DropTargetDeclarations.Count; j < count2; j++) {
                this.DropTargetDeclarations[j].Accept(visitor);
            }
        }
    }
}
