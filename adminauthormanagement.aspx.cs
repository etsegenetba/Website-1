using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source = TSEGI1252\\SQLEXPRESS; Initial Catalog = Tlibrarydb; Integrated Security = True");
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.DataBind();
    }
    //add 
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (checkIfAuthorExists())
        {
            Response.Write("<script>alert('author with this id already exists. you can not add another author with the same author id');</script>");
        }
        else
        {
            addNewAuthor();
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        if (checkIfAuthorExists())
        {
            updateAuthor();
        }
        else
        {
            Response.Write("<script>alert('author updated successfuly');</script>");
           
        }
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        if (checkIfAuthorExists())
        {
            deleteAuthor();
        }
        else
        {
            Response.Write("<script>alert('author deleted successfuly');</script>");

        }
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        getAuthorById();
    }
    void getAuthorById()
    {
        try
        {
            SqlConnection con = new SqlConnection("Data Source = TSEGI1252\\SQLEXPRESS; Initial Catalog = Tlibrarydb; Integrated Security = True");


            SqlCommand cmd = new SqlCommand("Select * FROM author_master_tbl  WHERE author_id='" + TextBox1.Text.Trim() + "'; ", con);

            con.Open();
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count >= 1)
            {
                TextBox2.Text = dt.Rows[0][1].ToString();
            }
            else
            {
                Response.Write("<script>alert('invalid author id');</script>");
            }


        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "');</script>");
        }
    }
    void deleteAuthor()
    {
        try
        {
            SqlConnection con = new SqlConnection("Data Source = TSEGI1252\\SQLEXPRESS; Initial Catalog = Tlibrarydb; Integrated Security = True");


            SqlCommand cmd = new SqlCommand("DELETE FROM author_master_tbl  WHERE author_id='" + TextBox1.Text.Trim() + "' ", con);
             
            con.Open();
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();


            Response.Write("<script>alert('author deleted successfully ');</script>");
            clearForm();
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "');</script>");
        }
    }

    void updateAuthor()
    {
        try
        {
            SqlConnection con = new SqlConnection("Data Source = TSEGI1252\\SQLEXPRESS; Initial Catalog = Tlibrarydb; Integrated Security = True");


            SqlCommand cmd = new SqlCommand("UPDATE author_master_tbl  SET author_name= @author_name WHERE author_id='"+TextBox1.Text.Trim() +"' ", con);
             
            cmd.Parameters.AddWithValue("@author_name", TextBox2.Text.Trim());
            con.Open();
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();


            Response.Write("<script>alert('author updated successfully ');</script>");
            clearForm();
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "');</script>");
        }
    }
    void addNewAuthor()

    {
        try
        {
            SqlConnection con = new SqlConnection("Data Source = TSEGI1252\\SQLEXPRESS; Initial Catalog = Tlibrarydb; Integrated Security = True");

            
            SqlCommand cmd = new SqlCommand("INSERT INTO author_master_tbl(author_id ,author_name)values(@author_id ,@author_name)", con);
            cmd.Parameters.AddWithValue("@author_id", TextBox1.Text.Trim());
            cmd.Parameters.AddWithValue("@author_name", TextBox2.Text.Trim()); 
            con.Open();
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();


            Response.Write("<script>alert('author added successfully ');</script>");
            clearForm();
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "');</script>");
        }
    }
    bool checkIfAuthorExists()
    {
        try
        {

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }


            SqlCommand cmd = new SqlCommand("SELECT * FROM  author_master_tbl where author_id='" + TextBox1.Text.Trim() + "';", con);
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
        void clearForm()
       {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }
    
    }
