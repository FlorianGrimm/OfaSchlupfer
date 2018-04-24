namespace OfaSchlupfer.Model {
    using System;
    using System.Collections.Generic;
    using System.Runtime;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Xml.Linq;

    [Serializable]
    public sealed class ModelErrors : ISerializable {
        /// <summary>
        /// the errors
        /// </summary>
        /// <remarks>
        /// CAN BE NULL
        /// </remarks>
        public readonly List<ModelErrorInfo> Errors;

        private ModelErrors(bool ignoreance) {
            if (ignoreance) {
                this.Errors = null;
            } else {
                this.Errors = new List<ModelErrorInfo>();
            }
        }

        public ModelErrors() {
            this.Errors = new List<ModelErrorInfo>();
        }

        public ModelErrors(ModelErrorInfo modelErrorInfo) {
            this.Errors = new List<ModelErrorInfo>();
            if (modelErrorInfo != null) {
                this.Errors.Add(modelErrorInfo);
            }
        }

        //public bool HasErrors() {
        //    if (this.Errors == null) {
        //        return false;
        //    }
        //    return (this.Errors.Count > 0);
        //}

        public void Add(ModelErrorInfo item) {
            this.Errors?.Add(item);
        }

        private static ModelErrors _Ignorance;
        public static ModelErrors GetIgnorance() => (_Ignorance ?? (_Ignorance = new ModelErrors(true)));

        private ModelErrors(SerializationInfo info, StreamingContext context) {
            try {
                this.Errors = (List<ModelErrorInfo>)(info.GetValue("Errors", typeof(List<ModelErrorInfo>)));
            } catch { }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context) {
            info.AddValue("Errors", this.Errors, typeof(List<ModelErrorInfo>));
        }

        public override string ToString() {
            if (this.Errors == null) { return string.Empty; }
            var sb = new StringBuilder();
            foreach (var item in this.Errors) {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
    }

    [Serializable]
    public sealed class ModelErrorInfo : ISerializable {
        public string Text { get; set; }
        public string Location { get; set; }

        public ModelErrorInfo() { }

        public ModelErrorInfo(string text) {
            this.Text = text;
        }

        public ModelErrorInfo(string text, string location) {
            this.Text = text;
            this.Location = location;
        }

        private ModelErrorInfo(SerializationInfo info, StreamingContext context) {
            try {
                this.Text = info.GetString("Text");
                this.Location = info.GetString("Location");
            } catch { }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context) {
            info.AddValue("Text", this.Text);
            info.AddValue("Location", this.Location);
        }

        public override string ToString() {
            return $"{this.Text} @ {this.Location}";
        }
    }

    public static class ModelErrorsExtension {
        public static void AddErrorOrThrow(this ModelErrors errors, string msg, string location, Func<ModelErrorInfo, Exception> generator = null) {
            if ((object)errors == null) {
                if (generator == null) {
                    throw new ModelException(string.Empty, new ModelErrors(new ModelErrorInfo(msg, location)));
                } else {
                    throw (generator(new ModelErrorInfo(msg, location)));
                }
            } else {
                errors.Errors?.Add(new ModelErrorInfo(msg, location));
            }
        }

        public static void AddErrorOrThrow(this ModelErrors errors, ModelErrorInfo modelErrorInfo, Func<string, Exception> generator = null) {
            if ((object)errors == null) {
                if (generator == null) {
                    throw new ModelException(string.Empty, new ModelErrors(modelErrorInfo));
                } else {
                    throw (generator(modelErrorInfo.ToString()));
                }
            } else {
                errors.Errors?.Add(modelErrorInfo);
            }
        }

        public static bool HasErrors(this ModelErrors errors) {
            if ((object)errors == null) {
                return false;
            }
            if ((object)(errors.Errors) == null) {
                return false;
            }
            return (errors.Errors.Count > 0);
        }

        /*
        public static void AddError(this ModelErrors errors, string msg, params XObject[] args) {
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
                errors.Errors?.Add(sb.ToString());
            }
        }
        */
    }
}
