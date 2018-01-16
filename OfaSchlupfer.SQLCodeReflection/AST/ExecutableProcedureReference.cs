namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class ExecutableProcedureReference : ExecutableEntity {
        private ProcedureReferenceName _procedureReference;

        private AdHocDataSource _adHocDataSource;

        public ProcedureReferenceName ProcedureReference {
            get {
                return this._procedureReference;
            }

            set {
                this.UpdateTokenInfo(value);
                this._procedureReference = value;
            }
        }

        public AdHocDataSource AdHocDataSource {
            get {
                return this._adHocDataSource;
            }

            set {
                this.UpdateTokenInfo(value);
                this._adHocDataSource = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.ProcedureReference?.Accept(visitor);
            this.AdHocDataSource?.Accept(visitor);
        }
    }
}
