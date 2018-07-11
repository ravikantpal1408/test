using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MAPBusiness;
using MAPConnection;

namespace WebApplication1
{
    public partial class DriverList : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        connections con = new connections();
        business ob = new business();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid_Driver();
            }
        }
        public void BindGrid_Driver()
        {
            ds = con.FN_ExecuteQuerySingle("select name,licence_n,p_address,r_address,email,mobile,format(convert(date,dob),'dd-MM-yyyy') as dob ,typeOFveh from MSt_driver_Reg");
            grdDriver.DataSource = ds;
            grdDriver.DataBind();
                 
        
        }

        protected void LnkEdit_Click(object sender, EventArgs e)
        {
            LinkButton LnkEdit = (LinkButton)sender;
            GridViewRow row = (GridViewRow)LnkEdit.Parent.Parent;
            string d_id = ((Label)row.FindControl("Label1")).Text;
            Response.Redirect("frm_reg_drivers.aspx?d_id=" + d_id);
        }

        protected void LinkDel_Click(object sender, EventArgs e)
        {
            LinkButton LinkDel = (LinkButton)sender;
            GridViewRow row = (GridViewRow)LinkDel.Parent.Parent;
            string d_id = ((Label)row.FindControl("Label1")).Text;
            ds = con.FN_ExecuteQuerySingle("delete from MSt_driver_Reg where licence_n='" + d_id + "'");

        }


    }
}