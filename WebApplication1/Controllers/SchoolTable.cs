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
            MySqlConnection connection = MySqlHelper.GetConnection();
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
        public ActionResult update(int id, string name)
        {
            try
            {
                MySqlConnection connection = MySqlHelper.GetConnection();
                string sql = string.Format("update new_schema.schooltable set name = {1} where (id = {0});", id, name);
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
        public ActionResult insert(string name)
        {
            try
            {
                MySqlConnection connection = MySqlHelper.GetConnection();
                string sql = string.Format("insert into new_schema.schooltable (name) values('{0}');", name);
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
        public ActionResult delete(int id)
        {
            try
            {
                MySqlConnection connection = MySqlHelper.GetConnection();
                string sql = string.Format("delete from new_schema.schooltable where (id = {0});", id);
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