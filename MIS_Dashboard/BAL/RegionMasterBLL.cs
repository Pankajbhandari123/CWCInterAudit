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

    public class RegionMasterBLL
    {
        RegionMasterDLL odll = new RegionMasterDLL();

        public DataSet bindGrid(int masterId)
        {
            return odll.bindGrid(masterId);
        }

        public int SaveUpdateRegion(int activeStatus, string createdBy, string RegionName, string RegionCode, int masterID)
        {
            return odll.SaveUpdateRegion(activeStatus, createdBy, RegionName, RegionCode, masterID);
        }
    }
}
