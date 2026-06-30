using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;
using NpgsqlTypes ;
using System.Data;
using System.Data .SqlClient ;
using System.Data.SqlTypes ;
using System.Configuration;
using System.Data.Common;

namespace NIC.WebLMISLibrary
{
    public class DataBaseHandler
    {
        #region " Local Declarations "

        private string _connectionString;
        clsCommonFunction clsobjrollback = new clsCommonFunction();
        #endregion

        #region "    Constructor     "

        // <summary>
        // Initializes a new instance of the ADO.SqlDatabase class.
        // </summary>
        // <param name="connectionString">The connection used to open the postgres Server database.</param>
        public DataBaseHandler()
        {
            _connectionString = (string)System.Configuration.ConfigurationManager.ConnectionStrings[0].ConnectionString.ToString();
    
        }
        public DataBaseHandler(string strConnectingString)
        {
            _connectionString = (string)System.Configuration.ConfigurationManager.ConnectionStrings[strConnectingString].ConnectionString.ToString();
        }
        public DataBaseHandler(string databasename, string strConnectingString)
        {
            _connectionString = databasename.Split('#')[0]+"database = " + databasename.Split('#')[1] + ";" + (string)System.Configuration.ConfigurationManager.ConnectionStrings[strConnectingString].ConnectionString.ToString();
        }
        #endregion
       
        #region "  Command/Parameter "

        public DbCommand SelectCommandText(string TableName, string ColValue, string Condition, string Orderby)
        {
            string cmdText = "select  " + ColValue + " from " + TableName;
            if (Condition != "")
            {
                cmdText = cmdText + " WHERE " + Condition;
            }
            if (Orderby != "")
            {
                cmdText = cmdText + " Order by " + Orderby;
            }
            DbCommand command = this.SetCommandText(cmdText, CommandType.Text);
            return command;
        }
        public DbCommand SelectCommandText1(string TableName, string ColValue, string Condition, string Orderby)
        {
            string cmdText = "select distinct " + ColValue + " from " + TableName;
            if (Condition != "")
            {
                cmdText = cmdText + " WHERE " + Condition;
            }
            if (Orderby != "")
            {
                cmdText = cmdText + " Order by " + Orderby;
            }
            DbCommand command = this.SetCommandText(cmdText, CommandType.Text);
            return command;
        }

        public NpgsqlCommand SetCommandText(string cmdText, CommandType cmdType)
        {
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.CommandText = cmdText;
            cmd.CommandType = cmdType;
            return cmd;
        }

        public void SetInParameter(DbCommand Cmd, string Name, DbType type, object value)
        {
            NpgsqlParameter para = new NpgsqlParameter();
            para.ParameterName = Name;
            para.Direction = ParameterDirection.Input;
            para.DbType = type;
            para.Value = value;
            Cmd.Parameters.Add(para);
        }

        public void SetOutParameter(DbCommand Cmd, string Name, DbType type, int size)
        {
            NpgsqlParameter para = new NpgsqlParameter();
            para.ParameterName = Name;
            para.Direction = ParameterDirection.Output;
            para.DbType = type;
            para.Size = size;
            Cmd.Parameters.Add(para);
        }

        public object GetOutParameterValue(DbCommand Cmd, string ParaName)
        {
            object obj = Cmd.Parameters[ParaName].Value;
            return obj;
        }
        #endregion

        #region "   ExecuteNonQuery  "

