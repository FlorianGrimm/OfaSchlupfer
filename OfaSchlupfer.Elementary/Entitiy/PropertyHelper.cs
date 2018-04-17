namespace OfaSchlupfer.Entity {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class PropertyHelper {
        /// <summary>
        /// Get the value of the property named name of that entity .
        /// </summary>
        /// <param name="that">the owner entity</param>
        /// <param name="name">the name of the property.</param>
        /// <param name="ignoreIfNotExists">throw an error or ignore</param>
        /// <param name="ifNotExistsValue">if not exists and ignored return this value.</param>
        /// <returns>The value -or- ifNotExistsValue</returns>
        public static object GetProperty(this IEntity that, string name, bool ignoreIfNotExists = true, object ifNotExistsValue = null) {
            if ((object)that == null) { throw new ArgumentNullException(nameof(that)); }
            if ((object)name == null) { throw new ArgumentNullException(nameof(name)); }
            var property = that.MetaData.GetProperty(name);
            if ((object)property == null) {
                if (ignoreIfNotExists) {
                    return ifNotExistsValue;
                } else {
                    throw new InvalidOperationException(string.Format("Property {0} not found.", name));
                }
            }
            return property.GetAccessor(that).Value;
        }

        /// <summary>
        /// Get the string value of the property named name of that entity .
        /// </summary>
        /// <param name="that">the owner entity</param>
        /// <param name="name">the name of the property.</param>
        /// <param name="ignoreIfNotExists">throw an error or ignore</param>
        /// <param name="ifNotExistsValue">if not exists and ignored return this value.</param>
        /// <returns>The value -or- ifNotExistsValue</returns>
        public static string GetPropertyAsString(this IEntity that, string name, bool ignoreIfNotExists = true, string ifNotExistsValue = null) {
            object value = GetProperty(that, name, ignoreIfNotExists, ifNotExistsValue);
            return (string)value;
        }

        /// <summary>
        /// Get the TimeSpan value of the property named name of that entity .
        /// </summary>
        /// <param name="that">the owner entity</param>
        /// <param name="name">the name of the property.</param>
        /// <param name="ignoreIfNotExists">throw an error or ignore</param>
        /// <param name="ifNotExistsValue">if not exists and ignored return this value.</param>
        /// <returns>The value -or- ifNotExistsValue</returns>
        public static System.TimeSpan? GetPropertyAsTimeSpanQ(this IEntity that, string name, bool ignoreIfNotExists = true, string ifNotExistsValue = null) {
            object value = GetProperty(that, name, ignoreIfNotExists, ifNotExistsValue);
            if (value == null) { return null; }
            if (value is decimal) {
                var dec = ((decimal)value);
                return TimeSpan.FromMinutes((double)dec);
            }
            throw new NotImplementedException("GetPropertyAsTimeSpanQ");
        }

        /// <summary>
        /// Get the Double value of the property named name of that entity .
        /// </summary>
        /// <param name="that">the owner entity</param>
        /// <param name="name">the name of the property.</param>
        /// <param name="ignoreIfNotExists">throw an error or ignore</param>
        /// <param name="ifNotExistsValue">if not exists and ignored return this value.</param>
        /// <returns>The value -or- ifNotExistsValue</returns>
        public static double? GetPropertyAsDoubleQ(this IEntity that, string name, bool ignoreIfNotExists = true, string ifNotExistsValue = null) {
            object value = GetProperty(that, name, ignoreIfNotExists, ifNotExistsValue);
            if (value == null) { return null; }
            if (value is double) {
                return ((double)value);
            }
            throw new NotImplementedException("GetPropertyAsTimeSpanQ");
        }

        /// <summary>
        /// Get the Enum value of the property named name of that entity .
        /// </summary>
        /// <typeparam name="TEnum">a enum</typeparam>
        /// <param name="that">the owner entity</param>
        /// <param name="name">the name of the property.</param>
        /// <param name="ignoreIfNotExists">throw an error or ignore</param>
        /// <param name="ifNotExistsValue">if not exists and ignored return this value.</param>
        /// <returns>The value -or- ifNotExistsValue</returns>
        public static TEnum? GetPropertyAsEnumQ<TEnum>(this IEntity that, string name, bool ignoreIfNotExists = true, string ifNotExistsValue = null)
            where TEnum : struct {
            object value = GetProperty(that, name, ignoreIfNotExists, ifNotExistsValue);
            if (value == null) { return null; }
            if (value is string) {
                TEnum e;
                if (Enum.TryParse<TEnum>((string)value, out e)) {
                    return e;
                } else {
                    return null;
                }
            }
            if (value is int) {
                return (TEnum)(value);
            }
            throw new NotImplementedException("GetPropertyAsTimeSpanQ");
        }

        /// <summary>
        /// Get the Guid value of the property named name of that entity .
        /// </summary>
        /// <param name="that">the owner entity</param>
        /// <param name="name">the name of the property.</param>
        /// <param name="ignoreIfNotExists">throw an error or ignore</param>
        /// <param name="ifNotExistsValue">if not exists and ignored return this value.</param>
        /// <returns>The value</returns>
        public static Guid GetPropertyAsGuid(this IEntity that, string name, bool ignoreIfNotExists = true, Guid? ifNotExistsValue = null) {
            object value = GetProperty(that, name, ignoreIfNotExists, ifNotExistsValue);
            return (Guid)value;
        }

        /// <summary>
        /// Get the bool value of the property named name of that entity .
        /// </summary>
        /// <param name="that">the owner entity</param>
        /// <param name="name">the name of the property.</param>
        /// <param name="ignoreIfNotExists">throw an error or ignore</param>
        /// <param name="ifNotExistsValue">if not exists and ignored return this value.</param>
        /// <returns>The value</returns>
        public static bool GetPropertyAsBool(this IEntity that, string name, bool ignoreIfNotExists = true, bool? ifNotExistsValue = null) {
            object value = GetProperty(that, name, ignoreIfNotExists, ifNotExistsValue);
            return (bool)value;
        }

        /// <summary>
        /// Get the bool? value of the property named name of that entity .
        /// </summary>
        /// <param name="that">the owner entity</param>
        /// <param name="name">the name of the property.</param>
        /// <param name="ignoreIfNotExists">throw an error or ignore</param>
        /// <param name="ifNotExistsValue">if not exists and ignored return this value.</param>
        /// <returns>The value</returns>
        public static bool? GetPropertyAsBoolQ(this IEntity that, string name, bool ignoreIfNotExists = true, bool? ifNotExistsValue = null) {
            object value = GetProperty(that, name, ignoreIfNotExists, ifNotExistsValue);
            return (bool?)value;
        }

        /// <summary>
        /// Get the Guid? value of the property named name of that entity .
        /// </summary>
        /// <param name="that">the owner entity</param>
        /// <param name="name">the name of the property.</param>
        /// <param name="ignoreIfNotExists">throw an error or ignore</param>
        /// <param name="ifNotExistsValue">if not exists and ignored return this value.</param>
        /// <returns>The value</returns>
        public static Guid? GetPropertyAsGuidQ(this IEntity that, string name, bool ignoreIfNotExists = true, Guid? ifNotExistsValue = null) {
            object value = GetProperty(that, name, ignoreIfNotExists, ifNotExistsValue);
            return (Guid?)value;
        }

        /// <summary>
        /// Get the Byte value of the property named name of that entity .
        /// </summary>
        /// <param name="that">the owner entity</param>
        /// <param name="name">the name of the property.</param>
        /// <param name="ignoreIfNotExists">throw an error or ignore</param>
        /// <param name="ifNotExistsValue">if not exists and ignored return this value.</param>
        /// <returns>The value</returns>
        public static byte GetPropertyAsByte(this IEntity that, string name, bool ignoreIfNotExists = true, byte ifNotExistsValue = 0) {
            object value = GetProperty(that, name, ignoreIfNotExists, ifNotExistsValue);
            try {
                return (byte)value;
            } catch {
                return System.Convert.ToByte(value);
            }
        }

        /// <summary>
        /// Get the Byte? value of the property named name of that entity .
        /// </summary>
        /// <param name="that">the owner entity</param>
        /// <param name="name">the name of the property.</param>
        /// <param name="ignoreIfNotExists">throw an error or ignore</param>
        /// <param name="ifNotExistsValue">if not exists and ignored return this value.</param>
        /// <returns>The value</returns>
        public static byte? GetPropertyAsByteQ(this IEntity that, string name, bool ignoreIfNotExists = true, byte? ifNotExistsValue = null) {
            object value = GetProperty(that, name, ignoreIfNotExists, ifNotExistsValue);
            if (value == null) {
                return null;
            }
            try {
                return (byte)value;
            } catch {
                return System.Convert.ToByte(value);
            }
        }

        /// <summary>
        /// Get the short value of the property named name of that entity .
        /// </summary>
        /// <param name="that">the owner entity</param>
        /// <param name="name">the name of the property.</param>
        /// <param name="ignoreIfNotExists">throw an error or ignore</param>
        /// <param name="ifNotExistsValue">if not exists and ignored return this value.</param>
        /// <returns>The value</returns>
        public static short GetPropertyAsShort(this IEntity that, string name, bool ignoreIfNotExists = true, short ifNotExistsValue = 0) {
            object value = GetProperty(that, name, ignoreIfNotExists, ifNotExistsValue);
            try {
                return (short)value;
            } catch {
                return System.Convert.ToInt16(value);
            }
        }

        /// <summary>
        /// Get the short? value of the property named name of that entity .
        /// </summary>
        /// <param name="that">the owner entity</param>
        /// <param name="name">the name of the property.</param>
        /// <param name="ignoreIfNotExists">throw an error or ignore</param>
        /// <param name="ifNotExistsValue">if not exists and ignored return this value.</param>
        /// <returns>The value</returns>
        public static short? GetPropertyAsShortQ(this IEntity that, string name, bool ignoreIfNotExists = true, short? ifNotExistsValue = null) {
            object value = GetProperty(that, name, ignoreIfNotExists, ifNotExistsValue);
            if (value == null) {
                return null;
            }
            try {
                return (short)value;
            } catch {
                return System.Convert.ToInt16(value);
            }
        }

        /// <summary>
        /// Get the int value of the property named name of that entity .
        /// </summary>
        /// <param name="that">the owner entity</param>
        /// <param name="name">the name of the property.</param>
        /// <param name="ignoreIfNotExists">throw an error or ignore</param>
        /// <param name="ifNotExistsValue">if not exists and ignored return this value.</param>
        /// <returns>The value</returns>
        public static int GetPropertyAsInt(this IEntity that, string name, bool ignoreIfNotExists = true, int ifNotExistsValue = 0) {
            object value = GetProperty(that, name, ignoreIfNotExists, ifNotExistsValue);
            try {
                return (int)value;
            } catch {
                return System.Convert.ToInt32(value);
            }
        }

        /// <summary>
        /// Get the int? value of the property named name of that entity .
        /// </summary>
        /// <param name="that">the owner entity</param>
        /// <param name="name">the name of the property.</param>
        /// <param name="ignoreIfNotExists">throw an error or ignore</param>
        /// <param name="ifNotExistsValue">if not exists and ignored return this value.</param>
        /// <returns>The value</returns>
        public static int? GetPropertyAsIntQ(this IEntity that, string name, bool ignoreIfNotExists = true, int? ifNotExistsValue = null) {
            object value = GetProperty(that, name, ignoreIfNotExists, ifNotExistsValue);
            if (value == null) {
                return null;
            }
            try {
                return (int)value;
            } catch {
                return System.Convert.ToInt32(value);
            }
        }

        /// <summary>
        /// Get the long value of the property named name of that entity .
        /// </summary>
        /// <param name="that">the owner entity</param>
        /// <param name="name">the name of the property.</param>
        /// <param name="ignoreIfNotExists">throw an error or ignore</param>
        /// <param name="ifNotExistsValue">if not exists and ignored return this value.</param>
        /// <returns>The value</returns>
        public static long GetPropertyAsLong(this IEntity that, string name, bool ignoreIfNotExists = true, long ifNotExistsValue = 0) {
            object value = GetProperty(that, name, ignoreIfNotExists, ifNotExistsValue);
            return (long)value;
        }

        /// <summary>
        /// Get the long? value of the property named name of that entity .
        /// </summary>
        /// <param name="that">the owner entity</param>
        /// <param name="name">the name of the property.</param>
        /// <param name="ignoreIfNotExists">throw an error or ignore</param>
        /// <param name="ifNotExistsValue">if not exists and ignored return this value.</param>
        /// <returns>The value</returns>
        public static long? GetPropertyAsLongQ(this IEntity that, string name, bool ignoreIfNotExists = true, long? ifNotExistsValue = null) {
            object value = GetProperty(that, name, ignoreIfNotExists, ifNotExistsValue);
            return (long?)value;
        }

        /// <summary>
        /// Get the DateTime value of the property named name of that entity .
        /// </summary>
        /// <param name="that">the owner entity</param>
        /// <param name="name">the name of the property.</param>
        /// <param name="ignoreIfNotExists">throw an error or ignore</param>
        /// <param name="ifNotExistsValue">if not exists and ignored return this value.</param>
        /// <returns>The value</returns>
        public static DateTime GetPropertyAsDateTime(this IEntity that, string name, bool ignoreIfNotExists = true, DateTime? ifNotExistsValue = null) {
            object value = GetProperty(that, name, ignoreIfNotExists, ifNotExistsValue);
            return (DateTime)value;
        }

        /// <summary>
        /// Get the DateTime? value of the property named name of that entity .
        /// </summary>
        /// <param name="that">the owner entity</param>
        /// <param name="name">the name of the property.</param>
        /// <param name="ignoreIfNotExists">throw an error or ignore</param>
        /// <param name="ifNotExistsValue">if not exists and ignored return this value.</param>
        /// <returns>The value</returns>
        public static DateTime? GetPropertyAsDateTimeQ(this IEntity that, string name, bool ignoreIfNotExists = true, DateTime? ifNotExistsValue = null) {
            object value = GetProperty(that, name, ignoreIfNotExists, ifNotExistsValue);
            return (DateTime?)value;
        }

        /// <summary>
        /// Set the value of property named named of that entity to value.
        /// </summary>
        /// <param name="that">the owner entity</param>
        /// <param name="name">the name of the property.</param>
        /// <param name="value">the value.</param>
        /// <param name="ignoreIfNotExists">throw an error or ignore</param>
        public static void SetProperty(this IEntity that, string name, object value, bool ignoreIfNotExists = true) {
            if ((object)that == null) { throw new ArgumentNullException(nameof(that)); }
            if ((object)name == null) { throw new ArgumentNullException(nameof(name)); }
            var property = that.MetaData.GetProperty(name);
            if ((object)property == null) {
                if (ignoreIfNotExists) {
                    return;
                } else {
                    throw new InvalidOperationException(string.Format("Property {0} not found.", name));
                }
            }
            property.GetAccessor(that).Value = value;
        }
    }
}