using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class SqlDataTypeReference : ParameterizedDataTypeReference {
        private SqlDataTypeOption _sqlDataTypeOption;

        public SqlDataTypeOption SqlDataTypeOption {
            get {
                return this._sqlDataTypeOption;
            }
            set {
                this._sqlDataTypeOption = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
