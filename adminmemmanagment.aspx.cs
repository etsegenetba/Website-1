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
    //go
    protected void GoClick(object sender, EventArgs e)
    {
        getMemberById();
    }

    protected void activeClick(object sender, EventArgs e)
    {
        updateMemberStatusById("active");
    }

    protected void pendingClick(object sender, EventArgs e)
    {
         updateMemberStatusById("pending"); 
    }

    protected void deactiveClick(object sender, EventArgs e)
    {
         updateMemberStatusById("deactive");
    }

    protected void deleteClick(object sender, EventArgs e)
    {
        deleteMemberById();
    }

    bool checkIfMemberExists()
    {
        try
        {

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }


            SqlCommand cmd = new SqlCommand("SELECT * FROM  member_master_tbl where member_id='" + TextBox1.Text.Trim() + "';", con);
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
    void getMemberById()
    {
        try
        {
            SqlConnection con = new SqlConnection("Data Source = TSEGI1252\\SQLEXPRESS; Initial Catalog = Tlibrarydb; Integrated Security = True");


            SqlCommand cmd = new SqlCommand("Select * FROM member_master_tbl  WHERE member_id='" + TextBox1.Text.Trim() + "'; ", con);

            con.Open();
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            //voi
            //con.Close();

            SqlDataReader dr = cmd.ExecuteReader();
            //DataTable dt = new DataTable();
             
            if (dr.HasRows )
            {
                while (dr.Read())
                {
                    TextBox2.Text = dr.GetValue(0).ToString();
                    TextBox7.Text = dr.GetValue(10).ToString();
                    TextBox3.Text = dr.GetValue(1).ToString();
                    TextBox8.Text = dr.GetValue(2).ToString();
                    TextBox4.Text = dr.GetValue(3).ToString();
                    TextBox9.Text = dr.GetValue(4).ToString();
                    TextBox10.Text = dr.GetValue(5).ToString();
                    TextBox11.Text = dr.GetValue(6).ToString();
                    TextBox5.Text = dr.GetValue(7).ToString();
                }
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
    void updateMemberStatusById(string status)
    {
        if (checkIfMemberExists())
        {

            try
            {
                SqlConnection con = new SqlConnection("Data Source = TSEGI1252\\SQLEXPRESS; Initial Catalog = Tlibrarydb; Integrated Security = True");


                SqlCommand cmd = new SqlCommand("UPDATE member_master_tbl SET account_status='" + status + "' WHERE member_id='" + TextBox1.Text.Trim() + "'; ", con);

                con.Open();
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                //voi
                con.Close();
                GridView1.DataBind();
                //SqlDataReader dr = cmd.ExecuteReader();
                //DataTable dt = new DataTable();
                Response.Write("<script>alert('member status updated');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('invalid member id ');</script>");
        }
    }

    void deleteMemberById()
    {
        if (checkIfMemberExists())
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source = TSEGI1252\\SQLEXPRESS; Initial Catalog = Tlibrarydb; Integrated Security = True");


                SqlCommand cmd = new SqlCommand("DELETE FROM member_master_tbl  WHERE member_id='" + TextBox1.Text.Trim() + "' ", con);

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
        else
        {
            Response.Write("<script>alert('invalid member id ');</script>");
        }
    }
    void clearForm()
    {
        TextBox2.Text =  "";
        TextBox7.Text =  "";
        TextBox3.Text = "";
        TextBox8.Text = "";
        TextBox4.Text = "";
        TextBox9.Text = "";
        TextBox10.Text = "";
        TextBox11.Text = "";
        TextBox5.Text = "";
    }

}