namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class ReceiveStatement : WaitForSupportedStatement {
        private ScalarExpression _top;

        private SchemaObjectName _queue;

        private VariableTableReference _into;

        private ValueExpression _where;

        public ScalarExpression Top {
            get {
                return this._top;
            }

            set {
                this.UpdateTokenInfo(value);
                this._top = value;
            }
        }

        public List<SelectElement> SelectElements { get; } = new List<SelectElement>();

        public SchemaObjectName Queue {
            get {
                return this._queue;
            }

            set {
                this.UpdateTokenInfo(value);
                this._queue = value;
            }
        }

        public VariableTableReference Into {
            get {
                return this._into;
            }

            set {
                this.UpdateTokenInfo(value);
                this._into = value;
            }
        }

        public ValueExpression Where {
            get {
                return this._where;
            }

            set {
                this.UpdateTokenInfo(value);
                this._where = value;
            }
        }

        public bool IsConversationGroupIdWhere { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Top?.Accept(visitor);
            this.SelectElements.Accept(visitor);
            this.Queue?.Accept(visitor);
            this.Into?.Accept(visitor);
            this.Where?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