        // <summary>
        // Executes a Transact-postgres statement against the connection and returns the number of rows affected.
        // </summary>
        // <param name="cmd">The Transact-postgres statement or stored procedure to execute at the data source.</param>
        // <param name="cmdType">A value indicating how the System.Data.SqlClient.NpgsqlCommand.CommandText property is to be interpreted.</param>
        // <returns>The number of rows affected.</returns>
        public int ExecuteNonQuery(string cmdText, CommandType cmdType)
        {
            NpgsqlConnection connection = null;
            NpgsqlTransaction transaction = null;
            NpgsqlCommand command = null;
            int result = -1;
            try
            {
                connection = new NpgsqlConnection(_connectionString);
                command = new NpgsqlCommand(cmdText, connection);
                command.CommandType = cmdType;
                connection.Open();
                transaction = connection.BeginTransaction();
                command.Transaction = transaction;
                result = command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                if (!(transaction == null))
                    transaction.Rollback();
                throw new DataException(ex.Message, ex.InnerException);


            }
            finally
            {
                if (!(connection == null) && (connection.State == ConnectionState.Open))
                    connection.Close();
                if (!(command == null))
                    command.Dispose();
                if (!(transaction == null))
                    transaction.Dispose();
            }
            return result;
        }

        // <summary>
        // Executes a Transact-postgres statement against the connection and returns the number of rows affected.
        // </summary>
        // <param name="cmd">The Transact-postgres statement or stored procedure to execute at the data source.</param>
        // <param name="cmdType">A value indicating how the System.Data.SqlClient.NpgsqlCommand.CommandText property is to be interpreted.</param>
        // <param name="parameters">The parameters of the Transact-postgres statement or stored procedure.</param>
        // <returns>The number of rows affected.</returns>
        public int ExecuteNonQuery(DbCommand  Command)
        {
            NpgsqlConnection connection = null;
            NpgsqlTransaction transaction = null;
            NpgsqlCommand command = (NpgsqlCommand)Command;
            int result = -1;
            try
            {
                connection = new NpgsqlConnection(_connectionString);
                command.Connection = connection;
                connection.Open();
                Command.CommandTimeout = 1200 * 1200;
                transaction = connection.BeginTransaction();
                command.Transaction = transaction;
                result = command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                if (!(transaction == null))
                    transaction.Rollback();
                throw new DataException(ex.Message, ex.InnerException);
            }
            finally
            {
                if (!(connection == null) && (connection.State == ConnectionState.Open))
                    connection.Close();
                if (!(command == null))
                    command.Dispose();
                if (!(transaction == null))
                    transaction.Dispose();
            }
            return result;
        }



        public long ExecuteNonQuery_long(DbCommand Command)
        {
            NpgsqlConnection connection = null;
            NpgsqlTransaction transaction = null;
            NpgsqlCommand command = (NpgsqlCommand)Command;
            int result = -1;
            try
            {
                connection = new NpgsqlConnection(_connectionString);
                command.Connection = connection;
                connection.Open();
                Command.CommandTimeout = 1200 * 1200;
                transaction = connection.BeginTransaction();
                command.Transaction = transaction;
                result = (int)command.ExecuteScalar();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                if (!(transaction == null))
                    transaction.Rollback();
                throw new DataException(ex.Message, ex.InnerException);
            }
            finally
            {
                if (!(connection == null) && (connection.State == ConnectionState.Open))
                    connection.Close();
                if (!(command == null))
                    command.Dispose();
                if (!(transaction == null))
                    transaction.Dispose();
            }
            return result;
        }

        #endregion
        public int ExecuteNonQueryT(DbCommand Command)
        {
           
            int result = -1;
            try
            {           
             
                result = Command.ExecuteNonQuery();
               
            }
            catch (Exception ex)
            {
                
                throw new DataException(ex.Message, ex.InnerException);
            }
           
            return result;
        }
    
        
        #region "    ExecuteScalar   "

