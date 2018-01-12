using System;
using System.Runtime.Serialization;

namespace antlr
{
	[System.Serializable]
	internal class TokenStreamException : ANTLRException
	{
		public TokenStreamException()
		{
		}

		public TokenStreamException(string s)
			: base(s)
		{
		}

		protected TokenStreamException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
