using MyUtilities_CS_yoni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyUtilities_CS_yoni.LogManager;

namespace SocialProject.Entities
{
    public class MainManager
    {
        //public CommandsManager CommandsManager;
        public AllFormsManager AllFormsManager;
        public UsersManager UsersManager;
        public TwitterManager twitterManager;
        private MainManager()
        {
            init();
        }

        public void init()
        {
            LogManager LogManager = new LogManager(providerType.File);
            AllFormsManager = new AllFormsManager(LogManager);
            UsersManager = new UsersManager(LogManager);
            twitterManager = new TwitterManager(LogManager);
            //CommandsManager = new CommandsManager();


            LogManager.LogEvent("test1!");

            LogManager.LogError("msg");

        }
        private static readonly MainManager instance = new MainManager();
        public static MainManager Instance { get { return instance; } }

    }
}
