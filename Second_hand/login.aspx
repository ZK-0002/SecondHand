<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Second_hand.WebForm1" EnableEventValidation="false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="Source/lib/css/bootstrap.min.css" />
    <style>
        body{
            background-image:url(Source/images/hotel4.jpg);
            background-size:cover;
          
        }
        
    </style>
</head>
<body>
       
   
     <form id="form1" runat="server">
        <div>
            <div class="container-fluid">
        <div class="row" style="height:200px"></div>
        <div class="row">
            <div class="col-md-4"></div>
            <div class="col-md-4 bg-light rounded-3">
                <h1 class="text-text-success text-center">校园二手交易平台</h1>
                <form>
                    <div class="mb-3">
                    <label for="UserTb" class="form-label">用户名</label>
                    <input type="text" class="form-control" id="UserTb" runat="server" required="required">
   
                    </div>
                    <div class="mb-3">
                    <label for="PasswordTb" class="form-label">密码</label>
                    <input type="password" class="form-control" id="PasswordTb" runat="server" required="required">
                    </div>

                    <div class="mb-3">
                    <label id="ErrMsg" class="text-danger" runat="server"></label>
                    <input type="radio" id="Admin" runat="server" name="Role"><label class="text-success">管理员</label>
                    <input type="radio" id="User" runat="server" name="Role"><label class="text-success">用户</label>
                    </div>
  
                    <div class="d-grid">
                        <label id="Essmsg" runat="server"></label>
                        <asp:Button ID="LoginBtn" runat="server" Text="登陆" class="btn btn-success btn-block" OnClick="LoginBtn_Click"/>
                    </div>
                    <br />

                    <div class="d-grid">       
                        <a class="nav-link text-block" href="signup.aspx">没有账户？点击注册</a>
                    </div>
                    <br />

            </form>
            </div>
            <div class="col-md-4"></div>
        </div>
        
    </div>
        </div>
    </form>
</body>
</html>
