using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source = TSEGI1252\\SQLEXPRESS; Initial Catalog = Tlibrarydb; Integrated Security = True");

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            //SqlConnection con = new SqlConnection(strcon);
            
                con.Open();
            


            SqlCommand cmd = new SqlCommand("SELECT * FROM  member_master_tbl where member_id='" + TextBox1.Text.Trim() + "' And password='"+ TextBox2.Text.Trim()+ "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
             
              
            if (dr.HasRows)
            {
                while(dr.Read())
                {
                    Response.Write("<script>alert('Login successful');</script>");
                    Session["username"] = dr.GetValue(8).ToString();
                    Session["fullname"] = dr.GetValue(0).ToString();
                    Session["role"] ="user";
                    Session["status"] = dr.GetValue(10).ToString();
                }
                Response.Redirect("ourweb.aspx");
            }
            else
            {
                Response.Write("<script>alert('invalid user');</script>");
            }
        }
        catch (Exception ex)
        {
             
        } // Response.Write("<script>alert('successfuly loged');</script>");
    }
}