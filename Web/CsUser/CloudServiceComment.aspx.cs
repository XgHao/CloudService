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

public partial class CloudServiceComment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Label_cloudserviceName.Text = Request.QueryString["cloudserviceName"];
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
                HttpCookie cookiee = Request.Cookies.Get("UserIDTableName");
                string ClassName = cookiee.Value;
                Label_Name.Text = DBHelper.GetUserName(isexpire, ClassName);
                Head.ImageUrl = DBHelper.GetHeadImage(isexpire, ClassName);
            }
            BindClassGridView(Label_cloudserviceName.Text,"全部用户");
        }
    }

    private void BindClassGridView(string Csname, string Username)
    {
        this.GridView1.DataSource = CloudServiceManager.GetCommentByCsIdANDUserId(Csname, Username);
        this.GridView1.DataBind();
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {  

    }
    
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

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
    //1.判断课程编号是否被占用
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
}
