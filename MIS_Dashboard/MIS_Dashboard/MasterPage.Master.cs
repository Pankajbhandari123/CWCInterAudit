using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;

namespace MIS_Dashboard
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        PageClass PC = new PageClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["LoginName"] != null)
                {
                    menu.InnerHtml = PC.RenderMenuPermissions(Convert.ToInt32(Session["UserRecNo"]));
                    menu.InnerHtml = PC.RenderMenuPermissions(Convert.ToInt32(1));

                }

                if (Session["DisplayName"] != null && Session["DisplayName"].ToString() != "")
                {
                    lblUsernameDisplay.Text = Session["DisplayName"].ToString();
                }

            }

        }

        protected void lnklogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/HomePage.aspx");
        }

        protected void lnkChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ChangePassword.aspx");
        }
    }
}