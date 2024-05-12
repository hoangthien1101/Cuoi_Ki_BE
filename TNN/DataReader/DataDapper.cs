using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace TNN.DataReader
{
    public class DataDapper
    {
        private string connectString =
            "Data Source=GE_G5\\SQLEXPRESS;Initial Catalog=CuaHangDienLanh;Integrated Security=True;TrustServerCertificate=True";
        private SqlConnection conn;
        private DataTable dt;
        private SqlCommand cmd;

        public DataDapper()
        {
            try
            {
                conn = new SqlConnection(connectString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Execute(string sql, object param = null, CommandType? commandType = null)
        {
            using (var connection = new SqlConnection(connectString))
            {
                connection.Open();
                var affectedRows = connection.Execute(sql, param, commandType: commandType);
                Console.WriteLine($"Số hàng bị ảnh hưởng: {affectedRows}");
                return affectedRows;
            }
        }
        public IEnumerable<T> Select<T>(string sql, object paras)
        {
            try
            {
                conn.Open();
                return conn.Query<T>(sql, paras, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
