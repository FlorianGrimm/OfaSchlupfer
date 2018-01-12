using System;
using System.Runtime.Serialization;

namespace antlr
{
	[System.Serializable]
	internal class TokenStreamRetryException : TokenStreamException
	{
		public TokenStreamRetryException()
		{
		}

		protected TokenStreamRetryException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
