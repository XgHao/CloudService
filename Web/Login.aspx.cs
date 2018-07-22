using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CloudService.BLL;
using CloudService.DAO;
using CloudService.Models;
using System.Web.Security;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button_login_Click(object sender, EventArgs e)
    {
        //获取信息
        string name = TextBox_Name.Text.Trim();
        string PW = TextBox_PW.Text.Trim();
        string UserClass = RadioButtonList1.SelectedValue;
        string Pass_S = FormsAuthentication.HashPasswordForStoringInConfigFile(PW, "MD5");
        //查询用户是否存在
        if (UserClass == "Admin")
        {
            Response.Write("<script>alert('管理员功能正在开发中！');</script>");
        }
        else
        {
            int usecnt = DBHelper.QueryUser(UserClass, name, Pass_S);
            if (usecnt == 1)
            {
                //获取用户ID
                string Iden_ID = string.Empty;
                if (UserClass == "CsUser")
                    Iden_ID = "UserID";
                else if (UserClass == "Admin")
                    Iden_ID = "AdminID";
                string ID = DBHelper.GetID(Iden_ID, UserClass, name); 
                //传递存储用户ID，使用Cookie方法
                HttpCookie cookie = new HttpCookie(Iden_ID + "Name");
                HttpCookie cookiee = new HttpCookie(Iden_ID + "TableName");
                cookie.Value = ID;
                cookiee.Value = UserClass;
                int Hour = 1;
                //选中"免登录"
                if (Cook.Checked)
                {
                    int NowHour = Convert.ToInt32(DateTime.Now.ToString("HH"));
                    Hour = 24 - NowHour;
                }
                //设置Cookie信息过期时效
                cookie.Expires = DateTime.Now.Add(new TimeSpan(0, Hour, 0, 0));
                cookiee.Expires = DateTime.Now.Add(new TimeSpan(0, Hour, 0, 0));
                Response.AppendCookie(cookie);
                Response.AppendCookie(cookiee);
                if (UserClass == "CsUser")
                {
                    //首先清空CloudService表中的数据
                    DBHelper.Delete_Data();
                    //将对应用户CloudService_ID表复制到CloudService表中
                    DBHelper.CopyTable(ID);
                }
                //显示登录成功信息
                if(UserClass == "CsUser")
                    Response.Write("<script>location='../CsUser/Main.aspx'</script>");
                else if(UserClass == "Admin")
                    Response.Write("<script>location='../Admin/Main.aspx'</script>");     
            }
            else
                //显示登录失败信息
                Response.Write("<script>alert('登录失败！');</script>");
        }     
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        //注册页面
        Response.Write("<script>location='../Register.aspx'</script>");
    }
    protected void Button_find_Click1(object sender, EventArgs e)
    {
        //找回密码
        Response.Write("<script>location='../FindPassword.aspx'</script>");
    }
}