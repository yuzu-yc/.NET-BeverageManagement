using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BeverageManagement
{
    public sealed class DBOperator : IDisposable
    {
        private static readonly Lazy<DBOperator> lazy =
            new Lazy<DBOperator>(() => new DBOperator());
        //延迟加载
        public static DBOperator Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        private DBOperator()
        {
            // 使用SQL Server连接字符串
            conn = new SqlConnection(connString);
        }

        private string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\BeverageManagement\BeverageManagment.mdf;
Integrated Security=True;Connect Timeout=30";
        private SqlConnection conn;

        // 连接数据库
        public void ConnectDB()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("连接数据库失败: " + e.Message);
            }
        }

        // 关闭数据库连接
        public void CloseDB()
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("关闭数据库失败: " + e.Message);
            }
        }

   

       

        // 使用参数化查询来防止 SQL 注入
        public DataTable TableQueryWithParams(string queryStr, SqlParameter[] parameters)
        {
            ConnectDB();  // 确保已连接到数据库
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddRange(parameters);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public int TableExecuteWithParams(string queryStr, SqlParameter[] parameters)
        {
            ConnectDB();  // 确保已连接到数据库
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddRange(parameters);
            int rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected;
        }



        /*----用户相关操作----*/
        public bool UserExists(string username)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@username", SqlDbType.VarChar) { Value = username }
            };

            DataTable dt = TableQueryWithParams("SELECT * FROM user_info WHERE username = @username", parameters);
            return dt.Rows.Count > 0;
        }

        // 显式释放资源
        public void Dispose()
        {
            CloseDB();
        }
    }
}
