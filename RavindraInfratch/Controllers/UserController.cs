using Microsoft.AspNetCore.Mvc;
using RavindraInfratch.DBData;
using RavindraInfratch.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Mono.TextTemplating;
using Newtonsoft.Json;
using Microsoft.AspNetCore.JsonPatch;
using System.Text;
using Azure.Core;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RavindraInfratch.Controllers
{
	public class UserController : Controller
	{
		private string url = "http://api.ravindrainfratech.com/get/UserAccount/";
		//private string url = "https://localhost:7241/get/UserAccount/";

		private HttpClient client = new HttpClient();
		 
		RavindraInfraContext _context = new RavindraInfraContext();
		IWebHostEnvironment webHostEnvironment;
		public UserController(IWebHostEnvironment HC)
		{
			webHostEnvironment = HC;
		
		}
		public IActionResult Dashboard()
		{
			string key = "AccountID";
			var cookieValue = Request.Cookies[key];
			if (cookieValue != null)
			
			{
				 UserDashboard userDashboard = new UserDashboard();
				//var s = HttpContext.Session.GetInt32("AccountID").ToString();
				//var RegData = _context.LogTblAccounts.FromSqlRaw("EXECUTE GetBusiness ").AsEnumerable().ToList();
				// List<UserDashboard> userDashboard = new List<UserDashboard>();
				//if (RegData.Count > 0)
				//{
				//	foreach (var item in RegData)
				//	{
				//		var Rlist = new UserDashboard()
				//		{

				//			AccountName = item.AccountName,
				//			Business = item.Business,
				//			Photo = item.Photo,



				//		};
				//		userDashboard.Add(Rlist);

				//	}

				//}
				//return View(userDashboard);
				var RegData = _context.RptAccounts.FirstOrDefault(x => x.AccountId == Convert.ToInt32(cookieValue));
				userDashboard = new UserDashboard();
				if (RegData != null)
				{

					userDashboard = new UserDashboard()
					{
						AccountName = RegData.AccountName,
						tTYPE = RegData.TType
						 
					};
					ViewData["AccountName"] = RegData.AccountName;

					ViewBag.tTYPE = RegData.TType;

				}
				var Data = _context.LogTblAccounts.FromSqlRaw("EXECUTE GetBusiness ").AsEnumerable().ToList();
				//projectModel = new ProjectModel();
				userDashboard.BusinessMonth = Data.Select(s => new Models.UserDashboard { AccountName = s.AccountName, Business = s.Business,Photo=s.Photo }).ToList();

				
				return View(userDashboard);

			}
			else
			{
				return RedirectToAction("Index", "Home");
			}
		}
		public IActionResult Profile(int id)
		{
			string key = "AccountID";
			var cookieValue = Request.Cookies[key];
			if (cookieValue != null)
			{
				 
				var RegData = (dynamic)null;
				//var GetData = _context.LogTblAccounts.FirstOrDefault(m => m.AccountId == Convert.ToInt32(HttpContext.Session.GetInt32("AccountID").ToString()));
				if (id == 0)
				{
					   RegData = _context.RptAccounts.FirstOrDefault(m => m.AccountId == Convert.ToInt32(cookieValue));
					ViewData["ID"] = "0";
				}
				else
				{
					  RegData = _context.RptAccounts.FirstOrDefault(m => m.AccountId == id);
					ViewData["ID"] = "1";
				}

				if (RegData != null)
				{
					//RegistrationList registration = new RegistrationList();
					RegistrationModel registrationModel = new RegistrationModel();

					registrationModel = new RegistrationModel()

					{
						Reg = new RegistrationList()
						{
							TType = RegData.TType,
							AccountId = RegData.AccountId,
							AccountName = RegData.AccountName,
							Gender= RegData.Gender,
							Address = RegData.Address,
							Address2 = RegData.Address2,
							City = RegData.City,
							District= RegData.District,
							//State = RegData.StateID.ToString(),
							StateName = RegData.State,
							Mobile = RegData.Mobile,
							WhatsApp = RegData.WhatsApp,
							Email = RegData.Email,
							AadharFront = RegData.AadharFront,
							AadharBack = RegData.AadharBack,
							Panphoto = RegData.Panphoto,
							Photo = RegData.Photo,
							SponsorName = RegData.Sponsorname,
							//SponsorID = RegData.SponsorID.ToString(),


						}
					};
					@ViewData["Ttype"] = registrationModel.Reg.AccountName;
					ViewData["AType"] = registrationModel.Reg.TType;



					return View(registrationModel);

				}




				else
				{
					return NotFound();
				}
			}
			else
			{
				return RedirectToAction("Index", "Home");
			}
		}
		[HttpPost]
		public async Task<IActionResult> Profile(RegistrationModel registration)
		{
			var RegData = await _context.LogTblAccounts.FindAsync((int)registration.Reg.AccountId);
			if (RegData != null)
			{
				RegData.WhatsApp = registration.Reg.WhatsApp;
				RegData.Email = registration.Reg.Email;
				RegData.Address = registration.Reg.Address;
			}
			_context.SaveChanges();
			TempData["JavaScriptFunction"] = string.Format("Update();");
			//string key = "AccountID";
			//var cookieValue = Request.Cookies[key];


			//if (cookieValue != null)
			//{

			//	string data = JsonConvert.SerializeObject(registration);



			//	 StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

			//	HttpResponseMessage responseMessage = client.PutAsync(url + Convert.ToInt32(cookieValue), content).Result;

			//	if (responseMessage.IsSuccessStatusCode)
			//	{
			//		TempData["JavaScriptFunction"] = string.Format("Update();");
			//	}



			//}

			return View(registration);
		}
		public IActionResult DownLine()
		{
			return View();
		}
		public IActionResult DownlineTeam()
		{

		List<RegistrationList> registrationList = new List<RegistrationList>();
			string key = "AccountID";
			var cookieValue = Request.Cookies[key];
			if (cookieValue != null)
			{
				var GetData = _context.LogTblAccounts.Where(m => m.Sponsorid == Convert.ToInt32(cookieValue)).ToList();

				if (GetData != null)
				{
					foreach (var item in GetData)
					{
						var reg = new RegistrationList()
						{
							AccountId = item.AccountId,
							AccountName = item.AccountName,
							TType = item.TType,
							Photo = item.Photo
						};
						registrationList.Add(reg);
					}
					return View(registrationList);
				}
				else
				{
					return NotFound();
				}
				
			}
			else
			{
				return RedirectToAction("Index", "Home");
			}
		}
		[HttpGet]
		public async Task <IActionResult> RegistrationList(  int id)
		{
			string key = "AccountID";
			var cookieValue = Request.Cookies[key];
			if (cookieValue != null)
			{
				if (id != 0)
				{

					var RegData = await _context.LogTblAccounts.FindAsync((short)id);

					//	RegistrationList Rlist = new RegistrationList();


					//List<RegistrationList> RegList = new List<RegistrationList>();
					//if (RegData != null)
					//{
					//	_context.LogTblAccounts.Remove(RegData);
					//	await _context.SaveChangesAsync();
					//	TempData["JavaScriptFunction"] = string.Format("Delete();");

					//}
					//return RedirectToAction("RegistrationList/../", new { AType = tType });
					return RedirectToAction("RegistrationList", "User", new { id = 0 });
				}
				else
				{
					var RegData = _context.RptAccounts.Where(m => m.Sponsorid == Convert.ToInt32(cookieValue)).ToList();
					//RegistrationList Rlist = new RegistrationList();
					List<RegistrationList> RegList = new List<RegistrationList>();
					if (RegData.Count > 0)
					{
						foreach (var item in RegData)
						{
							var Rlist = new RegistrationList()
							{
								AccountId = item.AccountId,
								AccountName = item.AccountName,
								City = item.City,
								State = item.State,
								Mobile = item.Mobile,
								WhatsApp = item.WhatsApp,
								Email = item.Email,
								SponsorName = item.Sponsorname,
								DateString = item.CreatedDate,
								TType = item.TType,
								Active = item.Active

							};
							RegList.Add(Rlist);

						}

					}


					return View(RegList);
				}
			}
			else
			{
				return RedirectToAction("Index", "Home");
			}
		}	


		public async Task<IActionResult> Registration (int ID)
		{
			string key = "AccountID";
			var cookieValue = Request.Cookies[key];
			if (cookieValue != null)
			{

				ViewData["ID"] = ID;
				if (ID == 0)
				{
					RegistrationModel registrationModel = new RegistrationModel();
					//registrationModel.Reg.TType= RouteData.Values["id"].ToString();
					registrationModel = new RegistrationModel()

					{
						Reg = new RegistrationList()
						{
							//TType = RouteData.Values["id"].ToString()
						}
					};


					var StateData = _context.States.OrderBy(m => m.State1).ToList();
					registrationModel.StateListModel = new List<SelectListItem>();
					foreach (var i in StateData)
					{
						registrationModel.StateListModel.Add(new SelectListItem()
						{
							Value = i.Id.ToString(),
							Text = i.State1.ToString()
						});
					}
					return View(registrationModel);
				}
				else
				{
					var RegData = _context.LogTblAccounts.FirstOrDefault(m => m.AccountId == ID);

					if (RegData != null)
					{
						//RegistrationList registration = new RegistrationList();
						RegistrationModel registrationModel = new RegistrationModel();

						registrationModel = new RegistrationModel()

						{
							Reg = new RegistrationList()
							{
								TType = RegData.TType,
								AccountId = RegData.AccountId,
								AccountName = RegData.AccountName,
								Gender = RegData.Gender,
								Address = RegData.Address,
								Address2 = RegData.Address2,
								City = RegData.City,
								District = RegData.District,
								State = RegData.State.ToString(),
								Mobile = RegData.Mobile,
								WhatsApp = RegData.WhatsApp,
								Email = RegData.Email,
								AadharFront = RegData.AadharFront,
								AadharBack = RegData.AadharBack,
								Panphoto = RegData.Panphoto,
								Photo = RegData.Photo,
								Active = RegData.Active

							}
						};
						@ViewData["Ttype"] = registrationModel.Reg.AccountName;
						//ViewData["AType"] = registrationModel.Reg.TType;

						var StateData = _context.States.OrderBy(m => m.State1).ToList();
						registrationModel.StateListModel = new List<SelectListItem>();
						foreach (var i in StateData)
						{
							registrationModel.StateListModel.Add(new SelectListItem()
							{
								Value = i.Id.ToString(),
								Text = i.State1.ToString()
							});
						}


						return View(registrationModel);

					}




					else
					{
						return NotFound();
					}
				}
			}
			else
			{
				return RedirectToAction("Index", "Home");
			}
		}
		[HttpPost]
		public async Task<IActionResult> Registration(RegistrationModel registration)
		{

			//RegistrationModel registration = new RegistrationModel();
			//ViewData["ID"] = registration.Reg.AccountId;


			var t = registration.Reg.TType;

			//var b= registration.Reg.AccountName;
			string key = "AccountID";
			var cookieValue = Request.Cookies[key];
			if (cookieValue != null)

			{
				var RegUpdate = await _context.LogTblAccounts.FindAsync(((short)registration.Reg.AccountId));
				if (RegUpdate != null)
				{

					RegUpdate.AccountName = registration.Reg.AccountName;
					RegUpdate.Gender = registration.Reg.Gender;
					RegUpdate.TType = registration.Reg.TType;
					RegUpdate.Address = registration.Reg.Address;
					RegUpdate.Address2 = registration.Reg.Address2;
					RegUpdate.City = registration.Reg.City;
					RegUpdate.District = registration.Reg.District;
					RegUpdate.State = Convert.ToInt32(registration.Reg.State);
					RegUpdate.Mobile = registration.Reg.Mobile;
					RegUpdate.WhatsApp = registration.Reg.WhatsApp;
					RegUpdate.Email = registration.Reg.Email;
					RegUpdate.EditedBy = 0;
					RegUpdate.EditedDate = DateTime.Now;
					//RegUpdate.Active = "Y";

					//RegUpdate.Sponsorid = Convert.ToInt32(registration.Reg.SponsorID);

					if (registration.Reg.imgPhoto != null)
					{
						string folder = Path.Combine(webHostEnvironment.WebRootPath, "Upload");
						string filename = Guid.NewGuid() + "_" + registration.Reg.imgPhoto.FileName;
						string FilePath = Path.Combine(folder, filename);
						registration.Reg.imgPhoto.CopyTo(new FileStream(FilePath, FileMode.Create));
						RegUpdate.Photo = filename;

					}

					if (registration.Reg.imgAadharFront != null)
					{
						string folder = Path.Combine(webHostEnvironment.WebRootPath, "Upload");
						string filename = Guid.NewGuid() + "_" + registration.Reg.imgAadharFront.FileName;
						string FilePath = Path.Combine(folder, filename);
						registration.Reg.imgAadharFront.CopyTo(new FileStream(FilePath, FileMode.Create));
						RegUpdate.AadharFront = filename;
					}

					if (registration.Reg.imgAadharBack != null)
					{
						string folder = Path.Combine(webHostEnvironment.WebRootPath, "Upload");
						string filename = Guid.NewGuid() + "_" + registration.Reg.imgAadharBack.FileName;
						string Filepath = Path.Combine(folder, filename);
						registration.Reg.imgAadharBack.CopyTo(new FileStream(Filepath, FileMode.Create));
						RegUpdate.AadharBack = filename;
					}

					if (registration.Reg.imgPan != null)
					{
						string folder = Path.Combine(webHostEnvironment.WebRootPath, "Upload");
						string filename = Guid.NewGuid() + "_" + registration.Reg.imgPan.FileName;
						string FilePath = Path.Combine(folder, filename);
						registration.Reg.imgPan.CopyTo(new FileStream(FilePath, FileMode.Create));
						RegUpdate.Panphoto = filename;
					}

					_context.SaveChanges();
					TempData["JavaScriptFunction"] = string.Format("Update();");



					return RedirectToAction("Registation", new { ID = registration.Reg.AccountId });
				}

				else
				{
					//var t = Context.Request.RouteValues["id"];
					var isPhoneExist = _context.LogTblAccounts.Any(x => x.Mobile == registration.Reg.Mobile);
					if (isPhoneExist)
					{
						ModelState.AddModelError("Reg.Mobile", "This mobile no. is already used");
						ViewData["ID"] = "0";
						ModelState.AddModelError("Reg.Mobile", "This mobile no. is already used");
						ViewData["ID"] = "0";

						var StateData = _context.States.OrderBy(m => m.State1).ToList();
						registration.StateListModel = new List<SelectListItem>();
						foreach (var i in StateData)
						{
							registration.StateListModel.Add(new SelectListItem()
							{
								Value = i.Id.ToString(),
								Text = i.State1.ToString()
							});
						}

						//return RedirectToAction("Registation", "Admin", new { id = registration.Reg.TType });
						//return View(registration, new { id = registration.Reg.TType });
						return View(registration);

					}
					else
					{
						var AddData = new LogTblAccount()
						{

							AccountName = registration.Reg.AccountName,
							Gender = registration.Reg.Gender,
							TType = registration.Reg.TType,
							Address = registration.Reg.Address,
							Address2 = registration.Reg.Address2,
							City = registration.Reg.City,
							District = registration.Reg.District,
							State = Convert.ToInt32(registration.Reg.State),
							Mobile = registration.Reg.Mobile,
							WhatsApp = registration.Reg.WhatsApp,
							Email = registration.Reg.Email,
							CreatedBy = 0,
							CreatedDate = DateTime.Now,
							Active = "N",
							Sponsorid = Convert.ToInt32(cookieValue),
							UserName = registration.Reg.Mobile,
							Password = registration.Reg.Mobile
						};
						await _context.LogTblAccounts.AddAsync(AddData);
						await _context.SaveChangesAsync();
						TempData["JavaScriptFunction"] = string.Format("Success();");
						int lasttId = _context.LogTblAccounts.Max(m => m.AccountId);
						ViewData["ID"] = lasttId;
						return RedirectToAction("Registration", new { ID = lasttId });

					}
				}
			}
			else
			{
				return RedirectToAction("Index", "Home");
			}


		}
		public IActionResult DirectPurchase()
		{
			string key = "AccountID";
			var cookieValue = Request.Cookies[key];
			if (cookieValue != null)
			{
				var GetData = (from AC in _context.LogTblAccounts
							   join PUR in _context.Purchases on AC.AccountId equals PUR.Accountid
							   join SP in _context.LogTblAccounts on AC.Sponsorid equals SP.AccountId
							   where AC.Sponsorid == Convert.ToInt32(cookieValue)
							   select new PurchaseModel
							   {
								   Id = PUR.Id,
								   SponsorName = SP.AccountName,
								   AccountName = AC.AccountName,
								   Address2 = AC.Address2,
								   Mobile = AC.Mobile,
								   WhatsApp = AC.WhatsApp,
								   Aarajino = PUR.Aarajino,
								   Area = PUR.Area,
								   Finalamount = PUR.Finalamount,
								   Advanceamoutn = PUR.Advanceamoutn,
								   Dueamount = PUR.Dueamount,
								   Process = PUR.Process,
								   Createddate = PUR.Createddate

							   }
						 ).ToList();

				return View(GetData);
			}
			else
			{
				return RedirectToAction("Index", "Home");
			}
		}
		public IActionResult PurchaseList()
		{
			string key = "AccountID";
			var cookieValue = Request.Cookies[key];
			if (cookieValue != null)
			{
				var GetData = (from AC in _context.LogTblAccounts
							   join PUR in _context.Purchases on AC.AccountId equals PUR.Accountid
							   join SP in _context.LogTblAccounts on PUR.Sponsorid equals SP.AccountId
							   join SNR in _context.LogTblAccounts on SP.Sponsorid equals SNR.AccountId
							   where SNR.AccountId == Convert.ToInt32(cookieValue)
							   select new PurchaseModel
							   {
								   Id = PUR.Id,
								   SponsorName = SP.AccountName,
								   AccountName = AC.AccountName,
								   Address2 = AC.Address2,
								   Mobile = AC.Mobile,
								   WhatsApp = AC.WhatsApp,
								   Aarajino = PUR.Aarajino,
								   Area = PUR.Area,
								   Finalamount = PUR.Finalamount,
								   Advanceamoutn = PUR.Advanceamoutn,
								   Dueamount = PUR.Dueamount,
								   Process = PUR.Process,
								   Createddate = PUR.Createddate

							   }
						 ).ToList();

				return View(GetData);
			}
			else
			{
				return RedirectToAction("Index", "Home");
			}
		}

		public IActionResult DirectSale()
		{
			string key = "AccountID";
			var cookieValue = Request.Cookies[key];
			if (cookieValue != null)
			{
				List<SaleModel> saleModel = new List<SaleModel>();
				var GetData = _context.Saledirects.Where(x => x.Accountid == Convert.ToInt32(cookieValue)).ToList();
				if (GetData != null)
				{
					foreach (var item in GetData)
					{
						var sale = new SaleModel()
						{
							receiptno = item.Id,
							Saletype = item.Saletype,
							SponsorName = item.Sponsorname,
							CustomerName = item.Accountname,
							CAddress = item.Address,
							CMobile = item.Mobile,
							CWhataApp = item.Whatsapp,
							Propertydetails = item.Propertydetails,
							ProjectName = item.ProjectName,
							Propertyname = item.Ttype,
							Blockname = item.Block,
							Plotno = item.Plotno,
							Aarajino = item.Aarajino,
							PlotSize = item.Plotsize,
							Finalamount = item.Finalamount,
							Createddate = item.Createddate
						};
						saleModel.Add(sale);
					}
				}

				return View(saleModel);
			}
			else
			{
				return RedirectToAction("Index", "Home");
			}
		}
		public IActionResult SaleList()
		{
			string key = "AccountID";
			var cookieValue = Request.Cookies[key];
			if (cookieValue != null)
			{
				List<SaleModel> saleModel = new List<SaleModel>();
				var GetData = _context.Saleteams.Where(x => x.Snrid == Convert.ToInt32(cookieValue)).ToList();
				if (GetData != null)
				{
					foreach (var item in GetData)
					{
						var sale = new SaleModel()
						{
							receiptno = item.Id,
							Saletype = item.Saletype,
							SponsorName = item.Sponsorname,
							CustomerName = item.Accountname,
							CAddress = item.Address,
							CMobile = item.Mobile,
							CWhataApp = item.Whatsapp,
							Propertydetails = item.Propertydetails,
							ProjectName = item.ProjectName,
							Propertyname = item.Ttype,
							Blockname = item.Block,
							Plotno = item.Plotno,
							Aarajino = item.Aarajino,
							PlotSize = item.Plotsize,
							Finalamount = item.Finalamount,
							Createddate = item.Createddate
						};
						saleModel.Add(sale);
					}
				}

				return View(saleModel);
			}
			else
			{
				return RedirectToAction("Index", "Home");
			}
		}
		public IActionResult Payout()
		{
			string key = "AccountID";
			var cookieValue = Request.Cookies[key];
			if (cookieValue != null)

			{
				var GetData = (from AC in _context.LogTblAccounts.Where(x => x.AccountId == Convert.ToInt32(cookieValue))

							   group AC by AC.AccountId into g


							   select new Commission()
							   {
								   Id = g.Key,

								   AccountName = g.Select(c => c.AccountName).FirstOrDefault(),


								   WhatsApp = g.Select(c => c.WhatsApp).FirstOrDefault(),
								   Mobile = g.Select(c => c.Mobile).FirstOrDefault(),

								   //PurchaseCommission = PUR.Sum(s=>s.PUR.Finalamount),
								   PurchaseCommission = _context.Purchases.Where(a => a.Sponsorid == g.Key).Select(p => p.Finalamount).Sum() * 2 / 100,
								   // var  pCommission = _context.Purchases.Where(a => a.Sponsorid == g.Key).Select(p => p.Finalamount).Sum() * 2 / 100,
								   SaleCommission = _context.Sales.Where(a => a.Sponsorid == g.Key).Select(p => p.Sfinalcommission).Sum(),
								   PaidCommission = _context.Paidcommissions.Where(a => a.Sponsorid == g.Key).Select(p => p.Amount).Sum(),
								   //dc.Deliveries.Where(n => n.TripDate == d).Sum(n => n.Rate)
								   TobePaidCommission = ((_context.Purchases.Where(a => a.Sponsorid == g.Key).Select(p => p.Finalamount).Sum() * 2 / 100) + (_context.Sales.Where(a => a.Sponsorid == g.Key).Select(p => p.Sfinalcommission).Sum()) - _context.Paidcommissions.Where(a => a.Sponsorid == g.Key).Select(p => p.Amount).Sum())



							   }
			 ).FirstOrDefault();

				return View(GetData);
			}
			else
			{
				return RedirectToAction("Index", "Home");
			}
		}
		[Produces("application/json")]
		[Consumes("application/json")]
		public IActionResult ChangePassword()
		{
			string key = "AccountID";
			var cookieValue = Request.Cookies[key];
			var data=_context.LogTblAccounts.FirstOrDefault(x=>x.AccountId== Convert.ToInt32(cookieValue));
			PasswordChange change = new PasswordChange
			{ GetOldPassword = data.Password };
			return View(change);
		}
		
		
		[HttpPost]
		public async Task<IActionResult> ChangePassword(PasswordChange change)
	 
		{
			string key = "AccountID";
			var cookieValue = Request.Cookies[key];
			change.AccountId = Convert.ToInt32(cookieValue);
			//change = new PasswordChange()
			//{
			//	id= Convert.ToInt32(cookieValue),
			//	Password=change.Password
			//};
			 
				var patchDoc = new JsonPatchDocument<PasswordChange>();
				patchDoc.Replace(e => e.Password, change.Password);
			 

				//var uri = Path.Combine("companies", "C9D4C053-49B6-410C-BC78-2D54A9991870", "employees", "80ABBCA8-664D-4B20-B5DE-024705497D4A");
				var serializedDoc = JsonConvert.SerializeObject(patchDoc);
				var requestContent = new StringContent(serializedDoc, Encoding.UTF8, "application/json-patch+json");

			//	var response =   client.PatchAsync(url+ Convert.ToInt32(cookieValue), requestContent);
			HttpResponseMessage responseMessage = client.PatchAsync(url + Convert.ToInt32(cookieValue), requestContent).Result;
			if (responseMessage.IsSuccessStatusCode)
			{
			 
				TempData["JavaScriptFunction"] = string.Format("Update();");
			}
			// response.EnsureSuccessStatusCode();

			return View();

		}

    }
	
}
