using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Connection.Settings;
using static Connection.Settings.StampsConfiguration;

namespace Connection.Settings
{
    public class StampsConfiguration
    {
        ConnectionString connectionString;
        private readonly string BASE_URL;//ApiIntegration.Stamps.Development.Url;
        private readonly string TOKEN;//ApiIntegration.Stamps.Development.Token;
        private readonly string MERCHANT;//ApiIntegration.Stamps.Development.Merchant;
        public StampsConfiguration()
        {
            connectionString = new ConnectionString();
            //Production
            if (connectionString.AppConfig.Level == 1)
            {
                BASE_URL = connectionString.AppConfig.Production.StampsConnection.BASE_URL;
                TOKEN = connectionString.AppConfig.Production.StampsConnection.TOKEN;
                MERCHANT = connectionString.AppConfig.Production.StampsConnection.MERCHANT;
            }
            else
            {
                BASE_URL = connectionString.AppConfig.Development.StampsConnection.BASE_URL;
                TOKEN = connectionString.AppConfig.Development.StampsConnection.TOKEN;
                MERCHANT = connectionString.AppConfig.Development.StampsConnection.MERCHANT;
            }
        }

        #region GETMETHOD
        public object GetMembership(string _user)
        {
            string CURRENT_URL = "v2/memberships/details?token=" + TOKEN + "&user=" + _user + "&merchant=" + MERCHANT + "";
            using (HttpClient httpc = new HttpClient())
            {
                return Task.Run(() => GetAsynchronous(httpc, BASE_URL + CURRENT_URL)).Result;
            }
        }

        public object MemberSuggestions(string _query)
        {
            string CURRENT_URL = "memberships/suggestions?token=" + TOKEN + "&query=" + _query + "&merchant=" + MERCHANT + "";
            using (HttpClient httpc = new HttpClient())
            {
                return Task.Run(() => GetAsynchronous(httpc, BASE_URL + CURRENT_URL)).Result;
            }
        }

        public object GetMembershipByCode(string _card_number)
        {
            string CURRENT_URL = "v2/memberships/user-by-card-number?token=" + TOKEN + "&card_number=" + _card_number + "&merchant=" + MERCHANT + "";
            using (HttpClient httpc = new HttpClient())
            {
                return Task.Run(() => GetAsynchronous(httpc, BASE_URL + CURRENT_URL)).Result;
            }
        }

        public object ValidateVoucherCode(string _voucher_code, long _store)
        {
            string CURRENT_URL = "vouchers/validate?token=" + TOKEN + "&voucher_code=" + _voucher_code + "&store=" + _store.ToString() + "";
            using (HttpClient httpc = new HttpClient())
            {
                return Task.Run(() => GetAsynchronous(httpc, BASE_URL + CURRENT_URL)).Result;
            }
        }
        #endregion

        #region POSTMETHOD
        public object AddTransaction(string _user, long _store, long _stamps, string _invoiceNumber, long _totalValue, long _subTotal,
                                           string _employeeCode, long _numberOfPeople, long _tax, string _createdDateTime, string _requireEmailNotification,
                                           List<Item> _items, List<ExtraData> _extra_data, List<StampsPayment> _payments)
        {
            string CURRENT_URL = "v2/transactions/add";
            using (HttpClient httpc = new HttpClient())
            {
                using StringContent jsonContent = new(Newtonsoft.Json.JsonConvert.SerializeObject(new
                {
                    token = TOKEN,
                    user = _user,
                    store = _store,
                    stamps = _stamps,
                    invoice_number = _invoiceNumber,
                    total_value = _totalValue,
                    sub_total = _subTotal,
                    employee_code = _employeeCode,
                    number_of_people = _numberOfPeople,
                    tax = _tax,
                    created = _createdDateTime,
                    require_email_notification = _requireEmailNotification,
                    items = _items,
                    extra_data = _extra_data,
                    payments = _payments
                }), Encoding.UTF8, "application/json");
                return Task.Run(() => PostAsynchronous(httpc, BASE_URL + CURRENT_URL, jsonContent)).Result;
            }
        }

        public object CancelTransaction(long _id)
        {
            string CURRENT_URL = "transactions/cancel";
            using (HttpClient httpc = new HttpClient())
            {
                using StringContent jsonContent = new(Newtonsoft.Json.JsonConvert.SerializeObject(new
                {
                    token = TOKEN,
                    id = _id
                }), Encoding.UTF8, "application/json");
                return Task.Run(() => PostAsynchronous(httpc, BASE_URL + CURRENT_URL, jsonContent)).Result;
            }
        }

