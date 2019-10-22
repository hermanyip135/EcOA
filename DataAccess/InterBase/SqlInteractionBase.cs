using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using SqlDatabase;

namespace DataAccess
{
    /// <summary>
    /// 数据库操作抽象类
    /// </summary>
    public abstract class SqlInteractionBase : IDisposable, ICommonDBAccess
    {
        #region Class Member Declarations
        protected SqlConnection _mainConnection, _mainConnection2;
        protected int _rowsAffected;
        protected SqlInt32 _errorCode;
        protected bool _mainConnectionIsCreatedLocal;
        protected ConnectionProvider _mainConnectionProvider;
        private bool _isDisposed;

        private SqlDataReader Dr = null;
        private byte[] Po;//图片
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

        #region InitClass M_20150923：连接二级OR楼盘信息
        //private void InitClassSecondOR()
        //{
        //    _mainConnection2 = new SqlConnection();
        //    _mainConnectionIsCreatedLocal = true;
        //    _mainConnectionProvider = null;
        //    AppSettingsReader _configReader = new AppSettingsReader();

        //    _mainConnection2.ConnectionString =
        //        _configReader.GetValue("Main.ConnectionSecond", typeof(string)).ToString();
        //    _errorCode = (int)DBError.AllOk;
        //    _isDisposed = false;
        //}
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

        #region ICommonDBAccess接口
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



        protected DataSet RunSQLSecondOR(string sSql) //M_20150923：查询二级OR楼盘信息
        {
            SqlCommand cmdToExecute = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);
            DataSet ds = new DataSet();

            cmdToExecute.CommandText = sSql;
            cmdToExecute.CommandType = CommandType.Text;
            cmdToExecute.CommandTimeout = 3600;

            try
            {
                _mainConnection2 = new SqlConnection();
                AppSettingsReader _configReader = new AppSettingsReader();
                _mainConnection2.ConnectionString = _configReader.GetValue("Main.ConnectionSecondOR", typeof(string)).ToString();

                cmdToExecute.Connection = _mainConnection2;
                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection2.Open();
                }
                else
                {
                    if (_mainConnectionProvider.IsTransactionPending)
                    {
                        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                    }
                }

                adapter.Fill(ds);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection2.Close();
                }

                cmdToExecute.Dispose();

                adapter.Dispose();
            }

            return ds;
        }

        
        protected bool RunNoneSQL(string sSql)
        {
            SqlCommand cmdToExecute = new SqlCommand() { CommandText = sSql, CommandType = CommandType.Text };

            try
            {
                cmdToExecute.Connection = _mainConnection;
                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Open();
                    cmdToExecute.Transaction = _mainConnection.BeginTransaction();
                }
                else
                {
                    if (_mainConnectionProvider.IsTransactionPending)
                    {
                        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                    }
                }

                int rowCount = cmdToExecute.ExecuteNonQuery();
                if (_mainConnectionIsCreatedLocal)
                {
                    cmdToExecute.Transaction.Commit();
                }
                if (rowCount > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Close();
                }

                cmdToExecute.Dispose();
            }

        }

        protected DataSet RunSQL(string sSql)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);
            DataSet ds = new DataSet();

            cmdToExecute.CommandText = sSql;
            cmdToExecute.CommandType = CommandType.Text;
            cmdToExecute.CommandTimeout = 3600;

            try
            {
                cmdToExecute.Connection = _mainConnection;
                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Open();
                }
                else
                {
                    if (_mainConnectionProvider.IsTransactionPending)
                    {
                        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                    }
                }

                adapter.Fill(ds);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Close();
                }

                cmdToExecute.Dispose();

                adapter.Dispose();
            }

            return ds;
        }

        public byte[] GetPhotos(string sSql)
        {
            SqlCommand cmdToExecute = new SqlCommand();

            cmdToExecute.CommandText = sSql;
            cmdToExecute.CommandType = CommandType.Text;
            cmdToExecute.CommandTimeout = 3600;
            try
            {
                
                cmdToExecute.Connection = _mainConnection;
                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Open();
                }
                else
                {
                    if (_mainConnectionProvider.IsTransactionPending)
                    {
                        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                    }
                }
                Dr = cmdToExecute.ExecuteReader();
                while (Dr.Read())
                {
                    Po = new byte[Dr.GetBytes(0, 0, null, 0, Int32.MaxValue)];
                    Dr.GetBytes(0, 0, Po, 0, Po.Length);
                    break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
                Dr.Dispose();
            }
            return Po;
        }

        protected int RunCountSQL(string sSql)
        {
            SqlCommand cmdToExecute = new SqlCommand() { CommandText = sSql, CommandType = CommandType.Text };

            try
            {
                cmdToExecute.Connection = _mainConnection;
                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Open();
                    cmdToExecute.Transaction = _mainConnection.BeginTransaction();
                }
                else
                {
                    if (_mainConnectionProvider.IsTransactionPending)
                    {
                        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                    }
                }

                int count = int.Parse(cmdToExecute.ExecuteScalar().ToString());
                if (_mainConnectionIsCreatedLocal)
                {
                    cmdToExecute.Transaction.Commit();
                }

                return count;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    _mainConnection.Close();
                }

                cmdToExecute.Dispose();
            }

        }
    }
}
