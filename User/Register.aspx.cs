using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace OnlineJobPortal.User
{
    public partial class Register : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        string str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try //start from here... good night
            {
                con = new SqlConnection(str);
                string query = @"Insert into User_info (userName, password, fullName, addresss, Contact, Email) values 
                                                        (@userName, @password, @fullName, @addresss, @Contact, @Email)";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@userName", txtUsername.Text.Trim());
                cmd.Parameters.AddWithValue("@password", txtConfirmPassword.Text.Trim());
                cmd.Parameters.AddWithValue("@fullName", txtFullName.Text.Trim());
                cmd.Parameters.AddWithValue("@addresss", txtAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@Contact", txtMobile.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());

                con.Open();
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    lblmsg.Visible = true;
                    lblmsg.Text = "Register Successful!!";
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
            catch(SqlException ex)
            {
                if (ex.Message.Contains("Violation of UNIQUE KEY constraint"))      //to make sure if its a unique username or not
                {
                    lblmsg.Visible = true;
                    lblmsg.Text = "<b>" + txtUsername.Text.Trim() + "<b> this username already exixts, try something different. ";
                    lblmsg.CssClass = "alert alert-success";
                }
                else { 
                    Response.Write("<script>alert('" + ex.Message + "')</script>"); 
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
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
            txtFullName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtMobile.Text = string.Empty;
            txtEmail.Text = string.Empty;
            //throw new NotImplementedException();
        }
    }
}