namespace small_online_store.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Items : DbContext
    {
        public Items()
            : base("name=ItemsEntitiy")
        {
        }

        public virtual DbSet<Item> ItemsUnites { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Item>()
                .Property(e => e.Photo)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.type)
                .IsUnicode(false);
        }
    }
}
