namespace OfaSchlupfer.SPO {
    using System;
    using System.Collections.Specialized;
    using System.Globalization;
    using System.Net;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;

    internal static class IdcrlUtility {
        private const string DummyElementName = "DummyElement";

        private const string DummyElementTag = "<DummyElement>";

        public static string XmlValueEncode(string value) {
            StringBuilder stringBuilder = new StringBuilder();
            using (XmlWriter xmlWriter = XmlWriter.Create(stringBuilder)) {
                xmlWriter.WriteElementString("DummyElement", value);
            }
            string text = stringBuilder.ToString();
            int num = text.IndexOf("<DummyElement>", StringComparison.Ordinal) + "<DummyElement>".Length;
            int num2 = text.IndexOf('<', num);
            return text.Substring(num, num2 - num);
        }

        internal static XElement GetElementAtPath(XElement elem, params string[] paths) {
            foreach (string expandedName in paths) {
                if (elem == null) {
                    return null;
                }
                elem = elem.Element(XName.Get(expandedName));
            }
            return elem;
        }

        internal static string GetWebResponseHeader(WebResponse response) {
            StringBuilder stringBuilder = new StringBuilder();
            if (response != null && response.SupportsHeaders && response.Headers != null) {
                string[] allKeys = response.Headers.AllKeys;
                foreach (string text in allKeys) {
                    if (stringBuilder.Length > 0) {
                        stringBuilder.Append(", ");
                    }
                    stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "{0}={1}", new object[2]
                    {
                        text,
                        ((NameValueCollection)response.Headers)[text]
                    });
                }
            }
            return stringBuilder.ToString();
        }
    }
}
