using Connection.Interface;
using Connection.Models;
using Connection.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Net;
using Newtonsoft.Json;

namespace Connection.Repositories
{
    public class DataCustomerRepository : IDataCustomerRepository
    {
        private readonly JAWSDbContext _context;
        private readonly StampsRepository _stamps;
        private readonly OpenConnection _openConnection;
        private readonly ConnectionString _connectionString;

        public DataCustomerRepository()
        {
            _context = new JAWSDbContext();
            _stamps = new StampsRepository();
            _openConnection = new OpenConnection();
            _connectionString = new ConnectionString();
        }

        public object GetDataCustomerByKeyword(string kw, int searchby)
        {
            string brand = _connectionString.AppConfig.BrandCode;
            List<object> result = new List<object>();
            dynamic datacustomerstamps = _stamps.MemberSuggestion(kw);
            if (datacustomerstamps.status_code == HttpStatusCode.OK)
            {
                StampsResponse.ResponseMemberSuggestions customerstamps = Newtonsoft.Json.JsonConvert.DeserializeObject<StampsResponse.ResponseMemberSuggestions>(datacustomerstamps.result);
                if (customerstamps.suggestions.Length > 0)
                {
                    foreach (var item in customerstamps.suggestions)
                    {
                        try
                        {
                            dynamic datacustomerstampsdetail = _stamps.GetMembership(item.id.ToString());
                            if (datacustomerstamps.status_code == HttpStatusCode.OK)
                            {
                                StampsResponse.ResponseMembership customerstampsdetail = Newtonsoft.Json.JsonConvert.DeserializeObject<StampsResponse.ResponseMembership>(datacustomerstampsdetail.result);
                                if (customerstampsdetail.user.member_ids != null && customerstampsdetail.user.id != 0.ToString())
                                {
                                    string m_kode = customerstampsdetail.user.member_ids[0];
                                    string m_group = "";
                                    string m_nama = customerstampsdetail.user.name.ToUpper();
                                    string m_alamat = customerstampsdetail.user.address.ToUpper();
                                    string m_kota = "";
                                    string m_telepon1 = customerstampsdetail.user.phone;
                                    string m_telepon2 = "";
                                    string m_fax = "";
                                    string m_email = customerstampsdetail.user.email;
                                    string m_npwp = "";
                                    string m_status = "00";
                                    string m_tmplahir = "";
                                    string m_tgllahir = Convert.ToDateTime(customerstampsdetail.user.birthday).ToString("yyyy-MM-dd");
                                    string m_agama = "00";
                                    string m_cabang = "";
                                    string m_kodesales = "";
                                    string m_referensi = "";
                                    string m_pinbb = "";
                                    int m_tanggal = Convert.ToDateTime(customerstampsdetail.user.birthday).Day;
                                    int m_bulan = Convert.ToDateTime(customerstampsdetail.user.birthday).Month;
                                    int m_tahun = Convert.ToDateTime(customerstampsdetail.user.birthday).Year;
                                    string m_ktp = "";
                                    string m_validktp = "";
                                    string m_email2 = "";
                                    long m_stampsstatusmembership = customerstampsdetail.membership.status ?? 0;
                                    string m_stampsstatusmembership_text = customerstampsdetail.membership.status_text;
                                    long m_stampspoint = customerstampsdetail.membership.stamps ?? 0;
                                    string m_loginid = "";
                                    string m_stampsuserid = customerstampsdetail.user.id;
                                    string m_gender = "";
                                    string m_brand = brand;
                                    CreateOrUpdateCustomerByStampsID(m_kode, m_group, m_nama, m_alamat, m_kota, m_telepon1,
                                        m_telepon2, m_fax, m_email, m_npwp, m_status, m_tmplahir, m_tgllahir, m_agama, m_cabang,
                                        m_kodesales, m_referensi, m_pinbb, m_tanggal, m_bulan, m_tahun, m_ktp, m_validktp, m_email2,
                                        m_stampsstatusmembership, m_stampsstatusmembership_text, m_stampspoint, m_loginid, m_stampsuserid, m_gender, m_brand);
                                }
                            }
                            else
                            {
                                StampsResponse.ResponseErrorGeneral error = JsonConvert.DeserializeObject<StampsResponse.ResponseErrorGeneral>(datacustomerstampsdetail.result);
                            }
                        }
                        catch { }
                        var test = _context.DataCustomers.SingleOrDefault(p => p.NoCustomer == item.member_ids[0]);
                        result.Add(new
                        {
                            id_customer = (test == null) ? 0 : test.Id,
                            id_customer_stamps = Convert.ToInt32(item.id),
                            customer_name = item.name.ToUpper(),
                            e_receipt_email = item.email,
                            e_receipt_hp = item.phone,
                            tgllahir = Convert.ToDateTime(item.birthday).ToString("dd-MM-yyyy"),
                            kodecustomer = item.member_ids[0],
                            membership = item.membership.ToUpper()
                        });
                    }
                    return new { message = "", data = result };
                }
                else
                {
                    return new { message = "No Data" };
                }
            }
            else
            {
                StampsResponse.ResponseErrorGeneral error = JsonConvert.DeserializeObject<StampsResponse.ResponseErrorGeneral>(datacustomerstamps.result);
                return new { message = error.detail };
            }
        }

