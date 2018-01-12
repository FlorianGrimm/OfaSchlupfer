using System;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public sealed class ExecuteSpecification : TSqlFragment
	{
		private VariableReference _variable;

		private Identifier _linkedServer;

		private ExecuteContext _executeContext;

		private ExecutableEntity _executableEntity;

		public VariableReference Variable
		{
			get
			{
				return this._variable;
			}
			set
			{
				base.UpdateTokenInfo(value);
				this._variable = value;
			}
		}

		public Identifier LinkedServer
		{
			get
			{
				return this._linkedServer;
			}
			set
			{
				base.UpdateTokenInfo(value);
				this._linkedServer = value;
			}
		}

		public ExecuteContext ExecuteContext
		{
			get
			{
				return this._executeContext;
			}
			set
			{
				base.UpdateTokenInfo(value);
				this._executeContext = value;
			}
		}

		public ExecutableEntity ExecutableEntity
		{
			get
			{
				return this._executableEntity;
			}
			set
			{
				base.UpdateTokenInfo(value);
				this._executableEntity = value;
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
			if (this.LinkedServer != null)
			{
				this.LinkedServer.Accept(visitor);
			}
			if (this.ExecuteContext != null)
			{
				this.ExecuteContext.Accept(visitor);
			}
			if (this.ExecutableEntity != null)
			{
				this.ExecutableEntity.Accept(visitor);
			}
			base.AcceptChildren(visitor);
		}
	}
}
