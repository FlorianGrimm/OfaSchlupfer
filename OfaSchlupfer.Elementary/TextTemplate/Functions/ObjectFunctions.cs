
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using OfaSchlupfer.TextTemplate.Helpers;
using OfaSchlupfer.TextTemplate.Parsing;
using OfaSchlupfer.TextTemplate.Runtime;

namespace OfaSchlupfer.TextTemplate.Functions {
    /// <summary>
    /// Object functions available through the builtin object 'object'.
    /// </summary>
    public class ObjectFunctions : ScriptObject {
        /// <summary>
        /// The `default` value is returned if the input `value` is null or an empty string "". A string containing whitespace characters will not resolve to the default value.
        /// </summary>
        /// <param name="value">The input value to check if it is null or an empty string.</param>
        /// <param name="default">The default alue to return if the input `value` is null or an empty string.</param>
        /// <returns>The `default` value is returned if the input `value` is null or an empty string "", otherwise it returns `value`</returns>
        /// <remarks>
        /// ```scriban-html
        /// {{ undefined_var | object.default "Yo" }}
        /// ```
        /// ```html
        /// Yo
        /// ```
        /// </remarks>
        public static object Default(object value, object @default) {
            return value == null || (value is string && string.IsNullOrEmpty((string)value)) ? @default : value;
        }

        /// <summary>
        /// Checks if the specified object as the member `key`
        /// </summary>
        /// <param name="value">The input object.</param>
        /// <param name="key">The member name to check its existence.</param>
        /// <returns>**true** if the input object contains the member `key`; otherwise **false**</returns>
        /// <remarks>
        /// ```scriban-html
        /// {{ product | object.has_key "title" }}
        /// ```
        /// ```html
        /// true
        /// ```
        /// </remarks>
        public static bool HasKey(IDictionary<string, object> value, string key) {
            if (value == null || key == null) {
                return false;
            }

            return value.ContainsKey(key);
        }

        /// <summary>
        /// Checks if the specified object as a value for the member `key`
        /// </summary>
        /// <param name="value">The input object.</param>
        /// <param name="key">The member name to check the existence of its value.</param>
        /// <returns>**true** if the input object contains the member `key` and has a value; otherwise **false**</returns>
        /// <remarks>
        /// ```scriban-html
        /// {{ product | object.has_value "title" }}
        /// ```
        /// ```html
        /// true
        /// ```
        /// </remarks>
        public static bool HasValue(IDictionary<string, object> value, string key) {
            if (value == null || key == null) {
                return false;
            }
            return value.ContainsKey(key) && value[key] != null;
        }

        /// <summary>
        /// Gets the members/keys of the specified value object.
        /// </summary>
        /// <param name="value">The input object.</param>
        /// <returns>A list with the member names/key of the input object</returns>
        /// <remarks>
        /// ```scriban-html
        /// {{ product | object.keys | array.sort }}
        /// ```
        /// ```html
        /// [title, type]
        /// ```
        /// </remarks>
        public new static ScriptArray Keys(IDictionary<string, object> value) {
            return value == null ? new ScriptArray() : new ScriptArray(value.Keys);
        }

        /// <summary>
        /// Returns the size of the input object. 
        /// - If the input object is a string, it will return the length
        /// - If the input is a list, it will return the number of elements
        /// - If the input is an object, it will return the number of members
        /// </summary>
        /// <param name="context">The template context</param>
        /// <param name="span">The source span</param>
        /// <param name="value">The input object.</param>
        /// <returns>The size of the input object.</returns>
        /// <remarks>
        /// ```scriban-html
        /// {{ [1, 2, 3] | object.size }}
        /// ```
        /// ```html
        /// 3
        /// ```
        /// </remarks>
        public static int Size(TemplateContext context, SourceSpan span, object value) {
            if (value is string) {
                return StringFunctions.Size((string) value);
            }

            if (value is IEnumerable) {
                return ArrayFunctions.Size((IEnumerable) value);
            }

            // Should we throw an exception?
            return 0;
        }

        /// <summary>
        /// Returns string representing the type of the input object. The type can be `string`, `boolean`, `number`, `array`, `iterator` and `object` 
        /// </summary>
        /// <param name="value">The input object.</param>
        /// <remarks>
        /// ```scriban-html
        /// {{ null | object.typeof }}
        /// {{ true | object.typeof }}
        /// {{ 1 | object.typeof }}
        /// {{ 1.0 | object.typeof }}
        /// {{ "text" | object.typeof }}
        /// {{ 1..5 | object.typeof }}
        /// {{ [1,2,3,4,5] | object.typeof }}
        /// {{ {} | object.typeof }}
        /// {{ object | object.typeof }}
        /// ```
        /// ```html
        /// 
        /// boolean
        /// number
        /// number
        /// string
        /// iterator
        /// array
        /// object
        /// object
        /// ```
        /// </remarks>
        public static string Typeof(object value) {
            if (value is null) {
                return null;
            }
            var type = value.GetType();
            var typeInfo = type.GetTypeInfo();
            if (type == typeof(string)) {
                return "string";
            }

            if (type == typeof(bool)) {
                return "boolean";
            }

            // We assume that we are only using int/double/long for integers and shortcut to IsPrimitive
            if (typeInfo.IsPrimitive) {
                return "number";
            }

            // Test first IList, then IEnumerable
            if (typeof(IList).GetTypeInfo().IsAssignableFrom(typeInfo)) {
                return "array";
            }

            if ((!typeof(ScriptObject).GetTypeInfo().IsAssignableFrom(typeInfo) && !typeof(IDictionary).GetTypeInfo().IsAssignableFrom(typeInfo)) &&
                typeof(IEnumerable).GetTypeInfo().IsAssignableFrom(typeInfo)) {
                return "iterator";
            }

            return "object";
        }

        /// <summary>
        /// Gets the member's values of the specified value object.
        /// </summary>
        /// <param name="value">The input object.</param>
        /// <returns>A list with the member values of the input object</returns>
        /// <remarks>
        /// ```scriban-html
        /// {{ product | object.values | array.sort }}
        /// ```
        /// ```html
        /// [fruit, Orange]
        /// ```
        /// </remarks>
        public new static ScriptArray Values(IDictionary<string, object> value) {
            return value == null ? new ScriptArray() : new ScriptArray(value.Values);
        }
    }
}