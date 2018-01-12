using System;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public sealed class ExecuteParameter : TSqlFragment
	{
		private VariableReference _variable;

		private ScalarExpression _parameterValue;

		private bool _isOutput;

		public VariableReference Variable
		{
			get
			{
				return this._variable;
			}
			set
			{
				this.UpdateTokenInfo(value);
				this._variable = value;
			}
		}

		public ScalarExpression ParameterValue
		{
			get
			{
				return this._parameterValue;
			}
			set
			{
				this.UpdateTokenInfo(value);
				this._parameterValue = value;
			}
		}

		public bool IsOutput
		{
			get
			{
				return this._isOutput;
			}
			set
			{
				this._isOutput = value;
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
			if (this.Variable != null)
			{
				this.Variable.Accept(visitor);
			}
			if (this.ParameterValue != null)
			{
				this.ParameterValue.Accept(visitor);
			}
			base.AcceptChildren(visitor);
		}
	}
}
