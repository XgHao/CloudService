using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CloudService.BLL;
using CloudService.DAO;
using CloudService.Models;

public partial class CommentCs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            Label_cloudserID.Text = Request.QueryString["cloudserviceId"];
            string isexpire = IsExpire();
            //过期
            if (isexpire == "NULL")
            {
                //清空临时表
                DBHelper.Delete_Data();
                Response.Write("<script>alert('身份过期，请重新登录。');location='../Login.aspx'</script>");
            }
            else
            {
                string cloudserviceId = Label_cloudserID.Text.Trim();
                lbl_Company.Text = DBHelper.GetCloudServiceCompany(cloudserviceId);
                //个人信息
                CloudService_Name.Text = DBHelper.GetCloudServiceName(cloudserviceId);
                HttpCookie cookiee = Request.Cookies.Get("UserIDTableName");
                string ClassName = cookiee.Value;
                User_Name.Text = DBHelper.GetUserName(isexpire, ClassName);
                Head.ImageUrl = DBHelper.GetHeadImage(isexpire, ClassName);
            }
        }
    }
    //评论
    protected void Cancel_Click(object sender, EventArgs e)
    {
        //判断身份是否过期
        //过期
        string isexpire = IsExpire();
        if (isexpire == "NULL")
        {
            //清空临时表
            DBHelper.Delete_Data();
            Response.Write("<script>alert('身份过期，请重新登录。');location='../Login.aspx'</script>");
        }
        else
        {
            //获取各字段信息
            string cloudserviceId = Label_cloudserID.Text.Trim();
            string CTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");  //评论时间
            string QuickCom = GetQuickComment("");
            string Company = lbl_Company.Text.Trim();
            string AllCom = string.Empty;
            string score = Label_score.Text.Trim();
            if (score == "0")
            {
                Response.Write("<script>alert('还没评分哦~')</script>");
            }
            else
            {
                if (TextBox_more.Text.Length >= 0)
                    AllCom = QuickCom + " -- " + TextBox_more.Text.Trim();
                //发表评论
                int res = DBHelper.CommentCloudService(cloudserviceId, CTime, AllCom, score, isexpire);
                Response.Write("<script>alert('评价完成。');location='../CsUser/CommentList.aspx'</script>");
            }       
        }
    }

    //加粗文本框
    protected void Button_Bold_Click(object sender, EventArgs e)
    {
        if (TextBox_more.Font.Bold.ToString() == "True")
            TextBox_more.Font.Bold = false;
        else
            TextBox_more.Font.Bold = true;
    }
    //下划线文本框
    protected void Button_Under_Click(object sender, EventArgs e)
    {
        if (TextBox_more.Font.Underline.ToString() == "True")
            TextBox_more.Font.Underline = false;
        else
            TextBox_more.Font.Underline = true;
    }
    //斜体文本框
    protected void Button_Italic_Click(object sender, EventArgs e)
    {
        if (TextBox_more.Font.Italic.ToString() == "True")
            TextBox_more.Font.Italic = false;
        else
            TextBox_more.Font.Italic = true;
    }
    //清空文本框
    protected void Button_Clear_Click(object sender, EventArgs e)
    {
        TextBox_more.Text = "";
    }
    protected void Button_addF_Click(object sender, EventArgs e)
    {
        if (TextBox_more.Font.Size.ToString() != "XX-Large")
            TextBox_more.Font.Size = FontUnit.XXLarge;
        else
            TextBox_more.Font.Size = FontUnit.XLarge;
    }
    protected void Button_subF_Click(object sender, EventArgs e)
    {
        if (TextBox_more.Font.Size.ToString() != "Large")
            TextBox_more.Font.Size = FontUnit.Large;
        else
            TextBox_more.Font.Size = FontUnit.XLarge;
    }
    //自定义函数
    //判断Cookie是否过期，过期返回NULL否则返回该值
    public string IsExpire()
    {
        HttpCookie cookie = Request.Cookies.Get("UserIDName");
        //如果Cookie过期
        if (cookie == null || cookie.Value == string.Empty)
            return "NULL"; //已过期
        else
            return cookie.Value; //没有过期
    }
    protected void Button_Logout_Click(object sender, EventArgs e)
    {
        //清空Cookie信息
        HttpCookie cookie = Response.Cookies.Get("UserIDName");
        HttpCookie cookiee = Response.Cookies.Get("UserIDTableName");
        cookie.Value = string.Empty;
        cookiee.Value = string.Empty;
        Response.Cookies.Add(cookie);
        Response.Cookies.Add(cookiee);
        Response.Write("<script>location='../Login.aspx'</script>");
    }

    //快速评价
    public string GetQuickComment(string com)
    {
        if (RB1.Checked)
            com = com + "[" + RB1.Text + "]";
        if (RB2.Checked)
            com = com + "[" + RB2.Text + "]";
        if (RB3.Checked)
            com = com + "[" + RB3.Text + "]";
        if (RB4.Checked)
            com = com + "[" + RB4.Text + "]";
        if (RB5.Checked)
            com = com + "[" + RB5.Text + "]";
        if (RB6.Checked)
            com = com + "[" + RB6.Text + "]";
        return com;
    }

    //评分系统
    protected void Score1_Click(object sender, ImageClickEventArgs e)
    {
        Score1.ImageUrl = "~/images/system/Yes.png";
        Score2.ImageUrl = "~/images/system/No.png";
        Score3.ImageUrl = "~/images/system/No.png";
        Score4.ImageUrl = "~/images/system/No.png";
        Score5.ImageUrl = "~/images/system/No.png";
        Label_score.Text = "1";
    }
    protected void Score2_Click(object sender, ImageClickEventArgs e)
    {
        Score1.ImageUrl = "~/images/system/Yes.png";
        Score2.ImageUrl = "~/images/system/Yes.png";
        Score3.ImageUrl = "~/images/system/No.png";
        Score4.ImageUrl = "~/images/system/No.png";
        Score5.ImageUrl = "~/images/system/No.png";
        Label_score.Text = "2";
    }
    protected void Score3_Click(object sender, ImageClickEventArgs e)
    {
        Score1.ImageUrl = "~/images/system/Yes.png";
        Score2.ImageUrl = "~/images/system/Yes.png";
        Score3.ImageUrl = "~/images/system/Yes.png";
        Score4.ImageUrl = "~/images/system/No.png";
        Score5.ImageUrl = "~/images/system/No.png";
        Label_score.Text = "3";
    }
    protected void Score4_Click(object sender, ImageClickEventArgs e)
    {
        Score1.ImageUrl = "~/images/system/Yes.png";
        Score2.ImageUrl = "~/images/system/Yes.png";
        Score3.ImageUrl = "~/images/system/Yes.png";
        Score4.ImageUrl = "~/images/system/Yes.png";
        Score5.ImageUrl = "~/images/system/No.png";
        Label_score.Text = "4";
    }
    protected void Score5_Click(object sender, ImageClickEventArgs e)
    {
        Score1.ImageUrl = "~/images/system/Yes.png";
        Score2.ImageUrl = "~/images/system/Yes.png";
        Score3.ImageUrl = "~/images/system/Yes.png";
        Score4.ImageUrl = "~/images/system/Yes.png";
        Score5.ImageUrl = "~/images/system/Yes.png";
        Label_score.Text = "5";
    }
}