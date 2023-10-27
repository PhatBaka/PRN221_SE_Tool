using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SETool_Business.Services.Extensions
{
	public class CreateObjectException : Exception
	{
		public CreateObjectException(string message) : base(message) 
		{ 
		
		}
	}
}
