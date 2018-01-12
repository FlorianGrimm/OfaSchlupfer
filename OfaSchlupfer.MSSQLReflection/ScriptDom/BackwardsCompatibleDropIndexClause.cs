using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class BackwardsCompatibleDropIndexClause : DropIndexClauseBase {
        private ChildObjectName _index;

        public ChildObjectName Index {
            get {
                return this._index;
            }
            set {
                base.UpdateTokenInfo(value);
                this._index = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Index?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
