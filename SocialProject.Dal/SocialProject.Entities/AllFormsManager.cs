using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialProject.Model;
using SocialProject.DataSql;

namespace SocialProject.Entities
{
    public class AllFormsManager
    {
        public void SendContactUsFormToDB(M_ContactUs m_ContactUs)
        {
            DS_Forms dS_Form = new DS_Forms();
            dS_Form.EnterContactUsFormToDB(m_ContactUs);
        }
    }
}
