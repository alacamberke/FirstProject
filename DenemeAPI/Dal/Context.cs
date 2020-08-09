using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class Context:DbContext
    {
        public Context():base("HaberKategoriDatabase")
            {
            }
        public DbSet<Haber> Habers { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<LogClass> Logs { get; set; }
    }
}
