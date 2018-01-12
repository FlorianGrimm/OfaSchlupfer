using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class ColumnEncryptionDefinition : TSqlFragment {
        private List<ColumnEncryptionDefinitionParameter> _parameters = new List<ColumnEncryptionDefinitionParameter>();

        public List<ColumnEncryptionDefinitionParameter> Parameters {
            get {
                return this._parameters;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
