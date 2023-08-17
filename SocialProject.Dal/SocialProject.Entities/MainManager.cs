using MyUtilities_CS_yoni;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialProject.Entities
{
    public class MainManager
    {
        public AllFormsManager AllFormsManager;
        public UsersManager UsersManager;
        public TwitterManager twitterManager;
        private MainManager()
        {
            init();
        }

        public void init()
        {
            AllFormsManager = new AllFormsManager();
            UsersManager = new UsersManager();
            twitterManager = new TwitterManager();
            //lomanageg log1 = new logmanager(file);
            //log1.LogEvent(msg);

        }
        private static readonly MainManager instance = new MainManager();
        public static MainManager Instance { get { return instance; } }

    }
}



//using IHost host = CreateHostBuilder(args).Build();
//using var scope = host.Services.CreateScope();
//var services = scope.ServiceProvider;
//var logManager = services.GetRequiredService<LogManager>();


//try
//{
//	var app = services.GetRequiredService<App>();
//	app.Run(args);
//	logManager.LogInfo("The app has finished running", LogProviderType.Console);
//}
//catch (Exception)
//{
//	logManager.LogError("Application Error: Check Log File", LogProviderType.Console);
//}


//static IHostBuilder CreateHostBuilder(string[] args)
//{

//	var config = new ConfigurationBuilder()
//		.SetBasePath(Directory.GetCurrentDirectory())
//		.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
//		.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("UniqeIdsScanner_ENVIRONMENT") ?? "Production"}.json", optional: true)
//		.AddEnvironmentVariables()
//		.Build();

//	var connectionString = GetConnectionString(config);

//	return Host.CreateDefaultBuilder(args)
//	 .ConfigureServices((hostContext, services) =>
//	 {

//		 services.AddSingleton<App>();
//		 services.AddDbContext<KlaContext>(options =>
//			 options.UseSqlServer(connectionString)
//			 .UseLoggerFactory(LoggerFactory.Create(builder =>
//			 {
//				 builder.AddFilter((category, level) =>
//					 !category.Equals("Microsoft.EntityFrameworkCore.Database.Command") || level == LogLevel.Error);
//			 }))
//		 );
//		 services.AddSingleton<LogManager>();
//		 services.AddTransient<IUnitOfWork, UnitOfWork>();
//		 services.AddTransient<IUniqueIdsRepository, UniqueIdsRepository>();
//		 services.AddTransient<IUserRepository, UserRepository>();
//		 services.AddTransient<IFileSystem, RealFileSystem>();
//		 services.AddTransient<AlarmScanner>();
//		 services.AddTransient<EventScanner>();
//		 services.AddTransient<VariableScanner>();
//		 services.AddSingleton<MainManager>();
//	 });
//}

//static string GetConnectionString(IConfiguration config)
//{
//	var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
//	var dbName = Environment.GetEnvironmentVariable("DB_NAME");
//	var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");

//	if (dbHost == null || dbName == null || dbPassword == null)
//	{
//		// If any of the environment variables were not found, return the connection string from appsettings
//		return config["ConnectionString:Value"];
//	}

//	return $"Data Source={dbHost};Initial Catalog={dbName};User ID=sa; Password={dbPassword};TrustServerCertificate=true";
//}
