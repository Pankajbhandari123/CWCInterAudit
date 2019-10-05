using BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MIS_Dashboard
{
    public partial class Para_Master : System.Web.UI.Page
    {
        public int vsintParaId
        {
            get
            {
                if (ViewState["vsintParaId"] == null)
                    return 0;
                else
                    return (int)ViewState["vsintParaId"];
            }
            set { ViewState["vsintParaId"] = value; }
        }

        Para_MasterBLL obll = new Para_MasterBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AddRepeater(1);
                DataSet ds = obll.BindReportDropDown();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlReportNumber.Items.Clear();
                    ddlReportNumber.DataSource = ds;
                    ddlReportNumber.DataValueField = "REPORT_ID";
                    ddlReportNumber.DataTextField = "REPORTNUMBER";
                    ddlReportNumber.DataBind();
                    ddlReportNumber.Items.Insert(0, new ListItem("Select"));
                }
            }
        }

        protected void lnkbtnEdit_Click(object sender, EventArgs e)
        {

        }

        protected void lnkbtnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void grdvUser_PreRender(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSave.Text == "Save")
                {

                    saveComplaintEmployeeInfo();
                }
              
            }
            catch (Exception ex)
            {

            }
        }


        private void saveComplaintEmployeeInfo()
        {
            try
            {
                foreach (RepeaterItem item in rptActivity.Items)
                {
                    TextBox txtParaName = (TextBox)item.FindControl("txtParaName");
                    HiddenField hdnParaId = (HiddenField)item.FindControl("hdnParaId");


                    int Result = obll.SaveUpdateParaDetails(txtParaName.Text, vsintParaId, txtParaSubject.Text, ddlReportNumber.SelectedValue);


                }

            }
            catch (Exception ex)
            {

            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {

        }
        protected void imgbtnDeleteRowactivity_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                ImageButton Remove = (sender as ImageButton);
                string commandArgument = Remove.CommandArgument;
                RepeaterItem row = Remove.NamingContainer as RepeaterItem;
                int index = row.ItemIndex;
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("hdnParaID", typeof(int)));
                dt.Columns.Add(new DataColumn("txtParaName", typeof(string)));
                int rptcount = rptActivity.Items.Count;
                HiddenField hdnParaID = (HiddenField)rptActivity.Items[index].FindControl("hdnParaID");
                int masterid = 0;
                if (hdnParaID.Value != string.Empty)
                {
                    masterid = Convert.ToInt32(hdnParaID.Value);
                }

                foreach (RepeaterItem item in rptActivity.Items)
                {
                    if (item.ItemIndex != index)
                    {
                        string value = "";
                        HiddenField hf = (HiddenField)item.FindControl("hdnParaID");
                        TextBox txtParaName = (TextBox)item.FindControl("txtParaName");

                        DataRow dr = dt.NewRow();

                        dr["hdnParaID"] = hf.Value;
                        dr["txtParaName"] = txtParaName.Text;



                        dt.Rows.Add(dr);
                    }
                }
                if (dt.Rows.Count == 0)
                {
                    AddSubActivity(rptcount - 1);
                }
                else
                {
                    AddSubActivity(dt.Rows.Count);
                }

                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        HiddenField hdnParaID123 = (HiddenField)rptActivity.Items[i].FindControl("hdnParaID");
                        TextBox txtParaName = (TextBox)rptActivity.Items[i].FindControl("txtParaName");
                        hdnParaID123.Value = dt.Rows[i]["hdnParaID"].ToString();
                        txtParaName.Text = dt.Rows[i]["txtParaName"].ToString();
                    }
                    //string Result = oActivityBAL.updateActivityStatus(masterid).ToString();
                }
            }
            catch (Exception)
            {
            }
        }

        public void AddSubActivity(int count)
        {
            try
            {
                // btnSaveWellWiseDrillingPipe.Text = "Save";
                DataTable dtOrignalCopy = new DataTable("Repeater");
                DataRow drOrignalCopy;
                int hikePrice = 0;
                dtOrignalCopy.Columns.Add(new DataColumn("paraID", typeof(Int32)));
                dtOrignalCopy.Columns.Add(new DataColumn("ParaName", typeof(string)));
                for (int i = 0; i < count; i++)
                {
                    drOrignalCopy = dtOrignalCopy.NewRow();
                    drOrignalCopy[0] = i;
                    dtOrignalCopy.Rows.Add(drOrignalCopy);
                }
                rptActivity.DataSource = dtOrignalCopy;
                rptActivity.DataBind();
                foreach (RepeaterItem item in rptActivity.Items)
                {

                    TextBox txtParaName = (TextBox)item.FindControl("txtParaName");
                    LinkButton a = (LinkButton)item.FindControl("imgbtnAddRowactivity");
                    LinkButton r = (LinkButton)item.FindControl("imgbtnDeleteRowactivity");
                }
                int ItemCount = rptActivity.Items.Count;
                if (ItemCount == 1)
                {
                    //    TextBox hike = (TextBox)rptRigPump.Items[0].FindControl("txthike");
                    LinkButton Add = (LinkButton)rptActivity.Items[0].FindControl("imgbtnDeleteRowactivity");
                    Add.Visible = false;
                }
                else if (ItemCount > 1)
                {
                    double rate = 0;
                    foreach (RepeaterItem item in rptActivity.Items)
                    {
                        if (item.ItemIndex != ItemCount - 1)
                        {
                            LinkButton Add = (LinkButton)item.FindControl("imgbtnAddRowactivity");
                            Add.Visible = false;

                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void AddRepeater(int count)
        {
            DataTable dtOccupationRates = new DataTable("Repeater");
            DataRow drOccupationRates;

            dtOccupationRates.Columns.Add(new DataColumn("paraID", typeof(Int32)));
            dtOccupationRates.Columns.Add(new DataColumn("ParaName", typeof(string)));
            for (int i = 0; i < count; i++)
            {
                drOccupationRates = dtOccupationRates.NewRow();
                drOccupationRates[0] = i;
                dtOccupationRates.Rows.Add(drOccupationRates);
            }
            rptActivity.DataSource = dtOccupationRates;
            rptActivity.DataBind();

            foreach (RepeaterItem item in rptActivity.Items)
            {
                TextBox txtParaName = (TextBox)item.FindControl("txtParaName");
            }

            if (rptActivity.Items.Count > 0)
            {
                foreach (RepeaterItem item in rptActivity.Items)
                {
                    ImageButton imgbtnAddRow = (ImageButton)item.FindControl("imgbtnAddRowactivity");
                    //  imgbtnAddRow.Visible = false;
                    ImageButton imgbtnDeleteRow = (ImageButton)item.FindControl("imgbtnDeleteRowactivity");
                    imgbtnDeleteRow.Visible = false;
                    TextBox txtParaName = (TextBox)item.FindControl("txtParaName");

                }

                if (rptActivity.Items.Count > 1)
                {
                    int cnt = 1;
                    foreach (RepeaterItem item in rptActivity.Items)
                    {
                        if (rptActivity.Items.Count != cnt)
                        {
                            ImageButton imgbtnAddRow = (ImageButton)item.FindControl("imgbtnAddRowactivity");
                            imgbtnAddRow.Visible = false;

                            ImageButton imgbtnDeleteRow = (ImageButton)item.FindControl("imgbtnDeleteRowactivity");
                            imgbtnDeleteRow.Visible = false;
                        }
                        else if (rptActivity.Items.Count == cnt)
                        {
                            ImageButton imgbtnAddRow = (ImageButton)item.FindControl("imgbtnAddRowactivity");
                            imgbtnAddRow.Visible = true;

                            ImageButton imgbtnDeleteRow = (ImageButton)item.FindControl("imgbtnDeleteRowactivity");
                            imgbtnDeleteRow.Visible = false;
                        }
                        cnt++;
                    }
                }
                else
                {
                    if (rptActivity.Items.Count == 1)
                    {
                        foreach (RepeaterItem item in rptActivity.Items)
                        {
                            ImageButton imgbtnAddRow = (ImageButton)item.FindControl("imgbtnAddRowactivity");
                            // imgbtnAddRow.Visible = true;

                            ImageButton imgbtnDeleteRow = (ImageButton)item.FindControl("imgbtnDeleteRowactivity");
                            //imgbtnDeleteRow.Visible = false;
                        }
                    }
                }
            }
        }

        protected void imgbtnAddRowactivity_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                bool flag = false;
                int ss = rptActivity.Items.Count;
                foreach (RepeaterItem item in rptActivity.Items)
                {
                    TextBox txtParaName = (TextBox)item.FindControl("txtParaName");
                    if (txtParaName.Text != "")
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                        string msg = "<script>alert('Please Fill all the data in above rows. unable to add new row.')</script>";
                        ScriptManager.RegisterStartupScript(this, typeof(Control), "alertmsg", msg, false);
                        break;
                    }
                }
                if (flag)
                {
                    int count = rptActivity.Items.Count;

                    count++;

                    DataTable dt = new DataTable();
                    dt.Columns.Add(new DataColumn("ParaID", typeof(int)));
                    dt.Columns.Add(new DataColumn("ParaName", typeof(string)));
                    foreach (RepeaterItem item in rptActivity.Items)
                    {
                        TextBox txtParaName = (TextBox)item.FindControl("txtParaName");
                        HiddenField hdnParaId = (HiddenField)item.FindControl("hdnParaId");
                        DataRow dr = dt.NewRow();
                        dr["ParaID"] = hdnParaId.Value;
                        dr["ParaName"] = txtParaName.Text;
                        dt.Rows.Add(dr);
                    }
                    AddSubActivity(count);

                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            HiddenField hdnSubActivity = (HiddenField)rptActivity.Items[i].FindControl("hdnParaID");
                            TextBox txtParaName = (TextBox)rptActivity.Items[i].FindControl("txtParaName");
                            // hdnSubActivity.Value = dt.Rows[i]["hdnParaID"].ToString();
                            txtParaName.Text = dt.Rows[i]["ParaName"].ToString();
                            hdnSubActivity.Value = dt.Rows[i]["ParaID"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}