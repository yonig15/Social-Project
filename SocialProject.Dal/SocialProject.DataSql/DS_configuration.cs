using MyUtilities_CS_yoni;
using SocialProject.Dal;
using SocialProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialProject.DataSql
{
    public class DS_configuration : BaseDataSql
    {
        BaseDal BaseDal;
        M_Configuration M_Configuration;
        public DS_configuration(LogManager log ,M_Configuration configuration) : base(log)
        {
            BaseDal = new BaseDal(Log);
            M_Configuration = configuration;
        }


        public void InitConfig()
        {
            try
            {
                Log.LogEvent(@"DataSql \ DS_configuration \ InitConfig ran Successfully - ");
                M_Configuration.Auth0BearerCode = (string)SqlQuery.Read_Scalar_FromDB("select Value from Configuration where Name like 'Auth0BearerCode'");
                M_Configuration.TwitterBearerCode = (string)SqlQuery.Read_Scalar_FromDB("select Value from Configuration where Name like 'TwitterBearerCode'");
                M_Configuration.TwitterConsumerKey = (string)SqlQuery.Read_Scalar_FromDB("select Value from Configuration where Name like 'TwitterConsumerKey'");
                M_Configuration.TwitterConsumerKeySecret = (string)SqlQuery.Read_Scalar_FromDB("select Value from Configuration where Name like 'TwitterConsumerKeySecret'");
                M_Configuration.TwitterAccessKey = (string)SqlQuery.Read_Scalar_FromDB("select Value from Configuration where Name like 'TwitterAccessKey'");
                M_Configuration.TwitterAccessKeySecret = (string)SqlQuery.Read_Scalar_FromDB("select Value from Configuration where Name like 'TwitterAccessKeySecret'");
            }
            catch (Exception ex)
            {
                Log.LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
        }


    }
}
