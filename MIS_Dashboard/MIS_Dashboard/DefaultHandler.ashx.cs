using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
//using System.Data.SqlClient;
using System.Configuration;
using MySql.Data;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace MIS_Dashboard
{
    /// <summary>
    /// Summary description for DefaultHandler
    /// </summary>
    public class DefaultHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string str2 = context.Request.QueryString["request"];
            if (str2 == "getStatusForKpi")
            {
                this.getStatusForKpi(context);
            }
            else if (str2 == "getSpeedoMeterStatusForKpi")
            {
                this.getSpeedoMeterStatusForKpi(context);
            }
            else if (str2 == "getSpeedoMeterStatusForKpiAllCWC")
            {
                this.getSpeedoMeterStatusForKpiAllCWC(context);
            }
            else if (str2 == "getStatusCWC")
            {
                this.getStatusCWC(context);
            }
            else if (str2 == "getdivisionWiseData")
            {
                this.getdivisionWiseData(context);
            }
            else if (str2 == "FirstgetStatusForKPIGetDivision")
            {
                this.FirstgetStatusForKPIGetDivision(context);
            }
            else if (str2 == "getWeekWiseCWCStatus")
            {
                this.getWeekWiseCWCStatus(context);
            }
            else if (str2 == "WeekWisedivisionWiseDataFunction")
            {
                this.WeekWisedivisionWiseDataFunction(context);
            }
        }

        private void WeekWisedivisionWiseDataFunction(HttpContext context)
        {
            string jResp = "{\"status\":false,\"data\":\"\"}";
            try
            {
               // string kpiRecno = Convert.ToString(context.Request.Params["kpivalue"]);
                string value = Convert.ToString(context.Request.Params["name"]);
                DataSet ds = new DataSet();
                MySqlParameter param = new MySqlParameter();
                MySqlConnection connection = new MySqlConnection(getConstr());
                MySqlCommand selectCommand = new MySqlCommand("PROC_BIND_DASHBOARD_WEEKWISE_DIVISIONACTUALPLANNED", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.Clear();
                MySqlParameter[] spmLogin = { //new MySqlParameter("P_KPI_RECNO", kpiRecno),
                                                new MySqlParameter("P_VALUE",value)
                                           };
                MySqlDataAdapter adapter = new MySqlDataAdapter(selectCommand);

                foreach (MySqlParameter LoopVar_param in spmLogin)
                {
                    param = LoopVar_param;
                    selectCommand.Parameters.Add(param);
                }
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    jResp = "{\"status\":true,\"data\":" + this.DataTableToJsonWithJsonNet(dataTable) + "}";

                }
                else
                {
                    jResp = "{\"status\":false,\"data\":\"Information not found\"}";
                }
            }
            catch
            {
                jResp = "{\"status\":false,\"data\":\"\"}";
            }
            writeResponse(context, jResp);
        }

        private void getWeekWiseCWCStatus(HttpContext context)
        {
            string jResp = "{\"status\":false,\"data\":\"\"}";
            try
            {
               // string kpiRecno = Convert.ToString(context.Request.Params["kpivalue"]);
                DataSet ds = new DataSet();
                MySqlParameter param = new MySqlParameter();
                MySqlConnection connection = new MySqlConnection(getConstr());
                MySqlCommand selectCommand = new MySqlCommand("PROC_BIND_DASHBOARD_WEEKWISE_CWC1", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.Clear();
                MySqlParameter[] spmLogin = { //new MySqlParameter("P_KPI_RECNO", kpiRecno)
                                           };
                MySqlDataAdapter adapter = new MySqlDataAdapter(selectCommand);

                foreach (MySqlParameter LoopVar_param in spmLogin)
                {
                    param = LoopVar_param;
                    selectCommand.Parameters.Add(param);
                }
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    jResp = "{\"status\":true,\"data\":" + this.DataTableToJsonWithJsonNet(dataTable) + "}";

                }
                else
                {
                    jResp = "{\"status\":false,\"data\":\"Information not found\"}";
                }
            }
            catch
            {
                jResp = "{\"status\":false,\"data\":\"\"}";
            }
            writeResponse(context, jResp);
        }

        private void FirstgetStatusForKPIGetDivision(HttpContext context)
        {
            string jResp = "{\"status\":false,\"data\":\"\"}";
            try
            {
                string divisionName = Convert.ToString(context.Request.Params["DIVISIONName"]);
                DataSet ds = new DataSet();
                MySqlParameter param = new MySqlParameter();
                MySqlConnection connection = new MySqlConnection(getConstr());
                MySqlCommand selectCommand = new MySqlCommand("PROC_GET_DIVISION_RECNO", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.Clear();
                MySqlParameter[] spmLogin = { new MySqlParameter("P_DIVISION_NAME", divisionName)
                                           };
                MySqlDataAdapter adapter = new MySqlDataAdapter(selectCommand);

                foreach (MySqlParameter LoopVar_param in spmLogin)
                {
                    param = LoopVar_param;
                    selectCommand.Parameters.Add(param);
                }
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    jResp = "{\"status\":true,\"data\":" + this.DataTableToJsonWithJsonNet(dataTable) + "}";

                }
                else
                {
                    jResp = "{\"status\":false,\"data\":\"Information not found\"}";
                }
            }
            catch
            {
                jResp = "{\"status\":false,\"data\":\"\"}";
            }
            writeResponse(context, jResp);
        }

        private void getdivisionWiseData(HttpContext context)
        {
            string jResp = "{\"status\":false,\"data\":\"\"}";
            try
            {
                string kpiRecno = Convert.ToString(context.Request.Params["kpivalue"]);
                string value = Convert.ToString(context.Request.Params["name"]);
                DataSet ds = new DataSet();
                MySqlParameter param = new MySqlParameter();
                MySqlConnection connection = new MySqlConnection(getConstr());
                MySqlCommand selectCommand = new MySqlCommand("PROC_BIND_DASHBOARD_DIVISION_WISE1", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.Clear();
                MySqlParameter[] spmLogin = { new MySqlParameter("P_KPI_RECNO", kpiRecno),
                                                new MySqlParameter("P_VALUE",value)
                                           };
                MySqlDataAdapter adapter = new MySqlDataAdapter(selectCommand);

                foreach (MySqlParameter LoopVar_param in spmLogin)
                {
                    param = LoopVar_param;
                    selectCommand.Parameters.Add(param);
                }
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    jResp = "{\"status\":true,\"data\":" + this.DataTableToJsonWithJsonNet(dataTable) + "}";

                }
                else
                {
                    jResp = "{\"status\":false,\"data\":\"Information not found\"}";
                }
            }
            catch
            {
                jResp = "{\"status\":false,\"data\":\"\"}";
            }
            writeResponse(context, jResp);
        }

        private string GETALLOTEDPLOT(DataTable dt)
        {
            string str = "";

            string str2 = str;

            str = str2 + "\"Data\":[" + GETPLOTS(dt) + "]";
            return str;
        }

        private object GETPLOTS(DataTable dt)
        {
            string str = "";
            foreach (DataRow row in dt.Rows)
            {
                string str2 = str;

                str = str2 + ((str == "") ? "" : ",") + "[" + row["jsonvalues"].ToString() + "]";
            }

            return str;
        }

        private void getStatusCWC(HttpContext context)
        {
            string jResp = "{\"status\":false,\"data\":\"\"}";
            try
            {
                string kpiRecno = Convert.ToString(context.Request.Params["kpivalue"]);
                DataSet ds = new DataSet();
                MySqlParameter param = new MySqlParameter();
                MySqlConnection connection = new MySqlConnection(getConstr());
                MySqlCommand selectCommand = new MySqlCommand("PROC_BIND_DASHBOARD_OVERALL_CWC", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.Clear();
                MySqlParameter[] spmLogin = { new MySqlParameter("P_KPI_RECNO", kpiRecno)
                                           };
                MySqlDataAdapter adapter = new MySqlDataAdapter(selectCommand);

                foreach (MySqlParameter LoopVar_param in spmLogin)
                {
                    param = LoopVar_param;
                    selectCommand.Parameters.Add(param);
                }
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    jResp = "{\"status\":true,\"data\":" + this.DataTableToJsonWithJsonNet(dataTable) + "}";

                }
                else
                {
                    jResp = "{\"status\":false,\"data\":\"Information not found\"}";
                }
            }
            catch
            {
                jResp = "{\"status\":false,\"data\":\"\"}";
            }
            writeResponse(context, jResp);
        }

        private void getStatusForKpi(HttpContext context)
        {
            string jResp = "{\"status\":false,\"data\":\"\"}";
            try
            {
                string tblname = "";
                string kpiRecno = Convert.ToString(context.Request.Params["kpivalue"]);
                string divisionRecno = Convert.ToString(context.Request.Params["divisionRecno"]);
                string page = "Dashboard";
                string index = "0";
                DataSet ds = new DataSet();
                MySqlParameter param = new MySqlParameter();

                MySqlConnection connection = new MySqlConnection(getConstr());
                connection.Open();
                MySqlCommand selectCommand = new MySqlCommand("PROC_GET_DATA_FOR_KPI_DASHBOARD", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("P_KPI_RECNO", kpiRecno);
                selectCommand.Parameters.AddWithValue("P_DIVISION_RECNO", divisionRecno);
                selectCommand.Parameters.AddWithValue("P_PAGE", page);
                selectCommand.Parameters.AddWithValue("P_INDEX", index);
                //MySqlParameter[] spmLogin = { new MySqlParameter("P_KPI_RECNO", kpiRecno),
                //                              new MySqlParameter("P_DIVISION_RECNO", divisionRecno)
                //                           };
                //foreach (MySqlParameter LoopVar_param in spmLogin)
                //{
                //    param = LoopVar_param;
                //    selectCommand.Parameters.Add(param);
                //}
                MySqlDataAdapter adapter = new MySqlDataAdapter(selectCommand);


                //if (tblname == null || tblname == "")
                //{
                //    adapter.Fill(ds);
                //}
                //else
                //{
                //    adapter.Fill(ds, tblname);
                //}

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    jResp = "{\"status\":true,\"data\":" + this.DataTableToJsonWithJsonNet(dataTable) + "}";
                }
                else
                {
                    jResp = "{\"status\":false,\"data\":\"No Information Found\"}";
                }
            }
            catch
            {
                jResp = "{\"status\":false,\"data\":\"\"}";
            }
            writeResponse(context, jResp);

        }

        private void getSpeedoMeterStatusForKpi(HttpContext context)
        {
            string jResp = "{\"status\":false,\"data\":\"\"}";
            try
            {
                string tblname = "";
                string kpiRecno = Convert.ToString(context.Request.Params["kpivalue"]);
                string divisionRecno = Convert.ToString(context.Request.Params["division"]);
                string initiativerecno = Convert.ToString(context.Request.Params["initiativerecno"]);
                DataSet ds = new DataSet();
                //      ds = null;
                MySqlParameter param = new MySqlParameter();

                MySqlConnection connection = new MySqlConnection(getConstr());
                connection.Open();
                MySqlCommand selectCommand = new MySqlCommand("PROC_BIND_DASHBOARD_SPEEDO_METER", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("P_KPI_RECNO", kpiRecno);
                selectCommand.Parameters.AddWithValue("P_DIVISION_RECNO", divisionRecno);
                selectCommand.Parameters.AddWithValue("P_INITIATIVE_RECNO", initiativerecno);
                //MySqlParameter[] spmLogin = { new MySqlParameter("P_KPI_RECNO", kpiRecno),
                //                              new MySqlParameter("P_DIVISION_RECNO", divisionRecno)
                //                           };
                //foreach (MySqlParameter LoopVar_param in spmLogin)
                //{
                //    param = LoopVar_param;
                //    selectCommand.Parameters.Add(param);
                //}
                MySqlDataAdapter adapter = new MySqlDataAdapter(selectCommand);


                //if (tblname == null || tblname == "")
                //{
                //    adapter.Fill(ds);
                //}
                //else
                //{
                //    adapter.Fill(ds, tblname);
                //}

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    jResp = "{\"status\":true,\"data\":" + this.DataTableToJsonWithJsonNet(dataTable) + "}";
                }
                else
                {
                    jResp = "{\"status\":false,\"data\":\"No Information Found\"}";
                }
            }
            catch
            {
                jResp = "{\"status\":false,\"data\":\"\"}";
            }
            writeResponse(context, jResp);

        }

        private void getSpeedoMeterStatusForKpiAllCWC(HttpContext context)
        {
            string jResp = "{\"status\":false,\"data\":\"\"}";
            try
            {
                string tblname = "";
                DataSet ds = new DataSet();
                //      ds = null;
                MySqlParameter param = new MySqlParameter();

                MySqlConnection connection = new MySqlConnection(getConstr());
                connection.Open();
                MySqlCommand selectCommand = new MySqlCommand("PROC_BIND_DASHBOARD_DATA_FOR_ALL_CWC", connection);
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.Clear();
                //MySqlParameter[] spmLogin = { new MySqlParameter("P_KPI_RECNO", kpiRecno),
                //                              new MySqlParameter("P_DIVISION_RECNO", divisionRecno)
                //                           };
                //foreach (MySqlParameter LoopVar_param in spmLogin)
                //{
                //    param = LoopVar_param;
                //    selectCommand.Parameters.Add(param);
                //}
                MySqlDataAdapter adapter = new MySqlDataAdapter(selectCommand);


                //if (tblname == null || tblname == "")
                //{
                //    adapter.Fill(ds);
                //}
                //else
                //{
                //    adapter.Fill(ds, tblname);
                //}

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    jResp = "{\"status\":true,\"data\":" + this.DataTableToJsonWithJsonNet(dataTable) + "}";
                }
                else
                {
                    jResp = "{\"status\":false,\"data\":\"No Information Found\"}";
                }
            }
            catch
            {
                jResp = "{\"status\":false,\"data\":\"\"}";
            }
            writeResponse(context, jResp);

        }

        public string DataTableToJsonWithJsonNet(DataTable table)
        {
            string jsonString = string.Empty;
            jsonString = JsonConvert.SerializeObject(table);
            return jsonString;
        }

        private static void writeResponse(HttpContext context, string jResp)
        {
            context.Response.ContentType = "application/json";
            context.Response.Write(jResp);
            context.Response.End();
        }

        private static string getConstr()
        {
            return ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

    }
}