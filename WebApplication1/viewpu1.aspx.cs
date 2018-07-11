using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MAPBusiness;
using GEN.Utility;
using MAPConnection;

namespace WebApplication1
{
    public partial class viewpu1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind_grid();
                BindAll_Zones();
            }

        }

        DataSet ds = new DataSet();
        business ob = new business();
        connections con = new connections();
        protected void bind_grid()
        {
            ds = ob.Fn_selectAll_pu();
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }



        protected void Ddlzone_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            string zone = Ddlzone.SelectedValue.ToString();
            search_PU_Zone_wise(zone);
            BindWards(zone);
        }

        protected void Ddlword_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string zone = Ddlzone.SelectedValue.ToString();
            string wadrid = Ddlword.SelectedValue.ToString();
            string strsql = "proc_select_Pu_wardwise '" + zone + "','" + wadrid + "'";
            ds = con.FN_ExecuteQuerySingle(strsql);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        public void BindWards(string zone)   //created By Gajendra Singh
        {
            DataSet ds = new DataSet();
            string strsql = "BindWardonSelect_Zone '" + zone + "'";
            ds = con.FN_ExecuteQuerySingle(strsql);
            Ddlword.DataSource = ds;
            Ddlword.DataTextField = "ward_name";
            Ddlword.DataValueField = "ward_id";
            Ddlword.DataBind();
            Ddlword.Items.Add(new ListItem("--Select--", "0"));
            Ddlword.SelectedValue = "0";


        }
        public void BindAll_Zones()//created By Gajendra Singh
        {

            DataSet getzone = new DataSet();
            getzone = ob.fn_get_z_name();

            Ddlzone.DataTextField = "Zone_Name";
            Ddlzone.DataValueField = "Zone_id";
            Ddlzone.DataSource = getzone;
            Ddlzone.DataBind();
            Ddlzone.Items.Add(new ListItem("--Select--", "0"));
            Ddlzone.SelectedValue = "0";
        }
        public void search_PU_Zone_wise(string zone)
        {
            ds = ob.Fn_select_PU_ZoneWise(zone);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void LinkEdit_Click(object sender, EventArgs e)
        {
            LinkButton LinkEdit = (LinkButton)sender;
            GridViewRow row = (GridViewRow)LinkEdit.Parent.Parent;
            string BinId = ((Label)row.FindControl("Label1")).Text;


            Response.Redirect("Add_Processing_Units.aspx?binid=" + BinId);

        }

        protected void LinkDel_Click(object sender, EventArgs e)
        {
            LinkButton LinkDel = (LinkButton)sender;
            GridViewRow row = (GridViewRow)LinkDel.Parent.Parent;

            string BinIdd = ((Label)row.FindControl("Label1")).Text;

            DataSet ds = new DataSet();
            ds = ob.fn_Delete_PU_Details(BinIdd);
            if (ds.Tables[0].Rows[0]["msg"].ToString() == "S")
            {
                MessageBox.Show("Bin Deleted Successfully");
                bind_grid();
            }
            else
                if (ds.Tables[0].Rows[0]["msg"].ToString() == "N")
                {
                    MessageBox.Show("Due to Some Problem Bin Not Deleted");
                }

        }
    }
}