<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="adminauthormanagement.aspx.cs" Inherits="_Default" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script>
    $(document).ready(function (){
        $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
    });
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <%--<a href="ourweb.aspx">HOME</a><br></br>--%>
        <div class="row">
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Author Details</h4 >
                                </center>
                            </div>
                        </div>
                         <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" src="imgs/images%20(4).jpg" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                 
                                    <hr>
 
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                 
                                <label >Author id</label>
                                <div class="form-group">
                                     <div class="input-group">
                                     
                                        <asp:TextBox cssclass="form-control"  ID="TextBox1" runat="server" placeholder=" id">

                                        </asp:TextBox>
                                        <asp:Button ID="Button1" class="btn btn-primary " runat="server" Text="Go" OnClick="Button1_Click"/> 
                                     </div>
                                    </div>
                                 </div>    
 
                            
                               <div class="col-md-8">
                                 <label >Author name</label>
                                 <div class="form-group">
                                     
                                     <asp:TextBox cssclass="form-control"  ID="TextBox2" runat="server" placeholder="name">

                                     </asp:TextBox>
                                 </div>
                               </div>
                        </div>
                            
                                    <div class="row"> 
                                       <div class="col-4">
                                           <asp:Button ID="Button2" runat="server" Class="btn btn-lg btn-block btn-success" 
                                               Text="add" OnClick="Button2_Click" />
                                        </div>
                                         <div class="col-4">
                                           <asp:Button ID="Button3" runat="server" Class="btn btn-lg btn-block btn-warning" 
                                               Text="update" OnClick="Button3_Click" />
                                        </div>
                                         <div class="col-4">
                                           <asp:Button ID="Button4" runat="server" Class="btn btn-lg btn-block btn-danger" 
                                               Text="delete" OnClick="Button4_Click" />
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
                                    <h4>Author list</h4 >
                                </center>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col">
                                 
                                    <hr>
 
                            </div>
                        </div>
                        <div class="row">

                             <asp:sqldatasource ID="sqldatasource1" runat="server" ConnectionString="<%$ ConnectionStrings:TlibrarydbConnectionString %>" SelectCommand="SELECT * FROM [author_master_tbl]"></asp:sqldatasource>
                            <div class="col">
                               
                            <asp:GridView  Class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="author_id" DataSourceID="sqldatasource1">
                                <Columns>
                                    <asp:BoundField DataField="author_id" HeaderText="author_id" ReadOnly="True" SortExpression="author_id" />
                                    <asp:BoundField DataField="author_name" HeaderText="author_name" SortExpression="author_name" />
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

