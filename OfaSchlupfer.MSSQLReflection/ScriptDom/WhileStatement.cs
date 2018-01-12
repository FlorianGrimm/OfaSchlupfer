using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class WhileStatement : TSqlStatement {
        private BooleanExpression _predicate;

        private TSqlStatement _statement;

        public BooleanExpression Predicate {
            get {
                return this._predicate;
            }

            set {
                this.UpdateTokenInfo(value);
                this._predicate = value;
            }
        }

        public TSqlStatement Statement {
            get {
                return this._statement;
            }

            set {
                this.UpdateTokenInfo(value);
                this._statement = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Predicate?.Accept(visitor);
            this.Statement?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
