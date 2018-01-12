using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class QueryStoreDesiredStateOption : QueryStoreOption {
        private QueryStoreDesiredStateOptionKind _value;

        private bool _operationModeSpecified;

        public QueryStoreDesiredStateOptionKind Value {
            get {
                return this._value;
            }
            set {
                this._value = value;
            }
        }

        public bool OperationModeSpecified {
            get {
                return this._operationModeSpecified;
            }
            set {
                this._operationModeSpecified = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
