namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AdHocDataSource : TSqlFragment {
        private StringLiteral _providerName;

        private StringLiteral _initString;

        public StringLiteral ProviderName {
            get {
                return this._providerName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._providerName = value;
            }
        }

        public StringLiteral InitString {
            get {
                return this._initString;
            }

            set {
                this.UpdateTokenInfo(value);
                this._initString = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.ProviderName?.Accept(visitor);
            this.InitString?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
