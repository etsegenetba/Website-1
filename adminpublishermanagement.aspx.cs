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
    Publisher pub = new Publisher();
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.DataBind();
    }
    //add 
    protected void addPublisherClick(object sender, EventArgs e)
    {
        if (checkIfPublisherExists())
        {
            Response.Write("<script>alert('publisher with this id already exists. you can not add another publisher with the same publisher id');</script>");
        }
        else
        {
            var pubid = TextBox1.Text.ToString();
            var pubname = TextBox2.Text.ToString();
            addNewPublisher(pubid, pubname);
        }
    }

    protected void updatePublisherClick(object sender, EventArgs e)
    {
        if (checkIfPublisherExists())
        {
            var pubid = TextBox1.Text.ToString();
            var pubname = TextBox2.Text.ToString();
            pub.updatePublisher(pubid, pubname);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Update Successful');window.location='adminpublishermanagement.aspx';", true);

        }
        else
        {
            Response.Write("<script>alert('Publisher updated successfuly');</script>");

        }
    }

    protected void deletePublisherClick(object sender, EventArgs e)
    {
        if (checkIfPublisherExists())
        {
            var pubid = TextBox1.Text.ToString();
            var pubname = TextBox2.Text.ToString();
            pub.deletePublisher(pubid, pubname);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('delete Successful');window.location='adminpublishermanagement.aspx';", true);
        }
        else
        {
            Response.Write("<script>alert('Publisher deleted successfuly');</script>");

        }
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        getpublisherById();
    }
    void getpublisherById()
    {
        try
        {
            SqlConnection con = new SqlConnection("Data Source = TSEGI1252\\SQLEXPRESS; Initial Catalog = Tlibrarydb; Integrated Security = True");


            SqlCommand cmd = new SqlCommand("Select * FROM publisher_master_tbl  WHERE publisher_id='" + TextBox1.Text.Trim() + "'; ", con);

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
                Response.Write("<script>alert('invalid publisher id');</script>");
            }


        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "');</script>");
        }
    }
    void deletePublisher()
    {
        try
        {
            SqlConnection con = new SqlConnection("Data Source = TSEGI1252\\SQLEXPRESS; Initial Catalog = Tlibrarydb; Integrated Security = True");


            SqlCommand cmd = new SqlCommand("DELETE FROM publisher_master_tbl  WHERE publisher_id='" + TextBox1.Text.Trim() + "' ", con);

            con.Open();
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();


            Response.Write("<script>alert('publisher deleted successfully ');</script>");
            clearForm();
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "');</script>");
        }
    }

   
    void addNewPublisher(string publisherId, string publisher_name)

    {
        try
        {
            SqlConnection con = new SqlConnection("Data Source = TSEGI1252\\SQLEXPRESS; Initial Catalog = Tlibrarydb; Integrated Security = True");


            SqlCommand cmd = new SqlCommand("INSERT INTO publisher_master_tbl(publisher_id ,publisher_name)values(@publisher_id ,@publisher_name)", con);
            cmd.Parameters.AddWithValue("@publisher_id", publisherId);
            cmd.Parameters.AddWithValue("@publisher_name", publisher_name);
            con.Open();
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();


            Response.Write("<script>alert('publisher added successfully ');</script>");
            clearForm();
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "');</script>");
        }
    }
    bool checkIfPublisherExists()
    {
        try
        {

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }


            SqlCommand cmd = new SqlCommand("SELECT * FROM  publisher_master_tbl where publisher_id='" + TextBox1.Text.Trim() + "';", con);
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
