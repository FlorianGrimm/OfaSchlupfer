namespace OfaSchlupfer.AST {
    [System.Serializable]
    public class LiteralRange : TSqlFragment {
        private Literal _from;

        private Literal _to;

        public Literal From {
            get {
                return this._from;
            }

            set {
                this.UpdateTokenInfo(value);
                this._from = value;
            }
        }

        public Literal To {
            get {
                return this._to;
            }

            set {
                this.UpdateTokenInfo(value);
                this._to = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.From?.Accept(visitor);
            this.To?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
