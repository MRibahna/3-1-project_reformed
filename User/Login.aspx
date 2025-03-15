<%@ Page Title="" Language="C#" MasterPageFile="~/User/userMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OnlineJobPortal.User.Login" %>
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
                        <h2 class="contact-title text-xl-center">Sign In</h2>
                    </div>
                    <div class="col-lg-6 mx-auto">
                         <div class="form-register">  
                        <div class="row">
                           
                                <div class="col-12">
                                    <div class="form-group">
                                        <label>Username</label>
                                             <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Enter Your UserName" required></asp:TextBox>
                                        
                                       
                                    </div>
                                </div>
                                <div class="col-12">
                                    <div class="form-group">
                                        <label>Password</label>
                                             <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Enter Password" TextMode="Password" required></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-12">
                                    <div class="form-group">
                                        <label>Login Type</label>
                                        <asp:DropDownList ID="ddlLoginType" runat="server" CssClass="form-control w-100">
                                            <asp:ListItem Value="0">Select Login Type</asp:ListItem>
                                            <asp:ListItem>Admin</asp:ListItem>
                                            <asp:ListItem>User</asp:ListItem>


                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="UserType is required" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="small" InitialValue="0" ControlToValidate="ddlLoginType">
                                            
                                        </asp:RequiredFieldValidator>
                                       
                                    </div>
                                </div>

                                <br />
                            <div class="form-group mt-3">
              <asp:Button ID="btnLogin" runat="server" Text="Login" Cssclass="button button-contactForm boxed-btn"  OnClick="btnLogin_Click" />
                                <br /><br />
                                <span class="clicklink">
                                    <a href="../User/Register.aspx">New User?? Click here!! </a>

                                </span>
                            </div>
                            
                            </div>
                        </div>
                    </div>
                </div>

        </div>
        
    </section>

</asp:Content>
