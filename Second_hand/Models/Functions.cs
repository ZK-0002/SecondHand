using System.Data;
using System.Data.SqlClient;

namespace Second_hand.Models
{
    public class Functions
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private DataTable dt;
        private string constr;
        private SqlDataAdapter sda;
        public static int Userid;
        public static int Aid;
        public static string Uname;
        //检测数据库是否开启
        public int setdata(string Query)
        {
            int cnt;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd = new SqlCommand(Query, con);
            cnt = cmd.ExecuteNonQuery();
            con.Close();
            return cnt;
        }
        //获取数据并将数据填充在虚拟表格中
        public DataTable getdata(string Query)
        {
            dt = new DataTable();
            sda = new SqlDataAdapter(Query, constr);
            sda.Fill(dt);
            return dt;
        }

        public Functions()
        {
            //连接数据库
            constr = "Data Source=LAPTOP-UD0T986Q;Initial Catalog=Second;Integrated Security=True";
            con = new SqlConnection(constr);
            cmd = new SqlCommand();
            cmd.Connection = con;//只允许在指定的数据库上执行操作

        }
    }
}