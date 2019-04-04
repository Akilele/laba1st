using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace laba1
{

    public partial class _History : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strConnect = $"Server=MYSQL6001.site4now.net;Database=db_a46ad7_akilele;Uid=a46ad7_akilele;Pwd={pass.Password}";//строка для подключения к БД
            MySqlConnection dbConn = new MySqlConnection(strConnect);
            dbConn.Open();
            var req = Request.QueryString["id"];
            string sql = "";
            if (Int32.TryParse(req, out int id))
            {
                sql = $"SELECT history.*, visitor.fio FROM history join visitor on  history.id_visitor = visitor.id WHERE id_visitor = {id}";
            }
            else
            {
                sql = "SELECT history.*, visitor.fio FROM history join visitor on  history.id_visitor = visitor.id";
            }
            MySqlCommand cmd = new MySqlCommand(sql, dbConn);
            DataTable newTable = createDataTableTemplate(); //создаем таблицу, в которую будем записывать результат запроса
            MySqlDataReader rdr = cmd.ExecuteReader();//выполняем запрос и записываем результат в массив
            while (rdr.Read())
            {
                DataRow newRow = newTable.NewRow();
                newRow["id"] = rdr.GetInt32(0);
                newRow["id_visitor"] = rdr.GetString(7);
                newRow["date"] = rdr.GetDateTime(2).ToString("dd.MM.yyyy");
                newRow["book_name"] = rdr.GetString(3);
                newRow["code"] = rdr.GetInt32(4);
                newRow["author"] = rdr.GetString(5);
                newRow["age"] = rdr.GetInt32(6);
                newTable.Rows.Add(newRow);//добавление в таблицу строки с результатом запроса
            }
            rdr.Close();
            dbConn.Close();//закрываем соединение
            GridView2.DataSource = newTable;//присваиваем источник данных элекменту отображения таблицы
            GridView2.DataBind();//применяем источник данных
        }
        private DataTable createDataTableTemplate()//конструктор таблицы
        {
            DataTable table = new DataTable("Visitor");
            DataColumn col1 = new DataColumn("id");
            DataColumn col2 = new DataColumn("id_visitor");
            DataColumn col3 = new DataColumn("date");
            DataColumn col4 = new DataColumn("book_name");
            DataColumn col5 = new DataColumn("code");
            DataColumn col6 = new DataColumn("author");
            DataColumn col7 = new DataColumn("age");
            col1.DataType = System.Type.GetType("System.Int32");
            col2.DataType = System.Type.GetType("System.String");
            col3.DataType = System.Type.GetType("System.String");
            col4.DataType = System.Type.GetType("System.String");
            col5.DataType = System.Type.GetType("System.Int32");
            col6.DataType = System.Type.GetType("System.String");
            col7.DataType = System.Type.GetType("System.Int32");
            table.Columns.Add(col1);
            table.Columns.Add(col2);
            table.Columns.Add(col3);
            table.Columns.Add(col4);
            table.Columns.Add(col5);
            table.Columns.Add(col6);
            table.Columns.Add(col7);
            return table;
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "remove")
            {
                var i = Convert.ToInt32(e.CommandArgument);
                var id = Convert.ToInt32(GridView2.Rows[i].Cells[0].Text);
                string strConnect = $"Server=MYSQL6001.site4now.net;Database=db_a46ad7_akilele;Uid=a46ad7_akilele;Pwd={pass.Password}";//строка для подключения к БД
                MySqlConnection dbConn = new MySqlConnection(strConnect);
                dbConn.Open();
                string sql = $"DELETE from history WHERE (id = {id})";
                MySqlCommand cmd = new MySqlCommand(sql, dbConn);
                cmd.ExecuteNonQuery();
                dbConn.Close();
                Response.Redirect("History");
            }

            if (e.CommandName == "change")
            {
                int i = Convert.ToInt32(e.CommandArgument);
                int id = Convert.ToInt32(GridView2.Rows[i].Cells[0].Text);
                Response.Redirect($"Editor2?id={id}");
            }

        }
        protected void create_Click(object sender, EventArgs e)
        {
            Response.Redirect("Editor2");
        }

        protected void list_Click(object sender, EventArgs e)
        {
            Response.Redirect($"Default");
        }
    }
}