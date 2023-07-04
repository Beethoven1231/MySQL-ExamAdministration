using MySql.Data.MySqlClient;

namespace WebApplication1.Controllers
{
    public class MySqlHelper
    {
        public static MySqlConnection GetConnection()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            MySqlConnection connection;
            // 用户名称
            builder.UserID = "root";
            // 用户密码
            builder.Password = "123456";
            // 服务器
            builder.Server = "120.55.93.5";
            builder.Database = "new_schema";
            connection = new MySqlConnection(builder.ConnectionString);
            //打开数据库连接
            connection.Open();
            return connection;
        }
    }
}
