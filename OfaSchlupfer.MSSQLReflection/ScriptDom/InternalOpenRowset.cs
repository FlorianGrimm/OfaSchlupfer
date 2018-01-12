using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class InternalOpenRowset : TableReferenceWithAlias {
        private Identifier _identifier;

        private List<ScalarExpression> _varArgs = new List<ScalarExpression>();

        public Identifier Identifier {
            get {
                return this._identifier;
            }
            set {
                base.UpdateTokenInfo(value);
                this._identifier = value;
            }
        }

        public List<ScalarExpression> VarArgs {
            get {
                return this._varArgs;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Identifier?.Accept(visitor);
            for (int i=0, count = this.VarArgs.Count; i < count; i++) {
                this.VarArgs[i].Accept(visitor);
            }
        }
    }
}
