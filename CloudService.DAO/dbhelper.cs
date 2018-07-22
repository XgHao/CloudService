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
        //���ݿ���������
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
        /// ִ���޲�SQL���
        /// </summary>
        public static int ExecuteCommand(string safeSql)
        {
            SqlCommand cmd = new SqlCommand(safeSql, Connection);
            int result = cmd.ExecuteNonQuery();
            return result;
        }
        /// <summary>
        /// ִ�д���SQL���
        /// </summary>
        public static int ExecuteCommand(string sql, params SqlParameter[] values)
        {
            SqlCommand cmd = new SqlCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            return cmd.ExecuteNonQuery();
        }
        /// <summary>
        /// ִ���޲�SQL��䣬������ִ�м�¼��
        /// </summary>
        public static int GetScalar(string safeSql)
        {
            SqlCommand cmd = new SqlCommand(safeSql, Connection);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            return result;
        }
        /// <summary>
        /// ִ���޲�SQL��䣬�����ز�ѯֵ
        /// </summary>
        public static string GetStringScalar(string safeSql)
        {
            SqlCommand cmd = new SqlCommand(safeSql, Connection);
            string data = cmd.ExecuteScalar().ToString();
            return data;
        }
        /// <summary>
        /// ִ���в�SQL��䣬������ִ�м�¼��
        /// </summary>
        public static int GetScalar(string sql, params SqlParameter[] values)
        {
            SqlCommand cmd = new SqlCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            return result;
        }
        /// <summary>
        /// ִ���޲�SQL��䣬������SqlDataReader
        /// </summary>
        public static SqlDataReader GetReader(string safeSql)
        {
            SqlCommand cmd = new SqlCommand(safeSql, Connection);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        /// <summary>
        /// ִ���в�SQL��䣬������SqlDataReader
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

        //����Ϊ��CloudService��Ĳ���

        /// <summary>
        /// ���Ʊ����ݣ�����Ӧ�û�CloudService_ID���Ƶ�CloudService����,����Ϊ�û�ID
        /// </summary>
        /// <param name="ID"></param>
        public static void CopyTable(string ID)
        {
            //sql���
            string sql = "insert into CloudService select * from CloudService_" + ID + ";";
            int res = DBHelper.ExecuteCommand(sql);
        }

        /// <summary>
        /// ���CloudService��UserComment��ʱ������
        /// </summary>
        public static void Delete_Data()
        {
            string sql = "delete from CloudService;" 
                        + "delete from UserComment where CommentID > 0;";
            int res = DBHelper.ExecuteCommand(sql);
        }

        /// <summary>
        /// ��ȡ�û�ID,������Ҫ��Ҫ���ҵ��û�_ID���û����ͣ��û���
        /// </summary>
        /// <param name="Iden_ID"></param>
        /// <param name="UserClass"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetID(string Iden_ID, string UserClass, string name)
        {
            //SQL���
            string sql = "select " + Iden_ID + " from " + UserClass + "  where UserName='" + name + "';";
            string ID = DBHelper.GetStringScalar(sql);
            return ID;
        }

        /// <summary>
        /// ע��ʱ��ȡ���û�ID���
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
        /// ����ʱ��ȡ������ID��ţ���Ҫ�����Ʒ���id
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
        /// �������û��������±�CloudService_ID��Ҫ���û�����ID
        /// </summary>
        /// <param name="ID"></param>
        public static void Create_Table(string ID)
        {
            string NewCloudService_Table = "CloudService_" + ID;
            string sql = "select * into " + NewCloudService_Table + " from CloudService where 1=1;";
            int res = DBHelper.ExecuteCommand(sql);
        }

        /// <summary>
        /// ���ڵ�¼��ѯ�û��Ƿ����,��Ҫ�����û���UserClass���û��������루name��PW��
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
        /// ��ѯ�û����Ƿ��Ѿ����ڣ����ڷ���false�������ڷ���true
        /// </summary>
        /// <param name="username"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static bool ExistUser(string username,string userid)
        {
            string sql = "select COUNT(*) from CsUser where UserName='" + username + "';";
            int usecnt = DBHelper.GetScalar(sql);
            //���ҵ�һ��
            if (usecnt >= 1 )
            {
                if (userid == "NULL")//ע��ʱ
                {
                    return false;//����
                }
                else//�޸�ʱ
                {
                    //�ж��ǲ���Ŀǰ���û���
                    if (DBHelper.GetUserName(userid, "CsUser").Equals(username))
                    {
                        //��Ŀǰ��
                        return true;//������
                    }
                    else
                        return false;//����
                }            
            }
            else
                return true;//������
        }

        /// <summary>
        /// �ղ��Ʒ����̣���Ҫ����������ID��cloudserviceid��������ʱ�䣨CommentTime��
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
        /// �����û���CloudService_ID��������ID��isexpire��,�Ʒ����̱�ţ�cloudserviceid��
        /// </summary>
        /// <param name="isexpire"></param>
        /// <param name="cloudserviceid"></param>
        public static void UpdateCloudService_ID(string isexpire, string cloudserviceid)
        {
            string sql = "insert into CloudService_" + isexpire + " select * from CloudService where CloudServiceID='" + cloudserviceid + "';";
            int res = DBHelper.ExecuteCommand(sql);
        }

        /// <summary>
        /// �����û���Ϣ��������ID��isexpire��,������Ϣ
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
        /// �ж��ܱ���Ϣ�Ƿ���ȷ
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
        /// ���ۣ���Ҫ�����Ʒ����̱�ţ�cloudservieId��������ʱ�䣨ComTime�����������ݣ�MoreInfo�������֣�Score��
        /// </summary>
        /// <param name="cloudservieId"></param>
        /// <param name="ComTime"></param>
        /// <param name="MoreInfo"></param>
        /// <param name="Score"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static int CommentCloudService(string cloudservieId, string ComTime, string MoreInfo, string Score, string userid)
        {
            //���Ȼ�ȡ�������
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
        /// ȡ���ղأ���Ҫ�����û�ID�ͷ�����ID
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
        /// ��ȡ�û�����ǩ��
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
        /// �����û���
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
        /// ��ȡ�Ʒ������������Ʒ�����ID
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
        /// ��ȡ�Ʒ����̹�˾�������Ʒ�����ID
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
        /// ��ȡ�Ʒ����̵����ID������ʡ��ID
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
        /// ��ȡ�û�ͷ��
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
        /// ��ѯ��Ӧ�����̵�ƽ������
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
        /// ɾ����Ӧ����
        /// </summary>
        /// <param name="Ctime"></param>
        /// <param name="username"></param>
        public static void DeleteComment(string Ctime, string username)
        {
            //���ȸ���Ctime��ȡ��Ӧ���Ʒ�����
            string sql = "select CloudServiceName from CommentList where Ctime = '" + Ctime + "';";
            string CsName = DBHelper.GetStringScalar(sql);
            //�����Ʒ����̻�ȡ��Ӧ���
            string sqll = "select CloudServiceID from CloudServiceList where CloudServiceName = '" + CsName + "';";
            string CsID = DBHelper.GetStringScalar(sqll);
            //ɾ������
            string sqlll = "delete from CommentList where Ctime='" + Ctime + "' and CloudServiceName = '" + CsName + "';"
                            + "delete from UserComment_" + CsID + " where Ctime='" + Ctime + "' and CloudServiceName = '" + CsName + "';";
            DBHelper.ExecuteCommand(sqlll);
        }
    }
}
