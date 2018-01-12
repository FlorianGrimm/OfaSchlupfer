using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class MoveToDropIndexOption : IndexOption {
        private FileGroupOrPartitionScheme _moveTo;

        public FileGroupOrPartitionScheme MoveTo {
            get {
                return this._moveTo;
            }
            set {
                base.UpdateTokenInfo(value);
                this._moveTo = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.MoveTo?.Accept(visitor);
        }
    }
}
