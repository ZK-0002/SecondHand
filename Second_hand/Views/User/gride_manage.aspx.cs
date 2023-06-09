using System;
using System.Data;

namespace Second_hand.Views.User
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Models.Functions con;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new Models.Functions();
            Showgrideview();
            if (!Page.IsPostBack)
            {
                showtypes();
                gettypes();

            }


        }
        //数据网格的显示
        private void Showgrideview()
        {
            string Query = "select Gid as id ,Gname as name ,Gtype as type , Gprice as price from Grades";
            grideview1.DataSource = con.getdata(Query);
            grideview1.DataBind();
        }
        //下拉列表的显示
        private void showtypes()
        {
            string Query = "select * from gridetype";
            gride_type.DataSource = con.getdata(Query);
            gride_type.DataBind();
        }

        private void gettypes()
        {
            string Query = "select * from gridetype";
            gride_type.DataTextField = con.getdata(Query).Columns["types"].ToString();
            gride_type.DataValueField = con.getdata(Query).Columns["tid"].ToString();
            gride_type.DataSource = con.getdata(Query);
            gride_type.DataBind();


        }
        private void reset()
        {
            gride_name.Value = "";
            price.Value = "";
        }
        //商品添加功能模块
        protected void addbtn_Click(object sender, EventArgs e)
        {
            price_judge.InnerText = "";
            add.InnerText = "";

            try
            {
                string gridename = gride_name.Value;
                string grideprice = price.Value;
                string gridetype = gride_type.SelectedItem.ToString();
                int grideownerid = Models.Functions.Userid;
                string Query = "insert into Grades(Gname,Gprice,Gtype,Gownerid) values('{0}','{1}','{2}','{3}')";
                string Query1 = "select * from Grades where Gname='{0}'";
                Query1 = string.Format(Query1, gridename);
                DataTable dt1 = con.getdata(Query1);
                double ang;
                if (!double.TryParse(grideprice, out ang) && grideprice != "")
                {
                    price_judge.InnerText = "输入数据不合法";
                    price.Value = "";
                }
                else if (dt1.Rows.Count == 0)
                {

                    Query = string.Format(Query, gridename, grideprice, gridetype, grideownerid);
                    con.setdata(Query);
                    Showgrideview();
                    add.InnerText = "商品信息添加成功！";
                    reset();
                }
                else
                {
                    add.InnerText = "商品名重复";
                }

            }
            catch (Exception Ex)
            {
                add.InnerText = Ex.ToString();
            }
        }
        //数据的删除
        protected void delebtn_Click(object sender, EventArgs e)
        {
            int key = 0;
            string gridename = gride_name.Value;
            string Query1 = "select * from Grades where Gname='{0}'";
            Query1 = string.Format(Query1, gridename);
            DataTable dt2 = con.getdata(Query1);
            if (gride_name.Value == "")
            {
                key = 0;
            }
            else if (dt2.Rows.Count == 0)
            {
                key = 0;

               

            }
            else
            {
                key = Convert.ToInt32(grideview1.SelectedRow.Cells[1].Text);
            }

            if (key == 0)
            {
                delete.InnerText = "无商品存在！";
            }
            else
            {
                try
                {
                    string Query = "delete from Grades where Gid=" + key + "";
                    con.setdata(Query);
                    Showgrideview();
                    add.InnerText = "商品信息删除成功！";
                    reset();
                }
                catch (Exception Ex)
                {
                    add.InnerText = Ex.ToString();
                }
            }

        }
        //重置
        protected void resetbtn_Click(object sender, EventArgs e)
        {
            reset();
        }
        //修改
        protected void rebtn_Click(object sender, EventArgs e)
        {
            price_judge.InnerText = "";
            add.InnerText = "";
            int key = Convert.ToInt32(grideview1.SelectedRow.Cells[1].Text);
            try
            {
                string gridename = gride_name.Value;
                string grideprice = price.Value;
                string gridetype = gride_type.SelectedItem.ToString();
                int grideownerid = Models.Functions.Userid;
                string Query = "update Grades set Gname='{0}',Gprice='{1}',Gtype='{2}' where Gid=" + key + "";
                string Query1 = "select * from Grades where Gname='{0}'";
                Query1 = string.Format(Query1, gridename);
                DataTable dt1 = con.getdata(Query1);
                double ang;
                if (!double.TryParse(grideprice, out ang) && grideprice != "")
                {
                    price_judge.InnerText = "输入数据不合法";
                    price.Value = "";
                }
                else 
                {
                    Query = string.Format(Query, gridename, grideprice, gridetype);
                    con.setdata(Query);
                    Showgrideview();
                    add.InnerText = "商品信息修改成功！";

                }
                

            }
            catch (Exception Ex)
            {
                add.InnerText = Ex.ToString();
            }
        }

        protected void CategoriesGV_SelectedIndexChanged(object sender, EventArgs e)
        {


            gride_name.Value = grideview1.SelectedRow.Cells[2].Text;
            price.Value = grideview1.SelectedRow.Cells[4].Text;

        }
    }
}