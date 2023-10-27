using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SETool_Business.Services.Extensions
{
	public class ValidationService : IValidationService
	{
		public async Task<string> FormatDateOutput(string dateString)
		{
			try
			{
				return DateTime.Parse(dateString).ToString("dd/MM/yyyy HH:mm:ss");
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
	}
}
