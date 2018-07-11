using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using GEN.Utility;
using MAPConnection;
using MAPBusiness;

namespace WebApplication1
{
    public partial class Add_Processing_Units : System.Web.UI.Page
    {
        /// <summary>
        /// created By Gajendra Singh
        /// Date 14/07/2017
        /// </summary>
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
                        // string bind = Session["binid"].ToString();
                        fn_edit_pu_Details(bind);
                    }

                }
                catch { }
            }
            }

        protected void fn_edit_pu_Details(string binid)
        {
            string name = Request.Form["Name"];

            DataSet edit_bin = new DataSet();
            edit_bin = ob.fn_edit_PU_Details(binid);
            DdlZone.SelectedValue = edit_bin.Tables[0].Rows[0]["Zone_id"].ToString();
            bind_ward_bind(edit_bin.Tables[0].Rows[0]["Zone_id"].ToString());
            DdlWard.SelectedValue = edit_bin.Tables[0].Rows[0]["wardid"].ToString();
            name = edit_bin.Tables[0].Rows[0]["AreaName"].ToString();
            string nm = name.Replace("_","'");
            ServerValue = edit_bin.Tables[0].Rows[0]["AreaName"].ToString();
            // get_address.Visible = true;
            blat.Text = edit_bin.Tables[0].Rows[0]["Lat"].ToString();
            blon.Text = edit_bin.Tables[0].Rows[0]["Lon"].ToString();
            f_name.Text = edit_bin.Tables[0].Rows[0]["name"].ToString();
            //serialid.Text = edit_bin.Tables[0].Rows[0]["SerialId"].ToString();
            Btnupdate.Visible = true;
            Button1.Visible = false;
            Btncancle.Visible = true;


        }





        protected void bind_ddl_zone()
        {
            ds = ob.fn_ddl_bind();
            DdlZone.DataSource = ds;
            DdlZone.DataValueField = "Zone_id";
            DdlZone.DataTextField = "Zone_Name";
            DdlZone.DataBind();
            DdlZone.Items.Add(new ListItem("--Select--", "0"));
            DdlZone.SelectedValue = "0";



        }
        protected void bind_ward_bind(string get_val)
        {

            DataSet ds1 = new DataSet();
            ds1 = ob.fn_bind_ward(get_val);
            DdlWard.DataSource = ds1;
            DdlWard.DataTextField = "ward_name";
            DdlWard.DataValueField = "ward_id";
            DdlWard.DataBind();
            DdlWard.Items.Add(new ListItem("--Select--", "0"));
            DdlWard.SelectedValue = "0";

        }


        protected void sbmt_Click(object sender, EventArgs e)
        {
            //    ds = ob.fn_insert_bins(B_id.Text, B_name.Text, areaid.Text, areaname.Text, blat.Text, blon.Text, zoneid.Text, zonenm.Text, wardid.Text, wardnm.Text);
            //   ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SomestartupScript", " alert(' BIn values Succesfully inserted ');", false);
            // insert_bin();
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = DdlZone.SelectedValue;
            bind_ward_bind(str);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string bin_lat = blat.Text;
            string bin_lon = blon.Text;
            string name = Request.Form["Name"];
            DataSet ds2 = new DataSet();
            //ds2 = ob.fn_insert_new_bin(name, blat.Text, blon.Text, b_name.Text, serialid.Text, DropDownList1.SelectedItem.Value.ToString(), DropDownList2.SelectedItem.Value.ToString());
            ds2 = ob.Fn_Insert_new_PU(DdlZone.SelectedItem.Text, DdlZone.SelectedValue, DdlWard.SelectedItem.Text, DdlWard.SelectedValue, name.Replace("'","_"), blat.Text, blon.Text, f_name.Text);
            // ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Bin Deployed Successfully');", true);
            if (ds2.Tables[0].Rows[0]["msg"].ToString() == "S")
            {
                MessageBox.Show("Processing Units added Successfully");
            }
            else
                if (ds2.Tables[0].Rows[0]["msg"].ToString() == "N")
                {
                    MessageBox.Show(" Due to Some Problems Processing Unit not Add");
                }

            blat.Text = "";
            blon.Text = "";
            f_name.Text = "";

        }



        protected void Btnupdate_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string name = Request.Form["Name"];
            ds = ob.fn_update_Processing_Units(ViewState["bin_id"].ToString(), DdlZone.SelectedValue, DdlWard.SelectedValue, name, blat.Text, blon.Text, f_name.Text, DdlZone.SelectedItem.Text, DdlWard.SelectedItem.Text);
            if (ds.Tables[0].Rows[0]["msg"].ToString() == "S")
            {
                MessageBox.Show("Processing Unit updated Successfully");
            }
            else
                if (ds.Tables[0].Rows[0]["msg"].ToString() == "N")
                {
                    MessageBox.Show("Due to Some Problem Processing Unit  Not Update");
                }
            Response.Redirect("View_Processing_Units.aspx");
        }

        protected void Btncancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("View_Processing_Units.aspx");
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
        public static List<ListItem> Getwards(string zone)
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

        }
}