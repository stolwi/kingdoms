﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.296
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SHKEntity
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="kingdoms")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertPlayer(Player instance);
    partial void UpdatePlayer(Player instance);
    partial void DeletePlayer(Player instance);
    partial void InsertWorld(World instance);
    partial void UpdateWorld(World instance);
    partial void DeleteWorld(World instance);
    partial void InsertVillage(Village instance);
    partial void UpdateVillage(Village instance);
    partial void DeleteVillage(Village instance);
    partial void InsertEdge(Edge instance);
    partial void UpdateEdge(Edge instance);
    partial void DeleteEdge(Edge instance);
    #endregion
		
		public DataClasses1DataContext() : 
				base(global::SHKEntity.Properties.Settings.Default.kingdomsConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Player> Players
		{
			get
			{
				return this.GetTable<Player>();
			}
		}
		
		public System.Data.Linq.Table<World> Worlds
		{
			get
			{
				return this.GetTable<World>();
			}
		}
		
		public System.Data.Linq.Table<Village> Villages
		{
			get
			{
				return this.GetTable<Village>();
			}
		}
		
		public System.Data.Linq.Table<Edge> Edges
		{
			get
			{
				return this.GetTable<Edge>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Player")]
	public partial class Player : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private EntitySet<Village> _Villages;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    #endregion
		
		public Player()
		{
			this._Villages = new EntitySet<Village>(new Action<Village>(this.attach_Villages), new Action<Village>(this.detach_Villages));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Player_Village", Storage="_Villages", ThisKey="Id", OtherKey="OwnerPlayerId")]
		public EntitySet<Village> Villages
		{
			get
			{
				return this._Villages;
			}
			set
			{
				this._Villages.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Villages(Village entity)
		{
			this.SendPropertyChanging();
			entity.Player = this;
		}
		
		private void detach_Villages(Village entity)
		{
			this.SendPropertyChanging();
			entity.Player = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.World")]
	public partial class World : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Name;
		
		private EntitySet<Village> _Villages;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    #endregion
		
		public World()
		{
			this._Villages = new EntitySet<Village>(new Action<Village>(this.attach_Villages), new Action<Village>(this.detach_Villages));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(50)")]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="World_Village", Storage="_Villages", ThisKey="Id", OtherKey="WorldId")]
		public EntitySet<Village> Villages
		{
			get
			{
				return this._Villages;
			}
			set
			{
				this._Villages.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Villages(Village entity)
		{
			this.SendPropertyChanging();
			entity.World = this;
		}
		
		private void detach_Villages(Village entity)
		{
			this.SendPropertyChanging();
			entity.World = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Village")]
	public partial class Village : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Name;
		
		private System.Nullable<double> _PosX;
		
		private System.Nullable<double> _PosY;
		
		private System.Nullable<int> _OwnerPlayerId;
		
		private int _Confidence;
		
		private int _WorldId;
		
		private EntitySet<Edge> _Edges;
		
		private EntitySet<Edge> _Edges1;
		
		private EntityRef<Player> _Player;
		
		private EntityRef<World> _World;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnPosXChanging(System.Nullable<double> value);
    partial void OnPosXChanged();
    partial void OnPosYChanging(System.Nullable<double> value);
    partial void OnPosYChanged();
    partial void OnOwnerPlayerIdChanging(System.Nullable<int> value);
    partial void OnOwnerPlayerIdChanged();
    partial void OnConfidenceChanging(int value);
    partial void OnConfidenceChanged();
    partial void OnWorldIdChanging(int value);
    partial void OnWorldIdChanged();
    #endregion
		
		public Village()
		{
			this._Edges = new EntitySet<Edge>(new Action<Edge>(this.attach_Edges), new Action<Edge>(this.detach_Edges));
			this._Edges1 = new EntitySet<Edge>(new Action<Edge>(this.attach_Edges1), new Action<Edge>(this.detach_Edges1));
			this._Player = default(EntityRef<Player>);
			this._World = default(EntityRef<World>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(128)")]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PosX", DbType="Float")]
		public System.Nullable<double> PosX
		{
			get
			{
				return this._PosX;
			}
			set
			{
				if ((this._PosX != value))
				{
					this.OnPosXChanging(value);
					this.SendPropertyChanging();
					this._PosX = value;
					this.SendPropertyChanged("PosX");
					this.OnPosXChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PosY", DbType="Float")]
		public System.Nullable<double> PosY
		{
			get
			{
				return this._PosY;
			}
			set
			{
				if ((this._PosY != value))
				{
					this.OnPosYChanging(value);
					this.SendPropertyChanging();
					this._PosY = value;
					this.SendPropertyChanged("PosY");
					this.OnPosYChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OwnerPlayerId", DbType="Int")]
		public System.Nullable<int> OwnerPlayerId
		{
			get
			{
				return this._OwnerPlayerId;
			}
			set
			{
				if ((this._OwnerPlayerId != value))
				{
					if (this._Player.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnOwnerPlayerIdChanging(value);
					this.SendPropertyChanging();
					this._OwnerPlayerId = value;
					this.SendPropertyChanged("OwnerPlayerId");
					this.OnOwnerPlayerIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Confidence", DbType="Int NOT NULL")]
		public int Confidence
		{
			get
			{
				return this._Confidence;
			}
			set
			{
				if ((this._Confidence != value))
				{
					this.OnConfidenceChanging(value);
					this.SendPropertyChanging();
					this._Confidence = value;
					this.SendPropertyChanged("Confidence");
					this.OnConfidenceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_WorldId", DbType="Int NOT NULL")]
		public int WorldId
		{
			get
			{
				return this._WorldId;
			}
			set
			{
				if ((this._WorldId != value))
				{
					if (this._World.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnWorldIdChanging(value);
					this.SendPropertyChanging();
					this._WorldId = value;
					this.SendPropertyChanged("WorldId");
					this.OnWorldIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Village_Edge", Storage="_Edges", ThisKey="Id", OtherKey="FromVillageId")]
		public EntitySet<Edge> Edges
		{
			get
			{
				return this._Edges;
			}
			set
			{
				this._Edges.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Village_Edge1", Storage="_Edges1", ThisKey="Id", OtherKey="ToVillageId")]
		public EntitySet<Edge> Edges1
		{
			get
			{
				return this._Edges1;
			}
			set
			{
				this._Edges1.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Player_Village", Storage="_Player", ThisKey="OwnerPlayerId", OtherKey="Id", IsForeignKey=true)]
		public Player Player
		{
			get
			{
				return this._Player.Entity;
			}
			set
			{
				Player previousValue = this._Player.Entity;
				if (((previousValue != value) 
							|| (this._Player.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Player.Entity = null;
						previousValue.Villages.Remove(this);
					}
					this._Player.Entity = value;
					if ((value != null))
					{
						value.Villages.Add(this);
						this._OwnerPlayerId = value.Id;
					}
					else
					{
						this._OwnerPlayerId = default(Nullable<int>);
					}
					this.SendPropertyChanged("Player");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="World_Village", Storage="_World", ThisKey="WorldId", OtherKey="Id", IsForeignKey=true)]
		public World World
		{
			get
			{
				return this._World.Entity;
			}
			set
			{
				World previousValue = this._World.Entity;
				if (((previousValue != value) 
							|| (this._World.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._World.Entity = null;
						previousValue.Villages.Remove(this);
					}
					this._World.Entity = value;
					if ((value != null))
					{
						value.Villages.Add(this);
						this._WorldId = value.Id;
					}
					else
					{
						this._WorldId = default(int);
					}
					this.SendPropertyChanged("World");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Edges(Edge entity)
		{
			this.SendPropertyChanging();
			entity.Village = this;
		}
		
		private void detach_Edges(Edge entity)
		{
			this.SendPropertyChanging();
			entity.Village = null;
		}
		
		private void attach_Edges1(Edge entity)
		{
			this.SendPropertyChanging();
			entity.Village1 = this;
		}
		
		private void detach_Edges1(Edge entity)
		{
			this.SendPropertyChanging();
			entity.Village1 = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Edge")]
	public partial class Edge : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private int _FromVillageId;
		
		private int _ToVillageId;
		
		private double _Time;
		
		private string _TimeType;
		
		private EntityRef<Village> _Village;
		
		private EntityRef<Village> _Village1;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnFromVillageIdChanging(int value);
    partial void OnFromVillageIdChanged();
    partial void OnToVillageIdChanging(int value);
    partial void OnToVillageIdChanged();
    partial void OnTimeChanging(double value);
    partial void OnTimeChanged();
    partial void OnTimeTypeChanging(string value);
    partial void OnTimeTypeChanged();
    #endregion
		
		public Edge()
		{
			this._Village = default(EntityRef<Village>);
			this._Village1 = default(EntityRef<Village>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FromVillageId", DbType="Int NOT NULL")]
		public int FromVillageId
		{
			get
			{
				return this._FromVillageId;
			}
			set
			{
				if ((this._FromVillageId != value))
				{
					if (this._Village.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnFromVillageIdChanging(value);
					this.SendPropertyChanging();
					this._FromVillageId = value;
					this.SendPropertyChanged("FromVillageId");
					this.OnFromVillageIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ToVillageId", DbType="Int NOT NULL")]
		public int ToVillageId
		{
			get
			{
				return this._ToVillageId;
			}
			set
			{
				if ((this._ToVillageId != value))
				{
					if (this._Village1.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnToVillageIdChanging(value);
					this.SendPropertyChanging();
					this._ToVillageId = value;
					this.SendPropertyChanged("ToVillageId");
					this.OnToVillageIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Time", DbType="Float NOT NULL")]
		public double Time
		{
			get
			{
				return this._Time;
			}
			set
			{
				if ((this._Time != value))
				{
					this.OnTimeChanging(value);
					this.SendPropertyChanging();
					this._Time = value;
					this.SendPropertyChanged("Time");
					this.OnTimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TimeType", DbType="NChar(10) NOT NULL", CanBeNull=false)]
		public string TimeType
		{
			get
			{
				return this._TimeType;
			}
			set
			{
				if ((this._TimeType != value))
				{
					this.OnTimeTypeChanging(value);
					this.SendPropertyChanging();
					this._TimeType = value;
					this.SendPropertyChanged("TimeType");
					this.OnTimeTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Village_Edge", Storage="_Village", ThisKey="FromVillageId", OtherKey="Id", IsForeignKey=true)]
		public Village Village
		{
			get
			{
				return this._Village.Entity;
			}
			set
			{
				Village previousValue = this._Village.Entity;
				if (((previousValue != value) 
							|| (this._Village.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Village.Entity = null;
						previousValue.Edges.Remove(this);
					}
					this._Village.Entity = value;
					if ((value != null))
					{
						value.Edges.Add(this);
						this._FromVillageId = value.Id;
					}
					else
					{
						this._FromVillageId = default(int);
					}
					this.SendPropertyChanged("Village");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Village_Edge1", Storage="_Village1", ThisKey="ToVillageId", OtherKey="Id", IsForeignKey=true)]
		public Village Village1
		{
			get
			{
				return this._Village1.Entity;
			}
			set
			{
				Village previousValue = this._Village1.Entity;
				if (((previousValue != value) 
							|| (this._Village1.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Village1.Entity = null;
						previousValue.Edges1.Remove(this);
					}
					this._Village1.Entity = value;
					if ((value != null))
					{
						value.Edges1.Add(this);
						this._ToVillageId = value.Id;
					}
					else
					{
						this._ToVillageId = default(int);
					}
					this.SendPropertyChanged("Village1");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
