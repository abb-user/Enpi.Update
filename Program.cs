using Electrification.ABB.SDK.EnPI.Update;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

internal class Program
{
    
    private static string logFilePath = string.Empty;
    private static async Task Main(string[] args)
    {
        try
        {
            
            var configuration = new ConfigurationBuilder()
           .SetBasePath(AppContext.BaseDirectory)
           .AddJsonFile("Config.json", optional: false, reloadOnChange: true)
           .Build();

            // Get the path of the directory where the executing assembly is located
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Determine the solution directory. This might vary based on your project structure.
            string solutionDirectory = Directory.GetParent(currentDirectory).FullName;

            logFilePath = Path.Combine(solutionDirectory, "logs.txt");

            ExcelProcessor processor = new ExcelProcessor();

            SiteManager sitemanager = new SiteManager(logFilePath);

            //you will get this below appId,APIkey,subId,PlantId from the application section of the sdk portal.
            Guid appId = new Guid(configuration["ApplicationId"]);

            string APIkey = $"ABB {configuration["APIKey"]}";

            string subId = configuration["SubscriptionKey"]; 

            var plantId = new Guid(configuration["PlantID"]);

            string filePath = Path.Combine(solutionDirectory, configuration["FileName"]);


            //Setup the headers
            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                { "Authorization", APIkey },
                { "Subscription-Key", subId }
            };

            Console.WriteLine(Environment.CurrentDirectory.ToString());
            if (!File.Exists(filePath))
            {
                Console.WriteLine(Environment.CurrentDirectory.ToString());
                Console.WriteLine($"Plant ID: {plantId }");
                Console.WriteLine($"The file does not exist. Please ensure the path is correct and try again. Path it is now pointing is {filePath}");
                Console.ReadLine();
                return;
            }
           
            
            await foreach(var row in processor.ReadExcelAsync(filePath))
            {
                await sitemanager.UpdateSitemanager(row, headers,appId,plantId);
            }


            Console.WriteLine("Execution Completed");
            Console.ReadLine();

        }
        catch (Exception ex)
        {
            TraceLogs.Log(logFilePath, $"{ex.Message}");
            Console.WriteLine(ex);
            Console.ReadLine();
        }
       
    }
  
}