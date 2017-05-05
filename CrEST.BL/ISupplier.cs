using System.Collections.Generic;
using CrEST.Models;

namespace CrEST.BL
{
	public interface ISupplier
	{
		IEnumerable<Supplier> GetAll();

		Supplier Get(int item);

		bool Put(Supplier item);		
	}
}
