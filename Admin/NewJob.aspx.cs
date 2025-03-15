using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineJobPortal.Admin
{
    public partial class newJobs : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        string str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        string query;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("~/User/Login.aspx");
            }
            Session["title"] = "Add Job";
            if (!IsPostBack)
            {
                fillData();
            }
        }

        private void fillData()
        {
            if (Request.QueryString["id"] != null)
            {
                con = new SqlConnection(str);
                query = "Select * from Jobs where jobID = ' " + Request.QueryString["id"] + "' ";
                cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows) 
                { 
                    while(sdr.Read())
                    {
                        txtJobTitle.Text = sdr["Title"].ToString();
                        txtNoofPost.Text = sdr["NoOfPost"].ToString();
                        txtDescription.Text = sdr["Descriptionn"].ToString();
                        txtQualification.Text = sdr["Qualification"].ToString();
                        txtExperience.Text = sdr["Experience"].ToString();
                        txtSpecialization.Text = sdr["Specialization"].ToString();
                        txtDeadline.Text = Convert.ToDateTime( sdr["Deadline"]).ToString("yyyy-MM-dd");
                        txtSalary.Text = sdr["Salary"].ToString(); 
                        ddlJobType.SelectedValue = sdr["jobType"].ToString();
                        txtCompany.Text = sdr["CompanyName"].ToString();
                        txtEmail.Text = sdr["Email"].ToString();
                        txtWebsite.Text = sdr["Website"].ToString();
                        txtAddress.Text = sdr["Addresss"].ToString();

                        btnAdd.Text = "Update";

                        linkBack.Visible = true;
                        Session["title"] = "Edit Job";

                    }
                }
                else
                {
                    lblMsg.Text = "Job not Found!!";
                    lblMsg.CssClass = "alert alert-danger";
                }

                sdr.Close();
                con.Close();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string type, concatQuery, imagePath = string.Empty;
                bool isValidToExecute = false;
                con=new SqlConnection(str);

                if(Request.QueryString["id"]!= null)
                {
                    if (fuCompanyLogo.HasFile)
                    {
                        if (Utils.IsValidExtension(fuCompanyLogo.FileName))
                        {
                            concatQuery = "CompanyImage = @CompanyImage,";


                        }
                        else
                        {
                            concatQuery = string.Empty;

                        }
                    }
                    else
                    {
                        concatQuery= string.Empty;
                    }
                    query = @"Update Jobs set Title=@Title, NoOfPost=@NoOfPost, Descriptionn=@Descriptionn,
                            Qualification=@Qualification,Experience=@Experience,Specialization=@Specialization,
                            Deadline=@Deadline,Salary=@Salary,jobType=@jobType,CompanyName=@CompanyName, "+ concatQuery+@"
                            Email=@Email, Website=@Website,Addresss=@Addresss where jobID = @id";
                    type = "Updated";
                    
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Title", txtJobTitle.Text.Trim());
                    cmd.Parameters.AddWithValue("@NoOfPost", txtNoofPost.Text.Trim());
                    cmd.Parameters.AddWithValue("@Descriptionn", txtDescription.Text.Trim());
                    cmd.Parameters.AddWithValue("@Qualification", txtQualification.Text.Trim());
                    cmd.Parameters.AddWithValue("@Experience", txtExperience.Text.Trim());
                    cmd.Parameters.AddWithValue("@Specialization", txtSpecialization.Text.Trim());
                    cmd.Parameters.AddWithValue("@Deadline", txtDeadline.Text.Trim());
                    cmd.Parameters.AddWithValue("@Salary", txtSalary.Text.Trim());
                    cmd.Parameters.AddWithValue("@jobType", ddlJobType.SelectedValue);
                    cmd.Parameters.AddWithValue("@CompanyName", txtCompany.Text.Trim());
                    //cmd.Parameters.AddWithValue("@CompanyImage", .Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Website", txtWebsite.Text.Trim());
                    cmd.Parameters.AddWithValue("@Addresss", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@id", Request.QueryString["id"].ToString());

                    if (fuCompanyLogo.HasFile)
                    {
                        if (Utils.IsValidExtension(fuCompanyLogo.FileName))
                        {
                            Guid obj = Guid.NewGuid();
                            imagePath = "Images/" + obj.ToString() + fuCompanyLogo.FileName;
                            fuCompanyLogo.PostedFile.SaveAs(Server.MapPath("~/Images/") + obj.ToString() + fuCompanyLogo.FileName);

                            cmd.Parameters.AddWithValue("@CompanyImage", imagePath);
                            isValidToExecute = true;
                        }
                        else
                        {
                            lblMsg.Text = "File should be in .jpg, .jpeg or in .ong format.";
                            lblMsg.CssClass = "alert alert-danger";
                        }
                    }
                    else
                    {
                        isValidToExecute = true;
                    }

                }
                else
                {
                    query = @"Insert into Jobs values (@Title, @NoOfPost, @Descriptionn,@Qualification,@Experience,@Specialization,
                            @Deadline,@Salary,@jobType,@CompanyName,@CompanyImage,@Email, @Website,@Addresss,@CreateDate)";
                    type = "Saved";
                    DateTime time = DateTime.Now;
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Title", txtJobTitle.Text.Trim());
                    cmd.Parameters.AddWithValue("@NoOfPost", txtNoofPost.Text.Trim());
                    cmd.Parameters.AddWithValue("@Descriptionn", txtDescription.Text.Trim());
                    cmd.Parameters.AddWithValue("@Qualification", txtQualification.Text.Trim());
                    cmd.Parameters.AddWithValue("@Experience", txtExperience.Text.Trim());
                    cmd.Parameters.AddWithValue("@Specialization", txtSpecialization.Text.Trim());
                    cmd.Parameters.AddWithValue("@Deadline", txtDeadline.Text.Trim());
                    cmd.Parameters.AddWithValue("@Salary", txtSalary.Text.Trim());
                    cmd.Parameters.AddWithValue("@jobType", ddlJobType.SelectedValue);
                    cmd.Parameters.AddWithValue("@CompanyName", txtCompany.Text.Trim());
                    //cmd.Parameters.AddWithValue("@CompanyImage", .Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Website", txtWebsite.Text.Trim());
                    cmd.Parameters.AddWithValue("@Addresss", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@CreateDate", time.ToString("yyyy-MM-dd HH:mm:ss"));

                    if (fuCompanyLogo.HasFile)
                    {
                        if (Utils.IsValidExtension(fuCompanyLogo.FileName))
                        {
                            Guid obj = Guid.NewGuid();
                            imagePath = "Images/" + obj.ToString() + fuCompanyLogo.FileName;
                            fuCompanyLogo.PostedFile.SaveAs(Server.MapPath("~/Images/") + obj.ToString() + fuCompanyLogo.FileName);

                            cmd.Parameters.AddWithValue("@CompanyImage", imagePath);
                            isValidToExecute = true;
                        }
                        else
                        {
                            lblMsg.Text = "File should be in .jpg, .jpeg or in .ong format.";
                            lblMsg.CssClass = "alert alert-danger";
                        }
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@CompanyImage", imagePath);
                        isValidToExecute = true;
                    }

                    
                }
                if (isValidToExecute)
                {
                    con.Open();
                    int res = cmd.ExecuteNonQuery();
                    if (res > 0)
                    {
                        lblMsg.Text = "Job " + type + " Successfully!!";
                        lblMsg.CssClass = "alert alert-success";
                        Clear();
                    }
                    else
                    {
                        lblMsg.Text = "Cannot " + type + " the records, Please try again after sometime.";
                        lblMsg.CssClass = "alert alert-danger";

                    }
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

        private void Clear()
        {
            txtJobTitle.Text = string.Empty;
            txtNoofPost.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtQualification.Text = string.Empty;
            txtExperience.Text = string.Empty;
            txtSpecialization.Text = string.Empty;
            txtDeadline.Text = string.Empty;
            txtSalary.Text = string.Empty;
            ddlJobType.ClearSelection();
            txtCompany.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtWebsite.Text = string.Empty;
            txtAddress.Text = string.Empty;

        }

        //private bool IsValidExtension(string fileName)
        //{

        //    bool isValid = false;
        //    string[] fileExtension = { ".jpg", ".jpeg", ".png" };
        //    for (int i = 0; i <= fileExtension.Length - 1; i++)
        //    {
        //        if (fileName.Contains(fileExtension[i]))
        //        {
        //            isValid = true;
        //            break;
        //        }
        //    }
        //    return isValid;
        //}
    }
}