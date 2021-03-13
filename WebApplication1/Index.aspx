<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebApplication1.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Ai là triệu phú</title>
    <link rel="shortcut icon" type="image/x-icon" href="~/favicon.ico" />
    <link rel="stylesheet" href="./style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <section class="container">

            <header>
                <img src="logo.png" alt="logo" id="logo" />
                <asp:PlaceHolder ID="PlLogin" runat="server">
                    <section class="PlLogin">
                        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                        <asp:Button Text="Chơi" runat="server" ID="btnLogin" OnClick="btnLogin_Click" />
                        <asp:RequiredFieldValidator ControlToValidate="txtUsername" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Bạn cần nhập tên người chơi"></asp:RequiredFieldValidator><br />
                    </section>
                </asp:PlaceHolder>
                <asp:PlaceHolder ID="PlUser" runat="server">
                    <label>Người chơi : </label>
                    <asp:Label ID="lbName" runat="server" Text="Name"></asp:Label>
                </asp:PlaceHolder>

                <section class="help">
                    <asp:Button ID="btnDel50" runat="server" Text="50 : 50" CssClass="help_button" OnClick="btnDel50_Click" />
                    <asp:Button ID="btnCall" runat="server" Text="Gọi điện" OnClick="btnCall_Click" />
                </section>
                <asp:Button ID="btnStop" runat="server" Text="Dừng chơi !" OnClick="btnStop_Click" />
            </header>

            <section class="wrapp_content">
                <main>
                    <section class="user">
                        <img class="icon_user" src="icon_user.png" alt="icon user 1" />
                        <img class="icon_user" src="icon_user.png" alt="icon user 2" />
                        <label id="TimeLeft">30</label>
                    </section>
                    <section class="content">
                        <asp:Label ID="lbQuestion" runat="server" Text="Question"></asp:Label><br />
                        <section class="answer">
                            <asp:RadioButtonList ID="AnswerList" runat="server" RepeatColumns="2" OnSelectedIndexChanged="AnswerList_SelectedIndexChanged" AutoPostBack="True">
                            </asp:RadioButtonList>
                        </section>
                    </section>
                </main>

                <aside class="question_list">
                    <hr />
                    <asp:CheckBoxList ID="QuestionList" runat="server" RepeatLayout="Flow" Enabled="False">
                        <asp:ListItem Value="100">Câu 1 - 100</asp:ListItem>
                        <asp:ListItem Value="200">Câu 2 - 200</asp:ListItem>
                        <asp:ListItem Value="500">Câu 3 - 500</asp:ListItem>
                        <asp:ListItem Value="800">Câu 4 - 800</asp:ListItem>
                        <asp:ListItem Value="1000">Câu 5 - 1000</asp:ListItem>
                        <asp:ListItem Value="1200">Câu 6 - 1200</asp:ListItem>
                        <asp:ListItem Value="1400">Câu 7 - 1400</asp:ListItem>
                        <asp:ListItem Value="1700">Câu 8 - 1700</asp:ListItem>
                        <asp:ListItem Value="1900">Câu 9 - 1900</asp:ListItem>
                        <asp:ListItem Value="3000">Câu 10 - 3000</asp:ListItem>
                    </asp:CheckBoxList>
                </aside>
            </section>

        </section>
    </form>
</body>
</html>
