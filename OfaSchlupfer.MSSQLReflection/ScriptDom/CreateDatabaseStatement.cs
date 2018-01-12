using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom
{
	[System.Serializable]
	public sealed class CreateDatabaseStatement : TSqlStatement, ICollationSetter
	{
		private Identifier _databaseName;

		private ContainmentDatabaseOption _containment;

		private List<FileGroupDefinition> _fileGroups = new List<FileGroupDefinition>();

		private List<FileDeclaration> _logOn = new List<FileDeclaration>();

		private List<DatabaseOption> _options = new List<DatabaseOption>();

		private AttachMode _attachMode;

		private Identifier _databaseSnapshot;

		private MultiPartIdentifier _copyOf;

		private Identifier _collation;

		public Identifier DatabaseName
		{
			get
			{
				return this._databaseName;
			}
			set
			{
				base.UpdateTokenInfo(value);
				this._databaseName = value;
			}
		}

		public ContainmentDatabaseOption Containment
		{
			get
			{
				return this._containment;
			}
			set
			{
				base.UpdateTokenInfo(value);
				this._containment = value;
			}
		}

		public List<FileGroupDefinition> FileGroups
		{
			get
			{
				return this._fileGroups;
			}
		}

		public List<FileDeclaration> LogOn
		{
			get
			{
				return this._logOn;
			}
		}

		public List<DatabaseOption> Options
		{
			get
			{
				return this._options;
			}
		}

		public AttachMode AttachMode
		{
			get
			{
				return this._attachMode;
			}
			set
			{
				this._attachMode = value;
			}
		}

		public Identifier DatabaseSnapshot
		{
			get
			{
				return this._databaseSnapshot;
			}
			set
			{
				base.UpdateTokenInfo(value);
				this._databaseSnapshot = value;
			}
		}

		public MultiPartIdentifier CopyOf
		{
			get
			{
				return this._copyOf;
			}
			set
			{
				base.UpdateTokenInfo(value);
				this._copyOf = value;
			}
		}

		public Identifier Collation
		{
			get
			{
				return this._collation;
			}
			set
			{
				base.UpdateTokenInfo(value);
				this._collation = value;
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
			if (this.DatabaseName != null)
			{
				this.DatabaseName.Accept(visitor);
			}
			if (this.Containment != null)
			{
				this.Containment.Accept(visitor);
			}
			int i = 0;
			for (int count = this.FileGroups.Count; i < count; i++)
			{
				this.FileGroups[i].Accept(visitor);
			}
			int j = 0;
			for (int count2 = this.LogOn.Count; j < count2; j++)
			{
				this.LogOn[j].Accept(visitor);
			}
			int k = 0;
			for (int count3 = this.Options.Count; k < count3; k++)
			{
				this.Options[k].Accept(visitor);
			}
			if (this.DatabaseSnapshot != null)
			{
				this.DatabaseSnapshot.Accept(visitor);
			}
			if (this.CopyOf != null)
			{
				this.CopyOf.Accept(visitor);
			}
			if (this.Collation != null)
			{
				this.Collation.Accept(visitor);
			}
			base.AcceptChildren(visitor);
		}
	}
}
