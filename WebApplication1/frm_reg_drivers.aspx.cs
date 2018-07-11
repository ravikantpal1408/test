using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MAPConnection;
using GEN.Utility;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;

namespace WebApplication1
{
    public partial class frm_reg_drivers : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        connections con = new connections();
        protected void Page_Load(object sender, EventArgs e)
        {
            string d_id = string.Empty;
            if (!IsPostBack)
            {
                try
                {
                    if (Request.QueryString["d_id"].ToString() != null)
                    {
                        d_id = Request.QueryString["d_id"].ToString();

                        Edit_driver_details(d_id);
                    }
                    
                }
                catch { }
            }
        }
        public void Edit_driver_details(string d_id)
        {
            bt_sbt.Visible = false;
            udpt.Visible = true;
            
            txt_licence.ReadOnly = true;
            ds = con.FN_ExecuteQuerySingle("select name,licence_n,p_address,r_address,email,mobile,format(convert(date,dob),'dd-MM-yyyy') as dob ,typeOFveh from MSt_driver_Reg where licence_n='" + d_id + "'");
            string name = ds.Tables[0].Rows[0]["name"].ToString();


             txt_name.Text = name;
             txt_licence.Text = ds.Tables[0].Rows[0]["licence_n"].ToString();
             txt_p_add.Text = ds.Tables[0].Rows[0]["p_address"].ToString();
             txt_c_add.Text = ds.Tables[0].Rows[0]["r_address"].ToString();
             txt_email.Text = ds.Tables[0].Rows[0]["email"].ToString();
            // txt_licence.Text = ds.Tables[0].Rows[0]["licence_n"].ToString();
             txt_mbl.Text = ds.Tables[0].Rows[0]["mobile"].ToString();
             txt_dob.Text = ds.Tables[0].Rows[0]["dob"].ToString();
            
             string veh = ds.Tables[0].Rows[0]["typeOFveh"].ToString();
             string vh = "Previous Select:- "+" "+veh.Replace("_", ",");
            if(veh!="")
            {
                lbl_msg.Visible = true;
                lbl_msg.Text =vh;
             }//string v1 = veh.Split("_".ToCharArray())[0];
             //string v2 = veh.Split("_".ToCharArray())[1];
             //string v3 = veh.Split("_".ToCharArray())[2];
             //if (v1 == "Dumper")
             //{
             //    //chk_veh.ThreeState= true;
             
             //}
     
        
        }


        public void fn_reg_Driver()
        {
            try
            {
                string veh_type = "";

                string name = txt_name.Text;
                string licence = txt_licence.Text;
                string p_address = txt_p_add.Text;
                string c_address = txt_c_add.Text;
                string e_mail = txt_email.Text;
                string mbl = txt_mbl.Text;
                string dob = txt_dob.Text;

                for (int i = 0; i < chk_veh.Items.Count; i++)
                {
                    if (chk_veh.Items[i].Selected) 
                            {
                                if (veh_type == "") 
                                {
                                    veh_type = chk_veh.Items[i].Text; 
                                }
                                 else 
                                {
                                    veh_type += "_" + chk_veh.Items[i].Text; 
                                } 
                            } 
                  

                }

            
                    ds = con.FN_ExecuteQuerySingle("fn_reg_Driver_proc" + "'" + name + "','" + licence + "','" + p_address + "','" + c_address + "','" + e_mail + "','" + mbl + "','" + Utility.DateTimeFormat(dob) + "','" + veh_type + "'");

                    if (ds.Tables[0].Rows[0]["msg"].ToString() == "1")
                    {
                        MessageBox.Show("Registration Success!!");
                    }
                    else
                    {
                        MessageBox.Show("Registration Failed!!");
                    
                    }
                    
            }
            catch {

                MessageBox.Show("Select Atleast on Vehicle");
            
            }
        }

        protected void bt_sbt_Click(object sender, EventArgs e)
        {
            fn_reg_Driver();
        }

     

        protected void udpt_Click1(object sender, EventArgs e)
        {
            string veh_type = "";
            for (int i = 0; i < chk_veh.Items.Count; i++)
            {
                if (chk_veh.Items[i].Selected)
                {
                    if (veh_type == "")
                    {
                        veh_type = chk_veh.Items[i].Text;
                    }
                    else
                    {
                        veh_type += "_" + chk_veh.Items[i].Text;
                    }
                }


            }
            try
            {

                DataSet udp = new DataSet();
                udp = con.FN_ExecuteQuerySingle("update_driver_prof_proc " + "'" + txt_name.Text + "','" + txt_licence.Text + "','" + txt_p_add.Text + "','" + txt_c_add.Text + "','" + txt_email.Text + "','" + txt_mbl.Text + "','" + Utility.DateTimeFormat(txt_dob.Text) + "','" + veh_type + "'");


                MessageBox.Show("Update Success!!");

            }
            catch { }
        }
    }
}