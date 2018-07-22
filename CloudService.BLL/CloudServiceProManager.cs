using System;
using System.Collections.Generic;
using System.Text;
using CloudService.DAO;
using CloudService.Models;

namespace CloudService.BLL
{
    public static class CloudServiceStateManager
    {
        public static CloudServicePro GetClassStateById(int proid)
        {
            return CloudServiceProService.GetCloudServiceProById(proid);
        }
    }
}
