using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MAPConnection;

namespace MAPBusiness
{
    public class business
    {
        DataSet ds = new DataSet();
        map_procedures ob = new map_procedures();

        //fn_pre_defined_path
        public DataSet fn_pre_defined_path(object s, object zone, object ward, object type, object rid)
        {
            string str = "'" + s + "','" + zone + "','" + ward + "','" + type + "','" + rid + "'";
            ds = ob.fn_pre_defined_path(str);
            return ds;
        
        
        }



        //fn_get_grid_

        public DataSet fn_get_grid_()
        {
            string str = "";
            ds = ob.fn_get_grid_(str);
            return ds;

        
        
        
        }


        //fn_get_bin_routewise
        public DataSet fn_get_bin_routewise(object s, object zone, object ward, object type, object rid)
        {
            string str = "'" + s + "','" + zone + "','" + ward + "','" + type + "','" + rid + "'";
            ds = ob.fn_get_bin_routewise(str);
            return ds;
              
        }




        //update default route
        public DataSet fn_update_route_for_bin(object bid, object lat, object lon, object routeid)
        {
            string str = "'" + bid + "','" + lat + "','" + lon + "','" + routeid + "'";
            ds = ob.fn_update_route_for_bin(str);
            return ds;
        
        
        }




        //get current BINS 

        public DataSet fn_get_current_bin(object m, object bid)
        { 
        
            string str="'"+m+"','"+bid+"'";
            ds = ob.fn_get_current_bin(str);
            return ds;
        
        
        }



        //getting routes for bins

        public DataSet fn_get_routes_for_bin(object m, object routeid)
        {
            string str = "'" + m + "','" + routeid + "'";
            ds = ob.fn_get_routes_for_bin(str);
            return ds;
        
        
        
        }




        //binding routes to Add_bin.aspx

        public DataSet fn_bin_route(object ward_id)
        {
            string str = "'" + ward_id + "'";
            ds = ob.fn_bin_route(str);
            return ds;
        
        
        
        }








        //inserting bins in plan schedule table 

        public DataSet FN_insert_bins(object b_id, object BinNAme, object lat, object lon, object Prior, object type, object order, object today)
        {
            string str = "'" + b_id + "','" + BinNAme + "','" + lat + "','" + lon + "','" + Prior + "','" + type + "','" + order + "','" + today + "'";
            ds = ob.FN_insert_bins(str);
            return ds;


        }




        //editing planned schedule
        public DataSet fn_update_route_plan(object b_id, object BinNAme, object lat, object lon, object Prior, object type, object order, object today)
        {
            string str = "'" + b_id + "','" + BinNAme + "','" + lat + "','" + lon + "','" + Prior + "','" + type + "','" + order + "','" + today + "'";
            ds = ob.fn_update_route_plan(str);
            return ds;
        }



        //scheduling route 
        public DataSet fn_plan_schedule(object b_id, object BinNAme, object lat, object lon, object Prior, object type, object order, object today)
        {
            string str = "'" + b_id + "','" + BinNAme + "','" + lat + "','" + lon + "','" + Prior + "','" + type + "','" + order + "','" + today + "'";
            ds = ob.fn_plan_schedule(str);
            return ds;

        
        
        }




        //getting bins zone & ward wise in LIst BOX

        public DataSet getBinPriorityList_ward_zone(object zn_id, object wrd_id)
        {
            string str = "'" + zn_id + "','" + wrd_id + "'";
            ds = ob.getBinPriorityList_ward_zone(str);
            return ds;
        
        
        
        }


        //route planning and getting bins only zone wise 

        public DataSet getBinPriorityList(object zn_id)
        {
            string str = "'" + zn_id + "'";
            ds = ob.getBinPriorityList(str);
            return ds;
        
        
        }


        //bin route planning 
        public DataSet fn_top_3_bins(object val)
        {
            string str = "'" + val + "'";
            ds = ob.fn_top_3_bins(str);
            return ds;
        
        }

        public DataSet fn_feeders_bind(string s, string zone, string ward)//string s,string zone, string ward
        {
            string str = "'" + s + "','" + zone + "','" + ward + "'";//'"+s+"','"+zone+"','"+ward+"'
            ds = ob.fn_feeders_bind(str);
            return ds;

        }


