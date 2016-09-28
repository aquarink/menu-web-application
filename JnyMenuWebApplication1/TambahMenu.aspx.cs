using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;

namespace JnyMenuWebApplication1
{
    public partial class TambahMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string kategori = (string)(Session["kategori"]);

            if (kategori == "3")
            {
                // Stay
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (
                String.IsNullOrEmpty(TxtNamaMenu.Text) ||
                String.IsNullOrEmpty(DepartmentDropDownList.Text) ||
                String.IsNullOrEmpty(TextLinkAddress.Text) ||
                String.IsNullOrEmpty(DepartmentDropDownList.SelectedValue)
                )
            {

            }
            else
            {

                if (LogoFileUpload.HasFile == false)
                {
                    // No file uploaded!
                    msgLabel.Text = "Please first select a logo to upload...";
                }
                else
                {
                    string Extensions = Path.GetExtension(LogoFileUpload.PostedFile.FileName);

                    if (
                        Extensions == ".jpg" || Extensions == ".jpeg" || Extensions == ".png" || Extensions == ".gif")
                    {
                        Random rnd = new Random();
                        int randomKey = rnd.Next(1, 999999);
                        //
                        string uploadFolder = Request.PhysicalApplicationPath + "Layout\\Assets\\gambar\\";

                        try
                        {
                            LogoFileUpload.SaveAs(uploadFolder + TxtNamaMenu.Text + randomKey + Extensions);
                            msgLabel.Text = "Upload Success";

                            try
                            {
                                SqlConnection koneksi = new SqlConnection(ConfigurationManager.ConnectionStrings["JNYWebMenuConnectionString"].ToString());
                                //
                                string logoSql = "Layout/Assets/gambar/" + TxtNamaMenu.Text + randomKey + Extensions;
                                SqlCommand sqlCommand = new SqlCommand("INSERT INTO MenuTable (idDept,namaMenu,logoMenu,linkMenu,statusMenu) VALUES(@idDept,@namaMenu,@logoMenu,@linkMenu,1)", koneksi);
                                sqlCommand.Parameters.Add(new SqlParameter("@idDept", DepartmentDropDownList.SelectedValue));
                                sqlCommand.Parameters.Add(new SqlParameter("@namaMenu", TxtNamaMenu.Text));
                                sqlCommand.Parameters.Add(new SqlParameter("@logoMenu", logoSql));
                                sqlCommand.Parameters.Add(new SqlParameter("@linkMenu", TextLinkAddress.Text));

                                koneksi.Open();
                                int CheckInsert = sqlCommand.ExecuteNonQuery();

                                if (CheckInsert > 0)
                                {
                                    TxtNamaMenu.Text = null;
                                    TxtNamaMenu.Text = null;
                                    TextLinkAddress.Text = "http://66.96.251.203/";
                                    msgLabel.Text = "Berhasil Upload";
                                }
                                else
                                {
                                    TxtNamaMenu.Text = null;
                                    TxtNamaMenu.Text = null;
                                    TextLinkAddress.Text = "http://66.96.251.203/";
                                    msgLabel.Text = "Gagal Upload";
                                }

                                koneksi.Close();

                            }
                            catch (Exception exx)
                            {
                                msgLabel.Text = exx.Message;
                            }
                        }
                        catch (Exception ex)
                        {
                            msgLabel.Text = ex.ToString();
                        }
                    }
                    else
                    {
                        msgLabel.Text = Extensions + "Ini Bukan Gambar";
                    }
                }
            }
        }
    }
}