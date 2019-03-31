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

    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strConnect = $"Server=MYSQL6001.site4now.net;Database=db_a46ad7_akilele;Uid=a46ad7_akilele;Pwd={pass.Password}";//строка для подключения к БД
            MySqlConnection dbConn = new MySqlConnection(strConnect);
            dbConn.Open();
            string sql = "SELECT * from visitor";
            MySqlCommand cmd = new MySqlCommand(sql, dbConn);
            DataTable newTable = createDataTableTemplate(); //создаем таблицу, в которую будем записывать результат запроса
            MySqlDataReader rdr = cmd.ExecuteReader();//выполняем запрос и записываем результат в массив
            while (rdr.Read())
            {
                DataRow newRow = newTable.NewRow();
                newRow["id"] = rdr.GetInt32(0);
                newRow["fio"] = rdr.GetString(1);
                newRow["ticket_number"] = rdr.GetInt32(2);
                newRow["birth"] = rdr.GetDateTime(3).ToString("dd.MM.yyyy");
                var gender_id = rdr.GetInt32(4);
                if (gender_id == 0)
                    newRow["gender"] = "Ж";
                else
                    newRow["gender"] = "М";
                newTable.Rows.Add(newRow);//добавление в таблицу строки с результатом запроса
            }
            rdr.Close();
            dbConn.Close();//закрываем соединение
            GridView1.DataSource = newTable;//присваиваем источник данных элекменту отображения таблицы
            GridView1.DataBind();//применяем источник данных
        }
        private DataTable createDataTableTemplate()//конструктор таблицы
        {
            DataTable table = new DataTable("Visitor");
            DataColumn col1 = new DataColumn("id");
            col1.DataType = System.Type.GetType("System.Int32");
            DataColumn col2 = new DataColumn("fio");
            col2.DataType = System.Type.GetType("System.String");
            DataColumn col3 = new DataColumn("ticket_number");
            col3.DataType = System.Type.GetType("System.Int32");
            DataColumn col4 = new DataColumn("birth");
            col4.DataType = System.Type.GetType("System.String");
            DataColumn col5 = new DataColumn("gender");
            col5.DataType = System.Type.GetType("System.String");
            table.Columns.Add(col1);
            table.Columns.Add(col2);
            table.Columns.Add(col3);
            table.Columns.Add(col4);
            table.Columns.Add(col5);
            return table;
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "history")
            {
                int i = Convert.ToInt32(e.CommandArgument);
                int id = Convert.ToInt32(GridView1.Rows[i].Cells[0].Text);
                Response.Redirect($"history?id={id}");
            }
            if (e.CommandName == "remove")
            {
                int i = Convert.ToInt32(e.CommandArgument);
                int id = Convert.ToInt32(GridView1.Rows[i].Cells[0].Text);
                string strConnect = $"Server=MYSQL6001.site4now.net;Database=db_a46ad7_akilele;Uid=a46ad7_akilele;Pwd={pass.Password}";//строка для подключения к БД
                MySqlConnection dbConn = new MySqlConnection(strConnect);
                dbConn.Open();
                string sql = $"DELETE from visitor WHERE (id = {id})";
                MySqlCommand cmd = new MySqlCommand(sql, dbConn);
                cmd.ExecuteNonQuery();
                dbConn.Close();
                Response.Redirect("Default");
            }
            if (e.CommandName == "change")
            {
                int i = Convert.ToInt32(e.CommandArgument);
                int id = Convert.ToInt32(GridView1.Rows[i].Cells[0].Text);
                Response.Redirect($"Editor?id={id}");
            }
        }

       

        

        protected void all_history_Click1(object sender, EventArgs e)
        {
            Response.Redirect($"History");
        }

        protected void create_Click(object sender, EventArgs e)
        {
            Response.Redirect("Editor");
        }
    }
}
