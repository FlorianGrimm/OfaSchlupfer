using System;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text;

namespace antlr
{
	[System.Serializable]
	internal class NoViableAltForCharException : RecognitionException
	{
		public char foundChar;

		public override string Message
		{
			get
			{
				StringBuilder stringBuilder = new StringBuilder("unexpected char: ");
				if (this.foundChar >= ' ' && this.foundChar <= '~')
				{
					stringBuilder.Append('\'');
					stringBuilder.Append(this.foundChar);
					stringBuilder.Append('\'');
				}
				else
				{
					stringBuilder.Append("0x");
					StringBuilder stringBuilder2 = stringBuilder;
					int num = this.foundChar;
					stringBuilder2.Append(num.ToString("X", CultureInfo.InvariantCulture));
				}
				return stringBuilder.ToString();
			}
		}

		public NoViableAltForCharException(char c, CharScanner scanner)
			: base("NoViableAlt", scanner.getFilename(), scanner.getLine(), scanner.getColumn())
		{
			this.foundChar = c;
		}

		public NoViableAltForCharException(char c, string fileName, int line, int column)
			: base("NoViableAlt", fileName, line, column)
		{
			this.foundChar = c;
		}

		protected NoViableAltForCharException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
