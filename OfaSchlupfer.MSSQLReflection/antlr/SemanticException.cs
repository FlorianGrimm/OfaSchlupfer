using System;
using System.Runtime.Serialization;

namespace antlr
{
	[System.Serializable]
	internal class SemanticException : RecognitionException
	{
		public SemanticException(string s)
			: base(s)
		{
		}

		public SemanticException(string s, string fileName, int line, int column)
			: base(s, fileName, line, column)
		{
		}

		protected SemanticException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
