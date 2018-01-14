namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class FullTextStopListAction : TSqlFragment {
        private Literal _stopWord;

        private IdentifierOrValueExpression _languageTerm;

        public bool IsAdd { get; set; }

        public bool IsAll { get; set; }

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
