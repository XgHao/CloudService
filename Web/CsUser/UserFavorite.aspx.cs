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
using CloudService.BLL;
using CloudService.DAO;
using CloudService.Models;

public partial class UserFavorite : System.Web.UI.Page
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
                //清空临时表
                DBHelper.Delete_Data();
                Response.Write("<script>alert('身份过期，请重新登录。');location='../Login.aspx'</script>");
            }
            else
            {            
                HttpCookie cookiee = Request.Cookies.Get("UserIDTableName");
                string ClassName = cookiee.Value;
                Label_Name.Text = DBHelper.GetUserName(isexpire, ClassName);
                Head.ImageUrl = DBHelper.GetHeadImage(isexpire, ClassName);
            }
            BindDataList();
        }
    }

    private void BindDataList()
    {
        DataList1.DataSource = CloudServiceManager.GetAllCloudService();
        DataList1.DataBind();
    }

    protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }

    protected void btnSelect_Click(object sender, EventArgs e)
    {

    }
    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        string isexpire = IsExpire();
        //身份过期
        if (isexpire == "NULL")
        {
            DBHelper.Delete_Data();
            Response.Write("<script>alert('身份过期，请重新登录。');location='../Login.aspx'</script>");
        }
        else
        {
            string cmd = e.CommandName;
            //获取命令参数
            int cloudserviceId = Convert.ToInt32(e.CommandArgument);
            if (cmd == "Edit")
            {
                //转向云服务商详细信息
                Page.Server.Transfer("CloudServiceInfo.aspx?cloudserviceId=" + Convert.ToString(cloudserviceId));
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
