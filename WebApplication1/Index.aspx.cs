using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
  public partial class Index : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      for (int i = 10; i >= 1; i--)
      {
        QuestionList.Items.Add("Question - " + i);
      }
      for (int i = 1; i <= 4; i++)
      {
        AnswerList.Items.Add("Answer " + i);
      }
    }
  }
}