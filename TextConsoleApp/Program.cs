
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TextConsoleApp.ServicesText;
using TextConsoleApp.TextRepositories;
using TextInMemoryDatabase.ContextsText;
using TextInMemoryDatabase.Repositories;
using TextInMemoryDatabase.TextServicePlayer;

var builder = Host.CreateDefaultBuilder().ConfigureServices((hostContext, services) =>
{
    services.AddDbContext<DataContextText>(x => x.UseInMemoryDatabase($"{Guid.NewGuid()}"));

    services.AddScoped<TextAddressRepo>();
    services.AddScoped<TextContactRepo>();
    services.AddScoped<TextRoleRepo>();
    services.AddScoped<TextClientRepo>();
    services.AddScoped<TextUserRepo>();

    services.AddScoped<UserService>();

    services.AddSingleton<MainAddress>();
    services.AddSingleton<MainContact>();
    services.AddSingleton<MainRole>();
    services.AddSingleton<MainClient>();
    services.AddSingleton<MainUser>();

    services.AddSingleton<MainUserService>();

}).Build();


//var mainAddress = builder.Services.GetRequiredService<MainAddress>();
//var contact = builder.Services.GetRequiredService<MainContact>();
var role = builder.Services.GetRequiredService<MainRole>();
var client = builder.Services.GetRequiredService<MainClient>();
var user = builder.Services.GetRequiredService<MainUser>();
var userService = builder.Services.GetRequiredService<MainUserService>();

Console.Clear();


//-----------ADDRESS----------
//mainAddress.CreateAddress();
//mainAddress.ListAllAddres();

//-----------CONTACT----------
//contact.CreateContact();

//contact.ListAllContact();

//-----------Role----------
//role.CreateRole();
//role.ListAllRolle();

//-----------Client----------
//client.CreateClient();
//client.ListAllClient();

//-----------Client----------
//user.CreateUser();
//user.ListAllUser();



userService.CreateUserService();
userService.ListAllUserService();
