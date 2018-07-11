using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using MAPBusiness;
using MAPConnection;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using GEN.Utility;


namespace WebApplication1
{
    public partial class plan_collection : System.Web.UI.Page
    {

        DataSet ds = new DataSet();
        connections con = new connections();
        business ob = new business();

        protected void Page_Load(object sender, EventArgs e)
        {
            BindDummyItem();
            //bind_grid();
        }

        public class MAPS
        {
            public string BinName;
            public string lat;
            public string lon;
            public string BinId;
            public string Type;
            public string SPriority;
            public string routeid;
            public string AreaName;
            public string Bin_Type;
            public string Priority;
            public string status;
        }
        //fn_del_bin
        [WebMethod]
        public static string fn_del_bin(string binid)
        {
            DataSet ds = new DataSet();
            business ob = new business();
            connections con = new connections();
            ds = con.FN_ExecuteQuerySingle("update Mst_Bin_Collection set status='D' where binid='" + binid + "'");
            return "0";
        }
        //fn_get_route_rt
        [WebMethod]
        public static List<ListItem> GetZone()
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
        //fn_get_route
        [WebMethod]
        public static List<ListItem> fn_ddl_route(string ward)
        {

            string query = "Select routid,routeName from Mst_Route_planner where wardid='" + ward + "'";
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
        public static MAPS[] ConvertDataTabletoString(string s, string zone, string ward, string type, string rid)
        {

            List<MAPS> lstMarkers = new List<MAPS>();
            DataSet ds = new DataSet();
            business ob = new business();
            connections con = new connections();
            DataTable dt = new DataTable();

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();



            dt.Columns.Add("AreaName");
            dt.Columns.Add("lat");
            dt.Columns.Add("lon");
            dt.Columns.Add("BinId");
            dt.Columns.Add("Bin_Type");
            dt.Columns.Add("Priority");
            dt.Columns.Add("routeid");
            dt.Columns.Add("status");
            try
            {
                if (s == "1")
                {
                    ds = ob.fn_get_bin_routewise(s, zone, ward, type, rid);//all bin  bind



                }
            }
            catch { }



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
                        dr["routeid"] = ds.Tables[0].Rows[i]["routeid"].ToString();
                        dr["status"] = ds.Tables[0].Rows[i]["status"].ToString();
                        dt.Rows.Add(dr);

                    }
                }
            }
            catch { }

            foreach (DataRow dtrow in dt.Rows)
            {
                MAPS objMAPS = new MAPS();
                objMAPS.AreaName = dtrow[0].ToString();
                objMAPS.lat = dtrow[1].ToString();
                objMAPS.lon = dtrow[2].ToString();
                objMAPS.BinId = dtrow[3].ToString();
                
                objMAPS.Bin_Type = dtrow[4].ToString();
                objMAPS.Priority = dtrow[5].ToString();
                objMAPS.routeid = dtrow[6].ToString();
                objMAPS.status = dtrow[7].ToString();
                lstMarkers.Add(objMAPS);

            }




            return lstMarkers.ToArray();

