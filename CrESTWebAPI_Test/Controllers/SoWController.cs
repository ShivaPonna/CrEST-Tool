using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CrEST.BL;
using CrEST.Data;
using CrEST.Models;

namespace CrESTWebAPI_Test.SoWControllers
{
    [Route("api/[controller]")]
    public class SowController : Controller
    {		
		private readonly ISoW _sowRepository;

		//public ValuesController(IValue crestValueRepository)
		//{
		//	_crestValueRepository = crestValueRepository;
		//}

		public SowController()
		{
			CrESTContext _context = new CrEST.Data.CrESTContext();
			_sowRepository = new SoWRepository(_context);
		}
		
		[HttpGet("{id}")]
		public SoW GetSoWs(int id)
		{
			return _sowRepository.Get(id);
		}

		[HttpPut("{id}")]		
		public bool PutSoW([FromBody]SoW item)
		{
			return _sowRepository.Put(item);
		}

		[HttpGet("{contractId}/'{serviceLine}'/{expiryDate}/'{msOwner}'")]
		public IEnumerable<SoW> FindSows([FromHeader]int contractId, string serviceLine, [FromHeader]DateTime expiryDate, string msOwner)
		{
			IEnumerable<SoW> results = _sowRepository.FindSoW(contractId, serviceLine, expiryDate, msOwner);			
			return results;
		}

		// DELETE api/values/5
		[HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
