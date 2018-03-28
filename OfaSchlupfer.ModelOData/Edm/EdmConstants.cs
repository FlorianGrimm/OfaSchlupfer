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

        private static XNamespace _NSEdmx;
        public static XNamespace NSEdmx => _NSEdmx ?? (_NSEdmx = XNamespace.Get("http://schemas.microsoft.com/ado/2007/06/edmx"));

        private static XNamespace _NSDataservicesMetadata;
        public static XNamespace NSDataservicesMetadata => _NSDataservicesMetadata ?? (_NSDataservicesMetadata = XNamespace.Get("http://schemas.microsoft.com/ado/2007/08/dataservices/metadata"));

        private static XName _EdmxDocument;
        public static XName EdmxDocument => _EdmxDocument ?? (_EdmxDocument = (NSEdmx + "Edmx"));

        private static XNamespace _NSEdmAnnotation;
        public static XNamespace NSEdmAnnotation => _NSEdmAnnotation ?? (_NSEdmAnnotation = XNamespace.Get("http://schemas.microsoft.com/ado/2009/02/edm/annotation"));

        private static XName _EdmxAnnotationsReference;
        public static XName EdmxAnnotationsReference => _EdmxAnnotationsReference ?? (_EdmxAnnotationsReference = (NSEdmx + "AnnotationsReference"));

        private static XName _EdmxDataServices;
        public static XName EdmxDataServices => _EdmxDataServices ?? (_EdmxDataServices = (NSEdmx + "DataServices"));

        private static XName _DataServiceVersion;
        public static XName DataServiceVersion => _DataServiceVersion ?? (_DataServiceVersion = (NSDataservicesMetadata + "DataServiceVersion"));

        private static XName _EdmxReference;
        public static XName EdmxReference => _EdmxReference ?? (_EdmxReference = (NSEdmx + "Reference"));

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

        private static XName _AttrX;
        public static XName AttrX => _AttrX ?? (_AttrX = XName.Get("x"));

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

        public static CSDLConstants CSDL1_0 => _CSDL1_0 ?? (_CSDL1_0 = new CSDLConstants(NSCSDL1_0));
        public static CSDLConstants CSDL1_1 => _CSDL1_1 ?? (_CSDL1_1 = new CSDLConstants(NSCSDL1_1));
        public static CSDLConstants CSDL1_2 => _CSDL1_2 ?? (_CSDL1_2 = new CSDLConstants(NSCSDL1_2));
        public static CSDLConstants CSDL2_0 => _CSDL2_0 ?? (_CSDL2_0 = new CSDLConstants(NSCSDL2_0));
        public static CSDLConstants CSDL3_0 => _CSDL3_0 ?? (_CSDL3_0 = new CSDLConstants(NSCSDL3_0));

        public class CSDLConstants {
            public readonly XNamespace Namespace;

            public CSDLConstants(XNamespace xNamespace) {
                this.Namespace = xNamespace;
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

            /*
            private XName _Y;
            public XName Y => _Y ?? (_Y = (Namespace + "Y"));

            private static XName _AttrX;
            public static XName AttrX => _AttrX ?? (_AttrX = XName.Get("x"));
             */
        }
    }
}
