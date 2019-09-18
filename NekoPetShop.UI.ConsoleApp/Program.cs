using System;
using Microsoft.Extensions.DependencyInjection;
using NekoPetShop.Core.DomainService;
using NekoPetShop.Core.ApplicationService;
using NekoPetShop.Core.ApplicationService.Services;
using NekoPetShop.Infrastructure.FakeData;
using NekoPetShop.Infrastructure.FakeData.Repositories;

namespace NekoPetShop.UI.ConsoleApp
{
    class Program
    {
        static void Main()
        {
            Console.Title = "NEKO-PetShop";
            FakeDB.InitializeData();

            ServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IOwnerRepository, OwnerRepository>();
            serviceCollection.AddScoped<IOwnerService, OwnerService>();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPetService, PetService>();
            serviceCollection.AddScoped<IView, StartUpView>();
            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            IView startUpView = serviceProvider.GetRequiredService<IView>();
            startUpView.Initialize();
        }
    }
}
