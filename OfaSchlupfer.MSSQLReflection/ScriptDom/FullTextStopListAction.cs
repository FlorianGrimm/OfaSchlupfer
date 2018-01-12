using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class FullTextStopListAction : TSqlFragment {
        private bool _isAdd;

        private bool _isAll;

        private Literal _stopWord;

        private IdentifierOrValueExpression _languageTerm;

        public bool IsAdd {
            get {
                return this._isAdd;
            }

            set {
                this._isAdd = value;
            }
        }

        public bool IsAll {
            get {
                return this._isAll;
            }

            set {
                this._isAll = value;
            }
        }

        public Literal StopWord {
            get {
                return this._stopWord;
            }

            set {
                this.UpdateTokenInfo(value);
                this._stopWord = value;
            }
        }

        public IdentifierOrValueExpression LanguageTerm {
            get {
                return this._languageTerm;
            }

            set {
                this.UpdateTokenInfo(value);
                this._languageTerm = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.StopWord?.Accept(visitor);
            this.LanguageTerm?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
