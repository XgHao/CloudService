using System;
using System.Collections.Generic;
using System.Text;

namespace CloudService.Models
{
    [Serializable]
    public class CloudServer
    {
        protected int cloudserviceID;       //云服务商ID
        protected string cloudservicename = String.Empty;       //云服务商名
        protected string address;       //地址
        protected string username;      
        protected string proname;       //省份
        protected string company;       //公司
        protected string website;       //站点
        protected string ctime;         //日期
        protected string newcomment;    //最新评论
        protected string logo;          //logo
        private CloudServicePro provinceid;

        public CloudServer() { }
              
        public int CloudServiceID
        {
            get { return cloudserviceID; }
            set { cloudserviceID = value; }
        }

        public string CloudServiceName
        {
            get { return cloudservicename; }
            set { cloudservicename = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string UserName
        {
            get { return username; }
            set { username = value; }
        }

        public string ProName
        {
            get { return proname; }
            set { proname = value; }
        }

        public string Company
        {
            get { return company; }
            set { company = value; }
        }

        public string WebSite
        {
            get { return website; }
            set { website = value; }
        }

        public string Ctime
        {
            get { return ctime; }
            set { ctime = value; }
        }

        public string NewComment
        {
            get { return newcomment; }
            set { newcomment = value; }
        }

        public string Logo
        {
            get { return logo; }
            set { logo = value; }
        }

        public CloudServicePro ProvinceID
        {
            get { return provinceid; }
            set { provinceid = value; }
        }
    }
}
