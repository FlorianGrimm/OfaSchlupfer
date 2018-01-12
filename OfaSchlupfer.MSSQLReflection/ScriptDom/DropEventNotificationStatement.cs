using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public sealed class DropEventNotificationStatement : TSqlStatement
	{
		private List<Identifier> _notifications = new List<Identifier>();

		private EventNotificationObjectScope _scope;

		public List<Identifier> Notifications
		{
			get
			{
				return this._notifications;
			}
		}

		public EventNotificationObjectScope Scope
		{
			get
			{
				return this._scope;
			}
			set
			{
				base.UpdateTokenInfo(value);
				this._scope = value;
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
			for (int count = this.Notifications.Count; i < count; i++)
			{
				this.Notifications[i].Accept(visitor);
			}
			if (this.Scope != null)
			{
				this.Scope.Accept(visitor);
			}
			base.AcceptChildren(visitor);
		}
	}
}
