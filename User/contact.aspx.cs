using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineJobPortal.User
{
    public partial class contact : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        string str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            try
            {
                con = new SqlConnection(str);
                string query = @"Insert into contact values (@name, @email, @subject, @message)";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", name.Value.Trim());
                cmd.Parameters.AddWithValue("@email", email.Value.Trim());
                cmd.Parameters.AddWithValue("@subject", subject.Value.Trim());
                cmd.Parameters.AddWithValue("@message", message.Value.Trim());
                con.Open();
                int r = cmd.ExecuteNonQuery();
                if (r == 1)
                {
                    lblmsg.Visible = true;
                    lblmsg.Text = "Thanks for reaching out, we will look into that!!";
                    lblmsg.CssClass = "alert alert-success";
                    clear();
                }
                else
                {
                    lblmsg.Visible = true;
                    lblmsg.Text = "Oops! something went wrong, please try again later!!";
                    lblmsg.CssClass = "alert alert-danger";
                }
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('" + ex.Message + "')</script>");


            }
            finally
            {
                con.Close();
            }

        }

        private void clear()
        {
            
            name.Value=string.Empty;
            email.Value=string.Empty;
            subject.Value=string.Empty;
            message.Value = string.Empty;
        }
    }
}