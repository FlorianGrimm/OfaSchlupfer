namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class TableValuedFunctionReturnType : FunctionReturnType {
        private DeclareTableVariableBody _declareTableVariableBody;

        public DeclareTableVariableBody DeclareTableVariableBody {
            get {
                return this._declareTableVariableBody;
            }

            set {
                this.UpdateTokenInfo(value);
                this._declareTableVariableBody = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.DeclareTableVariableBody?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
