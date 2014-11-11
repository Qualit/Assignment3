using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Assignment3
{
    public partial class allBks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            booksTable.CssClass = "table table-hover";
            TableRow tRow = new TableRow();
            booksTable.Rows.Add(tRow);
            TableCell tCell1 = new TableCell();
            TableCell tCell2 = new TableCell();
            TableCell tCell3 = new TableCell();
            tCell1.Text = "Title";
            tCell2.Text = "Author";
            tCell3.Text = "ISBN";
            tRow.Cells.Add(tCell1);
            tRow.Cells.Add(tCell2);
            tRow.Cells.Add(tCell3);
            
            string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

            string sql = "select BookTitle, BookAuthor, ISBN, BookId from Book";
            SqlConnection con = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr;

            try
            {
                con.Open();

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TableRow tRow2 = new TableRow();
                    booksTable.Rows.Add(tRow2);
                    for (int j = 0; j <= 2; j++)
                    {
                        // Create a new cell and add it to the row.
                        TableCell tCell = new TableCell();
                        tCell.Text = dr[j].ToString();
                        tRow2.Cells.Add(tCell);
                       
                    }
                    if (Session["id"] != null)
                    {
                        TableCell tCell4 = new TableCell();
                        string id = dr[3].ToString();
                        tCell4.Text = "<a href='default.aspx?id=" + id + "'><span class='btn btn-primary glyphicon glyphicon-cloud-download'>Borrow </span></a>";
                        tRow2.Cells.Add(tCell4);
                    }
                }

                dr.Close();
             

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