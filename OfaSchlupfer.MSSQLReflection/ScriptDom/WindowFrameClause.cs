namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class WindowFrameClause : TSqlFragment {
        private WindowDelimiter _top;

        private WindowDelimiter _bottom;

        private WindowFrameType _windowFrameType;

        public WindowDelimiter Top {
            get {
                return this._top;
            }

            set {
                this.UpdateTokenInfo(value);
                this._top = value;
            }
        }

        public WindowDelimiter Bottom {
            get {
                return this._bottom;
            }

            set {
                this.UpdateTokenInfo(value);
                this._bottom = value;
            }
        }

        public WindowFrameType WindowFrameType {
            get {
                return this._windowFrameType;
            }

            set {
                this._windowFrameType = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Top?.Accept(visitor);
            this.Bottom?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
