using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Aiguilleur.Connection
{
    public class DBConnection
    {
        private string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\KIADY\Documents\S6\Tahina - projets S6\C#\Aiguilleur\Aiguilleur\App_Data\aiguilleur.mdf;Integrated Security=True";
        SqlConnection SQLServerCon;

        public DBConnection()
        {
        }

        public void ExecuteQueries(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, SQLServerCon);
            cmd.ExecuteNonQuery();
        }

        public SqlConnection getCon()
        {

            return this.SQLServerCon; 
        }

        public void OpenConnection()
        {
            SQLServerCon = new SqlConnection(cs);
            SQLServerCon.Open();
        }

        public void CloseConnection()
        {
            SQLServerCon.Close();
        }

        public DbCommand CreateCommand()
        {
            DbCommand cmd = SQLServerCon.CreateCommand();
            return cmd;
        }
    
        public DbDataReader DataReader(string query)
        {
            DbCommand cmd = SQLServerCon.CreateCommand();
            cmd.CommandText = query;
            DbDataReader dr = cmd.ExecuteReader();
            return dr;
        }

        public DbTransaction BeginTrans()
        {
            DbTransaction trans = SQLServerCon.BeginTransaction();
            return trans;
        }
    }
}