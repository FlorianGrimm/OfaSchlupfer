namespace antlr
{
	internal interface IHiddenStreamToken : IToken
	{
		IHiddenStreamToken getHiddenAfter();

		void setHiddenAfter(IHiddenStreamToken t);

		IHiddenStreamToken getHiddenBefore();

		void setHiddenBefore(IHiddenStreamToken t);
	}
}
