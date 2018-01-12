using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class SetErrorLevelStatement : TSqlStatement {
        private ScalarExpression _level;

        public ScalarExpression Level {
            get {
                return this._level;
            }
            set {
                base.UpdateTokenInfo(value);
                this._level = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Level?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
