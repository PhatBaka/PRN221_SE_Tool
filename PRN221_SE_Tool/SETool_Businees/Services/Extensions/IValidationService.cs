using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SETool_Business.Services.Extensions
{
	public interface IValidationService
	{
		public Task<string> FormatDateOutput(string dateString);
	}
}
