using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CloudService.Models;

namespace CloudService.DAO
{
    public static class CloudServiceService
    {
        /// <summary>
        /// 获得当前用户收藏的服务商
        /// </summary>
        /// <returns></returns>
        public static IList<CloudServer> GetAllCloudService()
        {
            IList<CloudServer> list = new List<CloudServer>();
            string sql = "select * from CloudService";
            DataTable table = DBHelper.GetDataSet(sql);            
                
            foreach (DataRow row in table.Rows)
            {
                CloudServer cldser = new CloudServer();
                cldser.CloudServiceID = (int)row["CloudServiceID"];
                cldser.CloudServiceName = (string)row["CloudServiceName"];
                cldser.ProvinceID = CloudServiceProService.GetCloudServiceProById(int.Parse(row["ProID"].ToString()));
                cldser.Address = (string)row["Address"];
                cldser.Company = (string)row["Company"];
                cldser.WebSite = (string)row["WebSite"];
                cldser.Logo = (string)row["Logo"];
                cldser.Ctime = (string)row["Ctime"];
                list.Add(cldser);
            }

            return list;
        }

        /// <summary>
        /// 获取当前用户的评论 
        /// </summary>
        /// <returns></returns>
        public static IList<Comment> GetAllUserComment()
        {
            IList<Comment> list = new List<Comment>();
            string sql = "select * from UserComment;";
            DataTable table = DBHelper.GetDataSet(sql);

            foreach (DataRow row in table.Rows)
            {
                Comment comment = new Comment();
                comment.CommentID = int.Parse(row["CommentID"].ToString());
                comment.Commenter = (string)row["Commenter"];
                comment.CloudServiceName = (string)row["CloudServiceName"];
                comment.Score = (string)row["Score"];
                comment.UserComment = (string)row["Comment"];
                comment.Ctime = (string)row["Ctime"];
                list.Add(comment);
            }
            return list;
        }

        /// <summary>
        /// 获取所有的云服务商
        /// </summary>
        /// <returns></returns>
        public static IList<CloudServer> GetAllCloudServiceList()
        {
            IList<CloudServer> list = new List<CloudServer>();
            string sql = "select * from CloudServiceList where CloudServiceID > 0";
            DataTable table = DBHelper.GetDataSet(sql);

            foreach (DataRow row in table.Rows)
            {
                CloudServer cldser = new CloudServer();
                cldser.CloudServiceID = (int)row["CloudServiceID"];
                cldser.CloudServiceName = (string)row["CloudServiceName"];
                cldser.ProvinceID = CloudServiceProService.GetCloudServiceProById(int.Parse(row["ProID"].ToString()));
                cldser.Address = (string)row["Address"];
                cldser.Company = (string)row["Company"];
                cldser.WebSite = (string)row["WebSite"];
                cldser.Logo = (string)row["Logo"];
                list.Add(cldser);
            }
            return list;
        }

        /// <summary>
        /// 获取所有评论
        /// </summary>
        /// <returns></returns>
        public static IList<Comment> GetAllCommentList()
        {
            IList<Comment> list = new List<Comment>();
            string sql = "select * from CommentList";
            DataTable table = DBHelper.GetDataSet(sql);
            
            foreach (DataRow row in table.Rows)
            {
                Comment comment = new Comment();
                comment.Commenter = (string)row["Commenter"];
                comment.CloudServiceName = (string)row["CloudServiceName"];
                comment.Score = (string)row["Score"].ToString();
                comment.UserComment = (string)row["Comment"];
                comment.Ctime = (string)row["Ctime"];
                list.Add(comment);
            }
            
            return list;
        }

        /// <summary>
        /// 根据服务商ID获取服务商
        /// </summary>
        /// <param name="cloudserviceid"></param>
        /// <returns></returns>
        public static CloudServer GetCloudServiceByCloudServiceId(string cloudserviceid)
        {
            CloudServer cldser = new CloudServer();
            string sql = "select * from CloudService where CloudServiceID='" + cloudserviceid + "'";
            SqlDataReader datareader = DBHelper.GetReader(sql);
            if (datareader.Read())
            {
                cldser.CloudServiceID = (int)datareader["CloudServiceID"];
                cldser.CloudServiceName = (string)datareader["CloudServiceName"];
                cldser.ProvinceID = CloudServiceProService.GetCloudServiceProById(int.Parse(datareader["ProID"].ToString()));
                cldser.Address = (string)datareader["Address"];
                cldser.Company = (string)datareader["Company"];
                cldser.WebSite = (string)datareader["WebSite"];
                cldser.Logo = (string)datareader["Logo"];
            }
            datareader.Close();
            return cldser;
        }

