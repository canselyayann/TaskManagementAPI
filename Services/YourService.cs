
using TaskManagementAPI.Models;  // LoginModel s�n�f� burada yer al�r
using TaskManagementAPI.Data;    // ApplicationDbContext burada yer al�r


namespace TaskManagementAPI.Services  // Kendi namespace'inizi kullan�n
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
				.Where(l => l.UserId == userId)  // Kullan�c�ya ait login verilerini al
				.FirstOrDefault();  // �lk e�le�eni al, yoksa null d�ner

			return login;
		}
	}
}
