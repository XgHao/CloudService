using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CloudService.BLL;
using CloudService.DAO;
using CloudService.Models;

public partial class ChooseImage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpCookie cookie = Request.Cookies.Get("NewUser");
            if(cookie != null)
            {
                Label_ID.Text = cookie.Values["NewID"];
                Label_Table.Text = cookie.Values["NewTable"];
            }
            else
            {
                Response.Write("<script>location='../Login.aspx'</script>");
            }
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string imageurl = ImageButton1.ImageUrl;
        SetImage(Label_ID.Text.Trim(), Label_Table.Text.Trim(), imageurl);
        DeleteCookie();
        Response.Write("<script>location='../Login.aspx'</script>");

    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        string imageurl = ImageButton2.ImageUrl;
        SetImage(Label_ID.Text.Trim(), Label_Table.Text.Trim(), imageurl);
        DeleteCookie();
        Response.Write("<script>location='../Login.aspx'</script>");
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        string imageurl = ImageButton3.ImageUrl;
        SetImage(Label_ID.Text.Trim(), Label_Table.Text.Trim(), imageurl);
        DeleteCookie();
        Response.Write("<script>location='../Login.aspx'</script>");
    }
    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        string imageurl = ImageButton4.ImageUrl;
        SetImage(Label_ID.Text.Trim(), Label_Table.Text.Trim(), imageurl);
        DeleteCookie();
        Response.Write("<script>location='../Login.aspx'</script>");
    }
    protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
    {
        string imageurl = ImageButton5.ImageUrl;
        SetImage(Label_ID.Text.Trim(), Label_Table.Text.Trim(), imageurl);
        DeleteCookie();
        Response.Write("<script>location='../Login.aspx'</script>");
    }
    protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
    {
        string imageurl = ImageButton6.ImageUrl;
        SetImage(Label_ID.Text.Trim(), Label_Table.Text.Trim(), imageurl);
        DeleteCookie();
        Response.Write("<script>location='../Login.aspx'</script>");
    }
    protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
    {
        string imageurl = ImageButton7.ImageUrl;
        SetImage(Label_ID.Text.Trim(), Label_Table.Text.Trim(), imageurl);
        DeleteCookie();
        Response.Write("<script>location='../Login.aspx'</script>");
    }
    protected void ImageButton8_Click(object sender, ImageClickEventArgs e)
    {
        string imageurl = ImageButton8.ImageUrl;
        SetImage(Label_ID.Text.Trim(), Label_Table.Text.Trim(), imageurl);
        DeleteCookie();
        Response.Write("<script>location='../Login.aspx'</script>");
    }
    protected void ImageButton9_Click(object sender, ImageClickEventArgs e)
    {
        string imageurl = ImageButton9.ImageUrl;
        SetImage(Label_ID.Text.Trim(), Label_Table.Text.Trim(), imageurl);
        DeleteCookie();
        Response.Write("<script>location='../Login.aspx'</script>");
    }
    protected void ImageButton10_Click(object sender, ImageClickEventArgs e)
    {
        string imageurl = ImageButton10.ImageUrl;
        SetImage(Label_ID.Text.Trim(), Label_Table.Text.Trim(), imageurl);
        DeleteCookie();
        Response.Write("<script>location='../Login.aspx'</script>");
    }
    protected void ImageButton11_Click(object sender, ImageClickEventArgs e)
    {
        string imageurl = ImageButton11.ImageUrl;
        SetImage(Label_ID.Text.Trim(), Label_Table.Text.Trim(), imageurl);
        DeleteCookie();
        Response.Write("<script>location='../Login.aspx'</script>");
    }
    protected void ImageButton12_Click(object sender, ImageClickEventArgs e)
    {
        string imageurl = ImageButton1.ImageUrl;
        SetImage(Label_ID.Text.Trim(), Label_Table.Text.Trim(), imageurl);
        DeleteCookie();
        Response.Write("<script>location='../Login.aspx'</script>");
    }

    //自定义函数
    public void SetImage(string id, string type, string imageUrl)
    {
        string sql = "update " + type + " set HeadImage='" + imageUrl + "' where UserID='" + id + "';";
        int res = DBHelper.GetScalar(sql);
    }

    public void DeleteCookie()
    {
        HttpCookie cookie = Request.Cookies.Get("NewUser");
        if (cookie != null)
        {
            cookie.Values.Remove("NewID");
            cookie.Values.Remove("NewTable");
            Response.Cookies.Add(cookie);
        }
    }
}