        // <summary>
        // Executes the query, and returns the first column of the first row in the result set returned by the query. Additional columns or rows are ignored.
        // </summary>
        // <param name="cmd">The Transact-postgres statement or stored procedure to execute at the data source.</param>
        // <param name="cmdType">A value indicating how the System.Data.SqlClient.NpgsqlCommand.CommandText property is to be interpreted.</param>
        // <param name="parameters">The parameters of the Transact-postgres statement or stored procedure.</param>
        // <returns>The first column of the first row in the result set, or a null reference if the result set is empty.</returns>
        public int ExecuteScalar(DbCommand Command)
        {
            NpgsqlConnection connection = null;
            NpgsqlTransaction transaction = null;
            NpgsqlCommand command = (NpgsqlCommand )Command;
            int result = -1;
            try
            {
                connection = new NpgsqlConnection(_connectionString);
                command.Connection = connection;
                connection.Open();
                transaction = connection.BeginTransaction();
                command.Transaction = transaction;
                result = Convert.ToInt32 (command.ExecuteScalar());
                transaction.Commit();
            }
            catch (Exception ex)
            {
                if (!(transaction == null))
                    transaction.Rollback();
                throw new DataException(ex.Message, ex.InnerException);
            }
            finally
            {
                if (!(connection == null) && (connection.State == ConnectionState.Open))
                    connection.Close();
                if (!(command == null))
                    command.Dispose();
                if (!(transaction == null))
                    transaction.Dispose();
            }
            return result;
        }

        public String ExecuteScalarstring(DbCommand Command)
        {
            NpgsqlConnection connection = null;
            NpgsqlTransaction transaction = null;
            NpgsqlCommand command = (NpgsqlCommand)Command;
            String result = null;
            try
            {
                connection = new NpgsqlConnection(_connectionString);
                command.Connection = connection;
                connection.Open();
                transaction = connection.BeginTransaction();
                command.Transaction = transaction;
                result = Convert.ToString(command.ExecuteScalar());
                transaction.Commit();
            }
            catch (Exception ex)
            {
                if (!(transaction == null))
                    transaction.Rollback();
                throw new DataException(ex.Message, ex.InnerException);
            }
            finally
            {
                if (!(connection == null) && (connection.State == ConnectionState.Open))
                    connection.Close();
                if (!(command == null))
                    command.Dispose();
                if (!(transaction == null))
                    transaction.Dispose();
            }
            return result;
        }
     

        #endregion
        
        #region "   ExecuteDataSet   "

        /// <summary> 
        /// Calls the respective INSERT, UPDATE, or DELETE statements for each inserted, updated, or deleted row in the System.Data.DataSet with the specified System.Data.DataTable name. 
        /// </summary> 
        /// <param name="insertCmd">A command used to insert new records into the data source.</param> 
        /// <param name="updateCmd">A command used to update records in the data source.</param> 
        /// <param name="deleteCmd">A command for deleting records from the data set.</param> 
        /// <param name="ds">The System.Data.DataSet to use to update the data source. </param> 
        /// <param name="srcTable">The name of the source table to use for table mapping.</param> 
        /// <returns>The number of rows successfully updated from the System.Data.DataSet.</returns> 
        public DataSet  FillDataset(DbCommand  Command)
        {
            NpgsqlConnection connection = null;
            NpgsqlDataAdapter sqlAdapter = null;
            NpgsqlTransaction transaction = null;
            DataSet resultDataSet = new DataSet();         
            try
            {
                connection = new NpgsqlConnection(_connectionString);
                connection.Open();
                transaction = connection.BeginTransaction();
                sqlAdapter = new NpgsqlDataAdapter();
                sqlAdapter.SelectCommand = (NpgsqlCommand)Command;
                sqlAdapter.SelectCommand.Connection = connection;
                sqlAdapter.Fill(resultDataSet);
                transaction.Commit();
                connection.Close();
                
            }
            catch (Exception ex)
            {
                throw new DataException(ex.Message, ex.InnerException);
            }
            finally
            {
                //if (!(connection == null) && (connection.State == ConnectionState.Open))
                //    connection.Close();
                //if (!(Command == null))
                //    Command.Dispose();
                //if (!(sqlAdapter == null))
                //    sqlAdapter.Dispose();
                //if (!(transaction == null))
                //    transaction.Dispose();
            }
            return resultDataSet;
        }