            //return serializer.Serialize(rows);

        }
        //fn_get_wards
        [WebMethod]
        public static List<ListItem> fn_get_wards(string zone)
        {


            string query = "select ward_id,ward_name from ward_master where Zone_id='" + zone + "'";
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

        [WebMethod]
        public static string fn_change_routesss(string binid,string binName,string lat,string lon, string zone, string ward, string rid)
        {
            DataSet ds = new DataSet();
            connections con = new connections();
            DateTime today = DateTime.Today;
            DataSet type = new DataSet();
            type = con.FN_ExecuteQuerySingle("select Type,Priority from Mst_Bin where BinId='"+binid+"'");
            string typ = type.Tables[0].Rows[0]["Type"].ToString();
            string prior = type.Tables[0].Rows[0]["Priority"].ToString();

            ds = con.FN_ExecuteQuerySingle("FN_change_route_rt_proc" + "'" + binid + "','" + binName + "','" + lat + "','" + lon + "','" + typ + "','" + prior + "','" + zone + "','" + ward + "','" + rid + "','" + today + "'");

            return "s";
        }

        //fn_get_route_zone_ws

        [WebMethod]
        public static List<ListItem> fn_get_route_zone_ws(string zone)
        {


            string query = "select distinct routeid,Mst_Route_planner.routeName from Mst_Bin inner join Mst_Route_planner on Mst_Bin.routeid=Mst_Route_planner.routid where Zoneid='"+zone+"'";
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
                                Value = sdr["routeid"].ToString(),
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
        public static string fn_Schedule_bins_(string mar, string veh, string vtype, string driverID, string dname)
        {
            DateTime today = DateTime.Today;
            DataSet dm=new DataSet();
            DataSet ds = new DataSet();
            connections con = new connections();

            try
            {
                string[] slice = mar.Split(',');
                for (int ij = 0; ij < slice.Length; ij++)
                {
                    DataSet check = new DataSet();

                    //check = con.FN_ExecuteQuerySingle("Fn_check_proc_"+"'" + slice[ij] + "'");
                  
                        dm = con.FN_ExecuteQuerySingle("select * from Mst_Bin where BinId='" + slice[ij] + "'");
                        string bin_name = dm.Tables[0].Rows[0]["BinName"].ToString();
                        string z_id = dm.Tables[0].Rows[0]["Zoneid"].ToString();
                        string w_id = dm.Tables[0].Rows[0]["wardid"].ToString();
                        string r_id = dm.Tables[0].Rows[0]["routeid"].ToString();
                        dm = con.FN_ExecuteQuerySingle("select Zone_Name from zone_master where Zone_id='" + z_id + "'");
                        string z_nm = dm.Tables[0].Rows[0]["Zone_Name"].ToString();
                        dm = con.FN_ExecuteQuerySingle("select ward_name from ward_master where ward_id='" + w_id + "'");
                        string w_nm = dm.Tables[0].Rows[0]["ward_name"].ToString();
                        
                        dm = con.FN_ExecuteQuerySingle("select routeName from Mst_Route_planner where routid='" + r_id + "'");
                        string r_name = dm.Tables[0].Rows[0]["routeName"].ToString();
                        dm = con.FN_ExecuteQuerySingle("select DriverName from Mst_Drivers where DriverID='" + driverID + "'");
                        string drivernm = dm.Tables[0].Rows[0]["DriverName"].ToString();
                        dm = con.FN_ExecuteQuerySingle("select vehicle_type from Mst_Vehicles where [vehicle_num]='" + veh + "'");
                        string vh = dm.Tables[0].Rows[0]["vehicle_type"].ToString();
                        //dm=con.FN_ExecuteQuerySingle("select vehicle_num from Mst_Vehicles where routid='"+route+"'");
                        ds = con.FN_ExecuteQuerySingle("insert into Mst_Bin_Collection (binid,bin_name,zone_name,ward_name,route_name,vehicle,[Vehicle Type],[Driver ID],Driver,Date,status) values('" + slice[ij] + "','" + bin_name + "','" + z_nm + "','" + w_nm + "','" + r_name + "','" + veh + "','" + vh + "','" + driverID + "','" + drivernm + "','" + today + "','P')");
               

                }
            }
            catch { }



                return "0";
        }
        public void BindDummyItem()
        {
            DataTable dtGetData = new DataTable();
            dtGetData.Columns.Add("BinId");
            dtGetData.Columns.Add("BinName");
            dtGetData.Columns.Add("Zone");
            dtGetData.Columns.Add("Ward");
            dtGetData.Columns.Add("Route");
            dtGetData.Columns.Add("Vehicle");
            dtGetData.Columns.Add("Vehicle Type");
            dtGetData.Columns.Add("Driver ID");
            dtGetData.Columns.Add("Driver");
            dtGetData.Columns.Add("Date");
            dtGetData.Rows.Add();

            
        }
        [WebMethod]
        public static DetailsClass[] fn_get_grid_data() //GetData function
        {
           List<DetailsClass> Detail = new List<DetailsClass>();

           DateTime today = DateTime.Today;
           string SelectString = "select binid,bin_name,zone_name,ward_name,route_name,vehicle,[Vehicle Type],[Driver ID],Driver,format(convert(date,Date),'dd/MM/yyyy') as Date,status from Mst_Bin_Collection where Date='" + today + "' and status='P' order by DAY(Date) DESC";
           SqlConnection cn = new SqlConnection("Data Source=192.168.0.171;Initial Catalog=ACME_IOT;Persist Security Info=True;User ID=sa;Password=asdzxc@987");
           SqlCommand cmd = new SqlCommand(SelectString,cn);
           cn.Open();

           SqlDataAdapter da = new SqlDataAdapter(cmd);
           DataTable dtGetData = new DataTable();

           da.Fill(dtGetData);


           foreach(DataRow dtRow in dtGetData.Rows)
           {
               DetailsClass DataObj = new DetailsClass();
               DataObj.BinId = dtRow["binid"].ToString();
               DataObj.BinName = dtRow["bin_name"].ToString();
               DataObj.Zone = dtRow["zone_name"].ToString();
               DataObj.Ward = dtRow["ward_name"].ToString();
               DataObj.Route = dtRow["route_name"].ToString();
               DataObj.Vehicle = dtRow["vehicle"].ToString();
               DataObj.vtype = dtRow["Vehicle Type"].ToString();
               DataObj.did = dtRow["Driver ID"].ToString();
               DataObj.dnm = dtRow["Driver"].ToString();
               DataObj.Date = dtRow["Date"].ToString();
               Detail.Add(DataObj);
           }

           return Detail.ToArray();
       }
       public class DetailsClass //Class for binding data
       {
           public string BinId { get; set; }
           public string BinName { get; set; }
           public string Zone { get; set; }
           public string Ward { get; set; }
           public string Route { get; set; }
           public string Vehicle { get; set; }
           public string vtype { get; set; }
           public string did { get; set; }
           public string dnm { get; set; }
           public string Date { get; set; }
           

       }


        [WebMethod]
        public static List<ListItem> fn_get_zone()
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
        public static List<ListItem> fn_get_driver()
        {
            DateTime today = DateTime.Today;

            string query = "Select * from Mst_Drivers ";
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
                                Value = sdr["DriverID"].ToString(),
                                Text = sdr["DriverName"].ToString()
                            });
                        }
                    }
                    con.Close();
                    return customers;
                }
            }



        }
        //fn_get_pre_routes

        [WebMethod]
        public static List<ListItem> fn_get_pre_routes()
        {
            DateTime today = DateTime.Today;

            string query = "Select distinct route_name from Mst_Bin_Collection where Date='" + today + "' and status='P'";
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
                                Value = sdr["route_name"].ToString(),
                                Text = sdr["route_name"].ToString()
                            });
                        }
                    }
                    con.Close();
                    return customers;
                }
            }



        }



        [WebMethod]
        public static List<ListItem> fn_get_ward(string zone)
        {


            string query = "Select * from ward_master where Zone_id='" + zone + "'";
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
     
        //fn_get_vehicle
        [WebMethod]
        public static List<ListItem> fn_get_vehicle()
        {


            string query = "Select * from Mst_Vehicles ";
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
                                Value = sdr["vehicle_num"].ToString(),
                                Text = sdr["vehicle_type"].ToString()
                            });
                        }
                    }
                    con.Close();
                    return customers;
                }
            }



        }
        [WebMethod]
        public static List<ListItem> fn_get_route(string rid)
        {


            string query = "Select * from Mst_Route_planner where wardid='" + rid + "'";
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
        public static string fn_Select_bins(string binid)
        {
            DataSet ds = new DataSet();
            connections con = new connections();
            ds = con.FN_ExecuteQuerySingle("select * from Mst_Bin where BinId='" + binid + "' and StatusB='A'");
            return "0";
        }

 
      
    }
}