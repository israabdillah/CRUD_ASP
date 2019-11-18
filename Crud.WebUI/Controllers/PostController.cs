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
	public class PostController : Controller
	{
		IRepository<Post> context;
		IRepository<PostCategory> CategoryContext;

		public PostController(IRepository<Post> postContext, IRepository<PostCategory> categoryContext) {
			context = postContext;
			CategoryContext = categoryContext;	
  }

		public ActionResult Index() {
			List<Post> posts = context.Collection().ToList();
			return View(posts);
		}

		public ActionResult Details(string Id) {
			Post posts = context.Find(Id);
			if (posts == null)
			{
				return HttpNotFound();
			}
			else {
				return View(posts);
			}
		}

		public ActionResult Create() {
			PostViewModel vm = new PostViewModel();

			vm.Posts = new Post();
			vm.PostCategories = CategoryContext.Collection();
			return View(vm);
		}

		[HttpPost]
		public ActionResult Create(Post posts) {
			if (!ModelState.IsValid)
			{
				return View(posts);
			}
			else {
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
			else {
				PostViewModel vm2 = new PostViewModel();
				vm2.Posts = posts;
				vm2.PostCategories = CategoryContext.Collection();

				return View(vm2);
			}
		}
		[HttpPost]
		public ActionResult Edit(Post posts, string Id) {
			Post postToEdit = context.Find(Id);
			if (postToEdit == null)
			{
				return View(posts);
			}
			else {
				postToEdit.Category = posts.Category;
				postToEdit.Title = posts.Title;
				postToEdit.Description = posts.Description;

				context.Commit();

				return RedirectToAction("Index");
			}
		}

		public ActionResult Delete(string Id) {
			Post posts = context.Find(Id);
			if (posts == null)
			{
				return HttpNotFound();
			}
			else {
				return View(posts);
			}
		}
		[HttpPost]
		[ActionName("Delete")]
		public ActionResult ConfirmToDelete(string Id) {
			Post postToDelete = context.Find(Id);
			if (postToDelete == null)
			{
				return HttpNotFound();
			}
			else {
				context.Delete(Id);
				context.Commit();

				return RedirectToAction("Index");
			}
		}


	}
}