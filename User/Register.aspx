<%@ Page Title="" Language="C#" MasterPageFile="~/User/userMaster.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="OnlineJobPortal.User.Register" %>
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
                        <h2 class="contact-title text-xl-center">Sign Up</h2>
                    </div>
                    <div class="col-lg-6 mx-auto">
                         <div class="form-register">  
                        <div class="row">
                            <div class="col-12">
                                    <h5>Login Credentials</h5>
                                </div>
                                <div class="col-12">
                                    <div class="form-group">
                                        <label>Username</label>
                                             <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Enter an Unique UserName" required></asp:TextBox>
                                        
                                       
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label>Password</label>
                                             <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Enter Password" TextMode="Password" required></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label>Confirm Password</label>
                                             <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" placeholder="Confirm Password" TextMode="Password" required></asp:TextBox>
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Mismatched Password! Please Reconfirm." ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small"></asp:CompareValidator>
                                    </div>
                                </div>
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
                            <div class="form-group mt-3">
              <asp:Button ID="btnRegister" runat="server" Text="Register" Cssclass="button button-contactForm boxed-btn" OnClick="btnRegister_Click" />
                                <br /><br />
                                <span class="clicklink">
                                    <a href="../User/Login.aspx">Already Registered?? Click here!! </a>

                                </span>
                            </div>
                            
                            </div>
                        </div>
                    </div>
                </div>

        </div>
        
    </section>

</asp:Content>