        public object ModifyTransaction(long _id, long _totalValue, long _subTotal,
                                              long _stamps, List<Item> _items)
        {
            const string CURRENT_URL = "v2/transactions/modify";
            using (HttpClient httpc = new HttpClient())
            {
                using StringContent jsonContent = new(Newtonsoft.Json.JsonConvert.SerializeObject(new
                {
                    token = TOKEN,
                    id = _id,
                    total_value = _totalValue,
                    subtotal = _subTotal,
                    stamps = _stamps,
                    items = _items
                }), Encoding.UTF8, "application/json");
                return Task.Run(() => PostAsynchronous(httpc, BASE_URL + CURRENT_URL, jsonContent)).Result;
            }
        }

        public object CancelRedemptions(long _id)
        {
            const string CURRENT_URL = "redemptions/cancel";
            using (HttpClient httpc = new HttpClient())
            {
                using StringContent jsonContent = new(Newtonsoft.Json.JsonConvert.SerializeObject(new
                {
                    token = TOKEN,
                    id = _id
                }), Encoding.UTF8, "application/json");
                return Task.Run(() => PostAsynchronous(httpc, BASE_URL + CURRENT_URL, jsonContent)).Result;
            }
        }

        public object RedeemVoucherCode(string _identifier, string _voucher_code, long _store)
        {
            const string CURRENT_URL = "vouchers/redeem";
            using (HttpClient httpc = new HttpClient())
            {
                using StringContent jsonContent = new(Newtonsoft.Json.JsonConvert.SerializeObject(new
                {
                    token = TOKEN,
                    identifier = _identifier,
                    voucher_code = _voucher_code,
                    store = _store
                }), Encoding.UTF8, "application/json");
                return Task.Run(() => PostAsynchronous(httpc, BASE_URL + CURRENT_URL, jsonContent)).Result;
            }
        }

        public object AddTransactionWithRedemptionVoucher(string _redemption_id, string _invoicenumber)
        {
            const string CURRENT_URL = "https://crm.cmkclub.com/api/v2/redemptions/add-invoice-number";
            using (HttpClient httpc = new HttpClient())
            {
                using StringContent jsonContent = new(Newtonsoft.Json.JsonConvert.SerializeObject(new
                {
                    token = TOKEN,
                    redemption_id = _redemption_id,
                    invoice_number = _invoicenumber
                }), Encoding.UTF8, "application/json");
                return Task.Run(() => PostAsynchronous(httpc, CURRENT_URL, jsonContent)).Result;
            }
        }

        #endregion

        public class Item
        {
            public string product_name; // Di isi dengan `ProductCode` oleh Pihak CMK
            public long quantity;
            public ItemExtraData extra_data;
            public long stamps_subtotal;
            public long subtotal;
        }

        public class ItemExtraData
        {
            /*
             * Jika ada informasi tambah yang ingin disimpan.
             * Silahkan tambahkan property pada class `ItemExtraData` berdasarkan kebutuhan.
             * Informasi property dibawah merupakan contoh saja.
             */

            public string category;
            public string item;
            public string level;
            public string stonedistribution;
            public string type;
        }

        public class ExtraData
        {
            /*Jika ada informasi tambahan yang ingin disimpan, silahkan tambahkan property pada class `ExtraData` ini.*/
        }

        public class StampsPayment
        {
            public long payment_method;
            public long value;
            public bool eligible_for_membership;
        }

        public async Task<object> GetAsynchronous(HttpClient httpClient, string url)
        {
            using HttpResponseMessage response = await httpClient.GetAsync(url);
            string result = await response.Content.ReadAsStringAsync();
            return new { status_code = response.StatusCode, result };
        }

        public async Task<object> PostAsynchronous(HttpClient httpClient, string url, StringContent sc)
        {
            using HttpResponseMessage response = await httpClient.PostAsync(url, sc);
            string result = await response.Content.ReadAsStringAsync();
            return new { status_code = response.StatusCode, result };
        }
    }

    public class StampsResponse : StampsConfiguration
    {
        #region Response Message General
        public class ResponseErrorGeneral
        {
            public string detail;
            public string error_message;
        }
        #endregion

        #region "Response Existing Transaction ID"
        public class ResponseExistingTransactionID
        {
            public long existing_transaction_id;
        }
        #endregion

        #region "Response Membership"
        public class ResponseMembership
        {
            public ResponseMembership.Membership membership;
            public ResponseMembership.User user;

            public class Membership
            {
                public string[] tags;
                public long? status = 0;
                public string status_text;
                public long? stamps = 0;
                public long? balance = 0;
                public bool is_blocked;
                public string referral_code;
                public string start_date;
                public string created;
            }

