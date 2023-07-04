using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GunShop.Models
{
    public partial class GunShopContext : DbContext
    {
        public GunShopContext()
        {
        }

        public GunShopContext(DbContextOptions<GunShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ammunition> Ammunitions { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<ManufacturerCompany> ManufacturerCompanies { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Receipt> Receipts { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<TypeOfWeapon> TypeOfWeapons { get; set; } = null!;
        public virtual DbSet<TypeProduct> TypeProducts { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Weapon> Weapons { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-JEM0NFNF\\SNAKESQL;Initial Catalog=GunShop;User ID=sa;Password=8312");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ammunition>(entity =>
            {
                entity.HasKey(e => e.IdAmmunition)
                    .HasName("PK__Ammuniti__23123D68A0C0FECC");

                entity.ToTable("Ammunition");

                entity.Property(e => e.IdAmmunition).HasColumnName("ID_Ammunition");

                entity.Property(e => e.Caliber)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ManufacturerCompanyId).HasColumnName("Manufacturer_company_ID");

                entity.Property(e => e.PriceAmmunition)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Price_Ammunition");

                entity.Property(e => e.Specification)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.ManufacturerCompany)
                    .WithMany(p => p.Ammunitions)
                    .HasForeignKey(d => d.ManufacturerCompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ammunitio__Manuf__6754599E");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.IdCountry)
                    .HasName("PK__Country__A204CB3A498CFB22");

                entity.ToTable("Country");

                entity.HasIndex(e => e.NameCountry, "UQ__Country__35D3F04A04CB72EB")
                    .IsUnique();

                entity.Property(e => e.IdCountry).HasColumnName("ID_Country");

                entity.Property(e => e.NameCountry)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Name_Country");
            });

            modelBuilder.Entity<ManufacturerCompany>(entity =>
            {
                entity.HasKey(e => e.IdManufacturerCompany)
                    .HasName("PK__Manufact__6FA9F6F0E52E6B43");

                entity.ToTable("Manufacturer_company");

                entity.HasIndex(e => e.NameManufacturerCompany, "UQ__Manufact__EBDCCE0AEBBF7589")
                    .IsUnique();

                entity.Property(e => e.IdManufacturerCompany).HasColumnName("ID_Manufacturer_company");

                entity.Property(e => e.CountryId).HasColumnName("Country_ID");

                entity.Property(e => e.NameManufacturerCompany)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Name_Manufacturer_company");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.ManufacturerCompanies)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Manufactu__Count__6383C8BA");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.IdProduct)
                    .HasName("PK__Product__522DE496F5B04429");

                entity.ToTable("Product");

                entity.Property(e => e.IdProduct).HasColumnName("ID_Product");

                entity.Property(e => e.AmmunitionId).HasColumnName("Ammunition_ID");

                entity.Property(e => e.ArticleProduct)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("Article_Product");

                entity.Property(e => e.QuantityOfAmmunition)
                    .HasColumnName("Quantity_of_Ammunition")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.QuantityOfWeapons)
                    .HasColumnName("Quantity_of_Weapons")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TypeProductId).HasColumnName("Type_Product_ID");

                entity.Property(e => e.WeaponId).HasColumnName("Weapon_ID");

                entity.HasOne(d => d.Ammunition)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.AmmunitionId)
                    .HasConstraintName("FK__Product__Ammunit__02084FDA");

                entity.HasOne(d => d.TypeProduct)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.TypeProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product__Type_Pr__02FC7413");

                entity.HasOne(d => d.Weapon)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.WeaponId)
                    .HasConstraintName("FK__Product__Weapon___01142BA1");
            });

            modelBuilder.Entity<Receipt>(entity =>
            {
                entity.HasKey(e => e.IdReceipt)
                    .HasName("PK__Receipt__5D2BAE15FCC1D936");

                entity.ToTable("Receipt");

                entity.HasIndex(e => e.ReceiptNumber, "UQ__Receipt__833C62A2706A1F95")
                    .IsUnique();

                entity.Property(e => e.IdReceipt).HasColumnName("ID_Receipt");

                entity.Property(e => e.DateOfBuy)
                    .HasColumnType("date")
                    .HasColumnName("Date_of_buy")
                    .HasDefaultValueSql("(CONVERT([date],getdate()))");

                entity.Property(e => e.FinalPrice)
                    .HasColumnType("decimal(36, 2)")
                    .HasColumnName("Final_price");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.Property(e => e.ReceiptNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("Receipt_number");

                entity.Property(e => e.TimeOfBuy)
                    .HasColumnName("Time_of_buy")
                    .HasDefaultValueSql("(CONVERT([time],getdate()))");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Receipts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Receipt__Product__0A9D95DB");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Receipts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Receipt__User_ID__09A971A2");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRole)
                    .HasName("PK__Role__43DCD32D54F6C4B2");

                entity.ToTable("Role");

                entity.HasIndex(e => e.NameRole, "UQ__Role__32E244D4D03D3DC6")
                    .IsUnique();

                entity.Property(e => e.IdRole).HasColumnName("ID_Role");

                entity.Property(e => e.NameRole)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Name_Role");
            });

            modelBuilder.Entity<TypeOfWeapon>(entity =>
            {
                entity.HasKey(e => e.IdTypeOfWeapon)
                    .HasName("PK__Type_of___F333702129C3DC62");

                entity.ToTable("Type_of_weapon");

                entity.HasIndex(e => e.NameTypeOfWeapon, "UQ__Type_of___995F8D3492599145")
                    .IsUnique();

                entity.Property(e => e.IdTypeOfWeapon).HasColumnName("ID_Type_of_weapon");

                entity.Property(e => e.NameTypeOfWeapon)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Name_Type_of_weapon");
            });

            modelBuilder.Entity<TypeProduct>(entity =>
            {
                entity.HasKey(e => e.IdTypeProduct)
                    .HasName("PK__Type_Pro__25A3726B014BC1D5");

                entity.ToTable("Type_Product");

                entity.HasIndex(e => e.NameTypeProduct, "UQ__Type_Pro__F67FD5C29100EEE7")
                    .IsUnique();

                entity.Property(e => e.IdTypeProduct).HasColumnName("ID_Type_Product");

                entity.Property(e => e.NameTypeProduct)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Name_Type_Product");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__User__ED4DE44268183CFE");

                entity.ToTable("User");

                entity.HasIndex(e => e.LoginUser, "UQ__User__5B6755AD9414CCA8")
                    .IsUnique();

                entity.HasIndex(e => e.WeaponPermitNumber, "UQ__User__723E8B0DBC7E9261")
                    .IsUnique();

                entity.HasIndex(e => e.Nickname, "UQ__User__CC6CD17E6159966F")
                    .IsUnique();

                entity.Property(e => e.IdUser).HasColumnName("ID_User");

                entity.Property(e => e.EmailAddressUser)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Email_address_User");

                entity.Property(e => e.FirstNameUser)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("First_Name_User");

                entity.Property(e => e.LoginUser)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Login_User");

                entity.Property(e => e.MiddleNameUser)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Middle_Name_User")
                    .HasDefaultValueSql("('-')");

                entity.Property(e => e.Nickname)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordUser)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Password_User");

                entity.Property(e => e.RoleId)
                    .HasColumnName("Role_ID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.SecondNameUser)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Second_Name_User");

                entity.Property(e => e.WeaponPermitNumber)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("Weapon_permit_number");

                entity.Property(e => e.YearOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("Year_of_birth");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User__Role_ID__571DF1D5");
            });

            modelBuilder.Entity<Weapon>(entity =>
            {
                entity.HasKey(e => e.IdWeapon)
                    .HasName("PK__Weapon__18DC7F8779047408");

                entity.ToTable("Weapon");

                entity.Property(e => e.IdWeapon).HasColumnName("ID_Weapon");

                entity.Property(e => e.AmmunitionId).HasColumnName("Ammunition_ID");

                entity.Property(e => e.BarrelLenth)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Barrel_lenth")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CombatRateOfFire)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Combat_rate_of_fire")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DetailsOfWeapon)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Details_of_Weapon");

                entity.Property(e => e.History)
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.ImageOfWeapon)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Image_of_Weapon")
                    .HasDefaultValueSql("('нет фото')");

                entity.Property(e => e.MagazineCopacity)
                    .HasColumnName("Magazine_Copacity")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ManufacturerCompanyId).HasColumnName("Manufacturer_company_ID");

                entity.Property(e => e.NameOfWeapon)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Name_of_Weapon");

                entity.Property(e => e.PriceWeapon)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Price_Weapon");

                entity.Property(e => e.SightingRange)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Sighting_range")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TypeOfWeaponId).HasColumnName("Type_of_Weapon_ID");

                entity.Property(e => e.WeaponLength)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Weapon_length");

                entity.Property(e => e.WeightWithAmmunition)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Weight_with_ammunition")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.WeightWithoutAmmunition)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Weight_without_ammunition")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Ammunition)
                    .WithMany(p => p.Weapons)
                    .HasForeignKey(d => d.AmmunitionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Weapon__Ammuniti__787EE5A0");

                entity.HasOne(d => d.ManufacturerCompany)
                    .WithMany(p => p.Weapons)
                    .HasForeignKey(d => d.ManufacturerCompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Weapon__Manufact__797309D9");

                entity.HasOne(d => d.TypeOfWeapon)
                    .WithMany(p => p.Weapons)
                    .HasForeignKey(d => d.TypeOfWeaponId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Weapon__Type_of___778AC167");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
