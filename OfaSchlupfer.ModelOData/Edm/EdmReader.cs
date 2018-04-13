namespace OfaSchlupfer.ModelOData.Edm {
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;

    using Microsoft.Extensions.DependencyInjection;

    using Newtonsoft.Json;

    using OfaSchlupfer.Model;

    public class EdmReader {
        private ServiceProvider serviceProvider;

        public EdmReader(ServiceProvider serviceProvider) {
            this.serviceProvider = serviceProvider;
        }

        public IMetadataResolver MetadataResolver { get; set; }

        public EdmxModel Read(string location, ModelErrors errors) {
            return this.Read(this.MetadataResolver.Resolve(location), errors);
        }

        public EdmxModel Read(StreamReader streamReader, ModelErrors errors) {
            var xDoc = XDocument.Load(XmlReader.Create(streamReader, new XmlReaderSettings() {
                CloseInput = true,
                IgnoreComments = true,
                IgnoreWhitespace = true
            }));
            var result = this.ReadDocument(xDoc.Root, errors);
            this.ResolveNames(result, errors);
            return result;
        }

        public EdmxModel ReadDocument(XElement root, ModelErrors errors) {
            if (root.Name == EdmConstants.EdmxV3Document) {
                return this.ReadEdmxDocument(root, EdmConstants.EdmxV3, errors);
            }
            if (root.Name == EdmConstants.EdmxV4Document) {
                return this.ReadEdmxDocument(root, EdmConstants.EdmxV4, errors);
            }
            errors.AddErrorXmlParsing("root", null, root);
            return null;
        }

        public EdmxModel ReadEdmxDocument(XElement rootEdmx, EdmConstants.EdmxConstants edmxConstants, ModelErrors errors) {
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
                        errors.AddErrorXmlParsing("ReadCSDLDocument", null, rootEdmx, attr);
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
                            errors.AddErrorXmlParsing("ReadEdmxDocument-EdmxDataServices", null, ele1, eleSchema);
                        }
                    }
                } else {
                    errors.AddErrorXmlParsing("ReadEdmxDocument", null, ele1);
                }
            }
            //  <edmx:DataServices xmlns:m="http://schemas.microsoft.com/ado/2007/08/dataservices/metadata" m:DataServiceVersion="2.0">
            return edmxModel;
        }

        public CsdlSchemaModel ReadCSDLDocument(EdmxModel edmxModel, XElement eleSchema, EdmConstants.CSDLConstants csdlConstants, ModelErrors errors) {
            var schemaModel = new CsdlSchemaModel();
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
                        errors.AddErrorXmlParsing("ReadCSDLDocument", null, null, eleSchema, attr);
                    }
                }
            }
            edmxModel.DataServices.Add(schemaModel);
            // children
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

        public void ReadCsdlAnnotations(CsdlSchemaModel schemaModel, XElement ele1, EdmConstants.CSDLConstants csdlConstants, ModelErrors errors) {
            // TODO: Annotations
            throw new NotImplementedException(ele1.Name.ToString());
        }

        public void ReadCsdlAssociation(CsdlSchemaModel schemaModel, XElement eleAssociation, EdmConstants.CSDLConstants csdlConstants, ModelErrors errors) {
            var association = new CsdlAssociationModel();
            if (eleAssociation.HasAttributes) {
                foreach (var attr in eleAssociation.Attributes()) {
                    if (attr.IsNamespaceDeclaration) {
                        //
                    } else if (attr.Name == EdmConstants.AttrName) {
                        association.Name = attr.Value;
                        //} else if (attr.Name == csdlConstants.AttrIsDefaultEntityContainer) {
                        //    association.IsDefaultEntityContainer = ConvertToBoolean(attr.Value);
                    } else if (CheckAndAddAnnotation(attr, association)) {
                    } else {
                        errors.AddErrorXmlParsing("ReadCSDLDocument", null, eleAssociation, attr);
                    }
                }
            }
            schemaModel.Association.Add(association);

            // children
            foreach (var ele2 in eleAssociation.Elements()) {
                if (ele2.Name == csdlConstants.End) {
                    var associationEnd = new CsdlAssociationEndModel();
                    if (ele2.HasAttributes) {
                        foreach (var attr in ele2.Attributes()) {
                            if (attr.IsNamespaceDeclaration) {
                                //
                            } else if (attr.Name == EdmConstants.AttrRole) {
                                associationEnd.RoleName = attr.Value;
                                //} else if (attr.Name == EdmConstants.AttrEntitySet) {
                                //    associationEnd.EntitySetName = attr.Value;
                            } else if (attr.Name == EdmConstants.AttrType) {
                                associationEnd.TypeName = attr.Value;
                            } else if (attr.Name == EdmConstants.AttrMultiplicity) {
                                associationEnd.Multiplicity = attr.Value;
                            } else if (CheckAndAddAnnotation(attr, associationEnd)) {
                            } else {
                                errors.AddErrorXmlParsing("ReadCSDLDocument", null, eleAssociation, ele2, attr);
                            }
                        }
                    }
                    association.AssociationEnd.Add(associationEnd);

                    foreach (var ele3 in ele2.Elements()) {
                        {
                            errors.AddErrorXmlParsing("ReadCSDLDocument", null, eleAssociation, ele2, ele3);
                        }
                    }

                } else if (ele2.Name == csdlConstants.ReferentialConstraint) {
                    var referentialConstraint = new CsdlReferentialConstraintV3Model();
                    if (ele2.HasAttributes) {
                        foreach (var attr in ele2.Attributes()) {
                            if (attr.IsNamespaceDeclaration) {
                                //
                            } else if (CheckAndAddAnnotation(attr, referentialConstraint)) {
                            } else {
                                errors.AddErrorXmlParsing("ReadCSDLDocument", null, eleAssociation, ele2, attr);
                            }
                        }
                    }
                    foreach (var ele3 in ele2.Elements()) {
                        var isPrincipal = (ele3.Name == csdlConstants.Principal);
                        var isDependent = (ele3.Name == csdlConstants.Dependent);
                        if (isPrincipal || isDependent) {
                            var referentialConstraintPartner = new CsdlReferentialConstraintPartnerV3Model();
                            if (ele3.HasAttributes) {
                                foreach (var attr in ele3.Attributes()) {
                                    if (attr.Name == EdmConstants.AttrRole) {
                                        referentialConstraintPartner.RoleName = attr.Value;
                                    } else if (CheckAndAddAnnotation(attr, referentialConstraintPartner)) {
                                    } else {
                                        errors.AddErrorXmlParsing("ReadCSDLDocument", null, eleAssociation, ele2, ele3, attr);
                                    }
                                }
                            }
                            foreach (var ele4 in ele3.Elements()) {
                                if (ele4.Name == csdlConstants.PropertyRef) {
                                    var propertyRef = new CsdlPropertyRefModel();
                                    if (ele4.HasAttributes) {
                                        foreach (var attr in ele4.Attributes()) {
                                            if (attr.Name == EdmConstants.AttrName) {
                                                propertyRef.PropertyName = attr.Value;
                                            } else if (CheckAndAddAnnotation(attr, propertyRef)) {
                                            } else {
                                                errors.AddErrorXmlParsing("ReadCSDLDocument", null, eleAssociation, ele2, ele3, ele4, attr);
                                            }
                                        }
                                    }

                                    foreach (var ele5 in ele4.Elements()) {
                                        {
                                            errors.AddErrorXmlParsing("ReadCSDLDocument", null, eleAssociation, ele2, ele3, ele4, ele5);
                                        }
                                    }
                                    referentialConstraintPartner.PropertyRef.Add(propertyRef);
                                } else {
                                    errors.AddErrorXmlParsing("ReadCSDLDocument", null, eleAssociation, ele2, ele3, ele4);
                                }
                            }

                            if (isPrincipal) {
                                referentialConstraint.Principal = referentialConstraintPartner;
                            } else if (isDependent) {
                                referentialConstraint.Dependent = referentialConstraintPartner;
                            } else {
                                errors.AddErrorXmlParsing("ReadCSDLDocument", null, eleAssociation, ele2, ele3);
                            }
                        } else {
                            errors.AddErrorXmlParsing("ReadCSDLDocument", null, eleAssociation, ele2, ele3);
                        }
                    }
                    association.ReferentialConstraint.Add(referentialConstraint);
                } else {
                    errors.AddErrorXmlParsing("ReadCSDLDocument", null, eleAssociation, ele2);
                }
            }
        }

        public void ReadCsdlComplexType(CsdlSchemaModel schemaModel, XElement ele1, EdmConstants.CSDLConstants csdlConstants, ModelErrors errors) {
            // TODO: ComplexType
            throw new NotImplementedException(ele1.Name.ToString());
        }

        public void ReadCsdlEntityContainer(
            CsdlSchemaModel schemaModel,
            XElement eleEntityContainer,
            EdmConstants.CSDLConstants csdlConstants,
            ModelErrors errors
            ) {
            var entityContainer = new CsdlEntityContainerModel();
            if (eleEntityContainer.HasAttributes) {
                foreach (var attr in eleEntityContainer.Attributes()) {
                    if (attr.IsNamespaceDeclaration) {
                        //
                    } else if (attr.Name == EdmConstants.AttrName) {
                        entityContainer.Name = attr.Value;
                    } else if (attr.Name == csdlConstants.AttrIsDefaultEntityContainer) {
                        entityContainer.IsDefaultEntityContainer = ConvertToBoolean(attr.Value);
                    } else if (CheckAndAddAnnotation(attr, entityContainer)) {
                    } else {
                        errors.AddErrorXmlParsing("ReadCSDLDocument", null, eleEntityContainer, attr);
                    }
                }
            }
            foreach (var ele2 in eleEntityContainer.Elements()) {
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
                                errors.AddErrorXmlParsing("ReadCSDLDocument", null, eleEntityContainer, ele2, attr);
                            }
                        }
                    }
                    entityContainer.EntitySet.Add(entitySet);
                    foreach (var ele3 in ele2.Elements()) {
                        if (ele3.Name == csdlConstants.NavigationPropertyBinding) {
                            var navigationPropertyBinding = new CsdlNavigationPropertyBindingModel();
                            if (ele3.HasAttributes) {
                                foreach (var attr in ele3.Attributes()) {
                                    if (attr.IsNamespaceDeclaration) {
                                        //
                                    } else if (attr.Name == EdmConstants.AttrPath) {
                                        navigationPropertyBinding.PathName = attr.Value;
                                    } else if (attr.Name == EdmConstants.AttrTarget) {
                                        navigationPropertyBinding.TargetName = attr.Value;
                                    } else if (CheckAndAddAnnotation(attr, navigationPropertyBinding)) {
                                    } else {
                                        errors.AddErrorXmlParsing("ReadCSDLDocument", null, eleEntityContainer, ele2, attr);
                                    }
                                }
                            }
                            entitySet.NavigationPropertyBinding.Add(navigationPropertyBinding);
                            foreach (var ele4 in ele3.Elements()) {
                                {
                                    errors.AddErrorXmlParsing("ReadCSDLDocument", null, eleEntityContainer, ele2, ele3, ele4);
                                }
                            }
                        } else {
                            errors.AddErrorXmlParsing("ReadCSDLDocument", null, eleEntityContainer, ele2, ele3);
                        }
                    }
                } else if (ele2.Name == csdlConstants.AssociationSet) {
                    var associationSet = new CsdlAssociationSetModel();
                    if (ele2.HasAttributes) {
                        foreach (var attr in ele2.Attributes()) {
                            if (attr.IsNamespaceDeclaration) {
                                //
                            } else if (attr.Name == EdmConstants.AttrName) {
                                associationSet.Name = attr.Value;
                            } else if (attr.Name == EdmConstants.AttrAssociation) {
                                associationSet.AssociationName = attr.Value;
                            } else if (CheckAndAddAnnotation(attr, associationSet)) {
                            } else {
                                errors.AddErrorXmlParsing("ReadCSDLDocument", null, eleEntityContainer, ele2, attr);
                            }
                        }
                    }
                    entityContainer.AssociationSet.Add(associationSet);
                    foreach (var ele3 in ele2.Elements()) {
                        if (ele3.Name == csdlConstants.End) {
                            var associationSetEndModel = new CsdlAssociationSetEndModel();
                            if (ele3.HasAttributes) {
                                foreach (var attr in ele3.Attributes()) {
                                    if (attr.IsNamespaceDeclaration) {
                                        //
                                    } else if (attr.Name == EdmConstants.AttrRole) {
                                        associationSetEndModel.RoleName = attr.Value;
                                    } else if (attr.Name == EdmConstants.AttrEntitySet) {
                                        associationSetEndModel.EntitySetName = attr.Value;
                                    } else if (CheckAndAddAnnotation(attr, associationSet)) {
                                    } else {
                                        errors.AddErrorXmlParsing("ReadCSDLDocument", null, eleEntityContainer, ele2, attr);
                                    }
                                }
                            }
                            associationSet.End.Add(associationSetEndModel);
                            foreach (var ele4 in ele3.Elements()) {
                                {
                                    errors.AddErrorXmlParsing("ReadCSDLDocument", null, eleEntityContainer, ele2, ele3, ele4);
                                }
                            }
                        } else {
                            errors.AddErrorXmlParsing("ReadCSDLDocument", null, eleEntityContainer, ele2, ele3);
                        }
                    }
                } else {
                    errors.AddErrorXmlParsing("ReadCSDLDocument", null, eleEntityContainer, ele2);
                }
            }
            schemaModel.EntityContainer.Add(entityContainer);
        }

        public void ReadCsdlEntityType(
            CsdlSchemaModel schemaModel,
            XElement eleEntityType,
            EdmConstants.CSDLConstants csdlConstants,
            ModelErrors errors) {
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
                        errors.AddErrorXmlParsing("ReadCSDLDocument", null, eleEntityType, attr);
                    }
                }
            }
            schemaModel.EntityType.Add(entityType);

            foreach (var ele2 in eleEntityType.Elements()) {
                if (ele2.Name == csdlConstants.Key) {
                    if (ele2.HasAttributes) {
                        foreach (var attr in ele2.Attributes()) {
                            if (attr.IsNamespaceDeclaration) {
                                //
                            } else {
                                errors.AddErrorXmlParsing("ReadCSDLDocument", null, eleEntityType, ele2, attr);
                            }
                        }
                    }
                    foreach (var ele3 in ele2.Elements()) {
                        var propertyRef = new CsdlPrimaryKeyModel();
                        if (ele3.Name == csdlConstants.PropertyRef) {
                            if (ele3.HasAttributes) {
                                foreach (var attr in ele3.Attributes()) {
                                    if (attr.IsNamespaceDeclaration) {
                                        //
                                    } else if (attr.Name == EdmConstants.AttrName) {
                                        propertyRef.Name = attr.Value;
                                    } else if (CheckAndAddAnnotation(attr, propertyRef)) {
                                    } else {
                                        errors.AddErrorXmlParsing("ReadCSDLDocument", null, eleEntityType, ele2, ele3, attr);
                                    }
                                }
                            }
                        } else {
                            errors.AddErrorXmlParsing("ReadCSDLDocument", null, eleEntityType, ele2, ele3);
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
                                errors.AddErrorXmlParsing("ReadCSDLDocument", null, eleEntityType, ele2, attr);
                            }
                        }
                    }
                    entityType.Property.Add(property);
                    foreach (var ele3 in ele2.Elements()) {
                        {
                            errors.AddErrorXmlParsing("ReadCSDLDocument", null, eleEntityType, ele2, ele3);
                        }
                    }
                } else if (ele2.Name == csdlConstants.NavigationProperty) {
                    var navigationProperty = new CsdlNavigationPropertyModel();
                    if (ele2.HasAttributes) {
                        foreach (var attr in ele2.Attributes()) {
                            if (attr.IsNamespaceDeclaration) {
                                //
                            } else if (attr.Name == EdmConstants.AttrName) {
                                navigationProperty.Name = attr.Value;
                            } else if (attr.Name == EdmConstants.AttrRelationship) {
                                navigationProperty.RelationshipName = attr.Value;
                            } else if (attr.Name == EdmConstants.AttrFromRole) {
                                navigationProperty.FromRoleName = attr.Value;
                            } else if (attr.Name == EdmConstants.AttrToRole) {
                                navigationProperty.ToRoleName = attr.Value;
                            } else if (attr.Name == EdmConstants.AttrContainsTarget) {
                                navigationProperty.ContainsTarget = ConvertToBoolean(attr.Value, false);

                            } else if (attr.Name == EdmConstants.AttrType) {
                                navigationProperty.TypeName = attr.Value;
                            } else if (attr.Name == EdmConstants.AttrPartner) {
                                navigationProperty.PartnerName = attr.Value;
                            } else if (attr.Name == EdmConstants.AttrNullable) {
                                navigationProperty.Nullable = ConvertToBoolean(attr.Value, true);

                            } else {
                                errors.AddErrorXmlParsing("ReadCSDLDocument", null, eleEntityType, ele2, attr);
                            }
                        }
                    }
                    entityType.NavigationProperty.Add(navigationProperty);

                    foreach (var ele3 in ele2.Elements()) {
                        var referentialConstraint = new CsdlReferentialConstraintV4Model();
                        //var propertyRef = new CsdlPrimaryKeyModel();
                        if (ele3.Name == csdlConstants.ReferentialConstraint) {
                            if (ele3.HasAttributes) {
                                foreach (var attr in ele3.Attributes()) {
                                    if (attr.IsNamespaceDeclaration) {
                                        //
                                    } else if (attr.Name == EdmConstants.AttrProperty) {
                                        referentialConstraint.PropertyName = attr.Value;
                                    } else if (attr.Name == EdmConstants.AttrReferencedProperty) {
                                        referentialConstraint.ReferencedPropertyName = attr.Value;
                                    } else if (CheckAndAddAnnotation(attr, referentialConstraint)) {
                                    } else {
                                        errors.AddErrorXmlParsing("ReadCSDLDocument", null, eleEntityType, ele2, ele3, attr);
                                    }
                                }
                            }
                            foreach (var ele4 in ele3.Elements()) {
                                {
                                    errors.AddErrorXmlParsing("ReadCSDLDocument", null, eleEntityType, ele2, ele3, ele4);
                                }
                            }
                        } else {
                            errors.AddErrorXmlParsing("ReadCSDLDocument", null, eleEntityType, ele2, ele3);
                        }
                        navigationProperty.ReferentialConstraint.Add(referentialConstraint);
                    }
                } else {
                    errors.AddErrorXmlParsing("ReadCSDLDocument", null, eleEntityType, ele2);
                }
            }
        }

        public void ReadCsdlEnumType(CsdlSchemaModel schemaModel, XElement ele1, EdmConstants.CSDLConstants csdlConstants, ModelErrors errors) {
            // TODO: EnumType
            throw new NotImplementedException(ele1.Name.ToString());
        }

        public void ReadCsdlFunction(CsdlSchemaModel schemaModel, XElement ele1, EdmConstants.CSDLConstants csdlConstants, ModelErrors errors) {
            // TODO: Function
            throw new NotImplementedException(ele1.Name.ToString());
        }

        public void ReadCsdlUsing(CsdlSchemaModel schemaModel, XElement ele1, EdmConstants.CSDLConstants csdlConstants, ModelErrors errors) {
            // TODO: Using
            throw new NotImplementedException(ele1.Name.ToString());
        }

        public void ReadCsdlValueTerm(CsdlSchemaModel schemaModel, XElement ele1, EdmConstants.CSDLConstants csdlConstants, ModelErrors errors) {
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

        public void ResolveNames(EdmxModel edmxModel, ModelErrors errors) {
            edmxModel.ResolveNames(errors);
        }
    }
}
