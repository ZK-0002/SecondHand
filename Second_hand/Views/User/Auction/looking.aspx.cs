using System;
using System.Data;

namespace Second_hand.Views.User.Auction
{
    public partial class looking : System.Web.UI.Page
    {
        Models.Functions con;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new Models.Functions();
            Showgrideview();
        }
        private void Showgrideview()
        {
            int jugde_acution = Models.Functions.Aid;
            add.InnerText = Convert.ToString(jugde_acution);
            string Query = "select Ag_id as aid,Ag_name as aname,Ag_type as atype , Ag_price as aprice ,Ag_owner as aowner from Aution_grades where Aid="+jugde_acution+"";
            agrideview.DataSource = con.getdata(Query);
            agrideview.DataBind();
        }

        //添加至订单
        protected void addorderbtn_Click(object sender, EventArgs e)
        {
          
            int aid = Models.Functions.Aid;
            string query = "select Astarttime,Aendtime,Aaction from Acution where Aid='{0}'";
            query = string.Format(query, aid);
            DataTable dt1 = con.getdata(query);
            string name = Models.Functions.Uname;
            string uname1 = agrideview.SelectedRow.Cells[5].Text;
            string Query = "insert into Order_grade(Ogname,Ogprice,astartname,aendname,aplace,Ogsellername) values('{0}','{1}','{2}','{3}','{4}','{5}')";
            Query = string.Format(Query, gride_name.Value, price.Value, dt1.Rows[0][0].ToString(), dt1.Rows[0][1].ToString(), dt1.Rows[0][2].ToString(), uname1);
            string query1 = "select * from Order_grade where Ogname='{0}' and Ogsellername='{1}'";
            query1 = string.Format(query1, gride_name.Value, uname1);
            DataTable d1 = con.getdata(query1);
            if (name == uname1)
            {
                add.InnerText = "不能添加自己的物品";
            }else if (d1.Rows.Count == 0) {
                con.setdata(Query);
            }
            else
            {
                add.InnerText = "不能重复添加同一件商品";
            }
           
        }
        //撤回至我的物品
        protected void rebackgridebtn_Click(object sender, EventArgs e)
        {


            int key = 0;
            string grideprice = price.Value;
            string gridetype = Convert.ToString(agrideview.SelectedRow.Cells[3].Text);
            int grideownerid = Models.Functions.Userid;
            int judge = Convert.ToInt32(agrideview.SelectedRow.Cells[1].Text);
            string agowner = Convert.ToString(agrideview.SelectedRow.Cells[5].Text);
            string gridename = gride_name.Value;
            string uname = Models.Functions.Uname;
            string Query1 = "select * from Aution_grades where Ag_id='{0}'";
            Query1 = string.Format(Query1, judge);
            DataTable dt2 = con.getdata(Query1);

            if (gride_name.Value == "")
            {
                key = 0;
            }
            else if (dt2.Rows.Count == 1)
            {
                key = Convert.ToInt32(agrideview.SelectedRow.Cells[1].Text);

            }
            else
            {
                key = 0;
            }

            if (key == 0)
            {
                delete.InnerText = "无商品存在！";
            }
            else if (agowner == uname)
            {
                try
                {
                    string Query = "delete from Aution_grades where Ag_id="+judge+"";
                    con.setdata(Query);
                    Showgrideview();
                    add.InnerText = "商品信息删除成功！";

                }
                catch (Exception Ex)
                {
                    add.InnerText = Ex.ToString();
                }
                try
                {


                    string Query = "insert into Grades(Gname,Gprice,Gtype,Gownerid) values('{0}','{1}','{2}','{3}')";




                    Query = string.Format(Query, gridename, grideprice, gridetype, grideownerid);
                    con.setdata(Query);
                    Showgrideview();
                    


                }
                catch (Exception Ex)
                {
                    add.InnerText = Ex.ToString();
                }
            }
            else
            {
                add.InnerText = "商品不属于你";
            }



        }

        protected void agrideview_SelectedIndexChanged(object sender, EventArgs e)
        {
            gride_name.Value = agrideview.SelectedRow.Cells[2].Text;
            price.Value = agrideview.SelectedRow.Cells[4].Text;
        }
    }
}