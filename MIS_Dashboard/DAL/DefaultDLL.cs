using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Web.UI;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace DAL
{
    
   public class DefaultDLL
    {

       SqlHelper sql = new SqlHelper();


       public DataSet BindFirstKPI()
       {
           MySqlParameter[] sqlPrm = { };
           return sql.getDataSet("PROC_BIND_KPI_DROPDOWN", sqlPrm, "");
       }

       public DataSet BindAllDivision()
       {
           MySqlParameter[] sqlPrm = { };
           return sql.getDataSet("PROC_BIND_DIVISION_DROPDOWN", sqlPrm, "");
       }
    }
}
