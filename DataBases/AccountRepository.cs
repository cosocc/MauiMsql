using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MauiMsql.DataBases;
public class AccountRepository : DbContext
{
    public DbSet<Admin> Admins { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Server=10.0.0.254;Port=3306;Database=mymovice;User=xxxxx;Password=xxxxxx;";
        optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 28)));
    }

  
    public async Task AddAdminAsync(Admin admin)
    {
        await Admins.AddAsync(admin);
        await SaveChangesAsync();
    }


    public async Task DeleteAdminAsync(Admin admin)
    {
        Admins.Remove(admin);
        await SaveChangesAsync();
    }


    public async Task<Admin> GetAdminByNameAsync(string name)
    {
        return await Admins.FirstOrDefaultAsync(admin => admin.f_name == name);
    }


    public async Task UpdateAdminAsync(Admin admin)
    {
        Admins.Update(admin);
        await SaveChangesAsync();
    }


    public async Task<List<Admin>> GetSortedAdminsAsync()
    {
        return await Admins.OrderBy(admin => admin.f_name).ToListAsync();
    }





}
