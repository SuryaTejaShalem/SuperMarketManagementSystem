#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp1
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="market")]
	public partial class marketDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertBillTbl(BillTbl instance);
    partial void UpdateBillTbl(BillTbl instance);
    partial void DeleteBillTbl(BillTbl instance);
    partial void InsertCatTbl(CatTbl instance);
    partial void UpdateCatTbl(CatTbl instance);
    partial void DeleteCatTbl(CatTbl instance);
    partial void InsertProdTbl(ProdTbl instance);
    partial void UpdateProdTbl(ProdTbl instance);
    partial void DeleteProdTbl(ProdTbl instance);
    partial void InsertSellerTbl(SellerTbl instance);
    partial void UpdateSellerTbl(SellerTbl instance);
    partial void DeleteSellerTbl(SellerTbl instance);
    #endregion
		
		public marketDataContext() : 
				base(global::WpfApp1.Properties.Settings.Default.marketConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public marketDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public marketDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public marketDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public marketDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<BillTbl> BillTbls
		{
			get
			{
				return this.GetTable<BillTbl>();
			}
		}
		
		public System.Data.Linq.Table<CatTbl> CatTbls
		{
			get
			{
				return this.GetTable<CatTbl>();
			}
		}
		
		public System.Data.Linq.Table<ProdTbl> ProdTbls
		{
			get
			{
				return this.GetTable<ProdTbl>();
			}
		}
		
		public System.Data.Linq.Table<SellerTbl> SellerTbls
		{
			get
			{
				return this.GetTable<SellerTbl>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.BillTbl")]
	public partial class BillTbl : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _BillId;
		
		private string _SellerName;
		
		private string _BillDate;
		
		private int _TotAmt;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnBillIdChanging(int value);
    partial void OnBillIdChanged();
    partial void OnSellerNameChanging(string value);
    partial void OnSellerNameChanged();
    partial void OnBillDateChanging(string value);
    partial void OnBillDateChanged();
    partial void OnTotAmtChanging(int value);
    partial void OnTotAmtChanged();
    #endregion
		
		public BillTbl()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BillId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int BillId
		{
			get
			{
				return this._BillId;
			}
			set
			{
				if ((this._BillId != value))
				{
					this.OnBillIdChanging(value);
					this.SendPropertyChanging();
					this._BillId = value;
					this.SendPropertyChanged("BillId");
					this.OnBillIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SellerName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string SellerName
		{
			get
			{
				return this._SellerName;
			}
			set
			{
				if ((this._SellerName != value))
				{
					this.OnSellerNameChanging(value);
					this.SendPropertyChanging();
					this._SellerName = value;
					this.SendPropertyChanged("SellerName");
					this.OnSellerNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BillDate", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string BillDate
		{
			get
			{
				return this._BillDate;
			}
			set
			{
				if ((this._BillDate != value))
				{
					this.OnBillDateChanging(value);
					this.SendPropertyChanging();
					this._BillDate = value;
					this.SendPropertyChanged("BillDate");
					this.OnBillDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TotAmt", DbType="Int NOT NULL")]
		public int TotAmt
		{
			get
			{
				return this._TotAmt;
			}
			set
			{
				if ((this._TotAmt != value))
				{
					this.OnTotAmtChanging(value);
					this.SendPropertyChanging();
					this._TotAmt = value;
					this.SendPropertyChanged("TotAmt");
					this.OnTotAmtChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.CatTbl")]
	public partial class CatTbl : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _CatId;
		
		private string _CatName;
		
		private string _CatDesc;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCatIdChanging(int value);
    partial void OnCatIdChanged();
    partial void OnCatNameChanging(string value);
    partial void OnCatNameChanged();
    partial void OnCatDescChanging(string value);
    partial void OnCatDescChanged();
    #endregion
		
		public CatTbl()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CatId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int CatId
		{
			get
			{
				return this._CatId;
			}
			set
			{
				if ((this._CatId != value))
				{
					this.OnCatIdChanging(value);
					this.SendPropertyChanging();
					this._CatId = value;
					this.SendPropertyChanged("CatId");
					this.OnCatIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CatName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string CatName
		{
			get
			{
				return this._CatName;
			}
			set
			{
				if ((this._CatName != value))
				{
					this.OnCatNameChanging(value);
					this.SendPropertyChanging();
					this._CatName = value;
					this.SendPropertyChanged("CatName");
					this.OnCatNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CatDesc", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string CatDesc
		{
			get
			{
				return this._CatDesc;
			}
			set
			{
				if ((this._CatDesc != value))
				{
					this.OnCatDescChanging(value);
					this.SendPropertyChanging();
					this._CatDesc = value;
					this.SendPropertyChanged("CatDesc");
					this.OnCatDescChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ProdTbl")]
	public partial class ProdTbl : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ProdId;
		
		private string _ProdName;
		
		private int _ProdQty;
		
		private int _ProdPrice;
		
		private string _ProdCat;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnProdIdChanging(int value);
    partial void OnProdIdChanged();
    partial void OnProdNameChanging(string value);
    partial void OnProdNameChanged();
    partial void OnProdQtyChanging(int value);
    partial void OnProdQtyChanged();
    partial void OnProdPriceChanging(int value);
    partial void OnProdPriceChanged();
    partial void OnProdCatChanging(string value);
    partial void OnProdCatChanged();
    #endregion
		
		public ProdTbl()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProdId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ProdId
		{
			get
			{
				return this._ProdId;
			}
			set
			{
				if ((this._ProdId != value))
				{
					this.OnProdIdChanging(value);
					this.SendPropertyChanging();
					this._ProdId = value;
					this.SendPropertyChanged("ProdId");
					this.OnProdIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProdName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string ProdName
		{
			get
			{
				return this._ProdName;
			}
			set
			{
				if ((this._ProdName != value))
				{
					this.OnProdNameChanging(value);
					this.SendPropertyChanging();
					this._ProdName = value;
					this.SendPropertyChanged("ProdName");
					this.OnProdNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProdQty", DbType="Int NOT NULL")]
		public int ProdQty
		{
			get
			{
				return this._ProdQty;
			}
			set
			{
				if ((this._ProdQty != value))
				{
					this.OnProdQtyChanging(value);
					this.SendPropertyChanging();
					this._ProdQty = value;
					this.SendPropertyChanged("ProdQty");
					this.OnProdQtyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProdPrice", DbType="Int NOT NULL")]
		public int ProdPrice
		{
			get
			{
				return this._ProdPrice;
			}
			set
			{
				if ((this._ProdPrice != value))
				{
					this.OnProdPriceChanging(value);
					this.SendPropertyChanging();
					this._ProdPrice = value;
					this.SendPropertyChanged("ProdPrice");
					this.OnProdPriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProdCat", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string ProdCat
		{
			get
			{
				return this._ProdCat;
			}
			set
			{
				if ((this._ProdCat != value))
				{
					this.OnProdCatChanging(value);
					this.SendPropertyChanging();
					this._ProdCat = value;
					this.SendPropertyChanged("ProdCat");
					this.OnProdCatChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.SellerTbl")]
	public partial class SellerTbl : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _SellerId;
		
		private string _SellerName;
		
		private int _SellerAge;
		
		private string _SellerPhone;
		
		private string _SellerPassword;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnSellerIdChanging(int value);
    partial void OnSellerIdChanged();
    partial void OnSellerNameChanging(string value);
    partial void OnSellerNameChanged();
    partial void OnSellerAgeChanging(int value);
    partial void OnSellerAgeChanged();
    partial void OnSellerPhoneChanging(string value);
    partial void OnSellerPhoneChanged();
    partial void OnSellerPasswordChanging(string value);
    partial void OnSellerPasswordChanged();
    #endregion
		
		public SellerTbl()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SellerId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int SellerId
		{
			get
			{
				return this._SellerId;
			}
			set
			{
				if ((this._SellerId != value))
				{
					this.OnSellerIdChanging(value);
					this.SendPropertyChanging();
					this._SellerId = value;
					this.SendPropertyChanged("SellerId");
					this.OnSellerIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SellerName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string SellerName
		{
			get
			{
				return this._SellerName;
			}
			set
			{
				if ((this._SellerName != value))
				{
					this.OnSellerNameChanging(value);
					this.SendPropertyChanging();
					this._SellerName = value;
					this.SendPropertyChanged("SellerName");
					this.OnSellerNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SellerAge", DbType="Int NOT NULL")]
		public int SellerAge
		{
			get
			{
				return this._SellerAge;
			}
			set
			{
				if ((this._SellerAge != value))
				{
					this.OnSellerAgeChanging(value);
					this.SendPropertyChanging();
					this._SellerAge = value;
					this.SendPropertyChanged("SellerAge");
					this.OnSellerAgeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SellerPhone", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string SellerPhone
		{
			get
			{
				return this._SellerPhone;
			}
			set
			{
				if ((this._SellerPhone != value))
				{
					this.OnSellerPhoneChanging(value);
					this.SendPropertyChanging();
					this._SellerPhone = value;
					this.SendPropertyChanged("SellerPhone");
					this.OnSellerPhoneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SellerPassword", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string SellerPassword
		{
			get
			{
				return this._SellerPassword;
			}
			set
			{
				if ((this._SellerPassword != value))
				{
					this.OnSellerPasswordChanging(value);
					this.SendPropertyChanging();
					this._SellerPassword = value;
					this.SendPropertyChanged("SellerPassword");
					this.OnSellerPasswordChanged();
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
