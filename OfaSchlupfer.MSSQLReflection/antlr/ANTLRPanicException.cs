using System;
using System.Runtime.Serialization;

namespace antlr
{
	[System.Serializable]
	internal class ANTLRPanicException : ANTLRException
	{
		public ANTLRPanicException()
		{
		}

		public ANTLRPanicException(string s)
			: base(s)
		{
		}

		public ANTLRPanicException(string s, Exception inner)
			: base(s, inner)
		{
		}

		protected ANTLRPanicException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
