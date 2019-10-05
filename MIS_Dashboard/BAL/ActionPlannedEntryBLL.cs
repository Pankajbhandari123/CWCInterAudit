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
  public  class ActionPlannedEntryBLL
    {

      ActionPlannedEntryDLL odll = new ActionPlannedEntryDLL();

      public DataSet BindDivision(int UserRecno)
      {
          return odll.BindDivision(UserRecno);
      }

      public DataSet BindRegion()
      {
          return odll.BindRegion();
      }

      public DataSet BindGridForEditDetails(int masterid)
      {
          return odll.BindGridForEditDetails(masterid);
      }

      public DataSet BindUnit()
      {
          return odll.BindUnit();
      }

      public int SaveUpdateDetails(int masterid, int officetype, int divisionRegionRecno, string divisionRegionName, int initiativerecno, string initiativeName, string scheme, int requireChnages, string requirechangesRemarks, string parameter, string unitname, string hundredDyas, string august, string firstYear, string secondYear, string thirdYear, string fourthYear, string fifthYear, string parameterRemarks, string hundredDyasRemarks, string augustRemarks, string firstYearRemarks,string secondYearRemarks, string thirdYearRemarks, string fourthYearRemarks,
                       string fifthYearRemarks, string createdBy)
      {
          return odll.SaveUpdateDetails(masterid, officetype, divisionRegionRecno, divisionRegionName, initiativerecno, initiativeName, scheme, requireChnages, requirechangesRemarks, parameter, unitname, hundredDyas, august, firstYear, secondYear, thirdYear, fourthYear, fifthYear, parameterRemarks, hundredDyasRemarks, augustRemarks, firstYearRemarks, secondYearRemarks, thirdYearRemarks, fourthYearRemarks,
                        fifthYearRemarks, createdBy);
      }

      public DataSet GetBindGridData(int ID)
      {
          return odll.GetBindGridData(ID);
      }
    }
}
