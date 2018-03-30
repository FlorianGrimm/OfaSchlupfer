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

        public EdmxModel Read(string location, CsdlErrors errors) {
            return this.Read(this.MetadataResolver.Resolve(location), errors);
        }

        public EdmxModel Read(StreamReader streamReader, CsdlErrors errors) {
            var xDoc = XDocument.Load(XmlReader.Create(streamReader, new XmlReaderSettings() {
                CloseInput = true,
                IgnoreComments = true,
                IgnoreWhitespace = true
            }));
            var result = this.ReadDocument(xDoc.Root, errors);
            this.ResolveNames(result, errors);
            return result;
        }

        public EdmxModel ReadDocument(XElement root, CsdlErrors errors) {
            if (root.Name == EdmConstants.EdmxV3Document) {
                return this.ReadEdmxDocument(root, EdmConstants.EdmxV3, errors);
            }
            if (root.Name == EdmConstants.EdmxV4Document) {
                return this.ReadEdmxDocument(root, EdmConstants.EdmxV4, errors);
            }
            errors.AddError("root", root);
            return null;
        }

        public EdmxModel ReadEdmxDocument(XElement rootEdmx, EdmConstants.EdmxConstants edmxConstants, CsdlErrors errors) {
            // http://www.odata.org/documentation/odata-version-3-0/common-schema-definition-language-csdl/
            var edmxModel = new EdmxModel();
            if (rootEdmx.HasAttributes) {
                foreach (var attr in rootEdmx.Attributes()) {
                    if (attr.IsNamespaceDeclaration) {
                        //
                    } else if (attr.Name == EdmConstants.AttrVersion) {
                        edmxModel.Version = attr.Value;
                    } else if (CheckAndAddAnnotation(attr, edmxModel)) {
                    } else {
                        errors.AddError("ReadCSDLDocument", rootEdmx, attr);
                    }
                }
            }
            var references = new List<string>();
            foreach (var ele1 in rootEdmx.Elements()) {
                if (ele1.Name == edmxConstants.EdmxAnnotationsReference) {
                    // TODO: AnnotationsReference
                } else if (ele1.Name == edmxConstants.EdmxReference) {
                    if (ele1.HasAttributes) {
                        var url = ele1.Attribute(EdmConstants.AttrUrl).Value;
                        if (!string.IsNullOrEmpty(url)) {
                            edmxModel.References.Add(url);
                            references.Add(url);
                        }
                    }
                } else if (ele1.Name == edmxConstants.EdmxDataServices) {
                    if (ele1.HasAttributes) {
                        // TODO edmxConstants.EdmxDataServices Attributes
                        edmxModel.DataServiceVersion = ele1.Attribute(edmxConstants.AttrDataServiceVersion).Value;
                    }

                    foreach (var eleSchema in ele1.Elements()) {
                        if (eleSchema.Name == EdmConstants.CSDL1_0.Schema) {
                            ReadCSDLDocument(edmxModel, eleSchema, EdmConstants.CSDL1_0, errors);
                        } else if (eleSchema.Name == EdmConstants.CSDL1_1.Schema) {
                            ReadCSDLDocument(edmxModel, eleSchema, EdmConstants.CSDL1_1, errors);
                        } else if (eleSchema.Name == EdmConstants.CSDL1_2.Schema) {
                            ReadCSDLDocument(edmxModel, eleSchema, EdmConstants.CSDL1_2, errors);
                        } else if (eleSchema.Name == EdmConstants.CSDL2_0.Schema) {
                            ReadCSDLDocument(edmxModel, eleSchema, EdmConstants.CSDL2_0, errors);
                        } else if (eleSchema.Name == EdmConstants.CSDL3_0.Schema) {
                            ReadCSDLDocument(edmxModel, eleSchema, EdmConstants.CSDL3_0, errors);
                        } else if (eleSchema.Name == EdmConstants.CSDL4_0.Schema) {
                            ReadCSDLDocument(edmxModel, eleSchema, EdmConstants.CSDL4_0, errors);
                        } else {
                           errors.AddError("ReadEdmxDocument-EdmxDataServices", ele1, eleSchema);
                        }
                    }
                } else {
                   errors.AddError("ReadEdmxDocument", ele1);
                }
            }
            //  <edmx:DataServices xmlns:m="http://schemas.microsoft.com/ado/2007/08/dataservices/metadata" m:DataServiceVersion="2.0">
            return edmxModel;
        }

        public CsdlSchemaModel ReadCSDLDocument(EdmxModel edmxModel, XElement eleSchema, EdmConstants.CSDLConstants csdlConstants, CsdlErrors errors) {
            var schemaModel = new CsdlSchemaModel();
            edmxModel.DataServices.Add(schemaModel);
            if (eleSchema.HasAttributes) {
                foreach (var attr in eleSchema.Attributes()) {
                    if (attr.IsNamespaceDeclaration) {
                        //
                    } else if (attr.Name == EdmConstants.AttrNamespace) {
                        schemaModel.Namespace = attr.Value;
                        //} else if (attr.Name == csdlConstants.AttrIsDefaultEntityContainer) {
                        //    association.IsDefaultEntityContainer = ConvertToBoolean(attr.Value);
                    } else if (CheckAndAddAnnotation(attr, schemaModel)) {
                    } else {
                       errors.AddError("ReadCSDLDocument", eleSchema, attr);
                    }
                }
            }
            foreach (var ele1 in eleSchema.Elements()) {
                if (ele1.Name == csdlConstants.Annotations) {
                    ReadCsdlAnnotations(schemaModel, ele1, csdlConstants, errors);
                } else if (ele1.Name == csdlConstants.Association) {
                    ReadCsdlAssociation(schemaModel, ele1, csdlConstants, errors);
                } else if (ele1.Name == csdlConstants.ComplexType) {
                    ReadCsdlComplexType(schemaModel, ele1, csdlConstants, errors);
                } else if (ele1.Name == csdlConstants.EntityContainer) {
                    ReadCsdlEntityContainer(schemaModel, ele1, csdlConstants, errors);
                } else if (ele1.Name == csdlConstants.EntityType) {
                    ReadCsdlEntityType(schemaModel, ele1, csdlConstants, errors);
                } else if (ele1.Name == csdlConstants.EnumType) {
                    ReadCsdlEnumType(schemaModel, ele1, csdlConstants, errors);
                } else if (ele1.Name == csdlConstants.Function) {
                    ReadCsdlFunction(schemaModel, ele1, csdlConstants, errors);
                } else if (ele1.Name == csdlConstants.Using) {
                    ReadCsdlUsing(schemaModel, ele1, csdlConstants, errors);
                } else if (ele1.Name == csdlConstants.ValueTerm) {
                    ReadCsdlValueTerm(schemaModel, ele1, csdlConstants, errors);
                } else {
                    throw new NotImplementedException(ele1.Name.ToString());
                }
            }
            //errors.AddError("ReadCSDLDocument", ele1, ele2, ele3, ele4, attr);
            return schemaModel;
        }

        public void ReadCsdlAnnotations(CsdlSchemaModel schemaModel, XElement ele1, EdmConstants.CSDLConstants csdlConstants, CsdlErrors errors) {
            // TODO: Annotations
            throw new NotImplementedException(ele1.Name.ToString());
        }

        public void ReadCsdlAssociation(CsdlSchemaModel schemaModel, XElement ele1, EdmConstants.CSDLConstants csdlConstants, CsdlErrors errors) {
            var association = new CsdlAssociationModel();
            if (ele1.HasAttributes) {
                foreach (var attr in ele1.Attributes()) {
                    if (attr.IsNamespaceDeclaration) {
                        //
                    } else if (attr.Name == EdmConstants.AttrName) {
                        association.Name = attr.Value;
                        //} else if (attr.Name == csdlConstants.AttrIsDefaultEntityContainer) {
                        //    association.IsDefaultEntityContainer = ConvertToBoolean(attr.Value);
                    } else if (CheckAndAddAnnotation(attr, association)) {
                    } else {
                       errors.AddError("ReadCSDLDocument", ele1, attr);
                    }
                }
            }
            foreach (var ele2 in ele1.Elements()) {
                if (ele2.Name == csdlConstants.End) {
                    var associationEnd = new CsdlAssociationEndModel();
                    if (ele2.HasAttributes) {
                        foreach (var attr in ele2.Attributes()) {
                            if (attr.IsNamespaceDeclaration) {
                                //
                            } else if (attr.Name == EdmConstants.AttrRole) {
                                associationEnd.Role = attr.Value;
                            } else if (attr.Name == EdmConstants.AttrEntitySet) {
                                associationEnd.EntitySetName = attr.Value;
                            } else if (attr.Name == EdmConstants.AttrType) {
                                associationEnd.TypeName = attr.Value;
                            } else if (attr.Name == EdmConstants.AttrMultiplicity) {
                                associationEnd.Multiplicity = attr.Value;
                            } else if (CheckAndAddAnnotation(attr, associationEnd)) {
                            } else {
                               errors.AddError("ReadCSDLDocument", ele1, ele2, attr);
                            }
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
                            if (ele3.HasAttributes) {
                                foreach (var attr in ele3.Attributes()) {
                                    if (attr.Name == EdmConstants.AttrRole) {
                                        referentialConstraintPartner.Role = attr.Value;
                                    } else if (CheckAndAddAnnotation(attr, referentialConstraintPartner)) {
                                    } else {
                                       errors.AddError("ReadCSDLDocument", ele1, ele2, ele3, attr);
                                    }
                                }
                            }
                            foreach (var ele4 in ele3.Elements()) {
                                if (ele4.Name == csdlConstants.PropertyRef) {
                                    var propertyRef = new CsdlPropertyRefModel();
                                    if (ele4.HasAttributes) {
                                        foreach (var attr in ele4.Attributes()) {
                                            if (attr.Name == EdmConstants.AttrName) {
                                                propertyRef.Name = attr.Value;
                                            } else if (CheckAndAddAnnotation(attr, propertyRef)) {
                                            } else {
                                               errors.AddError("ReadCSDLDocument", ele1, ele2, ele3, ele4, attr);
                                            }
                                        }
                                    }
                                    referentialConstraintPartner.PropertyRef.Add(propertyRef);
                                } else {
                                   errors.AddError("ReadCSDLDocument", ele1, ele2, ele3, ele4);
                                }
                            }

                            if (isPrincipal) {
                                referentialConstraint.Principal = referentialConstraintPartner;
                            } else if (isDependent) {
                                referentialConstraint.Dependent = referentialConstraintPartner;
                            } else {
                               errors.AddError("ReadCSDLDocument", ele1, ele2, ele3);
                            }
                        } else {
                           errors.AddError("ReadCSDLDocument", ele1, ele2, ele3);
                        }
                    }
                    association.ReferentialConstraint.Add(referentialConstraint);
                } else {
                   errors.AddError("ReadCSDLDocument", ele1, ele2);
                }
            }
            schemaModel.Association.Add(association);
        }

        public void ReadCsdlComplexType(CsdlSchemaModel schemaModel, XElement ele1, EdmConstants.CSDLConstants csdlConstants, CsdlErrors errors) {
            // TODO: ComplexType
            throw new NotImplementedException(ele1.Name.ToString());
        }

        public void ReadCsdlEntityContainer(
            CsdlSchemaModel schemaModel,
            XElement ele1,
            EdmConstants.CSDLConstants csdlConstants,
            CsdlErrors errors
            ) {
            var entityContainer = new CsdlEntityContainerModel();
            if (ele1.HasAttributes) {
                foreach (var attr in ele1.Attributes()) {
                    if (attr.IsNamespaceDeclaration) {
                        //
                    } else if (attr.Name == EdmConstants.AttrName) {
                        entityContainer.Name = attr.Value;
                    } else if (attr.Name == csdlConstants.AttrIsDefaultEntityContainer) {
                        entityContainer.IsDefaultEntityContainer = ConvertToBoolean(attr.Value);
                    } else if (CheckAndAddAnnotation(attr, entityContainer)) {
                    } else {
                       errors.AddError("ReadCSDLDocument", ele1, attr);
                    }
                }
            }
            foreach (var ele2 in ele1.Elements()) {
                if (ele2.Name == csdlConstants.EntitySet) {
                    var entitySet = new CsdlEntitySetModel();
                    if (ele2.HasAttributes) {
                        foreach (var attr in ele2.Attributes()) {
                            if (attr.IsNamespaceDeclaration) {
                                //
                            } else if (attr.Name == EdmConstants.AttrName) {
                                entitySet.Name = attr.Value;
                            } else if (attr.Name == EdmConstants.AttrEntityType) {
                                entitySet.EntityTypeName = attr.Value;
                            } else if (CheckAndAddAnnotation(attr, entitySet)) {
                            } else {
                               errors.AddError("ReadCSDLDocument", ele1, ele2, attr);
                            }
                        }
                    }
                    entityContainer.EntitySet.Add(entitySet);
                } else if (ele2.Name == csdlConstants.AssociationSet) {
                    var associationSet = new CsdlAssociationSetModel();
                    if (ele2.HasAttributes) {
                        foreach (var attr in ele2.Attributes()) {
                            if (attr.IsNamespaceDeclaration) {
                                //
                            } else if (attr.Name == EdmConstants.AttrName) {
                                associationSet.Name = attr.Value;
                            } else if (attr.Name == EdmConstants.AttrAssociation) {
                                associationSet.Association = attr.Value;
                            } else if (CheckAndAddAnnotation(attr, associationSet)) {
                            } else {
                               errors.AddError("ReadCSDLDocument", ele1, ele2, attr);
                            }
                        }
                    }
                    entityContainer.AssociationSet.Add(associationSet);
                } else {
                   errors.AddError("ReadCSDLDocument", ele1, ele2);
                }
            }
            schemaModel.EntityContainer.Add(entityContainer);
        }

        public void ReadCsdlEntityType(
            CsdlSchemaModel schemaModel,
            XElement eleEntityType,
            EdmConstants.CSDLConstants csdlConstants,
            CsdlErrors errors) {
            var entityType = new CsdlEntityTypeModel();
            if (eleEntityType.HasAttributes) {
                foreach (var attr in eleEntityType.Attributes()) {
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
                       errors.AddError("ReadCSDLDocument", eleEntityType, attr);
                    }
                }
            }
            schemaModel.EntityType.Add(entityType);

            foreach (var ele2 in eleEntityType.Elements()) {
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
                                       errors.AddError("ReadCSDLDocument", eleEntityType, ele2, ele3, attr);
                                    }
                                }
                            }
                        } else {
                           errors.AddError("ReadCSDLDocument", eleEntityType, ele2, ele3);
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
                               errors.AddError("ReadCSDLDocument", eleEntityType, ele2, attr);
                            }
                        }
                    }
                    entityType.Property.Add(property);

                } else if (ele2.Name == csdlConstants.NavigationProperty) {
                    var navigationProperty = new CsdlNavigationPropertyModel();
                    if (ele2.HasAttributes) {
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

                            } else if (attr.Name == EdmConstants.AttrType) {
                                navigationProperty.TypeName = attr.Value;
                            } else if (attr.Name == EdmConstants.AttrPartner) {
                                navigationProperty.Partner = attr.Value;
                            } else if (attr.Name == EdmConstants.AttrNullable) {
                                navigationProperty.Nullable = ConvertToBoolean(attr.Value, true);

                            } else {
                               errors.AddError("ReadCSDLDocument", eleEntityType, ele2, attr);
                            }
                        }
                    }
                    entityType.NavigationProperty.Add(navigationProperty);
                } else {
                   errors.AddError("ReadCSDLDocument", eleEntityType, ele2);
                }
            }
        }

        public void ReadCsdlEnumType(CsdlSchemaModel schemaModel, XElement ele1, EdmConstants.CSDLConstants csdlConstants, CsdlErrors errors) {
            // TODO: EnumType
            throw new NotImplementedException(ele1.Name.ToString());
        }

        public void ReadCsdlFunction(CsdlSchemaModel schemaModel, XElement ele1, EdmConstants.CSDLConstants csdlConstants, CsdlErrors errors) {
            // TODO: Function
            throw new NotImplementedException(ele1.Name.ToString());
        }

        public void ReadCsdlUsing(CsdlSchemaModel schemaModel, XElement ele1, EdmConstants.CSDLConstants csdlConstants, CsdlErrors errors) {
            // TODO: Using
            throw new NotImplementedException(ele1.Name.ToString());
        }

        public void ReadCsdlValueTerm(CsdlSchemaModel schemaModel, XElement ele1, EdmConstants.CSDLConstants csdlConstants, CsdlErrors errors) {
            // TODO: ValueTerm
            throw new NotImplementedException(ele1.Name.ToString());
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
            //try {
            return int.Parse(value);
            //} catch (System.FormatException exc) {
            //    throw new System.FormatException(value ?? "<NULL>", exc);
            //}
        }

        public static bool ConvertToBoolean(string value, bool defaultValue = false) => string.IsNullOrEmpty(value) ? defaultValue : string.Equals(value, "true", StringComparison.InvariantCultureIgnoreCase);

        public void ResolveNames(EdmxModel edmxModel, CsdlErrors errors) {
            edmxModel.ResolveNames(errors);
            // build names
            //var nameResolver = new CsdlNameResolver();
            //nameResolver.AddCoreElements();
            //foreach (var schema in result.DataServices) {
            //    schema.BuildNameResolver(nameResolver);
            //}
            //nameResolver.BuildNameResolver();
            //foreach (var schema in result.DataServices) {
            //    schema.ResolveNames(nameResolver);
            //}
        }

        
    }
}
