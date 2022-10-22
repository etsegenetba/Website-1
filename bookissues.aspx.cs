using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source = TSEGI1252\\SQLEXPRESS; Initial Catalog = Tlibrarydb; Integrated Security = True");
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.DataBind();
    }
    protected void goClick(object sender, EventArgs e)
    {
        getnames();
    }
    protected void issueClick(object sender, EventArgs e)
    {
        if (checkIfMemberExist() && checkIfBookExist())
        {
            if (checkIfIssueEntryExist())
            {
                Response.Write("<script>alert('This member already has this book');</script>");
            }
            else
            {
                var memberid = Memberid.Text.ToString();
                var MemName = Memname.Text.ToString();
                var bookid = Bookid.Text.ToString();
                var bookname = Bookname.Text.ToString();
                var issuedate = Issuedate.Text.ToString();
                var duedate = Duedate.Text.ToString();
                issueBook(memberid, MemName, bookid, bookname, issuedate, duedate);
            }
        }
        else
        {
            Response.Write("<script>alert('wrong Book id or Member id');</script>");
        }
    }
    protected void returnClick(object sender, EventArgs e)
    {
        if (checkIfMemberExist() && checkIfBookExist())
        {
            if (checkIfIssueEntryExist())
            {
                var memberid = Memberid.Text.ToString();
                var MemName = Memname.Text.ToString();
                var bookid = Bookid.Text.ToString();
                var bookname = Bookname.Text.ToString();
                var issuedate = Issuedate.Text.ToString();
                var duedate = Duedate.Text.ToString();
                returnBook(memberid, MemName, bookid, bookname, issuedate, duedate);
                 
            }
            else
            {
                
                Response.Write("<script>alert('This entry does not exist ');</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('wrong Book id or Member id');</script>");
        }
    }
    void issueBook(string member_id, string member_name, string book_id, string book_name, string issue_date, string due_date)
    {
        try
        {
            SqlConnection con = new SqlConnection("Data Source = TSEGI1252\\SQLEXPRESS; Initial Catalog = Tlibrarydb; Integrated Security = True");


            SqlCommand cmd = new SqlCommand("INSERT INTO book_issue_tbl(member_id ,member_name, book_id, book_name ,issue_date, due_date)values(@member_id ,@member_name,@book_id,@book_name, @issue_date,@due_date)", con);
            cmd.Parameters.AddWithValue("@member_id ", member_id);
            cmd.Parameters.AddWithValue("@member_name ", member_name);
            cmd.Parameters.AddWithValue("@book_id ", book_id);
            cmd.Parameters.AddWithValue("@book_name  ", book_name);

            DateTime now = DateTime.Now;
            Console.WriteLine(now.ToString("ddd MMM %d, yyyy"));
            cmd.Parameters.AddWithValue("@issue_date ", issue_date);
            cmd.Parameters.AddWithValue("@due_date ", due_date);
            con.Open();
            cmd.Connection = con;
            cmd.ExecuteNonQuery();

            cmd = new SqlCommand("UPDATE book_master_tbl SET current_stock = current_stock-1 WHERE book_id='" + Bookid.Text.Trim() + "' ", con);
            cmd.ExecuteNonQuery();

            con.Close();
            Response.Write("<script>alert('Book issued successfully ');</script>");

            //clearForm();
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "');</script>");
        }
    }
    void returnBook(string member_id, string member_name, string book_id, string book_name, string issue_date, string due_date)
    { 
            try
            {
                SqlConnection con = new SqlConnection("Data Source = TSEGI1252\\SQLEXPRESS; Initial Catalog = Tlibrarydb; Integrated Security = True");

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                SqlCommand cmd = new SqlCommand("Delete from book_issue_tbl WHERE book_id='" + Bookid.Text.Trim() + "' AND member_id = '" + Memberid.Text.Trim() + "' ", con);
                 int result= cmd.ExecuteNonQuery();
                //con.Close();
                 
                if (result > 0)
                {
                    cmd = new SqlCommand("UPDATE book_master_tbl SET current_stock =current_stock + 1 WHERE book_id='" + Bookid.Text.Trim() + "' ", con);
                    cmd.ExecuteNonQuery(); 
                    con.Close();
                   Response.Write("<script>alert('Book returned successfully');</script>");
                   GridView1.DataBind();
                   con.Close();
                }
                else
                {
                    Response.Write("<script>alert('Invalid details');</script>");
                } 
           }
        catch (Exception ex)
          {
            Response.Write("<script>alert('" + ex.Message + "');</script>");
          }
    }
    bool checkIfBookExist()
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }


            SqlCommand cmd = new SqlCommand("SELECT * FROM book_master_tbl where book_id='" + Bookid.Text.Trim() + "'AND current_stock >= 0 ", con);
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
            return false;
        }
        
    }

    bool checkIfMemberExist()
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }


            SqlCommand cmd = new SqlCommand("SELECT full_name FROM member_master_tbl where member_id = '" + Memberid.Text.Trim() + "' " , con);
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
            return false;
        }

    }
    bool checkIfIssueEntryExist()
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }


            SqlCommand cmd = new SqlCommand("SELECT * FROM book_issue_tbl where member_id = '" + Memberid.Text.Trim() + "' AND book_id='" + Bookid.Text.Trim()+"'", con);
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
            return false;
        }

    }
    void getnames()
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }


            SqlCommand cmd = new SqlCommand("SELECT book_name FROM book_master_tbl where book_id='" + Bookid.Text.Trim() + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count >= 1)
            {
                Bookname.Text = dt.Rows[0]["book_name"].ToString();
            }
            else
            {
                Response.Write("<script>alert('wrong book id');</script>");
            }
            cmd = new SqlCommand("SELECT full_name FROM member_master_tbl where member_id='" + Memberid.Text.Trim() + "'", con);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count >= 1)
            {
                Memname.Text = dt.Rows[0]["full_name"].ToString();
            }
            else
            {
                Response.Write("<script>alert('wrong user id');</script>");
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try {
            if (e.Row.RowType == DataControlRowType.DataRow)
            { 
                DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                DateTime today = DateTime.Today;
                if (today > dt)
                {
                    e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert(' " + ex.Message+"');</script>");
        }
    }
   
}