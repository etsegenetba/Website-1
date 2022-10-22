using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default4 : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source = TSEGI1252\\SQLEXPRESS; Initial Catalog = Tlibrarydb; Integrated Security = True");
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.DataBind();
        try
        {
           if(Session["username"].ToString()== "" || Session["username"]== null)
            {
                Response.Write("<script>alert('session expired login again');</script>");
                Response.Redirect("userlogin.aspx");
            }
            else
            {
                getUserBookData();

                if (!Page.IsPostBack)
                {
                    getUserPersonalDetails();
                   
                }
            }
        }
        catch(Exception ex)
        {
            Response.Write("<script>alert('session expired login again');</script>");
            Response.Redirect("userlogin.aspx");
        }
    }

    protected void updateclick(object sender, EventArgs e)
    {
        if (Session["username"].ToString() == "" || Session["username"] == null)
        {
            Response.Write("<script>alert('session expired login again');</script>");
            Response.Redirect("userlogin.aspx");
        }
        else
        {
            updateUserPersonalDetails();
        }
    }
    void updateUserPersonalDetails()
    {
        string password = "";
        if (TextBox10.Text.Trim() == "")
        {
            password = TextBox9.Text.Trim();
        }
        else
        {
            password = TextBox10.Text.Trim();
        }
        try
        {
            SqlConnection con = new SqlConnection("Data Source = TSEGI1252\\SQLEXPRESS; Initial Catalog = Tlibrarydb; Integrated Security = True");


            SqlCommand cmd = new SqlCommand("update member_master_tbl SET full_name=@full_name, dob=@dob, contact_no=@contact_no, email=@email, state=@state, city=@city, pincode=@pincode, full_adress=@full_adress, password=@password, account_status=@account_status WHERE member_id='" + Session["username"].ToString().Trim() + "' ", con);
            cmd.Parameters.AddWithValue("full_name", TextBox1.Text.Trim());
            cmd.Parameters.AddWithValue("dob", TextBox2.Text.Trim());
            cmd.Parameters.AddWithValue("contact_no", TextBox3.Text.Trim());
            cmd.Parameters.AddWithValue("email", TextBox4.Text.Trim());
            cmd.Parameters.AddWithValue("state", DropDownList1.SelectedItem.Value);
            cmd.Parameters.AddWithValue("city", TextBox6.Text.Trim());
            cmd.Parameters.AddWithValue("pincode", TextBox7.Text.Trim());
            cmd.Parameters.AddWithValue("full_adress", TextBox5.Text.Trim());
            cmd.Parameters.AddWithValue("password", TextBox9.Text.Trim());
            cmd.Parameters.AddWithValue("account_status", "Pending");
            con.Open();
            cmd.Connection = con;
            int result = cmd.ExecuteNonQuery();  
            con.Close();
            if (result > 0)
            {
                Response.Write("<script>alert('your details updated successfully ');</script>");
                getUserPersonalDetails();
                getUserBookData();

            }
            else
            {
                Response.Write("<script>alert('Invalid Entry');</script>");
            }
             
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "');</script>");
        }
    }
    void getUserPersonalDetails()
    {
        try
        {
            SqlConnection con = new SqlConnection("Data Source = TSEGI1252\\SQLEXPRESS; Initial Catalog = Tlibrarydb; Integrated Security = True");


            SqlCommand cmd = new SqlCommand("Select * FROM member_master_tbl  WHERE member_id='" + Session["username"].ToString() + "'; ", con);

            con.Open();
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            TextBox1.Text = dt.Rows[0]["full_name"].ToString();
            TextBox2.Text = dt.Rows[0]["dob"].ToString();
            TextBox3.Text = dt.Rows[0]["contact_no"].ToString();
            TextBox4.Text = dt.Rows[0]["email"].ToString();
            DropDownList1.SelectedValue = dt.Rows[0]["state"].ToString();

            TextBox6.Text = dt.Rows[0]["city"].ToString();
            TextBox7.Text = dt.Rows[0]["pincode"].ToString();
            TextBox5.Text = dt.Rows[0]["full_adress"].ToString();
            TextBox8.Text = dt.Rows[0]["member_id"].ToString();
            TextBox9.Text = dt.Rows[0]["password"].ToString();

            Label1.Text = dt.Rows[0]["account_status"].ToString().Trim();

            if (dt.Rows[0]["account_status"].ToString().Trim() == "Active")
            {
                Label1.Attributes.Add("class", "badge badge-pill badge-success");
            }
            else if (dt.Rows[0]["account_status"].ToString().Trim() == "Pending")
            {
                Label1.Attributes.Add("class", "badge badge-pill badge-warning");
            }
            else if (dt.Rows[0]["account_status"].ToString().Trim() == "Deactive")
            {
                Label1.Attributes.Add("class", "badge badge-pill badge-danger");
            }
            else
            {
                Label1.Attributes.Add("class", "badge badge-pill badge-info");
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "');</script>");
        }
    }
    void getUserBookData()
    {
        try
        {
            SqlConnection con = new SqlConnection("Data Source = TSEGI1252\\SQLEXPRESS; Initial Catalog = Tlibrarydb; Integrated Security = True");


            SqlCommand cmd = new SqlCommand("Select * FROM book_issue_tbl  WHERE member_id='" + Session["username"].ToString()+ "'; ", con);

            con.Open();
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "');</script>");
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
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
            Response.Write("<script>alert(' " + ex.Message + "');</script>");
        }
    }
}