using System;
using System.Runtime.Serialization;

namespace antlr
{
	[System.Serializable]
	internal class NoViableAltException : RecognitionException
	{
		public IToken token;

		public override string Message
		{
			get
			{
				if (this.token != null)
				{
					return "unexpected token: " + this.token.ToString();
				}
				return "unexpected token: (null)";
			}
		}

		public NoViableAltException(IToken t, string fileName_)
			: base("NoViableAlt", fileName_, t.getLine(), t.getColumn())
		{
			this.token = t;
		}

		protected NoViableAltException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
