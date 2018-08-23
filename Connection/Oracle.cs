using System;
using System.Collections.Generic;
using System.Text;
using Oracle.ManagedDataAccess.Client;
namespace TM.Core.Connection {
    public class Oracle {
        public OracleConnection Connection;
        public Oracle(string ConnectionString = "HNIVNPTBACKAN1") {
            try {
                Connection = new OracleConnection(TM.Core.HttpContext.configuration.GetSection($"ConnectionStrings:{ConnectionString}").Value);
                Connection.Open();
            } catch (System.Exception) { throw; }
        }
        public void Close() {
            try {
                if (Connection != null && Connection.State == System.Data.ConnectionState.Open)
                    Connection.Close();
            } catch (Exception) { throw; }
        }
    }
}