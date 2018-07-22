using System;
using System.Collections.Generic;
using System.Text;
using CloudService.Models;
using System.Data;
using System.Data.SqlClient;

namespace CloudService.DAO
{
    public static class CloudServiceProService
    {
        public static CloudServicePro GetCloudServiceProById(int proid)
        {
            string teaName = string.Empty;
            string sql = "select * from Province where ProID ='" + proid + "';";
            SqlDataReader reader = DBHelper.GetReader(sql);
            if (reader.Read())
            {
                CloudServicePro CsPro = new CloudServicePro();
                CsPro.ProID = proid;
                CsPro.Province = Convert.ToString(reader["Province"]);
                reader.Close();
                return CsPro;
            }
            else
            {
                reader.Close();
                return null;
            }
        }

        public static string GetCloudServiceProvince(string proid)
        {
            string sql = "select Province from Province where ProID ='" + proid + "';";
            string province = DBHelper.GetStringScalar(sql);
            return province;
        }
    }
}
