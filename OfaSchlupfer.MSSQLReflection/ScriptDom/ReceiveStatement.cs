using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class ReceiveStatement : WaitForSupportedStatement {
        private ScalarExpression _top;

        private List<SelectElement> _selectElements = new List<SelectElement>();

        private SchemaObjectName _queue;

        private VariableTableReference _into;

        private ValueExpression _where;

        private bool _isConversationGroupIdWhere;

        public ScalarExpression Top {
            get {
                return this._top;
            }
            set {
                base.UpdateTokenInfo(value);
                this._top = value;
            }
        }

        public List<SelectElement> SelectElements {
            get {
                return this._selectElements;
            }
        }

        public SchemaObjectName Queue {
            get {
                return this._queue;
            }
            set {
                base.UpdateTokenInfo(value);
                this._queue = value;
            }
        }

        public VariableTableReference Into {
            get {
                return this._into;
            }
            set {
                base.UpdateTokenInfo(value);
                this._into = value;
            }
        }

        public ValueExpression Where {
            get {
                return this._where;
            }
            set {
                base.UpdateTokenInfo(value);
                this._where = value;
            }
        }

        public bool IsConversationGroupIdWhere {
            get {
                return this._isConversationGroupIdWhere;
            }
            set {
                this._isConversationGroupIdWhere = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Top?.Accept(visitor);
            for (int i=0, count = this.SelectElements.Count; i < count; i++) {
                this.SelectElements[i].Accept(visitor);
            }
            this.Queue?.Accept(visitor);
            this.Into?.Accept(visitor);
            this.Where?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
