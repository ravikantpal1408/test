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
using System.Collections;


namespace WebApplication1
{
    public partial class plan_scheduling : System.Web.UI.Page
    {


        DataSet ds = new DataSet();
        business ob = new business();
        connections con= new connections();

        ArrayList arraylist1 = new ArrayList();
        ArrayList arraylist2 = new ArrayList();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               // getBinPriorityList(string zone_id);
                BIND_ddl_zone();
                //edit_schedule();
            }
           
            
           
        }
        protected void BIND_ddl_zone()
        {
            DataSet ddl_z = con.FN_ExecuteQuerySingle("select *from zone_master");
            ddl_zone.DataSource = ddl_z;
            ddl_zone.DataTextField = "Zone_Name";
            ddl_zone.DataValueField = "Zone_id";
            ddl_zone.DataBind();
            ddl_zone.Items.Add(new ListItem("--Select--", "0"));
            ddl_zone.SelectedValue = "0";
       
        
        
        }
        protected void BIND_ddl_ward(string zone_id)
        {
        
                DataSet ddl_w = con.FN_ExecuteQuerySingle("select * from ward_master where Zone_id='" + zone_id + "'");
                ddl_ward.DataSource = ddl_w;
                ddl_ward.DataTextField = "ward_name";
                ddl_ward.DataValueField = "ward_id";
                ddl_ward.DataBind();
                ddl_ward.Items.Add(new ListItem("--Select--", "0"));
                ddl_ward.SelectedValue = "0";
       
            
        
        }

        public void GetListItemsIntoDB()
        {
            DateTime today = DateTime.Today;
      

            DataSet get_bin = new DataSet();
            if (ListRight.Items.Count > 0)
            {

                for (int i = 0; i < ListRight.Items.Count; i++)
                {


                 
                    get_bin = con.FN_ExecuteQuerySingle("select BinName,Latitude,Longitude,Priority,Type from Mst_Bin where BinId='" + ListRight.Items[i].Value + "' and StatusB='A'");


                    string binid = ListRight.Items[i].Value;
                    string BinNAme = get_bin.Tables[0].Rows[0]["BinName"].ToString();
                    string lat = get_bin.Tables[0].Rows[0]["Latitude"].ToString();
                    string lon = get_bin.Tables[0].Rows[0]["Longitude"].ToString();
                    string Prior = get_bin.Tables[0].Rows[0]["Priority"].ToString();
                    string type = get_bin.Tables[0].Rows[0]["Type"].ToString();
                    string order = Convert.ToInt32(i + 1).ToString();
                    

                    DataSet ins_plan = new DataSet();
                    //ins_plan = con.FN_ExecuteQuerySingle("update Mst_schedule_collecttion set BinId='"+binid+"',lat='"+lat+"',lon='"+lon+"',Type='"+type+"',Priority='"+Prior+"',Sequence='"+order+"'");
                    ins_plan = ob.fn_plan_schedule(binid, BinNAme, lat, lon, type, Prior, order, today);
              


                }
                MessageBox.Show("Route Successfully Planned.");
            }
           

        
        }


        protected void getBinPriorityList(string zone_id ,string ward_id)
        {
            try
            {
                if (zone_id != "0" && ward_id == "0")
                {
                    ds = ob.getBinPriorityList(zone_id);
                    ListLeft.DataSource = ds;
                    ListLeft.DataValueField = "BinId";
                    ListLeft.DataTextField = "Bin";
                    ListLeft.DataBind();
                }
                else if (zone_id != "0" && ward_id != "0")
                {
                    ds = ob.getBinPriorityList_ward_zone(zone_id, ward_id);
                    ListLeft.DataSource = ds;
                    ListLeft.DataValueField = "BinId";
                    ListLeft.DataTextField = "Bin";
                    ListLeft.DataBind();

                }
                else if (zone_id == "0" && ward_id == "0")
                {
                    ListLeft.Items.Clear();


                }

            }
            catch { }
        }

        protected void TransferRight()
        {
            if (ListLeft.SelectedIndex >= 0)
            {

                ListItem match = ListRight.Items.FindByValue(ListLeft.SelectedValue);
                if (match != null)
                {
                    MessageBox.Show("Already Exist");
                }
                else {


                    ListRight.Items.Add(ListLeft.SelectedItem);
                    ListLeft.Items.Remove(ListLeft.SelectedItem);
                
                }


            }
      
            else
            {
                MessageBox.Show("NO BIN ID SELECTED !! ");
              
            }
        
        
        }
        protected void TransferLeft()
        {
            if (ListRight.SelectedIndex >= 0)
            {


                ListLeft.Items.Add(ListRight.SelectedItem);
                ListRight.Items.Remove(ListRight.SelectedItem);


            }
            else {

                MessageBox.Show("NO BIN ID SELECTED !! ");
            }
        
        
        
        }

        protected void btnLeft_Click(object sender, EventArgs e)
        {
            try
            {
               
                TransferRight();
            }
            catch { }
        }

        protected void btnRight_Click(object sender, EventArgs e)
        {
            try
            {
                TransferLeft();
            }
            catch { }
        }

        protected void ddl_zone_SelectedIndexChanged(object sender, EventArgs e)
        {
           // BIND_ddl_zone();
           BIND_ddl_ward(ddl_zone.SelectedItem.Value);
           getBinPriorityList(ddl_zone.SelectedItem.Value, ddl_ward.SelectedItem.Value);
        }

        protected void ddl_ward_SelectedIndexChanged(object sender, EventArgs e)
        {
            getBinPriorityList(ddl_zone.SelectedItem.Value, ddl_ward.SelectedItem.Value);
           // ListRight.Items.Clear();

        }

        protected void sbt_plan_Click(object sender, EventArgs e)
        {
            
            DataSet check = new DataSet();
            DateTime today = DateTime.Today;
            check = con.FN_ExecuteQuerySingle("select * from Mst_schedule_collecttion where Date='" + today + "'");
            try
            {
                if (check.Tables[0].Rows.Count > 0)
                {
                    DataSet del = new DataSet();
                    del = con.FN_ExecuteQuerySingle("delete from Mst_schedule_collecttion where Date='" + today + "'");


                }
            }
            catch { }
            GetListItemsIntoDB();
            ListRight.Items.Clear();
            ListLeft.Items.Clear();

        }

        protected void btn_view_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm2.aspx");
        }

        protected void btn_edit_schedule_Click(object sender, EventArgs e)
        {
            edit_schedule();
    
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            DataSet get_data = new DataSet();
            get_data = con.FN_ExecuteQuerySingle("select * from Mst_schedule_collecttion where Date='" + today + "'");

            try{
                if (get_data.Tables[0].Rows.Count > 0)
                   {

                       DataSet del = new DataSet();
                       del = con.FN_ExecuteQuerySingle("delete from Mst_schedule_collecttion where Date='" + today + "'");
                   }            
            }
            catch{}
           update_plan();
           ListRight.Items.Clear();
           ListLeft.Items.Clear();
        }


        public void edit_schedule()
        {
            DateTime today = DateTime.Today;
            DataSet edit_s = new DataSet();
            edit_s = con.FN_ExecuteQuerySingle("select BinId , BinName,Sequence from Mst_schedule_collecttion where Date='"+today+"'");
            ListRight.DataSource = edit_s;
            ListRight.DataTextField = "BinName";
            ListRight.DataValueField = "BinId";
            ListRight.DataBind();
            ListLeft.Items.Clear();
            btn_update.Visible = true;
            sbt_plan.Visible = false;
            btn_edit_schedule.Visible = false;
            btnRight.Visible = false;
            Remove.Visible = true;


        
        
        
        }


        protected void Remove_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            string slect = ListRight.SelectedValue;
            ListRight.Items.Remove(ListRight.SelectedItem);
            DataSet remove = new DataSet();
            try
            {
                remove = con.FN_ExecuteQuerySingle("Delete from Mst_schedule_collecttion where BinId='" + slect + "' and Date='" + today + "'");
              
            }
            catch { }
        }

        public void update_plan()
        {
            DataSet update_plan = new DataSet();
            
            DateTime today = DateTime.Today;
            try
            {
                if (ListRight.Items.Count > 0)
                {
                    for (int c = 0; c < ListRight.Items.Count; c++)
                    {

                        DataSet get_bin = new DataSet();
                        get_bin = con.FN_ExecuteQuerySingle("select BinId,BinName,Latitude,Longitude,Priority,Type from Mst_Bin where BinId='" + ListRight.Items[c].Value + "' and StatusB='A'");
                        string b_id = get_bin.Tables[0].Rows[0]["BinId"].ToString();
                        string b_name = get_bin.Tables[0].Rows[0]["BinName"].ToString();
                        string b_lat = get_bin.Tables[0].Rows[0]["Latitude"].ToString();
                        string b_lon = get_bin.Tables[0].Rows[0]["Longitude"].ToString();
                        string b_priority = get_bin.Tables[0].Rows[0]["Priority"].ToString();
                        string b_type = get_bin.Tables[0].Rows[0]["Type"].ToString();
                        string b_Sequence = Convert.ToInt32(c + 1).ToString();

                        DataSet ins_bin = new DataSet();
                        ins_bin = ob.FN_insert_bins(b_id, b_name, b_lat, b_lon, b_type, b_priority, b_Sequence, today);


                    }
                    MessageBox.Show("Schedule Updated Successfully");
                }
                else {

                    MessageBox.Show("LIST IS EMPTY");
                }

                   

                }


            catch { }


        }

        protected void ListRight_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ListLeft_SelectedIndexChanged(object sender, EventArgs e)
        {
     
        }

     

    }
}