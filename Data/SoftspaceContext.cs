using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SoftSpace_web;

public partial class SoftspaceContext : DbContext
{
    public SoftspaceContext()
    {
    }

    public SoftspaceContext(DbContextOptions<SoftspaceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ability> Abilities { get; set; }

    public virtual DbSet<Baggage> Baggages { get; set; }

    public virtual DbSet<BlockUser> BlockUsers { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<ConfirmationEmail> ConfirmationEmails { get; set; }

    public virtual DbSet<Deal> Deals { get; set; }

    public virtual DbSet<DealProduct> DealProducts { get; set; }

    public virtual DbSet<Developer> Developers { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<DlcForProduct> DlcForProducts { get; set; }

    public virtual DbSet<EventProduct> EventProducts { get; set; }

    public virtual DbSet<LabelProduct> LabelProducts { get; set; }

    public virtual DbSet<Library> Libraries { get; set; }

    public virtual DbSet<LikedCategory> LikedCategories { get; set; }

    public virtual DbSet<LikedProduct> LikedProducts { get; set; }

    public virtual DbSet<PictureCategory> PictureCategories { get; set; }

    public virtual DbSet<PictureEvent> PictureEvents { get; set; }

    public virtual DbSet<PictureProduct> PictureProducts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<RecommendedProduct> RecommendedProducts { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RoleAbility> RoleAbilities { get; set; }

    public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }

    public virtual DbSet<SubscriptionOnDev> SubscriptionOnDevs { get; set; }

    public virtual DbSet<TypeOfSubscription> TypeOfSubscriptions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserDev> UserDevs { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<UserSubOnDev> UserSubOnDevs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("User ID =postgres; Password=postgres; Server=localhost; Database=softspace; Integrated Security=true; Pooling=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pgcrypto");

        modelBuilder.Entity<Ability>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("abilities_pkey");

            entity.ToTable("abilities");

            entity.HasIndex(e => e.Name, "abilities_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("'NaD'::text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Baggage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("baggage_pkey");

            entity.ToTable("baggage");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdDealProduct).HasColumnName("id_deal_product");
            entity.Property(e => e.IdUser).HasColumnName("id_user");

            entity.HasOne(d => d.IdDealProductNavigation).WithMany(p => p.Baggages)
                .HasForeignKey(d => d.IdDealProduct)
                .HasConstraintName("baggage_id_deal_product_fkey");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Baggages)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("baggage_id_user_fkey");
        });

        modelBuilder.Entity<BlockUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("block_user_pkey");

            entity.ToTable("block_user");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cause)
                .HasDefaultValueSql("'NaC'::text")
                .HasColumnName("cause");
            entity.Property(e => e.DateBegin)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_begin");
            entity.Property(e => e.DateEnd)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_end");
            entity.Property(e => e.IdUser).HasColumnName("id_user");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.BlockUsers)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("block_user_id_user_fkey");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("category_pkey");

            entity.ToTable("category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DefPicture)
                .HasMaxLength(100)
                .HasDefaultValueSql("'NaPicture'::character varying")
                .HasColumnName("def_picture");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("'NaD'::text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<ConfirmationEmail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("confirmation_email_pkey");

            entity.ToTable("confirmation_email");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .HasColumnName("code");
            entity.Property(e => e.DateBegin)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_begin");
            entity.Property(e => e.DateEnd)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_end");
            entity.Property(e => e.IdUser).HasColumnName("id_user");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.ConfirmationEmails)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("confirmation_email_id_user_fkey");
        });

        modelBuilder.Entity<Deal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("deal_pkey");

            entity.ToTable("deal");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateDeal)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_deal");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.TotalPrice)
                .HasPrecision(10, 2)
                .HasDefaultValueSql("0.00")
                .HasColumnName("total_price");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Deals)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("deal_id_user_fkey");
        });

        modelBuilder.Entity<DealProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("deal_product_pkey");

            entity.ToTable("deal_product");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.IdDeal).HasColumnName("id_deal");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasDefaultValueSql("0.00")
                .HasColumnName("price");

            entity.HasOne(d => d.IdDealNavigation).WithMany(p => p.DealProducts)
                .HasForeignKey(d => d.IdDeal)
                .HasConstraintName("deal_product_id_deal_fkey");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.DealProducts)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("deal_product_id_product_fkey");
        });

        modelBuilder.Entity<Developer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("developers_pkey");

            entity.ToTable("developers");

            entity.HasIndex(e => e.NameOfCompany, "developers_name_of_company_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .HasDefaultValueSql("'NaA'::character varying")
                .HasColumnName("address");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("'NaD'::text")
                .HasColumnName("description");
            entity.Property(e => e.Mail)
                .HasDefaultValueSql("'NaM'::text")
                .HasColumnName("mail");
            entity.Property(e => e.NameOfCompany)
                .HasMaxLength(50)
                .HasColumnName("name_of_company");
            entity.Property(e => e.Phone)
                .HasMaxLength(80)
                .HasDefaultValueSql("'NaP'::character varying")
                .HasColumnName("phone");
            entity.Property(e => e.Score)
                .HasPrecision(10, 2)
                .HasDefaultValueSql("0.00")
                .HasColumnName("score");
            entity.Property(e => e.UrlOnLogo)
                .HasMaxLength(100)
                .HasDefaultValueSql("'NaL'::character varying")
                .HasColumnName("url_on_logo");
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("discount_pkey");

            entity.ToTable("discount");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateBegin)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_begin");
            entity.Property(e => e.DateEnd)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_end");
            entity.Property(e => e.DiscountPrice)
                .HasPrecision(10, 2)
                .HasDefaultValueSql("0.00")
                .HasColumnName("discount_price");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Discounts)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("discount_id_product_fkey");
        });

        modelBuilder.Entity<DlcForProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("dlc_for_product_pkey");

            entity.ToTable("dlc_for_product");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.IdSubProduct).HasColumnName("id_sub_product");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.DlcForProductIdProductNavigations)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("dlc_for_product_id_product_fkey");

            entity.HasOne(d => d.IdSubProductNavigation).WithMany(p => p.DlcForProductIdSubProductNavigations)
                .HasForeignKey(d => d.IdSubProduct)
                .HasConstraintName("dlc_for_product_id_sub_product_fkey");
        });

        modelBuilder.Entity<EventProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("event_product_pkey");

            entity.ToTable("event_product");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateEvent)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_event");
            entity.Property(e => e.DefPicture)
                .HasMaxLength(100)
                .HasDefaultValueSql("'NaPicture'::character varying")
                .HasColumnName("def_picture");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("'NaD'::text")
                .HasColumnName("description");
            entity.Property(e => e.EventName)
                .HasMaxLength(100)
                .HasDefaultValueSql("'NaP'::character varying")
                .HasColumnName("event_name");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.EventProducts)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("event_product_id_product_fkey");
        });

        modelBuilder.Entity<LabelProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("label_product_pkey");

            entity.ToTable("label_product");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.LabelName)
                .HasMaxLength(20)
                .HasDefaultValueSql("'NaL'::character varying")
                .HasColumnName("label_name");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.LabelProducts)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("label_product_id_product_fkey");
        });

        modelBuilder.Entity<Library>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("library_pkey");

            entity.ToTable("library");

            entity.HasIndex(e => e.IdDealProduct, "library_id_deal_product_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CountHours).HasColumnName("count_hours");
            entity.Property(e => e.IdDealProduct).HasColumnName("id_deal_product");
            entity.Property(e => e.IdUser).HasColumnName("id_user");

            entity.HasOne(d => d.IdDealProductNavigation).WithOne(p => p.Library)
                .HasForeignKey<Library>(d => d.IdDealProduct)
                .HasConstraintName("library_id_deal_product_fkey");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Libraries)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("library_id_user_fkey");
        });

        modelBuilder.Entity<LikedCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("liked_category_pkey");

            entity.ToTable("liked_category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdCategory).HasColumnName("id_category");
            entity.Property(e => e.IdUser).HasColumnName("id_user");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.LikedCategories)
                .HasForeignKey(d => d.IdCategory)
                .HasConstraintName("liked_category_id_category_fkey");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.LikedCategories)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("liked_category_id_user_fkey");
        });

        modelBuilder.Entity<LikedProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("liked_product_pkey");

            entity.ToTable("liked_product");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.IdUser).HasColumnName("id_user");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.LikedProducts)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("liked_product_id_product_fkey");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.LikedProducts)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("liked_product_id_user_fkey");
        });

        modelBuilder.Entity<PictureCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("picture_category_pkey");

            entity.ToTable("picture_category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdCategory).HasColumnName("id_category");
            entity.Property(e => e.UrlPicture)
                .HasMaxLength(100)
                .HasDefaultValueSql("'NaPicture'::character varying")
                .HasColumnName("url_picture");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.PictureCategories)
                .HasForeignKey(d => d.IdCategory)
                .HasConstraintName("picture_category_id_category_fkey");
        });

        modelBuilder.Entity<PictureEvent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("picture_event_pkey");

            entity.ToTable("picture_event");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdEnvent).HasColumnName("id_envent");
            entity.Property(e => e.UrlPicture)
                .HasMaxLength(100)
                .HasDefaultValueSql("'NaU'::character varying")
                .HasColumnName("url_picture");

            entity.HasOne(d => d.IdEnventNavigation).WithMany(p => p.PictureEvents)
                .HasForeignKey(d => d.IdEnvent)
                .HasConstraintName("picture_event_id_envent_fkey");
        });

        modelBuilder.Entity<PictureProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("picture_product_pkey");

            entity.ToTable("picture_product");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.UrlPicture)
                .HasMaxLength(100)
                .HasDefaultValueSql("'NaU'::character varying")
                .HasColumnName("url_picture");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.PictureProducts)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("picture_product_id_product_fkey");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("product_pkey");

            entity.ToTable("product");

            entity.HasIndex(e => e.Name, "product_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DefPicture)
                .HasMaxLength(100)
                .HasDefaultValueSql("'NaPicture.png'::character varying")
                .HasColumnName("def_picture");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("'NaDescription'::text")
                .HasColumnName("description");
            entity.Property(e => e.IdCategory).HasColumnName("id_category");
            entity.Property(e => e.IdDev).HasColumnName("id_dev");
            entity.Property(e => e.IsDlc).HasColumnName("is_dlc");
            entity.Property(e => e.IsInvisuble).HasColumnName("is_invisuble");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasDefaultValueSql("0.00")
                .HasColumnName("price");
            entity.Property(e => e.UrlOnProduct)
                .HasMaxLength(100)
                .HasDefaultValueSql("'NaUrlOnProduct'::character varying")
                .HasColumnName("url_on_product");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdCategory)
                .HasConstraintName("product_id_category_fkey");

            entity.HasOne(d => d.IdDevNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdDev)
                .HasConstraintName("product_id_dev_fkey");
        });

        modelBuilder.Entity<RecommendedProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("recommended_product_pkey");

            entity.ToTable("recommended_product");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.IdUser).HasColumnName("id_user");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.RecommendedProducts)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("recommended_product_id_product_fkey");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.RecommendedProducts)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("recommended_product_id_user_fkey");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("review_pkey");

            entity.ToTable("review");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Assessment)
                .HasDefaultValueSql("'5'::smallint")
                .HasColumnName("assessment");
            entity.Property(e => e.CommentToProduct)
                .HasDefaultValueSql("'NaC'::text")
                .HasColumnName("comment_to_product");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.IdUser).HasColumnName("id_user");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("review_id_product_fkey");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("review_id_user_fkey");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.HasIndex(e => e.Name, "roles_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("'NaD'::text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<RoleAbility>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("role_abilities_pkey");

            entity.ToTable("role_abilities");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdAbilities).HasColumnName("id_abilities");
            entity.Property(e => e.IdRole).HasColumnName("id_role");

            entity.HasOne(d => d.IdAbilitiesNavigation).WithMany(p => p.RoleAbilities)
                .HasForeignKey(d => d.IdAbilities)
                .HasConstraintName("role_abilities_id_abilities_fkey");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.RoleAbilities)
                .HasForeignKey(d => d.IdRole)
                .HasConstraintName("role_abilities_id_role_fkey");
        });

        modelBuilder.Entity<ShoppingCart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("shopping_cart_pkey");

            entity.ToTable("shopping_cart");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.IdUser).HasColumnName("id_user");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.ShoppingCarts)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("shopping_cart_id_product_fkey");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.ShoppingCarts)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("shopping_cart_id_user_fkey");
        });

        modelBuilder.Entity<SubscriptionOnDev>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("subscription_on_dev_pkey");

            entity.ToTable("subscription_on_dev");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateBegin)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_begin");
            entity.Property(e => e.DateEnd)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_end");
            entity.Property(e => e.IdDev).HasColumnName("id_dev");
            entity.Property(e => e.IdType).HasColumnName("id_type");
            entity.Property(e => e.IdUser).HasColumnName("id_user");

            entity.HasOne(d => d.IdDevNavigation).WithMany(p => p.SubscriptionOnDevs)
                .HasForeignKey(d => d.IdDev)
                .HasConstraintName("subscription_on_dev_id_dev_fkey");

            entity.HasOne(d => d.IdTypeNavigation).WithMany(p => p.SubscriptionOnDevs)
                .HasForeignKey(d => d.IdType)
                .HasConstraintName("subscription_on_dev_id_type_fkey");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.SubscriptionOnDevs)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("subscription_on_dev_id_user_fkey");
        });

        modelBuilder.Entity<TypeOfSubscription>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("type_of_subscription_pkey");

            entity.ToTable("type_of_subscription");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CountDays).HasColumnName("count_days");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasDefaultValueSql("0.00")
                .HasColumnName("price");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.Login, "users_login_key").IsUnique();

            entity.HasIndex(e => e.Mail, "users_mail_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BonusScore)
                .HasPrecision(10, 2)
                .HasDefaultValueSql("0.00")
                .HasColumnName("bonus_score");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasDefaultValueSql("'Не указанно'::character varying")
                .HasColumnName("first_name");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .HasColumnName("login");
            entity.Property(e => e.Lvl)
                .HasDefaultValueSql("1")
                .HasColumnName("lvl");
            entity.Property(e => e.Mail).HasColumnName("mail");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.PictureProfile)
                .HasMaxLength(100)
                .HasDefaultValueSql("'NaPicture.png'::character varying")
                .HasColumnName("picture_profile");
            entity.Property(e => e.Score)
                .HasPrecision(10, 2)
                .HasDefaultValueSql("0.00")
                .HasColumnName("score");
            entity.Property(e => e.SecondName)
                .HasMaxLength(50)
                .HasDefaultValueSql("'Не указанно'::character varying")
                .HasColumnName("second_name");
        });

        modelBuilder.Entity<UserDev>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_dev_pkey");

            entity.ToTable("user_dev");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdDev).HasColumnName("id_dev");
            entity.Property(e => e.IdUser).HasColumnName("id_user");

            entity.HasOne(d => d.IdDevNavigation).WithMany(p => p.UserDevs)
                .HasForeignKey(d => d.IdDev)
                .HasConstraintName("user_dev_id_dev_fkey");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.UserDevs)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("user_dev_id_user_fkey");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_role_pkey");

            entity.ToTable("user_role");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdRole)
                .HasDefaultValueSql("1")
                .HasColumnName("id_role");
            entity.Property(e => e.IdUser).HasColumnName("id_user");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.IdRole)
                .HasConstraintName("user_role_id_role_fkey");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("user_role_id_user_fkey");
        });

        modelBuilder.Entity<UserSubOnDev>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_sub_on_dev_pkey");

            entity.ToTable("user_sub_on_dev");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdSubscription).HasColumnName("id_subscription");
            entity.Property(e => e.IdUser).HasColumnName("id_user");

            entity.HasOne(d => d.IdSubscriptionNavigation).WithMany(p => p.UserSubOnDevs)
                .HasForeignKey(d => d.IdSubscription)
                .HasConstraintName("user_sub_on_dev_id_subscription_fkey");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.UserSubOnDevs)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("user_sub_on_dev_id_user_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
