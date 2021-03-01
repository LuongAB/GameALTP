<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebApplication1.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Ai là triệu phú</title>
    <link rel="stylesheet" href="./style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <section class="container">
            <header>
                <nav>
                    <h1>User name</h1>
                    <section class="help">
                        <asp:Button ID="btnDel50" runat="server" Text="50 : 50" CssClass="help_button" />
                        <asp:ImageButton ID="btnAsk" runat="server" ImageUrl="~/icon_help_1.png" />
                    </section>
                </nav>
            </header>
            <main>
                <section class="user">
                    <img src="icon_user.png" alt="icon user 1" />
                    <img src="icon_user.png" alt="icon user 2" />
                    <section class="content">
                        <asp:TextBox ID="TextBox1" runat="server" Columns="50" ReadOnly="True" Rows="10">
                        Question
                        </asp:TextBox>
                        <section class="answer">
                            <asp:RadioButtonList ID="AnswerList" runat="server" RepeatColumns="2">
                            </asp:RadioButtonList>
                        </section>
                    </section>
                </section>
                <h2>Time</h2>
                <aside class="question_list">
                    <asp:CheckBoxList ID="QuestionList" runat="server" RepeatLayout="Flow">
                    </asp:CheckBoxList>
                </aside>
            </main>
        </section>

    </form>
</body>
</html>
