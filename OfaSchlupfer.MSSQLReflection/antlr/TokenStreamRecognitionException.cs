using System;
using System.Runtime.Serialization;

namespace antlr
{
	[System.Serializable]
	internal class TokenStreamRecognitionException : TokenStreamException
	{
		public RecognitionException recog;

		public TokenStreamRecognitionException(RecognitionException re)
			: base(re.Message)
		{
			this.recog = re;
		}

		protected TokenStreamRecognitionException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}

		public override string ToString()
		{
			return this.recog.ToString();
		}
	}
}
