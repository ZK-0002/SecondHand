using System;
using System.Data;

namespace Second_hand
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        Models.Functions con;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new Models.Functions();
        }

        protected void signupBtn_Click(object sender, EventArgs e)
        {
            string unames = UserTb.Value;
            string upassword = Password1.Value;
            string rpassword = Password2.Value;

            string Query = "select uname from Users where Uname='{0}'";
            Query = string.Format(Query, unames);
            DataTable dt = con.getdata(Query);
            if (dt.Rows.Count > 0)
            {
                signup.InnerText = "用户名重复";
            }

            else if (!upassword.Equals(rpassword))
            {
                signup.InnerText = "两次输入密码不一致";
            }
            else
            {

                string Query1 = "insert into Users(Uname,Upassword) values('{0}','{1}')";
                Query1 = string.Format(Query1, unames, upassword);
                con.setdata(Query1);
                Response.Redirect("login.aspx");


            }
        }
    }
}