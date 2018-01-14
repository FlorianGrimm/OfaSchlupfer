#pragma warning disable SA1600 // Elements must be documented
#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1300 // Element must begin with upper-case letter
#pragma warning disable SA1602 // Enumeration items must be documented
namespace antlr {
    internal abstract class FileLineFormatter {
        private static FileLineFormatter formatter = new DefaultFileLineFormatter();

        public static FileLineFormatter getFormatter() {
            return FileLineFormatter.formatter;
        }

        public static void setFormatter(FileLineFormatter f) {
            FileLineFormatter.formatter = f;
        }

        public abstract string getFormatString(string fileName, int line, int column);
    }
}
