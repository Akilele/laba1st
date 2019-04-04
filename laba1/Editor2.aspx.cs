using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Globalization;

namespace laba1
{
    public partial class Editor2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string req = Request.QueryString["id"];
            if (!IsPostBack)
            {
                if (Int32.TryParse(req, out int id))
                {
                    string strConnect = $"Server=MYSQL6001.site4now.net;Database=db_a46ad7_akilele;Uid=a46ad7_akilele;Pwd={pass.Password}";//строка для подключения к БД
                    MySqlConnection dbConn = new MySqlConnection(strConnect);
                    dbConn.Open();
                    string sql = $"SELECT * from history WHERE (id = {id})";
                    MySqlCommand cmd = new MySqlCommand(sql, dbConn);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    rdr.Read();
                    id_visitor.Text = rdr.GetString(1);
                    date.Text = rdr.GetDateTime(2).ToString("dd.MM.yyyy");
                    book_name.Text = rdr.GetString(3);
                    code.Text = Convert.ToString(rdr.GetInt32(4));
                    author.Text = rdr.GetString(5);
                    age.Text = rdr.GetString(6);
                    dbConn.Close();
                }
            }

        }

        protected void apply_Click(object sender, EventArgs e)
        {
            string req = Request.QueryString["id"];
            string strConnect = $"Server=MYSQL6001.site4now.net;Database=db_a46ad7_akilele;Uid=a46ad7_akilele;Pwd={pass.Password}";//строка для подключения к БД
            MySqlConnection dbConn = new MySqlConnection(strConnect);
            dbConn.Open();
            string sql = null;
            DateTime _date = DateTime.ParseExact(date.Text, "dd.MM.yyyy", CultureInfo.CurrentCulture);
            if (Int32.TryParse(req, out int id)) sql = $"UPDATE history SET id = '{id}', id_visitor = '{id_visitor.Text}', date = '{_date.ToString("yyyy-MM-dd")}', book_name = '{book_name.Text}', code = '{code.Text}', author = '{author.Text}', age = '{age.Text}' WHERE id = {id};";
            else sql = $"INSERT INTO history VALUES(null,'{id_visitor.Text}', '{_date.ToString("yyyy-MM-dd")}', '{book_name.Text}', '{code.Text}', '{author.Text}', '{age.Text}')";
            MySqlCommand cmd = new MySqlCommand(sql, dbConn);
            cmd.ExecuteNonQuery();
            dbConn.Close();
            Response.Redirect($"History");
        }
    }
}