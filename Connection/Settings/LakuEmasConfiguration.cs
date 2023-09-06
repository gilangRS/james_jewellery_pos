using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Connection.Settings
{
    public class LakuEmasConfiguration
    {
        string BASE_URL_CASHBOX = "https://test-pos.sgk.co.id/api/jaws/list-cashbox?";
        string BASE_URL_PUSH = "https://test-pos.sgk.co.id/api/jaws/push-data?";
        string SIGNATURE = "IhpGVSZWsQt6WJceoiqxeftiRC8N8nuxE4BITJcr4Ng4pV2h9my0ZdDqRmWkN5Ax8RjLbAKu587p6jSKBeoONXhwzisxHJoTezlM";
        string THIRD_PARTY = "JAWS";

        #region POSTMETHOD
        public string AddTransactionLE(string customername, string customeremail, string customeraddress, string customerKTP, string customerhandphone, int bankid, string bankaccountnumber, string bankaccountname, string store, string keterangan, string cashboxcode, List<ItemPLU> items)
        {
            string result = "";
            AddTransaction at = new AddTransaction
            {
                customer_name = customername,
                customer_email = customeremail,
                customer_address = customeraddress,
                customer_ktp = customerKTP,
                customer_handphone = customerhandphone,
                bank_id = bankid,
                bank_account_number = bankaccountnumber,
                bank_account_name = bankaccountname,
                store_code = store,
                keterangan = keterangan,
                cashbox_code = cashboxcode,
                third_party = THIRD_PARTY,
                signature_key = SIGNATURE
            };
            string objectencoded = Newtonsoft.Json.JsonConvert.SerializeObject(at).Replace("{", "").Replace("}", "").Replace("\"", string.Empty).Replace(",", "&").Replace(":", "=");
            string url = BASE_URL_PUSH + objectencoded;

            string totalitemurl = "";
            int i = 0;
            foreach (ItemPLU item in items)
            {
                totalitemurl += "&item[" + i + "][plu_code]=" + item.plu_code + "&item[" + i + "][weight]=" + item.weight.ToString("#.##").Replace(".", "").Replace(",", ".") + "&item[" + i + "][jaws_price]=" + item.jaws_price.ToString("#.##").Replace(".", "").Replace(",", ".");
                i++;
            }
            url = url + totalitemurl;

            result = WebRequestPOST(url);
            return result;
        }

        public string GetCashBox(string storecode)
        {
            string result = "";
            CashboxList cl = new CashboxList
            {
                store_code = storecode,
                third_party = THIRD_PARTY,
                signature_key = SIGNATURE
            };
            string objectencoded = Newtonsoft.Json.JsonConvert.SerializeObject(cl).Replace("{", "").Replace("}", "").Replace("\"", string.Empty).Replace(",", "&").Replace(":", "=");
            string url = BASE_URL_CASHBOX + objectencoded;
            result = WebRequestGET(url);
            return result;
        }

        public object GetRateLEI()
        {
            string url = "https://apiext.lakuemas.com/cmk_club/get_price";
            string result = WebRequestGET(url);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<APILakuEmas>(result);
        }

        public APILakuEmas GetRateLEIs()
        {
            string url = "https://apiext.lakuemas.com/cmk_club/get_price";
            string result = WebRequestGET(url);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<APILakuEmas>(result);
        }

        public int GetMiddleRateLEI()
        {
            string url = "https://apiext.lakuemas.com/cmk_club/get_price";
            string result = WebRequestGET(url);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<APILakuEmas>(result).data.mid_price;
        }

        public class APILakuEmas
        {
            public int success { get; set; }
            public RateLM data { get; set; }
        }

        public class RateLM
        {
            public int buy_price { get; set; }
            public int sell_price { get; set; }
            public int mid_price { get; set; }
        }

        //POST
        public string WebRequestPOST(string url, string json = null)
        {
            //JSON result
            WebRequest req = WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/json";

            string result = "";

            try
            {
                using (WebResponse response = (WebResponse)req.GetResponse())
                {
                    result = new StreamReader(response.GetResponseStream()).ReadToEnd();
                }

            }
            catch (WebException ex)
            {
                using (WebResponse response = ex.Response)
                {
                    result = new StreamReader(response.GetResponseStream()).ReadToEnd();
                }
            }

            return result;
        }

        //GET
        public string WebRequestGET(string url, string json = null)
        {
            //JSON result
            WebRequest req = WebRequest.Create(url);
            req.Method = "GET";
            req.ContentType = "application/json";

            string result = "";

            try
            {
                using (WebResponse response = (WebResponse)req.GetResponse())
                {
                    result = new StreamReader(response.GetResponseStream()).ReadToEnd();
                }

            }
            catch (WebException ex)
            {
                using (WebResponse response = ex.Response)
                {
                    result = new StreamReader(response.GetResponseStream()).ReadToEnd();
                }
            }

            return result;
        }

        public class AddTransaction
        {
            public string customer_name { get; set; }
            public string customer_email { get; set; }
            public string customer_address { get; set; }
            public string customer_ktp { get; set; }
            public string customer_handphone { get; set; }
            public int bank_id { get; set; }
            public string bank_account_number { get; set; }
            public string bank_account_name { get; set; }
            public string store_code { get; set; }
            public string plu_code { get; set; }
            public decimal weight { get; set; }
            public string keterangan { get; set; }
            public decimal jaws_price { get; set; }
            public string cashbox_code { get; set; }
            public string third_party { get; set; }
            public string signature_key { get; set; }
        }

        public class ItemPLU
        {
            public string plu_code { get; set; }
            public decimal weight { get; set; }
            public decimal jaws_price { get; set; }
        }

        public class CashboxList
        {
            public string store_code { get; set; }
            public string third_party { get; set; }
            public string signature_key { get; set; }
        }

        public class ResponseCashboxList
        {
            public bool success { get; set; }
            public string message { get; set; }
            public List<ResponseCashboxListData> data { get; set; }
        }

        public class ResponseCashboxListData
        {
            public int id { get; set; }
            public string code { get; set; }
            public int? id_toko { get; set; }
            public int? id_toko_to { get; set; }
            public string status { get; set; }
            public DateTime created_at { get; set; }
        }

        public class ResponseAddTransaction
        {
            public string success { get; set; }
            public string message { get; set; }
            public DataTransaction data { get; set; }
        }

        public class DataTransaction
        {
            public string transaction_code { get; set; }
        }

        public static int MappingBank(int idbank)
        {
            int idbanklei = 1;
            switch (idbank)
            {
                case 1:
                    idbanklei = 1; //BCA
                    break;
                case 2:
                    idbanklei = 2; //Mandiri
                    break;
                case 14:
                    idbanklei = 3; //Permata
                    break;
                case 7:
                    idbanklei = 4; //Danamon
                    break;
                case 3:
                    idbanklei = 5; //BNI
                    break;
                case 13:
                    idbanklei = 6; //BRI
                    break;
                case 11:
                    idbanklei = 7; //CIMB
                    break;
                case 10:
                    idbanklei = 8; //Mega
                    break;
                case 18:
                    idbanklei = 9; //NISP
                    break;
                case 17:
                    idbanklei = 10; //Panin
                    break;
                case 23:
                    idbanklei = 23; //Bank DKI
                    break;
                default:
                    idbanklei = 1; //
                    break;
            }
            return idbanklei;
        }
        #endregion
    }
}
