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
using System.Security.Cryptography;

namespace VivoExamWeb
{
    public partial class Login : System.Web.UI.Page
    {

        static string connectionString = ConfigurationManager.ConnectionStrings["ApplicationServices_IN"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["userid"] != null)

                    txt_Emp_id.Text = Request.Cookies["userid"].Value;

                if (Request.Cookies["pwd"] != null)

                    txt_password.Attributes.Add("value", Request.Cookies["pwd"].Value);

                if (Request.Cookies["userid"] != null && Request.Cookies["pwd"] != null)
                    chk_Remember.Checked = true;

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "GetUserid";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@user_id", txt_Emp_id.Text.ToString().Trim());
            cmd.Parameters.AddWithValue("@Password", txt_password.Text.ToString().Trim());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["UserId"] = ds.Tables[0].Rows[0]["user_id"].ToString();
                //Session["DepId"] = dr["Deptid"].ToString();
                Session["UserName"] = ds.Tables[0].Rows[0]["user_name"].ToString();
                Session["Edit"] = ds.Tables[0].Rows[0]["Edit"].ToString();
                Session["Deletebtn"] = ds.Tables[0].Rows[0]["Deletebtn"].ToString();
                Session["AddWebUser"] = ds.Tables[0].Rows[0]["AddWebUser"].ToString();
                Session["Dept"] = ds.Tables[0].Rows[0]["user_department"].ToString();
                Session["SubDept"] = ds.Tables[0].Rows[0]["SubDepartment"].ToString();
                Session["RoleType"] = ds.Tables[0].Rows[0]["RoleType"].ToString();
                Session["Factory"] = ds.Tables[0].Rows[0]["Factory"].ToString();

                Session["AddExam"] = ds.Tables[0].Rows[0]["AddExam"].ToString();
                Session["AddQuestionBank"] = ds.Tables[0].Rows[0]["AddQuestionBank"].ToString();
                Session["ViewExamResult"] = ds.Tables[0].Rows[0]["ViewExamResult"].ToString();
                Session["ViewOutSideAccesscheck"] = ds.Tables[0].Rows[0]["ViewOutSideAccesscheck"].ToString();
                Session["DownloadQuestionBankExcel"] = ds.Tables[0].Rows[0]["DownloadQuestionBankExcel"].ToString();
                Session["TraningCenter"] = "False";
                if (Session["Factory"].ToString() == "India Factory")
                {
                    Session["Factory"] = "ApplicationServices_IN";
                }
                if (Session["Dept"] != null && Session["SubDept"] != null)
                {
                    if (Session["Dept"].ToString() == "Training Center" && Session["SubDept"].ToString() == "New Trainees Assessment")
                    {
                        Session["TraningCenter"] = "True";
                    }
                }

