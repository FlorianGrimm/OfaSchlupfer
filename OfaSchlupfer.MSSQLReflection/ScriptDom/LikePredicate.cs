namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class LikePredicate : BooleanExpression {
        private ScalarExpression _firstExpression;

        private ScalarExpression _secondExpression;

        private bool _notDefined;

        private bool _odbcEscape;

        private ScalarExpression _escapeExpression;

        public ScalarExpression FirstExpression {
            get {
                return this._firstExpression;
            }

            set {
                this.UpdateTokenInfo(value);
                this._firstExpression = value;
            }
        }

        public ScalarExpression SecondExpression {
            get {
                return this._secondExpression;
            }

            set {
                this.UpdateTokenInfo(value);
                this._secondExpression = value;
            }
        }

        public bool NotDefined {
            get {
                return this._notDefined;
            }

            set {
                this._notDefined = value;
            }
        }

        public bool OdbcEscape {
            get {
                return this._odbcEscape;
            }

            set {
                this._odbcEscape = value;
            }
        }

        public ScalarExpression EscapeExpression {
            get {
                return this._escapeExpression;
            }

            set {
                this.UpdateTokenInfo(value);
                this._escapeExpression = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.FirstExpression?.Accept(visitor);
            this.SecondExpression?.Accept(visitor);
            this.EscapeExpression?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
