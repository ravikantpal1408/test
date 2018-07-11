using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;
using System.Globalization;
using System.IO;



namespace GEN.Utility
{
    /// <summary>
    /// Created By Deepti
    /// </summary>
    public class Utility
    {


        /// <summary>
        /// To dispose object
        /// </summary>
        /// <param name="obj">Object</param>
        public static void DisposeObject(Object obj)
        {
            try
            {
                if (obj != null)
                {
                    obj = null;
                }
            }
            finally
            {

            }
        }

        /// <summary>
        /// To create data column        
        /// </summary>
        /// <param name="caption">Caption</param>
        /// <param name="columnName">Column Name</param>
        /// <param name="dataType">Data Type</param>
        /// <returns></returns>
        public static DataColumn CreateDataColumn(string caption, string columnName, string dataType)
        {

            DataColumn column = null;
            try
            {
                column = new DataColumn();
                column.Caption = caption;
                column.ColumnName = columnName;
                column.DataType = System.Type.GetType(dataType);
                return column;
            }
            finally
            {
                if (column != null)
                {
                    column.Dispose();
                    column = null;
                }
            }
        }
        /// <summary>
        /// To dispose data table object
        /// </summary>
        /// <param name="tbl">Data Table Object</param>
        public static void DisposeDataTable(DataTable tbl)
        {
            try
            {
                if (tbl != null)
                {
                    tbl.Dispose();
                    tbl = null;
                }
            }
            finally
            {

            }
        }
        /// <summary>
        /// To dispose dataset object
        /// </summary>
        /// <param name="ds">Dataset Object</param>
        public static void DisposeDataSet(DataSet ds)
        {
            try
            {
                if (ds != null)
                {
                    ds.Dispose();
                    ds = null;
                }
            }
            finally
            {

            }
        }


        public static string Change_Date_Format(string str_date)
        {
            string strformatdate = string.Empty;
            if (str_date != "")
            {
                try
                {
                    string[] str_date_temp = str_date.Split('-');
                    strformatdate = str_date_temp[2].ToString() + '-' + str_date_temp[1].ToString() + '-' + str_date_temp[0].ToString();
                }
                finally
                {

                }


            }
            return strformatdate;
        }


        /// <summary>
        /// To format date time string into "MM/dd/yyyy"
        /// </summary>
        /// <param name="strdate">string Date Time</param>
        public static string DateTimeFormat(string strdate)
        {
            string strFormatedDate = string.Empty;
            if (strdate != "")
            {
                DateTime dt = new DateTime();
                string strFormattedDate = string.Empty;
                try
                {
                    string[] strDateTime = strdate.Split('-');
                    strFormattedDate = strDateTime[1].ToString() + "-" + strDateTime[0].ToString() + "-" + strDateTime[2].ToString();
                    dt = Convert.ToDateTime(strFormattedDate.Trim(), DateTimeFormatInfo.InvariantInfo);
                    strFormatedDate = dt.ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo);
                    // return dt.ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo);

                }
                finally
                {

                }
            }
            return strFormatedDate;
        }


        /// <summary>
        /// To create the directory
        /// </summary>
        /// <param name="directoryPath">Directory Path</param>
        public static void CreateDirectory(string directoryPath)
        {
            System.IO.DirectoryInfo directoryInfo = null;
            try
            {
                directoryInfo = new System.IO.DirectoryInfo(directoryPath);
                if (!directoryInfo.Exists)
                {
                    directoryInfo.Create();

                }
            }
            finally
            {
                //To release the memory
                DisposeObject(directoryPath);
            }
        }



        /// <summary>
        /// To Set the Page privilege(add,edit,delete....) corresponding to Role of User
        /// Created By Deepti
        /// Created On 26-08-2010
        /// </summary>
        /// <param name="User_ID">User ID</param>
        /// <param name="Role_ID">Role ID</param>
        ///<param name="Module_ID">Module ID</param>
        ///<param name="Page_ID">Page ID</param>
        /// <param name="Privilege_Type">Privilege Type</param>
       
        public static DataSet GenerateYear()
        {

            string Session_Year;
            int base_year, current_year;
            //objAcc = new Accounts();
            DataSet dsTable = new DataSet("dsTable");
            DataRow dr = null;
            DataTable dtSession = new DataTable();

            dtSession.Columns.Add("value");
            dtSession.Columns.Add("Text");
            DateTime FinDate = Convert.ToDateTime("04/01/" + (System.DateTime.Now.Year));
            if ((System.DateTime.Now) >= FinDate)
            {
                current_year = Convert.ToInt32(System.DateTime.Now.Year) + 1;
            }
            else
            {
                current_year = Convert.ToInt32(System.DateTime.Now.Year);
            }

            for (base_year = current_year; base_year >= 2000; base_year--)
            {
                Session_Year = ((base_year) + "-" + (base_year + 1)).ToString();
                dr = dtSession.NewRow();
                dr["value"] = Session_Year;
                dr["Text"] = Session_Year;
                dtSession.Rows.Add(dr);
            }
            dsTable.Tables.Add(dtSession);
            return dsTable;
        }
        //-------------------------------//
        //-----------------Created By Mudassir, Date-21-12-2010--//
        public static string setFinancialYear()
        {
            try
            {

                string strFinancialYear = DateTime.Now.Date.ToString("yyyy");
                string MonthPart = DateTime.Now.Date.ToString("MM");
                if (MonthPart == "01" || MonthPart == "02" || MonthPart == "03")
                {
                    strFinancialYear = (Convert.ToInt32(strFinancialYear) - 1).ToString() + "-" + strFinancialYear;
                    return strFinancialYear;
                }
                else
                {
                    strFinancialYear = strFinancialYear + "-" + (Convert.ToInt32(strFinancialYear) + 1).ToString();
                    return strFinancialYear;

                }
            }
            finally
            { }
        }



