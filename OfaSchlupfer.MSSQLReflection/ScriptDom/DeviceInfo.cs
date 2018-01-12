using System;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public sealed class DeviceInfo : TSqlFragment
	{
		private IdentifierOrValueExpression _logicalDevice;

		private ValueExpression _physicalDevice;

		private DeviceType _deviceType;

		public IdentifierOrValueExpression LogicalDevice
		{
			get
			{
				return this._logicalDevice;
			}
			set
			{
				base.UpdateTokenInfo(value);
				this._logicalDevice = value;
			}
		}

		public ValueExpression PhysicalDevice
		{
			get
			{
				return this._physicalDevice;
			}
			set
			{
				base.UpdateTokenInfo(value);
				this._physicalDevice = value;
			}
		}

		public DeviceType DeviceType
		{
			get
			{
				return this._deviceType;
			}
			set
			{
				this._deviceType = value;
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
			if (this.LogicalDevice != null)
			{
				this.LogicalDevice.Accept(visitor);
			}
			if (this.PhysicalDevice != null)
			{
				this.PhysicalDevice.Accept(visitor);
			}
			base.AcceptChildren(visitor);
		}
	}
}
