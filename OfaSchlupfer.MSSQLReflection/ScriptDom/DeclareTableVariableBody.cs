using System;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public sealed class DeclareTableVariableBody : TSqlFragment
	{
		private Identifier _variableName;

		private bool _asDefined;

		private TableDefinition _definition;

		public Identifier VariableName
		{
			get
			{
				return this._variableName;
			}
			set
			{
				base.UpdateTokenInfo(value);
				this._variableName = value;
			}
		}

		public bool AsDefined
		{
			get
			{
				return this._asDefined;
			}
			set
			{
				this._asDefined = value;
			}
		}

		public TableDefinition Definition
		{
			get
			{
				return this._definition;
			}
			set
			{
				base.UpdateTokenInfo(value);
				this._definition = value;
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
			if (this.VariableName != null)
			{
				this.VariableName.Accept(visitor);
			}
			if (this.Definition != null)
			{
				this.Definition.Accept(visitor);
			}
			base.AcceptChildren(visitor);
		}
	}
}
