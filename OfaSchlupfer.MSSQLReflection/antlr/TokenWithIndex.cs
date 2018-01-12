namespace antlr
{
	internal class TokenWithIndex : CommonToken
	{
		private int index;

		public TokenWithIndex()
		{
		}

		public TokenWithIndex(int i, string t)
			: base(i, t)
		{
		}

		public void setIndex(int i)
		{
			this.index = i;
		}

		public int getIndex()
		{
			return this.index;
		}

		public override string ToString()
		{
			return "[" + this.index + ":\"" + this.getText() + "\",<" + base.Type + ">,line=" + base.line + ",col=" + base.col + "]\n";
		}
	}
}
