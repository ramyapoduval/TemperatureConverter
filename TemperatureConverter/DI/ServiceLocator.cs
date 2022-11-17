using Ninject;
using TemperatureConverter.ViewModels;

namespace TemperatureConverter.DI
{
    public class ServiceLocator
    {
        private readonly IKernel kernel;
        public ServiceLocator()
        {
            kernel = new StandardKernel(new DependencyBindings());
        }

        public MainWindowViewModel MainWindowViewModel
        {
            get { return kernel.Get<MainWindowViewModel>();  }
        }
    }
}
