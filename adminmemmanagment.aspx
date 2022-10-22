<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="adminmemmanagment.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <script>
    $(document).ready(function (){
        $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
    });
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
        <%--<a href="ourweb.aspx">HOME</a><br></br>--%>
        <div class="row">
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>member details</h4 >
                                </center>
                            </div>
                        </div>
                         <div class="row">
                            <div class="col">
                                <center>
                                      <img width="100px" src="imgs/images.png" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                 
                                    <hr>
 
                            </div>
                        </div>
                        <div class="row">
                               <div class="col-md-3">
                                 
                                <label >Mem id</label>
                                <div class="form-group">
                                     <div class="input-group">
                                      <asp:TextBox cssclass="form-control"  ID="TextBox1" runat="server" placeholder="Member id" >
                                           </asp:TextBox>
                                         <asp:LinkButton class="btn btn-primary" ID="LinkButton4" runat="server" OnClick="GoClick"><i class="fas fa-check-circle"></i></asp:LinkButton> 
                                         
                                    </div>
                                    </div>
                                 </div>    
                               <div class="col-md-3">
                                 <label >Full name</label>
                                 <div class="form-group">
                                     
                                     <asp:TextBox cssclass="form-control"  ID="TextBox2" runat="server" placeholder="Full name" ReadOnly="True">

                                     </asp:TextBox>
                                 </div>
                               </div>
                             <div class="col-md-6">
                                 
                                <label >Account status</label>
                                <div class="form-group">
                                     <div class="input-group">
                                     
                                        <asp:TextBox cssclass="form-control"  ID="TextBox7" runat="server" placeholder=" status"
                                             ReadOnly="True">

                                        </asp:TextBox>
                                         <asp:LinkButton ID="LinkButton1" class="btn btn-success mr-1" runat="server" OnClick="activeClick"> 
                                              <i class="fa-solid fa-circle-check"></i>
                                         </asp:LinkButton>
                                         <asp:LinkButton ID="LinkButton2" class="btn btn-warning mr-1" runat="server" OnClick="pendingClick"> 
                                              <i class="fa-solid fa-circle-pause"></i>
                                         </asp:LinkButton>
                                         <asp:LinkButton ID="LinkButton3" class="btn btn-danger mr-1" runat="server" OnClick="deactiveClick"> 
                                              <i class="fa-solid fa-circle-xmark"></i>
                                         </asp:LinkButton>
                                         
                                     </div>
                                    </div>
                                 </div>    
                            
                        </div>
                             <div class="row">
                           
                               <div class="col-md-4">
                                 <label >DOB</label>
                                 <div class="form-group">
                                     
                                     <asp:TextBox cssclass="form-control"  ID="TextBox3" runat="server" placeholder="date" 
                                         ReadOnly="True" TextMode="Date">

                                     </asp:TextBox>
                                 </div>
                               </div>
                                  <div class="col-md-4">
                                 <label >Contact No</label>
                                 <div class="form-group">
                                     
                                     <asp:TextBox cssclass="form-control"  ID="TextBox8" runat="server" placeholder="Contact No" 
                                         ReadOnly="True" TextMode="Phone">

                                     </asp:TextBox>
                                 </div>
                               </div>
                                 <div class="col-md-4">
                                 <label >Email Id</label>
                                 <div class="form-group">
                                     
                                     <asp:TextBox cssclass="form-control"  ID="TextBox4" runat="server" placeholder="Email" 
                                         ReadOnly="True" TextMode="Email">

                                     </asp:TextBox>
                                 </div>
                               </div>
                               
                        </div>

                             <div class="row">
                           
                               <div class="col-md-3">
                                 <label >State</label>
                                 <div class="form-group">
                                     
                                     <asp:TextBox cssclass="form-control"  ID="TextBox9" runat="server" placeholder="state" 
                                         ReadOnly="True">

                                     </asp:TextBox>
                                 </div>
                               </div>
                                  <div class="col-md-4">
                                 <label >City</label>
                                 <div class="form-group">
                                     
                                     <asp:TextBox cssclass="form-control"  ID="TextBox10" runat="server" placeholder="City" 
                                         ReadOnly="True">
                                    </asp:TextBox>
                                 </div>
                               </div>
                                 <div class="col-md-5">
                                 <label >Pincode</label>
                                 <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox11" runat="server" placeholder="Pin Code" ReadOnly="True"></asp:TextBox>
                                     </div>
                                     </div>
                                 </div>
                                <div class="row">
                                <div class="col-12">
                                 <label >full postal adress</label>
                                    <div class="form-group"> 
                                     <asp:TextBox cssclass="form-control"  ID="TextBox5" runat="server" 
                                         placeholder=" full postal adress"
                                           TextMode="MultiLine" ReadOnly="True"> </asp:TextBox>
                                 </div>
                               </div>
                     
                        </div>
                           
                                    <div class="row"> 
                                       <div class="col-10 mx-Auto">
                                           <asp:Button ID="Button2" runat="server" Class="btn btn-lg btn-block btn-danger" 
                                               Text="Delete user Permanenetly" OnClick="deleteClick"   />
                                        </div>
                                    </div>
                             
                                   </div> 
                                     
                                </div>
            
           
           </div>
    
            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">
                       
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>member list</h4 >
                                </center>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col">
                                 
                                    <hr>
 
                            </div>
                        </div>
                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TlibrarydbConnectionString2 %>" SelectCommand="SELECT * FROM [member_master_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                 
                            <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="member_id" DataSourceID="SqlDataSource1">
                                <Columns>
                                    <asp:BoundField DataField="member_id" HeaderText="ID" SortExpression="member_id" ReadOnly="True" />
                                    <asp:BoundField DataField="full_name" HeaderText="Name" SortExpression="full_name" />
                                    <asp:BoundField DataField="account_status" HeaderText="ACCOUNT_STATUS" SortExpression="account_status" />
                                    <asp:BoundField DataField="contact_no" HeaderText="Contact_no" SortExpression="contact_no" />
                                    <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                                    <asp:BoundField DataField="state" HeaderText="State" SortExpression="state" />
                                    <asp:BoundField DataField="city" HeaderText="City" SortExpression="city" />
                                </Columns>
                                </asp:GridView>
                                     
 
                            </div>
                        </div>
                        
                          </div>
                  
                    </div>
                
            </div>
       </div>
    </div>

</asp:Content>

