using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Publisher
/// </summary>
public class Publisher
{
    public Publisher()
    {
        //
        // TODO: Add constructor logic here
        //
    }



    public void updatePublisher(string pubid, string pubname)
    {
        try
        {
            SqlConnection con = new SqlConnection("Data Source = TSEGI1252\\SQLEXPRESS; Initial Catalog = Tlibrarydb; Integrated Security = True");


            SqlCommand cmd = new SqlCommand("UPDATE publisher_master_tbl  SET publisher_name= @publisher_name WHERE publisher_id=@publisherId", con);
            cmd.Parameters.AddWithValue("@publisherId", pubid);
            cmd.Parameters.AddWithValue("@publisher_name", pubname);
            con.Open();
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();


            //Response.Write("<script>alert('publisher updated successfully ');</script>");
            //clearForm();
            //GridView1.DataBind();
        }
        catch (Exception ex)
        {
            //Response.Write("<script>alert('" + ex.Message + "');</script>");
        }
    }
       
       public  void deletePublisher(string pubid, string pubname)
    {
            try
            {
                SqlConnection con = new SqlConnection("Data Source = TSEGI1252\\SQLEXPRESS; Initial Catalog = Tlibrarydb; Integrated Security = True");


                SqlCommand cmd = new SqlCommand("DELETE FROM publisher_master_tbl  WHERE publisher_id= @publisherId ", con);

                cmd.Parameters.AddWithValue("@publisherId", pubid);
                cmd.Parameters.AddWithValue("@publisher_name", pubname);
                con.Open();
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();


                //Response.Write("<script>alert('publisher updated successfully ');</script>");
                //clearForm();
                //GridView1.DataBind();
            }
            catch (Exception ex)
            {
                //Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

}
