using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

namespace _20180407_DataSet
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            DataTable dt = UseDataAdapterOpen();
            lbl1.Text = dt.Rows.Count.ToString() + "ですーーー。";

            //int count = UseMysqlScript();
            //lbl2.Text = count.ToString() + "ですーーー。";

        }

        public DataTable UseDataAdapterOpen()
        {
            MySqlConnection conn = null;
            MySqlParameter myParam = new MySqlParameter("@id", MySqlDbType.Int16);

            //返却用データテーブルの準備
            DataTable dt = new DataTable();
            //接続文字列の取得
            var connectionString = ConfigurationManager.ConnectionStrings["mysql"].ConnectionString;
            
            try
            {
                //接続準備
                conn = new MySqlConnection(connectionString);
                //接続開始
                conn.Open();
                
                //アダプタの準備
                MySqlDataAdapter adp = new MySqlDataAdapter();

                //SQLの準備
                string sql = "select * from user where id=@id;";
                
                //SQLとパラメーターの準備
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.Add(myParam);
                cmd.Parameters["@id"].Value = 2;

                //SQLの実行
                adp.SelectCommand = cmd;
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }
        //public DataTable UseDataAdapter()
        //{
        //    string connection = "Database=test;Data Source=localhost;User Id=root;Password=animedea";
        //    string query = "select * from user;";
        //    //string query = "select * from nothing;";

        //    DataTable dt = new DataTable();
        //    //DataColumn dc = new DataColumn("name", Type.GetType("System.String"));
        //    DataColumn[] dc = new DataColumn[]  {
        //        new DataColumn("id", typeof(int)),
        //        new DataColumn("name", typeof(string))};
        //    //dt.Columns.Add(dc_id);
        //    dt.Columns.AddRange(dc);

        //    try
        //    {
        //        MySqlConnection conn = new MySqlConnection(connection);
        //        MySqlDataAdapter adapter = new MySqlDataAdapter();
        //        adapter.SelectCommand = new MySqlCommand(query, conn);
        //        adapter.Fill(dt);
        //    }
        //    catch(Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //    }
        //    finally
        //    {

        //    }

        //    return dt;
        //}

        //public int UseMysqlScript()
        //{
        //    int count = -1;

        //    string connStr = "server=localhost;user=root;database=test;port=3306;password=animedea";
        //    MySqlConnection conn = new MySqlConnection(connStr);

        //    try
        //    {
        //        Console.WriteLine("Connecting to MySQL...");
        //        conn.Open();

        //        //string sql = "select * from user;";
        //        string sql = "select * from nothing;";

        //        MySqlScript script = new MySqlScript(conn, sql);

        //        script.Error += new MySqlScriptErrorEventHandler(Script_Error);
        //        script.ScriptCompleted += new EventHandler(Script_ScriptCompleted);
        //        script.StatementExecuted += new MySqlStatementExecutedEventHandler(Script_StatementExecuted);

        //        count = script.Execute();

        //        Console.WriteLine("Executed " + count + " statement(s).");
        //        Console.WriteLine("Delimiter: " + script.Delimiter);
                
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //    }

        //    conn.Close();
        //    Console.WriteLine("Done.");

        //    return count;
        //}
        //static void Script_StatementExecuted(object sender, MySqlScriptEventArgs args)
        //{
        //    Console.WriteLine("script_StatementExecuted");
        //}

        //static void Script_ScriptCompleted(object sender, EventArgs e)
        //{
        //    /// EventArgs e will be EventArgs.Empty for this method
        //    Console.WriteLine("script_ScriptCompleted!");
        //}

        //static void Script_Error(Object sender, MySqlScriptErrorEventArgs args)
        //{
        //    Console.WriteLine("script_Error: " + args.Exception.ToString());
        //}
    }
}