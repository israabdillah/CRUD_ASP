using System.Linq;

namespace Crud.Core.Contracts
{
	public interface IRepository<T>
	{
		IQueryable<T> Collection();
		void Commit();
		void Delete(string Id);
		T Find(string Id);
		void Insert(T t);
		void Update(T t);
	}
}