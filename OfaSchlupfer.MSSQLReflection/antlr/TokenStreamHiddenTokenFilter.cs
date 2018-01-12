using antlr.collections.impl;

namespace antlr
{
	internal class TokenStreamHiddenTokenFilter : TokenStreamBasicFilter, TokenStream
	{
		protected internal BitSet hideMask;

		private IHiddenStreamToken nextMonitoredToken;

		protected internal IHiddenStreamToken lastHiddenToken;

		protected internal IHiddenStreamToken firstHidden;

		public TokenStreamHiddenTokenFilter(TokenStream input)
			: base(input)
		{
			this.hideMask = new BitSet();
		}

		protected internal virtual void consume()
		{
			this.nextMonitoredToken = (IHiddenStreamToken)base.input.nextToken();
		}

		private void consumeFirst()
		{
			this.consume();
			IHiddenStreamToken hiddenStreamToken = null;
			while (true)
			{
				if (!this.hideMask.member(this.LA(1).Type) && !base.discardMask.member(this.LA(1).Type))
				{
					break;
				}
				if (this.hideMask.member(this.LA(1).Type))
				{
					if (hiddenStreamToken == null)
					{
						hiddenStreamToken = this.LA(1);
					}
					else
					{
						hiddenStreamToken.setHiddenAfter(this.LA(1));
						this.LA(1).setHiddenBefore(hiddenStreamToken);
						hiddenStreamToken = this.LA(1);
					}
					this.lastHiddenToken = hiddenStreamToken;
					if (this.firstHidden == null)
					{
						this.firstHidden = hiddenStreamToken;
					}
				}
				this.consume();
			}
		}

		public virtual BitSet getDiscardMask()
		{
			return base.discardMask;
		}

		public virtual IHiddenStreamToken getHiddenAfter(IHiddenStreamToken t)
		{
			return t.getHiddenAfter();
		}

		public virtual IHiddenStreamToken getHiddenBefore(IHiddenStreamToken t)
		{
			return t.getHiddenBefore();
		}

		public virtual BitSet getHideMask()
		{
			return this.hideMask;
		}

		public virtual IHiddenStreamToken getInitialHiddenToken()
		{
			return this.firstHidden;
		}

		public virtual void hide(int m)
		{
			this.hideMask.add(m);
		}

		public virtual void hide(BitSet mask)
		{
			this.hideMask = mask;
		}

		protected internal virtual IHiddenStreamToken LA(int i)
		{
			return this.nextMonitoredToken;
		}

		public override IToken nextToken()
		{
			if (this.LA(1) == null)
			{
				this.consumeFirst();
			}
			IHiddenStreamToken hiddenStreamToken = this.LA(1);
			hiddenStreamToken.setHiddenBefore(this.lastHiddenToken);
			this.lastHiddenToken = null;
			this.consume();
			IHiddenStreamToken hiddenStreamToken2 = hiddenStreamToken;
			while (true)
			{
				if (!this.hideMask.member(this.LA(1).Type) && !base.discardMask.member(this.LA(1).Type))
				{
					break;
				}
				if (this.hideMask.member(this.LA(1).Type))
				{
					hiddenStreamToken2.setHiddenAfter(this.LA(1));
					if (hiddenStreamToken2 != hiddenStreamToken)
					{
						this.LA(1).setHiddenBefore(hiddenStreamToken2);
					}
					hiddenStreamToken2 = (this.lastHiddenToken = this.LA(1));
				}
				this.consume();
			}
			return hiddenStreamToken;
		}

		public virtual void resetState()
		{
			this.firstHidden = null;
			this.lastHiddenToken = null;
			this.nextMonitoredToken = null;
		}
	}
}
