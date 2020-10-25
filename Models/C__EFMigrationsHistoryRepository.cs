using System;
using System.Linq;
using System.Collections.Generic;

namespace MVC5Demo.Models
{
	public  class C__EFMigrationsHistoryRepository : EFRepository<C__EFMigrationsHistory>, IC__EFMigrationsHistoryRepository
	{

	}

	public  interface IC__EFMigrationsHistoryRepository : IRepository<C__EFMigrationsHistory>
	{

	}
}