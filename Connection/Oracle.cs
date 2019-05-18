using System;
using System.Collections.Generic;
using System.Text;
using Oracle.ManagedDataAccess.Client;
namespace TM.Core.Connection
{
    public class Oracle : System.IDisposable
    {
        public OracleConnection Connection;
        public Oracle(string ConnectionString = "TTKD_BKN")
        {
            try
            {
                Connection = new OracleConnection(TM.Core.HttpContext.configuration.GetSection($"ConnectionStrings:{ConnectionString}").Value);
                if (Connection != null && Connection.State == System.Data.ConnectionState.Closed)
                    Connection.Open();
                // if (Connection == null)
                // {
                //     Connection.Open();
                // }
                // else
                // {
                //     if (Connection.State == System.Data.ConnectionState.Closed)
                //         Connection.Open();
                // }
            }
            catch (System.Exception) { throw; }
        }
        public void Open()
        {
            try
            {
                if (Connection != null && Connection.State == System.Data.ConnectionState.Closed)
                    Connection.Open();
            }
            catch (Exception) { throw; }
        }
        public void Close()
        {
            try
            {
                if (Connection != null && Connection.State == System.Data.ConnectionState.Open)
                {
                    Connection.Close();
                    Connection.Dispose();
                }
            }
            catch (Exception) { throw; }
        }
        void IDisposable.Dispose()
        {
            if (Connection != null && Connection.State == System.Data.ConnectionState.Open)
            {
                Connection.Close();
                Connection.Dispose();
            }
        }
    }
}