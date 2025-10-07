using CamCon.Domain.Enitity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.ApplicationDBContextService;
public class AppDbContext : IdentityDbContext<ApplicationUserModel>
{
    public DbSet<TokenInfoModel> TokenInfos { get; set; }
    public DbSet<ApplicationUserModel> Users { get; set; }
    public DbSet<ProfileInfo> ProfileInformations { get; set; }
    public DbSet<MyOrganizationModel> MyOrganizations { get; set; }
    public DbSet<DepartmentModel> Departments { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Rename Identity tables
        builder.Entity<IdentityRole>().ToTable("Roles");
        builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
        builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
        builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
        builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
        builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");

        // Rename your own table
        builder.Entity<ApplicationUserModel>().ToTable("Users");
        builder.Entity<TokenInfoModel>().ToTable("TokenInfos");
        builder.Entity<ProfileInfo>().ToTable("ProfileInformations");
        builder.Entity<MyOrganizationModel>().ToTable("MyOrganizations");
        builder.Entity<DepartmentModel>().ToTable("Departments");

    }
}