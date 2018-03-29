namespace OfaSchlupfer.ModelOData.Edm {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml.Linq;

    public static class EdmConstants {
        /*
         CSDL version 1.0: http://schemas.microsoft.com/ado/2006/04/edm
         CSDL version 1.1: http://schemas.microsoft.com/ado/2007/05/edm
         CSDL version 1.2: http://schemas.microsoft.com/ado/2008/01/edm
         CSDL version 2.0: http://schemas.microsoft.com/ado/2008/09/edm
         CSDL version 3.0: http://schemas.microsoft.com/ado/2009/11/edm
         http://schemas.microsoft.com/ado/2009/11/edm.

        Data Service Metadata Namespace
        namespace: http://schemas.microsoft.com/ado/2007/08/DataServices/Metadata.
        */
        private static XNamespace _NSCSDL1_0;
        public static XNamespace NSCSDL1_0 => _NSCSDL1_0 ?? (_NSCSDL1_0 = XNamespace.Get("http://schemas.microsoft.com/ado/2006/04/edm"));

        private static XNamespace _NSCSDL1_1;
        public static XNamespace NSCSDL1_1 => _NSCSDL1_1 ?? (_NSCSDL1_1 = XNamespace.Get("http://schemas.microsoft.com/ado/2007/05/edm"));

        private static XNamespace _NSCSDL1_2;
        public static XNamespace NSCSDL1_2 => _NSCSDL1_2 ?? (_NSCSDL1_2 = XNamespace.Get("http://schemas.microsoft.com/ado/2008/01/edm"));

        private static XNamespace _NSCSDL2_0;
        public static XNamespace NSCSDL2_0 => _NSCSDL2_0 ?? (_NSCSDL2_0 = XNamespace.Get("http://schemas.microsoft.com/ado/2008/09/edm"));


        private static XNamespace _NSCSDL3_0;
        public static XNamespace NSCSDL3_0 => _NSCSDL3_0 ?? (_NSCSDL3_0 = XNamespace.Get("http://schemas.microsoft.com/ado/2009/11/edm"));

        private static XNamespace _NSCSDL4_0;
        public static XNamespace NSCSDL4_0 => _NSCSDL4_0 ?? (_NSCSDL4_0 = XNamespace.Get("http://docs.oasis-open.org/odata/ns/edm"));

        private static XNamespace _NSEdmxV3;
        public static XNamespace NSEdmxV3 => _NSEdmxV3 ?? (_NSEdmxV3 = XNamespace.Get("http://schemas.microsoft.com/ado/2007/06/edmx"));


        private static XNamespace _NSEdmxV4;
        public static XNamespace NSEdmxV4 => _NSEdmxV4 ?? (_NSEdmxV4 = XNamespace.Get("http://docs.oasis-open.org/odata/ns/edmx"));

        private static XNamespace _NSDataservicesMetadata;
        public static XNamespace NSDataservicesMetadata => _NSDataservicesMetadata ?? (_NSDataservicesMetadata = XNamespace.Get("http://schemas.microsoft.com/ado/2007/08/dataservices/metadata"));

        private static XName _EdmxV3Document;
        public static XName EdmxV3Document => _EdmxV3Document ?? (_EdmxV3Document = (NSEdmxV3 + "Edmx"));

        private static XName _EdmxV4Document;
        public static XName EdmxV4Document => _EdmxV4Document ?? (_EdmxV4Document = (NSEdmxV4 + "Edmx"));

        private static XNamespace _NSEdmAnnotation;
        public static XNamespace NSEdmAnnotation => _NSEdmAnnotation ?? (_NSEdmAnnotation = XNamespace.Get("http://schemas.microsoft.com/ado/2009/02/edm/annotation"));

        private static XName _AttrAbstract;
        public static XName AttrAbstract => _AttrAbstract ?? (_AttrAbstract = XName.Get("Abstract"));
        private static XName _AttrAssociation;
        public static XName AttrAssociation => _AttrAssociation ?? (_AttrAssociation = XName.Get("Association"));
        private static XName _AttrBaseType;
        public static XName AttrBaseType => _AttrBaseType ?? (_AttrBaseType = XName.Get("BaseType"));
        private static XName _AttrCollation;
        public static XName AttrCollation => _AttrCollation ?? (_AttrCollation = XName.Get("Collation"));
        private static XName _AttrConcurrencyMode;
        public static XName AttrConcurrencyMode => _AttrConcurrencyMode ?? (_AttrConcurrencyMode = XName.Get("ConcurrencyMode"));
        private static XName _AttrContainsTarget;
        public static XName AttrContainsTarget => _AttrContainsTarget ?? (_AttrContainsTarget = XName.Get("ContainsTarget"));
        private static XName _AttrDefaultValue;
        public static XName AttrDefaultValue => _AttrDefaultValue ?? (_AttrDefaultValue = XName.Get("DefaultValue"));
        private static XName _AttrEntitySet;
        public static XName AttrEntitySet => _AttrEntitySet ?? (_AttrEntitySet = XName.Get("EntitySet"));
        private static XName _AttrEntityType;
        public static XName AttrEntityType => _AttrEntityType ?? (_AttrEntityType = XName.Get("EntityType"));
        private static XName _AttrFixedLength;
        public static XName AttrFixedLength => _AttrFixedLength ?? (_AttrFixedLength = XName.Get("FixedLength"));
        private static XName _AttrFromRole;
        public static XName AttrFromRole => _AttrFromRole ?? (_AttrFromRole = XName.Get("FromRole"));
        private static XName _AttrHasStream;
        public static XName AttrHasStream => _AttrHasStream ?? (_AttrHasStream = XName.Get("HasStream"));
        private static XName _AttrMaxLength;
        public static XName AttrMaxLength => _AttrMaxLength ?? (_AttrMaxLength = XName.Get("MaxLength"));
        private static XName _AttrMultiplicity;
        public static XName AttrMultiplicity => _AttrMultiplicity ?? (_AttrMultiplicity = XName.Get("Multiplicity"));
        private static XName _AttrName;
        public static XName AttrName => _AttrName ?? (_AttrName = XName.Get("Name"));
        private static XName _AttrNullable;
        public static XName AttrNullable => _AttrNullable ?? (_AttrNullable = XName.Get("Nullable"));
        private static XName _AttrOpenType;
        public static XName AttrOpenType => _AttrOpenType ?? (_AttrOpenType = XName.Get("OpenType"));
        private static XName _AttrPrecision;
        public static XName AttrPrecision => _AttrPrecision ?? (_AttrPrecision = XName.Get("Precision"));
        private static XName _AttrRelationship;
        public static XName AttrRelationship => _AttrRelationship ?? (_AttrRelationship = XName.Get("Relationship"));
        private static XName _AttrRole;
        public static XName AttrRole => _AttrRole ?? (_AttrRole = XName.Get("Role"));
        private static XName _AttrSRID;
        public static XName AttrSRID => _AttrSRID ?? (_AttrSRID = XName.Get("SRID"));
        private static XName _AttrScale;
        public static XName AttrScale => _AttrScale ?? (_AttrScale = XName.Get("Scale"));
        private static XName _AttrToRole;
        public static XName AttrToRole => _AttrToRole ?? (_AttrToRole = XName.Get("ToRole"));
        private static XName _AttrType;
        public static XName AttrType => _AttrType ?? (_AttrType = XName.Get("Type"));
        private static XName _AttrUnicode;
        public static XName AttrUnicode => _AttrUnicode ?? (_AttrUnicode = XName.Get("Unicode"));
        private static XName _AttrUrl;
        public static XName AttrUrl => _AttrUrl ?? (_AttrUrl = XName.Get("Url"));
        private static XName _AttrVersion;
        public static XName AttrVersion => _AttrVersion ?? (_AttrVersion = XName.Get("Version"));

        private static XName _AttrPartner;
        public static XName AttrPartner => _AttrPartner ?? (_AttrPartner = XName.Get("Partner"));

        private static XName _AttrNamespace;
        public static XName AttrNamespace => _AttrNamespace ?? (_AttrNamespace = XName.Get("Namespace"));


        /*
         * 


            private static XName _AttrX;
            public static XName AttrX => _AttrX ?? (_AttrX = XName.Get("x"));

        
        private static XNamespace _NSX;
        public static XNamespace NS => _NSX ?? (_NSX = XNamespace.Get("x"));

        private static XName _X;
        public static XName X => _X ?? (_X = XName.Get("x"));

        private static XName _X;
        public static XName X => _X ?? (_X = (NSx + "x"));
        */

        private static CSDLConstants _CSDL1_0;
        private static CSDLConstants _CSDL1_1;
        private static CSDLConstants _CSDL1_2;
        private static CSDLConstants _CSDL2_0;
        private static CSDLConstants _CSDL3_0;
        private static CSDLConstants _CSDL4_0;

        public static CSDLConstants CSDL1_0 => _CSDL1_0 ?? (_CSDL1_0 = new CSDLConstants(NSCSDL1_0, 10, NSDataservicesMetadata));
        public static CSDLConstants CSDL1_1 => _CSDL1_1 ?? (_CSDL1_1 = new CSDLConstants(NSCSDL1_1, 11, NSDataservicesMetadata));
        public static CSDLConstants CSDL1_2 => _CSDL1_2 ?? (_CSDL1_2 = new CSDLConstants(NSCSDL1_2, 12, NSDataservicesMetadata));
        public static CSDLConstants CSDL2_0 => _CSDL2_0 ?? (_CSDL2_0 = new CSDLConstants(NSCSDL2_0, 20, NSDataservicesMetadata));
        public static CSDLConstants CSDL3_0 => _CSDL3_0 ?? (_CSDL3_0 = new CSDLConstants(NSCSDL3_0, 30, NSDataservicesMetadata));
        public static CSDLConstants CSDL4_0 => _CSDL4_0 ?? (_CSDL4_0 = new CSDLConstants(NSCSDL4_0, 40, NSDataservicesMetadata));

        private static EdmxConstants _EdmxV3;
        public static EdmxConstants EdmxV3 => _EdmxV3 ?? (_EdmxV3 = new EdmxConstants(NSEdmxV3, NSDataservicesMetadata));

        private static EdmxConstants _EdmxV4;
        public static EdmxConstants EdmxV4 => _EdmxV4 ?? (_EdmxV4 = new EdmxConstants(NSEdmxV4, NSEdmxV4));

        public class EdmxConstants {
            public readonly XNamespace EdmxNamespace;
            public readonly XNamespace DataservicesMetadataNamespace;

            public EdmxConstants(XNamespace edmxNamespace, XNamespace nsDataservicesMetadata) {
                this.EdmxNamespace = edmxNamespace;
                this.DataservicesMetadataNamespace = nsDataservicesMetadata;
            }

            private XName _EdmxAnnotationsReference;
            public XName EdmxAnnotationsReference => _EdmxAnnotationsReference ?? (_EdmxAnnotationsReference = (EdmxNamespace + "AnnotationsReference"));

            private XName _EdmxDataServices;
            public XName EdmxDataServices => _EdmxDataServices ?? (_EdmxDataServices = (EdmxNamespace + "DataServices"));

            private XName _EdmxReference;
            public XName EdmxReference => _EdmxReference ?? (_EdmxReference = (EdmxNamespace + "Reference"));

            private XName _AttrDataServiceVersion;
            public XName AttrDataServiceVersion => _AttrDataServiceVersion ?? (_AttrDataServiceVersion = (DataservicesMetadataNamespace + "DataServiceVersion"));
        }

        public class CSDLConstants {
            public readonly XNamespace Namespace;
            public readonly XNamespace DataservicesMetadataNamespace;
            public readonly int Version;

            public CSDLConstants(XNamespace xNamespace, int version, XNamespace nsDataservicesMetadata) {
                this.Namespace = xNamespace;
                this.Version = version;
                this.DataservicesMetadataNamespace = nsDataservicesMetadata;
            }

            private XName _Schema;
            public XName Schema => _Schema ?? (_Schema = (Namespace + "Schema"));

            private XName _Annotations;
            public XName Annotations => _Annotations ?? (_Annotations = (Namespace + "Annotations"));

            private XName _Association;
            public XName Association => _Association ?? (_Association = (Namespace + "Association"));

            private XName _ComplexType;
            public XName ComplexType => _ComplexType ?? (_ComplexType = (Namespace + "ComplexType"));

            private XName _EntityContainer;
            public XName EntityContainer => _EntityContainer ?? (_EntityContainer = (Namespace + "EntityContainer"));

            private XName _EntityType;
            public XName EntityType => _EntityType ?? (_EntityType = (Namespace + "EntityType"));

            private XName _EnumType;
            public XName EnumType => _EnumType ?? (_EnumType = (Namespace + "EnumType"));

            private XName _Function;
            public XName Function => _Function ?? (_Function = (Namespace + "Function"));

            private XName _Using;
            public XName Using => _Using ?? (_Using = (Namespace + "Using"));

            private XName _ValueTerm;
            public XName ValueTerm => _ValueTerm ?? (_ValueTerm = (Namespace + "ValueTerm"));

            private XName _Key;
            public XName Key => _Key ?? (_Key = (Namespace + "Key"));

            private XName _Property;
            public XName Property => _Property ?? (_Property = (Namespace + "Property"));


            private XName _NavigationProperty;
            public XName NavigationProperty => _NavigationProperty ?? (_NavigationProperty = (Namespace + "NavigationProperty"));


            private XName _End;
            public XName End => _End ?? (_End = (Namespace + "End"));

            private XName _EntitySet;
            public XName EntitySet => _EntitySet ?? (_EntitySet = (Namespace + "EntitySet"));

            private XName _AssociationSet;
            public XName AssociationSet => _AssociationSet ?? (_AssociationSet = (Namespace + "AssociationSet"));

            private XName _PropertyRef;
            public XName PropertyRef => _PropertyRef ?? (_PropertyRef = (Namespace + "PropertyRef"));

            private XName _ReferentialConstraint;
            public XName ReferentialConstraint => _ReferentialConstraint ?? (_ReferentialConstraint = (Namespace + "ReferentialConstraint"));

            private XName _Principal;
            public XName Principal => _Principal ?? (_Principal = (Namespace + "Principal"));

            private XName _Dependent;
            public XName Dependent => _Dependent ?? (_Dependent = (Namespace + "Dependent"));

            private XName _AttrIsDefaultEntityContainer;
            public XName AttrIsDefaultEntityContainer => _AttrIsDefaultEntityContainer ?? (_AttrIsDefaultEntityContainer = (this.DataservicesMetadataNamespace + "IsDefaultEntityContainer"));

            /*
            private XName _Y;
            public XName Y => _Y ?? (_Y = (Namespace + "Y"));

            private static XName _AttrX;
            public static XName AttrX => _AttrX ?? (_AttrX = XName.Get("x"));
             */
        }
    }
}
