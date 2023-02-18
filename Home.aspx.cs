using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.IO;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Web.Services;
using System.Globalization;

namespace VivoExamWeb
{
    public partial class Home : System.Web.UI.Page
    {
        static string connectionString = null;
        SqlConnection con = null;
        public static int userid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["Factory"] != null)
                {
                    connectionString = ConfigurationManager.ConnectionStrings[Session["Factory"].ToString()].ConnectionString;
                    con = new SqlConnection(connectionString);
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }

                if (Session["Dept"].ToString() !=  "Engineering")
                {
                    myIframe.Style.Add("Display", "none");
                }

            }
            catch (Exception ex )
            {
                string message = ex.Message.Replace("'", "");
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            }

            if (!IsPostBack)
            {
                if (Session["UserId"] == null)
                {
                    Response.Redirect("~/Login.aspx");
                }
                else
                {
                    GetExamlist();
                }

            }
            //   this.Form.Ifra.Attributes.Add("src", "Login.aspx");
        }
        protected void GetExamlist()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "udp_GetDashboardExamlist";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Dept", Session["Dept"].ToString().Trim());
            cmd.Parameters.AddWithValue("@SubDept", Session["SubDept"].ToString().Trim());
            if (Session["Factory"].ToString() == "ApplicationServices_IN")
            {
                cmd.Parameters.Add("@CurrentTime", SqlDbType.DateTime).Value = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time")).ToString();
            }
            else if (Session["Factory"].ToString() == "ApplicationServices_BD")
            {
                cmd.Parameters.Add("@CurrentTime", SqlDbType.DateTime).Value = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Bangladesh Standard Time")).ToString();
            }
            else if (Session["Factory"].ToString() == "ApplicationServices_INF")
            {
                cmd.Parameters.Add("@CurrentTime", SqlDbType.DateTime).Value = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time")).ToString();
            }
            cmd.Connection = con;
            try
            {
                cmd.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                StringBuilder sb = new StringBuilder();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["ExamStatus"].ToString() == "Active")
                        {
                            sb.Append("<li class='item'>"
                                //+ "<div class='product-img'>"
                                // + "<img src='dist/img/default-150x150.png' alt='product image' class='img-size-50' /></div>"
                     + "<h4>" + dt.Rows[i]["exam_name"] + "</h4>"
                    + "<div class='product-info' style='margin-left:0px'>"
                    + "<span class='badge badge-success float-right'>" + dt.Rows[i]["ExamStatus"] + "</span>"
                    + "<span class='product-description'>"
                        + "Date: " + dt.Rows[i]["exam_start_time"] + " to " + dt.Rows[i]["exam_end_time"] + ""
                      + "</span>"
                  + "</div>"
                  + "</li>");
                        }
                        else
                        {

                            sb.Append("<li class='item'>"
                                //+ "<div class='product-img'>"
                                // + "<img src='dist/img/default-150x150.png' alt='product image' class='img-size-50' /></div>"
                         + "<h4>" + dt.Rows[i]["exam_name"] + "</h4>"
                        + "<div class='product-info' style='margin-left:0px'>"
                        + "<span class='badge badge-success float-right' style='background-color: #b6b4b4;'>" + dt.Rows[i]["ExamStatus"] + "</span>"
                        + "<span class='product-description'>"
                            + "Date: " + dt.Rows[i]["exam_start_time"] + " to " + dt.Rows[i]["exam_end_time"] + ""
                          + "</span>"
                      + "</div>"
                      + "</li>");

                        }

                    }

                }


                ExamItem.InnerHtml = sb.ToString();
            }
            catch (Exception ex)
            {
                string message = ex.Message.Replace("'", "");
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            }
        }


    }
}