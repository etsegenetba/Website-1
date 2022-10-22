using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["role"].Equals(""))
            {
                LinkButton1.Visible = true; //userlogin
                LinkButton2.Visible = true; //signup

                LinkButton3.Visible = true; //logout
                LinkButton7.Visible = true; //hello

                LinkButton6.Visible = true; //adminlogin
                LinkButton11.Visible = false; //authormgmt
                LinkButton12.Visible = false; //pubmgmt
                LinkButton8.Visible = false; //bkinventory
                LinkButton9.Visible = false; //bkissue
                LinkButton10.Visible = false; //membermgmt
                LinkButton10.Visible = false; //membermgmt
            }
            else if (Session["role"].Equals("user"))
            {
                LinkButton1.Visible = false; //userlogin
                LinkButton2.Visible = false; //signup

                LinkButton3.Visible = true; //logout
                LinkButton7.Visible = true; //hello
                LinkButton7.Text = "Hello \t" + Session["fullname"].ToString();

                LinkButton6.Visible = false; //adminlogin
                LinkButton11.Visible = false; //authormgmt
                LinkButton12.Visible = false; //pubmgmt
                LinkButton8.Visible = false; //bkinventory
                LinkButton9.Visible = false; //bkissue
                LinkButton10.Visible = false; //membermgmt

            }

            else if(Session["role"].Equals("admin"))
            {
                LinkButton1.Visible = false; //userlogin
                LinkButton2.Visible = false; //signup

                LinkButton3.Visible = true; //logout
                LinkButton7.Visible = true; //hello
                LinkButton7.Text = "hello admin";

                LinkButton6.Visible = true; //adminlogin
                LinkButton11.Visible = true; //authormgmt
                LinkButton12.Visible = true; //pubmgmt
                LinkButton8.Visible = true; //bkinventory
                LinkButton9.Visible = true; //bkissue
                LinkButton10.Visible = true; //membermgmt

            }
             
        }
        catch(Exception ex)
        {

        }
    }

    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        Response.Redirect("adminlogin.aspx");
    }
    protected void HelloClick(object sender, EventArgs e)
    {
        Response.Redirect("userprofile.aspx");
    }

    protected void LinkButton11_Click(object sender, EventArgs e)
    {
        Response.Redirect("adminauthormanagement.aspx");
    }

    protected void LinkButton12_Click(object sender, EventArgs e)
    {
        Response.Redirect("adminpublishermanagement.aspx");

    }

    protected void LinkButton8_Click(object sender, EventArgs e)
    {
        Response.Redirect("adminboobinventory.aspx");
    }

    protected void LinkButton9_Click(object sender, EventArgs e)
    {
        Response.Redirect("bookissues.aspx");
    }

    protected void LinkButton10_Click(object sender, EventArgs e)
    {
        Response.Redirect("adminmemmanagment.aspx");
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
         
        Response.Redirect("userlogin.aspx");
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
         
        Response.Redirect("usersignup.aspx");
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Session["username"] = "";
        Session["fullname"] = "";
        Session["role"] = "";
        Session["status"] ="";

        LinkButton1.Visible = true; //userlogin
        LinkButton2.Visible = true; //signup

        LinkButton3.Visible = false; //logout
        LinkButton7.Visible = false; //hello

        LinkButton6.Visible = true; //adminlogin
        LinkButton11.Visible = false; //authormgmt
        LinkButton12.Visible = false; //pubmgmt
        LinkButton8.Visible = false; //bkinventory
        LinkButton9.Visible = false; //bkissue
        LinkButton10.Visible = false; //membermgmt

        Response.Redirect("ourweb.aspx"); 
    }

    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        LinkButton6.Visible = true; //adminlogin
        Response.Redirect("viewbook.aspx");
    }


}

