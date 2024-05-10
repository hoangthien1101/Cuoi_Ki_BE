using Microsoft.Data.SqlClient;
using System.Data;

namespace TNN.DataReader
{
    public class DataBase
    {

        public class Database
        {
            private string connectString =
                "Data Source=GE_G5\\SQLEXPRESS;Initial Catalog=CuaHangDienLanh;Integrated Security=True";

            private SqlConnection conn;
            private DataTable dt;
            private SqlCommand cmd;

            public Database()
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
            public DataTable SelectTable(string sql, List<CustomParameter> paras)
            {
                try
                {
                    conn.Open();
                    cmd = new SqlCommand(sql, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (var para in paras)
                    {
                        cmd.Parameters.AddWithValue(para.key, para.value);
                    }
                    dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    return dt;
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
            public DataRow Select(string sql)
            {
                try
                {
                    conn.Open();
                    cmd = new SqlCommand(sql, conn);
                    dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    return dt.Rows[0];
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
            public int ExeCute(string sql, List<CustomParameter> lstPara)
            {
                try
                {
                    conn.Open();
                    cmd = new SqlCommand(sql, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (var p in lstPara)
                    {
                        cmd.Parameters.AddWithValue(p.key, p.value);
                    }
                    var rs = cmd.ExecuteNonQuery();
                    return (int)rs;
                }
                catch (Exception ex)
                {
                    return -100;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }

}

