namespace OfaSchlupfer.ScriptDom {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class AlterServerConfigurationStatement : TSqlStatement {
        private ProcessAffinityType _processAffinity;

        private List<ProcessAffinityRange> _processAffinityRanges = new List<ProcessAffinityRange>();

        public ProcessAffinityType ProcessAffinity {
            get {
                return this._processAffinity;
            }

            set {
                this._processAffinity = value;
            }
        }

        public List<ProcessAffinityRange> ProcessAffinityRanges {
            get {
                return this._processAffinityRanges;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            for (int i = 0, count = this.ProcessAffinityRanges.Count; i < count; i++) {
                this.ProcessAffinityRanges[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
