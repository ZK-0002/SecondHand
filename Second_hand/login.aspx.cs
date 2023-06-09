using System;
using System.Data;

namespace Second_hand
{

    public partial class WebForm1 : System.Web.UI.Page
    {
        Models.Functions con;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new Models.Functions();
            Session["UserName"] = "";
            Session["UId"] = "";
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            string uname = UserTb.Value;
            string upassword = PasswordTb.Value;


            if (Admin.Checked)
            {
                string Query2 = "select * from  Manager where Mname='{0}'and Mpassword='{1}'";
                Query2 = string.Format(Query2, uname, upassword);
                DataTable dt2 = con.getdata(Query2);
                if (dt2.Rows.Count == 0)
                {
                    Essmsg.InnerText = "无效的管理员";
                }
                else
                {
                    Session["Username"] = dt2.Rows[0][1].ToString();
                    Session["UId"] = Convert.ToInt32(dt2.Rows[0][0].ToString());
                    Response.Redirect("Views/Admin/Admin1.aspx");


                }
            }
            else if (User.Checked)
            {
                string Query1 = "select * from Users where Uname='{0}'and Upassword='{1}'";

                Query1 = string.Format(Query1, uname, upassword);

                DataTable dt1 = con.getdata(Query1);
                if (dt1.Rows.Count == 0)
                {
                    Essmsg.InnerText = "无效的用户";
                }
                else
                {
                    Models.Functions.Uname = dt1.Rows[0][1].ToString();
                    Session["Username"] = dt1.Rows[0][1].ToString();
                    Session["UId"] = Convert.ToInt32(dt1.Rows[0][0].ToString());
                    Models.Functions.Userid = Convert.ToInt32(dt1.Rows[0][0].ToString());
                    Response.Redirect("Views/User/gride_manage.aspx");
                }
            }
            else
            {
                Essmsg.InnerText = "请选择角色";
            }

        }
    }
}