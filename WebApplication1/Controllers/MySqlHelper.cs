using MySql.Data.MySqlClient;

namespace WebApplication1.Controllers
{
    public class MySqlHelper
    {
        public static MySqlConnection GetConnection()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            MySqlConnection connection;
            // 本机用户名称
            builder.UserID = "root";
            // 本机用户密码
            builder.Password = "123456";
            // 服务器(本机)
            builder.Server = "localhost";
            builder.Database = "new_schema";
            connection = new MySqlConnection(builder.ConnectionString);
            //打开数据库连接
            connection.Open();
            return connection;
        }
    }
}
