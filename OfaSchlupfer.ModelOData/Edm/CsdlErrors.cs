namespace OfaSchlupfer.ModelOData.Edm {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml.Linq;
    using OfaSchlupfer.Model;

    public static class ModelErrorsExtension {
        public static void AddErrorXmlParsing(this ModelErrors errors, string msg, params XObject[] args) {
            if (errors != null && errors.Errors == null) { return; }
            var sb = new StringBuilder();
            if (!string.IsNullOrEmpty(msg)) {
                sb.Append(msg);
            }
            foreach (var o in args) {
                if ((object)o == null) { continue; }
                if (o is XElement element) {
                    if (sb.Length > 0) { sb.Append(" - "); }
                    sb.Append(element.Name.ToString());
                } else if (o is XAttribute attribute) {
                    if (sb.Length > 0) { sb.Append(" - "); }
                    sb.Append(attribute.Name.ToString());
                } else {
                }
            }
            if ((object)errors == null) {
                throw new InvalidOperationException(sb.ToString());
            } else {
                if (errors.Errors != null) {
                    errors.Errors.Add(new ModelErrorInfo(sb.ToString()));
                }
                //errors.Errors?.Add(sb.ToString());
            }
        }
    }
}
