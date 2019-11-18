using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Crud.Core.Contracts;
using Crud.Core.Models;
using Crud.Core.ViewModels;

namespace Crud.WebUI.Controllers
{
	public class HomeController : Controller
	{
		IRepository<Post> context;
		IRepository<PostCategory> postCategories;

		public HomeController(IRepository<Post> Context, IRepository<PostCategory> postCategoryContext)
		{
			context = Context;
			postCategories = postCategoryContext;
		}
		public ActionResult Index(string Category = null)
		{
			List<Post> posts;
			List<PostCategory> categories = postCategories.Collection().ToList();

			if (Category == null)
			{

				posts = context.Collection().ToList();
			}
			else
			{
				posts = context.Collection().Where(p => p.Category == Category).ToList();
			}

			PostListViewModel model = new PostListViewModel();
			model.Poste = posts;
			model.postCategories = categories;

			return View(model);
		}

		public ActionResult Details(string Id)
		{
			Post posts = context.Find(Id);
			if (posts == null)
			{
				return HttpNotFound();
			}
			else
			{
				return View(posts);
			}
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}