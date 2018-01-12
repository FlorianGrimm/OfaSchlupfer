using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class ColumnEncryptionDefinitionParameter : TSqlFragment {
        private ColumnEncryptionDefinitionParameterKind _parameterKind;

        public ColumnEncryptionDefinitionParameterKind ParameterKind {
            get {
                return this._parameterKind;
            }

            set {
                this._parameterKind = value;
            }
        }
    }
}
