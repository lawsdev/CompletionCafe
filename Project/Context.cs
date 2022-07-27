using Microsoft.EntityFrameworkCore;

public class Context : DbContext
{
   public Context() : base(){}
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to sqlite database
        options.UseSqlite(@"Data Source=CompletionCafe.db");
    }
   
   public DbSet<Accomplishment>? Accomplishments { get;set; }

   public DbSet<UserCategory>? UserCategorys { get;set; }
}