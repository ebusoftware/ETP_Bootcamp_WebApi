using Domain_CampFinalProject.Entities;
using Domain_CampFinalProject.Entities.Common;
using Domain_CampFinalProject.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.CampFinalProjectAPI.Contexts
{
    public class ShoppingListDbContext: IdentityDbContext<AppUser, AppRole, string>
    {
        public ShoppingListDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories  { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }
        public DbSet<ShoppingListItem> ShoppingListItems { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasKey(p=>p.Id);
            });
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(p=>p.CategoryId);

                entity.HasOne(d => d.Brand)
                    .WithMany(b => b.Products)
                    .HasForeignKey(d => d.BrandId);

            });

            modelBuilder.Entity<ShoppingListItem>(entity =>
            {

                entity.HasOne(s => s.Product)
                    .WithMany(l => l.ShoppingListItems)
                    .HasForeignKey(s => s.ProductId);

            });

            modelBuilder.Entity<ShoppingList>(entity =>
            {

                entity.HasMany(s => s.ShoppingListItems)
                    .WithMany(l => l.ShoppingLists);
                    

            });


            base.OnModelCreating(modelBuilder);
        }
    }
}
