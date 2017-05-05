using System.Collections.Generic;
using CrEST.Models;
using System;

namespace CrEST.BL
{
	public interface ISoW
	{
		IEnumerable<SoW> GetAll();

		SoW Get(int item);

		bool Put(SoW item);

		IEnumerable<SoW> FindSoW(int contractId, string serviceLine, DateTime expiryDate, string msOwner);
	}
}
