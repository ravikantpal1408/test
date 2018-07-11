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
    public partial class map : System.Web.UI.Page
    {

        DataSet ds = new DataSet();
        business ob = new business();
        DataTable dt = new DataTable();
        //string lat = string.Empty;
        //string lon = string.Empty;
        //string area = string.Empty;


        protected void Page_Load(object sender, EventArgs e)
        {
            map_bind();
          // createdatatable();
        }
        protected void map_bind()
        {
            ds = ob.fn_map_bind();
            createdatatable();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();

                    dr["AreaName"] = ds.Tables[0].Rows[i]["AreaName"].ToString();

                    dr["Latitude"] = ds.Tables[0].Rows[i]["Lat"].ToString();
                    dr["Longitude"] = ds.Tables[0].Rows[i]["Lon"].ToString();
                    dr["Type"] = ds.Tables[0].Rows[i]["Type"].ToString();
                    //area.Text=ds.Tables[0].Rows[0]["AreaName"].ToString();
                    //lat.Text = ds.Tables[0].Rows[0]["lat"].ToString();
                    //lon.Text = ds.Tables[0].Rows[0]["lon"].ToString();}
                    dt.Rows.Add(dr);
                }

                rptMarkers.DataSource = dt;
                rptMarkers.DataBind();

            }
        }
        public void createdatatable()
        {
            dt.Columns.Add("AreaName");
            dt.Columns.Add("Latitude");
            dt.Columns.Add("Longitude");
            dt.Columns.Add("Type");

        

        }
    }
}