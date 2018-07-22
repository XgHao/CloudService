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
using CloudService.Models;
using CloudService.DAO;
using System.Data.SqlClient;

public partial class CloudServiceInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {             
            string cloudserviceid = Request.QueryString["cloudserviceId"];
            Label_ID.Text = cloudserviceid;
            string isexpire = IsExpire();
            Label_USerID.Text = isexpire;
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
                UserName.Text = "[" + DBHelper.GetUserName(isexpire, ClassName) + "]";
                CloudService_Name.Text = DBHelper.GetCloudServiceName(cloudserviceid);
                Head.ImageUrl = DBHelper.GetHeadImage(isexpire, ClassName);
                //获取评分平均值
                Label_Score.Text = DBHelper.GetAvgScoreByCsID(cloudserviceid);
                //其他信息
                CloudServer cldser = CloudServiceManager.GetCloudServiceInfoByCloudServiceId(cloudserviceid);
                Image_Logo.ImageUrl = cldser.Logo; 
                lbl_Company.Text = cldser.Company;
                lbl_Name.Text = cldser.CloudServiceName;
                lbl_Comment.Text = cldser.NewComment;
                lbl_Address.Text = cldser.Address; 
                lbl_Website.Text = cldser.WebSite;
            }
        }
    }

    
    //取消收藏
    protected void Button_Dislike_Click(object sender, EventArgs e)
    {
       DBHelper.DeleteCloudService_ID(Label_USerID.Text.Trim(), Label_ID.Text.Trim());
       Page.Server.Transfer("../CsUser/UserFavorite.aspx");

    }
    //评价服务商
    protected void CommentCs_Click(object sender, EventArgs e)
    {
        //转到评论页面
        Page.Server.Transfer("../CsUser/CommentCs.aspx?cloudserviceId=" + Label_ID.Text);
    }
    protected void CloudSerivceComment_Click(object sender, EventArgs e)
    {
        //更多评论
        Page.Server.Transfer("../CsUser/CloudServiceComment.aspx?cloudserviceName=" + lbl_Name.Text.Trim());
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


}
