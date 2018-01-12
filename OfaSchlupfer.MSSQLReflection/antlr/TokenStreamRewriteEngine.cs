using antlr.collections.impl;
using System.Collections;
using System.Text;

namespace antlr
{
	internal class TokenStreamRewriteEngine : TokenStream
	{
		protected class RewriteOperation
		{
			protected internal int index;

			protected internal string text;

			protected RewriteOperation(int index, string text)
			{
				this.index = index;
				this.text = text;
			}

			public virtual int execute(StringBuilder buf)
			{
				return this.index;
			}
		}

		protected class InsertBeforeOp : RewriteOperation
		{
			public InsertBeforeOp(int index, string text)
				: base(index, text)
			{
			}

			public override int execute(StringBuilder buf)
			{
				buf.Append(base.text);
				return base.index;
			}
		}

		protected class ReplaceOp : RewriteOperation
		{
			protected int lastIndex;

			public ReplaceOp(int from, int to, string text)
				: base(from, text)
			{
				this.lastIndex = to;
			}

			public override int execute(StringBuilder buf)
			{
				if (base.text != null)
				{
					buf.Append(base.text);
				}
				return this.lastIndex + 1;
			}
		}

		protected class DeleteOp : ReplaceOp
		{
			public DeleteOp(int from, int to)
				: base(from, to, null)
			{
			}
		}

		internal class RewriteOperationComparer : IComparer
		{
			public static readonly RewriteOperationComparer Default = new RewriteOperationComparer();

			public virtual int Compare(object o1, object o2)
			{
				RewriteOperation rewriteOperation = (RewriteOperation)o1;
				RewriteOperation rewriteOperation2 = (RewriteOperation)o2;
				if (rewriteOperation.index < rewriteOperation2.index)
				{
					return -1;
				}
				if (rewriteOperation.index > rewriteOperation2.index)
				{
					return 1;
				}
				return 0;
			}
		}

		public const int MIN_TOKEN_INDEX = 0;

		public const string DEFAULT_PROGRAM_NAME = "default";

		public const int PROGRAM_INIT_SIZE = 100;

		protected IList tokens;

		protected IDictionary programs;

		protected IDictionary lastRewriteTokenIndexes;

		protected int _index;

		protected TokenStream stream;

		protected BitSet discardMask = new BitSet();

		public TokenStreamRewriteEngine(TokenStream upstream)
			: this(upstream, 1000)
		{
		}

		public TokenStreamRewriteEngine(TokenStream upstream, int initialSize)
		{
			this.stream = upstream;
			this.tokens = new ArrayList(initialSize);
			this.programs = new Hashtable();
			this.programs["default"] = new ArrayList(100);
			this.lastRewriteTokenIndexes = new Hashtable();
		}

		public IToken nextToken()
		{
			TokenWithIndex tokenWithIndex;
			do
			{
				tokenWithIndex = (TokenWithIndex)this.stream.nextToken();
				if (tokenWithIndex != null)
				{
					tokenWithIndex.setIndex(this._index);
					if (tokenWithIndex.Type != 1)
					{
						this.tokens.Add(tokenWithIndex);
					}
					this._index++;
				}
			}
			while (tokenWithIndex != null && this.discardMask.member(tokenWithIndex.Type));
			return tokenWithIndex;
		}

		public void rollback(int instructionIndex)
		{
			this.rollback("default", instructionIndex);
		}

		public void rollback(string programName, int instructionIndex)
		{
			ArrayList arrayList = (ArrayList)this.programs[programName];
			if (arrayList != null)
			{
				this.programs[programName] = arrayList.GetRange(0, instructionIndex);
			}
		}

		public void deleteProgram()
		{
			this.deleteProgram("default");
		}

		public void deleteProgram(string programName)
		{
			this.rollback(programName, 0);
		}

		protected void addToSortedRewriteList(RewriteOperation op)
		{
			this.addToSortedRewriteList("default", op);
		}

		protected void addToSortedRewriteList(string programName, RewriteOperation op)
		{
			ArrayList arrayList = (ArrayList)this.getProgram(programName);
			if (op.index >= this.getLastRewriteTokenIndex(programName))
			{
				arrayList.Add(op);
				this.setLastRewriteTokenIndex(programName, op.index);
			}
			else
			{
				int num = arrayList.BinarySearch(op, RewriteOperationComparer.Default);
				if (num < 0)
				{
					arrayList.Insert(-num - 1, op);
				}
			}
		}

		public void insertAfter(IToken t, string text)
		{
			this.insertAfter("default", t, text);
		}

		public void insertAfter(int index, string text)
		{
			this.insertAfter("default", index, text);
		}

		public void insertAfter(string programName, IToken t, string text)
		{
			this.insertAfter(programName, ((TokenWithIndex)t).getIndex(), text);
		}

		public void insertAfter(string programName, int index, string text)
		{
			this.insertBefore(programName, index + 1, text);
		}

