using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class TriggerStatementBody : TSqlStatement {
        private SchemaObjectName _name;

        private TriggerObject _triggerObject;

        private List<TriggerOption> _options = new List<TriggerOption>();

        private TriggerType _triggerType;

        private List<TriggerAction> _triggerActions = new List<TriggerAction>();

        private bool _withAppend;

        private bool _isNotForReplication;

        private StatementList _statementList;

        private MethodSpecifier _methodSpecifier;

        public SchemaObjectName Name {
            get {
                return this._name;
            }
            set {
                base.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public TriggerObject TriggerObject {
            get {
                return this._triggerObject;
            }
            set {
                base.UpdateTokenInfo(value);
                this._triggerObject = value;
            }
        }

        public List<TriggerOption> Options {
            get {
                return this._options;
            }
        }

        public TriggerType TriggerType {
            get {
                return this._triggerType;
            }
            set {
                this._triggerType = value;
            }
        }

        public List<TriggerAction> TriggerActions {
            get {
                return this._triggerActions;
            }
        }

        public bool WithAppend {
            get {
                return this._withAppend;
            }
            set {
                this._withAppend = value;
            }
        }

        public bool IsNotForReplication {
            get {
                return this._isNotForReplication;
            }
            set {
                this._isNotForReplication = value;
            }
        }

        public StatementList StatementList {
            get {
                return this._statementList;
            }
            set {
                base.UpdateTokenInfo(value);
                this._statementList = value;
            }
        }

        public MethodSpecifier MethodSpecifier {
            get {
                return this._methodSpecifier;
            }
            set {
                base.UpdateTokenInfo(value);
                this._methodSpecifier = value;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.TriggerObject?.Accept(visitor);
            for (int i=0, count = this.Options.Count; i < count; i++) {
                this.Options[i].Accept(visitor);
            }
            int j = 0;
            for (int count2 = this.TriggerActions.Count; j < count2; j++) {
                this.TriggerActions[j].Accept(visitor);
            }
            this.StatementList?.Accept(visitor);
            this.MethodSpecifier?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
