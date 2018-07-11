using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MAPBusiness;

namespace WebApplication1
{
    public partial class Fomr_Bins : System.Web.UI.Page
    {

        business ob = new business();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            bind_bin_grid();
        }
        protected void bind_bin_grid()
        {
            ds = ob.fn_bind_bin_grid();
            GridView1.DataSource = ds;
            GridView1.DataBind();
            
        
        }
    }
}