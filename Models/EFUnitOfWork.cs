using System.Data.Entity;

namespace MVC5Demo.Models
{
	public class EFUnitOfWork : IUnitOfWork
	{
		public DbContext Context { get; set; }

		public EFUnitOfWork()
		{
			Context = new ContosoUniversityEntities();
		}

		public void Commit()
		{
			Context.SaveChanges();
		}

		public bool LazyLoadingEnabled
		{
			get { return Context.Configuration.LazyLoadingEnabled; }
			set { Context.Configuration.LazyLoadingEnabled = value; }
		}

		public bool ProxyCreationEnabled
		{
			get { return Context.Configuration.ProxyCreationEnabled; }
			set { Context.Configuration.ProxyCreationEnabled = value; }
		}

		public string ConnectionString
		{
			get { return Context.Database.Connection.ConnectionString; }
			set { Context.Database.Connection.ConnectionString = value; }
		}
	}
}
