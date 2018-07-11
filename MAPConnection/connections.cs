using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;

namespace MAPConnection
{
    public class connections
    {
        //#region Fields
        //private static byte[] key = { };
        //private static byte[] IV = { 38, 55, 206, 48, 28, 64, 20, 16 };
        //private static string stringKey = "!5663a#KN";
        //#endregion
        //SqlConnection sqlCon = new SqlConnection();
        //SqlConnection sqlCon_Res = new SqlConnection();
        //SqlCommand sqlCmd;
        //SqlDataAdapter sqlAdapter;
        SqlConnection sqlCon = new SqlConnection();
        SqlConnection sqlCon_Res = new SqlConnection();
        SqlCommand sqlCmd;
        SqlDataAdapter sqlAdapter;
        DataSet ds;

       
        //connections obj = new connections();

  
        public DataSet conn(string proc)
        {
            DataSet ds = new DataSet();
         
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["DA_DBConnectionString"].ConnectionString;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("execute " + proc, con);
               // int i = cmd.ExecuteNonQuery();
                
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;
                adp.Fill(ds);
                con.Close();
                return ds;
            }
            catch (Exception ex)
            {
                con.Close();
                return ds;

            }
            finally {

                con.Close();
            }
           
        
         }
        void FN_OpenConnection()
        {
            if (sqlCon.State == ConnectionState.Open)
            {
                sqlCon.Close();
            }
            sqlCon.ConnectionString = System.Configuration.ConfigurationSettings.AppSettings.Get("DA_DBConnectionString");
            sqlCon.Open();
        }


        //Function Used to close connection
        void FN_CloseConnection()
        {
            if (sqlCon.State == ConnectionState.Open)
            {
                sqlCon.Close();
            }
        }

        //function used for select,insert , update,delete by Stored Procedure
        public DataSet FN_ExecuteQuery(string proc)
        {
            sqlCmd = new SqlCommand();
            sqlAdapter = new SqlDataAdapter();
            ds = new DataSet();
            try
            {
                FN_OpenConnection();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "execute " + proc;
                sqlAdapter.SelectCommand = sqlCmd;
                sqlAdapter.Fill(ds);
                FN_CloseConnection();
                return ds;
            }
            catch (Exception ex)
            {
                FN_CloseConnection();
                return ds;
            }
        }


        //function used for select,insert , update,delete by Single Queary
        public DataSet FN_ExecuteQuerySingle(string Queary)
        {
            sqlCmd = new SqlCommand();
            sqlAdapter = new SqlDataAdapter();
            ds = new DataSet();
            try
            {
                FN_OpenConnection();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = Queary;
                sqlAdapter.SelectCommand = sqlCmd;
                sqlAdapter.Fill(ds);
                FN_CloseConnection();
                return ds;
            }
            catch (Exception ex)
            {
                FN_CloseConnection();
                return ds;
            }
        }



        //function used to insert image in the Data Base
        public void FNInsert_Image(Byte[] image, string strStudentId)
        {
            sqlCmd = new SqlCommand();
            sqlAdapter = new SqlDataAdapter();
            ds = new DataSet();
            try
            {
                FN_OpenConnection();
                sqlCmd = new SqlCommand("procInsert_image", sqlCon);
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.Add("@Stu_Image", image);
                sqlCmd.Parameters.Add("@studentId", strStudentId);
                sqlCmd.ExecuteNonQuery();
                FN_CloseConnection();
            }
            catch (Exception ex)
            {
                FN_CloseConnection();
            }
        }

        //Function to insert Signature
        public void FNInsert_Image1(Byte[] image, string strStudentId)
        {
            sqlCmd = new SqlCommand();
            sqlAdapter = new SqlDataAdapter();
            ds = new DataSet();
            try
            {
                FN_OpenConnection();
                sqlCmd = new SqlCommand("procInsert_image1", sqlCon);
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.Add("@Signature", image);
                sqlCmd.Parameters.Add("@studentId", strStudentId);
                sqlCmd.ExecuteNonQuery();
                FN_CloseConnection();
            }
            catch (Exception ex)
            {
                FN_CloseConnection();
            }
        }



        // To Update Address of student by Barcode Format
        public void FNInsert_Image2(Byte[] image, string strBarcode)
        {
            sqlCmd = new SqlCommand();
            sqlAdapter = new SqlDataAdapter();
            ds = new DataSet();
            try
            {
                FN_OpenConnection();
                sqlCmd = new SqlCommand("procInsert_image2", sqlCon);
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.Add("@Address_Image", image);
                sqlCmd.Parameters.Add("@Bar_Code", strBarcode);
                sqlCmd.ExecuteNonQuery();
                FN_CloseConnection();
            }
            catch (Exception ex)
            {
                FN_CloseConnection();
            }
        }


        // To Update Signature of student by Bar_Code
        public void FNInsert_Image3_Signature(Byte[] image, string strBarcode)
        {
            sqlCmd = new SqlCommand();
            sqlAdapter = new SqlDataAdapter();
            ds = new DataSet();
            try
            {
                FN_OpenConnection();
                sqlCmd = new SqlCommand("procInsert_image3_Signature", sqlCon);
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.Add("@Signature", image);
                sqlCmd.Parameters.Add("@Bar_Code", strBarcode);
                sqlCmd.ExecuteNonQuery();
                FN_CloseConnection();
            }
            catch (Exception ex)
            {
                FN_CloseConnection();
            }
        }


        // To Update Image of student by Bar_Code
        public void FNInsert_Image4_StuImage(Byte[] image, string strBarcode)
        {
            sqlCmd = new SqlCommand();
            sqlAdapter = new SqlDataAdapter();
            ds = new DataSet();
            try
            {
                FN_OpenConnection();
                sqlCmd = new SqlCommand("procInsert_image4_StuImage", sqlCon);
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.Add("@Stu_Image", image);
                sqlCmd.Parameters.Add("@Bar_Code", strBarcode);
                sqlCmd.ExecuteNonQuery();
                FN_CloseConnection();
            }
            catch (Exception ex)
            {
                FN_CloseConnection();
            }
        }


        public void FNInsert_EmployeeImage(Byte[] image)
        {
            sqlCmd = new SqlCommand();
            sqlAdapter = new SqlDataAdapter();
            ds = new DataSet();
            try
            {
                FN_OpenConnection();
                sqlCmd = new SqlCommand("PAY_procInsert_Employeeimage1", sqlCon);
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@employeeImage", image);

                sqlCmd.ExecuteNonQuery();
                FN_CloseConnection();
            }
            catch (Exception ex)
            {
                FN_CloseConnection();
            }
        }


        public string FN_ExecuteNonQuery(string Queary)
        {
            sqlCmd = new SqlCommand();
            sqlAdapter = new SqlDataAdapter();
            ds = new DataSet();
            string _Values = "";
            try
            {
                FN_OpenConnection();
                sqlCmd = new SqlCommand(Queary, sqlCon);
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = Queary;
                SqlDataReader dr_ = sqlCmd.ExecuteReader();
                while (dr_.Read())
                {
                    _Values = dr_[0].ToString();
                }
                FN_CloseConnection();
                return _Values;

            }
            catch (Exception ex)
            {
                FN_CloseConnection();
                return _Values;
            }
        }
            
     
        
    }
}
