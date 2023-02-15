using MyUtilities_CS_yoni;
using SocialProject.DataSql;
using SocialProject.Model;
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
        public CommandsManager CommandsManager;
        public UsersManager UsersManager;
        public TwitterManager twitterManager;
        public SocialActivistManager SocialActicistManager;
        public ProductManager ProductManager;
        public NPOManager NPOManager;
        public CampaignsManager CampaignsManager;
        public BCompanyManager BCompanyManager;
        public M_Configuration M_Configuration;
        public DS_configuration DS_configuration;
        public LogManager LogManager;

        private MainManager()
        {
            init();
        }

        public void init()
        {
            LogManager = new LogManager(providerType.File);
            UsersManager = new UsersManager(LogManager);
            twitterManager = new TwitterManager(LogManager);
            SocialActicistManager = new SocialActivistManager(LogManager);
            ProductManager = new ProductManager(LogManager);
            NPOManager = new NPOManager(LogManager);
            CampaignsManager = new CampaignsManager(LogManager);
            BCompanyManager = new BCompanyManager(LogManager);
            CommandsManager = new CommandsManager(LogManager);

            M_Configuration = new M_Configuration();
            DS_configuration = new DS_configuration(LogManager, M_Configuration);
            DS_configuration.InitConfig();

            LogManager.LogEvent(@"Entities \ MainManager \ init ran Successfully - ");
        }


        private static readonly MainManager instance = new MainManager();
        public static MainManager Instance { get { return instance; } }

    }
}
