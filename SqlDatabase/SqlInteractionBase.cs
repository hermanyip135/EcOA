using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace SqlDatabase
{
    public class SqlInteractionBase
    {
        #region Class Member Declarations
        protected SqlConnection _mainConnection;
        protected int _rowsAffected;
        protected SqlInt32 _errorCode;
        protected bool _mainConnectionIsCreatedLocal;
        protected ConnectionProvider _mainConnectionProvider;
        private bool _isDisposed;
        #endregion

        #region SqlInteractionBase
        public SqlInteractionBase()
        {
            InitClass();
        }
        #endregion

        #region InitClass
        private void InitClass()
        {
            _mainConnection = new SqlConnection();
            _mainConnectionIsCreatedLocal = true;
            _mainConnectionProvider = null;
            AppSettingsReader _configReader = new AppSettingsReader();

            _mainConnection.ConnectionString =
                _configReader.GetValue("Main.ConnectionString", typeof(string)).ToString();
            _errorCode = (int)DBError.AllOk;
            _isDisposed = false;
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
            if (!_isDisposed)
            {
                if (isDisposing)
                {
                    if (_mainConnectionIsCreatedLocal)
                    {
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
        #endregion

        #region ICommonDBAccess½Ó¿Ú
        public virtual bool Insert(object obj)
        {
            throw new NotImplementedException();
        }

        public virtual bool Delete(object obj)
        {
            throw new NotImplementedException();
        }

        public virtual bool Update(object obj)
        {
            throw new NotImplementedException();
        }

        public virtual object SelectOne(object obj)
        {
            throw new NotImplementedException();
        }

        public virtual DataSet SelectAll()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Class Property Declarations
        public ConnectionProvider MainConnectionProvider
        {
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("MainConnectionProvider", "Null passed as value to this property which is not allowed.");
                }
                if (_mainConnection != null)
                {
                    if (_mainConnectionIsCreatedLocal)
                    {
                        _mainConnection.Close();
                        _mainConnection.Dispose();
                    }
                    _mainConnection = null;
                }
                _mainConnectionProvider = (ConnectionProvider)value;
                _mainConnection = _mainConnectionProvider.DBConnection;
                _mainConnectionIsCreatedLocal = false;
            }
        }

        public SqlInt32 ErrorCode
        {
            get
            {
                return _errorCode;
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
