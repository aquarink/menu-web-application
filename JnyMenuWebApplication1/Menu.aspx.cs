using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

namespace JnyMenuWebApplication1
{
    public partial class Menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string idDept = Request.QueryString["dept"];
            if (idDept == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {

                SqlConnection koneksi = new SqlConnection(ConfigurationManager.ConnectionStrings["JNYWebMenuConnectionString"].ToString());

                //
                try
                {
                    StringBuilder htmlTable = new StringBuilder();
                    koneksi.Open();

                    SqlCommand sqlCommandFetch = new SqlCommand("SELECT * FROM MenuTable WHERE (idDept = @id) AND (statusMenu = 1)", koneksi);
                    sqlCommandFetch.Parameters.Add(new SqlParameter("@id", idDept));
                    SqlDataReader sqlDataReader = sqlCommandFetch.ExecuteReader();

                    //
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            htmlTable.Append("<a href='" + sqlDataReader["linkMenu"] + "'>");
                            htmlTable.Append("<div class='col-md-3 productbox' style='margin-right:10px'>");
                            htmlTable.Append("<img alt='' style='width:265px; height:265px' src='" + sqlDataReader["logoMenu"] + "' class='img-responsive' />");
                            htmlTable.Append("<div class='producttitle' style='text-align:center'>" + sqlDataReader["namaMenu"].ToString().ToUpper() + "</div>");
                            htmlTable.Append("</div>");
                            htmlTable.Append("</a>");

                        }

                        MenuDataPlaceHolder.Controls.Add(new Literal { Text = htmlTable.ToString() });

                        sqlDataReader.Close();
                        sqlDataReader.Dispose();
                    }
                    else
                    {
                        htmlTable.Append("<a href='Default.aspx' class='btn btn-warning'>System Not Found, Back..!</a>");

                        MenuDataPlaceHolder.Controls.Add(new Literal { Text = htmlTable.ToString() });
                    }

                }
                catch (Exception ex)
                {
                    //LabelMsg.Text = "Insert Employee " + ex.Message;
                }
                finally
                {
                    koneksi.Close();
                }
            }
        }
    }
}