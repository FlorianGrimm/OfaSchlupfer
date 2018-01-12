using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class RemoteServiceBindingOption : TSqlFragment {
        private RemoteServiceBindingOptionKind _optionKind;

        public RemoteServiceBindingOptionKind OptionKind {
            get {
                return this._optionKind;
            }
            set {
                this._optionKind = value;
            }
        }
    }
}
