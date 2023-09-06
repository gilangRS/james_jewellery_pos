using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Connection.Settings
{

    public class ConnectionString
    {
        public ConnectionName ConnectionStrings { get; set; }
        public AppConfig AppConfig { get; set; }

        public ConnectionString()
        {
            string fileName = "../appsettings.json";
            string jsonString = File.ReadAllText(fileName);
            AppConfig = JsonSerializer.Deserialize<AppConfig>(jsonString);
            //Production
            if(AppConfig.Level == 1)
            {
                ConnectionStrings = new ConnectionName 
                { 
                    Cnn_AC = AppConfig.Production.Cnn_AC, 
                    Cnn_DB = AppConfig.Production.Cnn_DB,
                    Cnn_CMK = AppConfig.Production.Cnn_CMK,
                    Cnn_IN = AppConfig.Production.Cnn_IN,
                };
            }
            else
            {
                ConnectionStrings = new ConnectionName 
                { 
                    Cnn_AC = AppConfig.Development.Cnn_AC, 
                    Cnn_DB = AppConfig.Development.Cnn_DB,
                    Cnn_CMK = AppConfig.Development.Cnn_CMK,
                    Cnn_IN = AppConfig.Development.Cnn_IN
                };
            }            
        }
    }
}
