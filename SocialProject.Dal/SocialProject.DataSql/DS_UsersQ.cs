using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialProject.DataSql
{
    public class DS_UsersQ
    {
        public bool? Send_PenddingQuery(string email)
        {
          string Is_Aproved = "select Is_Aproved from Register_Applications where Email like '" + email + "'";
          bool? Pending = (bool?)SocialProject.Dal.SqlQuery.Read_Scalar_FromDB(Is_Aproved);
          return Pending;
        }
    }
}
