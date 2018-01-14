namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class GeneralSetCommand : SetCommand {
        private GeneralSetCommandType _commandType;

        private ScalarExpression _parameter;

        public GeneralSetCommandType CommandType {
            get {
                return this._commandType;
            }

            set {
                this._commandType = value;
            }
        }

        public ScalarExpression Parameter {
            get {
                return this._parameter;
            }

            set {
                this.UpdateTokenInfo(value);
                this._parameter = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Parameter?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
