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

public partial class FindPW : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button_Reg_Click(object sender, EventArgs e)
    {
        //获取用户名和密码
        string UserName = TextBox_Name.Text.Trim();
        string NewPassword = TextBox_PW.Text.Trim();
        string Pass_S = FormsAuthentication.HashPasswordForStoringInConfigFile(NewPassword, "MD5");
     
        //获取密保问题及
        string Que = DDL_Que.SelectedValue;
        string Ans = TextBox_Ans.Text.Trim();
        string Ans_S = FormsAuthentication.HashPasswordForStoringInConfigFile(Ans, "MD5");

        //判断信息是否输入完整
        if (UserName.Length == 0 || NewPassword.Length == 0 || Que == "0" || Ans.Length == 0)
        {
            Response.Write("<script>alert('请填写完整的注册信息！')</script>");
        }
        else
        {
            //判断该用户名是否已注册
            if (DBHelper.ExistUser(TextBox_Name.Text.Trim(),"NULL")) //不存在
            {
                Response.Write("<script>alert('该用户名未被注册')</script>");

            }
            else
            {
                //检查密保信息是否正确
                string cmdText = "select COUNT(*) from CsUser where UserName='" + UserName + "' and Que='" + Que + "' and Ans='" + Ans_S + "';";
                int res = DBHelper.GetScalar(cmdText);
                if (res >= 1)
                {
                    string sql = "update CsUser set UserPW='" + Pass_S + "' where UserName='" + UserName + "';";
                    int cnt = DBHelper.ExecuteCommand(sql);
                    if(cnt == 1)
                        Response.Write("<script>alert('密码修改成功。');location='../Login.aspx'</script>");
                }
                else
                {
                    Label_Ser.Visible = true;
                }
            }
            
        }
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Write("<script>location='../Login.aspx'</script>");
    }
}