using System;
using System.Collections.Generic;
using System.Text;

namespace CloudService.Models
{
    public class Comment
    {
        //UserComment
        protected int commentid;
        protected string commenter = string.Empty;      //评论者
        protected string cloudservicename = string.Empty;       //服务商名
        protected string score = string.Empty;      //评分
        protected string usercomment = string.Empty;
        protected string ctime = string.Empty;


        public int CommentID
        {
            get { return commentid; }
            set { commentid = value; }
        }

        public string CloudServiceName
        {
            get { return cloudservicename; }
            set { cloudservicename = value; }
        }

        public string Score
        {
            get { return score; }
            set { score = value; }
        }

        public string Commenter
        {
            get { return commenter; }
            set { commenter = value; }
        }

        public string UserComment
        {
            get { return usercomment; }
            set { usercomment = value; }
        }

        public string Ctime
        {
            get { return ctime; }
            set { ctime = value; }
        }
    }
}