                if (chk_Remember.Checked == true)
                {
                    Response.Cookies["userid"].Value = txt_Emp_id.Text;
                    Response.Cookies["pwd"].Value = txt_password.Text;
                    Response.Cookies["userid"].Expires = DateTime.Now.AddDays(15);
                    Response.Cookies["pwd"].Expires = DateTime.Now.AddDays(15);
                }
                else
                {
                    Response.Cookies["userid"].Expires = DateTime.Now.AddDays(-1);

                    Response.Cookies["pwd"].Expires = DateTime.Now.AddDays(-1);
                }
                if (Session["Factory"] != null)
                {
                    Response.Redirect("~/Home.aspx");
                }
                else
                {
                    string message = "Factory is not found";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                }

            }
            else if (ds.Tables[1].Rows.Count > 0)
            {
                Session["UserId"] = ds.Tables[1].Rows[0]["user_id"].ToString();
                //Session["DepId"] = dr["Deptid"].ToString();
                Session["UserName"] = ds.Tables[1].Rows[0]["user_name"].ToString();
                Session["Edit"] = ds.Tables[1].Rows[0]["Edit"].ToString();
                Session["Deletebtn"] = ds.Tables[1].Rows[0]["Deletebtn"].ToString();
                Session["AddWebUser"] = ds.Tables[1].Rows[0]["AddWebUser"].ToString();
                Session["Dept"] = ds.Tables[1].Rows[0]["user_department"].ToString();
                Session["SubDept"] = ds.Tables[1].Rows[0]["SubDepartment"].ToString();
                Session["RoleType"] = ds.Tables[1].Rows[0]["RoleType"].ToString();
                Session["Factory"] = ds.Tables[1].Rows[0]["Factory"].ToString();

                Session["AddExam"] = ds.Tables[1].Rows[0]["AddExam"].ToString();
                Session["AddQuestionBank"] = ds.Tables[1].Rows[0]["AddQuestionBank"].ToString();
                Session["ViewExamResult"] = ds.Tables[1].Rows[0]["ViewExamResult"].ToString();
                Session["ViewOutSideAccesscheck"] = ds.Tables[1].Rows[0]["ViewOutSideAccesscheck"].ToString();
                Session["DownloadQuestionBankExcel"] = ds.Tables[1].Rows[0]["DownloadQuestionBankExcel"].ToString();
                Session["TraningCenter"] = "False";
                if (Session["Factory"].ToString() == "BD Factory")
                {
                    Session["Factory"] = "ApplicationServices_BD";
                }
                if (chk_Remember.Checked == true)
                {
                    Response.Cookies["userid"].Value = txt_Emp_id.Text;
                    Response.Cookies["pwd"].Value = txt_password.Text;
                    Response.Cookies["userid"].Expires = DateTime.Now.AddDays(15);
                    Response.Cookies["pwd"].Expires = DateTime.Now.AddDays(15);
                }
                else
                {
                    Response.Cookies["userid"].Expires = DateTime.Now.AddDays(-1);

                    Response.Cookies["pwd"].Expires = DateTime.Now.AddDays(-1);
                }
                if (Session["Factory"] != null)
                {
                    Response.Redirect("~/Home.aspx");
                }
                else
                {
                    string message = "Factory is not found";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                }
            }
            else if (ds.Tables[2].Rows.Count > 0)
            {
                Session["UserId"] = ds.Tables[2].Rows[0]["user_id"].ToString();
                //Session["DepId"] = dr["Deptid"].ToString();
                Session["UserName"] = ds.Tables[2].Rows[0]["user_name"].ToString();
                Session["Edit"] = ds.Tables[2].Rows[0]["Edit"].ToString();
                Session["Deletebtn"] = ds.Tables[2].Rows[0]["Deletebtn"].ToString();
                Session["AddWebUser"] = ds.Tables[2].Rows[0]["AddWebUser"].ToString();
                Session["Dept"] = ds.Tables[2].Rows[0]["user_department"].ToString();
                Session["SubDept"] = ds.Tables[2].Rows[0]["SubDepartment"].ToString();
                Session["RoleType"] = ds.Tables[2].Rows[0]["RoleType"].ToString();
                Session["Factory"] = ds.Tables[2].Rows[0]["Factory"].ToString();

                Session["AddExam"] = ds.Tables[2].Rows[0]["AddExam"].ToString();
                Session["AddQuestionBank"] = ds.Tables[2].Rows[0]["AddQuestionBank"].ToString();
                Session["ViewExamResult"] = ds.Tables[2].Rows[0]["ViewExamResult"].ToString();
                Session["ViewOutSideAccesscheck"] = ds.Tables[2].Rows[0]["ViewOutSideAccesscheck"].ToString();
                Session["DownloadQuestionBankExcel"] = ds.Tables[2].Rows[0]["DownloadQuestionBankExcel"].ToString();

                if (Session["Factory"].ToString() == "INDO Factory")
                {
                    Session["Factory"] = "ApplicationServices_INF";
                }
                if (chk_Remember.Checked == true)
                {
                    Response.Cookies["userid"].Value = txt_Emp_id.Text;
                    Response.Cookies["pwd"].Value = txt_password.Text;
                    Response.Cookies["userid"].Expires = DateTime.Now.AddDays(15);
                    Response.Cookies["pwd"].Expires = DateTime.Now.AddDays(15);
                }
                else
                {
                    Response.Cookies["userid"].Expires = DateTime.Now.AddDays(-1);

                    Response.Cookies["pwd"].Expires = DateTime.Now.AddDays(-1);
                }
                if (Session["Factory"] != null)
                {
                    Response.Redirect("~/Home.aspx");
                }
                else
                {
                    string message = "Factory is not found";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                }
            }
            else
            {
                string message = "Invalid UserId And Password.";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            }
            con.Close();

        }
    }
}