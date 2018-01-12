using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class ViewOption : TSqlFragment {
        private ViewOptionKind _optionKind;

        public ViewOptionKind OptionKind {
            get {
                return this._optionKind;
            }
            set {
                this._optionKind = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
