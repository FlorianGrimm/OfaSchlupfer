namespace OfaSchlupfer.Model {
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ModelBuilder {
        public ModelBuilder() {
            this.Rules = new List<ModelBuilderRule>();
        }

        public ModelDefinition ModelDefinition { get; set; }

        public ModelSchema ModelSchema { get; set; }

        public List<ModelBuilderRule> Rules { get; }

        public virtual List<string> Build() {
            return null;
        }
    }
}
