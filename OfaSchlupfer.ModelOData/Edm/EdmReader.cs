namespace OfaSchlupfer.ModelOData.Edm {
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using Microsoft.Extensions.DependencyInjection;
    using OfaSchlupfer.Model;

    public class EdmReader {
        private ServiceProvider serviceProvider;

        public EdmReader(ServiceProvider serviceProvider) {
            this.serviceProvider = serviceProvider;
        }

        public IMetadataResolver MetadataResolver { get; set; }

        public EdmxModel EdmxModel { get; set; }


        public object Read(string location) {
            return this.Read(this.MetadataResolver.Resolve(location));
        }

        public object Read(StreamReader streamReader) {
            var xDoc = XDocument.Load(XmlReader.Create(streamReader, new XmlReaderSettings() {
                CloseInput = true,
                IgnoreComments = true,
                IgnoreWhitespace = true
            }));
            var modelSchema = new ModelSchema();
            this.ReadDocument(xDoc.Root, modelSchema);
            return xDoc.Root;
        }

        public void ReadDocument(XElement root, ModelSchema modelSchema) {
            if (root.Name == EdmConstants.EdmxDocument) {
                this.ReadEdmxDocument(root);
            }
            System.Diagnostics.Debug.WriteLine(root.Name);
            foreach (var ele in root.Descendants()) {
                System.Diagnostics.Debug.WriteLine(ele.Name);
            }
            //modelSchema.ComplexTypes
        }

        public void ReadEdmxDocument(XElement rootEdmx) {
            // http://www.odata.org/documentation/odata-version-3-0/common-schema-definition-language-csdl/
            var edmxModel = new EdmxModel();
            this.EdmxModel = edmxModel;
            if (rootEdmx.HasAttributes) {
                edmxModel.Version = rootEdmx.Attribute(EdmConstants.AttrVersion).Value;
            }
            var references = new List<string>();
            foreach (var ele1 in rootEdmx.Elements()) {
                if (ele1.Name == EdmConstants.EdmxAnnotationsReference) {
                    // TODO: AnnotationsReference
                } else if (ele1.Name == EdmConstants.EdmxReference) {
                    if (ele1.HasAttributes) {
                        var url = ele1.Attribute(EdmConstants.AttrUrl).Value;
                        if (!string.IsNullOrEmpty(url)) {
                            edmxModel.References.Add(url);
                            references.Add(url);
                        }
                    }
                } else if (ele1.Name == EdmConstants.EdmxDataServices) {
                    if (ele1.HasAttributes) {
                        edmxModel.DataServiceVersion = ele1.Attribute(EdmConstants.DataServiceVersion).Value;
                    }

                    foreach (var ele2 in ele1.Elements()) {
                        if (ele2.Name == EdmConstants.CSDL1_0.Schema) {
                            ReadCSDL1_0Document(ele2);
                        } else if (ele2.Name == EdmConstants.CSDL1_1.Schema) {
                            ReadCSDL1_1Document(ele2);
                        } else if (ele2.Name == EdmConstants.CSDL1_2.Schema) {
                            ReadCSDL1_2Document(ele2);
                        } else if (ele2.Name == EdmConstants.CSDL2_0.Schema) {
                            ReadCSDL2_0Document(ele2);
                        } else if (ele2.Name == EdmConstants.CSDL3_0.Schema) {
                            ReadCSDL3_0Document(ele2);
                        } else {
                            throw new NotImplementedException(ele2.Name.ToString());
                        }
                    }
                } else {
                    throw new NotImplementedException(ele1.Name.ToString());
                }
            }
            //  <edmx:DataServices xmlns:m="http://schemas.microsoft.com/ado/2007/08/dataservices/metadata" m:DataServiceVersion="2.0">

        }

        public CsdlModel ReadCSDL1_0Document(XElement ele) => this.ReadCSDLDocument(ele, EdmConstants.CSDL1_0);

        public CsdlModel ReadCSDL1_1Document(XElement ele) => this.ReadCSDLDocument(ele, EdmConstants.CSDL1_1);

        public CsdlModel ReadCSDL1_2Document(XElement ele) => this.ReadCSDLDocument(ele, EdmConstants.CSDL1_2);

        public CsdlModel ReadCSDL2_0Document(XElement ele) => this.ReadCSDLDocument(ele, EdmConstants.CSDL2_0);

        public CsdlModel ReadCSDL3_0Document(XElement ele) => this.ReadCSDLDocument(ele, EdmConstants.CSDL3_0);


        public CsdlModel ReadCSDLDocument(XElement ele, EdmConstants.CSDLConstants csdlConstants) {
            var csdlModel = new CsdlModel();
            this.EdmxModel.DataServices.Add(csdlModel);
            foreach (var ele1 in ele.Elements()) {
                if (ele1.Name == csdlConstants.Annotations) {
                    throw new NotImplementedException(ele1.Name.ToString());
                } else if (ele1.Name == csdlConstants.Association) {
                    var association = new CsdlAssociationModel();
                    foreach (var ele2 in ele1.Elements()) {
                        if (ele2.Name == csdlConstants.End) {
                            var associationEnd = new CsdlAssociationEndModel();
                            foreach (var attr in ele2.Attributes()) {
                                if (attr.IsNamespaceDeclaration) {
                                    //
                                } else if (attr.Name == EdmConstants.AttrRole) {
                                    associationEnd.Role = attr.Value;
                                } else if (attr.Name == EdmConstants.AttrEntitySet) {
                                    associationEnd.EntitySet = attr.Value;
                                } else if (attr.Name == EdmConstants.AttrType) {
                                    associationEnd.Type = attr.Value;
                                } else if (attr.Name == EdmConstants.AttrMultiplicity) {
                                    associationEnd.Multiplicity = attr.Value;
                                } else if (CheckAndAddAnnotation(attr, associationEnd)) {
                                } else {
                                    throw new NotImplementedException($"{ele1.Name.ToString()} - {ele2.Name.ToString()} - {attr.Name.ToString()}");
                                }
                            }
                            association.AssociationEnd.Add(associationEnd);

                        } else if (ele2.Name == csdlConstants.ReferentialConstraint) {
                            var referentialConstraint = new CsdlReferentialConstraintModel();
                            foreach (var ele3 in ele2.Elements()) {
                                var isPrincipal = (ele3.Name == csdlConstants.Principal);
                                var isDependent = (ele3.Name == csdlConstants.Dependent);
                                if (isPrincipal || isDependent) {
                                    var referentialConstraintPartner = new CsdlReferentialConstraintPartnerModel();
                                    {
                                        foreach (var attr in ele3.Attributes()) {
                                            if (attr.Name == EdmConstants.AttrRole) {
                                                referentialConstraintPartner.Role = attr.Value;
                                            } else if (CheckAndAddAnnotation(attr, referentialConstraintPartner)) {
                                            } else {
                                                throw new NotImplementedException($"{ele1.Name.ToString()} - {ele2.Name.ToString()} - {ele3.Name.ToString()} - {attr.Name.ToString()}");
                                            }
                                        }
                                    }
                                    foreach (var ele4 in ele3.Elements()) {
                                        if (ele4.Name == csdlConstants.PropertyRef) {
                                            var propertyRef = new CsdlPropertyRefModel();
                                            foreach (var attr in ele4.Attributes()) {
                                                if (attr.Name == EdmConstants.AttrName) {
                                                    propertyRef.Name = attr.Value;
                                                } else if (CheckAndAddAnnotation(attr, propertyRef)) {
                                                } else {
                                                    throw new NotImplementedException($"{ele1.Name.ToString()} - {ele2.Name.ToString()} - {ele3.Name.ToString()} - {ele4.Name.ToString()} - {attr.Name.ToString()}");
                                                }
                                            }
                                            referentialConstraintPartner.PropertyRef.Add(propertyRef);
                                        } else {
                                            throw new NotImplementedException(ele3.Name.ToString());
                                        }
                                    }

                                    if (isPrincipal) {
                                        referentialConstraint.Principal = referentialConstraintPartner;
                                    } else if (isDependent) {
                                        referentialConstraint.Dependent = referentialConstraintPartner;
                                    } else {
                                        throw new NotImplementedException(ele3.Name.ToString());
                                    }
                                } else {
                                    throw new NotImplementedException(ele3.Name.ToString());
                                }
                            }
                            association.ReferentialConstraint.Add(referentialConstraint);
                        } else {
                            throw new NotImplementedException(ele2.Name.ToString());
                        }
                    }
                    csdlModel.Association.Add(association);
                } else if (ele1.Name == csdlConstants.ComplexType) {
                    // TODO: ComplexType
                    throw new NotImplementedException(ele1.Name.ToString());
                } else if (ele1.Name == csdlConstants.EntityContainer) {
                    var entityContainer = new CsdlEntityContainerModel();
                    foreach (var ele2 in ele1.Elements()) {
                        if (ele2.Name == csdlConstants.EntitySet) {
                            var entitySet = new CsdlEntitySetModel();
                            foreach (var attr in ele2.Attributes()) {
                                if (attr.IsNamespaceDeclaration) {
                                    //
                                } else if (attr.Name == EdmConstants.AttrName) {
                                    entitySet.Name = attr.Value;
                                } else if (attr.Name == EdmConstants.AttrEntityType) {
                                    entitySet.EntityType = attr.Value;
                                } else if (CheckAndAddAnnotation(attr, entitySet)) {
                                } else {
                                    throw new NotImplementedException($"{ele1.Name.ToString()} - {ele2.Name.ToString()} - {attr.Name.ToString()}");
                                }
                            }
                            entityContainer.EntitySet.Add(entitySet);
                        } else if (ele2.Name == csdlConstants.AssociationSet) {
                            var associationSet = new CsdlAssociationSetModel();
                            foreach (var attr in ele2.Attributes()) {
                                if (attr.IsNamespaceDeclaration) {
                                    //
                                } else if (attr.Name == EdmConstants.AttrName) {
                                    associationSet.Name = attr.Value;
                                } else if (attr.Name == EdmConstants.AttrAssociation) {
                                    associationSet.Association = attr.Value;
                                } else if (CheckAndAddAnnotation(attr, associationSet)) {
                                } else {
                                    throw new NotImplementedException($"{ele1.Name.ToString()} - {ele2.Name.ToString()} - {attr.Name.ToString()}");
                                }
                            }
                            entityContainer.AssociationSet.Add(associationSet);
                        } else {
                            throw new NotImplementedException(ele2.Name.ToString());
                        }
                    }
                    csdlModel.EntityContainer.Add(entityContainer);
                } else if (ele1.Name == csdlConstants.EntityType) {
                    var entityType = new CsdlEntityTypeModel();
                    if (ele1.HasAttributes) {
                        foreach (var attr in ele1.Attributes()) {
                            if (attr.IsNamespaceDeclaration) {
                                //
                            } else if (attr.Name == EdmConstants.AttrName) {
                                entityType.Name = attr.Value;
                            } else if (attr.Name == EdmConstants.AttrBaseType) {
                                entityType.BaseType = attr.Value;
                            } else if (attr.Name == EdmConstants.AttrAbstract) {
                                entityType.Abstract = ConvertToBoolean(attr.Value);
                            } else if (attr.Name == EdmConstants.AttrOpenType) {
                                entityType.OpenType = ConvertToBoolean(attr.Value);
                            } else if (attr.Name == EdmConstants.AttrHasStream) {
                                entityType.HasStream = ConvertToBoolean(attr.Value);
                            } else if (CheckAndAddAnnotation(attr, entityType)) {
                            } else {
                                throw new NotImplementedException($"{ele1.Name.ToString()} - {attr.Name.ToString()}");
                            }
                        }
                    }
                    csdlModel.EntityType.Add(entityType);

                    foreach (var ele2 in ele1.Elements()) {
                        if (ele2.Name == csdlConstants.Key) {
                            foreach (var ele3 in ele2.Elements()) {
                                var propertyRef = new CsdlPropertyRefModel();
                                if (ele3.Name == csdlConstants.PropertyRef) {
                                    if (ele3.HasAttributes) {
                                        foreach (var attr in ele3.Attributes()) {
                                            if (attr.IsNamespaceDeclaration) {
                                                //
                                            } else if (attr.Name == EdmConstants.AttrName) {
                                                propertyRef.Name = attr.Value;
                                            } else if (CheckAndAddAnnotation(attr, propertyRef)) {
                                            } else {
                                                throw new NotImplementedException($"{ele1.Name.ToString()} - {ele2.Name.ToString()} - {attr.Name.ToString()}");
                                            }
                                        }
                                    }
                                } else {
                                    throw new NotImplementedException(ele3.Name.ToString());
                                }
                                entityType.Keys.Add(propertyRef);
                            }
                        } else if (ele2.Name == csdlConstants.Property) {
                            var property = new CsdlPropertyModel();
                            if (ele2.HasAttributes) {
                                foreach (var attr in ele2.Attributes()) {
                                    if (attr.IsNamespaceDeclaration) {
                                        //
                                    } else if (attr.Name == EdmConstants.AttrName) {
                                        property.Name = attr.Value;
                                    } else if (attr.Name == EdmConstants.AttrType) {
                                        property.TypeName = attr.Value;
                                    } else if (attr.Name == EdmConstants.AttrNullable) {
                                        property.Nullable = ConvertToBoolean(attr.Value, true);
                                    } else if (attr.Name == EdmConstants.AttrMaxLength) {
                                        property.MaxLength = ConvertToInt(attr.Value, 0);
                                    } else if (attr.Name == EdmConstants.AttrFixedLength) {
                                        property.FixedLength = ConvertToBoolean(attr.Value, false);
                                    } else if (attr.Name == EdmConstants.AttrPrecision) {
                                        property.Precision = ConvertToInt(attr.Value, 0);
                                    } else if (attr.Name == EdmConstants.AttrScale) {
                                        property.Scale = ConvertToInt(attr.Value, 0);
                                    } else if (attr.Name == EdmConstants.AttrUnicode) {
                                        property.Unicode = ConvertToBoolean(attr.Value, true);
                                    } else if (attr.Name == EdmConstants.AttrCollation) {
                                        property.Collation = attr.Value;
                                    } else if (attr.Name == EdmConstants.AttrSRID) {
                                        property.SRID = attr.Value;
                                    } else if (attr.Name == EdmConstants.AttrDefaultValue) {
                                        property.DefaultValue = attr.Value;
                                    } else if (attr.Name == EdmConstants.AttrConcurrencyMode) {
                                        property.ConcurrencyMode = attr.Value;
                                    } else if (CheckAndAddAnnotation(attr, property)) {
                                    } else {
                                        throw new NotImplementedException($"{ele1.Name.ToString()} - {ele2.Name.ToString()} - {attr.Name.ToString()}");
                                    }
                                }
                            }
                            entityType.Property.Add(property);

                        } else if (ele2.Name == csdlConstants.NavigationProperty) {
                            var navigationProperty = new CsdlNavigationPropertyModel();
                            foreach (var attr in ele2.Attributes()) {
                                if (attr.IsNamespaceDeclaration) {
                                    //
                                } else if (attr.Name == EdmConstants.AttrName) {
                                    navigationProperty.Name = attr.Value;
                                } else if (attr.Name == EdmConstants.AttrRelationship) {
                                    navigationProperty.Relationship = attr.Value;
                                } else if (attr.Name == EdmConstants.AttrFromRole) {
                                    navigationProperty.FromRole = attr.Value;
                                } else if (attr.Name == EdmConstants.AttrToRole) {
                                    navigationProperty.ToRole = attr.Value;
                                } else if (attr.Name == EdmConstants.AttrContainsTarget) {
                                    navigationProperty.ContainsTarget = ConvertToBoolean(attr.Value, false);
                                } else {
                                    throw new NotImplementedException($"{ele1.Name.ToString()} - {ele2.Name.ToString()} - {attr.Name.ToString()}");
                                }
                            }
                            entityType.NavigationProperty.Add(navigationProperty);

                        } else {
                            throw new NotImplementedException($"{ele1.Name.ToString()} - {ele2.Name.ToString()}");
                        }
                    }
                } else if (ele1.Name == csdlConstants.EnumType) {
                    // TODO: EnumType
                    throw new NotImplementedException(ele1.Name.ToString());
                } else if (ele1.Name == csdlConstants.Function) {
                    // TODO: Function
                    throw new NotImplementedException(ele1.Name.ToString());
                } else if (ele1.Name == csdlConstants.Using) {
                    // TODO: Using
                    throw new NotImplementedException(ele1.Name.ToString());
                } else if (ele1.Name == csdlConstants.ValueTerm) {
                    // TODO: ValueTerm
                    throw new NotImplementedException(ele1.Name.ToString());
                } else {
                    throw new NotImplementedException(ele1.Name.ToString());
                }
            }
            return csdlModel;
        }

        public bool CheckAndAddAnnotation(XAttribute attr, CsdlAnnotationalModel annotationalModel) {
            if (string.Equals(attr.Name.Namespace.NamespaceName, EdmConstants.NSEdmAnnotation.NamespaceName, StringComparison.InvariantCultureIgnoreCase)) {
                annotationalModel.AddAnnotation(attr);
                return true;
            } else {
                return false;
            }
        }

        public static int ConvertToInt(string value, int defaultValue = 0) {
            if (string.IsNullOrEmpty(value)) { return defaultValue; }
            if (string.Equals(value, "Max", StringComparison.OrdinalIgnoreCase)) {
                return int.MaxValue;
            }
            try {
                return int.Parse(value);
            } catch (System.FormatException exc) {
                throw new System.FormatException(value ?? "<NULL>", exc);
            }
        }

        public static bool ConvertToBoolean(string value, bool defaultValue = false) => string.IsNullOrEmpty(value) ? defaultValue : string.Equals(value, "true", StringComparison.InvariantCultureIgnoreCase);

    }
}
