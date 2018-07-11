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

namespace WebApplication1
{
    public partial class pre_defined_routes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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

            

            try
            {

                if (s == "1")
                {
                    ds = ob.fn_pre_defined_path(s, zone, ward, type, rid);//all bin  bind



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
                //objMAPS.Areaid = dtrow[0].ToString();
                objMAPS.Bin_Type = dtrow[4].ToString();
                objMAPS.Priority = dtrow[5].ToString();
                objMAPS.routeid = dtrow[6].ToString();
                lstMarkers.Add(objMAPS);

            }




            return lstMarkers.ToArray();

            //return serializer.Serialize(rows);

        }


       
        [WebMethod]
        public static List<ListItem> get_r_zn_ws()
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
        public static List<ListItem> get_selected_route(string routeid)
        {
           
            string query = "Select routid,routeName from Mst_Route_planner";
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
        public static string  update_route(string id, string lat, string lon, string routeid)
        {
            DataSet ds = new DataSet();
            business ob = new business();

            ds = ob.fn_update_route_for_bin(id, lat, lon, routeid);




            return "Route Updated Successfully";
        
        
        
        }
   
        [WebMethod]
        public static string fn_assignment(string binid,string lat,string lon, string rid)
        {   

            DataSet assign = new DataSet();
            connections ob = new connections();
            assign = ob.FN_ExecuteQuerySingle("update Mst_Bin set routeid='"+rid+"',Latitude='"+lat+"' ,Longitude='"+lon+"' where BinId='"+binid+"'");
            return "0";
        
        
        
        }

        [WebMethod]
        public static List<ListItem> fn_select_path()
        {

            string query = "Select routid,routeName from Mst_Route_planner";
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
        public static List<ListItem> get_route_(string ward)
        {
         
            string query = "Select routid,routeName from Mst_Route_planner where wardid='"+ward+"'";
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
        public static MAPS[] get_current_route(string s, string binid)
        {
            List<MAPS> lstMarkers = new List<MAPS>();
            DataSet ds = new DataSet();
            business ob = new business();
            DataTable dt = new DataTable();

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
           
            dt.Columns.Add("BinName");
            dt.Columns.Add("lat");
            dt.Columns.Add("lon");
            dt.Columns.Add("routeid");
    


            if (s == "1")
            {


                ds = ob.fn_get_current_bin(s, binid);



            }


            try
            {


                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)//binding bins 
                    {
                        DataRow dr = dt.NewRow();
                     

                        dr["BinName"] = ds.Tables[0].Rows[i]["BinName"].ToString();
                        dr["lat"] = ds.Tables[0].Rows[i]["Latitude"].ToString();
                        dr["lon"] = ds.Tables[0].Rows[i]["Longitude"].ToString();
                        dr["routeid"] = ds.Tables[0].Rows[i]["routeid"].ToString();

                        
                        dt.Rows.Add(dr);

                    }
                }
            }
            catch { }




            foreach (DataRow dtrow in dt.Rows)
            {

                MAPS objMAPS = new MAPS();
              
                objMAPS.lat = dtrow[1].ToString();
                objMAPS.lon = dtrow[2].ToString();
                objMAPS.BinName = dtrow[0].ToString();
                objMAPS.routeid = dtrow[3].ToString();

                lstMarkers.Add(objMAPS);


            }




            return lstMarkers.ToArray();
        
        
        }

        [WebMethod]
        public static MAPS[] get_routes(string m, string route)
        {

            List<MAPS> lstMarkers = new List<MAPS>();
          
            DataSet ds = new DataSet();
           
            business ob = new business();
      
    
            connections con = new connections();
      
        

            DataTable dt = new DataTable();
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            DataTable dt12 = new DataTable();


            dt.Columns.Add("BinName");
            dt.Columns.Add("lat");
            dt.Columns.Add("lon");
            dt.Columns.Add("BinId");
            dt.Columns.Add("Bin_Type");
            dt.Columns.Add("Priority");


            if (m == "1")
            {


                ds = ob.fn_get_routes_for_bin(m, route);



            }

      
            try
            {


                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)//binding bins 
                    {
                        DataRow dr = dt.NewRow();
                        
                        dr["BinId"] = ds.Tables[0].Rows[i]["BinId"].ToString();
                        dr["BinName"] = ds.Tables[0].Rows[i]["BinName"].ToString();
                        dr["lat"] = ds.Tables[0].Rows[i]["Latitude"].ToString();
                        dr["lon"] = ds.Tables[0].Rows[i]["Longitude"].ToString();
                        dr["Bin_Type"] = ds.Tables[0].Rows[i]["Type"].ToString();
                        dr["Priority"] = ds.Tables[0].Rows[i]["Priority"].ToString();


                        dt.Rows.Add(dr);

                    }
                }
            }
            catch { }
           


           
            foreach (DataRow dtrow in dt.Rows)
            {
      
                MAPS objMAPS = new MAPS();
                objMAPS.BinId = dtrow[3].ToString();
                objMAPS.lat = dtrow[1].ToString();
                objMAPS.lon = dtrow[2].ToString();
                objMAPS.BinName = dtrow[0].ToString();
                objMAPS.Type = dtrow[4].ToString();
                objMAPS.SPriority = dtrow[5].ToString();

                lstMarkers.Add(objMAPS);


            }




