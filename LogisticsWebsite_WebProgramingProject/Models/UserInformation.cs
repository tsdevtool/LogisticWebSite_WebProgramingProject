namespace LogisticsWebsite_WebProgramingProject.Models
{
	public class UserInformation
	{
		public string Id { get; set; }	
		public string Name { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string PhoneNumber { get; set; } = string.Empty;
		public string Country { get; set; }
	}
}
