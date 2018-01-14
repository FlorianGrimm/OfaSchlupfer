namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class SecurityPredicateAction : TSqlFragment {
        private SecurityPredicateActionType _actionType;

        private SecurityPredicateType _securityPredicateType;

        private FunctionCall _functionCall;

        private SchemaObjectName _targetObjectName;

        private SecurityPredicateOperation _securityPredicateOperation;

        public SecurityPredicateActionType ActionType {
            get {
                return this._actionType;
            }

            set {
                this._actionType = value;
            }
        }

        public SecurityPredicateType SecurityPredicateType {
            get {
                return this._securityPredicateType;
            }

            set {
                this._securityPredicateType = value;
            }
        }

        public FunctionCall FunctionCall {
            get {
                return this._functionCall;
            }

            set {
                this.UpdateTokenInfo(value);
                this._functionCall = value;
            }
        }

        public SchemaObjectName TargetObjectName {
            get {
                return this._targetObjectName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._targetObjectName = value;
            }
        }

        public SecurityPredicateOperation SecurityPredicateOperation {
            get {
                return this._securityPredicateOperation;
            }

            set {
                this._securityPredicateOperation = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.FunctionCall?.Accept(visitor);
            this.TargetObjectName?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
