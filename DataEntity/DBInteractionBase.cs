using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace DataEntity
{
	public enum LLBLError
	{
		AllOk
		// Add more here (check the comma's!)
	}


	public interface ICommonDBAccess
	{
		bool		Insert();
		bool		Update();
		bool		Delete();
		DataTable	SelectOne();
		DataTable	SelectAll();
	}


	public abstract class DBInteractionBase : IDisposable, ICommonDBAccess
	{
		#region Class Member Declarations
			protected	SqlConnection			_mainConnection;
			protected	int						_rowsAffected;
			protected	bool					_mainConnectionIsCreatedLocal;
			protected	ConnectionProvider		_mainConnectionProvider;
			private		bool					_isDisposed;
		#endregion


		public DBInteractionBase()
		{
			// Initialize the class' members.
			InitClass();
		}


		private void InitClass()
		{
			// create all the objects and initialize other members.
			_mainConnection = new SqlConnection();
			_mainConnectionIsCreatedLocal = true;
			_mainConnectionProvider = null;
			AppSettingsReader _configReader = new AppSettingsReader();

			// Set connection string of the sqlconnection object
			_mainConnection.ConnectionString = 
						_configReader.GetValue("Main.ConnectionString", typeof(string)).ToString();
			_isDisposed = false;
		}


		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}


		protected virtual void Dispose(bool isDisposing)
		{
			// Check to see if Dispose has already been called.
			if(!_isDisposed)
			{
				if(isDisposing)
				{
					// Dispose managed resources.
					if(_mainConnectionIsCreatedLocal)
					{
						// Object is created in this class, so destroy it here.
						_mainConnection.Close();
						_mainConnection.Dispose();
						_mainConnectionIsCreatedLocal = false;
					}
					_mainConnectionProvider = null;
					_mainConnection = null;
				}
			}
			_isDisposed = true;
		}


		public virtual bool Insert()
		{
			// No implementation, throw exception
			throw new NotImplementedException();
		}


		public virtual bool Delete()
		{
			// No implementation, throw exception
			throw new NotImplementedException();
		}


		public virtual bool Update()
		{
			// No implementation, throw exception
			throw new NotImplementedException();
		}


		public virtual DataTable SelectOne()
		{
			// No implementation, throw exception
			throw new NotImplementedException();
		}


		public virtual DataTable SelectAll()
		{
			// No implementation, throw exception
			throw new NotImplementedException();
		}


		#region Class Property Declarations
		public ConnectionProvider MainConnectionProvider
		{
			set
			{
				if(value==null)
				{
					// Invalid value
					throw new ArgumentNullException("MainConnectionProvider", "Null passed as value to this property which is not allowed.");
				}

				// A connection provider object is passed to this class.
				// Retrieve the SqlConnection object, if present and create a
				// reference to it. If there is already a MainConnection object
				// referenced by the membervar, destroy that one or simply 
				// remove the reference, based on the flag.
				if(_mainConnection!=null)
				{
					// First get rid of current connection object. Caller is responsible
					if(_mainConnectionIsCreatedLocal)
					{
						// Is local created object, close it and dispose it.
						_mainConnection.Close();
						_mainConnection.Dispose();
					}
					// Remove reference.
					_mainConnection = null;
				}
				_mainConnectionProvider = (ConnectionProvider)value;
				_mainConnection = _mainConnectionProvider.DBConnection;
				_mainConnectionIsCreatedLocal = false;
			}
		}


		public int RowsAffected
		{
			get
			{
				return _rowsAffected;
			}
		}
		#endregion
	}
}
