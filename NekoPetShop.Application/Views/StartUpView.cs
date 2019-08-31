using System;
using NekoPetShop.Infrastructure;
using NekoPetShop.Application.Util;
using NekoPetShop.Core.DomainService;
using NekoPetShop.Core.ApplicationService;
using NekoPetShop.Infrastructure.Repositories;
using NekoPetShop.Core.ApplicationService.Services;
using Microsoft.Extensions.DependencyInjection;


namespace NekoPetShop.Application.Views
{
    class StartUpView : IView
    {
        private readonly string FILEPATHLOGO = AppContext.BaseDirectory + "\\TxtFiles\\LogoText.txt";


        public void Initialize()
        {
            ShowLogoASCII();
        }

        private void ShowLogoASCII()
        {
            ASCIIAnimator.Instance.CreateASCIIAnimation(FILEPATHLOGO, 35, 2, 3, true);
            ChangeToMainView();
        }

        private void ChangeToMainView()
        {
            FakeDB.InitializeData();
            ServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IOwnerRepository, OwnerRepository>();
            serviceCollection.AddScoped<IOwnerService, OwnerService>();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPetService, PetService>();
            serviceCollection.AddScoped<IView, PetView>();
            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            IView petView = serviceProvider.GetRequiredService<IView>();
            petView.Initialize();
        }
    }
}
