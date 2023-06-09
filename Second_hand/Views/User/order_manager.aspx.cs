using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Second_hand.Views.User
{
    
    public partial class WebForm3 : System.Web.UI.Page
    {
        Models.Functions con;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new Models.Functions();
            Showgrideview();
        }
        private void Showgrideview()
        {
            string Query = "select Ogid as aid,Ogname as aname, Ogprice as aprice ,Ogsellername as seller,astartname as starttime,aendname as endtime,aplace as place from Order_grade";
            ogrideview.DataSource = con.getdata(Query);
            ogrideview.DataBind();
        }
        private void reset()
        {
            gride_name.Value = "";
            price.Value = "";
            seller.Value = "";
            starttime.Value = "";
            endtime.Value = "";
            place.Value = "";
        }
        protected void ogrideview_SelectedIndexChanged(object sender, EventArgs e)
        {
            gride_name.Value = ogrideview.SelectedRow.Cells[2].Text;
            price.Value = ogrideview.SelectedRow.Cells[3].Text;
            seller.Value = ogrideview.SelectedRow.Cells[4].Text;
            starttime.Value = ogrideview.SelectedRow.Cells[5].Text;
            endtime.Value = ogrideview.SelectedRow.Cells[6].Text;
            place.Value = ogrideview.SelectedRow.Cells[7].Text;
        }

        protected void Delebtn_Click(object sender, EventArgs e)
        {
            int key = 0;
            string gridename = gride_name.Value;
            string Query1 = "select * from Order_grade where Ogname='{0}'";
            Query1 = string.Format(Query1, gridename);
            DataTable dt2 = con.getdata(Query1);
            if (gride_name.Value == "")
            {
                key = 0;
            }
            else if (dt2.Rows.Count != 0)
            {
                key = Convert.ToInt32(ogrideview.SelectedRow.Cells[1].Text);

            }
            else
            {
                key = 0;
            }

            if (key == 0)
            {
                delete.InnerText = "信息不存在！";
            }
            else
            {
                try
                {
                    string Query = "delete from Order_grade where Ogid=" + key + "";
                    con.setdata(Query);
                    Showgrideview();
                    delete.InnerText = "信息删除成功！";
                    
                }
                catch (Exception Ex)
                {
                    delete.InnerText = Ex.ToString();
                }
            }
        }
    }
}