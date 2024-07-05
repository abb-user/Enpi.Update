# Electrification.ABB.SDK.EnPI.Update
Project template for SDK developers

0. Clone this Git repo.

1. Modify the parameters in the Config.json file in the current folder.

2. The Config.json file includes five parameters: PlantId, ApplicationId, APIKey, Subscription-Key, and FileName. These keys are needed to access the Developer Portal/SDK APIs.

3. The PlantId can be found in Site Manager at this link(https://sitemanager.ability.abb/#/settings/site), where the SiteIdentifier serves as the PlantId.

4. The values for ApplicationId, APIKey, and Subscription-Key can be obtained from the Developer Portal/SDK portal at this link((https://developers.connect.abb.com/application)) and should be updated accordingly in the config.json file.


5. FileName refers to the name of the Excel file in the current folder. "SampleDataSource.xlsx" is an Excel file current used as sample, that contains Enpi Parameter Names, Date, and values to update Site Manager/Platform.

6. You can add any number of columns and rows to the Excel sheet. This application can process the additional data. Please ensure you follow the format provided in the sample Excel file ("SampleDataSource.xlsx").
for Example:
    Timestamp	       liters(Parameter Name)	Area(Parameter Name)  ENERGIA_PV(Parameter Name)  M3_TREATER(Parameter Name)   .......
    6/13/2024 11:19	      4	                           2.5                    5                              7.6               .......
    6/13/2024 11:19	      3	                            5                     6                               8                .......
    6/14/2024 11:19	      2	                            5                     7                               6                .......
    6/15/2024 11:19	      1	                            5                     8                               4                .......
    6/18/2024 11:19       7                             8                     100                             506              ....... 
           .              .                             .                      .                              .                .......
           .              .                             .                      .                              .                .......
           .              .                             .                      .                              .                .......
           .              .                             .                      .                              .                .......
           .              .                             .                      .                              .                .......    

7. Replace the headers in the Excel sheet with the parameter names, dates, and values as described in the previous step.

8. The current folder includes a Log.txt file that contains logs of recently processed data. Refer to this file for debugging purposes.



Finally to process the records in excel file,Build the solution.check if all the nuget packages are restored.
if not please restore them.
Run solution after.


Tools and Tech stack Used:

Tools:
 Visual studio 2022, Excel.

Technology:
 .Net8, C#, Console Application.

