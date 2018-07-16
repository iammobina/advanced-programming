

using System.Data.Entity;
using Project.DB;

namespace Repository
{
    public class Context : DbContext
    {
        public Context() : base("DBContext")
        { }
        public DbSet<StickyNote> StickyNotes { get; set; }


    }
}
