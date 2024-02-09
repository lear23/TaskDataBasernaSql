

using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using TaskDataBaseSql.Contexts;

namespace TaskDataBaseSql.Factories;

public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\source\repos\TaskDataBaseSql\TaskDataBaseSql\Data\DataBase.mdf;Integrated Security=True;Connect Timeout=30");

        return new DataContext(optionsBuilder.Options);
    }
}