        /// <summary>
        /// 根据服务商ID获取服务商的详细信息
        /// </summary>
        /// <param name="cloudserviceid"></param>
        /// <returns></returns>
        public static CloudServer GetCloudServiceInfoByCloudServiceId(string cloudserviceid)
        {
            CloudServer cldser = new CloudServer();
            string sql = "select * from CloudServiceList where CloudServiceID='" + cloudserviceid + "'";
            SqlDataReader datareader = DBHelper.GetReader(sql);
            if (datareader.Read())
            {
                cldser.CloudServiceID = (int)datareader["CloudServiceID"];
                cldser.CloudServiceName = (string)datareader["CloudServiceName"];
                cldser.Address = (string)datareader["Address"];
                cldser.Company = (string)datareader["Company"];
                cldser.WebSite = (string)datareader["WebSite"];
                cldser.NewComment = (string)datareader["NewComment"];
                cldser.Logo = (string)datareader["Logo"];
            }
            datareader.Close();
            return cldser;
        }

        /// <summary>
        /// 根据服务商ID和用户ID获取服务商
        /// </summary>
        /// <param name="cloudserviceid"></param>
        /// <returns></returns>
        public static CloudServer GetCloudServiceByCldSerIdAndUserId(string cloudserviceid, string userid)
        {
            CloudServer cldser = new CloudServer();
            string sql = "select * from CloudService where CloudServiceID='" + cloudserviceid + "'";
            SqlDataReader datareader = DBHelper.GetReader(sql);
            if (datareader.Read())
            {
                cldser.CloudServiceID = (int)datareader["CloudServiceID"];
                cldser.CloudServiceName = (string)datareader["CloudServiceName"];
                cldser.ProvinceID = CloudServiceProService.GetCloudServiceProById(int.Parse(datareader["ProID"].ToString()));
                cldser.Address = (string)datareader["Address"];
                cldser.Company = (string)datareader["Company"];
                cldser.WebSite = (string)datareader["WebSite"];
                cldser.Logo = (string)datareader["Logo"];
            }
            datareader.Close();
            return cldser;
        }

        /// <summary>
        /// 根据省份ID获取服务商
        /// </summary>
        /// <param name="proId"></param>
        /// <returns></returns>
        public static IList<Comment> GetCommentByCsIdANDUserId(string Csname, string Username)
        {
            IList<Comment> list = new List<Comment>();
            string sql = "select * from CommentList";
            //筛选服务商
            if (Csname == "全部云服务商")
            {
                //筛选用户
                if (Username == "全部用户")
                {
                    
                }
                else
                {
                    //筛选用户
                    sql += " where Commenter ='" + Username + "';";
                }
            }
            else
            {
                //筛选用户
                if (Username == "全部用户")
                {
                    //筛选服务商
                    sql += " where CloudServiceName ='" + Csname + "';";
                }
                else
                {
                    //筛选服务商与用户
                    sql += " where CloudServiceName ='" + Csname + "' and Commenter ='" + Username + "';";
                }
            }
            DataTable table = DBHelper.GetDataSet(sql);
            foreach (DataRow row in table.Rows)
            {
                Comment comment = new Comment();
                comment.CloudServiceName = (string)row["CloudServiceName"];
                comment.Score = (string)(row["Score"].ToString());
                comment.UserComment = (string)row["Comment"];
                comment.Commenter = (string)row["Commenter"];
                comment.Ctime = (string)row["Ctime"];
                list.Add(comment);
            }
            return list;           
        }

        /// <summary>
        /// 根据省份ID获取服务商
        /// </summary>
        /// <param name="proId"></param>
        /// <returns></returns>
        public static IList<CloudServer> GetAllCloudServiceListByProId(int proId)
        {
            IList<CloudServer> list = new List<CloudServer>();
            string sql = "select * from CloudServiceList where ProID ='" + proId + "';";
            DataTable table = DBHelper.GetDataSet(sql);
            foreach (DataRow row in table.Rows)
            {
                CloudServer cldser = new CloudServer();
                cldser.CloudServiceID = (int)row["CloudServiceID"];
                cldser.CloudServiceName = (String)row["CloudServiceName"];
                cldser.ProvinceID = CloudServiceProService.GetCloudServiceProById(int.Parse(row["ProID"].ToString()));
                cldser.Address = (string)row["Address"];
                cldser.Company = (string)row["Company"];
                cldser.WebSite = (string)row["WebSite"];
                cldser.Logo = (string)row["Logo"];
                list.Add(cldser);
            }
            return list;          
        }

        /// <summary>
        /// 根据省份ID获取服务商
        /// </summary>
        /// <param name="proId"></param>
        /// <returns></returns>
        public static IList<CloudServer> GetAllCloudServiceDealByProId(int proId)
        {
            IList<CloudServer> list = new List<CloudServer>();
            string sql = "select * from CloudServiceList";
            if (proId > 0)
                sql += " where ProID ='" + proId + "';";
            DataTable table = DBHelper.GetDataSet(sql);
            foreach (DataRow row in table.Rows)
            {
                CloudServer cldser = new CloudServer();
                cldser.CloudServiceID = (int)row["CloudServiceID"];
                cldser.CloudServiceName = (String)row["CloudServiceName"];
                cldser.ProvinceID = CloudServiceProService.GetCloudServiceProById(int.Parse(row["ProID"].ToString()));
                cldser.Address = (string)row["Address"];
                cldser.Company = (string)row["Company"];
                cldser.WebSite = (string)row["WebSite"];
                cldser.Logo = (string)row["Logo"];
                list.Add(cldser);
            }
            return list;
        }
    }
}
