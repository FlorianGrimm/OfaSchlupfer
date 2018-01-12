using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class UpdateDeleteSpecificationBase : DataModificationSpecification {
        private FromClause _fromClause;

        private WhereClause _whereClause;

        public FromClause FromClause {
            get {
                return this._fromClause;
            }

            set {
                this.UpdateTokenInfo(value);
                this._fromClause = value;
            }
        }

        public WhereClause WhereClause {
            get {
                return this._whereClause;
            }

            set {
                this.UpdateTokenInfo(value);
                this._whereClause = value;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.FromClause?.Accept(visitor);
            this.WhereClause?.Accept(visitor);
        }
    }
}
