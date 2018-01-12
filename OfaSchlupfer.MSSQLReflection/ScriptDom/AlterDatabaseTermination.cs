using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AlterDatabaseTermination : TSqlFragment {
        private bool _immediateRollback;

        private Literal _rollbackAfter;

        private bool _noWait;

        public bool ImmediateRollback {
            get {
                return this._immediateRollback;
            }

            set {
                this._immediateRollback = value;
            }
        }

        public Literal RollbackAfter {
            get {
                return this._rollbackAfter;
            }

            set {
                this.UpdateTokenInfo(value);
                this._rollbackAfter = value;
            }
        }

        public bool NoWait {
            get {
                return this._noWait;
            }

            set {
                this._noWait = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.RollbackAfter?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
