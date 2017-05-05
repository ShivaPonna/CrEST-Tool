using System.Collections.Generic;
using CrEST.Models;
using CrEST.Data;
using System.Linq;

namespace CrEST.BL
{
	public class SupplierRepository : ISupplier
	{
		private readonly CrESTContext _context;

		public SupplierRepository(CrESTContext context)
		{
			_context = context;
		}
		public IEnumerable<Supplier> GetAll()
		{
			return _context.Supplier.AsEnumerable();
		}
		public Supplier Get(int item)
		{
			return _context.Supplier.FirstOrDefault(s => s.SupplierId == item);
		}
		public bool Put(Supplier item)
		{
			if (item == null)
			{
				return false;
			}

			Supplier existingItem = _context.Supplier.FirstOrDefault(s => s.SupplierId == item.SupplierId);
			if (existingItem != null)
			{
				existingItem.SupplierName = item.SupplierName;
				existingItem.IsCrest = item.IsCrest;
				_context.Supplier.Update(existingItem);
			}
			else
			{
				_context.Supplier.Add(item);
			}

			_context.SaveChanges();
			return true;
		}

	}
}
