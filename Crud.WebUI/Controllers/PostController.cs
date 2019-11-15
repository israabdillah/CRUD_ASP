using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Crud.Core.Contracts;
using Crud.Core.Models;

namespace Crud.WebUI.Controllers
{
	public class PostController : Controller
	{
		IRepository<Post> context;

		public PostController(IRepository<Post> Context) {
			context = Context;
		}

		public ActionResult Index()
		{
			List<Post> posts = context.Collection().ToList();
			return View(posts);
		}
		public ActionResult Details(string Id) {
			Post posts = context.Find(Id);
			if(posts == null) {
				return HttpNotFound();
			}
			else 
			{
				return View(posts);
			}
		}
		public ActionResult Create() {
			Post posts = new Post();
			return View(posts);
		}
		[HttpPost]
		public ActionResult Create(Post posts) {
			if (!ModelState.IsValid)
			{
				return View(posts);
			}
			else
			{
				context.Insert(posts);
				context.Commit();

				return RedirectToAction("Index");
			}
		}

		public ActionResult Edit(string Id) {
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
		[HttpPost]
		public ActionResult Edit(Post posts, String Id)
		{
			Post PostToEdit = context.Find(Id);
			if (PostToEdit == null)
			{
				return HttpNotFound();
			}
			else {
				if (!ModelState.IsValid)
				{
					return View(posts);
				}
				else 
				{
					PostToEdit.Title = posts.Title;
					PostToEdit.Description = posts.Description;
					PostToEdit.Category = posts.Category;
					context.Commit();

					return RedirectToAction("Index");
				}
			}
		}

		public ActionResult Delete(string Id) {
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

		[HttpPost]
		public ActionResult ConfirmToDelete(string Id) {
			Post PostToDelete = context.Find(Id);
			if (PostToDelete == null)
			{
				return HttpNotFound();
			}
			else 
			{
				context.Delete(Id);
				context.Commit();

				return Redirect("Index");
			}
		}
	}
}