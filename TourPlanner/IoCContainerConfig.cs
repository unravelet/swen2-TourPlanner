using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using TourPlanner.ViewModels;

namespace TourPlanner {
    public class IoCContainerConfig {

        private readonly ServiceProvider _serviceProvider;

        public IoCContainerConfig() {

            var services = new ServiceCollection();


            //ViewModels
            services.AddSingleton <MainViewModel>();
            services.AddSingleton<ListViewModel>();
            services.AddSingleton<LogViewModel>();
            services.AddSingleton<TourViewModel>();

            _serviceProvider = services.BuildServiceProvider();
        }


        public MainViewModel MainViewModel 
            => _serviceProvider.GetService<MainViewModel>();    
    }
}
