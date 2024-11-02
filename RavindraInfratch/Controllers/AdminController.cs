using Azure;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Evaluation;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Mono.TextTemplating;
using Newtonsoft.Json.Linq;
using RavindraInfratch.DBData;
using RavindraInfratch.Models;
using System;
using System.ComponentModel.Design;
using System.Linq;
using System.Net;
using System.Reflection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace RavindraInfratch.Controllers
{
	public class AdminController : Controller
	{
		IWebHostEnvironment webHostEnvironment;
		RavindraInfraContext _context= new RavindraInfraContext();
		public AdminController (IWebHostEnvironment HC)
		{
			webHostEnvironment = HC;
		}
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Dashboard() 
		{
			string key = "AccountID";
			var cookieValue = Request.Cookies[key];
			if (cookieValue != null)
			{
				return View();
			}
			else
			{
				return RedirectToAction("Index","Home");
			}
			
		}
		public IActionResult CompanyDetails()
		{
			string key = "AccountID";
			var cookieValue = Request.Cookies[key];
			if (cookieValue != null)
			{
				int id = 1;
				var CompanyDetails = _context.LogTblCompanies.FirstOrDefault(x => x.CompanyId == id);
				if (CompanyDetails != null)
				{
					var CompanyModel = new AdminCompanyDetails
					{
						CompanyName = CompanyDetails.CompanyName,
						CompanyPhone = CompanyDetails.CompanyPhone,
						CompanyEmailId = CompanyDetails.CompanyEmailId,
						CompanyAddress = CompanyDetails.CompanyAddress,
						CompanyCity = CompanyDetails.CompanyCity,
						CompanyGstinNo = CompanyDetails.CompanyGstinNo,



					};

					return View(CompanyModel);
				}
				else
				{
					return NotFound();
				}
			}
			else
			{ return RedirectToAction("Index", "Home"); }
			
		}
		[HttpPost]
		public IActionResult CompanyDetails ( AdminCompanyDetails adminCompanyDetails)
		{
			int id = 1;
			adminCompanyDetails.CompanyId = 1;
			var CompanyDetailsUpdate = _context.LogTblCompanies.Find(adminCompanyDetails.CompanyId);
			if (CompanyDetailsUpdate != null)
			{

				CompanyDetailsUpdate.CompanyName = adminCompanyDetails.CompanyName;
				CompanyDetailsUpdate.CompanyPhone=adminCompanyDetails.CompanyPhone;
				CompanyDetailsUpdate.CompanyEmailId = adminCompanyDetails.CompanyEmailId;
				CompanyDetailsUpdate.CompanyAddress= adminCompanyDetails.CompanyAddress;
				CompanyDetailsUpdate.CompanyCity = adminCompanyDetails.CompanyCity;
				CompanyDetailsUpdate.CompanyGstinNo = adminCompanyDetails.CompanyGstinNo;
				 _context.SaveChanges();
				TempData["JavaScriptFunction"] = string.Format("Update();");


				
				return View(adminCompanyDetails);
			}
			else
			{
				return NotFound();
			}
		}
		public IActionResult StateList()
		{
			string key = "AccountID";
			var cookieValue = Request.Cookies[key];
			if (cookieValue != null)
			{
				var states1 = _context.States.ToList();
				StateViewModel stateViewModel = new StateViewModel();
				//StateList state = new  StateList();
				stateViewModel.StateLists = states1.Select(s => new Models.StateList { Id = s.Id, State1 = s.State1, StateCode = s.StateCode }).ToList();
				return View(stateViewModel);
			}
			else
			{ return RedirectToAction("Index", "Home"); }



		}

		public IActionResult StateDel(int id)
		{

			var stateDelete = _context.States.Where(c => c.Id == id).FirstOrDefault();
			if (stateDelete != null)
			{
				_context.States.Remove(stateDelete);
				_context.SaveChanges();
				TempData["JavaScriptFunction"] = string.Format("Delete();");
			}

			return RedirectToAction("StateList");
		}
		[HttpPost]
		public async Task<IActionResult> StateList(StateList stateList)
		{
			//if (ModelState.IsValid)
			 

			{
				if (ModelState.IsValid)
				{
					var Add = new DBData.State()
					{
						Id = stateList.Id,
						StateCode = stateList.StateCode.ToUpper(),
						State1 = stateList.State1.ToUpper()
					};
					await _context.States.AddAsync(Add);
					await _context.SaveChangesAsync();
					TempData["JavaScriptFunction"] = string.Format("Success();");
				}
			}
			return RedirectToAction("StateList");

		}
		public IActionResult ExpenseType()
		{
			string key = "AccountID";
			var cookieValue = Request.Cookies[key];
			if (cookieValue != null)
			{
				var Data = _context.LogTblMasters.Where(m => m.TType == "Expense").ToList();
				ExpenseType expenseType = new ExpenseType();
				expenseType.ExpenseTypeList = Data.Select(s => new Models.ExpenseTypeList { Id = s.Id, FldName = s.FldName }).ToList();


				return View(expenseType);
			}
			else
			{ return RedirectToAction("Index", "Home"); }
		}
		public IActionResult ExpenseDel(int id)
		{
			var ExpenseDel= _context.LogTblMasters.Where(d=>d.Id ==id).FirstOrDefault ();
			if(ExpenseDel!=null)
			{
				_context.LogTblMasters.Remove(ExpenseDel);
				_context.SaveChanges();
				TempData["JavaScriptFunction"] = string.Format("Delete();");
			}
			return RedirectToAction("ExpenseType");
		}
		[HttpPost]
		public async Task<IActionResult> ExpenseType(ExpenseTypeList expenseTypeList )
		{
			 
			var Add= new LogTblMaster()
			{
				Id= expenseTypeList.Id,
				FldName= expenseTypeList.FldName.ToUpper(),
				TType="Expense",
				CreatedBy = 0,
				CreatedDate= DateTime.Now
			};
			await _context.LogTblMasters.AddAsync(Add);
			await _context.SaveChangesAsync();
			TempData["JavaScriptFunction"] = string.Format("Success();");
			return RedirectToAction("ExpenseType");


		}
		public static class AllState 
		{

		}
		public IActionResult Bank()
		{
			string key = "AccountID";
			var cookieValue = Request.Cookies[key];
			if (cookieValue != null)
			{
				var BankData = _context.Banks.ToList();
				BankModel bankList = new BankModel();
				bankList.BankList = BankData.Select(s => new Models.BankList { Id = s.Id, Display = s.Display, AccountName = s.AccountName, AccountNo = s.AccountNo, BankName = s.BankName, Branch = s.Branch }).ToList();

				return View(bankList);
			}
			else
			{ return RedirectToAction("Index", "Home"); }
		}
		[HttpGet]
		public async Task <IActionResult> RegistrationList (string AType, int id)
		{
			string key = "AccountID";
			var cookieValue = Request.Cookies[key];
			if (cookieValue != null)
			{
				if (id != 0)
				{

					var RegData = await _context.LogTblAccounts.FindAsync((short)id);

					//	RegistrationList Rlist = new RegistrationList();
					var tType = RegData.TType;

					//List<RegistrationList> RegList = new List<RegistrationList>();
					if (RegData != null)
					{
						_context.LogTblAccounts.Remove(RegData);
						await _context.SaveChangesAsync();
						TempData["JavaScriptFunction"] = string.Format("Delete();");

					}
					//return RedirectToAction("RegistrationList/../", new { AType = tType });
					return RedirectToAction("RegistrationList", "Admin", new { AType = tType, id = 0 });
				}
				else
				{
					var RegData = _context.RptAccounts.Where(m => m.TType == AType).ToList();
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
								SponsorName = item.Sponsorname,
								DateString = item.CreatedDate,
								TType = item.TType,
								Active = item.Active
							};
							RegList.Add(Rlist);

						}

					}
					ViewData["Ttype"] = AType;

					return View(RegList);
				}
			}
			else
			{ return RedirectToAction("Index", "Home"); }

		}
		[HttpPost]
		public async Task<IActionResult> RegistrationList(RegistrationList registration)
		{
			
				var RegData = await _context.LogTblAccounts.FindAsync(registration.AccountId);
				//RegistrationList Rlist = new RegistrationList();
				//List<RegistrationList> RegList = new List<RegistrationList>();
				if (RegData != null)
				{
					_context.LogTblAccounts.Remove(RegData);
					await _context.SaveChangesAsync();
					TempData["JavaScriptFunction"] = string.Format("Delete();");

				}
			
			return RedirectToAction("RegistrationList");
		}
		[HttpGet]
		public async Task<IActionResult> Registation(int ID)
		{
			//ViewData["AType"] = TType;
			ViewData["Ttype"] = RouteData.Values["id"]+" Registation";

			ViewData["ID"] = ID;
			if (ID == 0)
			{
				RegistrationModel registrationModel = new RegistrationModel();
				//registrationModel.Reg.TType= RouteData.Values["id"].ToString();
				registrationModel = new RegistrationModel()

				{
					Reg = new RegistrationList()
					{
						TType = RouteData.Values["id"].ToString()
					
					
			}
				};
				registrationModel.RegistrationList = new List<SelectListItem>();
				var Data = _context.LogTblAccounts.OrderBy(b => b.AccountName).ToList();
				foreach (var item in Data)
				{
					registrationModel.RegistrationList.Add(new SelectListItem()
					{
						Value = item.AccountId.ToString(),
						Text = item.AccountName.ToString()
					});
				}
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
							Gender=RegData.Gender,
							Address = RegData.Address,
							Address2 = RegData.Address2,
							City = RegData.City,
							District=RegData.District,
							State = RegData.State.ToString(),
							Mobile = RegData.Mobile,
							WhatsApp = RegData.WhatsApp,
							Email = RegData.Email,
							AadharFront = RegData.AadharFront,
							AadharBack = RegData.AadharBack,
							Panphoto = RegData.Panphoto,
							Photo = RegData.Photo,
							SponsorID = RegData.Sponsorid.ToString(),
							Active= RegData.Active
							
						}
					};
					@ViewData["Ttype"] = registrationModel.Reg.AccountName;
					//ViewData["AType"] = registrationModel.Reg.TType;
					registrationModel.RegistrationList = new List<SelectListItem>();
					var Data = _context.LogTblAccounts.OrderBy(b => b.AccountName).ToList();
					foreach (var item in Data)
					{
						registrationModel.RegistrationList.Add(new SelectListItem()
						{
							Value = item.AccountId.ToString(),
							Text = item.AccountName.ToString()
						});
					}
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
	 
		[HttpPost]
		public  async  Task<IActionResult> Registation(RegistrationModel registration)
		{

			//RegistrationModel registration = new RegistrationModel();
			//ViewData["ID"] = registration.Reg.AccountId;
			
			 
				var t = registration.Reg.TType;

				//var b= registration.Reg.AccountName;
				var RegUpdate = await _context.LogTblAccounts.FindAsync(((int)registration.Reg.AccountId));
				if (RegUpdate != null)
				{

					RegUpdate.AccountName = registration.Reg.AccountName;
				RegUpdate.Gender= registration.Reg.Gender;
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
					RegUpdate.Active = "Y";

					RegUpdate.Sponsorid = Convert.ToInt32(registration.Reg.SponsorID);

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
					registration.RegistrationList = new List<SelectListItem>();
					var Data = _context.LogTblAccounts.OrderBy(b => b.AccountName).ToList();
					foreach (var item in Data)
					{
						registration.RegistrationList.Add(new SelectListItem()
						{
							Value = item.AccountId.ToString(),
							Text = item.AccountName.ToString()
						});
					}
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
						Gender=registration.Reg.Gender,
						TType = registration.Reg.TType,
						Address = registration.Reg.Address,
						Address2 = registration.Reg.Address2,
						City = registration.Reg.City,
						District=registration.Reg.District,
						State = Convert.ToInt32(registration.Reg.State),
						Mobile = registration.Reg.Mobile,
						WhatsApp = registration.Reg.WhatsApp,
						Email = registration.Reg.Email,
						CreatedBy = 0,
						CreatedDate = DateTime.Now,
						Active = "Y",
						Sponsorid = Convert.ToInt32(registration.Reg.SponsorID),
						UserName = registration.Reg.Mobile,
						Password = registration.Reg.Mobile
					};
					await _context.LogTblAccounts.AddAsync(AddData);
					await _context.SaveChangesAsync();
					TempData["JavaScriptFunction"] = string.Format("Success();");
					int lasttId = _context.LogTblAccounts.Max(m => m.AccountId);
					ViewData["ID"] = lasttId;
					return RedirectToAction("Registation", new { ID = lasttId });

				}
			}


		}
		//public async Task<IActionResult> Registation(int ID)
		[HttpGet]
		public async Task<IActionResult> ProjectList( int id)
		{

			ProjectModel projectModel = new ProjectModel();

			if (id == 0)
			{
				var Data = _context.ProjectDbs.ToList();
				  projectModel = new ProjectModel();
				projectModel.AllProject = Data.Select(s => new Models.AllProject { AutoId = s.Id, ProjectName = s.ProjectName }).ToList();
				
			}
			else
			{
				
				var UpdateData = _context.ProjectDbs.FirstOrDefault(x => x.Id == id);
				  projectModel = new ProjectModel();
				if (UpdateData != null)
				{
					
					projectModel = new ProjectModel()
					{
						ProjectOne = new AllProject()
						{
							AutoId= UpdateData.Id,
							ProjectName = UpdateData.ProjectName
						}
					};
					
				}
				var Data = _context.ProjectDbs.ToList();
				//projectModel = new ProjectModel();
				projectModel.AllProject = Data.Select(s => new Models.AllProject { AutoId = s.Id, ProjectName = s.ProjectName }).ToList();


			}
			return View(projectModel);




		}
		[HttpPost]
		public async Task<IActionResult > ProjectList (ProjectModel projectList )
		{
			
			if (!ModelState.IsValid)
			{
				var ID = projectList.ProjectOne.AutoId;
				if (projectList.ProjectOne.AutoId!=0)
				{

					var Update = _context.ProjectDbs.Where(x => x.Id == ID).FirstOrDefault();
					if (Update != null)
					{
						Update.ProjectName = projectList.ProjectOne.ProjectName.ToUpper();
					}
					await _context.SaveChangesAsync();
					TempData["JavaScriptFunction"] = string.Format("Update();");
				}
				else
				{
					var Add = new ProjectDb()
					{
						Id = projectList.ProjectOne.AutoId,
						ProjectName = projectList.ProjectOne.ProjectName.ToUpper()
					};
					await _context.ProjectDbs.AddAsync(Add);
					await _context.SaveChangesAsync();
					TempData["JavaScriptFunction"] = string.Format("Success();");
				}
				
			}
			return RedirectToAction("ProjectList");


		}
		public IActionResult ProjectDel (int id)
		{
			var DataDel=_context.ProjectDbs.Where(x=>x.Id==id).FirstOrDefault();
			if(DataDel!=null)
			{
				_context.ProjectDbs.Remove(DataDel);
				_context.SaveChanges();
				TempData["JavaScriptFunction"] = string.Format("Delete();");
			}
			return RedirectToAction("ProjectList");
		}
		[HttpGet]
		public async Task<IActionResult> PropertyTypeList(int ID)
		{
			PropertyTypeModel propertyTypeModel = new PropertyTypeModel();
			if (ID == 0)
			{
				var GETDATA = _context.PropertyTypes.ToList();

				if (GETDATA != null)
				{

					propertyTypeModel.PropertyTypeList = GETDATA.Select(s => new Models.PropertyTypeModel { Id = s.Id, tType = s.TType }).ToList();
				}
				
			}
			else
			{
				var GetDataUpdate = _context.PropertyTypes.FirstOrDefault(x => x.Id == ID);
				propertyTypeModel = new PropertyTypeModel();
				if (GetDataUpdate != null)
				{
					propertyTypeModel = new PropertyTypeModel()
					{
						Id = GetDataUpdate.Id,
						tType = GetDataUpdate.TType
					};
					 
				}
				var GETDATA = _context.PropertyTypes.ToList();

				if (GETDATA != null)
				{

					propertyTypeModel.PropertyTypeList = GETDATA.Select(s => new Models.PropertyTypeModel { Id = s.Id, tType = s.TType }).ToList();
				}

			}
			return View(propertyTypeModel);
		}
		[HttpPost]
		public async Task<IActionResult> PropertyTypeList(PropertyTypeModel propertyTypeModel)
		{
			if (propertyTypeModel.Id == 0)
			{
				var Add = new PropertyType()
				{
					Id = propertyTypeModel.Id,
					TType = propertyTypeModel.tType.ToUpper()
				};
				_context.PropertyTypes.AddAsync(Add);
				_context.SaveChangesAsync();
				TempData["JavaScriptFunction"] = string.Format("Success();");
			}
			else
			{
				var Update = _context.PropertyTypes.Where(x => x.Id == propertyTypeModel.Id).FirstOrDefault();
				if (Update != null)
				{
					Update.TType = propertyTypeModel.tType.ToUpper();
				}
				_context.SaveChangesAsync();
				TempData["JavaScriptFunction"] = string.Format("Update();");
			}
				return RedirectToAction("PropertyTypeList");
			
		}
		public IActionResult PropertyTypeDel (int id)
		{
			var Data = _context.PropertyTypes.Where(x => x.Id == id).FirstOrDefault();
			if (Data != null)
			{
				_context.PropertyTypes.Remove(Data);
				_context.SaveChanges();
				TempData["JavaScriptFunction"] = string.Format("Delete();");
			}
			return RedirectToAction("PropertyTypeList");
		}
		public  IActionResult BlockList(int ID)
		{
			BlockModel blockModel = new BlockModel();
			if (ID == 0)
			{
				
				var GetData = _context.Blocks.ToList();
				if (GetData != null)
				{
					blockModel.BlockListModel = GetData.Select(s => new Models.BlockModel { Id = s.Id, BlockName = s.Block1 }).ToList();

				}
			}
			else
			{
				var GetDataUpdate = _context.Blocks.FirstOrDefault(x => x.Id == ID);
				blockModel = new BlockModel();
				if (GetDataUpdate != null)
				{
					blockModel = new BlockModel()
					{
						Id = GetDataUpdate.Id,
						BlockName = GetDataUpdate.Block1
					};
				}
				var GetData = _context.Blocks.ToList();
				if (GetData != null)
				{
					blockModel.BlockListModel = GetData.Select(s => new Models.BlockModel { Id = s.Id, BlockName = s.Block1 }).ToList();

				}
			}
			return View(blockModel);
		}
		[HttpPost]
		public async Task<IActionResult> BlockList(BlockModel blockModel)
		{
			if (blockModel.Id == 0)
			{
				var Add = new Block()
				{
					Id = blockModel.Id,
					Block1 = blockModel.BlockName.ToUpper()
				};
				_context.Blocks.Add(Add);
				_context.SaveChangesAsync();
				TempData["JavaScriptFunction"] = string.Format("Success();");
			}
			else
			{
				var update = _context.Blocks.Where(x => x.Id == blockModel.Id).FirstOrDefault();
				if (update != null)
				{
					update.Block1 = blockModel.BlockName.ToUpper();
				}
				await _context.SaveChangesAsync();
				TempData["JavaScriptFunction"] = string.Format("Update();");
			}
			return RedirectToAction("BlockList");

		}
		public IActionResult BlockListDel (int id)
		{
			if (id != 0)
			{
				var Del = _context.Blocks.Where(x => x.Id == id).FirstOrDefault();
				if (Del != null)
				{
					_context.Blocks.Remove(Del);
					_context.SaveChangesAsync();
					TempData["JavaScriptFunction"] = string.Format("Delete();");
				}
				
			}
			return RedirectToAction("BlockList");
		}
		public IActionResult PlotList(int ID)
		{
			PlotModel plotModel = new PlotModel();
			if (ID == 0)
			{
				//var GetData =(from PL in _context.Plots
				//			  join PRJ in _context.Projects on PL.Projectid equals PRJ.Id
				//			  join PTY in _context.PropertyTypes on PL.Propertyid equals PTY.Id
				//			  join BL in _context.Blocks on PL.Blockid equals BL.Id
				//			  {

				//}).ToList();
				//if (GetData != null)
				//{
				//	//blockModel.BlockListModel = GetData.Select(s => new Models.BlockModel { Id = s.Id, BlockName = s.Block1 }).ToList();
				//	plotModel.PlotModelList= g

				//}

				plotModel.PlotModelList =  (from PL in _context.Plots
							   join PRJ in _context.ProjectDbs on PL.Projectid equals PRJ.Id
							   join PTY in _context.PropertyTypes on PL.Propertyid equals PTY.Id
							   join BL in _context.Blocks on PL.Blockid equals BL.Id
							   select new PlotModel
							   {
								   Id = PL.Id,
								   ProjectName = PRJ.ProjectName,
								   Propertyname = PTY.TType,
								   Blockname = BL.Block1,
								   Plots = PL.Plots,
								   PlotSize=PL.PlotSize
								   
								   

							   }
			 ).ToList();
			 
				plotModel.ProjectList = new List<SelectListItem>();
				var Data = _context.ProjectDbs.OrderBy(x => x.ProjectName).ToList();

				foreach (var item in Data)
				{
					plotModel.ProjectList.Add(new SelectListItem()
					{
						Value = item.Id.ToString(),
						Text = item.ProjectName.ToString()
					}
						);
				}
				plotModel.PropertyList = new List<SelectListItem>();
				var DataProperty = _context.PropertyTypes.OrderBy(x => x.TType).ToList();

				foreach (var item in DataProperty)
				{
					plotModel.PropertyList.Add(new SelectListItem()
					{
						Value = item.Id.ToString(),
						Text = item.TType.ToString()
					}
						);
				}
				plotModel.BlockListSelect = new List<SelectListItem>();
				var DataBlock = _context.Blocks.OrderBy(x => x.Block1).ToList();

				foreach (var item in DataBlock)
				{
					plotModel.BlockListSelect.Add(new SelectListItem()
					{
						Value = item.Id.ToString(),
						Text = item.Block1.ToString()
					}
						);
				}
			}
			else
			{
				var GetDataUpdate = _context.Plots.FirstOrDefault(x => x.Id == ID);
				plotModel = new PlotModel();
				if (GetDataUpdate != null)
				{
					plotModel = new PlotModel()
					{
						Id = GetDataUpdate.Id,
						Projectid = GetDataUpdate.Projectid,
						Propertyid = GetDataUpdate.Propertyid,
						Blockid = GetDataUpdate.Blockid,
						Plots = GetDataUpdate.Plots,
						PlotSize=GetDataUpdate.PlotSize
					};
				}
				plotModel.PlotModelList = (from PL in _context.Plots
										   join PRJ in _context.ProjectDbs on PL.Projectid equals PRJ.Id
										   join PTY in _context.PropertyTypes on PL.Propertyid equals PTY.Id
										   join BL in _context.Blocks on PL.Blockid equals BL.Id
										   select new PlotModel
										   {
											   Id = PL.Id,
											   ProjectName = PRJ.ProjectName,
											   Propertyname = PTY.TType,
											   Blockname = BL.Block1,
											   Plots = PL.Plots,
											   PlotSize=PL.PlotSize


										   }
			 ).ToList();
				plotModel.ProjectList = new List<SelectListItem>();
				var Data = _context.ProjectDbs.OrderBy(x => x.ProjectName).ToList();

				foreach (var item in Data)
				{
					plotModel.ProjectList.Add(new SelectListItem()
					{
						Value = item.Id.ToString(),
						Text = item.ProjectName.ToString()
					}
						);
				}
				plotModel.PropertyList = new List<SelectListItem>();
				var DataProperty = _context.PropertyTypes.OrderBy(x => x.TType).ToList();

				foreach (var item in DataProperty)
				{
					plotModel.PropertyList.Add(new SelectListItem()
					{
						Value = item.Id.ToString(),
						Text = item.TType.ToString()
					}
						);
				}
				plotModel.BlockListSelect = new List<SelectListItem>();
				var DataBlock = _context.Blocks.OrderBy(x => x.Block1).ToList();

				foreach (var item in DataBlock)
				{
					plotModel.BlockListSelect.Add(new SelectListItem()
					{
						Value = item.Id.ToString(),
						Text = item.Block1.ToString()
					}
						);
				}
			}
			return View(plotModel);
		}
		[HttpPost]
		public async Task<IActionResult> PlotList(PlotModel plotModel)
		{
			if (plotModel.Id == 0)
			{
				var Add = new Plot()
				{
					Id = plotModel.Id,
					Projectid = plotModel.Projectid,
					Propertyid=plotModel.Propertyid,
					Blockid=plotModel.Blockid,
					Plots=plotModel.Plots,
					PlotSize=plotModel.PlotSize
				};
				_context.Plots.Add(Add);
				_context.SaveChangesAsync();
				TempData["JavaScriptFunction"] = string.Format("Success();");
			}
			else
			{
				var update = _context.Plots.Where(x => x.Id == plotModel.Id).FirstOrDefault();
				if (update != null)
				{
					update.Projectid = plotModel.Projectid;
					update.Propertyid = plotModel.Propertyid;
					update.Blockid = plotModel.Blockid;
					update.Plots = plotModel.Plots;
					update.PlotSize = plotModel.PlotSize;
				}
				await _context.SaveChangesAsync();
				TempData["JavaScriptFunction"] = string.Format("Update();");
			}
			return RedirectToAction("PlotList");

		}
		public IActionResult AddPurchase(int ID)
		{
		
			PurchaseModel purchaseModel = new PurchaseModel();
			

			if (ID == 0)
			{
				ViewData["ID"] = "0";
				purchaseModel.SponsorList = new List<SelectListItem>();
				var Data = _context.LogTblAccounts.OrderBy(x => x.AccountName).ToList();

				foreach (var item in Data)
				{
					purchaseModel.SponsorList.Add(new SelectListItem()
					{
						Value = item.AccountId.ToString(),
						Text = item.AccountName.ToString()
					}
						);
				}

				purchaseModel.SellerList = new List<SelectListItem>();
				var SellerData = _context.LogTblAccounts.Where(x => x.TType == "Seller" & x.Active == "Y").OrderBy(x => x.AccountName).ToList();
				foreach (var item in SellerData)
				{
					purchaseModel.SellerList.Add(new SelectListItem()
					{
						Value = item.AccountId.ToString(),
						Text = item.AccountName.ToString()
					});
				}
			}
			else
			{
				var GetData = _context.Purchases.Where(x => x.Id == ID).FirstOrDefault();
				purchaseModel = new PurchaseModel()
				{
					Id = GetData.Id,
					Process = GetData.Id,
					Sponsorid = GetData.Sponsorid,
					Accountid = GetData.Accountid,
					Bankname = GetData.Bankname,
					Branchname = GetData.Branchname,
					Ifsc = GetData.Ifsc,
					AccountNo = GetData.BankAccount,
					Cheque = GetData.Cheque,
					Chequedate = GetData.Chequedate,
					Upi = GetData.Upi,
					Shareholder = GetData.Shareholder,
					Agreementdeadline = GetData.Agreementdeadline,
					Aarajino=GetData.Aarajino,
					Area = GetData.Area,
					Banknoc = GetData.Banknoc,
					Oldagreement = GetData.Oldagreement,
					Finalamount = GetData.Finalamount,
					Advanceamoutn = GetData.Advanceamoutn,
					Dueamount=GetData.Dueamount,
					AdvocateName=GetData.Advocatename,
					Courtfee=GetData.Courtfee,
					AdvocateFee=GetData.Advocatefee,
					Stamp=GetData.Stamp,
					Rasid=GetData.Rasid,
					Lekhpalname=GetData.Lekhpalname,
					Lekhpalmobile=GetData.Lekhpalmobile,
					Inspection1356=GetData.Inspection1356,
					Inspection1291=GetData.Inspection1291,
					Sala12=GetData.Sala12,
					Najrinaksha=GetData.Najrinaksha,
					Khasra=GetData.Khasra,
					Khatauni=GetData.Khatauni
				 };
				//var getPhoto = _context.Photos.Where(x => x.Purchaseid == ID).ToList();
				//if (getPhoto != null)
				//{
				//	purchaseModel.PhotoModelList = getPhoto.Select(s => new Models.PhotoModel { Tpath = s.Tpath, Ttype = s.Ttype }).ToList();

				//}
			 
				
				purchaseModel.SponsorList = new List<SelectListItem>();
				var Data = _context.LogTblAccounts.OrderBy(x => x.AccountName).ToList();

				foreach (var item in Data)
				{
					purchaseModel.SponsorList.Add(new SelectListItem()
					{
						Value = item.AccountId.ToString(),
						Text = item.AccountName.ToString()
					}
						);
				}

				purchaseModel.SellerList = new List<SelectListItem>();
				var SellerData = _context.LogTblAccounts.Where(x => x.TType == "Seller" & x.Active == "Y").OrderBy(x => x.AccountName).ToList();
				foreach (var item in SellerData)
				{
					purchaseModel.SellerList.Add(new SelectListItem()
					{
						Value = item.AccountId.ToString(),
						Text = item.AccountName.ToString()
					});
				}
				//foreach (var item in data)
				//{
				ViewData["ID"] = GetData.Process;
				//	purchaseModel.Sponsorid= item.Id;
				//}
			}

			return View(purchaseModel);
		}

		 
		public async Task<IActionResult> AddVideo(PurchaseModel purchaseModel)
		{
			var RegUpdate = await _context.Purchases.FindAsync((purchaseModel.Id));
			if (RegUpdate != null)
			{
				{
					if (RegUpdate.Process == 2 || RegUpdate.Process == 6)
					{

						if (purchaseModel.PhotoModel.imgPhoto != null)
						{
							string folder = Path.Combine(webHostEnvironment.WebRootPath, "Upload");
							string filename = Guid.NewGuid() + "_" + purchaseModel.PhotoModel.imgPhoto.FileName;
							string FilePath = Path.Combine(folder, filename);
							await purchaseModel.PhotoModel.imgPhoto.CopyToAsync(new FileStream(FilePath, FileMode.Create));
							var Add = new Photo()
							{
								Ttype = "Photo",
								Tpath = filename,
								Purchaseid = purchaseModel.Id
							};
							_context.AddAsync(Add);

							_context.SaveChangesAsync();
						}

						if (purchaseModel.PhotoModel.imgVideo != null)
						{


							//return RedirectToAction("");

							string folder = Path.Combine(webHostEnvironment.WebRootPath, "Upload");
							string filename = Guid.NewGuid() + "_" + purchaseModel.PhotoModel.imgVideo.FileName;
							string FilePath = Path.Combine(folder, filename);
							await purchaseModel.PhotoModel.imgVideo.CopyToAsync(new FileStream(FilePath, FileMode.Create, FileAccess.Write));
							var Add = new Photo()
							{
								Ttype = "Video",
								Tpath = filename,
								Purchaseid = purchaseModel.Id
							};
							_context.AddAsync(Add);

							_context.SaveChangesAsync();



						}
					}
					var p = Convert.ToInt32(RegUpdate.Process) + 1;
					RegUpdate.Process = p;
					_context.SaveChanges();
					TempData["JavaScriptFunction"] = string.Format("Success();");
				}


			}
			return RedirectToAction("AddPurchase", new { ID = purchaseModel.Id });
			
		}

			[HttpPost]
		public async Task<IActionResult> AddPurchase(  PurchaseModel purchaseModel)
		{
			var RegUpdate = await _context.Purchases.FindAsync((purchaseModel.Id));
			if (RegUpdate != null)
			{
				if (RegUpdate.Process == 6)
				{
					RegUpdate.Sponsorid = purchaseModel.Sponsorid;
					RegUpdate.Bankname = purchaseModel.Bankname;
					RegUpdate.Branchname = purchaseModel.Branchname;
					RegUpdate.Ifsc = purchaseModel.Ifsc;
					RegUpdate.BankAccount = purchaseModel.AccountNo;
					RegUpdate.Cheque = purchaseModel.Cheque;
					RegUpdate.Chequedate = purchaseModel.Chequedate;
					RegUpdate.Upi = purchaseModel.Upi;
					RegUpdate.Shareholder = purchaseModel.Shareholder;
					RegUpdate.Agreementdeadline = purchaseModel.Agreementdeadline;
					RegUpdate.Aarajino = purchaseModel.Aarajino;

					RegUpdate.Editeddate = DateTime.Now;
					_context.SaveChanges();
				}

				  if (RegUpdate.Process == 1 || RegUpdate.Process == 5)
				{
					
						if (purchaseModel.imgBanknoc != null)
						{
							string folder = Path.Combine(webHostEnvironment.WebRootPath, "Upload");
							string filename = Guid.NewGuid() + "_" + purchaseModel.imgBanknoc.FileName;
							string FilePath = Path.Combine(folder, filename);
							purchaseModel.imgBanknoc.CopyTo(new FileStream(FilePath, FileMode.Create));
							RegUpdate.Banknoc = filename;

						}

						if (purchaseModel.imgOldagreement != null)
						{
							string folder = Path.Combine(webHostEnvironment.WebRootPath, "Upload");
							string filename = Guid.NewGuid() + "_" + purchaseModel.imgOldagreement.FileName;
							string FilePath = Path.Combine(folder, filename);
							purchaseModel.imgOldagreement.CopyTo(new FileStream(FilePath, FileMode.Create));
							RegUpdate.Oldagreement = filename;
						}

						_context.SaveChanges();
				 

				}
				
				if (RegUpdate.Process ==2  || RegUpdate.Process == 5)
				{
					RegUpdate.Finalamount = purchaseModel.Finalamount;
					RegUpdate.Advanceamoutn = purchaseModel.Advanceamoutn;
					RegUpdate.Dueamount = purchaseModel.Dueamount;
					 
					_context.SaveChanges();
				}
				  if (RegUpdate.Process == 3 || RegUpdate.Process == 5)
				{
					RegUpdate.Advocatename = purchaseModel.AdvocateName;
					RegUpdate.Courtfee = purchaseModel.Courtfee;
					RegUpdate.Advocatefee = purchaseModel.AdvocateFee;
					if (purchaseModel.imgStamp != null)
					{
						string folder = Path.Combine(webHostEnvironment.WebRootPath, "Upload");
						string filename = Guid.NewGuid() + "_" + purchaseModel.imgStamp.FileName;
						string FilePath = Path.Combine(folder, filename);
						purchaseModel.imgStamp.CopyTo(new FileStream(FilePath, FileMode.Create));
						RegUpdate.Stamp = filename;

					}

					if (purchaseModel.imgRasid != null)
					{
						string folder = Path.Combine(webHostEnvironment.WebRootPath, "Upload");
						string filename = Guid.NewGuid() + "_" + purchaseModel.imgRasid.FileName;
						string FilePath = Path.Combine(folder, filename);
						purchaseModel.imgRasid.CopyTo(new FileStream(FilePath, FileMode.Create));
						RegUpdate.Rasid = filename;
					}
					 
					_context.SaveChanges();
				}

				if (RegUpdate.Process == 4 || RegUpdate.Process == 5)
				{
					RegUpdate.Lekhpalname = purchaseModel.Lekhpalname;
					RegUpdate.Lekhpalmobile = purchaseModel.Lekhpalmobile;
				 
					if (purchaseModel.imgInspection1356 != null)
					{
						string folder = Path.Combine(webHostEnvironment.WebRootPath, "Upload");
						string filename = Guid.NewGuid() + "_" + purchaseModel.imgInspection1356.FileName;
						string FilePath = Path.Combine(folder, filename);
						purchaseModel.imgInspection1356.CopyTo(new FileStream(FilePath, FileMode.Create));
						RegUpdate.Inspection1356 = filename;

					}

					if (purchaseModel.imgInspection1291 != null)
					{
						string folder = Path.Combine(webHostEnvironment.WebRootPath, "Upload");
						string filename = Guid.NewGuid() + "_" + purchaseModel.imgInspection1291.FileName;
						string FilePath = Path.Combine(folder, filename);
						purchaseModel.imgInspection1291.CopyTo(new FileStream(FilePath, FileMode.Create));
						RegUpdate.Inspection1291 = filename;
					}

					if (purchaseModel.imgSala12 != null)
					{
						string folder = Path.Combine(webHostEnvironment.WebRootPath, "Upload");
						string filename = Guid.NewGuid() + "_" + purchaseModel.imgSala12.FileName;
						string FilePath = Path.Combine(folder, filename);
						purchaseModel.imgSala12.CopyTo(new FileStream(FilePath, FileMode.Create));
						RegUpdate.Sala12 = filename;

					}

					if (purchaseModel.imgNajrinaksha != null)
					{
						string folder = Path.Combine(webHostEnvironment.WebRootPath, "Upload");
						string filename = Guid.NewGuid() + "_" + purchaseModel.imgNajrinaksha.FileName;
						string FilePath = Path.Combine(folder, filename);
						purchaseModel.imgNajrinaksha.CopyTo(new FileStream(FilePath, FileMode.Create));
						RegUpdate.Najrinaksha = filename;
					}
					if (purchaseModel.imgKhasra != null)
					{
						string folder = Path.Combine(webHostEnvironment.WebRootPath, "Upload");
						string filename = Guid.NewGuid() + "_" + purchaseModel.imgKhasra.FileName;
						string FilePath = Path.Combine(folder, filename);
						purchaseModel.imgKhasra.CopyTo(new FileStream(FilePath, FileMode.Create));
						RegUpdate.Khasra = filename;

					}

					if (purchaseModel.imgKhatauni != null)
					{
						string folder = Path.Combine(webHostEnvironment.WebRootPath, "Upload");
						string filename = Guid.NewGuid() + "_" + purchaseModel.imgKhatauni.FileName;
						string FilePath = Path.Combine(folder, filename);
						purchaseModel.imgKhatauni.CopyTo(new FileStream(FilePath, FileMode.Create));
						RegUpdate.Khatauni= filename;
					}

					_context.SaveChanges();
				}


				if (RegUpdate.Process == 5)
				{
					

					TempData["JavaScriptFunction"] = string.Format("Update();");
				}
				else
				{
					var p = Convert.ToInt32(RegUpdate.Process) + 1;
					RegUpdate.Process = p;
					_context.SaveChanges();
					TempData["JavaScriptFunction"] = string.Format("Success();");
				}



				return RedirectToAction("AddPurchase", new { ID = purchaseModel.Id });
			}
			else
			{
				var Add = new Purchase()
				{
					Id = purchaseModel.Id,
					Sponsorid = purchaseModel.Sponsorid,
					Accountid = purchaseModel.Accountid,
					Bankname = purchaseModel.Bankname,
					Branchname = purchaseModel.Branchname,
					Ifsc = purchaseModel.Ifsc,
					BankAccount = purchaseModel.AccountNo,
					Cheque = purchaseModel.Cheque,
					Chequedate = purchaseModel.Chequedate,
					Upi = purchaseModel.Upi,
					Shareholder = purchaseModel.Shareholder,
					Agreementdeadline = purchaseModel.Agreementdeadline,
					Aarajino = purchaseModel.Aarajino,
					Area = purchaseModel.Area,
					Process = 1

				};
				_context.Add(Add);
				_context.SaveChanges();
				TempData["JavaScriptFunction"] = string.Format("Success();");
				int lasttId = _context.Purchases.Max(m => m.Id);
				ViewData["ID"] = "1";
				return RedirectToAction("AddPurchase", new { ID = lasttId });


			}
			 
		}

		 
		public async Task<IActionResult> AddPhoto(int ID)
		{
			var getPhoto = _context.Photos.Where(x => x.Purchaseid == ID).ToList();
			PhotoModel photoModel = new PhotoModel();
			if (getPhoto != null)
			{
				photoModel.PhotosList = getPhoto.Select(s => new Models.PhotoModel {Id=s.Id, Tpath = s.Tpath, Ttype = s.Ttype }).ToList();

			}
			 
			return View(photoModel);
		}
		[HttpPost]
		public async Task<IActionResult> AddPhoto(PhotoModel purchaseModel)
		{



			if (purchaseModel.imgPhoto != null)
			{
				string folder = Path.Combine(webHostEnvironment.WebRootPath, "Upload");
				string filename = Guid.NewGuid() + "_" + purchaseModel.imgPhoto.FileName;
				string FilePath = Path.Combine(folder, filename);
				purchaseModel.imgPhoto.CopyTo(new FileStream(FilePath, FileMode.Create));
				var Add = new Photo()
				{
					
					Ttype = "Photo",
					Tpath = filename,
					Purchaseid = purchaseModel.Id
				};
				_context.Add(Add);

				_context.SaveChanges();
				}

				if (purchaseModel.imgVideo != null)
					{
						string folder = Path.Combine(webHostEnvironment.WebRootPath, "Upload");
						string filename = Guid.NewGuid() + "_" + purchaseModel.imgVideo.FileName;
						string FilePath = Path.Combine(folder, filename);
						string videoFname = Guid.NewGuid() + "_" + Path.GetExtension(purchaseModel.imgVideo.FileName);
					string VideoFilePath = Path.Combine(Path.GetTempPath(),videoFname);
				using Stream filestream = new FileStream(VideoFilePath, FileMode.Create);

				purchaseModel.imgVideo.CopyTo(filestream);
				var fi=new FileInfo(purchaseModel.imgVideo.FileName);
				//string extension = fi.Extension.ToUpper();
				//if (extension !=".MP4" &&
				//	extension!=".WEBM" &&
				//	extension!=".OGG")
				//{
				//	VideoFilePath= ConvertToMP4
				//}
						var Add = new Photo()
						{
							Ttype = "Video",
							Tpath = filename,
							Purchaseid = purchaseModel.Id
						};
						_context.Add(Add);

						_context.SaveChanges();
					}
					_context.SaveChanges();
					TempData["JavaScriptFunction"] = string.Format("Success();");

 
			return RedirectToAction("AddPhoto", new { ID = purchaseModel.Id });
		}
		public IActionResult DelPhoto(int ID)
		{
			if(ID!=0)
			{
				var Del = _context.Photos.Where(x => x.Id == ID).FirstOrDefault();
				if(Del!=null)
				{
					_context.Photos.Remove(Del);
					_context.SaveChanges();
					TempData["JavaScriptFunction"] = string.Format("Delete();");
				}
				return RedirectToAction("AddPhoto", new { ID = Del.Purchaseid });
			}
			else
			{
				return RedirectToAction("PurchaseList");
			}
			
		}
		public IActionResult PurchaseList ()
		{
			var GetData = (from AC in _context.LogTblAccounts
						   join PUR in _context.Purchases on AC.AccountId equals PUR.Accountid
						   join SP in _context.LogTblAccounts on AC.Sponsorid equals SP.AccountId
						   select new PurchaseModel
						   {
							   Id=PUR.Id,
							   SponsorName=SP.AccountName,
							   AccountName=AC.AccountName,
							   Address2=AC.Address2,
							   Mobile=AC.Mobile,
							   WhatsApp=AC.WhatsApp,
							   Aarajino=PUR.Aarajino,
							   Area=PUR.Area,
							   Finalamount=PUR.Finalamount,
							   Advanceamoutn=PUR.Advanceamoutn,
							   Dueamount=PUR.Dueamount,
							   Process=PUR.Process,
							   Createddate=PUR.Createddate
							  
						   }
						 ).ToList();

			return View(GetData);
		}

		public IActionResult AddSale(int ID)
		{

			SaleModel saleModel = new SaleModel();
			

			if (ID == 0)
			{
				ViewData["ID"] = "0";
				saleModel.SponsorList = new List<SelectListItem>();
				var Data = _context.LogTblAccounts.OrderBy(x => x.AccountName).ToList();

				foreach (var item in Data)
				{
					saleModel.SponsorList.Add(new SelectListItem()
					{
						Value = item.AccountId.ToString(),
						Text = item.AccountName.ToString()
					}
						);
				}

				saleModel.CustomerList = new List<SelectListItem>();
				var SellerData = _context.LogTblAccounts.Where(x => x.TType == "Customer" & x.Active == "Y").OrderBy(x => x.AccountName).ToList();
				foreach (var item in SellerData)
				{
					saleModel.CustomerList.Add(new SelectListItem()
					{
						Value = item.AccountId.ToString(),
						Text = item.AccountName.ToString()
					});
				}

				var ProjectlistData = _context.ProjectDbs.ToList();
				var PlotData = new List<PlotModel>();
				 
				ViewBag.ProjectData = new SelectList(ProjectlistData, "Id", "ProjectName");
				ViewBag.PropertyType = new SelectList(PlotData, "Propertyid", "Propertyname");
				ViewBag.Block = new SelectList(PlotData, "Blockid", "Blockname");
				ViewBag.Plotno = new SelectList(PlotData, "Plotno", "Plotno");
			}
			else
			{
				

				var GetData = _context.Sales.Where(x => x.Id == ID).FirstOrDefault();
				saleModel = new SaleModel()
				{
					Id = GetData.Id,
				 
					Sponsorid = GetData.Sponsorid,
					Customerid = GetData.Customerid,
					Projectid=GetData.Projectid,
					Propertyid=GetData.Propertyid,
					Blockid=GetData.Blockid,
					Plotno=GetData.Plotno,
					PlotSize=GetData.Plotsize,
					Direction=GetData.Direction,
					Chauhaddi=GetData.Chauhaddi,
					Aarajino=GetData.Aarajino,

					Bankname = GetData.Bankname,
					Branchname = GetData.Branchname,
					Ifsc = GetData.Ifsc,
					Accountno = GetData.Accountno,
					Cheque = GetData.Cheque,
					Chequedate = GetData.Chequedate,
					Upi = GetData.Upi,
					Finalamount = GetData.Finalamount,
					Advanceamoutn=GetData.Advanceamoutn,
					Dueamount = GetData.Dueamount,
					Sponsorcommision = GetData.Sponsorcommision,
					Sbankname = GetData.Sbankname,
					Sbranchname = GetData.Sbranchname,
					Sifsc = GetData.Sifsc,
					SAccountno=GetData.Saccountno,
					Scheque = GetData.Scheque,
					Schequedate = GetData.Schequedate,
					Supi = GetData.Supi,
					Loancustomerfull = GetData.Loancustomerfull,
					Loansalaryslip = GetData.Loansalaryslip,
					Customerfeedback = GetData.Customerfeedback,
					 
				};

				saleModel.SponsorList = new List<SelectListItem>();
				var Data = _context.LogTblAccounts.OrderBy(x => x.AccountName).ToList();

				foreach (var item in Data)
				{
					saleModel.SponsorList.Add(new SelectListItem()
					{
						Value = item.AccountId.ToString(),
						Text = item.AccountName.ToString()
					}
						);
				}

				saleModel.CustomerList = new List<SelectListItem>();
				var SellerData = _context.LogTblAccounts.Where(x => x.TType == "Customer" & x.Active == "Y").OrderBy(x => x.AccountName).ToList();
				foreach (var item in SellerData)
				{
					saleModel.CustomerList.Add(new SelectListItem()
					{
						Value = item.AccountId.ToString(),
						Text = item.AccountName.ToString()
					});
				}

				var ProjectlistData = _context.ProjectDbs.ToList();
			 
				var PlotData = new List<PlotModel>();

				ViewBag.ProjectData = new SelectList(ProjectlistData, "Id", "ProjectName");
				ViewBag.PropertyType = new SelectList(PlotData, "Propertyid", "Propertyname");
				ViewBag.Block = new SelectList(PlotData, "Blockid", "Blockname");
				ViewBag.Plotno = new SelectList(PlotData, "Plotno", "Plotno");

				 
			}

			return View(saleModel);
		}
		[HttpPost]
		public async Task<IActionResult> AddSale(SaleModel saleModel)
		{
			var RegUpdate = await _context.Sales.FindAsync((saleModel.Id));
			if (RegUpdate == null)
			 
			{
				var getPlotsize = _context.Plots.Where(x => x.Projectid == saleModel.Projectid & x.Propertyid == saleModel.Propertyid & x.Blockid == saleModel.Blockid).FirstOrDefault();
				string Loancustomerfullfile = "";
				if (saleModel.imgLoancustomerfull != null)
				{
					string folder = Path.Combine(webHostEnvironment.WebRootPath, "Upload");
					Loancustomerfullfile = Guid.NewGuid() + "_" + saleModel.imgLoancustomerfull.FileName;
					string FilePath = Path.Combine(folder, Loancustomerfullfile);
					saleModel.imgLoancustomerfull.CopyTo(new FileStream(FilePath, FileMode.Create));
					 

				}
				string LoanSalarySlipfile = "";
				if (saleModel.imgLoancustomerfull != null)
				{
					string folder = Path.Combine(webHostEnvironment.WebRootPath, "Upload");
					LoanSalarySlipfile = Guid.NewGuid() + "_" + saleModel.imgLoancustomerfull.FileName;
					string FilePath = Path.Combine(folder, LoanSalarySlipfile);
					saleModel.imgLoancustomerfull.CopyTo(new FileStream(FilePath, FileMode.Create));


				}
				var Add = new Sale()
				{
					Id = saleModel.Id,
					Sponsorid = saleModel.Sponsorid,
					Customerid = saleModel.Customerid,
					Projectid = saleModel.Projectid,
					Propertyid = saleModel.Propertyid,
					Blockid = saleModel.Blockid,
					Plotno = saleModel.Plotno,
					Plotsize = getPlotsize.PlotSize,
					Direction = saleModel.Direction,
					Chauhaddi = saleModel.Chauhaddi,
					Aarajino = saleModel.Aarajino,
					Profit = saleModel.profit,
					Saletype = "Own",
					Bankname = saleModel.Bankname,
					Branchname = saleModel.Branchname,
					Ifsc = saleModel.Ifsc,
					Cheque = saleModel.Cheque,
					Chequedate = saleModel.Chequedate,
					Upi=saleModel.Upi,
					Accountno=saleModel.Accountno,
					Finalamount=saleModel.Finalamount,
					Dueamount=saleModel.Dueamount,
					Advanceamoutn=saleModel.Advanceamoutn,
					Sponsorcommision=saleModel.Sponsorcommision,
					
					Sbankname=saleModel.Sbankname,
					Sbranchname=saleModel.Sbranchname,
					Sifsc=saleModel.Sifsc,
					Scheque=saleModel.Scheque,
					Schequedate=saleModel.Schequedate,
					Supi=saleModel.Supi,
					Saccountno=saleModel.SAccountno,
					Sfinalcommission=saleModel.Sfinalcommission,
					Loancustomerfull=  Loancustomerfullfile,
					Loansalaryslip= LoanSalarySlipfile,
					Customerfeedback=saleModel.Customerfeedback,
					Createddate=DateTime.Now

				};
				_context.Add(Add);
				_context.SaveChanges();
				int id = 1;
				var GetPara = _context.LogTblParas.Find(id);
				int lasttId = _context.Sales.Max(m => m.Id);
				var AddReceipt = new Receipt()
				{
					Id = saleModel.Id,
					Saleid= lasttId,
					Receiptno = GetPara.ReceiptNo,
					Sponsorid = saleModel.Sponsorid,
					Customerid = saleModel.Customerid,
					Projectid = saleModel.Projectid,
					Propertyid = saleModel.Propertyid,
					Blockid = saleModel.Blockid,
					Plotno = saleModel.Plotno,
					 
					Finalamount = saleModel.Finalamount,
					Dueamount = saleModel.Dueamount,
					Receivedamount = saleModel.Advanceamoutn,
					 
					Createddate = DateTime.Now

				};
				_context.Add(AddReceipt);
				//saleModel.receiptno = _context.Receipts.Max(m=>m.Id);
				if(GetPara!=null)
				{
					GetPara.ReceiptNo = GetPara.ReceiptNo + 1;
				}
				
				_context.SaveChanges();
				TempData["JavaScriptFunction"] = string.Format("Success();");
			}
			int lasttReceipt = _context.Receipts.Max(m => m.Id);
			return RedirectToAction("Receipt", new { ID = lasttReceipt });
			 
		}
		public IActionResult SaleList()
		{
			var GetData = (from AC in _context.LogTblAccounts
						   join PUR in _context.Sales on AC.AccountId equals PUR.Customerid
						   join SP in _context.LogTblAccounts on AC.Sponsorid equals SP.AccountId
						   join PR in _context.ProjectDbs on PUR.Projectid equals PR.Id	
						   join PT in _context.PropertyTypes on PUR.Propertyid equals PT.Id
						   join BL in _context.Blocks on PUR.Blockid equals BL.Id
						   join RC in _context.Receipts on PUR.Id equals RC.Saleid
						   where PUR.Saletype!="Other"
						   select new SaleModel
						   {
							   Id = PUR.Id,
							   receiptno=RC.Id,
							   SponsorName = SP.AccountName,
							   CustomerName = AC.AccountName,
							   CAddress = AC.Address2,
							   CMobile = AC.Mobile,
							   CWhataApp = AC.WhatsApp,
							   ProjectName=PR.ProjectName,
							   Propertyname=PT.TType,
							   Blockname=BL.Block1,
							   Plotno=PUR.Plotno,
							   Aarajino = PUR.Aarajino,
							   PlotSize = PUR.Plotsize,
							   
							   Createddate = PUR.Createddate

						   }
						 ).ToList();

			return View(GetData);
		}
		public IActionResult OtherSale(int ID)
		{

			SaleModel saleModel = new SaleModel();


			if (ID == 0)
			{
				ViewData["ID"] = "0";
				saleModel.SponsorList = new List<SelectListItem>();
				var Data = _context.LogTblAccounts.OrderBy(x => x.AccountName).ToList();

				foreach (var item in Data)
				{
					saleModel.SponsorList.Add(new SelectListItem()
					{
						Value = item.AccountId.ToString(),
						Text = item.AccountName.ToString()
					}
						);
				}

				saleModel.CustomerList = new List<SelectListItem>();
				var SellerData = _context.LogTblAccounts.Where(x => x.TType == "Customer" & x.Active == "Y").OrderBy(x => x.AccountName).ToList();
				foreach (var item in SellerData)
				{
					saleModel.CustomerList.Add(new SelectListItem()
					{
						Value = item.AccountId.ToString(),
						Text = item.AccountName.ToString()
					});
				}

				var ProjectlistData = _context.ProjectDbs.ToList();
				var PlotData = new List<PlotModel>();

				ViewBag.ProjectData = new SelectList(ProjectlistData, "Id", "ProjectName");
				ViewBag.PropertyType = new SelectList(PlotData, "Propertyid", "Propertyname");
				ViewBag.Block = new SelectList(PlotData, "Blockid", "Blockname");
				ViewBag.Plotno = new SelectList(PlotData, "Plotno", "Plotno");
			}
			else
			{


				var GetData = _context.Sales.Where(x => x.Id == ID).FirstOrDefault();
				saleModel = new SaleModel()
				{
					Id = GetData.Id,

					Sponsorid = GetData.Sponsorid,
					Customerid = GetData.Customerid,
					Projectid = GetData.Projectid,
					Propertyid = GetData.Propertyid,
					Blockid = GetData.Blockid,
					Plotno = GetData.Plotno,
					PlotSize = GetData.Plotsize,
					Direction = GetData.Direction,
					Chauhaddi = GetData.Chauhaddi,
					Aarajino = GetData.Aarajino,

					Bankname = GetData.Bankname,
					Branchname = GetData.Branchname,
					Ifsc = GetData.Ifsc,
					Accountno = GetData.Accountno,
					Cheque = GetData.Cheque,
					Chequedate = GetData.Chequedate,
					Upi = GetData.Upi,
					Finalamount = GetData.Finalamount,
					Advanceamoutn = GetData.Advanceamoutn,
					Dueamount = GetData.Dueamount,
					Sponsorcommision = GetData.Sponsorcommision,
					Sbankname = GetData.Sbankname,
					Sbranchname = GetData.Sbranchname,
					Sifsc = GetData.Sifsc,
					SAccountno = GetData.Saccountno,
					Scheque = GetData.Scheque,
					Schequedate = GetData.Schequedate,
					Supi = GetData.Supi,
					Loancustomerfull = GetData.Loancustomerfull,
					Loansalaryslip = GetData.Loansalaryslip,
					Customerfeedback = GetData.Customerfeedback,

				};

				saleModel.SponsorList = new List<SelectListItem>();
				var Data = _context.LogTblAccounts.OrderBy(x => x.AccountName).ToList();

				foreach (var item in Data)
				{
					saleModel.SponsorList.Add(new SelectListItem()
					{
						Value = item.AccountId.ToString(),
						Text = item.AccountName.ToString()
					}
						);
				}

				saleModel.CustomerList = new List<SelectListItem>();
				var SellerData = _context.LogTblAccounts.Where(x => x.TType == "Customer" & x.Active == "Y").OrderBy(x => x.AccountName).ToList();
				foreach (var item in SellerData)
				{
					saleModel.CustomerList.Add(new SelectListItem()
					{
						Value = item.AccountId.ToString(),
						Text = item.AccountName.ToString()
					});
				}

				var ProjectlistData = _context.ProjectDbs.ToList();

				var PlotData = new List<PlotModel>();

				ViewBag.ProjectData = new SelectList(ProjectlistData, "Id", "ProjectName");
				ViewBag.PropertyType = new SelectList(PlotData, "Propertyid", "Propertyname");
				ViewBag.Block = new SelectList(PlotData, "Blockid", "Blockname");
				ViewBag.Plotno = new SelectList(PlotData, "Plotno", "Plotno");


			}

			return View(saleModel);
		}
		[HttpPost]
		public async Task<IActionResult> OtherSale(SaleModel saleModel)
		{
			var RegUpdate = await _context.Sales.FindAsync((saleModel.Id));
			if (RegUpdate == null)

			{
				var getPlotsize = _context.Plots.Where(x => x.Projectid == saleModel.Projectid & x.Propertyid == saleModel.Propertyid & x.Blockid == saleModel.Blockid).FirstOrDefault();
				string Loancustomerfullfile = "";
				if (saleModel.imgLoancustomerfull != null)
				{
					string folder = Path.Combine(webHostEnvironment.WebRootPath, "Upload");
					Loancustomerfullfile = Guid.NewGuid() + "_" + saleModel.imgLoancustomerfull.FileName;
					string FilePath = Path.Combine(folder, Loancustomerfullfile);
					saleModel.imgLoancustomerfull.CopyTo(new FileStream(FilePath, FileMode.Create));


				}
				string LoanSalarySlipfile = "";
				if (saleModel.imgLoancustomerfull != null)
				{
					string folder = Path.Combine(webHostEnvironment.WebRootPath, "Upload");
					LoanSalarySlipfile = Guid.NewGuid() + "_" + saleModel.imgLoancustomerfull.FileName;
					string FilePath = Path.Combine(folder, LoanSalarySlipfile);
					saleModel.imgLoancustomerfull.CopyTo(new FileStream(FilePath, FileMode.Create));


				}
				var Add = new Sale()
				{
					Id = saleModel.Id,
					Sponsorid = saleModel.Sponsorid,
					Customerid = saleModel.Customerid,
					 Propertydetails=saleModel.Propertydetails,
					 Profit=saleModel.profit,
					 Saletype="Other",
					Bankname = saleModel.Bankname,
					Branchname = saleModel.Branchname,
					Ifsc = saleModel.Ifsc,
					Cheque = saleModel.Cheque,
					Chequedate = saleModel.Chequedate,
					Upi = saleModel.Upi,
					Accountno = saleModel.Accountno,
					Finalamount = saleModel.Finalamount,
					Dueamount = saleModel.Dueamount,
					Advanceamoutn = saleModel.Advanceamoutn,
					Sponsorcommision = saleModel.Sponsorcommision,

					Sbankname = saleModel.Sbankname,
					Sbranchname = saleModel.Sbranchname,
					Sifsc = saleModel.Sifsc,
					Scheque = saleModel.Scheque,
					Schequedate = saleModel.Schequedate,
					Supi = saleModel.Supi,
					Saccountno = saleModel.SAccountno,
					Sfinalcommission = saleModel.Sfinalcommission,
					Loancustomerfull = Loancustomerfullfile,
					Loansalaryslip = LoanSalarySlipfile,
					Customerfeedback = saleModel.Customerfeedback,
					Createddate = DateTime.Now

				};
				_context.Add(Add);
				_context.SaveChanges();

				int id = 1;
				var GetPara = _context.LogTblParas.Find(id);
				int lasttId = _context.Sales.Max(m => m.Id);
				var AddReceipt = new Receipt()
				{
					Id = saleModel.Id,
					Saleid = lasttId,
					Receiptno = GetPara.ReceiptNo,
					Sponsorid = saleModel.Sponsorid,
					Customerid = saleModel.Customerid,
					Projectid = saleModel.Projectid,
					Propertyid = saleModel.Propertyid,
					Blockid = saleModel.Blockid,
					Plotno = saleModel.Plotno,

					Finalamount = saleModel.Finalamount,
					Dueamount = saleModel.Dueamount,
					Receivedamount = saleModel.Advanceamoutn,

					Createddate = DateTime.Now

				};
				_context.Add(AddReceipt);
				//saleModel.receiptno = _context.Receipts.Max(m=>m.Id);
				if (GetPara != null)
				{
					GetPara.ReceiptNo = GetPara.ReceiptNo + 1;
				}


				_context.SaveChanges();
				TempData["JavaScriptFunction"] = string.Format("Success();");
			}

			return RedirectToAction("OtherSale");
		}
		public IActionResult OtherSaleList()
		{
			var GetData = (from AC in _context.LogTblAccounts
						   join PUR in _context.Sales on AC.AccountId equals PUR.Customerid
						   join SP in _context.LogTblAccounts on AC.Sponsorid equals SP.AccountId
						   
						   where PUR.Saletype.Equals("Other")
						   select new SaleModel
						   {
							   Id = PUR.Id,
							   
							   SponsorName = SP.AccountName,
							   CustomerName = AC.AccountName,
							   CAddress = AC.Address2,
							   CMobile = AC.Mobile,
							   CWhataApp = AC.WhatsApp,
							   Propertydetails = PUR.Propertydetails,
							   profit = PUR.Profit,
							   Finalamount=PUR.Finalamount,
							   Sponsorcommision=PUR.Sponsorcommision,
							   Sfinalcommission=PUR.Sfinalcommission,
							   Createddate = PUR.Createddate

						   }
						 ).ToList();

			return View(GetData);
		}
		public JsonResult GetCustomerDetails(int customerid)
		{
			var data = _context.LogTblAccounts.Where(x => x.AccountId == customerid).ToList();
			return Json(_context.LogTblAccounts.Where(x => x.AccountId == customerid).ToList());
		}
		public JsonResult GetSponsorDetails(int sponsorid)
		{
			var data = _context.LogTblAccounts.Where(x => x.AccountId == sponsorid).ToList();
			return Json(_context.LogTblAccounts.Where(x => x.AccountId == sponsorid).ToList());
		}
		public  JsonResult GetPropertyByProjectID(int projectid)
		{
			var data = _context.Rptplots.Where(x => x.Projectid == projectid).ToList();
			return Json(_context.Rptplots.Where(x => x.Projectid == projectid).ToList());
		}

		public JsonResult GetBlockByProprtyID(int propertyid, int projectid)
		{
			var data = _context.Rptplots.Where(x => x.Properytid == propertyid).ToList();
			return Json(_context.Rptplots.Where(x => x.Properytid == propertyid & x.Projectid==projectid).ToList());
		}
		public JsonResult GePlotByBlockID(int blockid, int projectid)
		{
			var data = _context.Rptplots.Where(x => x.BlockId == blockid).ToList();
			return Json(_context.Rptplots.Where(x => x.BlockId == blockid & x.Projectid == projectid).ToList());
		}
		public JsonResult GePlot(int blockid, int projectid)
		{
			var data = _context.Rptplots.Where(x => x.BlockId == blockid).ToList();
			return Json(_context.Rptplots.Where(x => x.BlockId == blockid & x.Projectid == projectid).ToList());
		}

		public IActionResult test ()
		{
			var ProjectlistData = _context.ProjectDbs.ToList();
			var PropertyType = new List<PropertyType>();
			ViewBag.Project = new SelectList(ProjectlistData, "Id", "ProjectName");
			ViewBag.PropertyType = new SelectList(PropertyType, "ID", "PropertyType");
			return View();
		}
		public IActionResult Receipt(int id)
		{
			ReceiptModel receiptModel = new ReceiptModel();
			var GetData = _context.RptReceipts.Where(x => x.Id == id).FirstOrDefault();

			if (GetData != null)
			{

				receiptModel = new ReceiptModel()
				{
					Id = GetData.Id,
					 ReceiptNo=GetData.Receiptno,
					Accountname =GetData.Accountname,
					Email=GetData.Email,
					Mobile=GetData.Mobile,
					Address=GetData.Address,
					Plot=GetData.Plot,
					Plotsize=GetData.Plotsize,
					Direction=GetData.Direction,
					Chauhaddi=GetData.Chauhaddi,
					Aarajino=GetData.Aarajino,
					Bankname=GetData.Bankname,
					Branchname=GetData.Branchname,
					Ifsc=GetData.Ifsc,
					Accountno=GetData.Accountno,
					Cheque=GetData.Cheque,
					Chequedate=GetData.Chequedate,
					Upi=GetData.Upi,
					Finalamount=GetData.Finalamount,
					Receivedamount=GetData.Receivedamount,
					 
					Dueamount=GetData.Dueamount,
					Createddate=GetData.Createddate

				};

			}
			return View(receiptModel);
		}
		public IActionResult PrintReceipt(int id)
		{
			ReceiptModel receiptModel = new ReceiptModel();
			var GetData = _context.RptReceipts.Where(x => x.Id == id).FirstOrDefault();
			 
			if (GetData != null)
			{

				receiptModel = new ReceiptModel()
				{
					Id = GetData.Id,
					ReceiptNo = GetData.Receiptno,
					Accountname = GetData.Accountname,
					Email = GetData.Email,
					Mobile = GetData.Mobile,
					Address = GetData.Address,
					Plot = GetData.Plot,
					Plotsize = GetData.Plotsize,
					Direction = GetData.Direction,
					Chauhaddi = GetData.Chauhaddi,
					Aarajino = GetData.Aarajino,
					Bankname = GetData.Bankname,
					Branchname = GetData.Branchname,
					Ifsc = GetData.Ifsc,
					Accountno = GetData.Accountno,
					Cheque = GetData.Cheque,
					Chequedate = GetData.Chequedate,
					Upi = GetData.Upi,
					Finalamount = GetData.Finalamount,
					Receivedamount = GetData.Receivedamount,

					Dueamount = GetData.Dueamount,
					Createddate = GetData.Createddate

				};

			}
			return View(receiptModel);
		}
		public IActionResult ReceiptList()
		{
			var GetData = (from AC in _context.LogTblAccounts
						   join PUR in _context.Sales on AC.AccountId equals PUR.Customerid
						   join SP in _context.LogTblAccounts on AC.Sponsorid equals SP.AccountId
						   join PR in _context.ProjectDbs on PUR.Projectid equals PR.Id
						   join PT in _context.PropertyTypes on PUR.Propertyid equals PT.Id
						   join BL in _context.Blocks on PUR.Blockid equals BL.Id
						   join RC in _context.Receipts on PUR.Id equals RC.Saleid
						   select new ReceiptModel
						   {
							   Id = RC.Id,
							   ReceiptNo = RC.Receiptno.ToString(),
							   SponsorName = SP.AccountName,
							   Accountname = AC.AccountName,
							   Address = AC.Address2,
							   Mobile = AC.Mobile,
							  
							   Plot = PR.ProjectName +' '+ PUR.Plotno ,
							    
							   Aarajino = PUR.Aarajino,
							   Plotsize = PUR.Plotsize,

							   Createddate = RC.Createddate

						   }
						 ).ToList();

			return View(GetData);
		}
		public IActionResult CommissionList()
		{
			var GetData = (from AC in _context.LogTblAccounts
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
						  PaidCommission= _context.Paidcommissions.Where(a => a.Sponsorid == g.Key).Select(p => p.Amount).Sum(),
							   //dc.Deliveries.Where(n => n.TripDate == d).Sum(n => n.Rate)
							   TobePaidCommission= ((_context.Purchases.Where(a => a.Sponsorid == g.Key).Select(p => p.Finalamount).Sum() * 2 / 100)+(_context.Sales.Where(a => a.Sponsorid == g.Key).Select(p => p.Sfinalcommission).Sum()) - _context.Paidcommissions.Where(a => a.Sponsorid == g.Key).Select(p => p.Amount).Sum())



						   }
			 ).ToList();

			return View(GetData);
		}
		public IActionResult Payout(int id)
		{
			//PaidCommissionModel paidCommissionModel = new PaidCommissionModel();
			var para = _context.LogTblParas.FirstOrDefault();
			PaidCommissionModel paid = new PaidCommissionModel();
			var GetData = _context.RptAccounts.Where(x => x.AccountId == id).FirstOrDefault();
			//var purCommission=_context.Purchases.Where(x=>x.Sponsorid==id).FirstOrDefault();

			if (GetData != null)
			{

				paid = new PaidCommissionModel()
				{
					 
					SponsorName =GetData.Sponsorname,
					 Ref=para.PaymentRefNo,
					 AccountID=GetData.AccountId,
					Accountname = GetData.AccountName,
					
					Mobile = GetData.Mobile,
					Address = GetData.Address,
				  Amount = ((_context.Purchases.Where(a => a.Sponsorid == id).Select(p => p.Finalamount).Sum() * 2 / 100) + (_context.Sales.Where(a => a.Sponsorid == id).Select(p => p.Sfinalcommission).Sum()) - _context.Paidcommissions.Where(a => a.Sponsorid == id).Select(p => p.Amount).Sum()),
					PaidAmount = ((_context.Purchases.Where(a => a.Sponsorid == id).Select(p => p.Finalamount).Sum() * 2 / 100) + (_context.Sales.Where(a => a.Sponsorid == id).Select(p => p.Sfinalcommission).Sum()) - _context.Paidcommissions.Where(a => a.Sponsorid == id).Select(p => p.Amount).Sum()),

					 

				};
				ViewData["Name"] = GetData.AccountName;
				 
			}
			return View(paid);






		}
		[HttpPost]
		public async Task<IActionResult> Payout(PaidCommissionModel paid)
		{
			//PaidCommissionModel paidCommissionModel = new PaidCommissionModel();


			var Add = new Paidcommission()
			{
				Ref=paid.Ref,
				Sponsorid=paid.AccountID,
				Amount=paid.PaidAmount,
				Createddate=System.DateTime.Now,
				Paymode=paid.Paymode,
				Bankname=paid.Bankname,
				Branchname=paid.Branchname,
				Ifsc=paid.Ifsc,
				Cheque=paid.Cheque,
				Chequedate=paid.Chequedate,
				Upi=paid.Upi,
				AccountNo=paid.AccountNo,
				Utr=paid.Utr

			};
			_context.Add(Add);
			_context.SaveChanges();
			TempData["JavaScriptFunction"] = string.Format("Success();");



			return RedirectToAction("CommissionList");
		}
		public IActionResult StatementDetails(int id)
		{
			 
			var RegData = _context.TblTempStatements.FromSqlRaw("EXECUTE GetStatement {0}", id).ToList();
			// var data = _context.AdminLogins.FromSql($"EXECUTE GetStatement  {id}");
			//var RegData = _context.TblTempStatements.ToList();
			//RegistrationList Rlist = new RegistrationList();
			List<StatementModel> statement = new List<StatementModel>();
			if (RegData.Count > 0)
			{
				foreach (var item in RegData)
				{
					var Rlist = new StatementModel()
					{
						 
						IDate = item.IDate,
						PartyName = item.PartyName,
						Amt = item.Amt,
						Commission = item.Commission,
						PaymentRecAmt = item.PaymentRecAmt,
						CommissionType = item.CommissionType
						 
					};
					statement.Add(Rlist);

				}

			}
			return View(statement);






		}
	}
}
