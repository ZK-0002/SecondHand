using System;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Web.UI.WebControls;

namespace Second_hand.Views.Admin
{
    public partial class Admin1 : System.Web.UI.Page
    {
        Models.Functions con;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new Models.Functions();
            Showgrideview();
        }


        private void Showgrideview()
        {
            string Query = "select Aid as id ,Astarttime as starttime ,Aaction as place ,Aendtime as endtime from Acution";
            agrid.DataSource = con.getdata(Query);
            agrid.DataBind();
        }
        //添加
        protected void aaddbtn_Click(object sender, EventArgs e)
        {
            price_judge.InnerText = "";
            add.InnerText = "";

            try
            {
                string bdate = System.DateTime.Today.Date.ToString();
                string gridename = astarttime.Value;
                string grideprice = aendtime.Value;
                string gridetype = place.Value;

                string Query = "insert into Acution(Astarttime,Aendtime,Aaction) values('{0}','{1}','{2}')";
                Query = String.Format(Query, gridename, grideprice, gridetype);
                int j = gridename.CompareTo(grideprice);
                if (j >= 0)
                {
                    add.InnerText = "拍卖会设置错误";
                }
                else
                {
                    con.setdata(Query);
                    Showgrideview();
                    add.InnerText = "拍卖会信息添加成功！";
                }

            }
            catch (Exception Ex)
            {
                add.InnerText = Ex.ToString();
            }
        }
        //删除
        protected void adelebtn_Click(object sender, EventArgs e)
        {

            int ker = Convert.ToInt32(agrid.SelectedRow.Cells[1].Text);
            string Query1 = "select * from Acution ";

            DataTable dt2 = con.getdata(Query1);
            if (dt2.Rows.Count == 0)
            {
                add.InnerText = "拍卖会已空";
            }
            else
            {
                try
                {
                    string Query = "delete from Acution where Aid=" + ker + "";
                    con.setdata(Query);
                    Showgrideview();
                    add.InnerText = "商品信息删除成功！";

                }
                catch (Exception Ex)
                {
                    add.InnerText = Ex.ToString();
                }
            }

        }
        //修改
        protected void arebtn_Click(object sender, EventArgs e)
        {
            int key = Convert.ToInt32(agrid.SelectedRow.Cells[1].Text);
            try
            {
                string gridename = astarttime.Value;
                string grideprice = aendtime.Value;
                string gridetype = place.Value;

                string Query = "update Acution set Astarttime='{0}',Aendtime='{1}',Aaction='{2}' where Aid=" + key + "";

                Query = string.Format(Query, gridename, grideprice, gridetype);
                con.setdata(Query);
                Showgrideview();
                add.InnerText = "商品信息修改成功！";
            }


            catch (Exception Ex)
            {
                add.InnerText = Ex.ToString();
            }
        }



        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {


            string a = agrid.SelectedRow.Cells[4].Text;
            a = a.Replace(" ", "T");
            char is_not = a[6];
            int b = a.Length;
            char is_or = a[b - 12];
            if (is_or != '/')
            {
                a = a.Insert(b - 10, "0");
            }
            if (is_not == '/')
            {
                a = a.Insert(5, "0");
            }
            a = a.Replace("/", "-");
            aendtime.Value = a;
            string a1 = agrid.SelectedRow.Cells[2].Text;
            a1 = a1.Replace(" ", "T");
            char is_not1 = a1[6];
            int b1 = a1.Length;
            char is_or1 = a1[b1 - 12];
            if (is_or1 != '/')
            {
                a1 = a1.Insert(b1 - 10, "0");
            }
            if (is_not1 == '/')
            {
                a1 = a1.Insert(5, "0");
            }
            a1 = a1.Replace("/", "-");
            astarttime.Value = a1;
            place.Value = agrid.SelectedRow.Cells[3].Text;

        }
    }
}