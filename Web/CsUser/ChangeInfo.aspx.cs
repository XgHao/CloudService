using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Drawing;
using CloudService.Models;
using CloudService.DAO;
using CloudService.BLL;

public partial class ChangeInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //加载用户信息
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
                HttpCookie cookiee = Request.Cookies.Get("UserIDTableName");
                string ClassName = cookiee.Value;
                TextBox_Name.Text = DBHelper.GetUserName(isexpire, ClassName);
                ImageButton1.ImageUrl = DBHelper.GetHeadImage(isexpire, ClassName);
                TextBox_Remark.Text = DBHelper.GetUserRemark(isexpire);
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
        HttpCookie cookie = Response.Cookies.Get("StuIDName");
        HttpCookie cookiee = Response.Cookies.Get("StuIDTableName");
        cookie.Value = string.Empty;
        cookiee.Value = string.Empty;
        Response.Cookies.Add(cookie);
        Response.Cookies.Add(cookiee);
        Response.Write("<script>location='../Login.aspx'</script>");
    }
    protected void Button_Chan_Click(object sender, EventArgs e)
    {
        //加载用户信息
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
            if (Button_Chan.Text.Equals("修改信息"))
            {
                TextBox_Name.ReadOnly = false;
                TextBox_PW.ReadOnly = false;
                TextBox_Ans.ReadOnly = false;
                TextBox_Remark.ReadOnly = false;
                TextBox_Name.BackColor = Color.White;
                TextBox_Name.ForeColor = Color.Black;
                TextBox_Remark.BackColor = Color.White;
                TextBox_Remark.ForeColor = Color.Black;
                Button_Chan.Text = "提交信息";
            }
            else
            {
                if (TextBox_Name.Text.Length != 0 && TextBox_Ans.Text.Length != 0 && TextBox_PW.Text.Length != 0 && TextBox_Remark.Text.Length != 0 && DDL_Que.SelectedValue != "请选择密保问题")
                {
                    //修改信息
                    string username = TextBox_Name.Text.Trim();
                    string Que = DDL_Que.SelectedValue;
                    string Ans = TextBox_Ans.Text.Trim();
                    string Ans_S = FormsAuthentication.HashPasswordForStoringInConfigFile(Ans, "MD5");
                    //判断该用户名是否存在
                    if(DBHelper.ExistUser(username,isexpire)) //不存在
                    {
                        //判断密保信息是否正确
                        if (DBHelper.JugInfo(isexpire, Que, Ans_S))
                        {
                            //获取各字段信息
                            string UserPassword = TextBox_PW.Text.Trim();
                            string Pass_S = FormsAuthentication.HashPasswordForStoringInConfigFile(UserPassword, "MD5");
                            string Remark = TextBox_Remark.Text.Trim();
                            DBHelper.UpdateUserInfo(isexpire, username, Pass_S, Remark, Ans_S);
                            TextBox_Name.ReadOnly = true;
                            TextBox_PW.ReadOnly = true;
                            TextBox_Ans.ReadOnly = true;
                            TextBox_Remark.ReadOnly = true;
                            TextBox_Name.BackColor = ColorTranslator.FromHtml("#D04F44");
                            TextBox_Name.ForeColor = ColorTranslator.FromHtml("#B6CFE0");
                            TextBox_Remark.BackColor = ColorTranslator.FromHtml("#D04F44");
                            TextBox_Remark.ForeColor = ColorTranslator.FromHtml("#B6CFE0");
                            Button_Chan.Text = "修改信息";
                            Response.Write("<script>alert('信息修改成功！')</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('密保问题错误，身份认证失败')</script>");
                        }                 
                    }
                    else
                    {
                        Response.Write("<script>alert('该用户名已存在！')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('请填写完整的信息，再提交')</script>");
                }

            }   
        }
    }
}
