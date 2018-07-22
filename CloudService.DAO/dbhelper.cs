using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CloudService.DAO
{
    public static class DBHelper
    {
        //数据库连接属性
        private static SqlConnection connection;
        public static SqlConnection Connection
        {
            get
            {
                string connectionString = ConfigurationSettings.AppSettings["dbconn"];
                if (connection == null)
                {
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                }
                else if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                else if (connection.State == System.Data.ConnectionState.Broken)
                {
                    connection.Close();
                    connection.Open();
                }
                return connection;
            }
        }
        /// <summary>
        /// 执行无参SQL语句
        /// </summary>
        public static int ExecuteCommand(string safeSql)
        {
            SqlCommand cmd = new SqlCommand(safeSql, Connection);
            int result = cmd.ExecuteNonQuery();
            return result;
        }
        /// <summary>
        /// 执行带参SQL语句
        /// </summary>
        public static int ExecuteCommand(string sql, params SqlParameter[] values)
        {
            SqlCommand cmd = new SqlCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            return cmd.ExecuteNonQuery();
        }
        /// <summary>
        /// 执行无参SQL语句，并返回执行记录数
        /// </summary>
        public static int GetScalar(string safeSql)
        {
            SqlCommand cmd = new SqlCommand(safeSql, Connection);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            return result;
        }
        /// <summary>
        /// 执行无参SQL语句，并返回查询值
        /// </summary>
        public static string GetStringScalar(string safeSql)
        {
            SqlCommand cmd = new SqlCommand(safeSql, Connection);
            string data = cmd.ExecuteScalar().ToString();
            return data;
        }
        /// <summary>
        /// 执行有参SQL语句，并返回执行记录数
        /// </summary>
        public static int GetScalar(string sql, params SqlParameter[] values)
        {
            SqlCommand cmd = new SqlCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            return result;
        }
        /// <summary>
        /// 执行无参SQL语句，并返回SqlDataReader
        /// </summary>
        public static SqlDataReader GetReader(string safeSql)
        {
            SqlCommand cmd = new SqlCommand(safeSql, Connection);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        /// <summary>
        /// 执行有参SQL语句，并返回SqlDataReader
        /// </summary>
        public static SqlDataReader GetReader(string sql, params SqlParameter[] values)
        {
            SqlCommand cmd = new SqlCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }

        public static DataTable GetDataSet(string safeSql)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(safeSql, Connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds.Tables[0];
        }

        public static DataTable GetDataSet(string sql, params SqlParameter[] values)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds.Tables[0];
        }

        //以下为对CloudService表的操作

        /// <summary>
        /// 复制表数据，将对应用户CloudService_ID表复制到CloudService表中,参数为用户ID
        /// </summary>
        /// <param name="ID"></param>
        public static void CopyTable(string ID)
        {
            //sql语句
            string sql = "insert into CloudService select * from CloudService_" + ID + ";";
            int res = DBHelper.ExecuteCommand(sql);
        }

        /// <summary>
        /// 清空CloudService与UserComment临时表数据
        /// </summary>
        public static void Delete_Data()
        {
            string sql = "delete from CloudService;" 
                        + "delete from UserComment where CommentID > 0;";
            int res = DBHelper.ExecuteCommand(sql);
        }

        /// <summary>
        /// 获取用户ID,参数需要需要查找的用户_ID，用户类型，用户名
        /// </summary>
        /// <param name="Iden_ID"></param>
        /// <param name="UserClass"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetID(string Iden_ID, string UserClass, string name)
        {
            //SQL语句
            string sql = "select " + Iden_ID + " from " + UserClass + "  where UserName='" + name + "';";
            string ID = DBHelper.GetStringScalar(sql);
            return ID;
        }

        /// <summary>
        /// 注册时获取新用户ID编号
        /// </summary>
        /// <param name="UserClass"></param>
        /// <returns></returns>
        public static string GetNewID()
        {
            string sql = "select Max(UserID) UserID from CsUser;";
            string res = (DBHelper.GetScalar(sql) + 1).ToString();
            return res;
        }

        /// <summary>
        /// 评价时获取新评论ID编号，需要参数云服务id
        /// </summary>
        /// <param name="commentid"></param>
        /// <returns></returns>
        public static string GetNewCommentID(string commentid)
        {
            string sql = "select Max(CommentID) CommentID from UserComment_" + commentid + ";";
            string res = (DBHelper.GetScalar(sql) + 1).ToString();
            return res;
        }

        /// <summary>
        /// 创建新用户所属的新表CloudService_ID需要新用户参数ID
        /// </summary>
        /// <param name="ID"></param>
        public static void Create_Table(string ID)
        {
            string NewCloudService_Table = "CloudService_" + ID;
            string sql = "select * into " + NewCloudService_Table + " from CloudService where 1=1;";
            int res = DBHelper.ExecuteCommand(sql);
        }

        /// <summary>
        /// 用于登录查询用户是否存在,需要参数用户表UserClass，用户名与密码（name，PW）
        /// </summary>
        /// <param name="UserClass"></param>
        /// <param name="name"></param>
        /// <param name="PW"></param>
        /// <returns></returns>
        public static int QueryUser(string UserClass, string name, string PW)
        {
            string sql = "select COUNT(*) from " + UserClass + "  where UserName='" + name + "' and UserPW='" + PW + "';";
            int usecnt = DBHelper.GetScalar(sql);
            return usecnt;
        }
        /// <summary>
        /// 查询用户名是否已经存在，存在返回false，不存在返回true
        /// </summary>
        /// <param name="username"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static bool ExistUser(string username,string userid)
        {
            string sql = "select COUNT(*) from CsUser where UserName='" + username + "';";
            int usecnt = DBHelper.GetScalar(sql);
            //查找到一个
            if (usecnt >= 1 )
            {
                if (userid == "NULL")//注册时
                {
                    return false;//存在
                }
                else//修改时
                {
                    //判断是不是目前的用户名
                    if (DBHelper.GetUserName(userid, "CsUser").Equals(username))
                    {
                        //是目前的
                        return true;//不存在
                    }
                    else
                        return false;//存在
                }            
            }
            else
                return true;//不存在
        }

        /// <summary>
        /// 收藏云服务商，需要参数服务商ID（cloudserviceid），评论时间（CommentTime）
        /// </summary>
        /// <param name="cloudserviceid"></param>
        /// <param name="CommentTime"></param>
        /// <returns></returns>
        public static int FavoriteCloudService(string cloudserviceid, string CommentTime)
        {
            string sql = "insert into CloudService select * from CloudServiceList where CloudServiceID='" + cloudserviceid + "';" +
                                    "UPDATE CloudService SET Ctime = '" + CommentTime + "' WHERE CloudServiceID ='" + cloudserviceid + "';";
            int res = DBHelper.ExecuteCommand(sql);
            return res;
        }

        /// <summary>
        /// 更新用户表CloudService_ID，参数表ID（isexpire）,云服务商编号（cloudserviceid）
        /// </summary>
        /// <param name="isexpire"></param>
        /// <param name="cloudserviceid"></param>
        public static void UpdateCloudService_ID(string isexpire, string cloudserviceid)
        {
            string sql = "insert into CloudService_" + isexpire + " select * from CloudService where CloudServiceID='" + cloudserviceid + "';";
            int res = DBHelper.ExecuteCommand(sql);
        }

        /// <summary>
        /// 更新用户信息，参数表ID（isexpire）,各种信息
        /// </summary>
        /// <param name="isexpire"></param>
        /// <param name="username"></param>
        /// <param name="userpw"></param>
        /// <param name="remark"></param>
        /// <param name="ans"></param>
        public static void UpdateUserInfo(string isexpire, string username,string userpw,string remark,string ans)
        {
            string sql = "update CsUser set UserName='" + username + "',UserPW='" + userpw + "',Remark='" + remark + "',Ans='" + ans + "' where UserID='" + isexpire + "';";
            int res = DBHelper.ExecuteCommand(sql);
        }
        /// <summary>
        /// 判断密保信息是否正确
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="Que"></param>
        /// <param name="Ans"></param>
        /// <returns></returns>
        public static bool JugInfo(string userid,string Que, string Ans)
        {
            string sql = "select COUNT(*) from CsUser where Que = '" + Que + "' and Ans = '" + Ans + "' and UserID = '" + userid + "';";
            int usecnt = DBHelper.GetScalar(sql);
            if (usecnt >= 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 评价，需要参数云服务商编号（cloudservieId），评价时间（ComTime），评价内容（MoreInfo），评分（Score）
        /// </summary>
        /// <param name="cloudservieId"></param>
        /// <param name="ComTime"></param>
        /// <param name="MoreInfo"></param>
        /// <param name="Score"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static int CommentCloudService(string cloudservieId, string ComTime, string MoreInfo, string Score, string userid)
        {
            //首先获取评论序号
            string newid = DBHelper.GetNewCommentID(cloudservieId);
            string commenter = DBHelper.GetUserName(userid,"CsUser");
            string cloudservicename = DBHelper.GetCloudServiceName(cloudservieId);
            string sql = "INSERT INTO UserComment_" + cloudservieId + " VALUES ('" + newid + "', '" + commenter + "', '" + cloudservicename + "', '" + Score + "', '" + MoreInfo + "', '" + ComTime + "');"
                + "INSERT INTO UserComment select * from UserComment_" + cloudservieId + " where CommentID='" + newid + "';"
                + "UPDATE CloudServiceList set NewComment='" + MoreInfo + "' where CloudServiceID='" + cloudservieId + "';"
                + "INSERT INTO CommentList VALUES ('" + commenter + "', '" + cloudservicename + "', '" + Score + "', '" + MoreInfo + "', '" + ComTime + "');";
            int res = DBHelper.ExecuteCommand(sql);
            return res;
        }
        /// <summary>
        /// 取消收藏，需要参数用户ID和服务商ID
        /// </summary>
        /// <param name="isexpire"></param>
        /// <param name="cloudserviceId"></param>
        /// <returns></returns>
        public static void DeleteCloudService_ID(string isexpire, string cloudserviceId)
        {
            string sql = "DELETE FROM CloudService_" + isexpire + " WHERE CloudServiceID='" + cloudserviceId + "';"
                + "DELETE FROM CloudService WHERE CloudServiceID='" + cloudserviceId + "';";
            int res = DBHelper.ExecuteCommand(sql);
        }
        /// <summary>
        /// 获取用户个性签名
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static string GetUserRemark(string userId)
        {
            string sql = "select Remark from CsUser where UserID='" + userId + "';";
            string Remark = DBHelper.GetStringScalar(sql);
            return Remark;
        }
        /// <summary>
        /// 查找用户名
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="UserClass"></param>
        /// <returns></returns>
        public static string GetUserName(string UserID, string UserClass)
        {
            string sql = "select UserName from " + UserClass + " where UserID='" + UserID + "';";
            string name = DBHelper.GetStringScalar(sql);
            return name;
        }
        /// <summary>
        /// 获取云服务商名根据云服务商ID
        /// </summary>
        /// <param name="cloudserviceid"></param>
        /// <returns></returns>
        public static string GetCloudServiceName(string cloudserviceid)
        {
            string sql = "select CloudServiceName from CloudServiceList where CloudServiceID = " + cloudserviceid + ";";
            string name = DBHelper.GetStringScalar(sql);
            return name;
        }
        /// <summary>
        /// 获取云服务商公司名根据云服务商ID
        /// </summary>
        /// <param name="cloudserviceid"></param>
        /// <returns></returns>
        public static string GetCloudServiceCompany(string cloudserviceid)
        {
            string sql = "select Company from CloudServiceList where CloudServiceID = " + cloudserviceid + ";";
            string name = DBHelper.GetStringScalar(sql);
            return name;
        }
        /// <summary>
        /// 获取云服务商的类别ID根据云省份ID
        /// </summary>
        /// <param name="cloudserviceid"></param>
        /// <returns></returns>
        public static string GetCloudServiceProid(string cloudserviceid)
        {
            string sql = "select ProID from CloudServiceList where CloudServiceID = " + cloudserviceid + ";";
            string proid = DBHelper.GetStringScalar(sql);
            return proid;
        }
        /// <summary>
        /// 获取用户头像
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="UserClass"></param>
        /// <returns></returns>
        public static string GetHeadImage(string UserID,string UserClass)
        {
            string sql = "select HeadImage from " + UserClass + " where UserID='" + UserID + "';";
            string HeadImage = DBHelper.GetStringScalar(sql);
            return HeadImage;
        }
        /// <summary>
        /// 查询对应服务商的平均评分
        /// </summary>
        /// <param name="cloudserviceid"></param>
        /// <returns></returns>
        public static string GetAvgScoreByCsID(string cloudserviceid)
        {
            string sql = "select avg(Score) from UserComment_" + cloudserviceid + " Where CommentID > 0;";
            string score = DBHelper.GetStringScalar(sql);
            return score;
        }
        /// <summary>
        /// 删除对应评论
        /// </summary>
        /// <param name="Ctime"></param>
        /// <param name="username"></param>
        public static void DeleteComment(string Ctime, string username)
        {
            //首先根据Ctime获取对应的云服务商
            string sql = "select CloudServiceName from CommentList where Ctime = '" + Ctime + "';";
            string CsName = DBHelper.GetStringScalar(sql);
            //根据云服务商获取对应编号
            string sqll = "select CloudServiceID from CloudServiceList where CloudServiceName = '" + CsName + "';";
            string CsID = DBHelper.GetStringScalar(sqll);
            //删除评论
            string sqlll = "delete from CommentList where Ctime='" + Ctime + "' and CloudServiceName = '" + CsName + "';"
                            + "delete from UserComment_" + CsID + " where Ctime='" + Ctime + "' and CloudServiceName = '" + CsName + "';";
            DBHelper.ExecuteCommand(sqlll);
        }
    }
}
