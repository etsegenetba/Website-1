<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="adminlogin.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container"> 
        <div class="row">
            <%--<a href="ourweb.aspx"> HOME</a><br></br>--%>
            <div class="col-md-5" mx-auto>
                 
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="imgs/images%20(4).jpg" /> 

                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Admin Login</h3>

                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                 
                                    <hr>
 
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <label >Admin Id</label>
                                 <div class="form-group">
                                     
                                     <asp:TextBox cssclass="form-control"  ID="TextBox1" runat="server" placeholder="adminid">

                                     </asp:TextBox>
                                 </div>
                                <label >Password</label>
                                 <div class="form-group">
                                     
                                     <asp:TextBox cssclass="form-control"  ID="TextBox2" runat="server" placeholder="password" TextMode="Password"></asp:TextBox>
                                 </div>
                                 
                                  <div class="form-group">
                           <asp:Button class="btn btn-primary btn-block btn-lg " ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
                        </div>
                        
                            </div>
                        </div>
                    </div>
                </div>
                
            </div>
        </div>
    </div>
</asp:Content>

