using Connection.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Connection.Interface
{
    public interface IStampsRepository
    {
        object GetMembership(string user);
        object MemberSuggestion(string query);
        object GetMembershipByCode(string code);
        object ValidateVoucherCode(string vouchercode, short stampsstore);
        object AddTransaction(string user, short stampsstore, int stamps, string invoicenumber, int totalvalue, int subtotal, string employeecode, int numberofpeople, int tax, string createdatetime, string requireemailnotif, List<StampsConfiguration.Item> items, List<StampsConfiguration.ExtraData> extradata, List<StampsConfiguration.StampsPayment> payments);
        object CancelTransaction(int id);
        object ModifyTransaction(int id, int totalvalue, int subtotal, int stamps, List<StampsConfiguration.Item> items);
        object RedeemVoucher(string identifier, string vouchercode, short store);
        object CancelVoucher(int id);
        object AddTransactionWithRedemptionVoucher(string redemptionid, string invoicenumber);
    }
}
