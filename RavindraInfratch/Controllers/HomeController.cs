using Microsoft.AspNetCore.Mvc;
using RavindraInfratch.Models;
using System.Diagnostics;
using RavindraInfratch.DBData;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace RavindraInfratch.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		RavindraInfraContext context= new RavindraInfraContext();
		private const string ID = "";
		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			string key = "AccountID";
			var cookieValue = Request.Cookies[key];
			if (cookieValue != null)
			{
				return RedirectToAction("Dashboard", "User");
			}
			 
			return View();
		}
		public const string SessionKeyId = "Id";
		[HttpPost]
		public IActionResult Index(Login Lg)
		{
			

				if (Lg.Username == "admin")
				{
					var status = context.AdminLogins.Where(m => m.Username == Lg.Username && m.Password == Lg.Password).FirstOrDefault();
					if (status == null)
					{
						ViewBag.Status = 0;
					}
					else
					{

						var data = context.AdminLogins.ToList();

						Lg.Id = 0;

						//HttpContext.Session.SetInt32("AccountID", Lg.Id);
						string key = "AccountID";
						string value = Lg.Id.ToString();
						CookieOptions options = new CookieOptions
						{
							Expires = DateTime.Now.AddDays(5)
						};
						Response.Cookies.Append(key, value, options);
						return RedirectToAction("Dashboard", "Admin");
					}
				}
				else
				{
					var status = context.LogTblAccounts.Where(m => m.UserName == Lg.Username && m.Password == Lg.Password).FirstOrDefault();
					if (status == null)
					{
						ViewBag.Status = 0;
					}
					else
					{

						var LDetails = new Login
						{
							Id = status.AccountId,
							Username = status.AccountName
						};

						//HttpContext.Session.SetInt32("AccountID", LDetails.Id);
						//HttpContent.Session.SetString("Username",LDetails.Username);
						string key = "AccountID";
						string value = LDetails.Id.ToString();
						CookieOptions options = new CookieOptions
						{
							Expires = DateTime.Now.AddDays(5)
						};
						Response.Cookies.Append(key, value, options);
						return RedirectToAction("Dashboard", "User");
					}
				}
			
			return View(Lg);
		}
		public IActionResult Logout()
		{
			//HttpContext.Session.Remove("AccountID");
			string key = "AccountID";
			string value =string.Empty;
			CookieOptions options = new CookieOptions
			{
				Expires = DateTime.Now.AddDays(-1)
			};
			Response.Cookies.Append(key, value, options);

			return RedirectToAction("Index");
		}
		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
