using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class CommandSecurityElement80 : SecurityElement80 {
        private bool _all;

        private CommandOptions _commandOptions;

        public bool All {
            get {
                return this._all;
            }

            set {
                this._all = value;
            }
        }

        public CommandOptions CommandOptions {
            get {
                return this._commandOptions;
            }

            set {
                this._commandOptions = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
