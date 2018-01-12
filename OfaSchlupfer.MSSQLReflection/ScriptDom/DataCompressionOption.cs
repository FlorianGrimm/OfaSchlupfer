using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public sealed class DataCompressionOption : IndexOption
	{
		private DataCompressionLevel _compressionLevel;

		private List<CompressionPartitionRange> _partitionRanges = new List<CompressionPartitionRange>();

		public DataCompressionLevel CompressionLevel
		{
			get
			{
				return this._compressionLevel;
			}
			set
			{
				this._compressionLevel = value;
			}
		}

		public List<CompressionPartitionRange> PartitionRanges
		{
			get
			{
				return this._partitionRanges;
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
			int i = 0;
			for (int count = this.PartitionRanges.Count; i < count; i++)
			{
				this.PartitionRanges[i].Accept(visitor);
			}
		}
	}
}
