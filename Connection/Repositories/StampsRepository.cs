using Connection.Interface;
using Connection.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Connection.Repositories
{
    public class StampsRepository : IStampsRepository
    {
        private readonly StampsConfiguration _sc;

        public StampsRepository()
        {
            _sc = new StampsConfiguration();
        }

        public object GetMembership(string user)
        {
            return _sc.GetMembership(user);
        }

        public object MemberSuggestion(string query)
        {
            return _sc.MemberSuggestions(query);
        }

        public object GetMembershipByCode(string code)
        {
            return _sc.GetMembershipByCode(code);
        }

        public object ValidateVoucherCode(string vouchercode, short stampsstore)
        {
            return _sc.ValidateVoucherCode(vouchercode, stampsstore);
        }

        public object AddTransaction(string user, short stampsstore, int stamps, string invoicenumber, int totalvalue, int subtotal, string employeecode, int numberofpeople, int tax, string createdatetime, string requireemailnotif, List<StampsConfiguration.Item> items, List<StampsConfiguration.ExtraData> extradata, List<StampsConfiguration.StampsPayment> payments)
        {
            return _sc.AddTransaction(user, stampsstore, stamps, invoicenumber, totalvalue, subtotal, employeecode, numberofpeople, tax, createdatetime, requireemailnotif, items, extradata, payments);
        }

        public object CancelTransaction(int id)
        {
            return _sc.CancelTransaction(id);
        }

        public object ModifyTransaction(int id, int totalvalue, int subtotal, int stamps, List<StampsConfiguration.Item> items)
        {
            return _sc.ModifyTransaction(id, totalvalue, subtotal, stamps, items);
        }

        public object RedeemVoucher(string identifier, string vouchercode, short store)
        {
            return _sc.RedeemVoucherCode(identifier, vouchercode, store);
        }

        public object CancelVoucher(int id)
        {
            return _sc.CancelRedemptions(id);
        }

        public object AddTransactionWithRedemptionVoucher(string redemptionid, string invoicenumber)
        {
            return _sc.AddTransactionWithRedemptionVoucher(redemptionid, invoicenumber);
        }
    }
}
