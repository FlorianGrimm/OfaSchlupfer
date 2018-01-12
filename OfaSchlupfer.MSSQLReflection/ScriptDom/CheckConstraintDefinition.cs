using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class CheckConstraintDefinition : ConstraintDefinition {
        private BooleanExpression _checkCondition;

        private bool _notForReplication;

        public BooleanExpression CheckCondition {
            get {
                return this._checkCondition;
            }
            set {
                base.UpdateTokenInfo(value);
                this._checkCondition = value;
            }
        }

        public bool NotForReplication {
            get {
                return this._notForReplication;
            }
            set {
                this._notForReplication = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.CheckCondition?.Accept(visitor);
        }
    }
}
