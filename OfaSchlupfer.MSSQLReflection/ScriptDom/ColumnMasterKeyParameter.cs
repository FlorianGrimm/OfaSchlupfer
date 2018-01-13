namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class ColumnMasterKeyParameter : TSqlFragment {
        private ColumnMasterKeyParameterKind _parameterKind;

        public ColumnMasterKeyParameterKind ParameterKind {
            get {
                return this._parameterKind;
            }

            set {
                this._parameterKind = value;
            }
        }
    }
}
