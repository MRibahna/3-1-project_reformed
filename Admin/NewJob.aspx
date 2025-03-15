<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="NewJob.aspx.cs" Inherits="OnlineJobPortal.Admin.newJobs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="background-image: url('../Image/bg.jpg'); width:100%; height: 720px; background-repeat: no-repeat; background-size:cover ; background-attachment: fixed;">
        <div class="container pt-4 pb-4">
            
            <div class="btn-toolbar justify-content-between mb-3">
                <div class="btn-group">
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </div>
                <div class="input-group h-25">
                    <asp:HyperLink ID="linkBack" runat="server" NavigateUrl="~/Admin/JobList.aspx" CssClass="btn btn-secondary" Visible="false">
                        < Back </asp:HyperLink>
                </div>
            </div>
        
        <h3 class="text-center"><%Response.Write(Session["title"]); %></h3>
        <div class="row mr-lg-5 ml-lg-5 pb-3">
            <div class="col-md-6 pt-3">
                <label for="txtJobTitle" style = "font-weight:600 ">Job Title</label>
                <asp:TextBox ID="txtJobTitle" runat="server" CssClass="form-control" placeHolder="Ex. Web Developer, App Developer" required></asp:TextBox>
            </div>
             <div class="col-md-6 pt-3">
                <label for="txtNoofPost" style = "font-weight:600 ">Number of posts</label>
                <asp:TextBox ID="txtNoofPost" runat="server" CssClass="form-control" placeHolder="Enter Number of Vacant Positions" required TextMode="Number"></asp:TextBox>
            </div>
            
        </div>

            <div class="row mr-lg-5 ml-lg-5 pb-3">
            <div class="col-md-12 pt-3">
                <label for="txtDescription" style = "font-weight:600 ">Description</label>
                <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" placeHolder="Enter Job Description" TextMode="MultiLine" required></asp:TextBox>
            </div>
            
            
        </div>

            <div class="row mr-lg-5 ml-lg-5 pb-3">
            <div class="col-md-6 pt-3">
                <label for="txtQualification" style = "font-weight:600 ">Required Qualification/Education </label>
                <asp:TextBox ID="txtQualification" required runat="server" CssClass="form-control" placeHolder="Ex. BSC, BSC in Engineering, MBA"></asp:TextBox>
            </div>
             <div class="col-md-6 pt-3">
                <label for="txtExperience" style = "font-weight:600 ">Required Experience</label>
                <asp:TextBox ID="txtExperience" required runat="server" CssClass="form-control" placeHolder="Ex. 2 Years, 1 year" ></asp:TextBox>
            </div>
            
        </div>

            <div class="row mr-lg-5 ml-lg-5 pb-3">
            <div class="col-md-6 pt-3">
                <label for="txtSpecialization" style = "font-weight:600 ">Required Specialization</label>
                <asp:TextBox ID="txtSpecialization" required runat="server" CssClass="form-control" placeHolder="Enter Specialization" TextMode="MultiLine"></asp:TextBox>
            </div>
             <div class="col-md-6 pt-3">
                <label for="txtDeadline" style = "font-weight:600 ">Application Deadline</label>
                <asp:TextBox ID="txtDeadline" required runat="server" CssClass="form-control" placeHolder="Enter Application Deadline" TextMode="Date" ></asp:TextBox>
            </div>
            
        </div>

            <div class="row mr-lg-5 ml-lg-5 pb-3">
            <div class="col-md-6 pt-3">
                <label for="txtSalary" style = "font-weight:600 ">Salary</label>
                <asp:TextBox ID="txtSalary" required runat="server" CssClass="form-control" placeHolder="Enter Monthly Salary or Annual Salary" ></asp:TextBox>
            </div>
             <div class="col-md-6 pt-3">
                <label for="ddlJobType" style = "font-weight:600 ">Job Type</label>
                 <asp:DropDownList ID="ddlJobType" runat="server" CssClass="form-control">
                     <asp:ListItem Value="0">Select Job Type</asp:ListItem>
                     <asp:ListItem>Full Time</asp:ListItem>
                     <asp:ListItem>Part Time</asp:ListItem>
                     <asp:ListItem>Remote</asp:ListItem>
                     <asp:ListItem>Freelance</asp:ListItem>
                 </asp:DropDownList>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Jobtype is required" ForeColor="Red" ControlToValidate="ddlJobType" InitialValue="0" Display="Dynamic" SetFocusOnError="true">

                 </asp:RequiredFieldValidator>
            </div>
            
        </div>

            <div class="row mr-lg-5 ml-lg-5 pb-3">
            <div class="col-md-6 pt-3">
                <label for="txtCompany" style = "font-weight:600 ">Company/Organization Name</label>
                <asp:TextBox ID="txtCompany" required runat="server" CssClass="form-control" placeHolder="Enter Company/Organization Name" ></asp:TextBox>
            </div>
             <div class="col-md-6 pt-3">
                <label for="ddlJobType" style = "font-weight:600 ">Company/Organization logo</label>
                 <asp:FileUpload ID="fuCompanyLogo" runat="server" CssClass="form-control" ToolTip=".jpg, .jpeg, .png extension only" />
                 
            </div>
            
        </div>

            <div class="row mr-lg-5 ml-lg-5 pb-3">
            <div class="col-md-6 pt-3">
                <label for="txtWebsite" style = "font-weight:600 ">Website </label>
                <asp:TextBox ID="txtWebsite" runat="server" CssClass="form-control" placeHolder="Enter Website" TextMode="Url"></asp:TextBox>
            </div>
             <div class="col-md-6 pt-3">
                <label for="txtEmail" style = "font-weight:600 ">Official Email of the Company/Organization</label>
                <asp:TextBox ID="txtEmail"  runat="server" CssClass="form-control" placeHolder="Enter Email" TextMode="Email" ></asp:TextBox>
            </div>
            
        </div>

            <div class="row mr-lg-5 ml-lg-5 pb-3">
            <div class="col-md-12 pt-3">
                <label for="txtAddress" style = "font-weight:600 ">Address</label>
                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" placeHolder="Enter Address" TextMode="MultiLine" required></asp:TextBox>
            </div>
            
            
        </div>

            <div class="row mr-lg-5 ml-lg-5 mb-3 pt-4">
                <div class="'col-md-3 col-md-offset-2 mb-3">
                    <asp:Button ID="btnAdd" runat="server" Text="Add Job" CssClass="btn btn-primary btn-block" BackColor="#7800cf" OnClick="btnAdd_Click" />

                </div>
            
        </div>

      </div>

    </div>

</asp:Content>
