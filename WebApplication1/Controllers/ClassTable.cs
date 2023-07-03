using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Xml.Linq;
using MySql.Data.MySqlClient;


namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ClassTable : ControllerBase
    {
        private readonly ILogger<ClassTable> _logger;

        public ClassTable(ILogger<ClassTable> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<ClassXinXi> select()
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

            string sql = "select * from classtable;";
            DataSet ds = new DataSet();

            MySqlDataAdapter mda = new MySqlDataAdapter(sql, connection);
            mda.Fill(ds, "classtable");

            List<ClassXinXi> list = new();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                ClassXinXi xx = new();
                xx.id = int.Parse(row["id"].ToString()!);
                xx.grade = Convert.ToDateTime(row["grade"].ToString())!;
                xx.classno = int.Parse(row["classno"].ToString()!);
                xx.schoolId = int.Parse(row["schoolId"].ToString()!);
                list.Add(xx);
            }

            return list;

        }

        [HttpGet]
        public IEnumerable<ClassXinXi> update(int id, DateTime grade, int classno, int schoolId)
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

            string sql = string.Format("update new_schema.classtable set grade = '{0}', classno = {1}, schoolId = {2} where (id = {3});select * from classtable;",grade,classno,schoolId,id);
            DataSet ds = new DataSet();

            MySqlDataAdapter mda = new MySqlDataAdapter(sql, connection);
            mda.Fill(ds, "classtable");

            List<ClassXinXi> list = new();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                ClassXinXi xx = new();
                xx.id = int.Parse(row["id"].ToString()!);
                xx.grade = Convert.ToDateTime(row["grade"].ToString())!;
                xx.classno = int.Parse(row["classno"].ToString()!);
                xx.schoolId = int.Parse(row["schoolId"].ToString()!);
                list.Add(xx);
            }

            return list;

        }

        [HttpGet]
        public IEnumerable<ClassXinXi> insert(DateTime grade, int classno, int schoolId)
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

            string sql = string.Format("insert into new_schema.classtable (grade, classno, schoolId) values('{0}',{1},{2});select * from classtable;", grade, classno, schoolId);
            DataSet ds = new DataSet();

            MySqlDataAdapter mda = new MySqlDataAdapter(sql, connection);
            mda.Fill(ds, "classtable");

            List<ClassXinXi> list = new();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                ClassXinXi xx = new();
                xx.id = int.Parse(row["id"].ToString()!);
                xx.grade = Convert.ToDateTime(row["grade"].ToString())!;
                xx.classno = int.Parse(row["classno"].ToString()!);
                xx.schoolId = int.Parse(row["schoolId"].ToString()!);
                list.Add(xx);
            }

            return list;

        }

        [HttpGet]
        public IEnumerable<ClassXinXi> delete(int id)
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

            string sql = string.Format("delete from new_schema.classtable where(id = {0});select * from classtable;",id);
            DataSet ds = new DataSet();

            MySqlDataAdapter mda = new MySqlDataAdapter(sql, connection);
            mda.Fill(ds, "classtable");

            List<ClassXinXi> list = new();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                ClassXinXi xx = new();
                xx.id = int.Parse(row["id"].ToString()!);
                xx.grade = Convert.ToDateTime(row["grade"].ToString())!;
                xx.classno = int.Parse(row["classno"].ToString()!);
                xx.schoolId = int.Parse(row["schoolId"].ToString()!);
                list.Add(xx);
            }

            return list;

        }
    }
}
