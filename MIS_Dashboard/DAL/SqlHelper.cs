using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Text;
using System.Text.RegularExpressions;

namespace DAL
{
    public class SqlHelper
    {
        private MySqlConnection nisConn;
        private MySqlCommand nisDataCommand;
        private MySqlDataAdapter nisDataAdapter = new MySqlDataAdapter();
        private MySqlTransaction nisTrans;

        public void OpenConn()
        {
            if (nisConn == null)
            {
                //nisConn = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
                nisConn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["con"].ConnectionString);

                if (nisConn.State == ConnectionState.Closed)
                {
                    nisConn.Open();
                    nisDataCommand = new MySqlCommand();
                    nisDataCommand.Connection = nisConn;
                }
            }
            else
            {
                if (nisConn.State == ConnectionState.Closed)
                    nisConn.Open();
                nisDataCommand = new MySqlCommand();
                nisDataCommand.Connection = nisConn;
            }
        }

        public void OpenConn1()
        {
            nisConn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            if (nisConn == null)
            {

                //nisConn = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
                nisConn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["con"].ConnectionString);

                if (nisConn.State == ConnectionState.Closed)
                {
                    nisConn.Open();
                    nisDataCommand = new MySqlCommand();
                    nisDataCommand.Connection = nisConn;
                }
            }
            else
            {
                if (nisConn.State == ConnectionState.Closed)
                    nisConn.Open();
                nisDataCommand = new MySqlCommand();
                nisDataCommand.Connection = nisConn;
            }
        }
        public void CloseConn()
        {
            if (nisConn != null)
            {
                if (nisConn.State == ConnectionState.Open)
                    nisConn.Close();
            }

        }
        public void disposeConn()
        {
            if (nisConn != null)
            {
                if (nisConn.State == ConnectionState.Closed)
                    nisConn.Dispose();
                nisConn = null;
            }
        }
        public void OpenTransaction()
        {
            if (nisTrans != null)
            {
                nisTrans = null;
            }

            nisTrans = nisDataCommand.Connection.BeginTransaction(IsolationLevel.ReadCommitted);
            nisDataCommand.Transaction = nisTrans;

        }
        public void CommintTransaction()
        {
            if (nisTrans != null)
            {
                nisTrans.Commit();
            }
        }

        public void RollbackTransaction()
        {
            if (nisTrans != null)
            {
                if (nisTrans.Connection != null)
                {
                    nisTrans.Rollback();
                }
            }
        }

        public int execStoredProcudure(string strProcName, MySqlParameter[] arProcParams)
        {
            int returnValue;

            MySqlParameter param = new MySqlParameter();
            OpenConn();
            nisDataCommand.CommandType = CommandType.StoredProcedure;
            nisDataCommand.CommandText = strProcName;

            nisDataCommand.Parameters.Clear();
            foreach (MySqlParameter LoopVar_param in arProcParams)
            {
                param = LoopVar_param;
                nisDataCommand.Parameters.Add(param);
            }
            returnValue = Convert.ToInt32(nisDataCommand.ExecuteScalar());
            CloseConn();
            disposeConn();

            return returnValue;
        }



        public int execStoredProcudure(string strProcName, MySqlParameter[] arProcParams, string str)
        {
            int returnValue;
            OpenConn();
            MySqlParameter param = new MySqlParameter();
            nisDataCommand.CommandType = CommandType.StoredProcedure;
            nisDataCommand.CommandText = strProcName;
            nisDataCommand.Parameters.Clear();
            foreach (MySqlParameter LoopVar_param in arProcParams)
            {
                param = LoopVar_param;
                nisDataCommand.Parameters.Add(param);
            }
            returnValue = Convert.ToInt32(nisDataCommand.ExecuteScalar());
            CloseConn();
            disposeConn();
            return returnValue;
        }

        public int execSQL(string strSql)
        {
            nisDataCommand.CommandType = CommandType.Text;
            nisDataCommand.CommandText = strSql;
            int intRows = nisDataCommand.ExecuteNonQuery();

            return intRows;
        }

        public string execScaler(string strSql)
        {
            string val = "";
            this.OpenConn();
            nisDataCommand.CommandType = CommandType.Text;
            nisDataCommand.CommandText = strSql;
            val = Convert.ToString(nisDataCommand.ExecuteScalar());
            return val;
            this.CloseConn();
        }
        public string execScaler(string strSql, string str, MySqlParameter[] arProcParams)
        {
            string val = "";
            if (str == "Query")
            {
                this.OpenConn();
                nisDataCommand.CommandType = CommandType.Text;
                nisDataCommand.CommandText = strSql;
                val = Convert.ToString(nisDataCommand.ExecuteScalar());
                this.CloseConn();
            }
            else if (str == "Procedure")
            {
                MySqlParameter param = new MySqlParameter();
                this.OpenConn();
                foreach (MySqlParameter LoopVar_param in arProcParams)
                {
                    param = LoopVar_param;
                    nisDataCommand.Parameters.Add(param);
                }
                nisDataCommand.CommandType = CommandType.StoredProcedure;
                nisDataCommand.CommandText = strSql;
                val = Convert.ToString(nisDataCommand.ExecuteScalar());

                this.CloseConn();
            }
            return val;

        }
        public DataTable getDataTable(string Storeproc, String Command)
        {
            this.OpenConn();
            MySqlDataAdapter da = new MySqlDataAdapter(Storeproc, nisConn);
            if (Command == "Procedure")
            {
                nisDataCommand.CommandType = CommandType.StoredProcedure;
            }
            else if (Command == "Query")
            {
                nisDataCommand.CommandType = CommandType.Text;
            }
            nisDataCommand.CommandText = Storeproc;
            DataTable dt = new DataTable();
            da.Fill(dt);
            this.CloseConn();
            this.disposeConn();
            return dt;
        }


        public DataTable getDataTable(string StoreProc, MySqlParameter[] arProcParams, String tblname)
        {
            DataSet ds = new DataSet();
            MySqlParameter param = new MySqlParameter();
            OpenConn();
            MySqlDataAdapter da = new MySqlDataAdapter(StoreProc, nisConn);
            nisDataCommand.CommandType = CommandType.StoredProcedure;
            nisDataCommand.CommandText = StoreProc;
            nisDataCommand.Parameters.Clear();
            nisDataAdapter.SelectCommand = nisDataCommand;

            foreach (MySqlParameter LoopVar_param in arProcParams)
            {
                param = LoopVar_param;
                nisDataCommand.Parameters.Add(param);
            }
            if (tblname == null || tblname == "")
            {
                nisDataAdapter.Fill(ds);
            }
            else
            {
                nisDataAdapter.Fill(ds, tblname);
            }
            DataTable dt = new DataTable();
            nisDataAdapter.Fill(dt);
            this.CloseConn();
            this.disposeConn();
            return dt;
        }


        public DataSet getDataSet(string StoreProc, MySqlParameter[] arProcParams, String tblname)
        {
            DataSet ds1 = new DataSet();
           // DataSet ds = new DataSet();
            try
            {
                MySqlParameter param = new MySqlParameter();
                OpenConn();
                MySqlDataAdapter da = new MySqlDataAdapter(StoreProc, nisConn);
                nisDataCommand.CommandType = CommandType.StoredProcedure;
                nisDataCommand.CommandText = StoreProc;
                nisDataCommand.CommandTimeout = 21600;

                nisDataCommand.Parameters.Clear();
                da.SelectCommand = nisDataCommand;

                foreach (MySqlParameter LoopVar_param in arProcParams)
                {
                    param = LoopVar_param;
                    nisDataCommand.Parameters.Add(param);
                }
                //if (tblname == null || tblname == "")
                //{
                //    nisDataAdapter.Fill(ds);
                //}
                //else
                //{
                //    nisDataAdapter.Fill(ds, tblname);
                //}

                da.Fill(ds1);
                this.CloseConn();
                this.disposeConn();

            }
            catch (Exception ex)
            {
                ds1 = null;
            }
            return ds1;
        }




        public DataSet GetDataSet(string strSql)
        {
            this.OpenConn();
            MySqlDataAdapter da = new MySqlDataAdapter(strSql, nisConn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            this.CloseConn();
            this.disposeConn();
            return ds;
        }

        public DataSet GetDataSet(string strSql, string tblname)
        {
            this.OpenConn();
            MySqlDataAdapter da = new MySqlDataAdapter(strSql, nisConn);
            DataSet ds = new DataSet();
            da.Fill(ds, tblname);
            this.CloseConn();
            this.disposeConn();
            return ds;
        }

        public DataSet GetDataSet(string strSPName, string tblname, MySqlParameter[] arProcParams)
        {
            this.OpenConn();
            DataSet ds = new DataSet();
            MySqlParameter param = new MySqlParameter();
            nisDataCommand.CommandType = CommandType.StoredProcedure;
            nisDataCommand.CommandText = strSPName;
            nisDataCommand.Parameters.Clear();
            nisDataAdapter.SelectCommand = nisDataCommand;

            foreach (MySqlParameter LoopVar_param in arProcParams)
            {
                param = LoopVar_param;
                nisDataCommand.Parameters.Add(param);
            }
            if (tblname == null)
            {
                nisDataAdapter.Fill(ds);
            }
            else
            {
                nisDataAdapter.Fill(ds, tblname);
            }
            this.CloseConn();
            this.disposeConn();
            return ds;
        }

        private MySqlDataReader getDataReader(string strSql)
        {
            this.OpenConn();
            MySqlDataReader dReader;
            nisDataCommand.CommandType = CommandType.Text;
            nisDataCommand.CommandText = strSql;
            dReader = nisDataCommand.ExecuteReader(CommandBehavior.CloseConnection);
            return dReader;

        }
        public int getSingleIntRecord(String Query, String FieldName)
        {
            int i = 0;

            MySqlDataReader dr;
            OpenConn();
            nisDataCommand = new MySqlCommand(Query, nisConn);
            dr = nisDataCommand.ExecuteReader(CommandBehavior.SingleResult);
            while (dr.Read())
            {
                if (dr[0].ToString() == "")
                {
                    i = 0;
                }
                else
                {
                    i = Convert.ToInt32(dr[0].ToString());

                }
            }
            CloseConn();
            return i;
        }
        public Boolean CheckforGrid(GridView grvGrid)
        {
            Boolean Msg = false;
            for (int i = 0; i <= grvGrid.Rows.Count - 1; i++)
            {
                CheckBox chk = (CheckBox)grvGrid.Rows[i].FindControl("chkMain");
                if (chk.Checked == true)
                {
                    Msg = true;
                    goto last;
                }

            }
        last: ;
            return Msg;
        }
        private string RemoveSpecialChar(string str)
        {
            Regex r = new Regex("(?:[^a-z0-9 ]|(?<=['\"])s)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);
            return r.Replace(str, String.Empty);
        }
    }
}
