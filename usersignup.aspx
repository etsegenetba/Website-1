<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="usersignup.aspx.cs" Inherits="Default3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <%--<a href="ourweb.aspx">HOME</a><br></br>--%>
     <div class="container">
         
        <div class="row">
            <div class="col-md-12"  mx-auto>
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" src="imgs/images%20(13).jpg" />

                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>User Registeration</h4 >

                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                 
                                    <hr>
 
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                 
                                <label >Full Name</label>
                                <div class="form-group">
                                     
                                     <asp:TextBox cssclass="form-control"  ID="TextBox1" runat="server" placeholder="fullname">

                                     </asp:TextBox>
                                 </div>    
 
                            </div>
                               <div class="col-md-6">
                                 <label >Date</label>
                                    
                                 <div class="form-group"> 
                                     <asp:TextBox cssclass="form-control"  ID="TextBox2" runat="server" placeholder="date" TextMode="Date">
                                       
                                     </asp:TextBox>
                                 </div>
                               </div>
                        </div>
                         <div class="row">
                            <div class="col-md-6">
                                 
                                 <label >Contact no</label>
                                 <div class="form-group">
                                     
                                       <asp:TextBox cssclass="form-control"  ID="TextBox3" runat="server" placeholder="contact no"
                                         TextMode="Phone">

                                        </asp:TextBox>
                                   </div>    
 
                                 </div>
                           
                            
                               <div class="col-md-6">
                                 <label >Email Id</label>
                                 <div class="form-group">
                                     
                                     <asp:TextBox cssclass="form-control"  ID="TextBox4" runat="server" placeholder="Email" 
                                         TextMode="Email">

                                     </asp:TextBox>
                                 </div>
                              </div>
                            </div>
                             <div class="row">
                                 <div class="col-md-4">  
                                   <label >State</label>
                                   <div class="form-group">
                                       <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                                           <asp:ListItem Text="AddisAbaba" Value=""/>
                                           <asp:ListItem Text="Semera" Value=""/>
                                           <asp:ListItem Text="Bahirdar" Value=""/>
                                           <asp:ListItem Text=" Asosa" Value=""/>
                                           <asp:ListItem Text="Diredawa" Value=""/>
                                           <asp:ListItem Text="Gambela" Value=""/>
                                           <asp:ListItem Text="Harar" Value=""/>
                                           <asp:ListItem Text="Hawassa" Value=""/>
                                           <asp:ListItem Text="Jijiga" Value=""/>
                                           <asp:ListItem Text="Bonga" Value=""/>
                                           <asp:ListItem Text="Mekelle" Value=""/>
                                            
                                        </asp:DropDownList>
                                    </div>  
                                   </div>  
                                  <div class="col-md-4">
                                    <label >City</label>
                                    <div class="form-group">
                                       <asp:TextBox class="form-control"  ID="TextBox6" runat="server" placeholder="city" >
                                       </asp:TextBox>
                                     </div>
                                   </div>
                                       
                                   <div class="col-md-4">
                                     <label >Pincode</label>
                                     <div class="form-group">
                                        <asp:TextBox cssclass="form-control"  ID="TextBox7" runat="server" placeholder="pincode" 
                                         TextMode="Number">
                                        </asp:TextBox>
                                     </div>
                                   </div>
                        </div>
                         <div class="row">
                            <div class="col ">
                                 
                                 <label >Full Adress</label>
                                 <div class="form-group">
                                     
                                     <asp:TextBox cssclass="form-control"  ID="TextBox5" runat="server" placeholder="full adress"
                                           Rows="2" TextMode="MultiLine" OnTextChanged="TextBox5_TextChanged">

                                     </asp:TextBox>
                                 </div>    
 
                              </div>
                          </div>
                       <div class="row">
                          <div class="col">
                                <center>
                                    <span class="badge badge-pill  badge-info">Login credentials</span>
                                 </center>
                          </div>    
                       </div>
                             <div class="row">
                               <div class="col-md-6">
                                 
                                  <label >UserId</label>
                                   <div class="form-group">
                                     
                                     <asp:TextBox class="form-control"  ID="TextBox8" runat="server" placeholder="UserId" >

                                      </asp:TextBox>
                                   </div>    
 
                                 </div>
                           
                            
                                 <div class="col-md-6">
                                    <label >Password</label>
                                    <div class="form-group">
                                     
                                       <asp:TextBox class="form-control"  ID="TextBox9" runat="server" placeholder="password"  TextMode="Password">

                                       </asp:TextBox>
                                     </div>
                                  </div>
                                </div>
 
                         <div class="row"> 
                             <div class="col">
                               <div class="form-group">
                                 <asp:Button ID="Button1" class="btn btn-success btn-block btn-lg" runat="server" Text="signup" OnClick="signupClick"/> 
                               </div>
                            </div>
                        </div>
               
            </div>

           
        </div>
   

</asp:Content>

