using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default3 : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source = TSEGI1252\\SQLEXPRESS; Initial Catalog = Tlibrarydb; Integrated Security = True");
    
    protected void page_load(object sender, EventArgs e)
    {
        
    }
    protected void signupClick(object sender, EventArgs e)
    {
        if (checkMemberExists())
        {
            Response.Write("<script>alert('member already exists');</script>");
        }
        else
        {  
            signUpNewmember();
        }
    }

    bool checkMemberExists()
    {
        try
        { 
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            } 
            SqlCommand cmd = new SqlCommand("SELECT * FROM  member_master_tbl where member_id='" + TextBox8.Text.Trim() + "';", con);
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
            Response.Write("<script>alert('it seems not sign up');</script>");
            return false;
        }

    }

    void signUpNewmember()
    {
        //try
        //{
            SqlConnection con = new SqlConnection("Data Source = TSEGI1252\\SQLEXPRESS; Initial Catalog = Tlibrarydb; Integrated Security = True");
            //con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO member_master_tbl(full_name,dob,contact_no,email,State,city,pincode,full_adress,Password,account_status)values(@full_name, @dob, @contact_no, @email, @State, @city, @pincode, @full_address, @Password, @account_status)");
            cmd.Parameters.AddWithValue("@full_name", TextBox1.Text.Trim());
            DateTime now = DateTime.Now;
            Console.WriteLine(now.ToString("ddd MMM %d, yyyy"));
            cmd.Parameters.AddWithValue("@dob", TextBox2.Text.ToString()); 
            cmd.Parameters.AddWithValue("@contact_no", TextBox3.Text.Trim());
            cmd.Parameters.AddWithValue("@email", TextBox4.Text.Trim());
            cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@city", TextBox6.Text.Trim());
            cmd.Parameters.AddWithValue("@pincode", TextBox7.Text.Trim());
            cmd.Parameters.AddWithValue("@full_address", TextBox5.Text.Trim());
            //cmd.Parameters.AddWithValue("@member_id", TextBox8.Text.Trim());
            cmd.Parameters.AddWithValue("@password", TextBox9.Text.Trim());
            cmd.Parameters.AddWithValue("@account_status", "pending");
            con.Open();
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();

            
            Response.Write("<script>alert('signup successful. go to user login');</script>");
    //}
    //    catch (Exception ex)
    //    {
    //        Response.Write("<script>alert('" + ex.Message + "');</script>");
    //    }
    }

     
    protected void TextBox5_TextChanged(object sender, EventArgs e)
    {

    }
}
     
