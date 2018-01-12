using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class FullTextIndexColumn : TSqlFragment {
        private Identifier _name;

        private Identifier _typeColumn;

        private IdentifierOrValueExpression _languageTerm;

        private bool _statisticalSemantics;

        public Identifier Name {
            get {
                return this._name;
            }
            set {
                base.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public Identifier TypeColumn {
            get {
                return this._typeColumn;
            }
            set {
                base.UpdateTokenInfo(value);
                this._typeColumn = value;
            }
        }

        public IdentifierOrValueExpression LanguageTerm {
            get {
                return this._languageTerm;
            }
            set {
                base.UpdateTokenInfo(value);
                this._languageTerm = value;
            }
        }

        public bool StatisticalSemantics {
            get {
                return this._statisticalSemantics;
            }
            set {
                this._statisticalSemantics = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.TypeColumn?.Accept(visitor);
            this.LanguageTerm?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
