using System;
namespace Core.Utilities.Security.JWT
{
	public class AccessToken : ITokenHelper
	{ 
		public string Token { get; set; }
		public string Expiration { get; set; }
	}
}

