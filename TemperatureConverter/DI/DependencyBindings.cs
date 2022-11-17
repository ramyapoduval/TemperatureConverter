
using Ninject.Modules;
using System.Reflection;
using TemperatureConverter.Services;
using TemperatureConverter.ViewModels;

namespace TemperatureConverter.DI
{
    public class DependencyBindings : NinjectModule
    { 
        public override void Load()
        {
            Bind<ICalculationService>().To<CalculationService>().InSingletonScope();
            Bind<ILog>().To<Logger>().InSingletonScope();
            Bind<IValidationService>().To<ValidationService>().InSingletonScope();
            Bind<ITemperatureVM>().To<TemperatureVM>().InTransientScope();
        }
    }
}
