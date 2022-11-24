using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebForm1._0.Models;

namespace WebForm1._0.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			FormDBContext db = new FormDBContext();
			List<FormData> obj = db.getData();

			return View(obj);
		}

		public ActionResult Create()
		{

			return View();
		}

		[HttpPost]
		public ActionResult Create(FormData data)
		{
			try
			{
				if (ModelState.IsValid == true)
				{
					FormDBContext context = new FormDBContext();
					bool check = context.AddData(data);
					if (check == true)
					{
						TempData["InsertMessage"] = "Data has been inserted Successfully!";
						ModelState.Clear();
						return RedirectToAction("Index");
					}
				}
				return View();
			}
			catch
			{
				return View();
			}
		}
		public ActionResult Edit(int id)
		{
			FormDBContext context = new FormDBContext();
			var row = context.getData().Find(model => model.id == id);
			return View(row);
		}

		[HttpPost]
		public ActionResult Edit(int id, FormData data)
		{
			if (ModelState.IsValid == true)
			{
				FormDBContext context = new FormDBContext();
				bool check = context.UpdateData(data);
				if (check == true)
				{
					TempData["UpdateMessage"] = "Data has been Updated Successfully.";
					ModelState.Clear();
					return RedirectToAction("Index");
				}

			}

			return View();
		}
		public ActionResult Details(int id)
		{
			FormDBContext context = new FormDBContext();
			var row = context.getData().Find(model => model.id == id);
			return View(row);
		}

		public ActionResult Delete(int id)
		{
			FormDBContext context = new FormDBContext();
			var row = context.getData().Find(model => model.id == id);
			return View(row);
		}

		[HttpPost]
		public ActionResult Delete(int id, FormData data)
		{

			FormDBContext context = new FormDBContext();
			bool check = context.DeleteData(id);
			if (check == true)
			{
				TempData["DeleteMessage"] = "Data has been Deleted Successfully.";
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}