using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class TargetDeclaration : TSqlFragment {
        private EventSessionObjectName _objectName;

        private List<EventDeclarationSetParameter> _targetDeclarationParameters = new List<EventDeclarationSetParameter>();

        public EventSessionObjectName ObjectName {
            get {
                return this._objectName;
            }
            set {
                base.UpdateTokenInfo(value);
                this._objectName = value;
            }
        }

        public List<EventDeclarationSetParameter> TargetDeclarationParameters {
            get {
                return this._targetDeclarationParameters;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.ObjectName?.Accept(visitor);
            for (int i=0, count = this.TargetDeclarationParameters.Count; i < count; i++) {
                this.TargetDeclarationParameters[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
