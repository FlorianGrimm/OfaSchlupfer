using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class WorkloadGroupImportanceParameter : WorkloadGroupParameter {
        private ImportanceParameterType _parameterValue;

        public ImportanceParameterType ParameterValue {
            get {
                return this._parameterValue;
            }

            set {
                this._parameterValue = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
