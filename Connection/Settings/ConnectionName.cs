using System;
using System.Collections.Generic;
using System.Text;

namespace Connection.Settings
{
    public class ConnectionName
    {
        public string Cnn_DB { get; set; }
        public string Cnn_AC { get; set; }
        public string Cnn_CMK { get; set; }
        public string Cnn_IN { get; set; }
    }

    public class AppConfig
    {
        public int Level { get; set; }
        public int Brand { get; set; }
        public string BrandCode { get; set; }
        public string DirPackaging { get; set; }
        public string DirSouvenir { get; set; }
        public string DirCetakan { get; set; }
        public string UrlJAWS { get; set; }
        public Development Development { get;set; }
        public Production Production { get; set; }
    }

    public class Development
    {
        public string Cnn_DB { get; set; }
        public string Cnn_AC { get; set; }
        public string Cnn_CMK { get; set; }
        public string Cnn_IN { get; set; }
        public StampsConnection StampsConnection { get; set; }
    }
    public class Production
    {
        public string Cnn_DB { get; set; }
        public string Cnn_AC { get; set; }
        public string Cnn_CMK { get; set; }
        public string Cnn_IN { get; set; }
        public StampsConnection StampsConnection { get; set; }
    }

    public class StampsConnection
    {
        public string BASE_URL { get; set; }
        public string TOKEN { get; set; }
        public string MERCHANT { get; set; }
    }
}
