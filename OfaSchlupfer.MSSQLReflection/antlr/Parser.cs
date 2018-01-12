using antlr.collections.impl;
using System;

namespace antlr
{
	internal abstract class Parser
	{
		internal static readonly object EnterRuleEventKey = new object();

		internal static readonly object ExitRuleEventKey = new object();

		internal static readonly object DoneEventKey = new object();

		internal static readonly object ReportErrorEventKey = new object();

		internal static readonly object ReportWarningEventKey = new object();

		internal static readonly object NewLineEventKey = new object();

		internal static readonly object MatchEventKey = new object();

		internal static readonly object MatchNotEventKey = new object();

		internal static readonly object MisMatchEventKey = new object();

		internal static readonly object MisMatchNotEventKey = new object();

		internal static readonly object ConsumeEventKey = new object();

		internal static readonly object LAEventKey = new object();

		internal static readonly object SemPredEvaluatedEventKey = new object();

		internal static readonly object SynPredStartedEventKey = new object();

		internal static readonly object SynPredFailedEventKey = new object();

		internal static readonly object SynPredSucceededEventKey = new object();

		protected internal ParserSharedInputState inputState;

		protected internal string[] tokenNames;

		private bool ignoreInvalidDebugCalls;

		protected internal int traceDepth;

		public Parser()
		{
			this.inputState = new ParserSharedInputState();
		}

		public Parser(ParserSharedInputState state)
		{
			this.inputState = state;
		}

		public abstract void consume();

		public virtual void consumeUntil(int tokenType)
		{
			while (this.LA(1) != 1 && this.LA(1) != tokenType)
			{
				this.consume();
			}
		}

		public virtual void consumeUntil(BitSet bset)
		{
			while (this.LA(1) != 1 && !bset.member(this.LA(1)))
			{
				this.consume();
			}
		}

		protected internal virtual void defaultDebuggingSetup(TokenStream lexer, TokenBuffer tokBuf)
		{
		}

		public virtual string getFilename()
		{
			return this.inputState.filename;
		}

		public virtual ParserSharedInputState getInputState()
		{
			return this.inputState;
		}

		public virtual void setInputState(ParserSharedInputState state)
		{
			this.inputState = state;
		}

		public virtual void resetState()
		{
			this.traceDepth = 0;
			this.inputState.reset();
		}

		public virtual string getTokenName(int num)
		{
			return this.tokenNames[num];
		}

		public virtual string[] getTokenNames()
		{
			return this.tokenNames;
		}

		public virtual bool isDebugMode()
		{
			return false;
		}

		public abstract int LA(int i);

		public abstract IToken LT(int i);

		public virtual int mark()
		{
			return this.inputState.input.mark();
		}

		public virtual void match(int t)
		{
			if (this.LA(1) != t)
			{
				throw new MismatchedTokenException(this.tokenNames, this.LT(1), t, false, this.getFilename());
			}
			this.consume();
		}

		public virtual void match(BitSet b)
		{
			if (!b.member(this.LA(1)))
			{
				throw new MismatchedTokenException(this.tokenNames, this.LT(1), b, false, this.getFilename());
			}
			this.consume();
		}

		public virtual void matchNot(int t)
		{
			if (this.LA(1) == t)
			{
				throw new MismatchedTokenException(this.tokenNames, this.LT(1), t, true, this.getFilename());
			}
			this.consume();
		}

		public virtual void reportError(RecognitionException ex)
		{
			Console.Error.WriteLine(ex);
		}

		public virtual void reportError(string s)
		{
			if (this.getFilename() == null)
			{
				Console.Error.WriteLine("error: " + s);
			}
			else
			{
				Console.Error.WriteLine(this.getFilename() + ": error: " + s);
			}
		}

		public virtual void reportWarning(string s)
		{
			if (this.getFilename() == null)
			{
				Console.Error.WriteLine("warning: " + s);
			}
			else
			{
				Console.Error.WriteLine(this.getFilename() + ": warning: " + s);
			}
		}

		public virtual void recover(RecognitionException ex, BitSet tokenSet)
		{
			this.consume();
			this.consumeUntil(tokenSet);
		}

		public virtual void rewind(int pos)
		{
			this.inputState.input.rewind(pos);
		}

		public virtual void setDebugMode(bool debugMode)
		{
			if (this.ignoreInvalidDebugCalls)
			{
				return;
			}
			throw new ANTLRException("setDebugMode() only valid if parser built for debugging");
		}

		public virtual void setFilename(string f)
		{
			this.inputState.filename = f;
		}

		public virtual void setIgnoreInvalidDebugCalls(bool Value)
		{
			this.ignoreInvalidDebugCalls = Value;
		}

		public virtual void setTokenBuffer(TokenBuffer t)
		{
			this.inputState.input = t;
		}

		public virtual void traceIndent()
		{
			for (int i = 0; i < this.traceDepth; i++)
			{
				Console.Out.Write(" ");
			}
		}

		public virtual void traceIn(string rname)
		{
			this.traceDepth++;
			this.traceIndent();
			Console.Out.WriteLine("> " + rname + "; LA(1)==" + this.LT(1).getText() + ((this.inputState.guessing > 0) ? " [guessing]" : ""));
		}

		public virtual void traceOut(string rname)
		{
			this.traceIndent();
			Console.Out.WriteLine("< " + rname + "; LA(1)==" + this.LT(1).getText() + ((this.inputState.guessing > 0) ? " [guessing]" : ""));
			this.traceDepth--;
		}
	}
}
