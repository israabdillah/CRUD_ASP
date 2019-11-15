using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crud.Core.Models;

namespace Crud.SQL
{
	public class DataContext : DbContext
	{
		public DataContext() : base("DefaultConnection") {
	
		}

		public DbSet<Post> Posts { get; set; }
    }
}