		public void insertBefore(IToken t, string text)
		{
			this.insertBefore("default", t, text);
		}

		public void insertBefore(int index, string text)
		{
			this.insertBefore("default", index, text);
		}

		public void insertBefore(string programName, IToken t, string text)
		{
			this.insertBefore(programName, ((TokenWithIndex)t).getIndex(), text);
		}

		public void insertBefore(string programName, int index, string text)
		{
			this.addToSortedRewriteList(programName, new InsertBeforeOp(index, text));
		}

		public void replace(int index, string text)
		{
			this.replace("default", index, index, text);
		}

		public void replace(int from, int to, string text)
		{
			this.replace("default", from, to, text);
		}

		public void replace(IToken indexT, string text)
		{
			this.replace("default", indexT, indexT, text);
		}

		public void replace(IToken from, IToken to, string text)
		{
			this.replace("default", from, to, text);
		}

		public void replace(string programName, int from, int to, string text)
		{
			this.addToSortedRewriteList(programName, new ReplaceOp(from, to, text));
		}

		public void replace(string programName, IToken from, IToken to, string text)
		{
			this.replace(programName, ((TokenWithIndex)from).getIndex(), ((TokenWithIndex)to).getIndex(), text);
		}

		public void delete(int index)
		{
			this.delete("default", index, index);
		}

		public void delete(int from, int to)
		{
			this.delete("default", from, to);
		}

		public void delete(IToken indexT)
		{
			this.delete("default", indexT, indexT);
		}

		public void delete(IToken from, IToken to)
		{
			this.delete("default", from, to);
		}

		public void delete(string programName, int from, int to)
		{
			this.replace(programName, from, to, null);
		}

		public void delete(string programName, IToken from, IToken to)
		{
			this.replace(programName, from, to, null);
		}

		public void discard(int ttype)
		{
			this.discardMask.add(ttype);
		}

		public TokenWithIndex getToken(int i)
		{
			return (TokenWithIndex)this.tokens[i];
		}

		public int getTokenStreamSize()
		{
			return this.tokens.Count;
		}

		public string ToOriginalString()
		{
			return this.ToOriginalString(0, this.getTokenStreamSize() - 1);
		}

		public string ToOriginalString(int start, int end)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = start; i >= 0 && i <= end && i < this.tokens.Count; i++)
			{
				stringBuilder.Append(this.getToken(i).getText());
			}
			return stringBuilder.ToString();
		}

		public override string ToString()
		{
			return this.ToString(0, this.getTokenStreamSize());
		}

		public string ToString(string programName)
		{
			return this.ToString(programName, 0, this.getTokenStreamSize());
		}

		public string ToString(int start, int end)
		{
			return this.ToString("default", start, end);
		}

		public string ToString(string programName, int start, int end)
		{
			IList list = (IList)this.programs[programName];
			if (list == null)
			{
				return null;
			}
			StringBuilder stringBuilder = new StringBuilder();
			int num = 0;
			int num2 = start;
			while (num2 >= 0 && num2 <= end && num2 < this.tokens.Count)
			{
				if (num < list.Count)
				{
					RewriteOperation rewriteOperation = (RewriteOperation)list[num];
					while (num2 == rewriteOperation.index && num < list.Count)
					{
						num2 = rewriteOperation.execute(stringBuilder);
						num++;
						if (num < list.Count)
						{
							rewriteOperation = (RewriteOperation)list[num];
						}
					}
				}
				if (num2 < end)
				{
					stringBuilder.Append(this.getToken(num2).getText());
					num2++;
				}
			}
			for (int i = num; i < list.Count; i++)
			{
				RewriteOperation rewriteOperation2 = (RewriteOperation)list[i];
				rewriteOperation2.execute(stringBuilder);
			}
			return stringBuilder.ToString();
		}

		public string ToDebugString()
		{
			return this.ToDebugString(0, this.getTokenStreamSize());
		}

		public string ToDebugString(int start, int end)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = start; i >= 0 && i <= end && i < this.tokens.Count; i++)
			{
				stringBuilder.Append(this.getToken(i));
			}
			return stringBuilder.ToString();
		}

		public int getLastRewriteTokenIndex()
		{
			return this.getLastRewriteTokenIndex("default");
		}

		protected int getLastRewriteTokenIndex(string programName)
		{
			object obj = this.lastRewriteTokenIndexes[programName];
			if (obj == null)
			{
				return -1;
			}
			return (int)obj;
		}

		protected void setLastRewriteTokenIndex(string programName, int i)
		{
			this.lastRewriteTokenIndexes[programName] = i;
		}

		protected IList getProgram(string name)
		{
			IList list = (IList)this.programs[name];
			if (list == null)
			{
				list = this.initializeProgram(name);
			}
			return list;
		}

		private IList initializeProgram(string name)
		{
			IList list = new ArrayList(100);
			this.programs[name] = list;
			return list;
		}
	}
}
