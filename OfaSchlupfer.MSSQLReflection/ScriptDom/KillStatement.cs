namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class KillStatement : TSqlStatement {
        private ScalarExpression _parameter;

        private bool _withStatusOnly;

        public ScalarExpression Parameter {
            get {
                return this._parameter;
            }

            set {
                this.UpdateTokenInfo(value);
                this._parameter = value;
            }
        }

        public bool WithStatusOnly {
            get {
                return this._withStatusOnly;
            }

            set {
                this._withStatusOnly = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Parameter?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