        public DataSet fn_map_bind(object s, object zone, object ward, object type)
        {
            string str = "'" + s + "','" + zone + "','" + ward + "','" + type + "'";
            ds = ob.fn_map_bind(str);
            return ds;
        }


        //Update Processing Units
        //Created  By Gajendra Singh 17/07/2017

        public DataSet fn_update_Processing_Units(object id, object zoneid, object wardid, object areaname, object lat, object lon, object PUname, object zonename, object wardname)
        {
            string str = "'" + id + "','" + zoneid + "','" + wardid + "','" + areaname + "','" + lat + "','" + lon + "','" + PUname + "','" + zonename + "','" + wardname + "'";
            ds = ob.fn_update_Processing_Units(str);
            return ds;
        }

        //edit PU Datils
        public DataSet fn_edit_PU_Details(string b_id)
        {
            string str = "'" + b_id + "'";
            ds = ob.fn_edit_PU_Details(str);
            return ds;


        }


        //Delete Pu Details
        //Created  By Gajendra Singh 17/07/2017
        public DataSet fn_Delete_PU_Details(object id)
        {
            string str = "'" + id + "'";
            ds = ob.fn_Delete_PU_Details(str);
            return ds;
        }




        //Select PU Zone Wise Created  By Gajendra Singh 17/07/2017

        public DataSet Fn_select_PU_ZoneWise(string zoneid)
        {
            string str = "'" + zoneid + "'";
            ds = ob.Fn_select_PU_ZoneWise(str);
            return ds;

        }


        //select All PU Created By Gajendra Singh 17/07/2017

        public DataSet Fn_selectAll_pu()
        {
            string str = "";
            ds = ob.Fn_selectAll_pu(str);
            return ds;

        }


        //Add new Processing Units
        //Created By Gajendra Singh 17/07/2017

        public DataSet Fn_Insert_new_PU(object zone, object zoneid, object ward, object wardid, object Areaname, object lat, object lon, object PUname)
        {
            string strsql = "'" + zone + "','" + zoneid + "','" + ward + "','" + wardid + "','" + Areaname + "','" + lat + "','" + lon + "','" + PUname + "'";
            ds = ob.Fn_Insert_new_PU(strsql);
            return ds;
        }


        //Delete Feeders Details
        //Created  By Gajendra Singh 17/07/2017
        public DataSet fn_Delete_Feeders_Details(object id)
        {
            string str = "'" + id + "'";
            ds = ob.fn_Delete_Feeders_Details(str);
            return ds;
        }


        //Update Feeders
        //Created  By Gajendra Singh 17/07/2017

        public DataSet fn_update_Feeders(object id, object zoneid, object wardid, object areaname, object lat, object lon, object feedername, object zonename, object wardname)
        {
            string str = "'" + id + "','" + zoneid + "','" + wardid + "','" + areaname + "','" + lat + "','" + lon + "','" + feedername + "','" + zonename + "','" + wardname + "'";
            ds = ob.fn_update_Feeders(str);
            return ds;
        }




        //Select feeders Zone Wise Created  By Gajendra Singh 17/07/2017

        public DataSet Fn_select_FeedersZoneWise(string zoneid)
        {
            string str = "'" + zoneid + "'";
            ds = ob.Fn_select_FeedersZoneWise(str);
            return ds;

        }


        //edit Feeders Datils
        public DataSet fn_edit_Feeders_Details(string b_id)
        {
            string str = "'" + b_id + "'";
            ds = ob.fn_edit_Feeders_Details(str);
            return ds;


        }



        //Select Bins Zone Wise Created  By Gajendra Singh 13/07/2017

        public DataSet Fn_select_binsZoneWise(string zoneid)
        {
            string str = "'" + zoneid + "'";
            ds = ob.Fn_select_binsZoneWise(str);
            return ds;

        }


        //Add new Feedars Created By Gajendra Singh 13/07/2017

        public DataSet Fn_selectAll_feeders()
        {
            string str = "";
            ds = ob.Fn_selectAll_feeders(str);
            return ds;

        }

        //Add new Feedars Created By Gajendra Singh 13/07/2017
        public DataSet Fn_Insert_new_Feeders(object zone,object zoneid,object ward,object wardid,object Areaname,object lat,object lon,object feedername)
        {
            string strsql = "'" + zone + "','" + zoneid + "','" + ward + "','" + wardid + "','" + Areaname + "','" + lat + "','" + lon + "','" + feedername + "'";
            ds = ob.Fn_Insert_new_Feeders(strsql);
            return ds;
        }

