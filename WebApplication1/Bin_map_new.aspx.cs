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
    public partial class Bin_map_new : System.Web.UI.Page
    {
        DataSet dslocation = new DataSet();
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        business ob = new business();
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataSet dsbinid = new DataSet();
        connections con = new connections();
        map_procedures mp = new map_procedures();
        DataSet getPU = new DataSet();
        DataSet select = new DataSet();



        string jam = string.Empty;


        protected void Page_Load(object sender, EventArgs e)
        {

          

           
           
            
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
            string query = "Select * from ward_master where Zone_id=" + zone;
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
        [WebMethod]
        public static string setpriority(string prior, string lat)
        {
            if (prior == "Remove")
            {
                DataSet rem = new DataSet();
                business obj2 = new business();
                rem = obj2.fn_remove_prior(lat);
                return "Priority removed ";

            }
            else
            {
                DataSet pr = new DataSet();
                business ob1 = new business();
                pr = ob1.fn_set_priority(prior, lat);
                return "Priority set Successfully";
            }
    

        }

      


        [WebMethod]
        public static MAPS[] ConvertDataTabletoString(string s, string zone, string ward, string type)
        {

            List<MAPS> lstMarkers = new List<MAPS>();
            DataSet dslocation = new DataSet();
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            business ob = new business();
            DataTable dt1 = new DataTable();
            DataSet dsbinid = new DataSet();
            connections con = new connections();
            map_procedures mp = new map_procedures();
            DataSet getPU = new DataSet();
            DataSet select = new DataSet();
            string jam = string.Empty;
            DataSet get_PU_zn_ws = new DataSet();

            DataTable dt = new DataTable();
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            DataTable dt12 = new DataTable();


            dt.Columns.Add("AreaName");
            dt.Columns.Add("lat");
            dt.Columns.Add("lon");
            dt.Columns.Add("BinId");
            dt.Columns.Add("Bin_Type");
            dt.Columns.Add("Priority");





            if (s == "1")
            {
                ds = ob.fn_map_bind(s, zone, ward, type);//all bin  bind



            }
            else if (s == "2")
            {
                ds1 = ob.fn_feeders_bind(s, zone, ward);//only feeders s,zone,ward
            }
            else if (s == "3")
            {
                getPU = ob.fn_get_PU(s, zone, ward);//only processing units
            }

            else
            {
                ds = ob.fn_map_bind(s, zone, ward, type); //for binding bins 

                getPU = ob.fn_get_PU(s, zone, ward); //for binding Processing points

                ds1 = ob.fn_feeders_bind(s, zone, ward);//for binding feeders points 
            }
            try
            {


                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)//binding bins 
                    {
                        DataRow dr = dt.NewRow();


                        dr["BinId"] = ds.Tables[0].Rows[i]["BinId"].ToString();

                        dr["AreaName"] = ds.Tables[0].Rows[i]["BinName"].ToString();

                        dr["lat"] = ds.Tables[0].Rows[i]["Latitude"].ToString();
                        dr["lon"] = ds.Tables[0].Rows[i]["Longitude"].ToString();





                        dr["Bin_Type"] = ds.Tables[0].Rows[i]["Type"].ToString();

                        dr["Priority"] = ds.Tables[0].Rows[i]["Priority"].ToString();
                        dt.Rows.Add(dr);

                    }
                }
            }
            catch { }
            try
            {

                if (ds1.Tables[0].Rows.Count > 0)//feeders 
                {

                    for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                    {
                        DataRow dr1 = dt.NewRow();

                        dr1["lat"] = ds1.Tables[0].Rows[j]["lat"].ToString();
                        dr1["lon"] = ds1.Tables[0].Rows[j]["lon"].ToString();
                        dr1["AreaName"] = ds1.Tables[0].Rows[j]["FeederName"].ToString();
                        dr1["Bin_Type"] = ds1.Tables[0].Rows[j]["Type"].ToString();

                        dt.Rows.Add(dr1);
                    }
                }
            }
            catch { }


            try
            {
                if (getPU.Tables[0].Rows.Count > 0)//processing units
                {
                    for (int k = 0; k < getPU.Tables[0].Rows.Count; k++)
                    {
                        DataRow dr2 = dt.NewRow();

                        dr2["lat"] = getPU.Tables[0].Rows[k]["lat"].ToString();
                        dr2["lon"] = getPU.Tables[0].Rows[k]["lon"].ToString();
                        dr2["AreaName"] = getPU.Tables[0].Rows[k]["name"].ToString();
                        dr2["Bin_Type"] = getPU.Tables[0].Rows[k]["Type"].ToString();

                        dt.Rows.Add(dr2);
                    }
                }
            }

            catch
            {

            }
            foreach (DataRow dtrow in dt.Rows)
            {
                MAPS objMAPS = new MAPS();
                objMAPS.AreaName = dtrow[0].ToString();
                objMAPS.lat = dtrow[1].ToString();
                objMAPS.lon = dtrow[2].ToString();
                //objMAPS.Areaid = dtrow[0].ToString();
                objMAPS.Bin_Type = dtrow[4].ToString();
                objMAPS.BinId = dtrow[3].ToString();
                objMAPS.Priority = dtrow[5].ToString();
                lstMarkers.Add(objMAPS);

            }




            return lstMarkers.ToArray();

            //return serializer.Serialize(rows);

        }



        public static void createdatatable(DataTable dt)
        {
            // dt.Columns.Add("id");
            dt.Columns.Add("Areaid");
            dt.Columns.Add("AreaName");
            dt.Columns.Add("lat");
            dt.Columns.Add("lon");
            dt.Columns.Add("BinId");
            dt.Columns.Add("Bin_Type");
            //dt.Columns.Add("Feeder");
            //dt.Columns.Add("PU");



        }

        private DataTable GetData(string query, params object[] queryParameters)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DA_DBConnectionString"].ConnectionString))
            using (SqlCommand cmd = con.CreateCommand())
            {
                if (queryParameters != null && queryParameters.Length != 0)
                {
                    IFormatProvider provider = CultureInfo.InvariantCulture;
                    for (int index = 0; index < queryParameters.Length; index++)
                    {
                        string name = "@P" + index;
                        string placeholder = "{" + index + "}";
                        query = query.Replace(placeholder, name);
                        cmd.Parameters.AddWithValue(name, queryParameters[index] ?? DBNull.Value);
                    }
                }

                cmd.CommandText = query;

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    return dt;
                }
            }
        }


        protected void DropDownList2_SelectedIndexChanged1(object sender, System.EventArgs e)
        {


        }





        protected void ddl_zone_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddl_filter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    

      
   

    }
}