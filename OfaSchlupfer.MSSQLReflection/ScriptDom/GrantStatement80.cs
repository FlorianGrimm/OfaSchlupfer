using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class GrantStatement80 : SecurityStatementBody80 {
        private bool _withGrantOption;

        private Identifier _asClause;

        public bool WithGrantOption {
            get {
                return this._withGrantOption;
            }
            set {
                this._withGrantOption = value;
            }
        }

        public Identifier AsClause {
            get {
                return this._asClause;
            }
            set {
                base.UpdateTokenInfo(value);
                this._asClause = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.AsClause?.Accept(visitor);
        }
    }
}
