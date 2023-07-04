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
            MySqlConnection connection = MySqlHelper.GetConnection();
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
        public ActionResult update(int id, DateTime grade, int classno, int schoolId)
        {
            try
            {
                MySqlConnection connection = MySqlHelper.GetConnection();
                string sql = string.Format("update new_schema.classtable set grade = '{0}', classno = {1}, schoolId = {2} where (id = {3});", grade, classno, schoolId, id);
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
        public ActionResult insert(DateTime grade, int classno, int schoolId)
        {
            try
            {
                MySqlConnection connection = MySqlHelper.GetConnection();
                string sql = string.Format("insert into new_schema.classtable (grade, classno, schoolId) values('{0}',{1},{2});", grade, classno, schoolId);
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
                string sql = string.Format("delete from new_schema.classtable where(id = {0});", id);
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
