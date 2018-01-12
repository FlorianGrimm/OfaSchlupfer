using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class FileGrowthFileDeclarationOption : FileDeclarationOption {
        private Literal _growthIncrement;

        private MemoryUnit _units;

        public Literal GrowthIncrement {
            get {
                return this._growthIncrement;
            }
            set {
                base.UpdateTokenInfo(value);
                this._growthIncrement = value;
            }
        }

        public MemoryUnit Units {
            get {
                return this._units;
            }
            set {
                this._units = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.GrowthIncrement?.Accept(visitor);
        }
    }
}
