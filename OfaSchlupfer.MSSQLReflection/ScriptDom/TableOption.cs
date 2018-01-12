using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class TableOption : TSqlFragment {
        private TableOptionKind _optionKind;

        public TableOptionKind OptionKind {
            get {
                return this._optionKind;
            }
            set {
                this._optionKind = value;
            }
        }
    }
}
