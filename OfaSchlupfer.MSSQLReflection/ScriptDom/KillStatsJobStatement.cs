using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class KillStatsJobStatement : TSqlStatement {
        private ScalarExpression _jobId;

        public ScalarExpression JobId {
            get {
                return this._jobId;
            }
            set {
                base.UpdateTokenInfo(value);
                this._jobId = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.JobId?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
