using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AlterFullTextStopListStatement : TSqlStatement {
        private Identifier _name;

        private FullTextStopListAction _action;

        public Identifier Name {
            get {
                return this._name;
            }
            set {
                base.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public FullTextStopListAction Action {
            get {
                return this._action;
            }
            set {
                base.UpdateTokenInfo(value);
                this._action = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.Action?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
