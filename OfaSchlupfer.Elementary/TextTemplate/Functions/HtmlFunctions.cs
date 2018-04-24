
using System;
using System.Text.RegularExpressions;
using OfaSchlupfer.TextTemplate.Runtime;

namespace OfaSchlupfer.TextTemplate.Functions {
    /// <summary>
    /// Html functions available through the builtin object 'html'.
    /// </summary>
    public class HtmlFunctions : ScriptObject {
        // From https://stackoverflow.com/a/17668453/1356325
        private const string RegexMatchHtml = @"<script.*?</script>|<!--.*?-->|<style.*?</style>|<(?:[^>=]|='[^']*'|=""[^""]*""|=[^'""][^\s>]*)*>";
#if NET35 || NET40 || PCL328
        private static readonly Regex stripHtml = new Regex(RegexMatchHtml, RegexOptions.IgnoreCase | RegexOptions.Singleline);
#endif

        /// <summary>
        /// Removes any HTML tags from the input string
        /// </summary>
        /// <param name="context">The template context (used for <see cref="TemplateContext.RegexTimeOut"/>)</param>
        /// <param name="text">The input string</param>
        /// <returns>The input string removed with any HTML tags</returns>
        /// <remarks>
        /// ```scriban-html
        /// {{ "&lt;p&gt;This is a paragraph&lt;/p&gt;" | html.strip }}
        /// ```
        /// ```html
        /// This is a paragraph
        /// ```
        /// </remarks>
        public static string Strip(TemplateContext context, string text) {
            if (string.IsNullOrEmpty(text)) {
                return text;
            }
#if !NET35 && !NET40 && !PCL328
            var stripHtml = new Regex(RegexMatchHtml, RegexOptions.IgnoreCase|RegexOptions.Singleline, context.RegexTimeOut);
#endif

            return stripHtml.Replace(text, string.Empty);
        }

#if !PCL328
        /// <summary>
        /// Escapes a HTML input string (replacing `&amp;` by `&amp;amp;`)
        /// </summary>
        /// <param name="text">The input string</param>
        /// <returns>The input string removed with any HTML tags</returns>
        /// <remarks>
        /// ```scriban-html
        /// {{ "&lt;p&gt;This is a paragraph&lt;/p&gt;" | html.escape }}
        /// ```
        /// ```html
        /// &amp;lt;p&amp;gt;This is a paragraph&amp;lt;/p&amp;gt;
        /// ```
        /// </remarks>
        public static string Escape(string text) {
            if (string.IsNullOrEmpty(text)) {
                return text;
            }
#if NET35
            return System.Web.HttpUtility.HtmlEncode(text);
#else
            return System.Net.WebUtility.HtmlEncode(text);
#endif
        }

        /// <summary>
        /// Converts any URL-unsafe characters in a string into percent-encoded characters.
        /// </summary>
        /// <param name="text">The input string</param>
        /// <returns>The input string url encoded</returns>
        /// <remarks>
        /// ```scriban-html
        /// {{ "john@liquid.com" | html.url_encode }}
        /// ```
        /// ```html
        /// john%40liquid.com
        /// ```
        /// </remarks>
        public static string UrlEncode(string text) {
            if (string.IsNullOrEmpty(text)) {
                return text;
            }
            return Uri.EscapeDataString(text);
        }

        /// <summary>
        /// Identifies all characters in a string that are not allowed in URLS, and replaces the characters with their escaped variants.
        /// </summary>
        /// <param name="text">The input string</param>
        /// <returns>The input string url escaped</returns>
        /// <remarks>
        /// ```scriban-html
        /// {{ "&lt;hello&gt; &amp; &lt;scriban&gt;" | html.url_escape }}
        /// ```
        /// ```html
        /// %3Chello%3E%20&amp;%20%3Cscriban%3E
        /// ```
        /// </remarks>
        public static string UrlEscape(string text) {
            if (string.IsNullOrEmpty(text)) {
                return text;
            }
            return Uri.EscapeUriString(text);
        }
#else

        public static string Escape(string text) {
            throw new NotSupportedException("This method is not supported by this .NET profile");
        }
        
        public static string UrlEncode(string text) {
            throw new NotSupportedException("This method is not supported by this .NET profile");
        }

        public static string UrlEscape(string text) {
            throw new NotSupportedException("This method is not supported by this .NET profile");
        }
#endif
    }
}