        //editing bins
        public DataSet fn_edit_bins(string b_id)
        {
            string str = "'" + b_id + "'";
            ds = ob.fn_edit_bins(str);
            return ds;
        
        
        }




        //deleting bins
        public DataSet fn_del(string sr_id)
        {
            string str = "'" + sr_id + "'";
            ds = ob.fn_del(str);
            return ds;
        
        
        
        }





        //binding bin information to grid view 
        public DataSet fn_bind_bin()
        {
            string str = "";
            ds = ob.fn_bind_bin(str);
            return ds;
        
        }




        //getting processing units ward wise

        public DataSet fn_get_ward_pu(object wrd)
        {
            string str = "'" + wrd + "'";
            ds = ob.fn_get_ward_pu(str);
            return ds;
        
        
        }

        //getting feeders ward wise
        public DataSet fn_ward_ws_get_fe(object wrd)
        {
            string str = "'" + wrd + "'";
            ds = ob.fn_ward_ws_get_fe(str);
            return ds;

        
        
        }


        //getting Processing Units Zone Wise

        public DataSet fn_get_PU_zn_ws(object zn)
        {
            string str = "'" + zn + "'";
            ds = ob.fn_get_PU_zn_ws(str);
            return ds;
        
        
        
        }








        //getting feeders zone wise

        public DataSet fn_get_fe_zn_ws(object zone)
        {
            string str = "'" + zone + "'";
            ds = ob.fn_get_fe_zn_ws(str);
            return ds;
        
        
        
        }
        //Delete Bin Details
        public DataSet fn_Delete_bin_Details(object binid)
        {
            string str = "'" + binid + "'";
            ds = ob.fn_Delete_bin_Details(str);
            return ds;
        }

        //Update Bins

        public DataSet fn_update_bin(object binid, object zone, object ward, object areaname, object lat, object lon, object binname, object serialid,object zonename,object wardname)
        {
            string str = "'" + binid + "','" + zone + "','" + ward + "','" + areaname + "','" + lat + "','" + lon + "','" + binname + "','" + serialid + "','" + zonename + "','" + wardname + "'";
            ds = ob.fn_update_bin(str);
            return ds;
        }




        //inserting new bin details
        public DataSet fn_insert_new_bin(object area_nm, object lat, object lon, object b_nm, object serialid, object dz_val, object dw_val,object wardname,object zonename,object route_id)
        {
            string str = "'" + area_nm + "','" + lat + "','" + lon + "','" + b_nm + "','" + serialid + "','" + dz_val + "','" + dw_val + "','" + wardname + "','" + zonename + "','" + route_id + "'";
            ds = ob.fn_insert_new_bin(str);
            return ds;


        }





        //binding ward
        public DataSet fn_bind_ward(string val)
        {

            string srt = "'" + val + "'";
            ds = ob.fn_bind_ward(srt);
            return ds;
        
        }


        //binding ddl_zone
        public DataSet fn_ddl_bind()
        {
            string str = "";
            ds = ob.fn_ddl_bind(str);
            return ds;
        
        
        }




        //inserting BINS 
        public DataSet fn_insert_bins(string bid,string b_nm,string areaid,string areanm,string blat,string blon,string z_id,string z_nm,string w_id,string w_nm)
        {
            string str = "'" + bid + "','" + b_nm + "','" + areaid + "','" + areanm + "','" + blat + "','" + blon + "','" + z_id + "','" + z_nm + "','" + w_id + "','" + w_nm + "'";
            ds = ob.fn_insert_bins(str);
            return ds;
        }



        //removing priority

        public DataSet fn_remove_prior(string rem)
        {
            string str = "'" + rem + "'";
            ds = ob.fn_remove_prior(str);
            return ds;
        
        }

        
        
        //inserting priority in mst_location

        public DataSet fn_set_priority(string pr, string lat)
        {
            string str = "'" + pr + "','" + lat + "'";
            ds = ob.fn_set_priority(str);
            return ds;
        
        
        }



        //getting bins ward wise
        public DataSet fn_get_ward_wise(string ward)
        {

            string str = "'" + ward + "'";
            ds = ob.fn_get_ward_wise(str);
            return ds;
        
        }
        
        
        
