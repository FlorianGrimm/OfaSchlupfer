using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class RouteOption : TSqlFragment {
        private RouteOptionKind _optionKind;

        private Literal _literal;

        public RouteOptionKind OptionKind {
            get {
                return this._optionKind;
            }
            set {
                this._optionKind = value;
            }
        }

        public Literal Literal {
            get {
                return this._literal;
            }
            set {
                base.UpdateTokenInfo(value);
                this._literal = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Literal?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
