using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MM_demo_core.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<drug> drugs { get; set; }
        public DbSet<cart> carts { get; set; }
    }

    public class drug
    {
        [Key]
        public int EId { get; set; }

        public string Ename { get; set; }

        public string Eprize { get; set; }

        public string ImageUrl3 { get; set; }
        public Nullable<int> flag { get; set; }
        public string Eavailability { get; set; }
        public string Edescription { get; set; }
        public string Edetails { get; set; }
    }

    public class cart
    {
        [Key]
        public int Cid { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public Nullable<int> qty { get; set; }
        public Nullable<int> price { get; set; }
        public Nullable<int> bil { get; set; }
        public string Cemail { get; set; }
    }
}