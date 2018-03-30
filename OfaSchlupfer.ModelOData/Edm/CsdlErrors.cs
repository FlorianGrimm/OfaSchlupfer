﻿namespace OfaSchlupfer.ModelOData.Edm {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml.Linq;

    public class CsdlErrors {
        public readonly List<string> Errors;
        public CsdlErrors() {
            this.Errors = new List<string>();
        }
    }

    public static class CsdlErrorsExtension {
        public static void AddError(this CsdlErrors errors, string msg, params XObject[] args) {
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
                throw new NotImplementedException(sb.ToString());
            } else {
                errors.Errors.Add(sb.ToString());
            }
        }
    }
}
