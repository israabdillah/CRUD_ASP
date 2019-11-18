﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Crud.Core.Contracts;
using Crud.Core.Models;

namespace Crud.WebUI.Controllers
{
    public class PostCategoryController : Controller
    {
		IRepository<PostCategory> context;

		public PostCategoryController(IRepository<PostCategory> context) {
			this.context = context;
		}
        public ActionResult Index()
        {
			List<PostCategory> postCategories = context.Collection().ToList();
			return View(postCategories);
        }

		public ActionResult Create() {
			PostCategory postCategory = new PostCategory();
			return View(postCategory);
		}

		[HttpPost]
		public ActionResult Create(PostCategory postCategory) {
			if (!ModelState.IsValid)
			{
				return View(postCategory);
			}
			else {
				context.Insert(postCategory);
				context.Commit();

				return RedirectToAction("Index");
			}
		}

		public ActionResult Edit(string Id) {
			PostCategory postCategories = context.Find(Id);
			if (postCategories == null)
			{
				return HttpNotFound();
			}
			else {
				return View(postCategories);
			}
		}
		[HttpPost]
		public ActionResult Edit(PostCategory postCategories, string Id) {
			PostCategory posttCategoryToEdit = context.Find(Id);
			if (posttCategoryToEdit == null)
			{
				return View(postCategories);
			}
			else {
				posttCategoryToEdit.Category = postCategories.Category;
				context.Commit();

				return RedirectToAction("Index");
			}
		}

		public ActionResult Delete(string Id) {
			PostCategory postCategories = context.Find(Id);
			if (postCategories == null)
			{
				return HttpNotFound();
			}
			else {
				return View(postCategories);
			}
		}
		[HttpPost]
		[ActionName("Delete")]
		public ActionResult ConfirmToDelete(PostCategory postCategories, string Id) {
			PostCategory postCategoryToDelete = context.Find(Id);
			if (postCategoryToDelete == null)
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