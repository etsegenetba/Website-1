using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source = TSEGI1252\\SQLEXPRESS; Initial Catalog = Tlibrarydb; Integrated Security = True");
    static string global_filepath;
    static int global_actual_stock, global_current_stock, global_issued_books;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            fillAuthorPublisherValues();
         
        }
        GridView1.DataBind();

    }
    //add
    protected void addClick(object sender, EventArgs e)
    {
      
        var Bookid = bookid_txt.Text.ToString();
        var BookName = bookName.Text.ToString();
        var AuthorName = AuthName.SelectedValue.ToString();
        var PublisherName = pubName.SelectedValue.ToString();
        var PublishDate = dateId.Text.ToString();
        var Language = langId.SelectedValue.ToString();
        var Edtion = editionid.Text.ToString();
        var BookCost = costid.Text.ToString();
        var NumberOfPage = pagenumid.Text.ToString();
        var BoookDescrption = BookdescId.Text.ToString();
        var ActualStock = actualStockid.Text.ToString();
        var CurrentStock = currentstockid.Text.ToString();
        addNewBook(Bookid, BookName, AuthorName, PublisherName, PublishDate, Language, Edtion, BookCost, NumberOfPage, BoookDescrption, ActualStock, CurrentStock);
        //if (checkIfBookExists())
        //{
        //    Response.Write("<script>alert('book already exists,try some other book id');</script>");
        //}
        //else
        //{

        //}
     }
    //update
    protected void updateClick(object sender, EventArgs e)
    {
       // var Bookid = bookid_txt.Text.ToString();
        var BookName = bookName.Text.ToString();
        var AuthorName = AuthName.SelectedValue.ToString();
        var PublisherName = pubName.SelectedValue.ToString();
        var PublishDate = dateId.Text.ToString();
        var Language = langId.SelectedValue.ToString();
        var Edtion = editionid.Text.ToString();
        var BookCost = costid.Text.ToString();
        var NumberOfPage = pagenumid.Text.ToString();
        var BoookDescrption = BookdescId.Text.ToString();
        var ActualStock = actualStockid.Text.ToString();
        var CurrentStock = currentstockid.Text.ToString();
        updateBookById( BookName, AuthorName, PublisherName, PublishDate, Language, Edtion, BookCost, NumberOfPage, BoookDescrption, ActualStock, CurrentStock);
    }
    //delete
    protected void deleteClick(object sender, EventArgs e)
    {
        deleteBookById();
    }
    //go
    protected void GoClick(object sender, EventArgs e)
    {
        getBookById();
    }
    void getBookById()
    {
        //try
        //{
            SqlConnection con = new SqlConnection("Data Source = TSEGI1252\\SQLEXPRESS; Initial Catalog = Tlibrarydb; Integrated Security = True");


            SqlCommand cmd = new SqlCommand("Select * FROM  book_master_tbl Where book_id='"+ bookid_txt.Text.ToString() + "'; ", con);

            con.Open();
            cmd.Connection = con;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count >= 1)
            {
                bookName.Text = dt.Rows[0]["book_name"].ToString();
                dateId.Text = dt.Rows[0]["publish_date"].ToString();
                langId.SelectedValue= dt.Rows[0]["language"].ToString();
                AuthName.SelectedValue = dt.Rows[0]["author_name"].ToString();
                pubName.SelectedValue = dt.Rows[0]["publisher_name"].ToString();
                editionid.Text= dt.Rows[0]["edition"].ToString();
                costid.Text = dt.Rows[0]["book_cost"].ToString();
                pagenumid.Text = dt.Rows[0]["no_of_pages"].ToString();
                actualStockid.Text = dt.Rows[0]["actual_stock"].ToString();
                currentstockid.Text = dt.Rows[0]["current_stock"].ToString();

                global_actual_stock = int.Parse(dt.Rows[0]["actual_stock"].ToString());
                global_current_stock = int.Parse( dt.Rows[0]["current_stock"].ToString());

                global_issued_books = global_actual_stock - global_current_stock;
                issuedbk.Text = global_issued_books.ToString();

                global_filepath = dt.Rows[0]["book_img_link"].ToString();
                BookdescId.Text = dt.Rows[0]["book_description"].ToString();
                generid.ClearSelection();
                string[] genere = dt.Rows[0]["genere"].ToString().Split(',');
                for (int i=0; i< genere.Length; i++)
                {
                    for (int j = 0; j < generid.Items.Count; j++)
                        if(generid.Items[j].ToString() == genere[i])
                        {
                            generid.Items[j].Selected = true;
                        }
                }
            }
            else
            {
                Response.Write("<script>alert(' invalid book id   ');</script>");
            }
             
        //}
        //catch (Exception ex)
        //{
        //    Response.Write("<script>alert('" + ex.Message + "');</script>");
        //}
    }
    void fillAuthorPublisherValues()
    {
        try
        {
             SqlConnection con = new SqlConnection("Data Source = TSEGI1252\\SQLEXPRESS; Initial Catalog = Tlibrarydb; Integrated Security = True");


            SqlCommand cmd = new SqlCommand("Select author_name FROM author_master_tbl; ", con);

            con.Open();
            cmd.Connection = con;
            
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            AuthName.DataSource = dt;
            AuthName.DataValueField = "author_name";
            AuthName.DataBind();
            cmd = new SqlCommand("Select publisher_name FROM publisher_master_tbl; ", con);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            pubName.DataSource = dt;
            pubName.DataValueField = "publisher_name";
            pubName.DataBind();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "');</script>");
        }
    }
    bool checkIfBookExists()
    {
        try
        {

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }


            SqlCommand cmd = new SqlCommand("SELECT * FROM  book_master_tbl where book_id='" + bookid_txt.Text.ToString() + "'OR book_name='"+ bookName.Text.Trim() +"';", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "');</script>");
            return false;
        }
    }
     void addNewBook(string bookid, string bookname,string author_name, string publisher_name, string publish_date, string language, string edtion, string bookcost, string No_of_Page, string bookDescrption, string ActualStock, string CurrentStock)
    {

        //try
        //{
            string generes = "";
            foreach (int i in generid.GetSelectedIndices())
            {
                generes = generes + generid.Items[i] + ",";
            }
            generes = generes.Remove(generes.Length - 1);

            string filepath = "~/book_inventory/images%20(1).jpg";
            string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
            FileUpload1.SaveAs(Server.MapPath("~/book_inventory/" + filename));
            filepath = "~/book_inventory/" + filename;

            SqlConnection con = new SqlConnection("Data Source = TSEGI1252\\SQLEXPRESS; Initial Catalog = Tlibrarydb; Integrated Security = True");

      
        SqlCommand cmd = new SqlCommand("INSERT INTO book_master_tbl(book_id ,book_name,genere,author_name,publisher_name,publish_date,language,edition,book_cost,no_of_pages,book_description,actual_stock,current_stock,book_img_link)values(@book_id,@book_name,@genere,@author_name,@publisher_name,@publish_date,@language,@edition,@book_cost,@no_of_pages,@book_description,@actual_stock,@current_stock,@book_img_link)", con);
            cmd.Parameters.AddWithValue("@book_id", bookid);
            cmd.Parameters.AddWithValue("@book_name", bookname);
            cmd.Parameters.AddWithValue("@genere", generes);


            cmd.Parameters.AddWithValue("@author_name", author_name);
            cmd.Parameters.AddWithValue("@publisher_name", publisher_name);
            cmd.Parameters.AddWithValue("@publish_date", publish_date);
            cmd.Parameters.AddWithValue("@language", language);
            cmd.Parameters.AddWithValue("@edition", edtion);
            cmd.Parameters.AddWithValue("@book_cost", bookcost);
            cmd.Parameters.AddWithValue("@no_of_pages", No_of_Page);
            cmd.Parameters.AddWithValue("@book_description", bookDescrption);
            cmd.Parameters.AddWithValue("@actual_stock", ActualStock);
            cmd.Parameters.AddWithValue("@current_stock", ActualStock);
            cmd.Parameters.AddWithValue("@book_img_link",filepath);
            con.Open();
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            //con.Close();


            Response.Write("<script>alert('book added successfully ');</script>");
            //clearForm();
            GridView1.DataBind();
        //}
        //catch (Exception ex)
        //{
        //    Response.Write("<script>alert('" + ex.Message + "');</script>");
        //}
    }
    void updateBookById( string bookname, string author_name, string publisher_name, string publish_date, string language, string edtion, string bookcost, string No_of_Page, string bookDescrption, string ActualStock, string CurrentStock)
    {
        if (checkIfBookExists())
        {

            try
            {
                int actual_stock = int.Parse(actualStockid.Text.Trim());
                int current_stock = int.Parse(currentstockid.Text.Trim());

                if (global_actual_stock == actual_stock)
                {

                }
                else
                {
                    if(actual_stock < global_issued_books)
                    {
                        Response.Write("<script>alert('actual stock can not be less than the issued books ');</script>");
                        return;
                    }
                    else
                    {
                        current_stock = actual_stock - global_issued_books;
                        currentstockid.Text = "" + current_stock;
                    }
                }

                string generes = "";
                foreach (int i in generid.GetSelectedIndices())
                {
                    generes = generes + generid.Items[i] + ",";
                }
                generes = generes.Remove(generes.Length - 1);

                string filepath = "~/book_inventory/images%20(1).jpg";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);

                if (filename =="" || filename == null)
                {
                     filepath = global_filepath;
                }
                else
                {
                    FileUpload1.SaveAs(Server.MapPath("~/book_inventory/" + filename));
                    filepath = "~/book_inventory/" + filename;
                }
                


                SqlConnection con = new SqlConnection("Data Source = TSEGI1252\\SQLEXPRESS; Initial Catalog = Tlibrarydb; Integrated Security = True");


                SqlCommand cmd = new SqlCommand("UPDATE book_master_tbl SET book_name= @book_name, genere=@genere , author_name= @author_name, publisher_name=@publisher_name, publish_date =@publish_date, language=@language, edition = @edition, book_cost = @book_cost, no_of_pages =@no_of_pages, book_description= @book_description, actual_stock=@actual_stock, current_stock=@current_stock, book_img_link=@book_img_link WHERE book_id='" + bookid_txt.Text.Trim() + "'; ", con);

                //cmd.Parameters.AddWithValue("@book_id", bookid);
                cmd.Parameters.AddWithValue("@book_name", bookname);
                cmd.Parameters.AddWithValue("@genere", generes);


                cmd.Parameters.AddWithValue("@author_name", author_name);
                cmd.Parameters.AddWithValue("@publisher_name", publisher_name);
                cmd.Parameters.AddWithValue("@publish_date", publish_date);
                cmd.Parameters.AddWithValue("@language", language);
                cmd.Parameters.AddWithValue("@edition", edtion);
                cmd.Parameters.AddWithValue("@book_cost", bookcost);
                cmd.Parameters.AddWithValue("@no_of_pages", No_of_Page);
                cmd.Parameters.AddWithValue("@book_description", bookDescrption);
                cmd.Parameters.AddWithValue("@actual_stock", ActualStock);
                cmd.Parameters.AddWithValue("@current_stock", CurrentStock);
                cmd.Parameters.AddWithValue("@book_img_link", filepath);
                con.Open();
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                //voi
                con.Close();
                GridView1.DataBind();
                 
                Response.Write("<script>alert('Book updated');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('invalid book id ');</script>");
        }
    }
    void deleteBookById()
    {
        if (checkIfBookExists())
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source = TSEGI1252\\SQLEXPRESS; Initial Catalog = Tlibrarydb; Integrated Security = True");


                SqlCommand cmd = new SqlCommand("DELETE FROM book_master_tbl  WHERE book_id='" + bookid_txt.Text.Trim() + "' ", con);

                con.Open();
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();


                Response.Write("<script>alert('book deleted successfully ');</script>");

                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('Invalid Member ID');</script>");
        }
    }
}