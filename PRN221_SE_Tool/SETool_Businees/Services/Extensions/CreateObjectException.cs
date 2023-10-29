using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SETool_Business.Services.Extensions
{
	public static class CreateObjectException 
	{
		public static string EmailExisted = "This email is existed";
		public static string PhoneExisted = "This phone is existed";
	}
}
