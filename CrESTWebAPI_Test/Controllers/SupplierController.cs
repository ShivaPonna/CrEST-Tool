using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CrEST.BL;
using CrEST.Data;
using CrEST.Models;

namespace CrESTWebAPI_Test.Controllers
{
    [Route("api/[controller]")]
    public class SupplierController : Controller
    {		
		private readonly ISupplier _supplierRepository;

		//public ValuesController(IValue crestValueRepository)
		//{
		//	_crestValueRepository = crestValueRepository;
		//}

		public SupplierController()
		{
			CrESTContext _context = new CrEST.Data.CrESTContext();
			_supplierRepository = new SupplierRepository(_context);
		}

		// GET api/values
		[HttpGet]
        public IEnumerable<Supplier> GetAllSuppliers()
        {
			return _supplierRepository.GetAll();			
		}

		[HttpGet("{id}")]
		public Supplier GetSupplier(int id)
		{
			return _supplierRepository.Get(id);
		}

		[HttpPut("{id}")]		
		public bool PutSupplier([FromBody]Supplier item)
		{
			return _supplierRepository.Put(item);
		}		

		// DELETE api/values/5
		[HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
