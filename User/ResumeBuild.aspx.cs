using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

namespace OnlineJobPortal.User
{
    public partial class ResumeBuild : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader sdr;
        string str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        string query;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("login.aspx");
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    showUserInfo();
                }
                else
                {
                    Response.Redirect("login.aspx");
                }
            }
        }

        private void showUserInfo()
        {
            try
            {
                con = new SqlConnection(str);
                string query = "Select * from User_info where userID=@userID";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@userID", Request.QueryString["id"]);
                con.Open();
                sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    if (sdr.Read())
                    {
                        txtUsername.Text = sdr["userName"].ToString();
                        txtFullName.Text = sdr["fullName"].ToString();
                        txtEmail.Text = sdr["Email"].ToString();
                        txtMobile.Text = sdr["Contact"].ToString();
                        txtSSC.Text = sdr["ssc_result"].ToString();
                        txtHSC.Text = sdr["hsc_Result"].ToString();
                        txtGrad.Text = sdr["CGPAgrad"].ToString();
                        txtPg.Text = sdr["CGPApostgrad"].ToString();
                        txtPhd.Text = sdr["phd"].ToString();
                        txtWork.Text = sdr["worksOn"].ToString();
                        txtExperience.Text = sdr["experience"].ToString();
                        txtAddress.Text = sdr["addresss"].ToString();

                    }
                }
                else
                {
                    lblmsg.Visible = true;
                    lblmsg.Text = "User not found!!";
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["id"] != null)
                {
                    string concatQuery = string.Empty;
                    string filePath = string.Empty;
                    //bool isValidToExecute = false;
                    bool isValid = false;
                    con = new SqlConnection(str);
                    if (fuResume.HasFile)
                    {
                        if (Utils.IsValidExtensionResume(fuResume.FileName))
                        {
                            concatQuery = "resuemee=@resume";
                            isValid = true;
                        }
                        else
                        {
                            //concatQuery = string.Empty;
                            lblmsg.Visible = true;
                            lblmsg.Text = "User not found!!";
                            lblmsg.CssClass = "alert alert-danger";
                        }
                    }
                    else
                    {
                        concatQuery = string.Empty;
                    }

                    query = @"UPDATE User_info
                                                SET userName = @userName, 
                                                fullName = @fullName, 
                                                Email = @Email, 
                                                Contact = @Contact,
                                                ssc_result = @ssc_result, 
                                                hsc_Result = @hsc_Result, 
                                                CGPAgrad = @CGPAgrad, 
                                                CGPApostgrad = @CGPApostgrad, 
                                                phd = @phd, 
                                                worksOn = @worksOn,
                                                experience = @experience, 
                                                " + concatQuery + 
                                                ", addresss = @addresss WHERE userID = @userID";

                        //Update User_info set userName = @userName, fullName = @fullName, Email = @Email, Contact = @Contact,
                        //    ssc_result = @ssc_result, hsc_Result = @hsc_Result, CGPAgrad = @CGPAgrad, CGPApostgrad = @CGPApostgrad, phd = @phd, worksOn = @worksOn,
                        //    experience = @experience," + concatQuery + ", addresss = @addresss where userID = @userID

                    Console.WriteLine(query);

                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@userName",txtUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@fullName", txtFullName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Contact", txtMobile.Text.Trim());
                    cmd.Parameters.AddWithValue("@ssc_result", txtSSC.Text.Trim());
                    cmd.Parameters.AddWithValue("@hsc_Result", txtHSC.Text.Trim());
                    cmd.Parameters.AddWithValue("@CGPAgrad", txtGrad.Text.Trim());
                    cmd.Parameters.AddWithValue("@CGPApostgrad", txtPg.Text.Trim());
                    cmd.Parameters.AddWithValue("@phd", txtPhd.Text.Trim());
                    cmd.Parameters.AddWithValue("@worksOn", txtWork.Text.Trim());
                    cmd.Parameters.AddWithValue("@experience", txtExperience.Text.Trim());
                    cmd.Parameters.AddWithValue("@addresss", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@userID", Request.QueryString["id"]);
                    if (isValid)
                    {
                        Guid obj = Guid.NewGuid();
                        filePath = "Resumes/ " + obj.ToString() + fuResume.FileName;
                        fuResume.PostedFile.SaveAs(Server.MapPath("~/Resumes/") + obj.ToString() + fuResume.FileName);

                        cmd.Parameters.AddWithValue("@resume", filePath);
                        //isValidToExecute = true;
                    }
                    else
                    {
                        isValid = true;
                    }
                    if (isValid)
                    {
                        con.Open();
                        int r = cmd.ExecuteNonQuery();
                        if (r > 0)
                        {
                            lblmsg.Visible = true;
                            lblmsg.Text = "Resume Details Updated Successfully!!";
                            lblmsg.CssClass = "alert alert-success";
                        }
                        else
                        {
                            lblmsg.Visible = true;
                            lblmsg.Text = "Cannot Update Records. Please try again after sometimes.";
                            lblmsg.CssClass = "alert alert-danger";
                        }
                    }
                }
                else
                {
                    lblmsg.Visible = true;
                    lblmsg.Text = "Cannot Update Records. Please try <b>Relogin<b>!";
                    lblmsg.CssClass = "alert alert-danger";
                }
            }
            catch (SqlException ex)
            {

                if (ex.Message.Contains("Violation of UNIQUE KEY constraint"))      
                {
                    lblmsg.Visible = true;
                    lblmsg.Text = "<b>" + txtUsername.Text.Trim() + "<b> this username already exixts, try something different. ";
                    lblmsg.CssClass = "alert alert-success";
                }
                else
                {
                    Response.Write("<script>alert('" + ex.Message + "')</script>");
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
            finally
            { 
                con.Close(); 
            }


        }
    }
}