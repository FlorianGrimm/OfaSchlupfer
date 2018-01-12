using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public sealed class DbccStatement : TSqlStatement
	{
		private string _dllName;

		private DbccCommand _command;

		private bool _parenthesisRequired;

		private List<DbccNamedLiteral> _literals = new List<DbccNamedLiteral>();

		private List<DbccOption> _options = new List<DbccOption>();

		private bool _optionsUseJoin;

		public string DllName
		{
			get
			{
				return this._dllName;
			}
			set
			{
				this._dllName = value;
			}
		}

		public DbccCommand Command
		{
			get
			{
				return this._command;
			}
			set
			{
				this._command = value;
			}
		}

		public bool ParenthesisRequired
		{
			get
			{
				return this._parenthesisRequired;
			}
			set
			{
				this._parenthesisRequired = value;
			}
		}

		public List<DbccNamedLiteral> Literals
		{
			get
			{
				return this._literals;
			}
		}

		public List<DbccOption> Options
		{
			get
			{
				return this._options;
			}
		}

		public bool OptionsUseJoin
		{
			get
			{
				return this._optionsUseJoin;
			}
			set
			{
				this._optionsUseJoin = value;
			}
		}

		public override void Accept(TSqlFragmentVisitor visitor)
		{
			if (visitor != null)
			{
				visitor.ExplicitVisit(this);
			}
		}

		public override void AcceptChildren(TSqlFragmentVisitor visitor)
		{
			int i = 0;
			for (int count = this.Literals.Count; i < count; i++)
			{
				this.Literals[i].Accept(visitor);
			}
			int j = 0;
			for (int count2 = this.Options.Count; j < count2; j++)
			{
				this.Options[j].Accept(visitor);
			}
			base.AcceptChildren(visitor);
		}
	}
}
