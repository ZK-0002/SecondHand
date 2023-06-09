using System;
using System.Data;

namespace Second_hand.Views.User.Auction
{
    public partial class addgrides : System.Web.UI.Page
    {
        Models.Functions con;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new Models.Functions();
            Showgrideview();
        }


        private void Showgrideview()
        {
            string Query = "select Gid as id ,Gname as name ,Gtype as type , Gprice as price from Grades";
            grideview2.DataSource = con.getdata(Query);
            grideview2.DataBind();
        }
        //商品添加

        protected void addbtn_Click(object sender, EventArgs e)
        {
            int key = 0;
            string owner = Models.Functions.Uname;
            string gridename = gride_name.Value;
            string gprice = grideview2.SelectedRow.Cells[4].Text;
            string gtype = grideview2.SelectedRow.Cells[3].Text;
            string Query1 = "select * from Grades where Gname='{0}'";
            Query1 = string.Format(Query1, gridename);
            DataTable dt2 = con.getdata(Query1);
            if (gride_name.Value == "")
            {
                key = 0;
            }
            else if (dt2.Rows.Count == 1)
            {
                key = Convert.ToInt32(grideview2.SelectedRow.Cells[1].Text);

            }
            else
            {
                key = 0;
            }

            if (key == 0)
            {
                add.InnerText = "无商品存在！";
            }
            else
            {
                try
                {
                    string Query = "delete from Grades where Gid=" + key + "";
                    con.setdata(Query);
                    Showgrideview();
                    add.InnerText = "商品信息上传成功！";

                }
                catch (Exception Ex)
                {
                    add.InnerText = Ex.ToString();
                }
                try
                {
                    int jugde_acution = Models.Functions.Aid;
                    string Query = "insert into Aution_grades(Ag_name,Ag_price,Ag_type,Ag_owner,Aid) values('{0}','{1}','{2}','{3}','{4}')";
                    Query = string.Format(Query, gridename, gprice, gtype, owner,jugde_acution);
                    con.setdata(Query);
                    Showgrideview();




                }
                catch (Exception Ex)
                {
                    add.InnerText = Ex.ToString();
                }

            }
        }

        protected void grideview1_SelectedIndexChanged(object sender, EventArgs e)
        {
            gride_name.Value = grideview2.SelectedRow.Cells[2].Text;
            price.Value = grideview2.SelectedRow.Cells[4].Text;
            Text2.Value= grideview2.SelectedRow.Cells[3].Text;
        }
    }
}