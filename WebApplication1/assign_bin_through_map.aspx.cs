using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MAPBusiness;
using MAPConnection;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.IO;
using System.Globalization;

namespace WebApplication1
{
    public partial class assign_bin_through_map : System.Web.UI.Page
    {
        connections con = new connections();
        map_procedures mp = new map_procedures();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<ListItem> get_route(string ward)
        {
            string query = "Select * from Mst_Route_planner where  wardid="+ward;
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

        public class MAPS
        {
            public string AreaName;
            public string lat;
            public string lon;
            public string BinId;
            public string Bin_Type;
            public string Areaid;
            public string Priority;
        }
      //  [WebMethod]
        //public static MAPS[] get_bin_acc_route(string s, string zone, string ward, string type)
        //{ 
        
        
        
        //}


    }
}