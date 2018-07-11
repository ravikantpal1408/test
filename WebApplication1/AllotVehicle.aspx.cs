using MAPBusiness;
using MAPConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class AllotVehicals : System.Web.UI.Page
    {
        connections con = new connections();
        DataSet ds = new DataSet();
        business ob = new business();
        string str = DateTime.Now.ToString("yyyy-MM-dd' '00:00:00.000");
       
        protected void Page_Load(object sender, EventArgs e)
        {
           
           
          
            if (!IsPostBack)
            {
                ds = ob.fn_get_z_name();

                ddlZone.DataTextField = "Zone_Name";
                ddlZone.DataValueField = "Zone_id";
                ddlZone.DataSource = ds;
                ddlZone.DataBind();
                ddlZone.Items.Add(new ListItem("--Select--", "0"));
                ddlZone.SelectedValue = "0";


                ds = con.FN_ExecuteQuerySingle(" Select *,CONVERT(VARCHAR(10),allotmentDT,103)as date from Mst_Driver_Vehicle_Allotment  order by AllotmentLongDT desc");
                
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdDefault.DataSource = ds;
                    grdDefault.DataBind();
                }
                else
                {
                    grdDefault.DataSource = null;
                    grdDefault.DataBind();
                }


            }
            dvgrvDetails.Visible = false;
        }
        protected void ddlZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string strsql = "BindWardonSelect_Zone '" + ddlZone.SelectedValue + "'";
            ds = con.FN_ExecuteQuerySingle(strsql);
            ddlWard.DataSource = ds;
            ddlWard.DataTextField = "ward_name";
            ddlWard.DataValueField = "ward_id";
            ddlWard.DataBind();
            ddlWard.Items.Add(new ListItem("--Select--", "0"));
            ddlWard.SelectedValue = "0";
            divlistbox.Visible = false;
            dvgrvDetails.Visible = false;
        }

        protected void ddlWard_SelectedIndexChanged(object sender, EventArgs e)
        {
            ds = con.FN_ExecuteQuerySingle("select * from Mst_Route_planner where wardid='" + ddlWard.SelectedValue + "'");
            ddlRoute.DataSource = ds;
            ddlRoute.DataTextField = "routeName";
            ddlRoute.DataValueField = "routid";
            ddlRoute.DataBind();
            ddlRoute.Items.Add(new ListItem("--Select--", "0"));
            ddlRoute.SelectedValue = "0";
            divlistbox.Visible = false;
            dvgrvDetails.Visible = false;
           
        }

        protected void ddlRoute_SelectedIndexChanged(object sender, EventArgs e)
        {

            ListBoxAllotment.Items.Clear();
            if (ddlRoute.SelectedValue != "0")
            {
                ds = con.FN_ExecuteQuerySingle("select * from Mst_Drivers");
                ListLeft.DataSource = ds;
                ListLeft.DataValueField = "DriverID";
                ListLeft.DataTextField = "DriverName";
                ListLeft.DataBind();
                ListLeft.Items.Add(new ListItem("", ""));
                DataSet ds1 = new DataSet();

                ds1 = con.FN_ExecuteQuerySingle("select * from Mst_Vehicles");
                ListRight.DataSource = ds1;
                ListRight.DataValueField = "vehicle_num";
                ListRight.DataTextField = "vehicle_type";
                ListRight.DataBind();
                ListRight.Items.Add(new ListItem("", ""));
                divlistbox.Visible = true;
                dvgrvDetails.Visible = true;
            }
            else
            {
                dvgrvDetails.Visible = false;
            }
        }






        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (ListLeft.SelectedValue != "" && ListRight.SelectedValue != "")
            {
                ds = con.FN_ExecuteQuerySingle("select * from Mst_Driver_Vehicle_Allotment where driverid='" + ListLeft.SelectedValue + "' and vehicleid='" + ListRight.SelectedValue + "' and routeid='" + ddlRoute.SelectedValue + "' and allotmentDT='" + str + "' ");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Response.Write("<script>alert('Already alloted....');</script>");
                }

                else
                {

                    ds = con.FN_ExecuteQuerySingle("proc_Insert_Allotment_Details '" + ListLeft.SelectedValue + "','" + ListLeft.SelectedItem.ToString() + "','" + ListRight.SelectedValue + "','" + ListRight.SelectedItem.ToString() + "','" + ddlRoute.SelectedItem.ToString() + "','" + ddlRoute .SelectedValue+ "'");
                    dvgrvDetails.Visible = true;
                    ds = con.FN_ExecuteQuerySingle("select top 1 * from Mst_Driver_Vehicle_Allotment order by AllotmentLongDT desc ");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ListBoxAllotment.Items.Add(ds.Tables[0].Rows[0]["DriverName"] + " " + "-->" + " " + ds.Tables[0].Rows[0]["VehicleType"]);
                        ds = con.FN_ExecuteQuerySingle("Select *,CONVERT(VARCHAR(10),allotmentDT,103)as date from Mst_Driver_Vehicle_Allotment where AllotmentDT ='" + str + "'order by AllotmentLongDT desc");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            grvDetails.DataSource = ds;
                            grvDetails.DataBind();
                           
                        }
                        else
                        {
                            grvDetails.DataSource = null;
                            grvDetails.DataBind();
                        }

                        ds = con.FN_ExecuteQuerySingle(" Select *,CONVERT(VARCHAR(10),allotmentDT,103)as date from Mst_Driver_Vehicle_Allotment  order by AllotmentLongDT desc");
                        
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            grdDefault.DataSource = ds;
                            grdDefault.DataBind();
                        }
                        else
                        {
                            grdDefault.DataSource = null;
                            grdDefault.DataBind();
                        }
                    }
                }
                ListLeft.SelectedValue = "";
                ListRight.SelectedValue = "";
            }
            else
            {
                Response.Write("<script>alert('Select Driver and Vehicle..');</script>");
            }
        }

        //protected void btnDetails_Click(object sender, EventArgs e)
        //{
        //    ds = con.FN_ExecuteQuerySingle("Select *,CONVERT(VARCHAR(10),allotmentDT,103)as date from Mst_Driver_Vehicle_Allotment order by drivername");
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        grvDetails.DataSource = ds;
        //        grvDetails.DataBind();
        //    }
        //    else
        //    {
        //        grvDetails.DataSource = null;
        //        grvDetails.DataBind();
        //    }
        //}

        protected void grvbtndelete_Click(object sender, ImageClickEventArgs e)
        {

            DataSet ds_delete = new DataSet();
            ImageButton linkb = (ImageButton)sender;
            GridViewRow grdViewApplication = (GridViewRow)linkb.NamingContainer;

            string altId = ((Label)grdViewApplication.FindControl("lblAllotmentId")).Text;
            ds_delete = con.FN_ExecuteQuerySingle("delete from Mst_Driver_Vehicle_Allotment where AllotmentId='" + altId + "'");

            ds = con.FN_ExecuteQuerySingle(" Select *,CONVERT(VARCHAR(10),allotmentDT,103)as date from Mst_Driver_Vehicle_Allotment  order by AllotmentLongDT desc");

            if (ds.Tables[0].Rows.Count > 0)
            {
                grdDefault.DataSource = ds;
                grdDefault.DataBind();
            }
            else
            {
                grdDefault.DataSource = null;
                grdDefault.DataBind();
            }




            ds = con.FN_ExecuteQuerySingle("Select *,CONVERT(VARCHAR(10),allotmentDT,103)as date from Mst_Driver_Vehicle_Allotment where AllotmentDT ='" + str + "' order by AllotmentLongDT desc");
            if (ds.Tables[0].Rows.Count > 0 && ddlRoute.SelectedValue!="")
            {
                grvDetails.DataSource = ds;
                grvDetails.DataBind();

                dvgrvDetails.Visible = true;

                ds = con.FN_ExecuteQuerySingle("Select *,CONVERT(VARCHAR(10),allotmentDT,103)as date from Mst_Driver_Vehicle_Allotment where allotmentDT='" + str + "' and routeid='" + ddlRoute.SelectedValue + "'  order by AllotmentLongDT desc");
            if (ds.Tables[0].Rows.Count > 0)
            {
                ListBoxAllotment.Items.Clear();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ListBoxAllotment.Items.Add(ds.Tables[0].Rows[i]["DriverName"] + " " + "-->" + " " + ds.Tables[0].Rows[i]["VehicleType"]);
                }
            }
            }
            else
            {
                grvDetails.DataSource = null;
                grvDetails.DataBind();
                dvgrvDetails.Visible = false;
                ListBoxAllotment.Items.Clear();
            }

        }

        

    }

    
}