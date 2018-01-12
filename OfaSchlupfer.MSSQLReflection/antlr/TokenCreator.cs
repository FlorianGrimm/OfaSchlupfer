namespace antlr
{
	internal abstract class TokenCreator
	{
		public abstract string TokenTypeName
		{
			get;
		}

		public abstract IToken Create();
	}
}
