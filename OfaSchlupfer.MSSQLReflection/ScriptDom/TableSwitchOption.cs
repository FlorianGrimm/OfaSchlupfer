using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class TableSwitchOption : TSqlFragment {
        private TableSwitchOptionKind _optionKind;

        public TableSwitchOptionKind OptionKind {
            get {
                return this._optionKind;
            }
            set {
                this._optionKind = value;
            }
        }
    }
}
