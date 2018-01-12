using System;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public sealed class DataTypeSequenceOption : SequenceOption
	{
		private DataTypeReference _dataType;

		public DataTypeReference DataType
		{
			get
			{
				return this._dataType;
			}
			set
			{
				base.UpdateTokenInfo(value);
				this._dataType = value;
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
			base.AcceptChildren(visitor);
			if (this.DataType != null)
			{
				this.DataType.Accept(visitor);
			}
		}
	}
}
