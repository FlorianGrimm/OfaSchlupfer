namespace antlr
{
	internal class ParserSharedInputState
	{
		protected internal TokenBuffer input;

		public int guessing;

		protected internal string filename;

		public virtual void reset()
		{
			this.guessing = 0;
			this.filename = null;
			this.input.reset();
		}
	}
}
