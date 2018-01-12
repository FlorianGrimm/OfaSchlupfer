namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class StopRestoreOption : RestoreOption {
        private ValueExpression _mark;

        private ValueExpression _after;

        private bool _isStopAt;

        public ValueExpression Mark {
            get {
                return this._mark;
            }
            set {
                base.UpdateTokenInfo(value);
                this._mark = value;
            }
        }

        public ValueExpression After {
            get {
                return this._after;
            }
            set {
                base.UpdateTokenInfo(value);
                this._after = value;
            }
        }

        public bool IsStopAt {
            get {
                return this._isStopAt;
            }
            set {
                this._isStopAt = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Mark?.Accept(visitor);
            this.After?.Accept(visitor);
        }
    }
}
