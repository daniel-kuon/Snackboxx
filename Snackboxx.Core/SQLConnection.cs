using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Snackboxx.Core
{
    public struct SQLConnObj
    {
        public bool isConnect;
        public Exception exp;
    }

    public struct ParameterObj
    {
        public string name;
        public SqlDbType type;
        public Object value;
    }


    public class DBConnection
    {
        private SqlConnection _sqlconn;
        private SqlConnectionStringBuilder _sqlconnstr;

        public DBConnection()
        {
            _sqlconn = new SqlConnection();
            _sqlconnstr = new SqlConnectionStringBuilder();
        }

        public SQLConnObj Connection(string server, string database, string user, string password)
        {
            SQLConnObj sqlconnobj = new SQLConnObj();
            sqlconnobj.isConnect = false;
            try
            {
                _sqlconn = new SqlConnection();
                _sqlconnstr = new SqlConnectionStringBuilder();
                _sqlconnstr.IntegratedSecurity = false;
                _sqlconnstr.DataSource = server;
                _sqlconnstr.InitialCatalog = database;
                _sqlconnstr.UserID = user;
                _sqlconnstr.Password = password;
                _sqlconn.ConnectionString = _sqlconnstr.ToString();
                _sqlconn.Open();
                sqlconnobj.isConnect = true;
            }
            catch (SqlException sqlexp)
            {
                sqlconnobj.exp = sqlexp;
            }
            return sqlconnobj;
        }

        public void SQLClose()
        {
            if (_sqlconn.State == ConnectionState.Open ||
                _sqlconn.State == ConnectionState.Broken)
                _sqlconn.Close();
        }

        public void SQLOpen()
        {
            if (_sqlconn.State != ConnectionState.Open)
                if (String.IsNullOrEmpty(_sqlconnstr.ConnectionString))
                    _sqlconn.Open();
        }

        public ConnectionState GetState
        {
            get { return _sqlconn.State; }
        }

        public SQLConnObj TestConnection(string server, string database, string user, string password)
        {
            SQLConnObj sqlconnobj = new SQLConnObj();
            sqlconnobj.isConnect = false;
            try
            {
                SqlConnection conn = new SqlConnection();
                SqlConnectionStringBuilder sqlconnstr = new SqlConnectionStringBuilder();
                sqlconnstr.IntegratedSecurity = false;
                sqlconnstr.DataSource = server;
                sqlconnstr.InitialCatalog = database;
                sqlconnstr.UserID = user;
                sqlconnstr.Password = password;

                conn.ConnectionString = sqlconnstr.ToString();

                conn.Open();
                sqlconnobj.isConnect = true;
                conn.Close();
            }
            catch (SqlException sqlexp)
            {
                //MessageBox.Show("SqlConnection Exception: " + sqlexp.Message);
                sqlconnobj.exp = sqlexp;
            }
            return sqlconnobj;
        }

        public SqlDataReader GetResult(string query)
        {
            return GetResult(query, null);
        }

        public SqlDataReader GetResult(string query, List<ParameterObj> parameters)
        {
            SqlDataReader sqldr = null;

            if (this.GetState == ConnectionState.Open)
            {
                SqlCommand sqlcommand = new SqlCommand(query, _sqlconn);
                if (parameters != null)
                {
                    for (int i = 0; i < parameters.Count; ++i)
                    {
                        sqlcommand.Parameters.Add(parameters[i].name, parameters[i].type).Value = parameters[i].value;
                    }
                }
                sqldr = sqlcommand.ExecuteReader();
            }
            else
            {
                throw new Exception("SQLConnection is broken...");
            }
            return sqldr;
        }

        public List<Dictionary<string, string>> GetResultList(string query, List<ParameterObj> parameters)
        {
            SqlDataReader sqldr = this.GetResult(query, parameters);
            List<Dictionary<string, string>> erg = new List<Dictionary<string, string>>();
            while (sqldr.Read())
            {
                Dictionary<string, string> line = new Dictionary<string, string>();
                for (int i = 0; i < sqldr.FieldCount; ++i)
                {
                    line.Add(sqldr.GetName(i), sqldr.GetValue(i).ToString());
                }
                erg.Add(line);
            }
            sqldr.Close();
            return erg;
        }

        public bool DataSetExists(string query, List<ParameterObj> parameters)
        {
            bool exists = false;
            SqlDataReader sqldr = GetResult(query, parameters);
            while (sqldr.Read())
            {
                exists = true;
            }
            sqldr.Close();
            return exists;
        }

        public int Execute(string query)
        {
            return Execute(query, null);
        }

        public int Execute(string query, List<ParameterObj> parameters)
        {
            int res = 0;
            if (this.GetState == ConnectionState.Open)
            {
                SqlCommand sqlcommand = new SqlCommand(query, _sqlconn);
                if (parameters != null)
                {
                    for (int i = 0; i < parameters.Count; ++i)
                    {
                        sqlcommand.Parameters.Add(parameters[i].name, parameters[i].type).Value = parameters[i].value;
                    }
                }
                res = sqlcommand.ExecuteNonQuery();
            }
            else
            {
                throw new Exception("SQLConnection is broken...");
            }
            return res;
        }
    }
}
