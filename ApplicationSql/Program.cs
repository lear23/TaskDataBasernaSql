using ApplicationSql.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaskDataBaseSql.Contexts;
using TaskDataBaseSql.PlayerRepo;
using TaskDataBaseSql.ProductService;
using TaskDataBaseSql.ProductsRepo;
using TaskDataBaseSql.Services;

var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{

    services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\source\repos\TaskDataBaseSql\TaskDataBaseSql\Data\DataBase.mdf;Integrated Security=True;Connect Timeout=30"));
    services.AddDbContext<ProductDataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\source\repos\TaskDataBaseSql\TaskDataBaseSql\Data\ProductDatabase.mdf;Integrated Security=True;Connect Timeout=30"));

    services.AddScoped<AddressRepo>();
    services.AddScoped<ClientRepo>();
    services.AddScoped<ContactRepo>();
    services.AddScoped<RoleRepo>();
    services.AddScoped<UserRepo>();

    services.AddScoped<CategoryRepo>();
    services.AddScoped<ClientsRepo>();   
    services.AddScoped<DirectionRepo>();
    services.AddScoped<ProductRepo>();
    services.AddScoped<ReaderRepo>();

    services.AddScoped<AddressService>();
    services.AddScoped<ClientService>();
    services.AddScoped<ContactService>();
    services.AddScoped<RoleService>();
    services.AddScoped<UserService>();

    services.AddScoped<CategoryService>();
    services.AddScoped<ClientsService>();
    services.AddScoped<DirectionService>();
    services.AddScoped<ProductService>();
    services.AddScoped<ReaderService>();


    //services.AddSingleton<PlayerMenuUI>();
    services.AddSingleton<ProductServiceUI>();


}).Build();

//var player = builder.Services.GetRequiredService<PlayerMenuUI>();
//player.CreatePlayer();
//player.GetPlayer();
//player.UpdatePlayer();
//player.DeletePlayer();

var rest = builder.Services.GetRequiredService<ProductServiceUI>();
//rest.CreateBuyerUI();
rest.GetBuyer();
//rest.UpdateBayer();
//rest.DeleteBayer();