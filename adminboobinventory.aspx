<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="adminboobinventory.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        $(document).ready(function (){
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });

        function readURL(input)
        {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function(e){
                    $('#imgview').attr('src',e.target.result);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }
    
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     
    <div class="container-fluid">
       <%-- <a href="ourweb.aspx">HOME</a><br></br>--%>
        <div class="row">
           
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Book details</h4 >
                                </center>
                            </div>
                        </div> 
                         <div class="row">
                            <div class="col">
                                <center>
                                       <img id="imgview" height="150px" width="100px"src="imgs/images%20(1).jpg" />
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
                                <asp:FileUpload class="form-control" ID="FileUpload1" onchange="readURL(this);" runat="server" />
                            </div>
                        </div>
                        <div class="row">
                               <div class="col-md-3">
                                 
                                <label >Book id</label>
                                <div class="form-group">
                                     <div class="input-group">
                                      <asp:TextBox cssclass="form-control"  ID="bookid_txt" runat="server" placeholder="bkid">
                                           </asp:TextBox>
                                        <asp:Button ID="Button1" class="btn btn-primary " runat="server" Text="Go" OnClick="GoClick"/> 
                                         
                                    </div>
                                    </div>
                                 </div>  
                               
                               <div class="col-md-9">
                                 <label >Book name</label>
                                 <div class="form-group">
                                     
                                     <asp:TextBox cssclass="form-control"  ID="bookName" runat="server" placeholder="bkname">

                                     </asp:TextBox>
                                 </div>
                               </div>
                             
                        </div>
                             <daiv class="row">
                           
                               <div class="col-md-4">
                                   <label >Language</label>
                                   <div class="form-group"> 
                                     <asp:DropDownList class="form-control" ID="langId" Autopostback="false" runat="server">
                                           <asp:ListItem Text="Amharic" Value="Amharic"/>
                                           <asp:ListItem Text="English" Value="English"/>
                                           <asp:ListItem Text="Arabic" Value="Arabic"/>
                                           <asp:ListItem Text=" Hindi" Value="Hindi"/>
                                           <asp:ListItem Text="Italic" Value="Italics"/> 
                                     </asp:DropDownList>
                                    </div>
                                    <label >Publisher Name</label>
                                    <div class="form-group"> 
                                        <asp:DropDownList class="form-control" Autopostback="false" ID="pubName" runat="server">
                                          
                                           <asp:ListItem Text=" publisher 1" Value="publisher 1"/>
                                           <asp:ListItem Text="publisher 2" Value="publisher 2"/> 
                                        </asp:DropDownList>
                                      </div>
                                 </div>
                                <div class="col-md-4">
                                      <label >Author Name</label>
                                     <div class="form-group"> 
                                         <asp:DropDownList class="form-control" Autopostback="false" ID="AuthName" runat="server">
                                           
                                           <asp:ListItem Text=" a1" Value="a1"/>
                                           <asp:ListItem Text="a2" Value="a2"/> 
                                         </asp:DropDownList>
                                     </div>
                                     <label >Publish date</label>
                                     <div class="form-group">
                                     
                                         <asp:TextBox cssclass="form-control"  ID="dateId" runat="server" placeholder="date" 
                                           TextMode="Date">

                                         </asp:TextBox>
                                     </div>
                               </div>
                                 <div class="col-md-4">
                                 <label >Gener</label>
                                 <div class="form-group"> 
                                     <asp:ListBox ID="generid" SelectionMode="Multiple" cssclass="form-control"  runat="server" Rows="5">
                                         <asp:ListItem Text="Action" Value="Action" />
                                         <asp:ListItem Text="Adventure" Value="Adventure" />
                                         <asp:ListItem Text="Comic Book" Value="Comic Book" />
                                          <asp:ListItem Text="Self Help" Value="Self Help" />
                                         <asp:ListItem Text="Motivation" Value="Motivation" />
                                         <asp:ListItem Text="Healthy Living" Value="Healthy Living" />
                                         <asp:ListItem Text="Wellness" Value="Wellness" />
                                          <asp:ListItem Text="Crime" Value="Crime" />
                                         <asp:ListItem Text="Drama" Value="Drama" />
                                         <asp:ListItem Text="Fantasy" Value="Fantasy" />
                                         <asp:ListItem Text="Horror" Value="Horror" />
                                         <asp:ListItem Text="Poetry" Value="Poetry" />
                                          <asp:ListItem Text="Personal Development" Value="Personal Development" />
                                         <asp:ListItem Text="Romance" Value="Romance" />
                                          <asp:ListItem Text="Science Fiction" Value="Science Fiction" />
                                          <asp:ListItem Text="Suspense" Value="Suspense" />
                                          <asp:ListItem Text="Thriller" Value="Thriller" />
                                          <asp:ListItem Text="Art" Value="Art" />
                                          <asp:ListItem Text="Autobiography" Value="Autobiography" />
                                          <asp:ListItem Text="Encyclopedia" Value="Encyclopedia" />
                                          <asp:ListItem Text="Health" Value="Health" />
                                           <asp:ListItem Text="History" Value="History" />
                                            <asp:ListItem Text="Math" Value="Math" />
                                           <asp:ListItem Text="Textbook" Value="Textbook" />
                                            <asp:ListItem Text="Science" Value="Science" />
                                     </asp:ListBox>
                                 </div>
                               </div>
                                 
                        </daiv>
                             <div class="row">
                           
                               <div class="col-md-4">
                                 <label >Edition</label>
                                 <div class="form-group">
                                     
                                     <asp:TextBox cssclass="form-control"  ID="editionid" runat="server" placeholder="edition" 
                                        >  </asp:TextBox>
                                 </div>
                               </div>
                                  <div class="col-md-4">
                                 <label >Book Cost(per unit)</label>
                                 <div class="form-group">
                                     
                                     <asp:TextBox cssclass="form-control"  ID="costid" runat="server" placeholder="cost" 
                                          TextMode="Number">

                                     </asp:TextBox>
                                 </div>
                               </div>
                                 <div class="col-md-4">
                                 <label >Pages</label>
                                 <div class="form-group">
                                     
                                     <asp:TextBox cssclass="form-control"  ID="pagenumid" runat="server" placeholder="page" 
                                          TextMode="Number">

                                     </asp:TextBox>
                                 </div>
                               </div>
                               
                        </div>


                             <div class="row">
                           
                               <div class="col-md-3">
                                 <label >Actual stock</label>
                                 <div class="form-group">
                                     
                                     <asp:TextBox cssclass="form-control"  ID="actualStockid" runat="server" placeholder="amount" 
                                         >

                                     </asp:TextBox>
                                 </div>
                               </div>
                                  <div class="col-md-4">
                                 <label >Current Stock</label>
                                 <div class="form-group">
                                     
                                     <asp:TextBox cssclass="form-control"  ID="currentstockid" runat="server" placeholder="CurrentS" 
                                         ReadOnly="True" TextMode="Number">

                                     </asp:TextBox>
                                 </div>
                               </div>
                                 <div class="col-md-5">
                                 <label >issuedbooks</label>
                                 <div class="form-group">
                                     
                                     <asp:TextBox cssclass="form-control"  ID="issuedbk" runat="server" placeholder="issuedB" 
                                         ReadOnly="True" TextMode="Number">

                                     </asp:TextBox>
                                 </div>
                               </div>
                               
                        </div>
                           
                             <div class="row">
                           
                               <div class="col-md-12">
                                 <label > Book description</label>
                                 <div class="form-group">
                                     
                                     <asp:TextBox cssclass="form-control"  ID="BookdescId" runat="server" 
                                         placeholder=" description"
                                           TextMode="MultiLine">

                                     </asp:TextBox>
                                 </div>
                               </div>
                     
                        </div>
                           
                                    <div class="row"> 
                                        <div class="col-4">
                                           <asp:Button ID="Button3" runat="server" autopostback="True" Class="btn btn-lg btn-block btn-success" 
                                               Text="Add" OnClick="addClick" />
                                        </div>
                                        <div class="col-4">
                                           <asp:Button ID="Button4" runat="server" Class="btn btn-lg btn-block btn-primary" 
                                               Text="Update" OnClick=" updateClick" />
                                        </div>
                                       <div class="col-4">
                                           <asp:Button ID="Button2" runat="server" Class="btn btn-lg btn-block btn-danger" 
                                               Text="Delete " OnClick="deleteClick" />
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
                                    <h4>Book inventory list</h4 >
                                </center>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col">
                                 
                                    <hr>
 
                            </div>
                        </div>
                        <div class="row">
                            <asp:sqldatasource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TlibrarydbConnectionString2 %>" SelectCommand="SELECT * FROM [book_master_tbl]"></asp:sqldatasource>
                            <div class="col">
                                 
                            <asp:GridView  Class="table table-striped table-bordered" ID="GridView1" runat="server"   AutoGenerateColumns="False" DataKeyNames="book_id" DataSourceID="SqlDataSource1">
                                <Columns>
                                    <asp:BoundField DataField="book_id" HeaderText="ID" ReadOnly="True" SortExpression="book_id" >
                                     
                                    <ItemStyle Font-Bold="True" />
                                    </asp:BoundField>
                                     
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                             <div class="container-fluid">
                                                 <div class="row">
                                                     <div class="col-lg-10">
                                                         <div class="row">
                                                              <div class="col-lg-12">
                                                                  <asp:Label ID="Label1" runat="server" Text='<%# Eval("book_name") %>' Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                                              </div>
                                                         </div>
                                                         <div class="row">
                                                              <div class="col-lg-12">
                                                                     <span>Author -</span>
                                                                  <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("author_name") %>'></asp:Label>
                                                                  &nbsp;|
                                                                 
                                                                     <span> <span>&nbsp;</span>Genere - </span>

                                                                  <asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("genere") %>'></asp:Label>
                                                                   &nbsp;|
                                                                  <span><span>&nbsp;</span>Language -  </span>  

                                                                   <asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("language") %>'></asp:Label>
                                                                  
                                                              </div>
                                                         </div>
                                                         <div class="row">
                                                              <div class="col-lg-12">

                                                                  Publisher-<asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("publisher_name") %>'></asp:Label>
                                                                  &nbsp;|Publish Date -<asp:Label ID="Label6" runat="server" Font-Bold="True" Text='<%# Eval("publish_date") %>'></asp:Label>
                                                                  &nbsp;| Pages-<asp:Label ID="Label7" runat="server" Font-Bold="True" Text='<%# Eval("no_of_pages") %>'></asp:Label>
                                                                  &nbsp;| Edition-<asp:Label ID="Label8" runat="server" Font-Bold="True" Text='<%# Eval("edition") %>'></asp:Label>
                                                                  &nbsp;| Cost-<asp:Label ID="Label9" runat="server" Font-Bold="True" Text='<%# Eval("book_cost") %>'></asp:Label>
                                                                  &nbsp;| Actual stock-<asp:Label ID="Label10" runat="server" Font-Bold="True" Text='<%# Eval("actual_stock") %>'></asp:Label>
                                                                  &nbsp;| Available stock-<asp:Label ID="Label11" runat="server" Font-Bold="True" Text='<%# Eval("current_stock") %>'></asp:Label>
                                                                  &nbsp;|</div>
                                                         </div>
                                                         <div class="row">
                                                              <div class="col-lg-12">

                                                                  &nbsp;Description-<asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Italic="True" Text='<%# Eval("book_description") %>'></asp:Label>

                                                              </div>
                                                         </div>
                                                         <div class="row">
                                                              <div class="col-lg-12">

                                                              </div>
                                                         </div>
                                                     </div>
                                                     <div class="col-lg-2">
                                                         <asp:Image class= "img-fluid " ID="Image1" runat="server" ImageUrl='<%# Eval("book_img_link") %>' />
                                                     </div>
                                                 </div>
                                             </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     
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

