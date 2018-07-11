using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MAPBusiness;
using GEN.Utility;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Services;

namespace WebApplication1
{
    public partial class addbins1 : System.Web.UI.Page
    {

        string route_id = string.Empty;

        public string ServerValue = String.Empty;
        DataSet ds = new DataSet();
        business ob = new business();
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                bind_ddl_zone();
                try
                {
                    if (Request.QueryString["binid"].ToString() != null)
                    {
                        string bind = Request.QueryString["binid"].ToString();
                        ViewState["bin_id"] = bind;
                        //string bind = Session["binid"].ToString();
                        edit_bins(bind);
                    }

                }
                catch { }
            }
            try
            {

                Session["route_id"] = Request.QueryString["route_id"].ToString();

            }
            catch { }

        }




        
        protected void edit_bins(string binid)
        {
                GetCustomers();
                string name = Request.Form["Name"];
                DataSet edit_bin = new DataSet();
                edit_bin = ob.fn_edit_bins(binid);
                string zone = edit_bin.Tables[0].Rows[0]["Zoneid"].ToString();
                ddlzone.SelectedValue = zone;

                //Getwards(edit_bin.Tables[0].Rows[0]["Zoneid"].ToString());
                bind_ward_bind(edit_bin.Tables[0].Rows[0]["Zoneid"].ToString());
                ddlward.SelectedValue = edit_bin.Tables[0].Rows[0]["wardid"].ToString();
                name = edit_bin.Tables[0].Rows[0]["Area_Name"].ToString();
                string nm = name.Replace("_", "'");
                ServerValue = edit_bin.Tables[0].Rows[0]["Area_Name"].ToString();
                // get_address.Visible = true;
                blat.Text = edit_bin.Tables[0].Rows[0]["Latitude"].ToString();
                blon.Text = edit_bin.Tables[0].Rows[0]["Longitude"].ToString();
                b_name.Text = edit_bin.Tables[0].Rows[0]["BinName"].ToString();
                serialid.Text = edit_bin.Tables[0].Rows[0]["SerialId"].ToString();
                Btnupdate.Visible = true;
                Button1.Visible = false;
                Btncancle.Visible = true;


            }

        protected void bind_ddl_zone()
        {
            ds = ob.fn_ddl_bind();
            ddlzone.DataSource = ds;
            ddlzone.DataValueField = "Zone_id";
            ddlzone.DataTextField = "Zone_Name";
            ddlzone.DataBind();
            ddlzone.Items.Add(new ListItem("--Select--", "0"));
            ddlzone.SelectedValue = "0";



        }
        protected void bind_ward_bind(string get_val)
        {

            DataSet ds1 = new DataSet();
            ds1 = ob.fn_bind_ward(get_val);
            ddlward.DataSource = ds1;
            ddlward.DataTextField = "ward_name";
            ddlward.DataValueField = "ward_id";
            ddlward.DataBind();
            ddlward.Items.Add(new ListItem("--Select--", "0"));
            ddlward.SelectedValue = "0";

        }
 


        protected void sbmt_Click(object sender, EventArgs e)
        {
        
        }

        protected void ddlward_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

      

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
            string bin_lat = blat.Text;
            string bin_lon = blon.Text;
            string name = Request.Form["Name"];
            
              // route_id = Request.QueryString["route_id"].ToString();
            string r_id = Session["route_id"].ToString();
           
           
                
                //string route_id = ddl_route.SelectedValue;
         
            
                
                DataSet ds2 = new DataSet();
            
                
                //ds2 = ob.fn_insert_new_bin(name, blat.Text, blon.Text, b_name.Text, serialid.Text, DropDownList1.SelectedItem.Value.ToString(), ddlward.SelectedItem.Value.ToString());


                ds2 = ob.fn_insert_new_bin(name.Replace("'", "_"), blat.Text, blon.Text, b_name.Text, serialid.Text, ddlzone.SelectedValue, ddlward.SelectedValue, ddlward.SelectedItem.Text, ddlzone.SelectedItem.Text, r_id);
            
                
                // ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Bin Deployed Successfully');", true);

          
                
            if (ds2.Tables[0].Rows[0]["msg"].ToString() == "S")
            {
                MessageBox.Show("Bin Deployed Successfully");
            }
            else
                if (ds2.Tables[0].Rows[0]["msg"].ToString() == "N")
                {
                    MessageBox.Show(" Due to Some Problems Bin not Deployed Successfully");
                }

            blat.Text = "";
            blon.Text = "";
            b_name.Text = "";
            serialid.Text = "";
            }
            catch { }
        }



        protected void Btnupdate_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string name = Request.Form["Name"];
            ds = ob.fn_update_bin(ViewState["bin_id"].ToString(), ddlzone.SelectedValue, ddlward.SelectedValue, name, blat.Text, blon.Text, b_name.Text, serialid.Text, ddlzone.SelectedItem.Text, ddlward.SelectedItem.Text);
            if (ds.Tables[0].Rows[0]["msg"].ToString() == "S")
            {
                MessageBox.Show("Bin updated Successfully");
            }
            else
                if (ds.Tables[0].Rows[0]["msg"].ToString() == "N")
                {
                    MessageBox.Show("Due to Some Problem Bin Not Update");
                }
            Response.Redirect("Grid_View_bins.aspx");
        }

        protected void Btncancle_Click(object sender, EventArgs e)
        {
            
                Response.Redirect("Grid_View_bins.aspx");
            
        }


        [WebMethod]
        public static List<ListItem> get_route(string ward)
        {

            string query = "select * from Mst_Route_planner where wardid='" + ward + "'";
            string constr = ConfigurationManager.ConnectionStrings["DA_DBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    List<ListItem> customers = new List<ListItem>();
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers.Add(new ListItem
                            {
                                Value = sdr["routid"].ToString(),
                                Text = sdr["routeName"].ToString()
                            });
                        }
                    }
                    con.Close();
                    return customers;
                }
            }


        }

        [WebMethod]
        public static List<ListItem> GetCustomers()
        {
            string query = "Select * from zone_master";
            string constr = ConfigurationManager.ConnectionStrings["DA_DBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    List<ListItem> customers = new List<ListItem>();
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers.Add(new ListItem
                            {
                                Value = sdr["Zone_id"].ToString(),
                                Text = sdr["Zone_Name"].ToString()
                            });
                        }
                    }
                    con.Close();
                    return customers;
                }
            }
        }




        [WebMethod]
        public static List<ListItem> Getwards( string zone)
        {
            string query = "Select * from ward_master where zone_id='" + zone + "'";
            string constr = ConfigurationManager.ConnectionStrings["DA_DBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    List<ListItem> customers = new List<ListItem>();
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers.Add(new ListItem
                            {
                                Value = sdr["ward_id"].ToString(),
                                Text = sdr["ward_name"].ToString()
                            });
                        }
                    }
                    con.Close();
                    return customers;
                }
            }
        }

        protected void ddlzone_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = ddlzone.SelectedValue;
            bind_ward_bind(str);
        }

        protected void ddl_route_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void ddlward_SelectedIndexChanged1(object sender, EventArgs e)
        {
                 //       ddl_route_bind(ddlward.SelectedValue);
        }
    
    }
}