using System;
using System.Collections.Generic;
using System.Text;

namespace TM.Core.Connection {
    public class SQLServer {
        public System.Data.SqlClient.SqlConnection Connection;
        public SQLServer(string ConnectionString = "Maincontext") {
            try {
                Connection = new System.Data.SqlClient.SqlConnection(TM.Core.HttpContext.configuration.GetSection($"ConnectionStrings:{ConnectionString}").Value);
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
        public static Result getPaginationQuery(Pagination page) {
            page.select = string.IsNullOrEmpty(page.select) ? "*" : page.select;
            page.column = string.IsNullOrEmpty(page.column) ? "id" : page.column;
            page.direction = string.IsNullOrEmpty(page.direction) ? "DESC" : page.direction;
            page.limit = page.limit > 0 ? page.limit : 10;
            page.page = page.page > 0 ? page.page : 1;
            var strFilter = "";
            if (!string.IsNullOrEmpty(page.filter)) {
                strFilter = "WHERE (";
                foreach (var item in page.filterColumn)
                    strFilter += $"{item} LIKE N'%{page.filter}%' OR ";
                if (string.IsNullOrEmpty(page.where)) strFilter = strFilter.Substring(0, strFilter.Length - 4) + ")";
            }
            if (string.IsNullOrEmpty(page.where)) page.where = "";
            else page.where = (string.IsNullOrEmpty(page.filter) ? "WHERE " : " AND ") + page.where;
            // 
            page.where = strFilter + page.where;
            var total = $"SELECT count(*) FROM {page.table} {page.where}";
            var data = $"SELECT {page.select} FROM {page.table} {page.where} ORDER BY {page.column} {page.direction} OFFSET {page.limit} * ({page.page} - 1) ROWS FETCH NEXT {page.limit} ROWS ONLY";
            return new Result { Data = data, Total = total };
        }
        public partial class Pagination {
            public string table { get; set; }
            public string select { get; set; }
            public string where { get; set; }
            public string[] filterColumn { get; set; }
            public string filter { get; set; }
            public int total { get; set; }
            public int page { get; set; }
            public int offset { get; set; }
            public int limit { get; set; }
            public string column { get; set; }
            public string direction { get; set; }
        }
        public partial class Result {
            public string Total { get; set; }
            public string Data { get; set; }
        }
    }
}