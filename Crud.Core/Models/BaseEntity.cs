using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Core.Models
{
	public class BaseEntity
	{
		public string Id { get; set; }
		public DateTimeOffset CreateAt { get; set; }

		public BaseEntity()		
		{
			Id = Guid.NewGuid().ToString();
			CreateAt = DateTime.Now;
		}
	}
}