        public DbDataReader GetDataReader(DbCommand Command)
        {
            NpgsqlConnection connection = null;
            DbDataReader  datareader = null;
            NpgsqlTransaction transaction = null;
            DataSet resultDataSet = new DataSet();
            try
            {
                connection = new NpgsqlConnection(_connectionString);
                connection.Open();
                transaction = connection.BeginTransaction();
                Command.Connection = connection;
                datareader = Command.ExecuteReader();
                transaction.Commit();
                connection.Close();
                return datareader;
            }
            catch (Exception ex)
            {
                throw new DataException(ex.Message, ex.InnerException);
            }
            finally
            {
                if (!(connection == null) && (connection.State == ConnectionState.Open))
                    connection.Close();
                if (!(Command == null))
                    Command.Dispose();
               if (!(transaction == null))
                    transaction.Dispose();
            }
        }
        public DbDataAdapter GetDbDataAdapter(string Command)
        {
            NpgsqlConnection connection = null;
            DbDataAdapter DbDataAdapter = null;
            NpgsqlTransaction transaction = null;
           
            try
            {
                connection = new NpgsqlConnection(_connectionString);
                connection.Open();
                DbDataAdapter=new NpgsqlDataAdapter(Command , connection);
                return DbDataAdapter;
            }
            catch (Exception ex)
            {
                throw new DataException(ex.Message, ex.InnerException);
            }
            finally
            {
             
            }
        }

        #endregion

        #region  "  Select Statement  "

        public NpgsqlCommand SelectCommandText(string tablename, string fieldname, string condition, CommandType cmdType)
        {
            NpgsqlCommand cmd = new NpgsqlCommand();
            string cmdText = "select  " + fieldname + " from " + tablename;
            if (condition != "")
            {
                cmdText = cmdText + " WHERE " + condition;
            }
            cmd.CommandText = cmdText;
            cmd.CommandType = cmdType;
            return cmd;
        }

        #endregion

        internal double ExecuteScalardouble(DbCommand dbCommand)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        internal DataTable FillDataTable(DbCommand Command)
        {

            NpgsqlConnection connection = null;
            NpgsqlDataAdapter sqlAdapter = null;
            NpgsqlTransaction transaction = null;
            DataTable resultDataTable = new DataTable();
            try
            {
                connection = new NpgsqlConnection(_connectionString);
                connection.Open();
                transaction = connection.BeginTransaction();
                sqlAdapter = new NpgsqlDataAdapter();
                sqlAdapter.SelectCommand = (NpgsqlCommand)Command;
                sqlAdapter.SelectCommand.Connection = connection;
                sqlAdapter.Fill(resultDataTable);
                transaction.Commit();
                connection.Close();

            }
            catch (Exception ex)
            {
                throw new DataException(ex.Message, ex.InnerException);
            }
            finally
            {
                //if (!(connection == null) && (connection.State == ConnectionState.Open))
                //    connection.Close();
                //if (!(Command == null))
                //    Command.Dispose();
                //if (!(sqlAdapter == null))
                //    sqlAdapter.Dispose();
                //if (!(transaction == null))
                //    transaction.Dispose();
            }
            return resultDataTable;
        }

        public string ExecuteScalarString(DbCommand Command)
        {
            NpgsqlConnection connection = null;
            NpgsqlTransaction transaction = null;
            NpgsqlCommand command = (NpgsqlCommand)Command;
            string result = "";
            try
            {
                connection = new NpgsqlConnection(_connectionString);
                command.Connection = connection;
                connection.Open();
                transaction = connection.BeginTransaction();
                command.Transaction = transaction;
                result = Convert.ToString(command.ExecuteScalar());
                transaction.Commit();
            }
            catch (Exception ex)
            {
                if (!(transaction == null))
                    transaction.Rollback();
                throw new DataException(ex.Message, ex.InnerException);
            }
            finally
            {
                if (!(connection == null) && (connection.State == ConnectionState.Open))
                    connection.Close();
                if (!(command == null))
                    command.Dispose();
                if (!(transaction == null))
                    transaction.Dispose();
            }
            return result;
        }

        //public string ExecuteScalarString(DbCommand dbCmd)
        //{
        //    throw new Exception("The method or operation is not implemented.");
        //}
    }
}

       