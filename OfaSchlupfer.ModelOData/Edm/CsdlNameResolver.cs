namespace OfaSchlupfer.ModelOData.Edm {
    using System;
    using System.Collections.Generic;

    public class CsdlNameResolver {
        public readonly List<Item> Items;
        public CsdlNameResolver() {
            this.Items = new List<Item>();
        }

        public void AddCoreElements() {
            this.AddScalarType(new CsdlScalarTypeModel("Edm", "Binary"));
            this.AddScalarType(new CsdlScalarTypeModel("Edm", "Boolean"));
            this.AddScalarType(new CsdlScalarTypeModel("Edm", "Byte"));
            this.AddScalarType(new CsdlScalarTypeModel("Edm", "DateTime"));
            this.AddScalarType(new CsdlScalarTypeModel("Edm", "Decimal"));
            this.AddScalarType(new CsdlScalarTypeModel("Edm", "Double"));
            this.AddScalarType(new CsdlScalarTypeModel("Edm", "Single"));
            this.AddScalarType(new CsdlScalarTypeModel("Edm", "Guid"));
            this.AddScalarType(new CsdlScalarTypeModel("Edm", "Int16"));
            this.AddScalarType(new CsdlScalarTypeModel("Edm", "Int32"));
            this.AddScalarType(new CsdlScalarTypeModel("Edm", "Int64"));
            this.AddScalarType(new CsdlScalarTypeModel("Edm", "SByte"));
            this.AddScalarType(new CsdlScalarTypeModel("Edm", "String"));
            this.AddScalarType(new CsdlScalarTypeModel("Edm", "Time"));
            this.AddScalarType(new CsdlScalarTypeModel("Edm", "DateTimeOffset"));
            this.AddScalarType(new CsdlScalarTypeModel("Edm", "Geography"));
            this.AddScalarType(new CsdlScalarTypeModel("Edm", "GeographyPoint"));
            this.AddScalarType(new CsdlScalarTypeModel("Edm", "GeographyLineString"));
            this.AddScalarType(new CsdlScalarTypeModel("Edm", "GeographyPolygon"));
            this.AddScalarType(new CsdlScalarTypeModel("Edm", "GeographyMultiPoint"));
            this.AddScalarType(new CsdlScalarTypeModel("Edm", "GeographyMultiLineString"));
            this.AddScalarType(new CsdlScalarTypeModel("Edm", "GeographyMultiPolygon"));
            this.AddScalarType(new CsdlScalarTypeModel("Edm", "GeographyCollection"));
            this.AddScalarType(new CsdlScalarTypeModel("Edm", "Geometry"));
            this.AddScalarType(new CsdlScalarTypeModel("Edm", "GeometryPoint"));
            this.AddScalarType(new CsdlScalarTypeModel("Edm", "GeometryLineString"));
            this.AddScalarType(new CsdlScalarTypeModel("Edm", "GeometryPolygon"));
            this.AddScalarType(new CsdlScalarTypeModel("Edm", "GeometryMultiPoint"));
            this.AddScalarType(new CsdlScalarTypeModel("Edm", "GeometryMultiLineString"));
            this.AddScalarType(new CsdlScalarTypeModel("Edm", "GeometryMultiPolygon"));
            this.AddScalarType(new CsdlScalarTypeModel("Edm", "GeometryCollection"));
            this.AddScalarType(new CsdlScalarTypeModel("Edm", "Stream"));
        }

        public void AddScalarType(CsdlScalarTypeModel scalarType) {
            this.Items.Add((new Item() { CsdlModelNamespace = scalarType.Namespace, Name = scalarType.Name, ScalarType = scalarType }).BuildNames());
        }
        public void AddEntityType(string csdlModelNamespace, string name, CsdlEntityTypeModel entityType) {
            this.Items.Add((new Item() { CsdlModelNamespace = csdlModelNamespace, Name = name, EntityType = entityType }).BuildNames());
        }

        public void AddEntityContainer(string csdlModelNamespace, string name, CsdlEntityContainerModel entityContainer) {
            this.Items.Add((new Item() { CsdlModelNamespace = csdlModelNamespace, Name = name, EntityContainer = entityContainer }).BuildNames());
        }

        public void AddAssociation(string csdlModelNamespace, string name, CsdlAssociationModel association) {
            this.Items.Add((new Item() { CsdlModelNamespace = csdlModelNamespace, Name = name, Association = association }).BuildNames());
        }

        public void AddEntitySet(string csdlModelNamespace, string parentName, string name, CsdlEntitySetModel entitySet) {
            this.Items.Add((new Item() { CsdlModelNamespace = csdlModelNamespace, ParentName = parentName, Name = name, EntitySet = entitySet }).BuildNames());
        }

        public void AddAssociationSet(string csdlModelNamespace, string parentName, string name, CsdlAssociationSetModel associationSet) {
            this.Items.Add((new Item() { CsdlModelNamespace = csdlModelNamespace, ParentName = parentName, Name = name, AssociationSet = associationSet }).BuildNames());
        }

        public void AddProperty(string csdlModelNamespace, string parentName, string name, CsdlPropertyModel property) {
            this.Items.Add((new Item() { CsdlModelNamespace = csdlModelNamespace, ParentName = parentName, Name = name, Property = property }).BuildNames());
        }

        public void AddNavigationProperty(string csdlModelNamespace, string parentName, string name, CsdlNavigationPropertyModel navigationProperty) {
            this.Items.Add((new Item() { CsdlModelNamespace = csdlModelNamespace, ParentName = parentName, Name = name, NavigationProperty = navigationProperty }).BuildNames());
        }

        [System.Diagnostics.DebuggerDisplay("{CsdlModelNamespace} - {ParentName} - {Name}")]
        public class Item {
            public string CsdlModelNamespace;
            public string ParentName;
            public string Name;
            public CsdlEntityTypeModel EntityType;
            public CsdlEntityContainerModel EntityContainer;
            public CsdlAssociationModel Association;
            public CsdlScalarTypeModel ScalarType;
            public CsdlEntitySetModel EntitySet;
            public CsdlAssociationSetModel AssociationSet;
            public CsdlPropertyModel Property;
            public CsdlNavigationPropertyModel NavigationProperty;


            public string CsdlModelNamespace_Name;
            public string CsdlModelNamespace_ParentName_Name;
            public string ParentName_Name;
            public Item BuildNames() {
                this.CsdlModelNamespace_Name = CsdlNameResolver.ConcatDotAnsiNULL(this.CsdlModelNamespace, this.Name);
                this.CsdlModelNamespace_ParentName_Name = CsdlNameResolver.ConcatDotAnsiNULL(this.CsdlModelNamespace, this.ParentName, this.Name);
                this.ParentName_Name = CsdlNameResolver.ConcatDotAnsiNULL(this.ParentName, this.Name);
                return this;
            }
        }

        public void BuildNameResolver() {
            // post add
        }

        public List<Item> FindNSParentName(string findName, List<Item> result = null) {
            if (result == null) {
                result = new List<Item>();
            }
            foreach (var item in this.Items) {
                if (string.Equals(item.CsdlModelNamespace_ParentName_Name, findName, StringComparison.Ordinal)) {
                    result.Add(item);
                }
            }
            return result;
        }
        public List<Item> FindNSName(string findName, List<Item> result = null) {
            if (result == null) {
                result = new List<Item>();
            }
            foreach (var item in this.Items) {
                if (string.Equals(item.CsdlModelNamespace_Name, findName, StringComparison.Ordinal)) {
                    result.Add(item);
                }
            }
            return result;
        }
        public List<Item> FindName(string findName, List<Item> result = null) {
            if (result == null) {
                result = new List<Item>();
            }
            foreach (var item in this.Items) {
                if (string.Equals(item.Name, findName, StringComparison.Ordinal)) {
                    result.Add(item);
                }
            }
            return result;
        }

        public List<Item> FindAnyWhere(string findName, List<Item> result = null) {
            if (result == null) {
                result = new List<Item>();
            }
            foreach (var item in this.Items) {
                if (string.Equals(item.CsdlModelNamespace_ParentName_Name, findName, StringComparison.Ordinal)) {
                    result.Add(item);
                }
                if (string.Equals(item.CsdlModelNamespace_Name, findName, StringComparison.Ordinal)) {
                    result.Add(item);
                }
                if (string.Equals(item.ParentName_Name, findName, StringComparison.Ordinal)) {
                    result.Add(item);
                }
                if (string.Equals(item.Name, findName, StringComparison.Ordinal)) {
                    result.Add(item);
                }
            }
            return result;
        }
        public static string ConcatDotIgnoreNULL(params string[] names) {
            string result = null;
            foreach (var n in names) {
                if (string.IsNullOrEmpty(n)) { continue; }
                if (result == null) {
                    result = n;
                } else {
                    result = result + "." + n;
                }
            }
            return result;
        }
        public static string ConcatDotAnsiNULL(params string[] names) {
            string result = null;
            foreach (var n in names) {
                if (string.IsNullOrEmpty(n)) { return null; }
                if (result == null) {
                    result = n;
                } else {
                    result = result + "." + n;
                }
            }
            return result;
        }
    }
}