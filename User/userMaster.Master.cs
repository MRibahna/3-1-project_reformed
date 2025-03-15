using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineJobPortal.User
{
    public partial class userMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                lbRegisterORProfile.Text = "Profile";
                lbLoginORLogout.Text = "Logout";

            }
            else
            {
                lbRegisterORProfile.Text = "Register";
                lbLoginORLogout.Text = "Login";
            }
        }

        protected void lbRegisterORProfile_Click(object sender, EventArgs e)
        {
            if (lbRegisterORProfile.Text == "Profile")
            {
                Response.Redirect("Profile.aspx");
            }
            else
            {
                Response.Redirect("Register.aspx");
            }
        }

        protected void lbLoginORLogout_Click(object sender, EventArgs e)
        {
            if (lbLoginORLogout.Text == "Login")
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }
        }
    }
}