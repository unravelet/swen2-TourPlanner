using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using TourPlanner.BL;
using TourPlanner.BL.Services;
using TourPlanner.DAL.DB;
using TourPlanner.DAL.Repositories;
using TourPlanner.ViewModels;

namespace TourPlanner {
    public class IoCContainerConfig {

        private readonly ServiceProvider _serviceProvider;

        public IoCContainerConfig() {

            var services = new ServiceCollection();

            //Database and Repositories
            services.AddSingleton<Database>();
            services.AddSingleton<TourLogRepository>();
            services.AddSingleton<TourRepository>();

            //Services
            services.AddSingleton<MapQuestService>();
            services.AddSingleton<ReportService>();
            services.AddSingleton<UserInputService>();
            services.AddSingleton<ExportImportService>();


            //Businesslogic
            services.AddSingleton<Businesslogic>();

            //ViewModels
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<LogViewModel>();
            services.AddSingleton<NewTourViewModel>();
            services.AddSingleton<EditTourViewModel>();
            services.AddSingleton<EditTourLogViewModel>();
            services.AddSingleton<NewTourLogViewModel>();
            services.AddSingleton<RouteViewModel>();
            services.AddSingleton<DetailsViewModel>();
            services.AddSingleton<TourViewModel>();
            services.AddSingleton<MenuViewModel>();
            services.AddSingleton<ListViewModel>();

            _serviceProvider = services.BuildServiceProvider();
        }


        public MainViewModel MainViewModel
            => _serviceProvider.GetService<MainViewModel>();
        public LogViewModel LogViewModel
            => _serviceProvider.GetService<LogViewModel>();
        public NewTourViewModel NewTourViewModel
            => _serviceProvider.GetService<NewTourViewModel>();
        public EditTourViewModel EditTourViewModel
            => _serviceProvider.GetService<EditTourViewModel>();
        public EditTourLogViewModel EditTourLogViewModel
            => _serviceProvider.GetService<EditTourLogViewModel>();
        public NewTourLogViewModel NewTourLogViewModel
            => _serviceProvider.GetService<NewTourLogViewModel>();
        public RouteViewModel RouteViewModel
            => _serviceProvider.GetService<RouteViewModel>();
        public DetailsViewModel DetailsViewModel
            => _serviceProvider.GetService<DetailsViewModel>();
        public TourViewModel TourViewModel
            => _serviceProvider.GetService<TourViewModel>();
        public MenuViewModel MenuViewModel
            => _serviceProvider.GetService<MenuViewModel>();
        public ListViewModel ListViewModel
            => _serviceProvider.GetService<ListViewModel>();

    }
}
