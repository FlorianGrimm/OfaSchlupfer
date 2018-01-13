namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class SetSearchPropertyListAlterFullTextIndexAction : AlterFullTextIndexAction {
        private SearchPropertyListFullTextIndexOption _searchPropertyListOption;

        private bool _withNoPopulation;

        public SearchPropertyListFullTextIndexOption SearchPropertyListOption {
            get {
                return this._searchPropertyListOption;
            }

            set {
                this.UpdateTokenInfo(value);
                this._searchPropertyListOption = value;
            }
        }

        public bool WithNoPopulation {
            get {
                return this._withNoPopulation;
            }

            set {
                this._withNoPopulation = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.SearchPropertyListOption?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
