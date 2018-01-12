namespace antlr
{
	internal class CommonHiddenStreamToken : CommonToken, IHiddenStreamToken, IToken
	{
		internal class CommonHiddenStreamTokenCreator : TokenCreator
		{
			public override string TokenTypeName
			{
				get
				{
					return typeof(CommonHiddenStreamToken).FullName;
				}
			}

			public override IToken Create()
			{
				return new CommonHiddenStreamToken();
			}
		}

		public new static readonly CommonHiddenStreamTokenCreator Creator = new CommonHiddenStreamTokenCreator();

		protected internal IHiddenStreamToken hiddenBefore;

		protected internal IHiddenStreamToken hiddenAfter;

		public CommonHiddenStreamToken()
		{
		}

		public CommonHiddenStreamToken(int t, string txt)
			: base(t, txt)
		{
		}

		public CommonHiddenStreamToken(string s)
			: base(s)
		{
		}

		public virtual IHiddenStreamToken getHiddenAfter()
		{
			return this.hiddenAfter;
		}

		public virtual IHiddenStreamToken getHiddenBefore()
		{
			return this.hiddenBefore;
		}

		public virtual void setHiddenAfter(IHiddenStreamToken t)
		{
			this.hiddenAfter = t;
		}

		public virtual void setHiddenBefore(IHiddenStreamToken t)
		{
			this.hiddenBefore = t;
		}
	}
}
