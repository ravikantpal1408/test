using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using MAPConnection;
using MAPBusiness;
using System.Text;

namespace WebApplication1
{
    /// <summary>
    /// Summary description for car
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class car : System.Web.Services.WebService
    {


        connections con = new connections();
        DataSet ds = new DataSet();
        business ob = new business();
        DateTime today = DateTime.Today;

        public string DataTableToJSONWithStringBuilder(DataTable table)
        {
            var JSONString = new StringBuilder();
            if (table.Rows.Count > 0)
            {
                JSONString.Append("[");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    JSONString.Append("{");
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        if (j < table.Columns.Count - 1)
                        {
                            JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\",");
                        }
                        else if (j == table.Columns.Count - 1)
                        {
                            JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\"");
                        }
                    }
                    if (i == table.Rows.Count - 1)
                    {
                        JSONString.Append("}");
                    }
                    else
                    {
                        JSONString.Append("},");
                    }
                }
                JSONString.Append("]");
            }
            return JSONString.ToString();
        }



        [WebMethod]
        public string zonewstable(string zoneid)
        {

            string returnvalue = "";
            ds = con.FN_ExecuteQuerySingle("FN_select_policy"+"'" + zoneid + "'");



            foreach (DataTable dt in ds.Tables)
            {

                returnvalue = returnvalue + DataTableToJSONWithStringBuilder(dt);

            }


            return returnvalue;
        
        }

        [WebMethod]
        public string makezonalpolicy(string zoneid,string devicename, string poll_int, string kai, string th_lvl)
        {
            ds = con.FN_ExecuteQuerySingle("update Mst_Bin set Devicename='" + devicename + "',poll_interval='" + poll_int + "',keepaliveinterval='" + kai + "',threshold='" + th_lvl + "' where Zoneid='" + zoneid + "'");
            //ds = con.FN_ExecuteQuerySingle("insert into mst_znws_bin_policy (devicename,poll_interval,keep_alive_int,threshold_level,zn_date,flag,zoneid) values('" + devicename + "','" + poll_int + "','" + kai + "','" + th_lvl + "',dbo.getlocaldate(),'N','" + zoneid + "')");
            return "0";
        
        
        
        }



        [WebMethod]
        public string bindddlzonewise__()
        {
            string returnvalue = "";
            ds = con.FN_ExecuteQuerySingle("select Zone_id,Zone_Name from zone_master");



            foreach (DataTable dt in ds.Tables)
            {

                returnvalue = returnvalue + DataTableToJSONWithStringBuilder(dt);

            }


            return returnvalue;
        
        
        }



        [WebMethod]
        public string globaltable()
        {


            string returnvalue = "";
            ds = con.FN_ExecuteQuerySingle("select *from mst_global_policy");



            foreach (DataTable dt in ds.Tables)
            {

                returnvalue = returnvalue + DataTableToJSONWithStringBuilder(dt);

            }


            return returnvalue;
        
        }

        [WebMethod]
        public string makewardpolicy(string zoneid, string wardid, string devicename, string poll_int, string kai, string th_lvl)
        {


            ds = con.FN_ExecuteQuerySingle("insert into mst_wr_ws_bin_policy (devicename,poll_interval,keep_alive_int,threshold_level,wr_date,flag,zoneid,wardid) values('" + devicename + "','" + poll_int + "','" + kai + "','" + th_lvl + "',dbo.getlocaldate(),'N','" + zoneid + "','" + wardid + "')");
            return "0";
        
        
        
        
        }

        [WebMethod]
        public string ward_del(string id)
        {


            ds = con.FN_ExecuteQuerySingle("delete from mst_wr_ws_bin_policy where id='" + id + "'");
            return "0";


        }

        //ward_del

        [WebMethod]
        public string updatewardpolicy(string zoneid,string wardid, string devicename, string poll_int, string kai, string th_lvl)
        {

            //ds = con.FN_ExecuteQuerySingle("update Mst_Bin set Devicename='" + devicename + "',poll_interval='" + poll_int + "',keepalive_int='" + kai + "',threshold_level='" + th_lvl + "',wr_date=dbo.getlocaldate() where id='" + id + "'");

            ds = con.FN_ExecuteQuerySingle("FN_update_wrd_zn_proc" + "'" + zoneid + "','" + wardid + "','" + devicename + "','" + poll_int + "','" + kai + "','" + th_lvl + "'");
            
            return "0";
            //updatewardpolicy
        }


        [WebMethod]
        public string wardwstable(string zoneid,string wardid)
        {


            string returnvalue = "";
            //ds = con.FN_ExecuteQuerySingle("select * from mst_wr_ws_bin_policy  where zoneid='" + zoneid + "' and wardid='" + wardid + "'");
            ds = con.FN_ExecuteQuerySingle("FN_getpolicy_zn_wrd_proc" + "'" + zoneid + "','" + wardid + "'");


            foreach (DataTable dt in ds.Tables)
            {

                returnvalue = returnvalue + DataTableToJSONWithStringBuilder(dt);

            }


            return returnvalue;

        }
        //wardwstable


        [WebMethod]
        public string getwards(string zoneid)
        {


            string returnvalue = "";
            ds = con.FN_ExecuteQuerySingle("select ward_id,ward_name from ward_master  where Zone_id='" + zoneid + "'");



            foreach (DataTable dt in ds.Tables)
            {

                returnvalue = returnvalue + DataTableToJSONWithStringBuilder(dt);

            }


            return returnvalue;
        
        }

        [WebMethod]
        public string zonal_del(string id)
        {


            ds = con.FN_ExecuteQuerySingle("delete from mst_znws_bin_policy where id='" + id + "'");
            return "0";


        }
        [WebMethod]
        public string update_in_policy(string binid, string device_nm, string poll, string keep, string thresh)
        {

            ds = con.FN_ExecuteQuerySingle("FN_update_in_policy_proc" + "'" + binid + "','" + device_nm + "','" + poll + "','" + keep + "','" + thresh + "'");
            return "0";

        
        }


        [WebMethod]
        public string global_del(string id)
        {


            ds = con.FN_ExecuteQuerySingle("delete from mst_global_policy where id='"+id+"'");
            return "0";
        
        
        }

        [WebMethod]
        public string getsensorhealth()
        {

            string returnvalue = "";

            ds = con.FN_ExecuteQuerySingle("FN_get_health_proc");




            foreach (DataTable dt in ds.Tables)
            {

                returnvalue = returnvalue + DataTableToJSONWithStringBuilder(dt);

            }


            return returnvalue;
        
        }


        [WebMethod]
        public string bindindividual()
        {
            string returnvalue = "";
            //ds = con.FN_ExecuteQuerySingle("select *from Mst_Bin where StatusB='A'");
            ds = con.FN_ExecuteQuerySingle("FN_Individual_policy");

            foreach (DataTable dt in ds.Tables)
            {

                returnvalue = returnvalue + DataTableToJSONWithStringBuilder(dt);

            }


            return returnvalue;
        
        
        
        }

        [WebMethod]
        public string updatezonalpolicy(string zid, string Devicename, string poll_interval, string keepaliveinterval, string threshold)
        {

            ds = con.FN_ExecuteQuerySingle("update Mst_Bin set Devicename='" + Devicename + "',poll_interval='" + poll_interval + "',keepaliveinterval='" + keepaliveinterval + "',threshold='" + threshold + "' where Zoneid='" + zid + "'");
            return "0";



        }


        [WebMethod]
        public string updateglobalpolicy(string id,string devicename, string poll_int, string kai, string th_lvl)
        {

            ds = con.FN_ExecuteQuerySingle("update mst_global_policy set Devicename='" + devicename + "',poll_interval='" + poll_int + "',keepaliveinterval='" + kai + "',threshold='" + th_lvl + "',gdate=dbo.getlocaldate()  where id='" + id + "'");
            return "0";
        
        
        
        }

        [WebMethod]
        public string makeglobalpolicy(string devicename, string poll_int, string kai, string th_lvl)
        {

            //ds = con.FN_ExecuteQuerySingle("insert into mst_global_policy (Devicename,poll_interval,keepaliveinterval,threshold,gdate) values('" + devicename + "','" + poll_int + "','" + kai + "','" + th_lvl + "',dbo.getlocaldate())");
            ds = con.FN_ExecuteQuerySingle("FN_make_global_proc" + "'" + devicename + "','" + poll_int + "','" + kai + "','" + th_lvl + "'");
            //DataSet udp = new DataSet();
            //udp = con.FN_ExecuteQuerySingle("FN_global_update_proc");

            return "0";
        
        
        
        
        }





        [WebMethod]

        public string addCar(string email, string cartype, string brand, string color, string carnum, string date)
        {
            ds=con.FN_ExecuteQuerySingle("insert into car_ADD_CAR (usermobile,cartype,carmodel,carcolor,carnumber,cardate) values('"+email+"','"+cartype+"','"+brand+"','"+color+"','"+carnum+"','"+date+"')");



            return "0";
        }

       















        public class MAPS
        {
            //public string BinName;
            public string lat;
            public string lon;
            public string type;
           
     
        }


        

        [WebMethod]
        public string remove_car(string lat, string lon)
        {


            DataSet rem = new DataSet();
            rem = con.FN_ExecuteQuerySingle("delete from Car_LAT_LON where lat='" + lat + "' and lon='" + lon + "'");

            return "1";




        }

     [WebMethod]

        public MAPS[] init_get_car()
        {
            List<MAPS> lstMarkers = new List<MAPS>();
            connections con = new connections();
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            DataTable dt = new DataTable();
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            dt.Columns.Add("lat");
            dt.Columns.Add("lon");
            dt.Columns.Add("type");


            


            ds1 = con.FN_ExecuteQuerySingle("select lat,lon from Car_LAT_LON");

            if (ds1.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["lat"] = ds1.Tables[0].Rows[i]["lat"].ToString();
                    dr["lon"] = ds1.Tables[0].Rows[i]["lon"].ToString();
                    dt.Rows.Add(dr);


                }




            }
            else {
                DataRow dr = dt.NewRow();
                dr["lat"] = "23.235846";
                dr["lon"] = "77.3980373";
                dr["type"] = "D";


                dt.Rows.Add(dr);
            
            
            }
             
             
             
            foreach (DataRow dtrow in dt.Rows)
            {
                MAPS objMAPS = new MAPS();

                objMAPS.lat = dtrow[0].ToString();
                objMAPS.lon = dtrow[1].ToString();
                objMAPS.type = dtrow[2].ToString();

                lstMarkers.Add(objMAPS);

            }
            return lstMarkers.ToArray();
        }


     
        [WebMethod]
        public  MAPS[] fn_get_car(string lat, string lon)
        {
            List<MAPS> lstMarkers = new List<MAPS>();
            connections con = new connections();
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            DataTable dt = new DataTable();
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            dt.Columns.Add("lat");
            dt.Columns.Add("lon");
         
            ds = con.FN_ExecuteQuerySingle("insert into Car_LAT_LON (lat,lon) values('"+lat+"','"+lon+"')");

                   
            ds1 = con.FN_ExecuteQuerySingle("select lat,lon from Car_LAT_LON");

            if (ds1.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["lat"] = ds1.Tables[0].Rows[i]["lat"].ToString();
                    dr["lon"] = ds1.Tables[0].Rows[i]["lon"].ToString();
                    dt.Rows.Add(dr);
                
                
                }
           
            
            
            
            }
                 foreach (DataRow dtrow in dt.Rows)
                {
                    MAPS objMAPS = new MAPS();
           
                    objMAPS.lat = dtrow[0].ToString();
                    objMAPS.lon = dtrow[1].ToString();
                 
                    lstMarkers.Add(objMAPS);

                }
                 return lstMarkers.ToArray();
            }






        
  
        }
}
