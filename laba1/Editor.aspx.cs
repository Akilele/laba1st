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
    public partial class Editor : System.Web.UI.Page
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
                    string sql = $"SELECT * from visitor WHERE (id = {id})";
                    MySqlCommand cmd = new MySqlCommand(sql, dbConn);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    rdr.Read();
                    fio.Text = rdr.GetString(1);
                    number.Text = Convert.ToString(rdr.GetInt32(2));
                    date.Text = rdr.GetDateTime(3).ToString("dd.MM.yyyy");
                    gender.SelectedIndex = rdr.GetInt32(4);
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
            DateTime birth = DateTime.ParseExact(date.Text, "dd.MM.yyyy", CultureInfo.CurrentCulture);
            if (Int32.TryParse(req, out int id)) sql = $"UPDATE visitor SET fio = '{fio.Text}', ticket_number = '{number.Text}', birth = '{birth.ToString("yyyy-MM-dd")}', gender = '{gender.SelectedValue}' WHERE id = {id}";
            else sql = $"INSERT INTO visitor VALUES(null,'{fio.Text}','{number.Text}', '{birth.ToString("yyyy-MM-dd")}','{gender.SelectedValue}')";
            MySqlCommand cmd = new MySqlCommand(sql, dbConn);
            cmd.ExecuteNonQuery();
            dbConn.Close();

        }
    }
}