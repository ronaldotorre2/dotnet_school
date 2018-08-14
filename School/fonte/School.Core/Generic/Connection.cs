using School.Core.Module.Person;
using System.Data.Entity;

namespace School.Core.Generic
{
    public class Connection: DbContext
    {
        public Connection() : base("ConnectionDB")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public new IDbSet<E> Set<E>() where E : class
        {
            return base.Set<E>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) { }

        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }

    }
}