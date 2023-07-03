using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Xml.Linq;
using MySql.Data.MySqlClient;


namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class StudentTable : ControllerBase
    {
        private readonly ILogger<StudentTable> _logger;

        public StudentTable(ILogger<StudentTable> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<StudentXinXi> select()
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

            string sql = "select * from studenttable;";
            DataSet ds = new DataSet();

            MySqlDataAdapter mda = new MySqlDataAdapter(sql, connection);
            mda.Fill(ds, "studenttable");

            List<StudentXinXi> list = new();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                StudentXinXi xx = new();
                xx.id = int.Parse(row["id"].ToString()!);
                xx.name = row["name"].ToString()!;
                xx.birthday = Convert.ToDateTime(row["birthday"].ToString())!;
                xx.classId = int.Parse(row["classId"].ToString()!);
                list.Add(xx);
            }

            return list;

        }

        [HttpGet]
        public IEnumerable<StudentXinXi> update(int id, string name, DateTime birthday, int classId )
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

            string sql = string.Format("update new_schema.studenttable set name = '{0}', birthday = '{1}', classId = {2} where (id = {3}); select * from studenttable;",name,birthday,classId,id);
            DataSet ds = new DataSet();

            MySqlDataAdapter mda = new MySqlDataAdapter(sql, connection);
            mda.Fill(ds, "studenttable");

            List<StudentXinXi> list = new();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                StudentXinXi xx = new();
                xx.id = int.Parse(row["id"].ToString()!);
                xx.name = row["name"].ToString()!;
                xx.birthday = Convert.ToDateTime(row["birthday"].ToString())!;
                xx.classId = int.Parse(row["classId"].ToString()!);
                list.Add(xx);
            }

            return list;

        }

        [HttpGet]
        public IEnumerable<StudentXinXi> insert(string name,DateTime birthday,int classId)
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

            string sql = string.Format("insert into new_schema.studenttable (name, birthday, classId) values('{0}','{1}',{2});select * from studenttable;",name,birthday,classId);
            DataSet ds = new DataSet();

            MySqlDataAdapter mda = new MySqlDataAdapter(sql, connection);
            mda.Fill(ds, "studenttable");

            List<StudentXinXi> list = new();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                StudentXinXi xx = new();
                xx.id = int.Parse(row["id"].ToString()!);
                xx.name = row["name"].ToString()!;
                xx.birthday = Convert.ToDateTime(row["birthday"].ToString())!;
                xx.classId = int.Parse(row["classId"].ToString()!);
                list.Add(xx);
            }

            return list;

        }

        [HttpGet]
        public IEnumerable<StudentXinXi> delete(int id)
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

            string sql = string.Format("delete from new_schema.studenttable where(`id` = '{0}');select * from studenttable;",id);
            DataSet ds = new DataSet();

            MySqlDataAdapter mda = new MySqlDataAdapter(sql, connection);
            mda.Fill(ds, "studenttable");

            List<StudentXinXi> list = new();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                StudentXinXi xx = new();
                xx.id = int.Parse(row["id"].ToString()!);
                xx.name = row["name"].ToString()!;
                xx.birthday = Convert.ToDateTime(row["birthday"].ToString())!;
                xx.classId = int.Parse(row["classId"].ToString()!);
                list.Add(xx);
            }

            return list;

        }
    }
}
