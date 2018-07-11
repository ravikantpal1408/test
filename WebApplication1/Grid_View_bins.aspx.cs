using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MAPBusiness;
using GEN.Utility;
using MAPConnection;

namespace WebApplication1
{
    public partial class Grid_View_bins : System.Web.UI.Page
    {
        connections con = new connections();
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

        protected void bind_grid()
        {
            ds = ob.fn_bind_bin();
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

 
        protected void Ddlzone_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string zone = Ddlzone.SelectedValue.ToString();
            search_bin_Zone_wise(zone);
            BindWards(zone);
        }
        public void search_bin_Zone_wise(string zone)
        {
            ds = ob.Fn_select_binsZoneWise(zone);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        public void BindAll_Zones()//created By Gajendra Singh
        {
            //  string zone = DropDownList2.SelectedItem.Text;
            //  ConvertDataTabletoString(zone);
            DataSet getzone = new DataSet();
            getzone = ob.fn_get_z_name();

            Ddlzone.DataTextField = "Zone_Name";
            Ddlzone.DataValueField = "Zone_id";
            Ddlzone.DataSource = getzone;
            Ddlzone.DataBind();
            Ddlzone.Items.Add(new ListItem("--Select--", "0"));
            Ddlzone.SelectedValue = "0";
        }
        public void BindWards( string zone)   //created By Gajendra Singh
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

        protected void Ddlword_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string zone = Ddlzone.SelectedValue.ToString();
            string wadrid = Ddlword.SelectedValue.ToString();
            string strsql = "proc_select_Bins_wardWise '" + zone + "','" + wadrid + "'";
            ds = con.FN_ExecuteQuerySingle(strsql);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

     
        protected void LnkEdit_Click(object sender, EventArgs e)
        {
            LinkButton LnkEdit = (LinkButton)sender;
            GridViewRow row = (GridViewRow)LnkEdit.Parent.Parent;
            string BinId = ((Label)row.FindControl("Label1")).Text;
      

            Response.Redirect("Add_Bins.aspx?binid=" + BinId);
        }

 
        protected void LinkDel_Click(object sender, EventArgs e)
        {
            LinkButton LinkDel = (LinkButton)sender;
            GridViewRow row = (GridViewRow)LinkDel.Parent.Parent;
            //string serialid = ((Label)row.FindControl("Label9")).Text;
            string BinIdd = ((Label)row.FindControl("Label1")).Text;

            DataSet ds = new DataSet();
            ds = ob.fn_Delete_bin_Details(BinIdd);
            if (ds.Tables[0].Rows[0]["msg"].ToString() == "S")
            {
                MessageBox.Show("Bin Deleted Successfully");
                bind_grid();
            }
            else if (ds.Tables[0].Rows[0]["msg"].ToString() == "N")
            {
                MessageBox.Show("Due to Some Problem Bin Not Deleted");
            }
        }
    }
}