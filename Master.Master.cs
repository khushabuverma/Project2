using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VivoExamWeb
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserId"] != null)
                {
                    lblUsername.Text = Session["UserName"].ToString();
                    Session["UserName"] = Session["UserName"].ToString();
                    Session["UserId"] = Session["UserId"].ToString();

                    AddWebuser.Visible = Convert.ToBoolean(Session["AddWebUser"]);
                    AddExamResult.Visible = Convert.ToBoolean(Session["ViewExamResult"]);
                    AddExam.Visible = Convert.ToBoolean(Session["AddExam"]);
                    AddExamInstruction.Visible = Convert.ToBoolean(Session["AddExam"]);
                    AddQuestionBank.Visible = Convert.ToBoolean(Session["AddQuestionBank"]);
                    if (Session["Factory"].ToString() == "BD Factory")
                    {
                        GotoFeedbackURL.HRef = "http://172.24.140.14:8089/Login.aspx?UserId=" + Session["UserId"];
                    }
                    else
                    {
                        GotoFeedbackURL.HRef = "http://172.24.140.14:8089/Login.aspx?UserId=" + Session["UserId"];
                    }
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }

                if (Session["RoleType"].ToString() == "DepartmentAdmin")
                {
                    ExamCategory.Attributes.Add("style", "Display:none");
                }
                else
                {
                    ExamCategory.Attributes.Add("style", "Display:none");
                }
                if (Session["TraningCenter"].ToString() == "True")
                {
                    AddExamResult_TrainingTream.Attributes.Add("style", "Display:Block");
                    ExaminationCode.Attributes.Add("style", "Display:Block");
                    AddExamResult.Attributes.Add("style", "Display:none");
                }
                else
                {
                    AddExamResult_TrainingTream.Attributes.Add("style", "Display:none");
                    ExaminationCode.Attributes.Add("style", "Display:none");
                    AddExamResult.Attributes.Add("style", "Display:Block");
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Login.aspx");
            }
        }
    }
}