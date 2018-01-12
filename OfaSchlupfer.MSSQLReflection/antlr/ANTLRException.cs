using System;
using System.Runtime.Serialization;

namespace antlr
{
	[System.Serializable]
	internal class ANTLRException : Exception
	{
		public ANTLRException()
		{
		}

		public ANTLRException(string s)
			: base(s)
		{
		}

		public ANTLRException(string s, Exception inner)
			: base(s, inner)
		{
		}

		protected ANTLRException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