            return lstMarkers.ToArray();

          

        }


        protected void ddl_route_select_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }


        [WebMethod]
        public static string fn_insert_routes(string ward, string route)
        {
            connections con = new connections();
            DataSet ds = new DataSet();
            try
            {
                ds = con.FN_ExecuteQuerySingle("INERT_ROUTE_proc" + "'" + ward + "','" + route + "'");

                string msg = ds.Tables[0].Rows[0]["msg"].ToString();

                return msg;
            }
            catch {
                return "0";
            }
        }

        public void BindDummyItem()
        {
            DataTable dtGetData = new DataTable();
            dtGetData.Columns.Add("routid");
            dtGetData.Columns.Add("routeName");
            //dtGetData.Columns.Add("wardid");
            dtGetData.Columns.Add("ward_name");
            //dtGetData.Columns.Add("Zoneid");
            dtGetData.Columns.Add("Zone_Name");
            dtGetData.Rows.Add();


        }
        [WebMethod]
        public static string fn_del_bin(string routeid)
        {
            DataSet ds = new DataSet();
            connections con= new connections();
            ds = con.FN_ExecuteQuerySingle("delete from Mst_Route_Planner where routid='"+routeid+"'");
            return "0";
        
        }
        [WebMethod]
        public static DetailsClass[] fn_get_grid_data() //GetData function
        {
            List<DetailsClass> Detail = new List<DetailsClass>();

            DateTime today = DateTime.Today;
            //string SelectString = "select distinct Mst_Route_planner.routid,Mst_Route_planner.routeName,Mst_Route_planner.wardid,ward_master.ward_name,Mst_Bin.Zoneid,ZoneName  from Mst_Route_planner inner join ward_master on ward_master.ward_id=Mst_Route_planner.wardid inner join Mst_Bin on Mst_Bin.wardid=Mst_Route_planner.wardid";
            string SelectString = "select Mst_Route_Planner.routid,routeName,ward_master.ward_name,zone_master.Zone_Name from Mst_Route_planner inner join ward_master on ward_master.ward_id=Mst_Route_planner.wardid inner join zone_master on ward_master.Zone_id=zone_master.Zone_id";
            SqlConnection cn = new SqlConnection("Data Source=192.168.0.171;Initial Catalog=ACME_IOT;Persist Security Info=True;User ID=sa;Password=asdzxc@987");
            SqlCommand cmd = new SqlCommand(SelectString, cn);
            cn.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtGetData = new DataTable();

            da.Fill(dtGetData);


            foreach (DataRow dtRow in dtGetData.Rows)
            {
                DetailsClass DataObj = new DetailsClass();
                DataObj.routid = dtRow["routid"].ToString();
                DataObj.routeName = dtRow["routeName"].ToString();
                //DataObj.wardid = dtRow["wardid"].ToString();
                DataObj.ward_name = dtRow["ward_name"].ToString();
                //DataObj.Zoneid = dtRow["Zoneid"].ToString();
                DataObj.ZoneName = dtRow["Zone_Name"].ToString();
                Detail.Add(DataObj);
            }

            return Detail.ToArray();
        }
        public class DetailsClass //Class for binding data
        {
            public string routid { get; set; }
            public string routeName { get; set; }
            //public string wardid { get; set; }
            public string ward_name { get; set; }
            //public string Zoneid { get; set; }
           public string ZoneName { get; set; }



        }


    }
}