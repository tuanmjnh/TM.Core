using System;
using System.Collections.Generic;
using System.Text;

namespace TM.Core.Connection {
    public class SQLServer {
        public System.Data.SqlClient.SqlConnection Connection;
        public SQLServer(string ConnectionString = "Maincontext") {
            try {
                Connection = new System.Data.SqlClient.SqlConnection(TM.Core.HttpContext.Current.configuration.GetSection($"ConnectionStrings:{ConnectionString}").Value);
                Connection.Open();
            } catch (System.Exception) { throw; }
        }
        public void Close() {
            try {
                if (Connection != null && Connection.State == System.Data.ConnectionState.Open) {
                    Connection.Close();
                    Connection.Dispose();
                }
            } catch (Exception) { throw; }
        }
    }
}