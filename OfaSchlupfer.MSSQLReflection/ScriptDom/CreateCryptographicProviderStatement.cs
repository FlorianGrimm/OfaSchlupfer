using System;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public sealed class CreateCryptographicProviderStatement : TSqlStatement
	{
		private Identifier _name;

		private Literal _file;

		public Identifier Name
		{
			get
			{
				return this._name;
			}
			set
			{
				this.UpdateTokenInfo(value);
				this._name = value;
			}
		}

		public Literal File
		{
			get
			{
				return this._file;
			}
			set
			{
				this.UpdateTokenInfo(value);
				this._file = value;
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
			if (this.Name != null)
			{
				this.Name.Accept(visitor);
			}
			if (this.File != null)
			{
				this.File.Accept(visitor);
			}
			base.AcceptChildren(visitor);
		}
	}
}
