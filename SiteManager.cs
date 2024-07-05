using ABB.Developers.SDK.Services.Assets;
using ABB.Developers.SDK.Services.Powers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Electrification.ABB.SDK.EnPI.Update
{
    public class SiteManager
    {
        private  bool isHeader = true;
        private  List<string> HeaderRow = new List<string>();
        private string logFilePath;
        private const string datePattern = "MM/dd/yyyy hh:mm:ss tt";

        public SiteManager( string logFilePath)
        {
            this.logFilePath = logFilePath;
        }
        public async Task UpdateSitemanager(string[] row, Dictionary<string, string> headers, Guid appId, Guid plantId)
        {
            DateTime parsedDate = DateTime.Now;
            if (isHeader)
            {
                HeaderRow = row.Cast<string>().ToList();
                isHeader = false;
            }
            else
            {

                int cellNumber = 1;
                bool isdateColumn = true;
                foreach (var cell in row)
                {
                    if (isdateColumn)
                    {
                        isdateColumn = false;
                        continue;
                    }

                    // Instantiate power service
                    PowerService ps = new PowerService(headers);

                    //update Performance Parameter value
                    var result = await ps.UpdatePerformanceIndicatorParameterValue(appId, plantId, HeaderRow[cellNumber], cell, Convert.ToDateTime(row[0]).ToString(datePattern));

                    string LogMessage = string.Empty;
                    if (result.Code == AssetServiceResultCode.Success)
                    {
                        LogMessage = $"{row[0].ToString()} ----- {HeaderRow[cellNumber]} ----- {cell} ----- {result?.Message}";
                    }
                    else
                    {
                        LogMessage = $"{row[0].ToString()} ----- {HeaderRow[cellNumber]} ----- {cell} ----- {"Error"} -- {result?.Errors?.FirstOrDefault()?.Message}";
                    }

                    TraceLogs.Log(logFilePath, LogMessage);
                    //write result to console
                    Console.WriteLine(LogMessage);

                    cellNumber++;
                }
            }
        }
    }
}
