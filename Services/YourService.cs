
using TaskManagementAPI.Models;  // LoginModel sýnýfý burada yer alýr
using TaskManagementAPI.Data;    // ApplicationDbContext burada yer alýr


namespace TaskManagementAPI.Services  // Kendi namespace'inizi kullanýn
{
	public class YourService
	{
		private readonly ApplicationDbContext _dbContext;

		public YourService(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public LoginModel GetLoginByUserId(int userId)
		{
			var login = _dbContext.LoginModels
				.Where(l => l.UserId == userId)  // Kullanýcýya ait login verilerini al
				.FirstOrDefault();  // Ýlk eþleþeni al, yoksa null döner

			return login;
		}
	}
}
