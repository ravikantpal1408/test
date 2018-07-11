using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MAPConnection
{
    public class map_procedures
    {
        DataSet ds = new DataSet();
        connections con = new connections();

        //fn_pre_defined_path
        public DataSet fn_pre_defined_path(string str)
        {
            string st = "fn_get_bin_pre_routewise_proc" + str;
            ds = con.conn(st);
            return ds;

        }

        
        
        
        
        //fn_get_grid_
        public DataSet fn_get_grid_(string str)
        {
            string st = "fn_get_grid_proc_" + str;
            ds = con.conn(st);
            return ds;
        
        
        }


        //fn_get_bin_routewise

        public DataSet fn_get_bin_routewise(string str)
        {
            string st = "fn_get_bin_routewise_proc" + str;
            ds = con.conn(st);
            return ds;
     
        
        }



        //update default route

        public DataSet fn_update_route_for_bin(string str)
        {
            string st = "fn_update_route_for_bin_proc" + str;
            ds = con.conn(st);
            return ds;
        
        
        
        }


        //get current route 

        public DataSet fn_get_current_bin(string cu_bin)
        {
            string st = "fn_get_current_bin_proc" + cu_bin;
            ds = con.conn(st);
            return ds;
        
        
        }


        //getting bins routes
        public DataSet fn_get_routes_for_bin(string routes)
        {
            string st = "fn_get_routes_for_bin_proc" + routes;
            ds=con.conn(st);
             return ds;
        
        
        
        
        }







        // binding routes to add_bins.aspx
        public DataSet fn_bin_route(string ward_id)
        {
            string st="fn_bin_route_proc"+ward_id;
            ds=con.conn(st);
            return ds;

        
        
        }





        //inserting bins in plan schedule table
        public DataSet FN_insert_bins(string str)
        {
            string st = "fn_ins_bins_Mst_schedule_collecttion" + str;
            ds = con.conn(st);
            return ds;


        }


        //editing planned schedule

        public DataSet fn_update_route_plan(string str)
        {
            string st = "fn_update_route_plan_proc" + str;
            ds = con.conn(st);
            return ds;
        
        }



        //scheduled route 
        public DataSet fn_plan_schedule(string str)
        {
            string st = "fn_plan_schedule_proc" + str;
            ds = con.conn(st);
            return ds;
        
        }




        //route planning and zone and ward wise ddl
        public DataSet getBinPriorityList_ward_zone(string str)
        {
            string st = "getBinPriorityList_ward_zone_proc" + str;
            ds = con.conn(st);
            return ds;
        
        
        }



        //route planning and getting bins zone wise 
        public DataSet getBinPriorityList(string str)
        {
            string st = "getBinPriorityList_proc" + str;
            ds = con.conn(st);
            return ds;
        
        
        }


        //getting route plan 
        public DataSet fn_top_3_bins(string str)
        {
            string st = "fn_bin_route_plan" + str;
            ds = con.conn(st);
            return ds;
        
        }


        //update PU Details
        //created By Gajendra Singh
        //Date 17/07/2017

        public DataSet fn_update_Processing_Units(string str)
        {

            string st = "Update_PU_Details" + str;
            ds = con.conn(st);
            return ds;
        }


        //edit PU Details 

        public DataSet fn_edit_PU_Details(string str)
        {
            string st = "Edit_Pudetails" + str;
            ds = con.conn(st);
            return ds;

        }

        //Delete Processing Units Details
        //Created By Gajendra Singh
        //Date 17/07/2017


        public DataSet fn_Delete_PU_Details(string str)
        {
            string st = "Delete_Processing_Units" + str;
            ds = con.conn(st);
            return ds;
        }




        //Select PU Zone Wise Created By Gajendra Singh 17/07/2017
        public DataSet Fn_select_PU_ZoneWise(string str)
        {
            string strsql = "select_PU_Zone_wise" + str;
            ds = con.FN_ExecuteQuery(strsql);
            return ds;
        }



        //Select All processing Units Created By Gajendra Singh 13/07/2017
        public DataSet Fn_selectAll_pu(string str)
        {
            string strsql = "select_All_PU" + str;
            ds = con.FN_ExecuteQuery(strsql);
            return ds;
        }


        //Add new Feedars Created By Gajendra Singh 17/07/2017
        public DataSet Fn_Insert_new_PU(string str)
        {
            string strsql = "Add_New_Processing_Units" + str;
            ds = con.FN_ExecuteQuery(strsql);
            return ds;
        }


        //Delete Feeders Details
        //Created By Gajendra Singh
        //Date 17/07/2017


        public DataSet fn_Delete_Feeders_Details(string str)
        {
            string st = "Delete_Feeders" + str;
            ds = con.conn(st);
            return ds;
        }



        //update Feeders Details

        public DataSet fn_update_Feeders(string str)
        {

            string st = "Update_Feeders_Details" + str;
            ds = con.conn(st);
            return ds;
        }



        //Select feeders Zone Wise Created By Gajendra Singh 17/07/2017
        public DataSet Fn_select_FeedersZoneWise(string str)
        {
            string strsql = "select_Allfeeders_Zone_wise" + str;
            ds = con.FN_ExecuteQuery(strsql);
            return ds;
        }






        //edit Feeders Details 

        public DataSet fn_edit_Feeders_Details(string str)
        {
            string st = "Edit_Feeders_Details" + str;
            ds = con.conn(st);
            return ds;

        }




        //Select Bins Zone Wise Created By Gajendra Singh 14/07/2017
        public DataSet Fn_select_binsZoneWise(string str)
        {
            string strsql = "select_Allbins_Zone_wise" + str;
            ds = con.FN_ExecuteQuery(strsql);
            return ds;
        }


        //select Feedars Created By Gajendra Singh 13/07/2017
        public DataSet Fn_selectAll_feeders(string str)
        {
            string strsql = "select_feeders" + str;
            ds = con.FN_ExecuteQuery(strsql);
            return ds;
        }


        //Add new Feedars Created By Gajendra Singh 13/07/2017
        public DataSet Fn_Insert_new_Feeders(string str)
        {
            string strsql = "Add_New_Feeders" + str;
            ds = con.FN_ExecuteQuery(strsql);
            return ds;
        }

        //editing bins 

        public DataSet fn_edit_bins(string str)
        {
            string st = "edit_bin_proc" + str;
            ds = con.conn(st);
            return ds;
        
        }




        //deleting bins 
        public DataSet fn_del(string str)
        {

            string st = "fn_del_proc " + str;
            ds = con.conn(st);
            return ds;
        }



        //binding bin information to grid view 

        public DataSet fn_bind_bin(string str)
        {
            string st = "fn_bind_bin_proc " + str;
            ds = con.conn(st);
            return ds;
        
        }



        //getting processing units ward wise
        public DataSet fn_get_ward_pu(string wrd)
        {
            string st = "fn_get_ward_pu_proc " + wrd;
            ds = con.conn(st);
            return ds;
        
        
        }



        //getting feeders ward wise
        public DataSet fn_ward_ws_get_fe(string wrd_fe)
        {
            string st = "fn_ward_ws_get_fe_proc " + wrd_fe;
            ds = con.conn(st);
            return ds;
        
        
        }



        //getting processing Units zone wise 
        public DataSet fn_get_PU_zn_ws(string zn)
        {

            string st = "fn_get_PU_zn_ws_proc " + zn;
            ds = con.conn(st);
            return ds;
        
        }





        //getting feeders zone wise 


        public DataSet fn_get_fe_zn_ws(string zone)
        {
            string st = "fn_get_fe_zn_ws_proc" + zone;
            ds = con.conn(st);
            return ds;
        
        }

        //Delete Bin Details
        public DataSet fn_Delete_bin_Details(string str)
        {
            string st = "Delete_Bines" + str;
            ds = con.conn(st);
            return ds;
        }



        //update Bin Details

        public DataSet fn_update_bin(string str)
        {

            string st = "updatebinsdetails" + str;
            ds = con.conn(st);
            return ds;
        }



        //inserting new bin details 
        public DataSet fn_insert_new_bin(string str)
        {
            string st = "fn_insert_new_bin_proc" + str;
            ds = con.conn(st);
            return ds;


        }


        //binding ward
        public DataSet fn_bind_ward(string str)
        {
            string st = "fn_bind_ward_proc " + str;
            ds = con.conn(st);
            return ds;
        
        
        
        }





        //binding ddl_zone

        public DataSet fn_ddl_bind(string str)
        {

            string st = "fn_ddl_bind_proc " + str;
            ds = con.conn(st);
            return ds;
        
        }




        //inserting bins 
        public DataSet fn_insert_bins(string b_info)
        {
            string st = "fn_insert_bins_proc111 " + b_info;
            ds = con.conn(st);
            return ds;
        
        }



        //removing priority
        public DataSet fn_remove_prior(string rem)
        {
            string st = "fn_remove_prior_proc " + rem;
            ds = con.conn(st);
            return ds;
        
        
        }
        //procedure to set priority
        public DataSet fn_set_priority(string prior)
        {
            string st = "fn_set_priority_proc " + prior;
            ds = con.conn(st);
            return ds;
        
        
        }


        //getting bins ward wise 

        public DataSet fn_get_ward_wise(string ward)
        {
            string st = "fn_get_ward_wise_proc " + ward;
            ds = con.conn(st);
            return ds;
        
        
        }



        //get zone name
        public DataSet fn_get_z_name(string str)
        {
            string st = "get_zone_name_proc " + str;
            ds = con.conn(st);
            return ds;
        
        
        }

        //bind zone lat lon

        public DataSet getZ_latlon(string zlatlon)
        {
            string st = "getZ_latlon_proc " + zlatlon;
            ds = con.conn(st);
            return ds;

        
        
        }

        //get lat lon zone

        public DataSet getzonelatlon(string latlon_z)
        {
            string st = "getzonelatlon_proc " + latlon_z;
            ds = con.conn(st);
            return ds;
        
        
        }


        //getting Data Ward Wise 
        public DataSet fn_getWardWise(string ward)
        {

            string st = "fn_getWardWise_proc " + ward;
            ds = con.conn(st);
            return ds;
        }



        //getting Data Zone Wise
        public DataSet fn_get_zone_wise(string zone)
        {
            string st = "zone_w_bin " + zone;
            ds = con.conn(st);
            return ds;

        
        }



        //binding grid on Fomr_bins.aspx
        public DataSet fn_bind_bin_grid(string str)
        {
            string st = "fn_bind_bin_grid_proc " + str;
            ds = con.conn(st);
            return ds;
        
        }

        public DataSet fn_select_type(string str)
        {
            string st = "fn_select_type_proc " + str;
            ds = con.conn(st);
            return ds;
        }


        //function to check the functionality of web SEr
        public DataSet fn_check(string str)
        {
            string st = "fn_check_proc " + str;
            ds = con.conn(st);
            return ds;
        }

        //creating procedure to get data from processing units
        public DataSet fn_get_PU(string str)
        {
            string st = "fn_get_PU_proc " + str;//table:Mst_Processing_Units
            ds = con.conn(st);
            return ds;
        }

        public DataSet fn_filter_marker(string str)
        {
            string st = "fn_filter_marker_proc " + str;
            ds = con.conn(st);
            return ds;
        
        
        }


        //fn_bind_device



        //fn_Mst_BinDevice

        public DataSet fn_Mst_BinDevice(string str)
        {
            string st = "fn_Mst_BinDevice_proc " + str;
            ds = con.conn(st);
            return ds;

        }

        //fn_Mst_bin

        public DataSet fn_Mst_bin(string str)
        {
            string st = "PROC_SELECT_SENSORDATA " + str;
            ds = con.conn(st);
            return ds;

        }
        public DataSet fn_get_map_binID(string str)
        {
            string st = "fn_get_map_binID_proc " + str;
            ds = con.conn(st);
            return ds;
        }
        public DataSet fn_get_location(string str)
        {
            string st = "fn_get_location_proc " + str;
            ds = con.conn(st);
            return ds;
        }
        //fn_sub_string

        public DataSet fn_sub_string(string str)
        {
            string st = "fn_sub_string_proc " + str;
            ds = con.conn(st);
            return ds;

        }
     
        //fn_sensor_input



        public DataSet fn_sensor_input(string str)
        {
            string st = "fn_sensor_input_proc " + str;
            ds = con.conn(st);
            return ds;

        }
        public DataSet fn_bind_device(string str)
        {
            string st = "fn_bind_device_proc " + str;
            ds = con.conn(st);
            return ds;

        }
        public DataSet fn_bin_bind(string str)
        {
            string st = "get_bin_proc " + str;
            ds = con.conn(st);
                return ds;
        
        }
        public DataSet fn_map_bind(string str)//BIN BINDING ON MAP
        {
            string st="map_bind_proc "+str;
            ds = con.conn(st);
            return ds;

        }
        public DataSet fn_map_service(string str)
        {
            string st = "map_service_proc " + str;
            ds = con.conn(st);
            return ds;
        
        }
        public DataSet fn_feeders_bind(string str)
        {
            string st = "fn_feeders_proc " + str;
            ds=con.conn(st);
            return ds;
        }
        public DataSet fn_demo(string str)
        {
            string st = "fn_demo " + str;
            ds = con.conn(st);
            return ds;
        }
        public DataSet execute_q(string str)
        {
            string st = "fn_get_bin_proc " + str;
            ds = con.conn(st);
            return ds;
        }



        public DataSet fn_sub_string_2(string str)
        {
            //fn_sub_string_2
            string st = "fn_sub_string_2_proc " + str;
            ds = con.conn(st);
            return ds;
        }
        public DataSet fn_bind_dsmstbintype(string binid)
        {
            string st = "fn_fn_bind_dsmstbintype_proc" + binid;
            ds = con.conn(st);
            return ds;

        
        
        }
    }
}