        public object GetDataCustomerByID(int id)
        {
            var datacustomer = _context.DataCustomers.SingleOrDefault(p => p.Id == id);
            if (datacustomer != null)
            {
                int idstampscust = _openConnection.SingleInteger("SELECT TOP 1 ISNULL(IDCustomerStamps,0) [IDStamps] FROM DataCustomer WHERE ID = " + datacustomer.Id, _connectionString.ConnectionStrings.Cnn_DB);
                return new
                {
                    message = "",
                    data = new
                    {
                        id = datacustomer.Id,
                        nama = datacustomer.Nama.ToUpper(),
                        email = datacustomer.AddrEmail.ToUpper(),
                        phone = datacustomer.AddrNoTelp,
                        tgllahir = Convert.ToDateTime(datacustomer.TglLahir).ToString("dd-MM-yyyy"),
                        kodecustomer = datacustomer.NoCustomer,
                        idcustomerstamps = idstampscust
                    }
                };
            }
            else
            {
                return new { message = "Failed. Customer not found." };
            }
        }

        private object CreateOrUpdateCustomerByStampsID(string m_kode, string m_group, string m_nama,
            string m_alamat, string m_kota, string m_telepon1, string m_telepon2, string m_fax, string m_email,
            string m_npwp, string m_status, string m_tmplahir, string m_tgllahir, string m_agama,
            string m_cabang, string m_kodesales, string m_referensi, string m_pinbb, int m_tanggal,
            int m_bulan, int m_tahun, string m_ktp, string m_validktp, string m_email2, long m_stampsstatusmembership, string m_stampsstatusmembership_text,
            long m_stampspoint, string m_loginid, string m_stampsuserid, string m_gender, string m_brand)
        {
            string queryjaws = "EXEC sp_insert_update_datacustomer_new";
            string querymyapps = "EXEC sp_savecustomerstampsnew";

            querymyapps += " '" + m_kode + "'," +
                    " '" + m_group + "', '" + m_nama + "'," +
                    " '" + m_alamat + "', '" + m_kota + "'," +
                    " '" + m_telepon1 + "', '" + m_telepon2 + "'," +
                    " '" + m_fax + "', '" + m_email + "'," +
                    " '" + m_npwp + "', '" + m_status + "'," +
                    " '" + m_tmplahir + "', '" + m_tgllahir + "'," +
                    " '" + m_agama + "', '" + m_cabang + "'," +
                    " '" + m_kodesales + "', '" + m_referensi + "'," +
                    " '" + m_pinbb + "', '" + m_tanggal + "', '" + m_bulan + "'," +
                    " '" + m_tahun + "', '" + m_ktp + "', '" + m_validktp + "'," +
                    " '" + m_email2 + "', '" + m_stampsstatusmembership + "'," +
                    " '" + m_stampspoint + "', '" + m_loginid + "'," +
                    " '" + m_stampsuserid + "','" + m_gender + "', '" + m_brand + "'";

            string m_type_member = "M01";
            switch (m_stampsstatusmembership)
            {
                case 10:
                    m_type_member = "M00";
                    break;
                case 20:
                    m_type_member = "M01";
                    break;
                case 30:
                    m_type_member = "M02";
                    break;
                case 40:
                    m_type_member = "M03";
                    break;
                case 50:
                    m_type_member = "M04";
                    break;
                case 60:
                    m_type_member = "M06";
                    break;
                case 70:
                    m_type_member = "M05";
                    break;
            }

            queryjaws += " '" + m_kode + "','" + m_nama + "', '" + m_stampsstatusmembership_text + "'," +
                         " '" + DateTime.Now.ToString("yyyy-MM-dd") + "', '" + m_telepon1 + "', '" + m_email + "'," +
                         " '" + m_tgllahir + "', '" + m_stampsuserid + "', '" + m_brand + "'";
            //string query = "BEGIN TRY BEGIN TRAN C " + querymyapps + " " + queryjaws + " COMMIT TRAN C SELECT '' [MESSAGE] END TRY BEGIN CATCH ROLLBACK TRAN C SELECT ERROR_MESSAGE() [MESSAGE] END CATCH";
            string resultmyapps = _openConnection.SingleString("BEGIN TRY BEGIN TRAN C " + querymyapps + " COMMIT TRAN C SELECT '' [MESSAGE] END TRY BEGIN CATCH ROLLBACK TRAN C SELECT ERROR_MESSAGE() [MESSAGE] END CATCH", _connectionString.ConnectionStrings.Cnn_CMK);
            string result = "";
            if (resultmyapps != "")
            {
                result = resultmyapps;
            }
            else
            {
                result = _openConnection.SingleString("BEGIN TRY BEGIN TRAN C " + queryjaws + " COMMIT TRAN C SELECT '' [MESSAGE] END TRY BEGIN CATCH ROLLBACK TRAN C SELECT ERROR_MESSAGE() [MESSAGE] END CATCH", _connectionString.ConnectionStrings.Cnn_DB);
            }
            if (result == "")
            {
                var datacustomerjaws = _context.DataCustomers.SingleOrDefault(p => p.Id == Convert.ToInt32(m_stampsuserid));
                if (datacustomerjaws != null)
                {
                    string errormyapps = _openConnection.SingleString("EXEC " + querymyapps + " ", _connectionString.ConnectionStrings.Cnn_CMK);
                    if (errormyapps == "")
                    {
                        string errorjaws = _openConnection.SingleString("EXEC " + queryjaws + " ", _connectionString.ConnectionStrings.Cnn_DB);
                        if (errorjaws == "")
                        {
                            return new { message = "" };
                        }
                        else
                        {
                            return new { message = "Failed. " + errorjaws };
                        }
                    }
                    else
                    {
                        return new { message = "Failed. " + errormyapps };
                    }
                }
                else
                {
                    dynamic datacustomerstamps = _stamps.GetMembership(Convert.ToInt32(m_stampsuserid).ToString());
                    StampsResponse.ResponseMembership customerstamps = Newtonsoft.Json.JsonConvert.DeserializeObject<StampsResponse.ResponseMembership>(datacustomerstamps.result);
                    if (customerstamps.user != null)
                    {
                        string errormyapps = _openConnection.SingleString("EXEC " + querymyapps + " ", _connectionString.ConnectionStrings.Cnn_CMK);
                        if (errormyapps == "")
                        {
                            string errorjaws = _openConnection.SingleString("EXEC " + queryjaws + " ", _connectionString.ConnectionStrings.Cnn_DB);
                            if (errorjaws == "")
                            {
                                return new { message = "" };
                            }
                            else
                            {
                                return new { message = "Failed." + errorjaws };
                            }
                        }
                        else
                        {
                            return new { message = "Failed." + errormyapps };
                        }
                    }
                    else
                    {
                        return new { message = "Failed.  Customer not found." };
                    }
                }
            }
            else
            {
                return new { message = result };
            }
        }
    }
}
