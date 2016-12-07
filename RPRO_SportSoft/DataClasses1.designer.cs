﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RPRO_SportSoft
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="SportSoftDb")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertCourt(Court instance);
    partial void UpdateCourt(Court instance);
    partial void DeleteCourt(Court instance);
    partial void InsertSport(Sport instance);
    partial void UpdateSport(Sport instance);
    partial void DeleteSport(Sport instance);
    partial void InsertUser(User instance);
    partial void UpdateUser(User instance);
    partial void DeleteUser(User instance);
    partial void InsertPriceList(PriceList instance);
    partial void UpdatePriceList(PriceList instance);
    partial void DeletePriceList(PriceList instance);
    partial void InsertPriceLists_Courts(PriceLists_Courts instance);
    partial void UpdatePriceLists_Courts(PriceLists_Courts instance);
    partial void DeletePriceLists_Courts(PriceLists_Courts instance);
    partial void InsertReservation(Reservation instance);
    partial void UpdateReservation(Reservation instance);
    partial void DeleteReservation(Reservation instance);
    partial void InsertReservation_Time(Reservation_Time instance);
    partial void UpdateReservation_Time(Reservation_Time instance);
    partial void DeleteReservation_Time(Reservation_Time instance);
    #endregion
		
		public DataClasses1DataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["SportSoftDbConnectionString"].ConnectionString, mappingSource)
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
		
		public System.Data.Linq.Table<Court> Courts
		{
			get
			{
				return this.GetTable<Court>();
			}
		}
		
		public System.Data.Linq.Table<Sport> Sports
		{
			get
			{
				return this.GetTable<Sport>();
			}
		}
		
		public System.Data.Linq.Table<User> Users
		{
			get
			{
				return this.GetTable<User>();
			}
		}
		
		public System.Data.Linq.Table<PriceList> PriceLists
		{
			get
			{
				return this.GetTable<PriceList>();
			}
		}
		
		public System.Data.Linq.Table<PriceLists_Courts> PriceLists_Courts
		{
			get
			{
				return this.GetTable<PriceLists_Courts>();
			}
		}
		
		public System.Data.Linq.Table<Reservation> Reservations
		{
			get
			{
				return this.GetTable<Reservation>();
			}
		}
		
		public System.Data.Linq.Table<Reservation_Time> Reservation_Times
		{
			get
			{
				return this.GetTable<Reservation_Time>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Courts")]
	public partial class Court : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Name;
		
		private int _Sports_Id;
		
		private EntitySet<Reservation> _Reservations;
		
		private EntityRef<Sport> _Sport;
		
		private EntityRef<PriceLists_Courts> _PriceLists_Courts;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnSports_IdChanging(int value);
    partial void OnSports_IdChanged();
    #endregion
		
		public Court()
		{
			this._Reservations = new EntitySet<Reservation>(new Action<Reservation>(this.attach_Reservations), new Action<Reservation>(this.detach_Reservations));
			this._Sport = default(EntityRef<Sport>);
			this._PriceLists_Courts = default(EntityRef<PriceLists_Courts>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL", IsPrimaryKey=true, IsDbGenerated=true)]
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
					if (this._PriceLists_Courts.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="VarChar(1) NOT NULL", CanBeNull=false)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Sports_Id", DbType="Int NOT NULL")]
		public int Sports_Id
		{
			get
			{
				return this._Sports_Id;
			}
			set
			{
				if ((this._Sports_Id != value))
				{
					if (this._Sport.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnSports_IdChanging(value);
					this.SendPropertyChanging();
					this._Sports_Id = value;
					this.SendPropertyChanged("Sports_Id");
					this.OnSports_IdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Court_Reservation", Storage="_Reservations", ThisKey="Id", OtherKey="Courts_Id")]
		public EntitySet<Reservation> Reservations
		{
			get
			{
				return this._Reservations;
			}
			set
			{
				this._Reservations.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Sport_Court", Storage="_Sport", ThisKey="Sports_Id", OtherKey="Id", IsForeignKey=true)]
		public Sport Sport
		{
			get
			{
				return this._Sport.Entity;
			}
			set
			{
				Sport previousValue = this._Sport.Entity;
				if (((previousValue != value) 
							|| (this._Sport.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Sport.Entity = null;
						previousValue.Courts.Remove(this);
					}
					this._Sport.Entity = value;
					if ((value != null))
					{
						value.Courts.Add(this);
						this._Sports_Id = value.Id;
					}
					else
					{
						this._Sports_Id = default(int);
					}
					this.SendPropertyChanged("Sport");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="PriceLists_Courts_Court", Storage="_PriceLists_Courts", ThisKey="Id", OtherKey="Courts_Id", IsForeignKey=true)]
		public PriceLists_Courts PriceLists_Courts
		{
			get
			{
				return this._PriceLists_Courts.Entity;
			}
			set
			{
				PriceLists_Courts previousValue = this._PriceLists_Courts.Entity;
				if (((previousValue != value) 
							|| (this._PriceLists_Courts.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._PriceLists_Courts.Entity = null;
						previousValue.Courts.Remove(this);
					}
					this._PriceLists_Courts.Entity = value;
					if ((value != null))
					{
						value.Courts.Add(this);
						this._Id = value.Courts_Id;
					}
					else
					{
						this._Id = default(int);
					}
					this.SendPropertyChanged("PriceLists_Courts");
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
		
		private void attach_Reservations(Reservation entity)
		{
			this.SendPropertyChanging();
			entity.Court = this;
		}
		
		private void detach_Reservations(Reservation entity)
		{
			this.SendPropertyChanging();
			entity.Court = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Sports")]
	public partial class Sport : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Name;
		
		private EntitySet<Court> _Courts;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    #endregion
		
		public Sport()
		{
			this._Courts = new EntitySet<Court>(new Action<Court>(this.attach_Courts), new Action<Court>(this.detach_Courts));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL", IsPrimaryKey=true, IsDbGenerated=true)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="VarChar(1) NOT NULL", CanBeNull=false)]
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
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Sport_Court", Storage="_Courts", ThisKey="Id", OtherKey="Sports_Id")]
		public EntitySet<Court> Courts
		{
			get
			{
				return this._Courts;
			}
			set
			{
				this._Courts.Assign(value);
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
		
		private void attach_Courts(Court entity)
		{
			this.SendPropertyChanging();
			entity.Sport = this;
		}
		
		private void detach_Courts(Court entity)
		{
			this.SendPropertyChanging();
			entity.Sport = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.User")]
	public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _Email;
		
		private string _Password;
		
		private string _Salt;
		
		private string _Role;
		
		private EntitySet<Reservation> _Reservations;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    partial void OnSaltChanging(string value);
    partial void OnSaltChanged();
    partial void OnRoleChanging(string value);
    partial void OnRoleChanged();
    #endregion
		
		public User()
		{
			this._Reservations = new EntitySet<Reservation>(new Action<Reservation>(this.attach_Reservations), new Action<Reservation>(this.detach_Reservations));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="VarChar(1) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="VarChar(1) NOT NULL", CanBeNull=false)]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this.OnPasswordChanging(value);
					this.SendPropertyChanging();
					this._Password = value;
					this.SendPropertyChanged("Password");
					this.OnPasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Salt", DbType="VarChar(1) NOT NULL", CanBeNull=false)]
		public string Salt
		{
			get
			{
				return this._Salt;
			}
			set
			{
				if ((this._Salt != value))
				{
					this.OnSaltChanging(value);
					this.SendPropertyChanging();
					this._Salt = value;
					this.SendPropertyChanged("Salt");
					this.OnSaltChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Role", DbType="VarChar(1) NOT NULL", CanBeNull=false)]
		public string Role
		{
			get
			{
				return this._Role;
			}
			set
			{
				if ((this._Role != value))
				{
					this.OnRoleChanging(value);
					this.SendPropertyChanging();
					this._Role = value;
					this.SendPropertyChanged("Role");
					this.OnRoleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_Reservation", Storage="_Reservations", ThisKey="Email", OtherKey="User_Email")]
		public EntitySet<Reservation> Reservations
		{
			get
			{
				return this._Reservations;
			}
			set
			{
				this._Reservations.Assign(value);
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
		
		private void attach_Reservations(Reservation entity)
		{
			this.SendPropertyChanging();
			entity.User = this;
		}
		
		private void detach_Reservations(Reservation entity)
		{
			this.SendPropertyChanging();
			entity.User = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.PriceLists")]
	public partial class PriceList : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private int _Price;
		
		private string _Description;
		
		private EntityRef<PriceLists_Courts> _PriceLists_Courts;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnPriceChanging(int value);
    partial void OnPriceChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    #endregion
		
		public PriceList()
		{
			this._PriceLists_Courts = default(EntityRef<PriceLists_Courts>);
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
					if (this._PriceLists_Courts.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Price", DbType="INT NOT NULL")]
		public int Price
		{
			get
			{
				return this._Price;
			}
			set
			{
				if ((this._Price != value))
				{
					this.OnPriceChanging(value);
					this.SendPropertyChanging();
					this._Price = value;
					this.SendPropertyChanged("Price");
					this.OnPriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="VarChar(1) NOT NULL", CanBeNull=false)]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="PriceLists_Courts_PriceList", Storage="_PriceLists_Courts", ThisKey="Id", OtherKey="PriceLists_Id", IsForeignKey=true)]
		public PriceLists_Courts PriceLists_Courts
		{
			get
			{
				return this._PriceLists_Courts.Entity;
			}
			set
			{
				PriceLists_Courts previousValue = this._PriceLists_Courts.Entity;
				if (((previousValue != value) 
							|| (this._PriceLists_Courts.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._PriceLists_Courts.Entity = null;
						previousValue.PriceLists.Remove(this);
					}
					this._PriceLists_Courts.Entity = value;
					if ((value != null))
					{
						value.PriceLists.Add(this);
						this._Id = value.PriceLists_Id;
					}
					else
					{
						this._Id = default(int);
					}
					this.SendPropertyChanged("PriceLists_Courts");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.PriceLists_Courts")]
	public partial class PriceLists_Courts : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private int _PriceLists_Id;
		
		private int _Courts_Id;
		
		private System.DateTime _Date;
		
		private EntitySet<Court> _Courts;
		
		private EntitySet<PriceList> _PriceLists;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnPriceLists_IdChanging(int value);
    partial void OnPriceLists_IdChanged();
    partial void OnCourts_IdChanging(int value);
    partial void OnCourts_IdChanged();
    partial void OnDateChanging(System.DateTime value);
    partial void OnDateChanged();
    #endregion
		
		public PriceLists_Courts()
		{
			this._Courts = new EntitySet<Court>(new Action<Court>(this.attach_Courts), new Action<Court>(this.detach_Courts));
			this._PriceLists = new EntitySet<PriceList>(new Action<PriceList>(this.attach_PriceLists), new Action<PriceList>(this.detach_PriceLists));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL", IsPrimaryKey=true, IsDbGenerated=true)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="PriceList_Id", Storage="_PriceLists_Id", DbType="Int NOT NULL")]
		public int PriceLists_Id
		{
			get
			{
				return this._PriceLists_Id;
			}
			set
			{
				if ((this._PriceLists_Id != value))
				{
					this.OnPriceLists_IdChanging(value);
					this.SendPropertyChanging();
					this._PriceLists_Id = value;
					this.SendPropertyChanged("PriceLists_Id");
					this.OnPriceLists_IdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Courts_Id", DbType="Int NOT NULL")]
		public int Courts_Id
		{
			get
			{
				return this._Courts_Id;
			}
			set
			{
				if ((this._Courts_Id != value))
				{
					this.OnCourts_IdChanging(value);
					this.SendPropertyChanging();
					this._Courts_Id = value;
					this.SendPropertyChanged("Courts_Id");
					this.OnCourts_IdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Date", DbType="Date")]
		public System.DateTime Date
		{
			get
			{
				return this._Date;
			}
			set
			{
				if ((this._Date != value))
				{
					this.OnDateChanging(value);
					this.SendPropertyChanging();
					this._Date = value;
					this.SendPropertyChanged("Date");
					this.OnDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="PriceLists_Courts_Court", Storage="_Courts", ThisKey="Courts_Id", OtherKey="Id")]
		public EntitySet<Court> Courts
		{
			get
			{
				return this._Courts;
			}
			set
			{
				this._Courts.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="PriceLists_Courts_PriceList", Storage="_PriceLists", ThisKey="PriceLists_Id", OtherKey="Id")]
		public EntitySet<PriceList> PriceLists
		{
			get
			{
				return this._PriceLists;
			}
			set
			{
				this._PriceLists.Assign(value);
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
		
		private void attach_Courts(Court entity)
		{
			this.SendPropertyChanging();
			entity.PriceLists_Courts = this;
		}
		
		private void detach_Courts(Court entity)
		{
			this.SendPropertyChanging();
			entity.PriceLists_Courts = null;
		}
		
		private void attach_PriceLists(PriceList entity)
		{
			this.SendPropertyChanging();
			entity.PriceLists_Courts = this;
		}
		
		private void detach_PriceLists(PriceList entity)
		{
			this.SendPropertyChanging();
			entity.PriceLists_Courts = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Reservations")]
	public partial class Reservation : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private int _Courts_Id;
		
		private System.DateTime _Date;
		
		private int _Price;
		
		private int _Time_Id;
		
		private string _User_Email;
		
		private EntityRef<Court> _Court;
		
		private EntityRef<User> _User;
		
		private EntityRef<Reservation_Time> _Reservation_Time;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnCourts_IdChanging(int value);
    partial void OnCourts_IdChanged();
    partial void OnDateChanging(System.DateTime value);
    partial void OnDateChanged();
    partial void OnPriceChanging(int value);
    partial void OnPriceChanged();
    partial void OnTime_IdChanging(int value);
    partial void OnTime_IdChanged();
    partial void OnUser_EmailChanging(string value);
    partial void OnUser_EmailChanged();
    #endregion
		
		public Reservation()
		{
			this._Court = default(EntityRef<Court>);
			this._User = default(EntityRef<User>);
			this._Reservation_Time = default(EntityRef<Reservation_Time>);
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Courts_Id", DbType="Int NOT NULL")]
		public int Courts_Id
		{
			get
			{
				return this._Courts_Id;
			}
			set
			{
				if ((this._Courts_Id != value))
				{
					if (this._Court.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnCourts_IdChanging(value);
					this.SendPropertyChanging();
					this._Courts_Id = value;
					this.SendPropertyChanged("Courts_Id");
					this.OnCourts_IdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Date", DbType="Date NOT NULL")]
		public System.DateTime Date
		{
			get
			{
				return this._Date;
			}
			set
			{
				if ((this._Date != value))
				{
					this.OnDateChanging(value);
					this.SendPropertyChanging();
					this._Date = value;
					this.SendPropertyChanged("Date");
					this.OnDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Price", DbType="Int NOT NULL")]
		public int Price
		{
			get
			{
				return this._Price;
			}
			set
			{
				if ((this._Price != value))
				{
					this.OnPriceChanging(value);
					this.SendPropertyChanging();
					this._Price = value;
					this.SendPropertyChanged("Price");
					this.OnPriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Time_Id", DbType="Int NOT NULL")]
		public int Time_Id
		{
			get
			{
				return this._Time_Id;
			}
			set
			{
				if ((this._Time_Id != value))
				{
					if (this._Reservation_Time.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnTime_IdChanging(value);
					this.SendPropertyChanging();
					this._Time_Id = value;
					this.SendPropertyChanged("Time_Id");
					this.OnTime_IdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_User_Email", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string User_Email
		{
			get
			{
				return this._User_Email;
			}
			set
			{
				if ((this._User_Email != value))
				{
					if (this._User.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnUser_EmailChanging(value);
					this.SendPropertyChanging();
					this._User_Email = value;
					this.SendPropertyChanged("User_Email");
					this.OnUser_EmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Court_Reservation", Storage="_Court", ThisKey="Courts_Id", OtherKey="Id", IsForeignKey=true)]
		public Court Court
		{
			get
			{
				return this._Court.Entity;
			}
			set
			{
				Court previousValue = this._Court.Entity;
				if (((previousValue != value) 
							|| (this._Court.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Court.Entity = null;
						previousValue.Reservations.Remove(this);
					}
					this._Court.Entity = value;
					if ((value != null))
					{
						value.Reservations.Add(this);
						this._Courts_Id = value.Id;
					}
					else
					{
						this._Courts_Id = default(int);
					}
					this.SendPropertyChanged("Court");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_Reservation", Storage="_User", ThisKey="User_Email", OtherKey="Email", IsForeignKey=true)]
		public User User
		{
			get
			{
				return this._User.Entity;
			}
			set
			{
				User previousValue = this._User.Entity;
				if (((previousValue != value) 
							|| (this._User.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._User.Entity = null;
						previousValue.Reservations.Remove(this);
					}
					this._User.Entity = value;
					if ((value != null))
					{
						value.Reservations.Add(this);
						this._User_Email = value.Email;
					}
					else
					{
						this._User_Email = default(string);
					}
					this.SendPropertyChanged("User");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Reservation_Time_Reservation", Storage="_Reservation_Time", ThisKey="Time_Id", OtherKey="Id", IsForeignKey=true)]
		public Reservation_Time Reservation_Time
		{
			get
			{
				return this._Reservation_Time.Entity;
			}
			set
			{
				Reservation_Time previousValue = this._Reservation_Time.Entity;
				if (((previousValue != value) 
							|| (this._Reservation_Time.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Reservation_Time.Entity = null;
						previousValue.Reservations.Remove(this);
					}
					this._Reservation_Time.Entity = value;
					if ((value != null))
					{
						value.Reservations.Add(this);
						this._Time_Id = value.Id;
					}
					else
					{
						this._Time_Id = default(int);
					}
					this.SendPropertyChanged("Reservation_Time");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Reservation_Time")]
	public partial class Reservation_Time : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Time;
		
		private EntitySet<Reservation> _Reservations;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnTimeChanging(string value);
    partial void OnTimeChanged();
    #endregion
		
		public Reservation_Time()
		{
			this._Reservations = new EntitySet<Reservation>(new Action<Reservation>(this.attach_Reservations), new Action<Reservation>(this.detach_Reservations));
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Time", DbType="VarChar(10) NOT NULL", CanBeNull=false)]
		public string Time
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
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Reservation_Time_Reservation", Storage="_Reservations", ThisKey="Id", OtherKey="Time_Id")]
		public EntitySet<Reservation> Reservations
		{
			get
			{
				return this._Reservations;
			}
			set
			{
				this._Reservations.Assign(value);
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
		
		private void attach_Reservations(Reservation entity)
		{
			this.SendPropertyChanging();
			entity.Reservation_Time = this;
		}
		
		private void detach_Reservations(Reservation entity)
		{
			this.SendPropertyChanging();
			entity.Reservation_Time = null;
		}
	}
}
#pragma warning restore 1591
