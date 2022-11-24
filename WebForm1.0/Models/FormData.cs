using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebForm1._0.Models
{
	public class FormData
	{
		public int id { get; set; }
		[Required]
		public string PlanType { get; set; }
		[Required]
		public string SelectField { get; set; }

		public string CPA { get; set; }

		public string CNPA { get; set; }

		public string CC1FA { get; set; }

		public string IM { get; set; }

		public string C { get; set; }
		public string color { get; set; }
		public string progress { get; set; }
		[Required]
		public string Areas { get; set; }
		[Required]
		public string Month { get; set; }
		
		public string sheetName { get; set; }
		[Required]
		public string owner { get; set; }
	}
}