using System.Collections.Generic;

namespace OfaSchlupfer.ModelOData.Edm {
    public class CsdlEntityTypeModel : CsdlAnnotationalModel {
        public CsdlEntityTypeModel() {
            this.Property = new List<CsdlPropertyModel>();
            this.NavigationProperty = new List<CsdlNavigationPropertyModel>();
            this.Keys = new List<CsdlPropertyRefModel>();
        }

        public string Name;
        public string BaseType;
        public bool Abstract;
        public bool OpenType;
        public bool HasStream;
        public readonly List<CsdlPropertyModel> Property;
        public readonly List<CsdlNavigationPropertyModel> NavigationProperty;
        public readonly List<CsdlPropertyRefModel> Keys;
    }
}