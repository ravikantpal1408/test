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
    public partial class LoginIOT : System.Web.UI.Page
    {
        connections con = new connections();


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            if ((Uid.Value != "" || Uid.Value != null)&&(pass.Value!=""||pass.Value!=null))
            {
                try
                {
                    DataSet ds = new DataSet();
                    ds = con.FN_ExecuteQuerySingle("select * from MST_USER where username='" + Uid.Value + "' and   userpassword='" + pass.Value + "'");// and usertype='"++ 
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["usertype"].ToString() == "A")
                        { 
                            Session["uid"] = Uid.Value;
                            Session["type"] = ds.Tables[0].Rows[0]["usertype"].ToString();
                            string sest = Session["type"].ToString();
                            Response.Redirect("Home_page.aspx");//cityid=" + ds.Tables[0].Rows[0]["cityid"].ToString()
                    
                        }
                        if (ds.Tables[0].Rows[0]["usertype"].ToString() == "U")
                        {
                            Session["uid"] = Uid.Value;
                            Session["type"] = ds.Tables[0].Rows[0]["usertype"].ToString();
                            string sess = Session["type"].ToString();
                            Response.Redirect("Home_page.aspx");
                        
                        }


                    }
                    else
                    {

                        MessageBox.Show("User Does not Exist!!");


                    }
                }
                catch { }
            
            
            }
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}