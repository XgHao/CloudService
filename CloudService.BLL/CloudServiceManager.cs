using System;
using System.Collections.Generic;
using System.Text;
using CloudService.Models;
using CloudService.DAO;

namespace CloudService.BLL
{
    public static class CloudServiceManager
    {
        public static IList<CloudServer> GetAllCloudService()
        {
            try
            {
                return CloudServiceService.GetAllCloudService();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public static IList<Comment> GetAllUserComment()
        {
            try
            {
                return CloudServiceService.GetAllUserComment();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public static IList<CloudServer> GetAllCloudServiceList()
        {
            try
            {
                return CloudServiceService.GetAllCloudServiceList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public static IList<Comment> GetAllCommentList()
        {
            try
            {
                return CloudServiceService.GetAllCommentList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public static IList<Comment> GetCommentByCsIdANDUserId(string Csname, string Username)
        {
            try
            {
                return CloudServiceService.GetCommentByCsIdANDUserId(Csname, Username);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public static IList<CloudServer> GetAllCloudServiceListByProId(int proId)
        {
            try
            {
                return CloudServiceService.GetAllCloudServiceListByProId(proId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public static IList<CloudServer> GetAllCloudServiceDealByProId(int proId)
        {
            try
            {
                return CloudServiceService.GetAllCloudServiceDealByProId(proId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public static CloudServer GetCloudServiceByCloudServiceId(string cloudserviceid)
        {
            try
            {
                return CloudServiceService.GetCloudServiceByCloudServiceId(cloudserviceid);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public static CloudServer GetCloudServiceInfoByCloudServiceId(string cloudserviceid)
        {
            try
            {
                return CloudServiceService.GetCloudServiceInfoByCloudServiceId(cloudserviceid);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public static CloudServer GetCloudServiceByCldSerIdAndUserId(string cloudserviceid, string userid)
        {
            try
            {
                return CloudServiceService.GetCloudServiceByCldSerIdAndUserId(cloudserviceid,userid);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
