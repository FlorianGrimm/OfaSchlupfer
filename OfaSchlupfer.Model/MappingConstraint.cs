namespace OfaSchlupfer.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    [Serializable]
    public class MappingConstraint {
        public string SourceName;
        public string TargetName;
        [NonSerialized]
        public ModelConstraint Source;
        [NonSerialized]
        public ModelConstraint Target;

        public string Name;

        internal void UpdateNames(ModelRoot.Current current, ModelSchema.Current sourceCurrent, ModelSchema.Current targetCurrent) {
            throw new NotImplementedException();
        }

        internal void ResolveNames(ModelRoot.Current current, ModelSchema.Current sourceCurrent, ModelSchema.Current targetCurrent) {
            throw new NotImplementedException();
        }
    }
}