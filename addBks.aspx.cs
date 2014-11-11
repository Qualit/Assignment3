using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment3
{
    public partial class addBks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

            string sql = "insert into Book (BookTitle, BookAuthor, ISBN) values ('" + Ttl.Text + "', '" + Auth.Text + "', '" + ISBN.Text +"')";
            SqlConnection con = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(sql, con);
            string sql2 = "select BookTitle from Book WHERE BookTitle='" + Ttl.Text + "'";
            SqlCommand cmd2 = new SqlCommand(sql2, con);

            try
            {
                con.Open();
                if (cmd2.ExecuteScalar() == null)
                {
                    cmd.ExecuteNonQuery();

                    System.Threading.Thread.Sleep(1000);
                    Response.Redirect("addSucc.aspx");
                }
                else
                {
                    System.Threading.Thread.Sleep(1000);
                    Response.Redirect("err3.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }
    }
}