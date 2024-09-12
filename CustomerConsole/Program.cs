using CustomerConsole;
using CustomerConsole.Repository;
using CustomerConsole.Repository.IRepository;
using Microsoft.Extensions.DependencyInjection;

var builder = new ServiceCollection()
    .AddSingleton<ICustomerDataProvider, FileCustomerDataProvider>()
    .AddSingleton<App>()
    .BuildServiceProvider();

var customerApp = builder.GetRequiredService<App>();

customerApp.SaveCustomerList();

customerApp.GetCustomerList();