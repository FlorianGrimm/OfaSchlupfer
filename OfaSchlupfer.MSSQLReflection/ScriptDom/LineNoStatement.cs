namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class LineNoStatement : TSqlStatement {
        private IntegerLiteral _lineNo;

        public IntegerLiteral LineNo {
            get {
                return this._lineNo;
            }

            set {
                this.UpdateTokenInfo(value);
                this._lineNo = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.LineNo?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
