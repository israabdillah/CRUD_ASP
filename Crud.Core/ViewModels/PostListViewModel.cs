using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crud.Core.Models;

namespace Crud.Core.ViewModels
{
	public class PostListViewModel
	{
		public IEnumerable<Post> Poste { get; set; }
		public IEnumerable<PostCategory> postCategories { get; set; }
	}
}
