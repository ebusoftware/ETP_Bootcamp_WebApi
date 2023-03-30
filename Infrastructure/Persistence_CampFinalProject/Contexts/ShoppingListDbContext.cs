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
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Endpoint> Endpoints { get; set; }



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

            modelBuilder.Entity<ShoppingListItem>(entity =>
            {

                entity.HasMany(s => s.ShoppingLists)
                    .WithOne(l => l.ShoppingListItem)
                    .HasForeignKey(s=>s.ItemId);
            });
            modelBuilder.Entity<ShoppingList>(entity =>
            {

                entity.HasOne(s => s.AppUser)
                    .WithMany(l => l.ShoppingLists)
                    .HasForeignKey(s => s.UserId);
            });
            //ilk migration da admin kullanıcısı tanımladık.
            AppUser appUsers = new() { Id=Guid.NewGuid().ToString(),Email = "admin@hotmail.com", UserName = "admin", NameSurname = "Yönetici Admin" };
            modelBuilder.Entity<AppUser>().HasData(appUsers);

            base.OnModelCreating(modelBuilder);

        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            /*ChangeTracker:Entityler üzerinde yapılan değişikliklerin ya da yeni eklenen verinin yakalanmasını sağlayan property dir.
            Update operasyonlarında Track edilen verileri yakalayıp elde etmemizi sağlıyor.*/
            var datas = ChangeTracker
                .Entries<Entity>();
            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                    _ => DateTime.UtcNow


                };

            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
