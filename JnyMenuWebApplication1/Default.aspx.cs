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

namespace JnyCardWebApplication
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder htmlTable = new StringBuilder();
            SqlConnection koneksi = new SqlConnection(ConfigurationManager.ConnectionStrings["JNYWebMenuConnectionString"].ToString());

            //
            try
            {
                koneksi.Open();

                SqlCommand sqlCommandFetch = new SqlCommand("SELECT * FROM DepartmentTable WHERE (statusDept = 1)", koneksi);
                SqlDataReader sqlDataReader = sqlCommandFetch.ExecuteReader();

                //
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        htmlTable.Append("<a href='Menu.aspx?dept=" + sqlDataReader["idDept"] + "'>");
                        htmlTable.Append("<div class='col-md-3 productbox' style='margin-right:10px'>");
                        htmlTable.Append("<img alt='' style='width:265px; height:265px' src='Layout/Assets/img/computer.png' class='img-responsive' />");
                        htmlTable.Append("<div class='producttitle' style='text-align:center'>" + sqlDataReader["namaDept"].ToString().ToUpper() + "</div>");
                        htmlTable.Append("</div>");
                        htmlTable.Append("</a>");

                    }

                    DeptDataPlaceHolder.Controls.Add(new Literal { Text = htmlTable.ToString() });

                    sqlDataReader.Close();
                    sqlDataReader.Dispose();
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