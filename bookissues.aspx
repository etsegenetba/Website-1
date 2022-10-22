<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="bookissues.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
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
                                    <h4>book issuing</h4 >
                                </center>
                            </div>
                        </div>
                         <div class="row">
                            <div class="col">
                                <center>
                                     <img width="100px"src="imgs/images(12).png" />
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
                                 <label >Member id</label>
                                 <div class="form-group">
                                     
                                     <asp:TextBox cssclass="form-control"  ID="Memberid" runat="server" placeholder="member id" >

                                     </asp:TextBox>
                                 </div>
                               </div>
                            <div class="col-md-6">
                                 
                                <label >Book id </label>
                                <div class="form-group">
                                     <div class="input-group">
                                     
                                        <asp:TextBox cssclass="form-control"  ID="Bookid" runat="server" placeholder="Book id">

                                        </asp:TextBox>
                                        <asp:Button ID="Button1" class="btn btn-dark " runat="server" OnClick="goClick" Text="Go" /> 
                                     </div>
                                    </div>
                                 </div>    
                        </div>
                             <div class="row">
                           
                               <div class="col-md-6">
                                 <label >Member name</label>
                                 <div class="form-group">
                                     
                                     <asp:TextBox cssclass="form-control"  ID="Memname" runat="server" placeholder="member name" 
                                         ReadOnly="True">

                                     </asp:TextBox>
                                 </div>
                               </div>
                                 <div class="col-md-6">
                                 <label >Book name</label>
                                 <div class="form-group">
                                     
                                     <asp:TextBox cssclass="form-control"  ID="Bookname" runat="server" placeholder="Book name" 
                                         ReadOnly="True">

                                     </asp:TextBox>
                                 </div>
                               </div>
                               
                        </div>
                             <div class="row">
                           
                               <div class="col-md-6">
                                   <label >Issue date</label>
                                 <div class="form-group">
                                     
                                     <asp:TextBox cssclass="form-control"  ID="Issuedate" runat="server" placeholder="issuedate"
                                          TextMode="Date">

                                     </asp:TextBox>
                                 </div>
                               </div>
                                 <div class="col-md-6">
                                 <label >Due date</label>
                                 <div class="form-group">
                                     
                                     <asp:TextBox cssclass="form-control"  ID="Duedate" runat="server" placeholder="duedate" 
                                         TextMode="Date">

                                     </asp:TextBox>
                                 </div>
                               </div>
                               
                        </div>
                          
                            
                                    <div class="row"> 
                                       <div class="col-6">
                                           <asp:Button ID="Button2" runat="server" Class="btn btn-lg btn-block btn-primary" OnClick="issueClick"
                                               Text="issue" />
                                        </div>
                                         
                                         <div class="col-6">
                                           <asp:Button ID="Button4" runat="server" Class="btn btn-lg btn-block btn-success"  OnClick="returnClick"
                                               Text="Return" />
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
                                    <h4>Issued list</h4 >
                                </center>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col">
                                 
                                    <hr>
 
                            </div>
                        </div>
                        <div class="row">
                            <asp:sqldatasource ID="sqldatasource1" runat="server" ConnectionString="<%$ ConnectionStrings:TlibrarydbConnectionString %>" SelectCommand="SELECT * FROM [book_issue_tbl]"></asp:sqldatasource>
                            <div class="col">
                                
                            <asp:GridView  Class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="sqldatasource1" OnRowDataBound="GridView1_RowDataBound">
                                <Columns>
                                    <asp:BoundField DataField="member_id" HeaderText="Member Id" SortExpression="member_id"></asp:BoundField>
                                    <asp:BoundField DataField="member_name" HeaderText="Member Name" SortExpression="member_name"></asp:BoundField>
                                    <asp:BoundField DataField="book_id" HeaderText="Book Id" SortExpression="book_id"></asp:BoundField>
                                    <asp:BoundField DataField="book_name" HeaderText="Book Name" SortExpression="book_name"></asp:BoundField>
                                    <asp:BoundField DataField="issue_date" HeaderText="Issue Date" SortExpression="issue_date"></asp:BoundField>
                                    <asp:BoundField DataField="due_date" HeaderText="Due Date" SortExpression="due_date"></asp:BoundField>
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

 

