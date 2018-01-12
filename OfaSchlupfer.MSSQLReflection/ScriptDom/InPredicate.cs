using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class InPredicate : BooleanExpression {
        private ScalarExpression _expression;

        private ScalarSubquery _subquery;

        private bool _notDefined;

        private List<ScalarExpression> _values = new List<ScalarExpression>();

        public ScalarExpression Expression {
            get {
                return this._expression;
            }

            set {
                this.UpdateTokenInfo(value);
                this._expression = value;
            }
        }

        public ScalarSubquery Subquery {
            get {
                return this._subquery;
            }

            set {
                this.UpdateTokenInfo(value);
                this._subquery = value;
            }
        }

        public bool NotDefined {
            get {
                return this._notDefined;
            }

            set {
                this._notDefined = value;
            }
        }

        public List<ScalarExpression> Values {
            get {
                return this._values;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Expression?.Accept(visitor);
            this.Subquery?.Accept(visitor);
            for (int i=0, count = this.Values.Count; i < count; i++) {
                this.Values[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
