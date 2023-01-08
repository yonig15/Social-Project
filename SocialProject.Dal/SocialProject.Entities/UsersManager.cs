using SocialProject.DataSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialProject.Entities
{
    public class UsersManager
    {
        public bool? get_Pending_FromDB (string email)
        {
            DS_UsersQ dS_UsersQ = new DS_UsersQ();
            return dS_UsersQ.Send_PenddingQuery(email);
        }
    
    }
}
