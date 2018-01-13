namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class WorkloadGroupParameter : TSqlFragment {
        private WorkloadGroupParameterType _parameterType;

        public WorkloadGroupParameterType ParameterType {
            get {
                return this._parameterType;
            }

            set {
                this._parameterType = value;
            }
        }
    }
}
