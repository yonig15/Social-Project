using SocialProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialProject.Dal;

namespace SocialProject.DataSql
{
    public class DS_Forms
    {
        //הכנסת אורח לטבלה במסד הנתונים
        public void EnterContactUsFormToDB(M_ContactUs M_ContactUs)
        {
            string sqlQuery = "insert into Contact_Us values ('" + M_ContactUs.FirstName + "','" + M_ContactUs.LastName + "','" + M_ContactUs.Email + "','"+ M_ContactUs.Message+ "','" + M_ContactUs.JoinedNewsletter + "',getdate())";
            SqlQuery.WriteToDB(sqlQuery);
        }
    }
}
