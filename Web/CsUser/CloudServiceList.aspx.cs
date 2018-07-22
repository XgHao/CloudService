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
using CloudService.Models;
using CloudService.DAO;
using CloudService.BLL;

public partial class CloudServiceList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
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
                HttpCookie cookiee = Request.Cookies.Get("UserIDTableName");
                string ClassName = cookiee.Value;
                Label_Name.Text = DBHelper.GetUserName(isexpire, ClassName);
                Head.ImageUrl = DBHelper.GetHeadImage(isexpire, ClassName);
            }
            BindClassGridView();
        }
    }

    private void BindClassGridView()
    {
        this.GridView1.DataSource = CloudServiceManager.GetAllCloudServiceList();
        this.GridView1.DataBind();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        BindClassGridView();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //收藏,获取当前云服务商ID
        string cloudserviceid = GridView1.DataKeys[e.RowIndex].Value.ToString();
        //首先判断身份是否过期
        string isexpire = IsExpire();
        if (isexpire == "NULL")
        {
            //清空临时表
            DBHelper.Delete_Data();
            Response.Write("<script>alert('身份过期，请重新登录。');location='../Login.aspx'</script>");
        }
        else
        {
            //获取当前系统时间
            //获取当前时间（精确到秒）
            string CommentTime = DateTime.Now.ToString("yyyy-MM-dd");

            //首先判断该云服务商是否已经收藏过
            if (Exist(cloudserviceid))//不存在，可以收藏
            {
                //生成sql语句，收藏云服务商
                int res = DBHelper.FavoriteCloudService(cloudserviceid, CommentTime);
                //生成sql语句，更新用户表CloudService_ID数据
                DBHelper.UpdateCloudService_ID(isexpire, cloudserviceid);

                if (res == 2)//收藏成功
                {
                    Response.Write("<script>alert('添加成功！');location='../CsUser/CloudServiceList.aspx'</script>");
                }
                else
                {
                    Response.Write("<script>alert('添加失败，未知错误。');location='../CsUser/CloudServiceList.aspx'</script>");
                }
            }
            else//已经存在，不可以收藏
            {
                Response.Write("<script>alert('“我的收藏”中已存在。')</script>");
            }
        }
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {  
        
    }
    
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        BindClassGridView();
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        BindClassGridView();
    }
   
    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        if (GridView1.EditIndex != -1)
        {
            DropDownList dropDownList2 = this.GridView1.Rows[GridView1.EditIndex].Cells[3].FindControl("DropDownList2") as DropDownList;
            HiddenField hiddenField2 = this.GridView1.Rows[GridView1.EditIndex].Cells[3].FindControl("HiddenField2") as HiddenField;
            dropDownList2.SelectedValue = hiddenField2.Value.Trim();
            DropDownList dropDownList1 = this.GridView1.Rows[GridView1.EditIndex].Cells[6].FindControl("DropDownList1") as DropDownList;
            HiddenField hiddenField1 = this.GridView1.Rows[GridView1.EditIndex].Cells[6].FindControl("HiddenField1") as HiddenField;
            dropDownList1.SelectedValue = hiddenField1.Value.Trim();
        }        
    }

    //定义函数
    //1.判断云服务商编号是否被占用
    public bool Exist(string cloudserviceid)
    {
        string sql = "select COUNT(*) from CloudService where CloudServiceID=" + cloudserviceid + ";";
        int usecnt = DBHelper.GetScalar(sql);

        if (usecnt != 0)//存在
            return false;
        else//不存在
            return true;
    }
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

    protected void btnSelect_Click(object sender, EventArgs e)
    {
        int proId = Convert.ToInt32(this.DDL_Pro.SelectedValue);
        if (proId > 0)
        {
            this.GridView1.DataSource = CloudServiceManager.GetAllCloudServiceListByProId(proId);
            this.GridView1.DataBind();
        }
        else if (proId == 0)
        {
            this.GridView1.DataSource = CloudServiceManager.GetAllCloudServiceList();
            this.GridView1.DataBind();
        }
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
