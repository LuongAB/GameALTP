using System;
using System.Data;
using System.Threading;
using System.Web;
using System.Media;

namespace WebApplication1
{
  public partial class Index : System.Web.UI.Page
  {
    DBHelper helper = new DBHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        PlUser.Visible = false;
        btnStop.Visible = false;
        ViewState["countCorrectAnswer"] = -1;
        playSound("music_bg.wav");
      }
    }

    private void playSound(string name)
    {
      SoundPlayer sound = new SoundPlayer();
      sound.SoundLocation = Server.MapPath(name);
      sound.Play();
    }

    private void loadQuestion()
    {
      int count = 0;
      for (int i = 0; i < QuestionList.Items.Count; i++)
      {
        if (QuestionList.Items[i].Selected)
        {
          count++;
        }
      }

      if (count <= 4)
      {
        int idQuestion = 0;
        string qrDE = "sp_Select_CauHoi_DE";
        DataTable table = helper.execQuery(qrDE);
        foreach (DataRow item in table.Rows)
        {
          string a = item[1].ToString();
          idQuestion = int.Parse(item[0].ToString());
          ViewState["IDQuestion"] = idQuestion;
          lbQuestion.Text = a;
        }
        string qr1 = "sp_Select_DapAn";
        string[] pam = { "@idCauHoi" };
        object[] ob = { idQuestion };
        AnswerList.DataSource = helper.execQuery(qr1, pam, ob);
        AnswerList.DataTextField = "NoiDungDapAn";
        AnswerList.DataValueField = "IDDapAn";
        AnswerList.DataBind();
      }

      if (count > 4 && count <= 7)
      {
        btnStop.Visible = true;
        int idQuestion = 0;
        string qrTB = "sp_Select_CauHoi_TB";
        DataTable table = helper.execQuery(qrTB);
        foreach (DataRow item in table.Rows)
        {
          string a = item[1].ToString();
          idQuestion = int.Parse(item[0].ToString());
          ViewState["IDQuestion"] = idQuestion;
          lbQuestion.Text = a;
        }
        string qr1 = "sp_Select_DapAn";
        string[] pam = { "@idCauHoi" };
        object[] ob = { idQuestion };
        AnswerList.DataSource = helper.execQuery(qr1, pam, ob);
        AnswerList.DataTextField = "NoiDungDapAn";
        AnswerList.DataValueField = "IDDapAn";
        AnswerList.DataBind();
      }

      if (count > 7)
      {
        int idQuestion = 0;
        string qrKH = "sp_Select_CauHoi_KHO";
        DataTable table = helper.execQuery(qrKH);
        foreach (DataRow item in table.Rows)
        {
          string a = item[1].ToString();
          idQuestion = int.Parse(item[0].ToString());
          ViewState["IDQuestion"] = idQuestion;
          lbQuestion.Text = a;
        }
        string qr1 = "sp_Select_DapAn";
        string[] pam = { "@idCauHoi" };
        object[] ob = { idQuestion };
        AnswerList.DataSource = helper.execQuery(qr1, pam, ob);
        AnswerList.DataTextField = "NoiDungDapAn";
        AnswerList.DataValueField = "IDDapAn";
        AnswerList.DataBind();
      }
    }

    public void loadTime()
    {
      Page.ClientScript.RegisterClientScriptBlock(GetType(), "loadTimes", "" +
      "<script>" +
        "let timeout = 30;" +
        "const times = setInterval(myFunction, 1000);" +
        "function myFunction()" +
        "{" +
          "let t = document.getElementById('TimeLeft');" +
          "timeout--;" +
          "t.innerText = timeout;" +
          "if (timeout < 0)" +
            "{" +
             "clearInterval(times);" +
             "t.innerText = 'Hết giờ...';" +
            "}" +
        "}" +
      "</script>");
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
      Session["user"] = txtUsername.Text;
      PlLogin.Visible = false;
      PlUser.Visible = true;
      lbName.Text = Session["user"].ToString();
      loadTime();
      loadQuestion();
    }

    protected void AnswerList_SelectedIndexChanged(object sender, EventArgs e)
    {
      string qr = "sp_Select_DapanDung";
      int x = int.Parse(ViewState["IDQuestion"].ToString());
      int m = int.Parse(AnswerList.SelectedValue);
      int a = 0;
      string[] pam = { "@idCauHoi" };
      object[] ob = { x };
      DataTable table = helper.execQuery(qr, pam, ob);
      foreach (DataRow item in table.Rows)
      {
        a = int.Parse(item[0].ToString());
      }
      Thread.Sleep(1000);
      int count = int.Parse(ViewState["countCorrectAnswer"].ToString());
      if (a == m)
      {
        playSound("music_corect.wav");
        Thread.Sleep(3000);
        loadQuestion();
        loadTime();
        count++;
        ViewState["countCorrectAnswer"] = count;
        if (count == 9)
        {
          playSound("music_end.wav");
          Page.ClientScript.RegisterClientScriptBlock(GetType(), "endGame", "" +
          "alert('Bạn đã trở thành triệu phú !')", true);
          string insertUsert = "sp_Insert_User";
          string[] listParam = { "@name", "@score" };
          decimal score = decimal.Parse(Request.Cookies["score"].ToString());
          object[] listValue = { Session["user"].ToString(), score };
          helper.execNonQuery(insertUsert, listParam, listValue);
        }
        else
        {
          for (int i = 0; i <= count; i++)
          {
            QuestionList.Items[i].Selected = true;
          }
        }
      }
      else
      {
        playSound("music_failure.wav");
        Page.ClientScript.RegisterClientScriptBlock(GetType(), "stop", "" +
        "alert('Bạn đã trả lời sai !');", true);
        string insertUsert = "sp_Insert_User";
        string[] listParam = { "@name", "@score" };
        decimal score = decimal.Parse(Request.Cookies["score"].Value);
        object[] listValue = { Session["user"].ToString(), score };
        helper.execNonQuery(insertUsert, listParam, listValue);
        Session.Remove("user");
      }

      int sum = 0;
      HttpCookie ck = new HttpCookie("score");
      for (int i = 0; i < QuestionList.Items.Count; i++)
      {
        if (QuestionList.Items[i].Selected)
        {
          sum += int.Parse(QuestionList.Items[i].Value);
        }
      }
      ck.Value = sum.ToString();
      Response.Cookies.Add(ck);
    }

    protected void btnDel50_Click(object sender, EventArgs e)
    {
      playSound("music_help_50.wav");

    }

    protected void btnCall_Click(object sender, EventArgs e)
    {
      playSound("music_help_call.wav");

    }

    protected void btnStop_Click(object sender, EventArgs e)
    {

    }
  }
}
