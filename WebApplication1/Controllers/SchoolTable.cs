using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Xml.Linq;
using MySql.Data.MySqlClient;


namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SchoolTable : ControllerBase
    {
        private readonly ILogger<SchoolTable> _logger;

        public SchoolTable(ILogger<SchoolTable> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<SchoolXinXi> select()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            MySqlConnection connection;
            // �����û�����
            builder.UserID = "root";
            // �����û�����
            builder.Password = "123456";
            // ������(����)
            builder.Server = "localhost";
            builder.Database = "new_schema";
            connection = new MySqlConnection(builder.ConnectionString);
            //�����ݿ�����
            connection.Open();

            string sql = "select * from schooltable;";
            DataSet ds = new DataSet();

            MySqlDataAdapter mda = new MySqlDataAdapter(sql, connection);
            mda.Fill(ds, "schooltable");

            List<SchoolXinXi> list = new();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                SchoolXinXi xx = new();
                xx.id = int.Parse(row["id"].ToString()!);
                xx.name = row["name"].ToString()!;
                list.Add(xx);
            }

            return list;

        }
    
        [HttpGet]
        public IEnumerable<SchoolXinXi> update(int id, string name)
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            MySqlConnection connection;
            // �����û�����
            builder.UserID = "root";
            // �����û�����
            builder.Password = "123456";
            // ������(����)
            builder.Server = "localhost";
            builder.Database = "new_schema";
            connection = new MySqlConnection(builder.ConnectionString);
            //�����ݿ�����
            connection.Open();

            string sql = string.Format("update new_schema.schooltable set name = {1} where (id = {0}); select * from schooltable;",id,name);
            DataSet ds = new DataSet();

            MySqlDataAdapter mda = new MySqlDataAdapter(sql, connection);
            mda.Fill(ds, "schooltable");

            List<SchoolXinXi> list = new();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                SchoolXinXi xx = new();
                xx.id = int.Parse(row["id"].ToString()!);
                xx.name = row["name"].ToString()!;
                list.Add(xx);
            }

            return list;
        }

        [HttpGet]
        public IEnumerable<SchoolXinXi> insert(string name)
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            MySqlConnection connection;
            // �����û�����
            builder.UserID = "root";
            // �����û�����
            builder.Password = "123456";
            // ������(����)
            builder.Server = "localhost";
            builder.Database = "new_schema";
            connection = new MySqlConnection(builder.ConnectionString);
            //�����ݿ�����
            connection.Open();

            string sql = string.Format("insert into new_schema.schooltable (name) values('{0}'); select * from schooltable;",name);
            DataSet ds = new DataSet();

            MySqlDataAdapter mda = new MySqlDataAdapter(sql, connection);
            mda.Fill(ds, "schooltable");

            List<SchoolXinXi> list = new();
            
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                SchoolXinXi xx = new();
                xx.id = int.Parse(row["id"].ToString()!);
                xx.name = row["name"].ToString()!;
                list.Add(xx);
            }

            return list;
        
        }

        [HttpGet]
        public IEnumerable<SchoolXinXi> delete(int id)
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            MySqlConnection connection;
            // �����û�����
            builder.UserID = "root";
            // �����û�����
            builder.Password = "123456";
            // ������(����)
            builder.Server = "localhost";
            builder.Database = "new_schema";
            connection = new MySqlConnection(builder.ConnectionString);
            //�����ݿ�����
            connection.Open();

            string sql = string.Format("delete from new_schema.schooltable where (id = {0}); select * from schooltable", id);
            DataSet ds = new DataSet();

            MySqlDataAdapter mda = new MySqlDataAdapter(sql, connection);
            mda.Fill(ds, "schooltable");

            List<SchoolXinXi> list = new();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                SchoolXinXi xx = new();
                xx.id = int.Parse(row["id"].ToString()!);
                xx.name = row["name"].ToString()!;
                list.Add(xx);
            }

            return list;

        }
        
    }
}