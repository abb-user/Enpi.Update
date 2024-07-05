# Electrification.ABB.SDK.EnPI.Update
Project template for SDK developers

1. Clone this Git repo.
2. Change the Parameters in Config.json file
3. Config.json file contains 5 parameters namely, PlantId, ApplicationId, APIKey, Subscription-Key and FileName.
4. ApplicationId, APIKey, Subscription-Key, This 3 values can be obtained from Developer Portal/SDK portal(https://developers.connect.abb.com/application) and should be replaced.
1. PlantId can be obtained from sitemanager.
5. FileName is the name of the Excel file in th relative path of this solution. Provided value is the sample Excel file in this path.
6. Kindly note that you can add any number of columns and rows in the Excel sheet. The solution supports processing the same.Please follow the format, as in the attached sample excel file.
7. Replace the headers with Parameter names and values in the ExcelSheet.
8. Solution contains Log.txt file which has the Logs of recent processed data. Please look here for debugging purpose.



Finally to process the records in excel file,Build the solution.check if all the nuget packages are restored.
if not please restore them.
Run solution after.


Tools and Tech stack Used:

Tools:
 Visual studio 2022, Excel.

Technology:
 .Net8, C#, Console Application.

