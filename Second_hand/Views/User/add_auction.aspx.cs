using System;

namespace Second_hand.Views.User
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        Models.Functions con;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new Models.Functions();
            Showgrideview();
        }
        private void Showgrideview()
        {
            string Query = "select Aid as id ,Aaction as place ,Astarttime as starttime , Aendtime as endtime from Acution";
            grideview2.DataSource = con.getdata(Query);
            grideview2.DataBind();
        }


        protected void grideview2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Models.Functions.Aid = Convert.ToInt32(grideview2.SelectedRow.Cells[1].Text);
            Response.Redirect("Auction/looking.aspx");
        }
    }
}