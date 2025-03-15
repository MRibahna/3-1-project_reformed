<%@ Page Title="" Language="C#" MasterPageFile="~/User/userMaster.Master" AutoEventWireup="true" CodeBehind="ResumeBuild.aspx.cs" Inherits="OnlineJobPortal.User.ResumeBuild" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section>
        <div class="container pt-50 pb-40">
            <div class="row">
                    <div class="col-12 pb-20">

                  <asp:Label ID="lblmsg" runat="server" Visible="false"></asp:Label>
                    </div>
                    <div class="col-12">
                        <h2 class="contact-title text-xl-center">Build Resume</h2>
                    </div>
                    <div class="col-lg-6 mx-auto">
                         <div class="form-register">  
                        <div class="row">
                            <div class="col-12">
                                    <h5>Personal Information</h5>
                                </div>
                            <div class="col-12">
                                    <div class="form-group">
                                        <label>Full Name</label>
                                             <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control" placeholder="Enter Full Name" required></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Name Must not include any numbers" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" ValidationExpression="^[a-zA-Z\s]+$" ControlToValidate="txtFullName"></asp:RegularExpressionValidator>
                                    </div>
                                </div>

                                <div class="col-12">
                                    <div class="form-group">
                                        <label>Username</label>
                                             <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Enter an Unique UserName" required></asp:TextBox>
                                        
                                       
                                    </div>
                                </div>
                                <div class="col-12">
                                    <div class="form-group">
                                        <label>Address</label>
                                             <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" placeholder="Enter Address" TextMode="MultiLine" required></asp:TextBox>
                                    </div>
                                </div>
                               <div class="col-12">
                                    <div class="form-group">
                                        <label>Contact Number</label>
                                             <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" placeholder="Enter Contact Number" required></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Must be 11 digits" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" ValidationExpression="^[0-9]{11}$" ControlToValidate="txtMobile"></asp:RegularExpressionValidator>

                                    </div>
                                </div>

                               <div class="col-12">
                                    <div class="form-group">
                                        <label>Email</label>
                                             <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Enter Email Address" required TextMode="Email"></asp:TextBox>

                                    </div>
                                </div>
                                
                            <div class="col-12 pt-4">
                                <h5>Education/Resume Information</h5>
                            </div>

                            <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                        <label>SSC result</label>
                                             <asp:TextBox ID="txtSSC" runat="server" CssClass="form-control" placeholder="Enter GPA" required ></asp:TextBox>

                                    </div>
                                </div>

                            <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                        <label>HSC result</label>
                                             <asp:TextBox ID="txtHSC" runat="server" CssClass="form-control" placeholder="Enter GPA" required ></asp:TextBox>

                                    </div>
                                </div>

                            <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                        <label>Graduation result</label>
                                             <asp:TextBox ID="txtGrad" runat="server" CssClass="form-control" placeholder="Enter CGPA" required ></asp:TextBox>

                                    </div>
                                </div>

                            <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                        <label>Post Graduation result</label>
                                             <asp:TextBox ID="txtPg" runat="server" CssClass="form-control" placeholder="Enter CGPA"  ></asp:TextBox>

                                    </div>
                                </div>

                            <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                        <label>PhD result</label>
                                             <asp:TextBox ID="txtPhd" runat="server" CssClass="form-control" placeholder="Enter phd result"  ></asp:TextBox>

                                    </div>
                                </div>

                            <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                        <label>Job Profile/Works On</label>
                                             <asp:TextBox ID="txtWork" runat="server" CssClass="form-control" placeholder="Enter Job Profile" required ></asp:TextBox>

                                    </div>
                                </div>

                            <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                        <label>Experience</label>
                                             <asp:TextBox ID="txtExperience" runat="server" CssClass="form-control" placeholder="Enter Work Experience"  ></asp:TextBox>

                                    </div>
                                </div>

                            <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                        <label>Resume</label>
                                        <asp:FileUpload ID="fuResume" runat="server" CssClass="form-control pt-2" ToolTip=".doc, .docx, .pdf extension only" /> 
                                    </div>
                                </div>
                            
                                
                               
                            <div class="form-group mt-3">
              <asp:Button ID="btnUpdate" runat="server" Text="Update" Cssclass="button button-contactForm boxed-btn" OnClick="btnUpdate_Click" />
                                <br /><br />
                                
                            </div>
                            
                            </div>
                        </div>
                    </div>
                </div>

        </div>
        
    </section>

</asp:Content>
