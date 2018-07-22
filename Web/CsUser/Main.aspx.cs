using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CloudService.BLL;
using CloudService.DAO;
using CloudService.Models;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //加载用户信息
            //根据时间设置问候语
            int Hour = Convert.ToInt32(DateTime.Now.ToString("HH"));
            if (4 <= Hour && Hour < 11)
                Label_Time.Text = "早上好，";
            else if (11 <= Hour && Hour < 13)
                Label_Time.Text = "中午好，";
            else if (13 <= Hour && Hour < 17)
                Label_Time.Text = "下午好，";
            else if (17 <= Hour)
                Label_Time.Text = "晚上好，";
            else
                Label_Time.Text = "该休息了";

            string isexpire = IsExpire();
            //过期
            if (isexpire == "NULL")
            {
                //清空CloudService临时表
                DBHelper.Delete_Data();
                Response.Write("<script>alert('身份过期，请重新登录。');location='../Login.aspx'</script>");
            }
            else
            {
                Label_Name.Text = DBHelper.GetUserName(isexpire, "CsUser");
                HttpCookie cookiee = Request.Cookies.Get("UserIDTableName");
                Head.ImageUrl = DBHelper.GetHeadImage(isexpire,cookiee.Value);
            }
        }
           
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
    protected void Button_Info_Click(object sender, EventArgs e)
    {
        Response.Write("<script>location='../CsUser/ChangeInfo.aspx'</script>");
    }
}