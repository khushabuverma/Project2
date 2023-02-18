<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="VivoExamWeb.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>VivoExam-Login</title>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="stylesheet" href="css/style.css">
</head>
<body style="background-image: linear-gradient(to Right, #f782ff 5%, #1de8d6 107%); height: auto">
    <div class="panda">
        <div class="ear">
        </div>
        <div class="face">
            <div class="eye-shade">
            </div>
            <div class="eye-white">
                <div class="eye-ball">
                </div>
            </div>
            <div class="eye-shade rgt">
            </div>
            <div class="eye-white rgt">
                <div class="eye-ball">
                </div>
            </div>
            <div class="nose">
            </div>
            <div class="mouth">
            </div>
        </div>
        <div class="body">
        </div>
        <div class="foot">
            <div class="finger">
            </div>
        </div>
        <div class="foot rgt">
            <div class="finger">
            </div>
        </div>
        <div class="tale">
        </div>
    </div>
    <form id="form1" runat="server">
    <div class="hand">
    </div>
    <div class="hand rgt">
    </div>
    <h1>
        Vivo Exam</h1>
    <div class="form-group">
        <asp:TextBox ID="txt_Emp_id" runat="server" Height="36px" MaxLength="9" CssClass="form-control"></asp:TextBox>
        <label class="form-label">
            User Id
        </label>
    </div>
    <div class="form-group">
        <asp:TextBox ID="txt_password" runat="server" Height="36px" TextMode="Password" CssClass="form-control"></asp:TextBox>
        <label class="form-label">
            Password</label>
        <asp:Button ID="Button1" runat="server" Text="Login" CssClass="btn" OnClick="Button1_Click" />
        <div class="form-group">
            <asp:CheckBox ID="chk_Remember" runat="server" Text="Remember Me" />
        </div>
    </div>
    </form>
    <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
    <script src="js/index.js"></script>
</body>
</html>
