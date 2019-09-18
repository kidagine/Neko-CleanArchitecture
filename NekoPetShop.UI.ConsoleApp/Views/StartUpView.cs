using System;
using Microsoft.Extensions.DependencyInjection;
using NekoPetShop.Core.DomainService;
using NekoPetShop.Core.ApplicationService;
using NekoPetShop.Core.ApplicationService.Services;
using NekoPetShop.Infrastructure.FakeData;
using NekoPetShop.Infrastructure.FakeData.Repositories;
using NekoPetShop.UI.ConsoleApp.Util;


namespace NekoPetShop.UI.ConsoleApp
{
    class StartUpView : IView
    {
        private readonly IPetService petService;
        private readonly IOwnerService ownerService;
        private readonly string FILEPATHLOGO = AppContext.BaseDirectory + "\\TxtFiles\\LogoText.txt";


        public StartUpView(IPetService petService, IOwnerService ownerService)
        {
            this.petService = petService;
            this.ownerService = ownerService;
        }

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
