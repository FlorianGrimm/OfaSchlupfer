using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class EndpointProtocolOption : TSqlFragment {
        private EndpointProtocolOptions _kind;

        public EndpointProtocolOptions Kind {
            get {
                return this._kind;
            }
            set {
                this._kind = value;
            }
        }
    }
}