        //getting zone name 
        public DataSet fn_get_z_name()
        {
            string str = "";
            ds = ob.fn_get_z_name(str);
            return ds;

        }

        //binding Z_latLon
        public DataSet getZ_latlon(string zlatlon)
        {
            string str = "'" + zlatlon + "'";
            ds = ob.getZ_latlon(str);
            return ds;
        }

        //get zone lat lon
        public DataSet getzonelatlon(string latlon_z)
        {
            string str = "'" + latlon_z + "'";
            ds = ob.getzonelatlon(str);
            return ds;
        }

        //getting Ward Wise
        public DataSet fn_getWardWise()
        {
            string str = " ";
           ds = ob.fn_getWardWise(str);
            return ds;
        }
        //Geting Zone Wise
        public DataSet fn_get_zone_wise(string zone)
        {
            string str = "'" + zone + "'";
            ds = ob.fn_get_zone_wise(str);
            return ds;
        }
        
        //fn_bind_bin_grid


        public DataSet fn_bind_bin_grid()
        {
            string str = "";
            ds = ob.fn_bind_bin_grid(str);
            return ds;
        
        }
        //getting type 
        public DataSet fn_select_type(string value)
        {
            string str = "'" + value + "'";
            ds = ob.fn_select_type(str);
            return ds;
        }

        //geting data from processing units table
        public DataSet fn_get_PU(string s, string zone, string ward)
        {
            string str = "'" + s + "','" + zone + "','" + ward + "'";
            ds = ob.fn_get_PU(str);
            return ds;
        }
        public DataSet fn_check()
        {
            string str = "";
            ds = ob.fn_check(str);
            return ds;
        
        }

        public DataSet fn_filter_marker(string bin_type)
        {
            string str="'"+bin_type+"'";
            ds = ob.fn_filter_marker(str);
            return ds;
        }
        //fn_Mst_BinDevice
        public DataSet fn_Mst_BinDevice(string BinId)
        {
            string str = "'" + BinId + "'";
            ds = ob.fn_Mst_BinDevice(str);
            return ds;
        }
        //fn_Mst_bin
      

     

        public DataSet fn_sensor_input(string Areaid)
        {
            string str = "'" + Areaid + "'";
            ds = ob.fn_Mst_bin(str);
            return ds;
        }

        public DataSet fn_get_map_binID(string areaid)
        {
            string str = "'" + areaid + "'";
            ds = ob.fn_get_map_binID(str);
            return ds;
        }
        public DataSet fn_get_location(string areaid)
        {
            string str = "'" + areaid + "'";
            ds = ob.fn_get_location(str);
            return ds;

        
        }

         public DataSet fn_bind_device(string BinID)
        {
            string str = "'" + BinID + "'";
            ds = ob.fn_bind_device(str);
            return ds;
        }

        public DataSet fn_bin_bind(string BinID)
        {
            string str = "'" + BinID + "'";
            ds = ob.fn_bin_bind(str);
            return ds;
        }
        public DataSet fn_feeders_bind()
        {
            string str = " ";
            ds = ob.fn_feeders_bind(str);
            return ds;
        
        }
           public DataSet fn_map_bind()
            {
            string str=" ";
            ds=ob.fn_map_bind(str);
            return ds;
            }
           public DataSet fn_map_service()
           {
               string str = " ";
               ds = ob.fn_map_service(str);
               return ds;
           }
           public DataSet fn_demo(string a)
           {
               string str = "'" + a + "'";
               ds = ob.fn_demo(str);
               return ds;
           }
           public DataSet execute_q(string binid)
           {
               string str = "'" + binid + "'";
               ds = ob.execute_q(str);
               return ds;
           }

           public DataSet fn_Mst_bin(string BinId)
           {
               string str = "'" + BinId + "'";
               ds = ob.fn_Mst_bin(str);
               return ds;
           }
        //fn_sub_string
       
           public DataSet fn_sub_string()
           {
               string str = " ";
               ds = ob.fn_sub_string(str);
               return ds;
           }


           public DataSet fn_sub_string_2()
           {
               string str = " ";
               ds = ob.fn_sub_string_2(str);
               return ds;
           }

           public DataSet fn_bind_dsmstbintype(string BinId)
           {
               string str = "'"+BinId+"'";
               ds = ob.fn_bind_dsmstbintype(str);
               return ds;
           }
    }
 
}
