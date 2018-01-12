using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public abstract class SymmetricKeyStatement : TSqlStatement
	{
		private Identifier _name;

		private List<CryptoMechanism> _encryptingMechanisms = new List<CryptoMechanism>();

		public Identifier Name
		{
			get
			{
				return this._name;
			}
			set
			{
				base.UpdateTokenInfo(value);
				this._name = value;
			}
		}

		public List<CryptoMechanism> EncryptingMechanisms
		{
			get
			{
				return this._encryptingMechanisms;
			}
		}

		public override void AcceptChildren(TSqlFragmentVisitor visitor)
		{
			if (this.Name != null)
			{
				this.Name.Accept(visitor);
			}
			int i = 0;
			for (int count = this.EncryptingMechanisms.Count; i < count; i++)
			{
				this.EncryptingMechanisms[i].Accept(visitor);
			}
			base.AcceptChildren(visitor);
		}
	}
}
