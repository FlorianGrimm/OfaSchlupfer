namespace OfaSchlupfer.ModelOData.Edm {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml.Linq;
    using OfaSchlupfer.Model;

    public static class ModelErrorsExtension {
        public static void AddErrorXmlParsing(this ModelErrors errors, string msg, Func<ModelErrorInfo, Exception> generator, params XObject[] args) {
            if (errors != null && errors.Errors == null) {
                // fast ignorance
                return;
            }
            var mi = new ModelErrorInfo() { Text = msg, Location = "" };
            if (args.Length > 0) {
                var sb = new StringBuilder();
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
                mi.Location = sb.ToString();
            }
            if ((object)errors == null) {
                if (generator == null) {
                    throw new ModelException(msg, new ModelErrors(mi));
                } else {
                    throw (generator(mi));
                }
            } else {
                errors.Errors?.Add(mi);
            }
        }
    }
}
