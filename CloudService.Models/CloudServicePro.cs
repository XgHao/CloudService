using System;
using System.Collections.Generic;
using System.Text;

namespace CloudService.Models
{
    [Serializable]
    public class CloudServicePro
    {
        private int proid;
        private string province = String.Empty;

        public CloudServicePro() { }

        public int ProID
        {
            get { return this.proid; }
            set { this.proid = value; }
        }

        public string Province
        {
            get { return this.province; }
            set { this.province = value; }
        }
    }
}
