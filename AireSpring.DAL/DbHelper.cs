using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;

namespace AireSpring.DAL
{
    /// <summary>
    /// Class that provides database connectivity
    /// and capabilities to perform minor database
    /// operations.
    /// </summary>
    public class DbHelper
    {
        /// <summary>
        /// global connection instance that allows easy
        /// access to the helpers clients.
        /// </summary>
        protected SqlConnection conn { get; set; }

        /// <summary>
        /// The connection string read in from the app.config and web.config.
        /// </summary>
        protected String ConnectionString { get; set; }

        /// <summary>
        /// Constructor with no parameters. It automatically reads
        /// the connection string from the configuration file.
        /// </summary>
        public DbHelper()
        {
            this.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            conn = Connection(this.ConnectionString);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public SqlConnection Connection(String connectionString)
        {
            this.ConnectionString = connectionString;
            return Connection();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private SqlConnection Connection()
        {
            var tempConn = new SqlConnection(this.ConnectionString);
            return tempConn;
        }

        /// <summary>
        /// 
        /// </summary>
        private void OpenDb()
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void CloseDb()
        {
            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
            conn.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        private DataTable dt;
        private DataSet ds;
        private SqlDataReader dr;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable ExecuteSql(string sql)
        {
            this.OpenDb();
            var cmd = new SqlCommand(sql, conn);
            var da = new SqlDataAdapter(cmd);
            ds = new DataSet("AireSpring");
            da.Fill(ds, "Employees");
            dt = ds.Tables["Employees"];
            return dt;
        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int UpdateSql(string sql)
        {
            OpenDb();
            var cmd = new SqlCommand(sql, conn);
            var count = cmd.ExecuteNonQuery();
            CloseDb();
            return count;
        }

    }
}
