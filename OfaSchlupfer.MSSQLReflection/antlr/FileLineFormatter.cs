namespace antlr
{
	internal abstract class FileLineFormatter
	{
		private static FileLineFormatter formatter = new DefaultFileLineFormatter();

		public static FileLineFormatter getFormatter()
		{
			return FileLineFormatter.formatter;
		}

		public static void setFormatter(FileLineFormatter f)
		{
			FileLineFormatter.formatter = f;
		}

		public abstract string getFormatString(string fileName, int line, int column);
	}
}
