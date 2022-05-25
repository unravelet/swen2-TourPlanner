using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using TourPlanner.ViewModels;
using TourPlanner.BL;

namespace TourPlanner {
    public class IoCContainerConfig {

        private readonly ServiceProvider _serviceProvider;

        public IoCContainerConfig() {

            var services = new ServiceCollection();

            services.AddSingleton<Businesslogic>();

            //ViewModels
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<LogViewModel>();
            services.AddSingleton<TourViewModel>();
            services.AddSingleton<NewTourViewModel>();
            services.AddSingleton<EditTourViewModel>();
            services.AddSingleton<EditTourLogViewModel>();
            services.AddSingleton<NewTourLogViewModel>();
            services.AddSingleton<ListViewModel>();

            _serviceProvider = services.BuildServiceProvider();
        }


        public MainViewModel MainViewModel 
            => _serviceProvider.GetService<MainViewModel>();
        public LogViewModel LogViewModel
            => _serviceProvider.GetService<LogViewModel>();
        public TourViewModel TourViewModel
            => _serviceProvider.GetService<TourViewModel>();
        public NewTourViewModel NewTourViewModel
            => _serviceProvider.GetService<NewTourViewModel>();
        public EditTourViewModel EditTourViewModel
            => _serviceProvider.GetService<EditTourViewModel>();
        public EditTourLogViewModel EditTourLogViewModel
            => _serviceProvider.GetService<EditTourLogViewModel>();
        public NewTourLogViewModel NewTourLogViewModel
            => _serviceProvider.GetService<NewTourLogViewModel>();
        public ListViewModel ListViewModel
            => _serviceProvider.GetService<ListViewModel>();

    }
}
