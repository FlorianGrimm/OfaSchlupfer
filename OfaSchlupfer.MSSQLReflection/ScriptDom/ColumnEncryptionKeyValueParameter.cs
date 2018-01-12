using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class ColumnEncryptionKeyValueParameter : TSqlFragment {
        private ColumnEncryptionKeyValueParameterKind _parameterKind;

        public ColumnEncryptionKeyValueParameterKind ParameterKind {
            get {
                return this._parameterKind;
            }
            set {
                this._parameterKind = value;
            }
        }
    }
}
