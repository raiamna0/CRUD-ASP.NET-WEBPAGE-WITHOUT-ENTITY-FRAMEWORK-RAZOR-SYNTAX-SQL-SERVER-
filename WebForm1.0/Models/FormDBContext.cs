using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace WebForm1._0.Models
{
	public class FormDBContext
	{
		string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
		public List<FormData> getData()
		{
			List<FormData> dataList = new List<FormData>();

			SqlConnection con = new SqlConnection(cs);
			SqlCommand cmd = new SqlCommand("spGetData", con);
			cmd.CommandType = CommandType.StoredProcedure;
			con.Open();
			SqlDataReader dr = cmd.ExecuteReader();
			while (dr.Read())
			{
				FormData data = new FormData();
				data.id = Convert.ToInt32(dr.GetValue(0).ToString());
				data.sheetName = dr.GetValue(12).ToString();
				data.Areas = dr.GetValue(7).ToString();
				data.owner = dr.GetValue(13).ToString();
				data.PlanType = dr.GetValue(6).ToString();
				data.CPA = dr.GetValue(1).ToString();
				data.CNPA = dr.GetValue(2).ToString();
				data.CC1FA = dr.GetValue(3).ToString();
				data.IM = dr.GetValue(4).ToString();
				data.C = dr.GetValue(5).ToString();

				data.Month = dr.GetValue(8).ToString();


				dataList.Add(data);
			}

			con.Close();


			return dataList;
		}
		public bool AddData(FormData data)
		{
			SqlConnection con = new SqlConnection(cs);

			SqlCommand cmd = new SqlCommand("spAddData", con);
			cmd.CommandType = CommandType.StoredProcedure;

			cmd.Parameters.AddWithValue("@PlanType", data.PlanType);

			if (data.SelectField == "CPA")
			{
				if (data.color != null)
				{
					data.CPA = data.color;
					cmd.Parameters.AddWithValue("@CPA", data.CPA);
					cmd.Parameters.AddWithValue("@CNPA", "");
					cmd.Parameters.AddWithValue("@CC1FA", "");
					cmd.Parameters.AddWithValue("@IM", "");
					cmd.Parameters.AddWithValue("@C", "");
				}
				else if (data.progress != null)
				{
					data.CPA = data.progress;
					cmd.Parameters.AddWithValue("@CPA", data.CPA);
					cmd.Parameters.AddWithValue("@CNPA", "");
					cmd.Parameters.AddWithValue("@CC1FA", "");
					cmd.Parameters.AddWithValue("@IM", "");
					cmd.Parameters.AddWithValue("@C", "");
				}
				else
				{
					cmd.Parameters.AddWithValue("@CPA", "NA");
					cmd.Parameters.AddWithValue("@CNPA", "");
					cmd.Parameters.AddWithValue("@CC1FA", "");
					cmd.Parameters.AddWithValue("@IM", "");
					cmd.Parameters.AddWithValue("@C", "");
				}
			}
			else if (data.SelectField == "CNPA")
			{

				if (data.color != null)
				{
					data.CNPA = data.color;
					cmd.Parameters.AddWithValue("@CPA", "");
					cmd.Parameters.AddWithValue("@CNPA", data.CNPA);
					cmd.Parameters.AddWithValue("@CC1FA", "");
					cmd.Parameters.AddWithValue("@IM", "");
					cmd.Parameters.AddWithValue("@C", "");
				}
				else if (data.progress != null)
				{
					data.CNPA = data.progress;
					cmd.Parameters.AddWithValue("@CPA", "");
					cmd.Parameters.AddWithValue("@CNPA", data.CNPA);
					cmd.Parameters.AddWithValue("@CC1FA", "");
					cmd.Parameters.AddWithValue("@IM", "");
					cmd.Parameters.AddWithValue("@C", "");
				}
				else
				{
					cmd.Parameters.AddWithValue("@CPA", "");
					cmd.Parameters.AddWithValue("@CNPA", "");
					cmd.Parameters.AddWithValue("@CC1FA", "");
					cmd.Parameters.AddWithValue("@IM", "");
					cmd.Parameters.AddWithValue("@C", "");
				}
			}
			else if (data.SelectField == "CC1FA")
			{
				if (data.color != null)
				{
					data.CC1FA = data.color;
					cmd.Parameters.AddWithValue("@CPA", "");
					cmd.Parameters.AddWithValue("@CNPA", "");
					cmd.Parameters.AddWithValue("@CC1FA", data.CC1FA);
					cmd.Parameters.AddWithValue("@IM", "");
					cmd.Parameters.AddWithValue("@C", "");
				}
				else if (data.progress != null)
				{
					data.CC1FA = data.progress;
					cmd.Parameters.AddWithValue("@CPA", "");
					cmd.Parameters.AddWithValue("@CNPA", "");
					cmd.Parameters.AddWithValue("@CC1FA", data.CC1FA);
					cmd.Parameters.AddWithValue("@IM", "");
					cmd.Parameters.AddWithValue("@C", "");
				}
				else
				{
					cmd.Parameters.AddWithValue("@CPA", "");
					cmd.Parameters.AddWithValue("@CNPA", "");
					cmd.Parameters.AddWithValue("@CC1FA", "");
					cmd.Parameters.AddWithValue("@IM", "");
					cmd.Parameters.AddWithValue("@C", "");
				}
			}
			else if (data.SelectField == "IM")
			{
				if (data.color != null)
				{
					data.IM = data.color;
					cmd.Parameters.AddWithValue("@CPA", "");
					cmd.Parameters.AddWithValue("@CNPA", "");
					cmd.Parameters.AddWithValue("@CC1FA", "");
					cmd.Parameters.AddWithValue("@IM", data.IM);
					cmd.Parameters.AddWithValue("@C", "");
				}
				else if (data.progress != null)
				{
					data.IM = data.progress;
					cmd.Parameters.AddWithValue("@CPA", "");
					cmd.Parameters.AddWithValue("@CNPA", "");
					cmd.Parameters.AddWithValue("@CC1FA", "");
					cmd.Parameters.AddWithValue("@IM", data.IM);
					cmd.Parameters.AddWithValue("@C", "");
				}
				else
				{
					cmd.Parameters.AddWithValue("@CPA", "");
					cmd.Parameters.AddWithValue("@CNPA", "");
					cmd.Parameters.AddWithValue("@CC1FA", "");
					cmd.Parameters.AddWithValue("@IM", "");
					cmd.Parameters.AddWithValue("@C", "");
				}
			}
			else if (data.SelectField == "C")
			{
				if (data.color != null)
				{
					data.C = data.color;
					cmd.Parameters.AddWithValue("@CPA", "");
					cmd.Parameters.AddWithValue("@CNPA", "");
					cmd.Parameters.AddWithValue("@CC1FA", "");
					cmd.Parameters.AddWithValue("@IM", "");
					cmd.Parameters.AddWithValue("@C", data.C);
				}
				else if (data.progress != null)
				{
					data.C = data.progress;
					cmd.Parameters.AddWithValue("@CPA", "");
					cmd.Parameters.AddWithValue("@CNPA", "");
					cmd.Parameters.AddWithValue("@CC1FA", "");
					cmd.Parameters.AddWithValue("@IM", "");
					cmd.Parameters.AddWithValue("@C", data.C);
				}
				else
				{
					cmd.Parameters.AddWithValue("@CPA", "");
					cmd.Parameters.AddWithValue("@CNPA", "");
					cmd.Parameters.AddWithValue("@CC1FA", "");
					cmd.Parameters.AddWithValue("@IM", "");
					cmd.Parameters.AddWithValue("@C", "");
				}
			}
			else
			{
				cmd.Parameters.AddWithValue("@CPA", "NA");
				cmd.Parameters.AddWithValue("@CNPA", "NA");
				cmd.Parameters.AddWithValue("@CC1FA", "NA");
				cmd.Parameters.AddWithValue("@IM", "NA");
				cmd.Parameters.AddWithValue("@C", "NA");
			}
			cmd.Parameters.AddWithValue("@Areas", data.Areas);
			cmd.Parameters.AddWithValue("@Month", data.Month);
			cmd.Parameters.AddWithValue("@sheet_name", data.Areas + " / " + data.owner);
			cmd.Parameters.AddWithValue("@Owner", data.owner);
			con.Open();
			int i = cmd.ExecuteNonQuery();


			con.Close();
			if (i > 0)
			{
				return true;
			}
			else
			{
				return false;
			}

		}
		public bool UpdateData(FormData data)
		{
			SqlConnection con = new SqlConnection(cs);
			SqlCommand cmd = new SqlCommand("UPDATE dbo.WebData SET CPA = @CPA,CNPA = @CNPA ,CC1FA = @CC1FA ,IM = @IM   ,C = @C    ,PlanType = @PlanType   ,Areas = @Areas    ,Month = @Month    ,sheet_name = @sheet_name     ,Owner = @Owner WHERE id=@id", con);
			
			cmd.Parameters.AddWithValue("@id", data.id);
			cmd.Parameters.AddWithValue("@PlanType", data.PlanType);
			if (data.SelectField == "CPA")
			{
				if (data.color != null)
				{
					data.CPA = data.color;
					cmd.Parameters.AddWithValue("@CPA", data.CPA);
					cmd.Parameters.AddWithValue("@CNPA", "");
					cmd.Parameters.AddWithValue("@CC1FA", "");
					cmd.Parameters.AddWithValue("@IM", "");
					cmd.Parameters.AddWithValue("@C", "");
				}
				else if (data.progress != null)
				{
					data.CPA = data.progress;
					cmd.Parameters.AddWithValue("@CPA", data.CPA);
					cmd.Parameters.AddWithValue("@CNPA", "");
					cmd.Parameters.AddWithValue("@CC1FA", "");
					cmd.Parameters.AddWithValue("@IM", "");
					cmd.Parameters.AddWithValue("@C", "");
				}
				else
				{
					cmd.Parameters.AddWithValue("@CPA", "NA");
					cmd.Parameters.AddWithValue("@CNPA", "");
					cmd.Parameters.AddWithValue("@CC1FA", "");
					cmd.Parameters.AddWithValue("@IM", "");
					cmd.Parameters.AddWithValue("@C", "");
				}
			}
			else if (data.SelectField == "C")
			{

				if (data.color != null)
				{
					data.CNPA = data.color;
					cmd.Parameters.AddWithValue("@CPA", "");
					cmd.Parameters.AddWithValue("@CNPA", data.CNPA);
					cmd.Parameters.AddWithValue("@CC1FA", "");
					cmd.Parameters.AddWithValue("@IM", "");
					cmd.Parameters.AddWithValue("@C", "");
				}
				else if (data.progress != null)
				{
					data.CNPA = data.progress;
					cmd.Parameters.AddWithValue("@CPA", "");
					cmd.Parameters.AddWithValue("@CNPA", data.CNPA);
					cmd.Parameters.AddWithValue("@CC1FA", "");
					cmd.Parameters.AddWithValue("@IM", "");
					cmd.Parameters.AddWithValue("@C", "");
				}
				else
				{
					cmd.Parameters.AddWithValue("@CPA", "");
					cmd.Parameters.AddWithValue("@CNPA", "");
					cmd.Parameters.AddWithValue("@CC1FA", "");
					cmd.Parameters.AddWithValue("@IM", "");
					cmd.Parameters.AddWithValue("@C", "");
				}
			}
			else if (data.SelectField == "CC1FA")
			{
				if (data.color != null)
				{
					data.CC1FA = data.color;
					cmd.Parameters.AddWithValue("@CPA", "");
					cmd.Parameters.AddWithValue("@CNPA", "");
					cmd.Parameters.AddWithValue("@CC1FA", data.CC1FA);
					cmd.Parameters.AddWithValue("@IM", "");
					cmd.Parameters.AddWithValue("@C", "");
				}
				else if (data.progress != null)
				{
					data.CC1FA = data.progress;
					cmd.Parameters.AddWithValue("@CPA", "");
					cmd.Parameters.AddWithValue("@CNPA", "");
					cmd.Parameters.AddWithValue("@CC1FA", data.CC1FA);
					cmd.Parameters.AddWithValue("@IM", "");
					cmd.Parameters.AddWithValue("@C", "");
				}
				else
				{
					cmd.Parameters.AddWithValue("@CPA", "");
					cmd.Parameters.AddWithValue("@CNPA", "");
					cmd.Parameters.AddWithValue("@CC1FA", "");
					cmd.Parameters.AddWithValue("@IM", "");
					cmd.Parameters.AddWithValue("@C", "");
				}
			}
			else if (data.SelectField == "IM")
			{
				if (data.color != null)
				{
					data.IM = data.color;
					cmd.Parameters.AddWithValue("@CPA", "");
					cmd.Parameters.AddWithValue("@CNPA", "");
					cmd.Parameters.AddWithValue("@CC1FA", "");
					cmd.Parameters.AddWithValue("@IM", data.IM);
					cmd.Parameters.AddWithValue("@C", "");
				}
				else if (data.progress != null)
				{
					data.IM = data.progress;
					cmd.Parameters.AddWithValue("@CPA", "");
					cmd.Parameters.AddWithValue("@CNPA", "");
					cmd.Parameters.AddWithValue("@CC1FA", "");
					cmd.Parameters.AddWithValue("@IM", data.IM);
					cmd.Parameters.AddWithValue("@C", "");
				}
				else
				{
					cmd.Parameters.AddWithValue("@CPA", "");
					cmd.Parameters.AddWithValue("@CNPA", "");
					cmd.Parameters.AddWithValue("@CC1FA", "");
					cmd.Parameters.AddWithValue("@IM", "");
					cmd.Parameters.AddWithValue("@C", "");
				}
			}
			else if (data.SelectField == "C")
			{
				if (data.color != null)
				{
					data.C = data.color;
					cmd.Parameters.AddWithValue("@CPA", "");
					cmd.Parameters.AddWithValue("@CNPA", "");
					cmd.Parameters.AddWithValue("@CC1FA", "");
					cmd.Parameters.AddWithValue("@IM", "");
					cmd.Parameters.AddWithValue("@C", data.C);
				}
				else if (data.progress != null)
				{
					data.C = data.progress;

					cmd.Parameters.AddWithValue("@CPA", "");
					cmd.Parameters.AddWithValue("@CNPA", "");
					cmd.Parameters.AddWithValue("@CC1FA", "");
					cmd.Parameters.AddWithValue("@IM", "");
					cmd.Parameters.AddWithValue("@C", data.C);
				}
				else
				{

					cmd.Parameters.AddWithValue("@CPA", "");
					cmd.Parameters.AddWithValue("@CNPA", "");
					cmd.Parameters.AddWithValue("@CC1FA", "");
					cmd.Parameters.AddWithValue("@IM", "");
					cmd.Parameters.AddWithValue("@C", "");
				}
			}
			else
			{

				cmd.Parameters.AddWithValue("@CPA", "NA");
				cmd.Parameters.AddWithValue("@CNPA", "NA");
				cmd.Parameters.AddWithValue("@CC1FA", "NA");
				cmd.Parameters.AddWithValue("@IM", "NA");
				cmd.Parameters.AddWithValue("@C", "NA");
			}

			cmd.Parameters.AddWithValue("@Areas", data.Areas);
			cmd.Parameters.AddWithValue("@Month", data.Month);
			cmd.Parameters.AddWithValue("@sheet_name", data.Areas + " / " + data.owner);
			cmd.Parameters.AddWithValue("@Owner", data.owner);
			con.Open();
			int i = cmd.ExecuteNonQuery();
			cmd.Dispose();

			con.Close();
			if (i > 0)
			{
				return true;
			}
			else
			{
				return false;
			}

		}
		public bool DeleteData(int id)
		{
			SqlConnection con = new SqlConnection(cs);
			SqlCommand cmd = new SqlCommand("spDeleteData", con);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@id", id);
			con.Open();
			int i = cmd.ExecuteNonQuery();
			cmd.Dispose();

			con.Close();
			if (i > 0)
			{
				return true;
			}
			else
			{
				return false;
			}

		}
	}
}