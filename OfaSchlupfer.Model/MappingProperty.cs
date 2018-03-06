﻿namespace OfaSchlupfer.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [Serializable]
    public class MappingProperty {
        public string SourceName;
        public string TargetName;
        [NonSerialized]
        public ModelProperty Source;
        [NonSerialized]
        public ModelProperty Target;
        public bool Enabled;
        public string Conversion;

        public string Name;


        internal void UpdateNames(ModelRoot.Current current, ModelSchema.Current sourceCurrent, ModelSchema.Current targetCurrent) {
            throw new NotImplementedException();
        }

        internal void ResolveNames(ModelRoot.Current current, ModelSchema.Current sourceCurrent, ModelSchema.Current targetCurrent) {
            throw new NotImplementedException();
        }
    }
}