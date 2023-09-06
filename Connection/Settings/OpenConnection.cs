using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Connection.Settings
{
    public class OpenConnection
    {
		public DataTable Rs(string strSql, string CnnString)
		{
			SqlConnection sqlCnn = new SqlConnection(CnnString);
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(strSql, sqlCnn);
			sqlAdapter.SelectCommand.CommandTimeout = 300; // 300 sec or 5 mins for long time query
			DataSet objDS = new DataSet();
			sqlAdapter.Fill(objDS, "data");
			sqlCnn.Close();

			DataTable rs = new DataTable();
			rs = objDS.Tables["data"];

			return rs;
		}

		public DataSet Ds(string strSql, string CnnString)
		{
			SqlConnection sqlCnn = new SqlConnection(CnnString);
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(strSql, sqlCnn);
			sqlAdapter.SelectCommand.CommandTimeout = 300; // 300 sec or 5 mins for long time query
			DataSet objDS = new DataSet();
			sqlAdapter.Fill(objDS, "data");
			sqlCnn.Close();

			return objDS;
		}

		//Execute Command
		public void Execute(string strSql, string CnnString)
		{
			SqlConnection sqlCnn = new SqlConnection(CnnString);
			SqlCommand sqlCmd = new SqlCommand(strSql, sqlCnn);
			sqlCmd.CommandTimeout = 300; // 300 sec or 5 mins for long time query
			sqlCnn.Open();
			sqlCmd.ExecuteNonQuery();
			sqlCnn.Close();
		}

		//Scalar Function
		public string SingleString(string strSql, string CnnString)
		{
			SqlConnection sqlCnn = new SqlConnection(CnnString);
			SqlCommand sqlCmd = new SqlCommand(strSql, sqlCnn);
			sqlCnn.Open();
			string x = "";
			x = (string)sqlCmd.ExecuteScalar();
			sqlCnn.Close();

			return x;
		}
		public int SingleInteger(string strSql, string CnnString)
		{
			SqlConnection sqlCnn = new SqlConnection(CnnString);
			SqlCommand sqlCmd = new SqlCommand(strSql, sqlCnn);
			sqlCnn.Open();
			int x = (int)sqlCmd.ExecuteScalar();
			sqlCnn.Close();

			return x;
		}
		public  decimal SingleDecimal(string strSql, string CnnString)
		{
			SqlConnection sqlCnn = new SqlConnection(CnnString);
			SqlCommand sqlCmd = new SqlCommand(strSql, sqlCnn);
			sqlCnn.Open();
			decimal x = Convert.ToDecimal(sqlCmd.ExecuteScalar());
			sqlCnn.Close();

			return x;
		}
		public bool SingleBool(string strSql, string CnnString)
		{
			SqlConnection sqlCnn = new SqlConnection(CnnString);
			SqlCommand sqlCmd = new SqlCommand(strSql, sqlCnn);
			sqlCnn.Open();
			bool x = (bool)sqlCmd.ExecuteScalar();
			sqlCnn.Close();

			return x;
		}
		public byte SingleByte(string strSql, string CnnString)
		{
			SqlConnection sqlCnn = new SqlConnection(CnnString);
			SqlCommand sqlCmd = new SqlCommand(strSql, sqlCnn);
			sqlCnn.Open();
			byte x = (byte)sqlCmd.ExecuteScalar();
			sqlCnn.Close();

			return x;
		}
		public DateTime SingleTime(string strSql, string CnnString)
		{
			SqlConnection sqlCnn = new SqlConnection(CnnString);
			SqlCommand sqlCmd = new SqlCommand(strSql, sqlCnn);
			sqlCnn.Open();
			DateTime x = (DateTime)sqlCmd.ExecuteScalar();
			sqlCnn.Close();

			return x;
		}

		public int SingleInteger(DataTable dt, string sp, string CnnString)
        {
			int SingleInt = 0;
			using (SqlConnection conn = new SqlConnection(CnnString))
			{
				SqlCommand cmd = conn.CreateCommand();
				cmd.CommandType = System.Data.CommandType.StoredProcedure;
				cmd.CommandText = sp; //The name of the above mentioned stored procedure.  
				SqlParameter param = cmd.Parameters.AddWithValue("@Data", dt); //Here"@MyUDTableType" is the User-defined Table Type as a parameter.  

				SqlParameter RuturnValue = new SqlParameter("@retValue", SqlDbType.Int);
				RuturnValue.Direction = ParameterDirection.Output;
				cmd.Parameters.Add(RuturnValue);

				conn.Open();
				cmd.ExecuteNonQuery();
				SingleInt = (int)cmd.Parameters["@retValue"].Value;
				conn.Close();
			}

			return SingleInt;
		}

		public void Execute(DataTable dt, string sp, string CnnString)
        {
			using (SqlConnection conn = new SqlConnection(CnnString))
			{
				SqlCommand cmd = conn.CreateCommand();
				cmd.CommandType = System.Data.CommandType.StoredProcedure;
				cmd.CommandText = sp; //The name of the above mentioned stored procedure.  
				SqlParameter param = cmd.Parameters.AddWithValue("@Data", dt); //Here"@MyUDTableType" is the User-defined Table Type as a parameter.  
				conn.Open();
				cmd.ExecuteNonQuery();
				conn.Close();
			}
		}
	}
}
