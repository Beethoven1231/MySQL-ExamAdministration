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
            MySqlConnection connection = MySqlHelper.GetConnection();
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
        public ActionResult update(int id, string name, DateTime birthday, int classId )
        {
            try
            {
                MySqlConnection connection = MySqlHelper.GetConnection();
                string sql = string.Format("update new_schema.studenttable set name = '{0}', birthday = '{1}', classId = {2} where (id = {3});", name, birthday, classId, id);
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult insert(string name,DateTime birthday,int classId)
        {
            try
            {
                MySqlConnection connection = MySqlHelper.GetConnection();
                string sql = string.Format("insert into new_schema.studenttable (name, birthday, classId) values('{0}','{1}',{2});", name, birthday, classId);
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult delete(int id)
        {
            try
            {
                MySqlConnection connection = MySqlHelper.GetConnection();
                string sql = string.Format("delete from new_schema.studenttable where(`id` = '{0}');", id);
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
