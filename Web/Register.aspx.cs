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

public partial class Reg : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button_Reg_Click(object sender, EventArgs e)
    {
        //获取用户名和密码
        string UserName = TextBox_Name.Text.Trim();
        string UserPassword = TextBox_PW.Text.Trim();
        string Pass_S = FormsAuthentication.HashPasswordForStoringInConfigFile(UserPassword, "MD5");
     
        //获取密保问题及
        string Que = DDL_Que.SelectedValue;
        string Ans = TextBox_Ans.Text.Trim();
        string Ans_S = FormsAuthentication.HashPasswordForStoringInConfigFile(Ans, "MD5");
        //获取Remark
        string Remark = string.Empty;
        if (TextBox_Remark.Text.Length == 0)
            Remark = "改用户未填写";
        else
            Remark = TextBox_Remark.Text.Trim();
        //判断信息是否输入完整
        if (UserName.Length == 0 || UserPassword.Length == 0 || Que == "0" || Ans.Length == 0)
        {
            Response.Write("<script>alert('请填写完整的注册信息！')</script>");
        }
        else if (UserName.Length >= 10)
        {
            Response.Write("<script>alert('用户名太长了，请保持在1~9个字符。')</script>");
        }
        else
        {
            //判断该用户名是否已注册
            if (DBHelper.ExistUser(TextBox_Name.Text.Trim(),"NULL")) //不存在
            {
                //获取StuID
                string ID = DBHelper.GetNewID();
                string cmdText = "INSERT INTO CsUser VALUES ('" + ID + "', '" + UserName + "', '" + Pass_S + "', '" + Remark + "', '" + Que + "', '" + Ans_S + "', '" + "~/images/head/0.png" + "');";
                int res = DBHelper.ExecuteCommand(cmdText);
                if (res == 1)
                {
                    //首先清空CloudService表与UserComment表
                    DBHelper.Delete_Data();
                    //创建与ID对应的CloudService表CloudService表
                    DBHelper.Create_Table(ID);
                    //创建cookie选择用户头像。
                    HttpCookie cookie = new HttpCookie("NewUser");
                    cookie.Value = "NewUser";
                    cookie.Expires = DateTime.Now.Add(new TimeSpan(0, 0, 1, 0));
                    cookie.Values.Add("NewID", ID);
                    cookie.Values.Add("NewTable", "CsUser");
                    Response.Cookies.Add(cookie);
                    Response.Write("<script>alert('注册成功！');location='../ChooseImage.aspx'</script>");
                }
                else
                {
                    Response.Write("<script>alert('注册失败！')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('该用户名已存在！')</script>");
            }
            
        }
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Write("<script>location='../Login.aspx'</script>");
    }
}