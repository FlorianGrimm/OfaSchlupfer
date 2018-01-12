using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class CursorOption : TSqlFragment {
        private CursorOptionKind _optionKind;

        public CursorOptionKind OptionKind {
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
