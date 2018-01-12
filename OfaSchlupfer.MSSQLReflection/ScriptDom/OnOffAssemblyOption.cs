using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class OnOffAssemblyOption : AssemblyOption {
        private OptionState _optionState;

        public OptionState OptionState {
            get {
                return this._optionState;
            }
            set {
                this._optionState = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
