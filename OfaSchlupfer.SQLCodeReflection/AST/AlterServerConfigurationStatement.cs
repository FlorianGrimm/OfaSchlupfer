namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class AlterServerConfigurationStatement : TSqlStatement {
        private ProcessAffinityType _processAffinity;

        public ProcessAffinityType ProcessAffinity {
            get {
                return this._processAffinity;
            }

            set {
                this._processAffinity = value;
            }
        }

        public List<ProcessAffinityRange> ProcessAffinityRanges { get; } = new List<ProcessAffinityRange>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.ProcessAffinityRanges.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