            public class User
            {
                public string id;
                public string name;
                public string gender;
                public string address;
                public bool is_active;
                public string email;
                public string picture_url;
                public string birthday;
                public string phone;
                public bool protected_redemption;
                public bool has_incorrect_email;
                public string[] member_ids;
                public string primary_member_id;
            }
        }
        #endregion

        #region "Response Add Transaction"
        public class ResponseAddTransaction
        {
            public ResponseAddTransaction.Transaction transaction;
            public ResponseAddTransaction.Customer customer;

            public class Transaction
            {
                public long id;
                public double? value = 0;
                public long? stamps_earned = 0;
                public int? number_of_people = 0;
                public double? discount = 0;
            }

            public class Customer
            {
                public long id;
                public string mobile_phone;
                public long? stamps_remaining = 0;
                public string status;
                public long? balance = 0;
            }
        }
        #endregion

        #region "Response Cancel Transaction"
        public class ResponseCancelTransaction
        {
            public ResponseCancelTransaction.Transaction transaction;
            public ResponseCancelTransaction.Customer customer;

            public class Transaction
            {
                public long? stamps_earned = 0;
                public long id;
                public double? value = 0;
                public string status;
            }

            public class Customer
            {
                public string status;
                public long id;
                public string mobile_number;
                public long? stamps_remaining = 0;
            }
        }
        #endregion

        #region "Response Modify Transaction"
        public class ResponseModifyTransaction
        {
            public ResponseModifyTransaction.Transaction transaction;
            public ResponseModifyTransaction.Customer customer;

            public class Transaction
            {
                public long id;
                public double? value = 0;
                public long? stamps_earned = 0;
                public int? number_of_people = 0;
            }

            public class Customer
            {
                public long id;
                public string mobile_phone;
                public long? stamps_remaining = 0;
                public string status;
                public long? balance = 0;
            }
        }
        #endregion

        #region "Response Member Suggestions"
        public class ResponseMemberSuggestions
        {
            public ResponseMemberSuggestions.Suggestions[] suggestions;

            public class Suggestions
            {
                public long id;
                public string member_id;
                public string[] member_ids;
                public string name;
                public string birthday;
                public string address;
                public int? gender = null;
                public string email;
                public string phone;
                public long? stamps = 0;
                public string membership;
                public long? balance = 0;
                public bool is_active;
                public string identifier;
            }
        }
        #endregion

        #region "Response Validate Voucher Code"
        public class ResponseValidateVoucherCode
        {
            public ResponseValidateVoucherCode.Voucher voucher;
            public ResponseValidateVoucherCode.User user;

            public bool is_redeemable;
            public string detail;
            public string error_message;
            public string error_code;

            public class Voucher
            {
                public long id;
                public string name;
                public ExtraData extra_data;
                public string validity;
                public string start_date;
                public string end_date;
            }

            public class User
            {
                public string name;
                public string email;
                public string phone;
            }

            public class ExtraData
            {
                public string voucher_type;
                public long voucher_nominal;
                public string voucher_validity;
                public long voucher_valid_for;
                public DateTime? voucher_date_start;
                public DateTime? voucher_date_end;
            }
        }
        #endregion

        #region "Response Redeem Voucher Code"
        public class ResponseRedeemVoucherCode
        {
            public ResponseRedeemVoucherCode.Redemption redemption;
            public ResponseRedeemVoucherCode.Voucher voucher;

            public class Redemption
            {
                public long id;
            }

            public class Voucher
            {
                public long id;
                public string name;
                public dynamic extra_data;
            }
        }
        #endregion

        #region "Response Cancel Redemptions"
        public class ResponseCancelRedemptions
        {
            public ResponseCancelRedemptions.Redemption redemption;
            public ResponseCancelRedemptions.Customer customer;

            public class Redemption
            {
                public long id;
                public string status;
            }

            public class Customer
            {
                public string status;
                public long id;
                public long? stamps_remaining = 0;
            }
        }
        #endregion

        #region "Response Get Membership by Code"
        public class ResponseGetMembershipByCode
        {
            public ResponseGetMembershipByCode.Membership membership;
            public ResponseGetMembershipByCode.User user;

            public class Membership
            {
                public string[] tags;
                public long? status = 0;
                public string status_text;
                public long? stamps = 0;
                public long? balance = 0;
                public bool is_blocked;
                public string referral_code;
                public string start_date;
                public string created;
            }

            public class User
            {
                public string id;
                public string name;
                public string gender;
                public string address;
                public bool is_active;
                public string email;
                public string picture_url;
                public string birthday;
                public string phone;
                public bool protected_redemption;
                public bool has_incorrect_email;
                public string[] member_ids;
            }
        }
        #endregion
    }
}
