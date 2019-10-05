using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Web.UI;
using DAL;

namespace BAL
{
    public class SchemeMasterrBLL
    {
        SchemeMasterrDLL odll = new SchemeMasterrDLL();
        public int SaveUpdateScheme(int activeStatus, string createdBy, string schemeName, int masterId)
        {
            return odll.SaveUpdateScheme(activeStatus, createdBy, masterId, schemeName);
        }

        public DataSet bindGrid(int masterId)
        {
            return odll.bindGrid(masterId);
        }
    }
}
