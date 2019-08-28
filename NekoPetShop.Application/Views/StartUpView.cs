using Microsoft.Extensions.DependencyInjection;
using NekoPetShop.Application.Util;
using NekoPetShop.Core.ApplicationService;
using NekoPetShop.Core.ApplicationService.Services;
using NekoPetShop.Core.DomainService;
using NekoPetShop.Infrastructure.Repositories;
using System;

namespace NekoPetShop.Application.Views
{
    class StartUpView : IView
    {
        private readonly string FILEPATHLOGO = AppContext.BaseDirectory + "\\TxtFiles\\LogoText.txt";

        public void Initialize()
        {
            Console.Clear();
            ShowLogoASCII();
        }

        private void ShowLogoASCII()
        {
            ASCIIAnimator.Instance.CreateASCIIAnimation(FILEPATHLOGO, 35, 2, 3, true);
            ChangeToMainView();
        }

        private void ChangeToMainView()
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPetService, PetService>();
            serviceCollection.AddScoped<IView, MainView>();
            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            IView mainView = serviceProvider.GetRequiredService<IView>();
            mainView.Initialize();
        }
    }
}
