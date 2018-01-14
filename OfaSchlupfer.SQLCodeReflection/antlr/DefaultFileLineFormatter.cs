#pragma warning disable SA1600 // Elements must be documented
#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1300 // Element must begin with upper-case letter
#pragma warning disable SA1602 // Enumeration items must be documented
namespace antlr {
    using System.Text;

    internal class DefaultFileLineFormatter : FileLineFormatter {
        public override string getFormatString(string fileName, int line, int column) {
            StringBuilder stringBuilder = new StringBuilder();
            if (fileName != null) {
                stringBuilder.Append(fileName + ":");
            }
            if (line != -1) {
                if (fileName == null) {
                    stringBuilder.Append("line ");
                }
                stringBuilder.Append(line);
                if (column != -1) {
                    stringBuilder.Append(":" + column);
                }
                stringBuilder.Append(":");
            }
            stringBuilder.Append(" ");
            return stringBuilder.ToString();
        }
    }
}
