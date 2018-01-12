namespace OfaSchlupfer.ScriptDom.ScriptGenerator {
    internal class AlignmentPoint {
        private string _name;

        public string Name {
            get {
                return this._name;
            }
        }

        public AlignmentPoint()
            : this(null) {
        }

        public AlignmentPoint(string name) {
            this._name = name;
        }
    }
}