        //-----------------------------//

        //It convert Number to Word (used for Rs.)
        public string NumberToText(int number)
        {


            if (number == 0) return "Zero";

            if (number == -2147483648) return "Minus Two Hundred and Fourteen Crore Seventy Four Lakh Eighty Three Thousand Six Hundred and Forty Eight";

            int[] num = new int[4];

            int first = 0;

            int u, h, t;

            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            if (number < 0)
            {
                sb.Append("Minus ");
                number = -number;
            }
            string[] words0 = {"" ,"One ", "Two ", "Three ", "Four ",
      "Five " ,"Six ", "Seven ", "Eight ", "Nine "};
            string[] words1 = {"Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ",
      "Fifteen ","Sixteen ","Seventeen ","Eighteen ", "Nineteen "};
            string[] words2 = {"Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ",
      "Seventy ","Eighty ", "Ninety "};
            string[] words3 = { "Thousand ", "Lakh ", "Crore " };
            num[0] = number % 1000; // units
            num[1] = number / 1000;
            num[2] = number / 100000;
            num[1] = num[1] - 100 * num[2]; // thousands
            num[3] = number / 10000000; // crores
            num[2] = num[2] - 100 * num[3]; // lakhs
            for (int i = 3; i > 0; i--)
            {
                if (num[i] != 0)
                {
                    first = i;
                    break;
                }
            }
            for (int i = first; i >= 0; i--)
            {
                if (num[i] == 0) continue;
                u = num[i] % 10; // ones
                t = num[i] / 10;
                h = num[i] / 100; // hundreds
                t = t - 10 * h; // tens
                if (h > 0) sb.Append(words0[h] + "Hundred ");
                if (u > 0 || t > 0)
                {
                    if (h > 0 || i == 0) sb.Append("and ");
                    if (t == 0)
                        sb.Append(words0[u]);
                    else if (t == 1)
                        sb.Append(words1[u]);
                    else
                        sb.Append(words2[t - 2] + words0[u]);
                }
                if (i != 0) sb.Append(words3[i - 1]);
            }
            return sb.ToString().TrimEnd();
        }


        public static int CheckInteger(string str)
        {
            try
            {
                int i = Convert.ToInt32(str);
                return i;

            }
            catch
            {
                return 0;
            }
        }
        public static double CheckDouble(string str)
        {
            try
            {
                double i;
                i = Convert.ToDouble(str);
                return i;
            }
            catch
            {
                return 0.00;
            }


        }
        //Created By Mudassir, 04-July-2011
        public static string GetDateTo(string Month, string Year)
        {
            string strDateTo = string.Empty;
            string strFinancialYear = Year;

            if (Month == "01" || Month == "03" || Month == "05"
                     || Month == "07" || Month == "08" || Month == "10"
                   || Month == "12")
            {

                strDateTo = Month + "/31/" + strFinancialYear;
            }
            else if (Month == "04" || Month == "06" || Month == "09"
                     || Month == "11")
            {

                strDateTo = Month + "/30/" + strFinancialYear;
            }
            else if (Month == "02")
            {
                if (Convert.ToInt32(strFinancialYear) % 4 != 0)
                {
                    strDateTo = Month + "/28/" + strFinancialYear;
                }
                else
                {
                    strDateTo = Month + "/29/" + strFinancialYear;
                }
            }
            return strDateTo;
        }

        // Functions By Satyen
        public string formatdate(string date)
        {
            string str1 = string.Empty;
            if (date != string.Empty)
            {

                string day = date.Substring(0, 2);
                string month = date.Substring(3, 3);
                string year = date.Substring(6);
                string mo = month.Substring(0, 2);
                str1 = year + "-" + mo + "-" + day;
            }
            return str1;
        }
        public static string GetSession(string strdate)
        {
            string strFormatedDate = string.Empty;
            if (strdate != "")
            {
                DateTime dt = new DateTime();
                //string strFormattedDate = string.Empty;
                try
                {
                    string[] strDateTime = strdate.Split('-');

                    if (Convert.ToInt32(strDateTime[1]) < 04)
                    {
                        // strFormatedDate = (Convert.ToInt32(strDateTime[0]) - 1).ToString() + "-" + strDateTime[0].ToString().Substring(2, 2);
                        strFormatedDate = "01" + "-" + "04" + "-" + (Convert.ToInt32(strDateTime[2]) - 1).ToString();
                    }
                    else
                    {
                        //strFormatedDate = strDateTime[0].ToString() + "-" + (Convert.ToInt32(strDateTime[0]) + 1).ToString().Substring(2, 2);
                        strFormatedDate = "01" + "-" + "04" + "-" + strDateTime[2];
                    }
                }
                finally
                {

                }
            }
            return strFormatedDate;
        }

    }
}
