using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialProject.Entities
{
    public class MainManager
    {
        public AllFormsManager AllForms;
        public UsersManager UsersManager;
        private MainManager()
        {
            AllForms=new AllFormsManager();
            UsersManager = new UsersManager();
        }

        private static readonly MainManager instance = new MainManager();
        public static MainManager Instance { get { return instance; } }

    }
}
