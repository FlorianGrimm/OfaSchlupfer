namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class GraphMatchExpression : BooleanExpression {
        private Identifier _leftNode;

        private Identifier _edge;

        private Identifier _rightNode;

        private bool _arrowOnRight;

        public Identifier LeftNode {
            get {
                return this._leftNode;
            }

            set {
                this.UpdateTokenInfo(value);
                this._leftNode = value;
            }
        }

        public Identifier Edge {
            get {
                return this._edge;
            }

            set {
                this.UpdateTokenInfo(value);
                this._edge = value;
            }
        }

        public Identifier RightNode {
            get {
                return this._rightNode;
            }

            set {
                this.UpdateTokenInfo(value);
                this._rightNode = value;
            }
        }

        public bool ArrowOnRight {
            get {
                return this._arrowOnRight;
            }

            set {
                this._arrowOnRight = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.LeftNode?.Accept(visitor);
            this.Edge?.Accept(visitor);
            this.RightNode?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
