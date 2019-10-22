using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace SqlDatabase
{
	public class ConnectionProvider : IDisposable
	{
		#region Class Member Declarations
		private	SqlConnection		_dBConnection;
		private	bool				_isTransactionPending, _isDisposed;
		private	SqlTransaction		_currentTransaction;
		private	ArrayList			_savePoints;
		#endregion

		#region ConnectionProvider
		public ConnectionProvider()
		{
			InitClass();
		}
		#endregion

		#region Dispose
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool isDisposing)
		{
			if(!_isDisposed)
			{
				if(isDisposing)
				{
					if(_currentTransaction != null)
					{
						_currentTransaction.Dispose();
						_currentTransaction = null;
					}
					if(_dBConnection != null)
					{
						_dBConnection.Close();
						_dBConnection.Dispose();
						_dBConnection = null;
					}
				}
			}
			_isDisposed = true;
		}
		#endregion

		#region InitClass
		private void InitClass()
		{
			_dBConnection = new SqlConnection();
			_isDisposed = false;
			_currentTransaction = null;
			_isTransactionPending = false;
			_savePoints = new ArrayList();
		}
		#endregion		

		#region OpenConnection
		public bool OpenConnection()
		{
			try
			{
				if((_dBConnection.State & ConnectionState.Open) > 0)
				{
					return true;
				}

				AppSettingsReader _configReader = new AppSettingsReader();
				_dBConnection.ConnectionString = 
					_configReader.GetValue("Main.ConnectionString", typeof(string)).ToString();

				_dBConnection.Open();
				_isTransactionPending = false;
				return true;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public bool OpenConnection(string sConnect)
		{
			try
			{
				if((_dBConnection.State & ConnectionState.Open) > 0)
				{
					return true;
				}

				_dBConnection.ConnectionString = sConnect;
				_dBConnection.Open();
				_isTransactionPending = false;
				return true;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region BeginTransaction
		public bool BeginTransaction(string transactionName)
		{
			try
			{
				if(_isTransactionPending)
				{
					throw new Exception("BeginTransaction::Already transaction pending. Nesting not allowed");
				}
				if((_dBConnection.State & ConnectionState.Open) == 0)
				{
					throw new Exception("BeginTransaction::Connection is not open.");
				}
				_currentTransaction = _dBConnection.BeginTransaction(IsolationLevel.ReadCommitted, transactionName);
				_isTransactionPending = true;
				_savePoints.Clear();
				return true;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region CommitTransaction
		public bool CommitTransaction()
		{
			try
			{
				if(!_isTransactionPending)
				{
					throw new Exception("CommitTransaction::No transaction pending.");
				}
				if((_dBConnection.State & ConnectionState.Open) == 0)
				{
					throw new Exception("CommitTransaction::Connection is not open.");
				}

				_currentTransaction.Commit();
				_isTransactionPending = false;
				_currentTransaction.Dispose();
				_currentTransaction = null;
				_savePoints.Clear();
				return true;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region RollbackTransaction
		public bool RollbackTransaction(string transactionToRollback)
		{
			try
			{
				if(!_isTransactionPending)
				{
					throw new Exception("RollbackTransaction::No transaction pending.");
				}
				if((_dBConnection.State & ConnectionState.Open) == 0)
				{
					throw new Exception("RollbackTransaction::Connection is not open.");
				}
				_currentTransaction.Rollback(transactionToRollback);

				if(!_savePoints.Contains(transactionToRollback))
				{
					_isTransactionPending = false;
					_currentTransaction.Dispose();
					_currentTransaction = null;
					_savePoints.Clear();
				}
				return true;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region SaveTransaction
		public bool SaveTransaction(string savePointName)
		{
			try
			{
				if(!_isTransactionPending)
				{
					throw new Exception("SaveTransaction::No transaction pending.");
				}
				if((_dBConnection.State & ConnectionState.Open) == 0)
				{
					throw new Exception("SaveTransaction::Connection is not open.");
				}
				_currentTransaction.Save(savePointName);
				_savePoints.Add(savePointName);
				return true;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		#endregion

		#region CloseConnection
		public bool CloseConnection(bool commitPendingTransaction)
		{
			try
			{
				if((_dBConnection.State & ConnectionState.Open) == 0)
				{
					return false;
				}
				if(_isTransactionPending)
				{
					if(commitPendingTransaction)
					{
						_currentTransaction.Commit();
					}
					else
					{
						_currentTransaction.Rollback();
					}
					_isTransactionPending = false;
					_currentTransaction.Dispose();
					_currentTransaction = null;
					_savePoints.Clear();
				}
				_dBConnection.Close();
				return true;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}	
		#endregion
		
		#region Class Property Declarations
		public SqlTransaction CurrentTransaction
		{
			get
			{
				return _currentTransaction;
			}
		}


		public bool IsTransactionPending
		{
			get
			{
				return _isTransactionPending;
			}
		}


		public SqlConnection DBConnection
		{
			get
			{
				return _dBConnection;
			}
		}
		#endregion

	}
}
