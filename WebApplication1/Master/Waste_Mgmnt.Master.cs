using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Master
{
    public partial class Waste_Mgmnt : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (Session["type"].ToString() == "" || Session["type"].ToString() == null)
                {

                    Response.Redirect("LoginIOT.aspx");

                }
            }
        }

        protected void lg_out_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("LoginIOT.aspx");
        }
    }
}