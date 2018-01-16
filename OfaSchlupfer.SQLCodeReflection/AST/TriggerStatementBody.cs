namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public abstract class TriggerStatementBody : TSqlStatement {
        private SchemaObjectName _name;

        private TriggerObject _triggerObject;

        private StatementList _statementList;

        private MethodSpecifier _methodSpecifier;

        public SchemaObjectName Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public TriggerObject TriggerObject {
            get {
                return this._triggerObject;
            }

            set {
                this.UpdateTokenInfo(value);
                this._triggerObject = value;
            }
        }

        public List<TriggerOption> Options { get; } = new List<TriggerOption>();

        public TriggerType TriggerType { get; set; }

        public List<TriggerAction> TriggerActions { get; } = new List<TriggerAction>();

        public bool WithAppend { get; set; }

        public bool IsNotForReplication { get; set; }

        public StatementList StatementList {
            get {
                return this._statementList;
            }

            set {
                this.UpdateTokenInfo(value);
                this._statementList = value;
            }
        }

        public MethodSpecifier MethodSpecifier {
            get {
                return this._methodSpecifier;
            }

            set {
                this.UpdateTokenInfo(value);
                this._methodSpecifier = value;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.TriggerObject?.Accept(visitor);
            this.Options.Accept(visitor);
            this.TriggerActions.Accept(visitor);
            this.StatementList?.Accept(visitor);
            this.MethodSpecifier?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
