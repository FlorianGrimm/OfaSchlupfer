using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AlterColumnAlterFullTextIndexAction : AlterFullTextIndexAction {
        private FullTextIndexColumn _column;

        private bool _withNoPopulation;

        public FullTextIndexColumn Column {
            get {
                return this._column;
            }
            set {
                base.UpdateTokenInfo(value);
                this._column = value;
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
            this.Column?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
