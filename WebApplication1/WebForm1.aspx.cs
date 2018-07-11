using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //localhost1.demo bing=new localhost1.demo();
            //string a = TextBox1.Text.Trim();
            //ds = bing.HelloWorld(a);
            //label1.Text = ds.Tables[0].Rows[0]["lat"].ToString();
        }
    }
}